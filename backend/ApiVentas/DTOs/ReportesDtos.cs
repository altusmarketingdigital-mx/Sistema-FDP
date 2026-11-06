namespace ApiVentas.DTOs;

public class ReporteMovimientoItemDto
{
    public int ID { get; set; }
    public int IdCliente { get; set; }
    public string NombreCliente { get; set; } = string.Empty;
    public string RFC { get; set; } = string.Empty;
    public int IDPedido { get; set; }
    public string Folio { get; set; } = string.Empty;
    public DateTime? FechaVentaPedido { get; set; }
    public int IDNotaRemision { get; set; }
    public DateTime? FechaNotaRemision { get; set; }
    public string NombreCajeroNota { get; set; } = string.Empty;
    public string EstatusNotas { get; set; } = string.Empty;
    public int IDCancelar { get; set; }
    public DateTime? FechaCancelar { get; set; }
    public string NombreCajeroCancela { get; set; } = string.Empty;
    public int IDPago { get; set; }
    public decimal SaldoAnterior { get; set; }
    public decimal SaldoNuevo { get; set; }
    public DateTime? FechaTimbrado { get; set; }
}

public class ResumenVentasDiaDto
{
    public DateTime Fecha { get; set; }
    public int TotalPedidos { get; set; }
    public double MontoTotal { get; set; }
    public double TotalCobrado { get; set; }
    public double TotalPendiente { get; set; }
}
