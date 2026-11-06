namespace ApiVentas.DTOs;

public class LoginRequestDto
{
    public string Usuario { get; set; } = string.Empty;
    public string Contrasena { get; set; } = string.Empty;
}

public class LoginResponseDto
{
    public bool Exito { get; set; }
    public string Mensaje { get; set; } = string.Empty;
    public string? Token { get; set; }
    public UsuarioInfoDto? Usuario { get; set; }
}

public class UsuarioInfoDto
{
    public int IdUsuario { get; set; }
    public string Usuario { get; set; } = string.Empty;
    public string NombreCompleto { get; set; } = string.Empty;
    public string Nomina { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public bool EsAdmin { get; set; }
}
