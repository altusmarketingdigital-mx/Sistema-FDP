using System.Data;
using ApiVentas.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ApiVentas.Services;

public class VentasService
{
    private readonly string _inventarioConnStr;

    public VentasService(IConfiguration config)
    {
        _inventarioConnStr = config.GetConnectionString("Inventario")
            ?? throw new InvalidOperationException("Cadena 'Inventario' no configurada.");
    }

    public async Task<int> ObtenerSiguienteFolioAsync()
    {
        await using var conn = new SqlConnection(_inventarioConnStr);
        await conn.OpenAsync();

        var p = new DynamicParameters();
        p.Add("@intAccion", 1);
        p.Add("@PK_Id_Genera_Pedido", 0);
        p.Add("@vchFolio", string.Empty);
        p.Add("@FK_Id_Usuario", 0);
        p.Add("@dtp_FechaVenta", DateTime.Now);
        p.Add("@FK_Id_Cliente", 0);
        p.Add("@intDiasCredito", 0);
        p.Add("@dtp_FechaVencimientoCredito", DateTime.Now);
        p.Add("@FK_Metodo_Pago", 0);
        p.Add("@FK_Forma_Pago", 0);
        p.Add("@flt_TotalVenta", 0);
        p.Add("@vchComentario", string.Empty);
        p.Add("@PK_Id_Generar_Pedido_Detalle", 0);
        p.Add("@FK_Id_Generar_Pedido", 0);
        p.Add("@FK_Id_Clave_Producto", string.Empty);
        p.Add("@fltCantidad", 0);
        p.Add("@vchComentarioProducto", string.Empty);
        p.Add("@vchUmVenta", string.Empty);
        p.Add("@fltPrecioVenta", 0);
        p.Add("@dcDescuento", 0);
        p.Add("@fltImporte", 0);

        return await conn.QueryFirstOrDefaultAsync<int>("sp_Tss_Generar_Pedido", p, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> RegistrarPedidoAsync(int idUsuario, GenerarPedidoDto dto)
    {
        await using var conn = new SqlConnection(_inventarioConnStr);
        await conn.OpenAsync();

        var fechaVenta = DateTime.Now;
        var fechaVence = fechaVenta.AddDays(dto.DiasCredito);
        double total = dto.Partidas.Sum(p => p.Importe);

        // 1. Guardar Encabezado
        var pEncabezado = new DynamicParameters();
        pEncabezado.Add("@intAccion", 2); // 2 = Registro Encabezado
        pEncabezado.Add("@PK_Id_Genera_Pedido", 0);
        pEncabezado.Add("@vchFolio", dto.Folio);
        pEncabezado.Add("@FK_Id_Usuario", idUsuario);
        pEncabezado.Add("@dtp_FechaVenta", fechaVenta);
        pEncabezado.Add("@FK_Id_Cliente", dto.IdCliente);
        pEncabezado.Add("@intDiasCredito", dto.DiasCredito);
        pEncabezado.Add("@dtp_FechaVencimientoCredito", fechaVence);
        pEncabezado.Add("@FK_Metodo_Pago", dto.MetodoPago);
        pEncabezado.Add("@FK_Forma_Pago", 0);
        pEncabezado.Add("@flt_TotalVenta", total);
        pEncabezado.Add("@vchComentario", dto.Comentario ?? string.Empty);
        pEncabezado.Add("@PK_Id_Generar_Pedido_Detalle", 0);
        pEncabezado.Add("@FK_Id_Generar_Pedido", 0);
        pEncabezado.Add("@FK_Id_Clave_Producto", string.Empty);
        pEncabezado.Add("@fltCantidad", 0);
        pEncabezado.Add("@vchComentarioProducto", string.Empty);
        pEncabezado.Add("@vchUmVenta", string.Empty);
        pEncabezado.Add("@fltPrecioVenta", 0);
        pEncabezado.Add("@dcDescuento", 0);
        pEncabezado.Add("@fltImporte", 0);

        using var multi = await conn.QueryMultipleAsync("sp_Tss_Generar_Pedido", pEncabezado, commandType: CommandType.StoredProcedure);
        var resCode = await multi.ReadFirstOrDefaultAsync<int>();
        var idPedido = await multi.ReadFirstOrDefaultAsync<int>();

        if (idPedido <= 0)
        {
            throw new Exception("Error al registrar el encabezado del pedido.");
        }

        // 2. Guardar Partidas de Detalle
        foreach (var item in dto.Partidas)
        {
            var pDet = new DynamicParameters();
            pDet.Add("@intAccion", 3); // 3 = Registro Detalle
            pDet.Add("@PK_Id_Genera_Pedido", 0);
            pDet.Add("@vchFolio", string.Empty);
            pDet.Add("@FK_Id_Usuario", 0);
            pDet.Add("@dtp_FechaVenta", fechaVenta);
            pDet.Add("@FK_Id_Cliente", 0);
            pDet.Add("@intDiasCredito", 0);
            pDet.Add("@dtp_FechaVencimientoCredito", fechaVence);
            pDet.Add("@FK_Metodo_Pago", 0);
            pDet.Add("@FK_Forma_Pago", 0);
            pDet.Add("@flt_TotalVenta", 0);
            pDet.Add("@vchComentario", string.Empty);
            pDet.Add("@PK_Id_Generar_Pedido_Detalle", 0);
            pDet.Add("@FK_Id_Generar_Pedido", idPedido);
            pDet.Add("@FK_Id_Clave_Producto", item.ClaveProducto);
            pDet.Add("@fltCantidad", item.Cantidad);
            pDet.Add("@vchComentarioProducto", item.ComentarioProducto ?? string.Empty);
            pDet.Add("@vchUmVenta", item.UmVenta ?? "PZA");
            pDet.Add("@fltPrecioVenta", item.PrecioVenta);
            pDet.Add("@dcDescuento", item.Descuento);
            pDet.Add("@fltImporte", item.Importe);

            await conn.ExecuteAsync("sp_Tss_Generar_Pedido", pDet, commandType: CommandType.StoredProcedure);
        }

        return idPedido;
    }

    public async Task<IEnumerable<PedidoResumenDto>> ObtenerHistorialPedidosAsync()
    {
        await using var conn = new SqlConnection(_inventarioConnStr);
        await conn.OpenAsync();

        var p = new DynamicParameters();
        p.Add("@intAccion", 6); // 6 = Historial
        p.Add("@PK_Id_Genera_Pedido", 0);
        p.Add("@vchFolio", string.Empty);
        p.Add("@FK_Id_Usuario", 0);
        p.Add("@dtp_FechaVenta", DateTime.Now);
        p.Add("@FK_Id_Cliente", 0);
        p.Add("@intDiasCredito", 0);
        p.Add("@dtp_FechaVencimientoCredito", DateTime.Now);
        p.Add("@FK_Metodo_Pago", 0);
        p.Add("@FK_Forma_Pago", 0);
        p.Add("@flt_TotalVenta", 0);
        p.Add("@vchComentario", string.Empty);
        p.Add("@PK_Id_Generar_Pedido_Detalle", 0);
        p.Add("@FK_Id_Generar_Pedido", 0);
        p.Add("@FK_Id_Clave_Producto", string.Empty);
        p.Add("@fltCantidad", 0);
        p.Add("@vchComentarioProducto", string.Empty);
        p.Add("@vchUmVenta", string.Empty);
        p.Add("@fltPrecioVenta", 0);
        p.Add("@dcDescuento", 0);
        p.Add("@fltImporte", 0);

        return await conn.QueryAsync<PedidoResumenDto>("sp_Tss_Generar_Pedido", p, commandType: CommandType.StoredProcedure);
    }

    public async Task<TicketPedidoDto> ObtenerDatosTicketAsync(int idPedido)
    {
        await using var conn = new SqlConnection(_inventarioConnStr);
        await conn.OpenAsync();

        using var multi = await conn.QueryMultipleAsync("spObtenerBoletaPedido", new { idPedido }, commandType: CommandType.StoredProcedure);

        var encabezado = await multi.ReadFirstOrDefaultAsync<EncabezadoTicketDto>() ?? new EncabezadoTicketDto();
        var articulosRaw = (await multi.ReadAsync<dynamic>()).ToList();
        var empresa = await multi.ReadFirstOrDefaultAsync<ContribuyenteTicketDto>() ?? new ContribuyenteTicketDto();

        var ticket = new TicketPedidoDto
        {
            Encabezado = encabezado,
            Empresa = empresa,
            Articulos = articulosRaw.Select(r => new PartidaTicketDto
            {
                Clave = (string)r.CLAVE_PRODUCTO,
                Descripcion = (string)r.DESCRIPCION,
                Cantidad = (string)r.CANTIDAD,
                Precio = Convert.ToDouble(r.PRECIO),
                Descuento = Convert.ToDecimal(r.DESCUENTO),
                Importe = Convert.ToDouble(r.IMPORTE)
            }).ToList()
        };

        ticket.Total = ticket.Articulos.Sum(a => a.Importe);
        if (articulosRaw.Count > 0)
        {
            ticket.MontoLetra = (string)articulosRaw[0].Letra;
        }

        return ticket;
    }
}
