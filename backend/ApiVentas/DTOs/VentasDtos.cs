namespace ApiVentas.DTOs;

public class GenerarPedidoDto
{
    public string Folio { get; set; } = "PED";
    public int IdCliente { get; set; }
    public int DiasCredito { get; set; }
    public int MetodoPago { get; set; } = 1; // 1 = Contado / Efectivo
    public string Comentario { get; set; } = string.Empty;
    public List<DetallePedidoDto> Partidas { get; set; } = new();
}

public class DetallePedidoDto
{
    public string ClaveProducto { get; set; } = string.Empty;
    public string NombreProducto { get; set; } = string.Empty;
    public double Cantidad { get; set; }
    public string UmVenta { get; set; } = "PZA";
    public double PrecioVenta { get; set; }
    public decimal Descuento { get; set; } = 0;
    public double Importe => (Cantidad * PrecioVenta) - (double)Descuento;
    public string ComentarioProducto { get; set; } = string.Empty;
}

public class PedidoResumenDto
{
    public int Id_Pedido { get; set; }
    public string Folio { get; set; } = string.Empty;
    public string Id { get; set; } = string.Empty;
    public int Id_Cajero { get; set; }
    public DateTime Fecha_Venta { get; set; }
    public int Id_Cliente { get; set; }
    public string Nombre_Cliente { get; set; } = string.Empty;
    public int Dias_Credito { get; set; }
    public DateTime? Vencha_Vencimiento { get; set; }
}

public class TicketPedidoDto
{
    public EncabezadoTicketDto Encabezado { get; set; } = new();
    public List<PartidaTicketDto> Articulos { get; set; } = new();
    public ContribuyenteTicketDto Empresa { get; set; } = new();
    public double Total { get; set; }
    public string MontoLetra { get; set; } = string.Empty;
}

public class EncabezadoTicketDto
{
    public int Id { get; set; }
    public string Folio { get; set; } = string.Empty;
    public string Fecha { get; set; } = string.Empty;
    public string Hora { get; set; } = string.Empty;
    public string Condicion { get; set; } = string.Empty;
    public string Cajero { get; set; } = string.Empty;
    public string Comentario { get; set; } = string.Empty;
}

public class PartidaTicketDto
{
    public string Clave { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Cantidad { get; set; } = string.Empty;
    public double Precio { get; set; }
    public decimal Descuento { get; set; }
    public double Importe { get; set; }
}

public class ContribuyenteTicketDto
{
    public string RazonSocial { get; set; } = string.Empty;
    public string RFC { get; set; } = string.Empty;
    public string Domicilio { get; set; } = string.Empty;
    public string Colonia { get; set; } = string.Empty;
    public string CP { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
}
