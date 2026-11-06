namespace ApiVentas.DTOs;

public class RegistrarPagoDto
{
    public int IdCliente { get; set; }
    public int IdNotaRemision { get; set; }
    public double SaldoAnterior { get; set; }
    public double Interes { get; set; } = 0;
    public double SaldoFavor { get; set; } = 0;
    public double PagoAplicar { get; set; }
    public double SaldoNuevo => Math.Max(0, (SaldoAnterior + Interes) - (PagoAplicar + SaldoFavor));
    public int FormaPago { get; set; } = 1; // 1 = Efectivo
    public double ImporteRecibido { get; set; }
    public double Cambio => Math.Max(0, ImporteRecibido - PagoAplicar);
}

public class PagoRegistradoResumenDto
{
    public int ID { get; set; }
    public int IDCLIENTE { get; set; }
    public string NOMBRE { get; set; } = string.Empty;
    public int IDNOTA { get; set; }
    public double SALDO_ANTERIOR { get; set; }
    public double SALDO_NUEVO { get; set; }
    public DateTime FECHATIMBRADO { get; set; }
}

public class NotaRemisionPendienteDto
{
    public int No_Nota { get; set; }
    public string No_Pedido { get; set; } = string.Empty;
    public string Cliente { get; set; } = string.Empty;
    public string Cajero { get; set; } = string.Empty;
    public DateTime Fecha_Remision { get; set; }
    public DateTime Fecha_Venta { get; set; }
    public DateTime Fecha_Vencimiento { get; set; }
    public int Dias_Credito { get; set; }
}

public class CancelarRemisionDto
{
    public int IdNotaRemision { get; set; }
    public string Motivo { get; set; } = string.Empty;
}
