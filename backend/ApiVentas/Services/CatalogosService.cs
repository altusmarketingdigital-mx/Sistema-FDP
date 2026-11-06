using System.Data;
using ApiVentas.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ApiVentas.Services;

public class CatalogosService
{
    private readonly string _inventarioConnStr;

    public CatalogosService(IConfiguration config)
    {
        _inventarioConnStr = config.GetConnectionString("Inventario")
            ?? throw new InvalidOperationException("Cadena 'Inventario' no configurada.");
    }

    #region PRODUCTOS
    public async Task<IEnumerable<ProductoDto>> ObtenerProductosAsync(string? filtro = null)
    {
        await using var conn = new SqlConnection(_inventarioConnStr);
        await conn.OpenAsync();

        var p = new DynamicParameters();
        p.Add("@PK_Id_Producto", 0);
        p.Add("@vchClaveProducto", string.Empty);
        p.Add("@vchNombre", filtro ?? string.Empty);
        p.Add("@vchLocalizacion", string.Empty);
        p.Add("@bitArticuloConDecimal", false);
        p.Add("@vch_UM_Compra", string.Empty);
        p.Add("@vch_UM_Venta", string.Empty);
        p.Add("@vchContenido", string.Empty);
        p.Add("@intClaveGrupo", 0);
        p.Add("@intClaveDepartamento", 0);
        p.Add("@vchInventarioMinimo", string.Empty);
        p.Add("@vchInventarioMaximo", string.Empty);
        p.Add("@bitProductoExento", false);
        p.Add("@fltIEPS", 0);
        p.Add("@fltIVA", 0);
        p.Add("@fltPrecioCompra", 0);
        p.Add("@ftl_MargenUtilidad_1", 0);
        p.Add("@flt_PrecioVenta_1", 0);
        p.Add("@ftl_MargenUtilidad_2", 0);
        p.Add("@flt_PrecioVenta_2", 0);
        p.Add("@ftl_MargenUtilidad_3", 0);
        p.Add("@flt_PrecioVenta_3", 0);
        p.Add("@vch_Clave_Unidad_Medida", string.Empty);
        p.Add("@vch_Clave_ProdServicio", string.Empty);

        // intAccion: 4 = Cargar Todos, 5 = Filtrar por Nombre
        p.Add("@intAccion", string.IsNullOrWhiteSpace(filtro) ? 4 : 5);

        return await conn.QueryAsync<ProductoDto>("sp_Tss_Producto", p, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> GuardarProductoAsync(GuardarProductoDto dto)
    {
        await using var conn = new SqlConnection(_inventarioConnStr);
        await conn.OpenAsync();

        var p = new DynamicParameters();
        p.Add("@PK_Id_Producto", dto.Id);
        p.Add("@vchClaveProducto", dto.Clave);
        p.Add("@vchNombre", dto.Nombre);
        p.Add("@vchLocalizacion", dto.Localizacion);
        p.Add("@bitArticuloConDecimal", dto.ArticuloConDecimal);
        p.Add("@vch_UM_Compra", dto.UmCompra);
        p.Add("@vch_UM_Venta", dto.UmVenta);
        p.Add("@vchContenido", dto.Contenido);
        p.Add("@intClaveGrupo", dto.ClaveGrupo);
        p.Add("@intClaveDepartamento", dto.ClaveDepartamento);
        p.Add("@vchInventarioMinimo", dto.InventarioMinimo);
        p.Add("@vchInventarioMaximo", dto.InventarioMaximo);
        p.Add("@bitProductoExento", dto.ProductoExento);
        p.Add("@fltIEPS", dto.Ieps);
        p.Add("@fltIVA", dto.Iva);
        p.Add("@fltPrecioCompra", dto.PrecioCompra);
        p.Add("@ftl_MargenUtilidad_1", dto.Margen1);
        p.Add("@flt_PrecioVenta_1", dto.PrecioVenta1);
        p.Add("@ftl_MargenUtilidad_2", dto.Margen2);
        p.Add("@flt_PrecioVenta_2", dto.PrecioVenta2);
        p.Add("@ftl_MargenUtilidad_3", dto.Margen3);
        p.Add("@flt_PrecioVenta_3", dto.PrecioVenta3);
        p.Add("@vch_Clave_Unidad_Medida", dto.ClaveUnidadMedida);
        p.Add("@vch_Clave_ProdServicio", dto.ClaveProdServicio);

        // intAccion: 1 = Nuevo, 2 = Actualizar
        p.Add("@intAccion", dto.Id > 0 ? 2 : 1);

        var respuesta = await conn.QueryFirstOrDefaultAsync<int>("sp_Tss_Producto", p, commandType: CommandType.StoredProcedure);
        return respuesta;
    }

    public async Task<int> EliminarProductoAsync(int id)
    {
        await using var conn = new SqlConnection(_inventarioConnStr);
        await conn.OpenAsync();

        var p = new DynamicParameters();
        p.Add("@PK_Id_Producto", id);
        p.Add("@vchClaveProducto", string.Empty);
        p.Add("@vchNombre", string.Empty);
        p.Add("@vchLocalizacion", string.Empty);
        p.Add("@bitArticuloConDecimal", false);
        p.Add("@vch_UM_Compra", string.Empty);
        p.Add("@vch_UM_Venta", string.Empty);
        p.Add("@vchContenido", string.Empty);
        p.Add("@intClaveGrupo", 0);
        p.Add("@intClaveDepartamento", 0);
        p.Add("@vchInventarioMinimo", string.Empty);
        p.Add("@vchInventarioMaximo", string.Empty);
        p.Add("@bitProductoExento", false);
        p.Add("@fltIEPS", 0);
        p.Add("@fltIVA", 0);
        p.Add("@fltPrecioCompra", 0);
        p.Add("@ftl_MargenUtilidad_1", 0);
        p.Add("@flt_PrecioVenta_1", 0);
        p.Add("@ftl_MargenUtilidad_2", 0);
        p.Add("@flt_PrecioVenta_2", 0);
        p.Add("@ftl_MargenUtilidad_3", 0);
        p.Add("@flt_PrecioVenta_3", 0);
        p.Add("@vch_Clave_Unidad_Medida", string.Empty);
        p.Add("@vch_Clave_ProdServicio", string.Empty);
        p.Add("@intAccion", 3); // 3 = Eliminar/Inactivar

        return await conn.QueryFirstOrDefaultAsync<int>("sp_Tss_Producto", p, commandType: CommandType.StoredProcedure);
    }
    #endregion

    #region CLIENTES
    public async Task<IEnumerable<ClienteDto>> ObtenerClientesAsync(string? filtro = null)
    {
        await using var conn = new SqlConnection(_inventarioConnStr);
        await conn.OpenAsync();

        var p = new DynamicParameters();
        p.Add("@PK_Id_Cliente", 0);
        p.Add("@vchConsecutivo_PV", string.Empty);
        p.Add("@vchContacto", string.Empty);
        p.Add("@vchNombre", filtro ?? string.Empty);
        p.Add("@vchCalle", string.Empty);
        p.Add("@vchNoExterior", string.Empty);
        p.Add("@vchNoInterior", string.Empty);
        p.Add("@vchColonia", string.Empty);
        p.Add("@vchCiudad", string.Empty);
        p.Add("@vchCodigoPostal", string.Empty);
        p.Add("@vchMunicipio", string.Empty);
        p.Add("@vchEstado", string.Empty);
        p.Add("@vchPais", string.Empty);
        p.Add("@vchEmail", string.Empty);
        p.Add("@vchTelefono", string.Empty);
        p.Add("@vchTelefono_2", string.Empty);
        p.Add("@vchRFC", string.Empty);
        p.Add("@vchLimiteCredito", string.Empty);
        p.Add("@intDiasCredito", 0);
        p.Add("@vchNoCuenta", string.Empty);
        p.Add("@bBloqueoCliente", false);
        p.Add("@vchMotivoBloqueo", string.Empty);
        p.Add("@bClienteExportacion", false);
        p.Add("@intCostoFactuacion", 0);
        p.Add("@flDescuento", 0);
        p.Add("@vchComentarios", string.Empty);
        p.Add("@intAccion", string.IsNullOrWhiteSpace(filtro) ? 4 : 5); // 4 = Cargar Todos, 5 = Filtrar

        return await conn.QueryAsync<ClienteDto>("sp_Tss_Cliente", p, commandType: CommandType.StoredProcedure);
    }
    #endregion
}
