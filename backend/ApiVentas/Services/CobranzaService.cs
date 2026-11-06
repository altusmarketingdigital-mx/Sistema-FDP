using System.Data;
using ApiVentas.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ApiVentas.Services;

public class CobranzaService
{
    private readonly string _inventarioConnStr;

    public CobranzaService(IConfiguration config)
    {
        _inventarioConnStr = config.GetConnectionString("Inventario")
            ?? throw new InvalidOperationException("Cadena 'Inventario' no configurada.");
    }

    public async Task<IEnumerable<NotaRemisionPendienteDto>> ObtenerNotasSinPagoAsync()
    {
        await using var conn = new SqlConnection(_inventarioConnStr);
        await conn.OpenAsync();

        var p = new DynamicParameters();
        p.Add("@PK_Id_Nota_Remision", 0);
        p.Add("@FK_Id_No_Pedido", 0);
        p.Add("@dtp_Fecha_Nota_Remision", DateTime.Now);
        p.Add("@FK_Id_Cajero", 0);
        p.Add("@vchEstatus_Nota_Remision", string.Empty);
        p.Add("@FK_Id_Cliente", 0);
        p.Add("@intAccion", 8); // 8 = Notas activas sin pago

        return await conn.QueryAsync<NotaRemisionPendienteDto>("sp_Tss_Nota_Remision", p, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> RegistrarPagoClienteAsync(RegistrarPagoDto dto)
    {
        await using var conn = new SqlConnection(_inventarioConnStr);
        await conn.OpenAsync();

        var fechaTimbrado = DateTime.Now;

        // 1. Guardar encabezado del pago
        var pEnc = new DynamicParameters();
        pEnc.Add("@PK_Id_Registro_Pago_Cliente", 0);
        pEnc.Add("@FK_Id_Cliente", dto.IdCliente);
        pEnc.Add("@FK_Id_Nota_Remision", dto.IdNotaRemision);
        pEnc.Add("@flt_Saldo_Anterior", dto.SaldoAnterior);
        pEnc.Add("@flt_Interes", dto.Interes);
        pEnc.Add("@flt_Saldo_Favor", dto.SaldoFavor);
        pEnc.Add("@flt_Pago_Aplicar", dto.PagoAplicar);
        pEnc.Add("@flt_Saldo_Nuevo", dto.SaldoNuevo);
        pEnc.Add("@dtp_Fecha_Timbrado", fechaTimbrado);
        pEnc.Add("@PK_Id_Registro_Pago_Cliente_Detalle", 0);
        pEnc.Add("@FK_Id_Registro_Pago_Cliente", 0);
        pEnc.Add("@FK_Id_Forma_Pago", 0);
        pEnc.Add("@flt_Importe_Pago", 0);
        pEnc.Add("@flt_Total_Pago", 0);
        pEnc.Add("@flt_Cambio_Pago", 0);
        pEnc.Add("@intAccion", 3); // 3 = Registro Pago

        using var multi = await conn.QueryMultipleAsync("sp_Tss_Registro_Pago_Cliente", pEnc, commandType: CommandType.StoredProcedure);
        var resCode = await multi.ReadFirstOrDefaultAsync<int>();
        var idPago = await multi.ReadFirstOrDefaultAsync<int>();

        if (idPago <= 0)
        {
            throw new Exception("Error al registrar el pago del cliente.");
        }

        // 2. Registrar detalle del cobro (cambio e importe)
        var pDet = new DynamicParameters();
        pDet.Add("@PK_Id_Registro_Pago_Cliente", 0);
        pDet.Add("@FK_Id_Cliente", 0);
        pDet.Add("@FK_Id_Nota_Remision", 0);
        pDet.Add("@flt_Saldo_Anterior", 0);
        pDet.Add("@flt_Interes", 0);
        pDet.Add("@flt_Saldo_Favor", 0);
        pDet.Add("@flt_Pago_Aplicar", 0);
        pDet.Add("@flt_Saldo_Nuevo", 0);
        pDet.Add("@dtp_Fecha_Timbrado", fechaTimbrado);
        pDet.Add("@PK_Id_Registro_Pago_Cliente_Detalle", 0);
        pDet.Add("@FK_Id_Registro_Pago_Cliente", idPago);
        pDet.Add("@FK_Id_Forma_Pago", dto.FormaPago);
        pDet.Add("@flt_Importe_Pago", dto.ImporteRecibido);
        pDet.Add("@flt_Total_Pago", dto.PagoAplicar);
        pDet.Add("@flt_Cambio_Pago", dto.Cambio);
        pDet.Add("@intAccion", 4); // 4 = Registro Detalle

        await conn.ExecuteAsync("sp_Tss_Registro_Pago_Cliente", pDet, commandType: CommandType.StoredProcedure);

        // 3. Si se liquida completamente, actualizar estatus de nota a 'Pagado'
        if (dto.SaldoNuevo <= 0.01)
        {
            var pNota = new DynamicParameters();
            pNota.Add("@PK_Id_Nota_Remision", dto.IdNotaRemision);
            pNota.Add("@FK_Id_No_Pedido", 0);
            pNota.Add("@dtp_Fecha_Nota_Remision", DateTime.Now);
            pNota.Add("@FK_Id_Cajero", 0);
            pNota.Add("@vchEstatus_Nota_Remision", string.Empty);
            pNota.Add("@FK_Id_Cliente", 0);
            pNota.Add("@intAccion", 5); // 5 = Estado Pagado

            await conn.ExecuteAsync("sp_Tss_Nota_Remision", pNota, commandType: CommandType.StoredProcedure);
        }

        return idPago;
    }

    public async Task<IEnumerable<PagoRegistradoResumenDto>> ObtenerHistorialPagosAsync()
    {
        await using var conn = new SqlConnection(_inventarioConnStr);
        await conn.OpenAsync();

        return await conn.QueryAsync<PagoRegistradoResumenDto>("spSEL_Pago_Cliente", commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> CancelarNotaRemisionAsync(int idCajero, CancelarRemisionDto dto)
    {
        await using var conn = new SqlConnection(_inventarioConnStr);
        await conn.OpenAsync();

        // 1. Validar que no tenga pagos registrados
        var pVal = new DynamicParameters();
        pVal.Add("@PK_Id_Registro_Pago_Cliente", 0);
        pVal.Add("@FK_Id_Cliente", 0);
        pVal.Add("@FK_Id_Nota_Remision", dto.IdNotaRemision);
        pVal.Add("@flt_Saldo_Anterior", 0);
        pVal.Add("@flt_Interes", 0);
        pVal.Add("@flt_Saldo_Favor", 0);
        pVal.Add("@flt_Pago_Aplicar", 0);
        pVal.Add("@flt_Saldo_Nuevo", 0);
        pVal.Add("@dtp_Fecha_Timbrado", DateTime.Now);
        pVal.Add("@PK_Id_Registro_Pago_Cliente_Detalle", 0);
        pVal.Add("@FK_Id_Registro_Pago_Cliente", 0);
        pVal.Add("@FK_Id_Forma_Pago", 0);
        pVal.Add("@flt_Importe_Pago", 0);
        pVal.Add("@flt_Total_Pago", 0);
        pVal.Add("@flt_Cambio_Pago", 0);
        pVal.Add("@intAccion", 5); // 5 = Validar que no tenga pago

        var tienePago = await conn.QueryFirstOrDefaultAsync<int>("sp_Tss_Registro_Pago_Cliente", pVal, commandType: CommandType.StoredProcedure);
        if (tienePago == 1)
        {
            throw new InvalidOperationException("No se puede cancelar la nota de remisión porque ya cuenta con pagos registrados.");
        }

        // 2. Registrar en tabla de cancelaciones
        var pCanc = new DynamicParameters();
        pCanc.Add("@PK_Id_Cancelar_Nota_Remisio", 0);
        pCanc.Add("@FK_Id_Nota_Remision", dto.IdNotaRemision);
        pCanc.Add("@dtp_Fecha", DateTime.Now);
        pCanc.Add("@FK_Id_Cajero", idCajero);
        pCanc.Add("@intAccion", 1);
        await conn.ExecuteAsync("sp_Tss_Cancelar_Nota_Remision", pCanc, commandType: CommandType.StoredProcedure);

        // 3. Cancelar la nota de remisión en Tss_Nota_Remision
        pCanc = new DynamicParameters();
        pCanc.Add("@PK_Id_Cancelar_Nota_Remisio", 0);
        pCanc.Add("@FK_Id_Nota_Remision", dto.IdNotaRemision);
        pCanc.Add("@dtp_Fecha", DateTime.Now);
        pCanc.Add("@FK_Id_Cajero", idCajero);
        pCanc.Add("@intAccion", 3);
        await conn.ExecuteAsync("sp_Tss_Cancelar_Nota_Remision", pCanc, commandType: CommandType.StoredProcedure);

        // 4. Liberar el pedido asociado
        pCanc = new DynamicParameters();
        pCanc.Add("@PK_Id_Cancelar_Nota_Remisio", 0);
        pCanc.Add("@FK_Id_Nota_Remision", dto.IdNotaRemision);
        pCanc.Add("@dtp_Fecha", DateTime.Now);
        pCanc.Add("@FK_Id_Cajero", idCajero);
        pCanc.Add("@intAccion", 2);
        await conn.ExecuteAsync("sp_Tss_Cancelar_Nota_Remision", pCanc, commandType: CommandType.StoredProcedure);

        return true;
    }
}
