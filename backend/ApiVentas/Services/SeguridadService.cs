using System.Data;
using ApiVentas.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ApiVentas.Services;

public class SeguridadService
{
    private readonly string _seguridadConnStr;

    public SeguridadService(IConfiguration config)
    {
        _seguridadConnStr = config.GetConnectionString("Seguridad")
            ?? throw new InvalidOperationException("Cadena 'Seguridad' no configurada.");
    }

    public async Task<IEnumerable<UsuarioDetalleDto>> ObtenerUsuariosAsync()
    {
        await using var conn = new SqlConnection(_seguridadConnStr);
        await conn.OpenAsync();

        return await conn.QueryAsync<UsuarioDetalleDto>("sp_ListarUsuariosSistema", commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> RegistrarBitacoraAsync(int idUsuario, RegistrarBitacoraDto dto)
    {
        await using var conn = new SqlConnection(_seguridadConnStr);
        await conn.OpenAsync();

        var p = new DynamicParameters();
        p.Add("@intUsuario", idUsuario);
        p.Add("@intIdAplicacion", 1); // 1 = Cuentas por Cobrar / Ventas
        p.Add("@dttFecha", DateTime.Now);
        p.Add("@vchEquipo", "WEB-CLIENT");

        try
        {
            await conn.ExecuteAsync("spADDBitacoraUsoAplicaciones", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
