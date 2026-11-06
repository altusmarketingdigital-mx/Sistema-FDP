using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiVentas.DTOs;
using ApiVentas.Security;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace ApiVentas.Services;

public class AuthService
{
    private readonly IConfiguration _config;
    private readonly string _seguridadConnStr;
    private const int AppIdCxc = 1;

    public AuthService(IConfiguration config)
    {
        _config = config;
        _seguridadConnStr = _config.GetConnectionString("Seguridad") 
            ?? throw new InvalidOperationException("Cadena de conexión 'Seguridad' no encontrada.");
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Usuario) || string.IsNullOrWhiteSpace(request.Contrasena))
        {
            return new LoginResponseDto { Exito = false, Mensaje = "Usuario y contraseña requeridos." };
        }

        string passEncriptado = EncriptacionService.EncriptarContrasena(request.Contrasena);

        await using var conn = new SqlConnection(_seguridadConnStr);
        await conn.OpenAsync();

        // 1. Validar credenciales con Stored Procedure original
        var p = new DynamicParameters();
        p.Add("@vchUsuario", request.Usuario.Trim());
        p.Add("@vchContraseña", passEncriptado);
        p.Add("@IdApp", AppIdCxc);

        var respuestaValida = await conn.QueryFirstOrDefaultAsync<bool>(
            "spr_VerificaUsuario",
            p,
            commandType: CommandType.StoredProcedure
        );

        if (!respuestaValida)
        {
            return new LoginResponseDto { Exito = false, Mensaje = "Usuario o contraseña incorrectos." };
        }

        // 2. Obtener datos del usuario
        const string queryUsuario = @"
            SELECT PK_PermisoUsuario AS IdUsuario, 
                   vchUsuario AS Usuario, 
                   ISNULL(vchNombre, '') + ' ' + ISNULL(vchPaterno, '') AS NombreCompleto,
                   ISNULL(No_Nomina, '') AS Nomina,
                   ISNULL(vchCorreo, '') AS Correo,
                   ISNULL(bitAdmn, 0) AS EsAdmin,
                   bitActivo
            FROM Permisos_Usuarios
            WHERE vchUsuario = @Usuario";

        var usuario = await conn.QueryFirstOrDefaultAsync<dynamic>(queryUsuario, new { Usuario = request.Usuario.Trim() });

        if (usuario == null || !(bool)usuario.bitActivo)
        {
            return new LoginResponseDto { Exito = false, Mensaje = "El usuario está inactivo o no existe." };
        }

        var userInfo = new UsuarioInfoDto
        {
            IdUsuario = (int)usuario.IdUsuario,
            Usuario = (string)usuario.Usuario,
            NombreCompleto = ((string)usuario.NombreCompleto).Trim(),
            Nomina = (string)usuario.Nomina,
            Correo = (string)usuario.Correo,
            EsAdmin = (bool)usuario.EsAdmin
        };

        // 3. Generar JWT Token
        string token = GenerarJwtToken(userInfo);

        return new LoginResponseDto
        {
            Exito = true,
            Mensaje = "Autenticación exitosa.",
            Token = token,
            Usuario = userInfo
        };
    }

    public async Task<string> ObtenerMenuUsuarioAsync(string nomina)
    {
        await using var conn = new SqlConnection(_seguridadConnStr);
        await conn.OpenAsync();

        var p = new DynamicParameters();
        p.Add("@nomina", nomina);
        p.Add("@APP", AppIdCxc);
        p.Add("@jsonOutput", dbType: DbType.String, direction: ParameterDirection.Output, size: -1);

        await conn.ExecuteAsync("sp_MenuPorUsuario", p, commandType: CommandType.StoredProcedure);

        return p.Get<string>("@jsonOutput") ?? "{}";
    }

    private string GenerarJwtToken(UsuarioInfoDto usuario)
    {
        var jwtKey = _config["Jwt:Key"] ?? "ClaveSecretaSuperSeguraElyonVentas2026_JWT_Token_Key!";
        var issuer = _config["Jwt:Issuer"] ?? "ApiVentas";
        var audience = _config["Jwt:Audience"] ?? "WebElyonVentas";

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, usuario.Usuario),
            new Claim("idUsuario", usuario.IdUsuario.ToString()),
            new Claim("nomina", usuario.Nomina),
            new Claim("nombre", usuario.NombreCompleto),
            new Claim("correo", usuario.Correo),
            new Claim(ClaimTypes.Role, usuario.EsAdmin ? "Admin" : "User")
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(10),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
