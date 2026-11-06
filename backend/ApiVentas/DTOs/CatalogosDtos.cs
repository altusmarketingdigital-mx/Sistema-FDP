namespace ApiVentas.DTOs;

public class ProductoDto
{
    public int Id { get; set; }
    public string Clave { get; set; } = string.Empty;
    public string Producto { get; set; } = string.Empty;
    public string Localizacion { get; set; } = string.Empty;
    public bool Tiene_Decimal { get; set; }
    public string UM_Compra { get; set; } = string.Empty;
    public string UM_Venta { get; set; } = string.Empty;
    public string Contenido { get; set; } = string.Empty;
    public int Clave_Grupo { get; set; }
    public int Clave_Departamento { get; set; }
    public string Inventario_Minimo { get; set; } = string.Empty;
    public string Inventario_Maximo { get; set; } = string.Empty;
    public bool Producto_Excento { get; set; }
    public double IEPS { get; set; }
    public double IVA { get; set; }
    public double Precio_Compra { get; set; }
    public double Margen_Utilidad_1 { get; set; }
    public double Precio_Venta_1 { get; set; }
    public double Margen_Utilidad_2 { get; set; }
    public double Precio_Venta_2 { get; set; }
    public double Margen_Utilidad_3 { get; set; }
    public double Precio_Venta_3 { get; set; }
    public string Clave_Unidad_Medida { get; set; } = string.Empty;
    public string Clave_Prod_Servicio { get; set; } = string.Empty;
}

public class GuardarProductoDto
{
    public int Id { get; set; }
    public string Clave { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Localizacion { get; set; } = string.Empty;
    public bool ArticuloConDecimal { get; set; }
    public string UmCompra { get; set; } = "PZA";
    public string UmVenta { get; set; } = "PZA";
    public string Contenido { get; set; } = "1";
    public int ClaveGrupo { get; set; } = 1;
    public int ClaveDepartamento { get; set; } = 1;
    public string InventarioMinimo { get; set; } = "0";
    public string InventarioMaximo { get; set; } = "100";
    public bool ProductoExento { get; set; }
    public double Ieps { get; set; }
    public double Iva { get; set; }
    public double PrecioCompra { get; set; }
    public double Margen1 { get; set; }
    public double PrecioVenta1 { get; set; }
    public double Margen2 { get; set; }
    public double PrecioVenta2 { get; set; }
    public double Margen3 { get; set; }
    public double PrecioVenta3 { get; set; }
    public string ClaveUnidadMedida { get; set; } = "H87";
    public string ClaveProdServicio { get; set; } = "01010101";
}

public class ClienteDto
{
    public int PK_Id_Cliente { get; set; }
    public string? vchConsecutivo_PV { get; set; }
    public string? vchContacto { get; set; }
    public string vchNombre { get; set; } = string.Empty;
    public string? vchCalle { get; set; }
    public string? vchNoExterior { get; set; }
    public string? vchColonia { get; set; }
    public string? vchCiudad { get; set; }
    public string? vchCodigoPostal { get; set; }
    public string? vchEmail { get; set; }
    public string? vchTelefono { get; set; }
    public string? vchRFC { get; set; }
    public string? vchLimiteCredito { get; set; }
    public int intDiasCredito { get; set; }
    public bool bBloqueoCliente { get; set; }
    public double flDescuento { get; set; }
    public string? vchComentarios { get; set; }
}
