namespace ApiVentas.DTOs;

public class UsuarioDetalleDto
{
    public int IdUsuario { get; set; }
    public string Usuario { get; set; } = string.Empty;
    public string NombreCompleto { get; set; } = string.Empty;
    public string Nomina { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public bool Activo { get; set; }
    public bool EsAdmin { get; set; }
    public DateTime? FechaCreacion { get; set; }
}

public class RegistrarBitacoraDto
{
    public string Accion { get; set; } = string.Empty;
    public string Detalle { get; set; } = string.Empty;
}
