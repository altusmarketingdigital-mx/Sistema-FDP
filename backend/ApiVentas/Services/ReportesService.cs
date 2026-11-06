using System.Data;
using ApiVentas.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ApiVentas.Services;

public class ReportesService
{
    private readonly string _inventarioConnStr;

    public ReportesService(IConfiguration config)
    {
        _inventarioConnStr = config.GetConnectionString("Inventario")
            ?? throw new InvalidOperationException("Cadena 'Inventario' no configurada.");
    }

    public async Task<IEnumerable<ReporteMovimientoItemDto>> ObtenerReporteMovimientosAsync(string tipoFiltro = "", int idFiltro = 0)
    {
        await using var conn = new SqlConnection(_inventarioConnStr);
        await conn.OpenAsync();

        var p = new DynamicParameters();
        p.Add("@vchDescripcion", tipoFiltro);
        p.Add("@intTipo", idFiltro);

        return await conn.QueryAsync<ReporteMovimientoItemDto>("spSELReporteMovimientos", p, commandType: CommandType.StoredProcedure);
    }

    public async Task<ResumenVentasDiaDto> ObtenerResumenDiaAsync()
    {
        await using var conn = new SqlConnection(_inventarioConnStr);
        await conn.OpenAsync();

        using var multi = await conn.QueryMultipleAsync("sp_ResumenVentasDia", commandType: CommandType.StoredProcedure);
        var pedidos = await multi.ReadFirstOrDefaultAsync<dynamic>();
        var totalCobrado = await multi.ReadFirstOrDefaultAsync<double>();

        double montoTotal = pedidos != null ? Convert.ToDouble(pedidos.MontoTotal) : 0;
        int countPedidos = pedidos != null ? Convert.ToInt32(pedidos.TotalPedidos) : 0;

        return new ResumenVentasDiaDto
        {
            Fecha = DateTime.Today,
            TotalPedidos = countPedidos,
            MontoTotal = montoTotal,
            TotalCobrado = totalCobrado,
            TotalPendiente = Math.Max(0, montoTotal - totalCobrado)
        };
    }
}
