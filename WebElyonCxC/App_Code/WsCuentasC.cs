using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.DirectoryServices;

/// <summary>
/// Summary description for WsCuentasC
/// </summary>
[WebService(Namespace = "AppElyonCXC")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WsCuentasC : System.Web.Services.WebService
{
    #region PROPIEDADES
    //static System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
    static RSACryptoServiceProvider sec = new RSACryptoServiceProvider();
    static byte[] bytString = null;
    static byte[] bytEncriptar = null;
    static byte[] bytDesEncriptar = null;
    static string key = "Cu3nt4sxC0br4r";
    SqlConnection cn;
    #endregion PROPIEDADES

    public WsCuentasC()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public DataSet dsObtener(string strXML, string strTipo)
    {
        switch (strTipo.ToUpper())
        {
            case "CARGAR BANCOS": return this.dsCargarBancos(strXML);
            case "CARGAR ESTADOS": return this.dsObtenerEstados(strXML);
            case "CARGAR CIUDADES": return this.dsObtenerCiudades(strXML);
            case "CARGAR VENDEDORES": return this.dsCargarvendedores(strXML);
            case "BUSCAR VENDEDOR": return this.dsBuscarvendedor(strXML);
            case "CARGAR CLIENTES": return this.dsCargarClientes(strXML);
            case "BUSCAR CLIENTES": return this.dsBuscarClientes(strXML);
            case "BUSCA LOS CLIENTE": return this.dsBuscarCliente(strXML);
            case "CARGAR EMPRESAS": return this.dsCargarEmpresas(strXML);
            case "BUSCA EMPRESAS POR CLAVE": return this.dsBuscarEmpresaCodigo(strXML);
            case "BUSCA EMPRESAS": return this.dsBuscarEmpresa(strXML);
            case "BUSCA VENDEDOR CLIENTES EMPRESAS": return this.dsBuscarVendedorClienteEmpresa(strXML);
            case "CARGAR VENDEDOR ACTIVOS": return this.dsCargarvendedoresActivos(strXML);
            case "CARGAR GRID CLIENTES EMPRESA": return this.dsBuscarClaveClienteEmpresa(strXML);
            case "CARGAR REPORTE EMPRESAS": return this.CargarReporteEmpresas(strXML);
            case "CARGAR REPORTE CLIENTES": return this.CargarReporteClientes(strXML);
            case "CARGAR REPORTE VENDEDORES": return this.CargarReporteVendedor(strXML);
            case "CARGAR REPORTE BANCOS": return this.CargarReporteBancos(strXML);
            case "OBTENER VALIDACION CLAVES BANCO": return this.dsObtenerValiacionClaveBanco(strXML);
            case "MANTENIMIENTO CATALOGO PROVEEDORES": return this.dsCatalogoProveedores(strXML);
            case "MANTENIMIENTO CATALOGO GRUPOS": return this.dsCatalogoGrupos(strXML);
            case "MANTENIMIENTO CATALOGO DEPARTAMENTOS": return this.dsCatalogoDepartamentos(strXML);
            case "MANTENIMIENTO CATALOGO PRODUCTO": return this.dsCatalogoProducto(strXML);
            case "CARGAR COMBO": return this.dsCargarCombo(strXML);
            case "MANTENIMIENTO CATALOGO CLIENTES": return this.dsCatalogoClientes(strXML);
            case "REGISTRO INVENTARIO INICIAL": return this.dsRegistroInventarioInicial(strXML);
            case "GENERAR PEDIDO": return this.dsGenerarPedido(strXML);
            case "OBTENER CLIENTES POR ID": return this.dsClientesID(strXML);
            case "OBTENER CLIENTES": return this.dsObtenerClientes(strXML);
            case "REGISTRO NOTA REMISION": return this.dsRegistroNotaRemision(strXML);
            case "OBTENER USUARIO": return this.dsObtenerUsuario(strXML);
            case "OBTENER NOTAS REMISION": return this.dsObtenerNotasRemision(strXML);
            case "REGISTRO PAGO CLIENTE": return this.dsRegistroPagoCliente(strXML);
            case "OBTENER DOCUMENTO NOTA REMISION": return this.dsObtenerDocumentoNotaRemision(strXML);
            case "MANTENIMIENTO FOLIO PEDIDOS": return this.dsMantenimientoFolioPedidos(strXML);
            case "OBTENER DEVOLUCIONES": return this.dsObtenerDevoluciones(strXML);
            case "OBTENER PEDIDOS": return this.dsPedidosID(strXML);
            case "OBTENER NOTAS DE REMISION ID": return this.dsNotasRemisionID(strXML);
            case "OBTENER PAGOS CLIENTE": return this.dsPagosID(strXML);
            case "OBTENER NOTAS CANCELADAS": return this.dsNotasCanceladasID(strXML);
            case "OBTENER REPORTE DE MOVIMIENTOS": return this.dsReporteMovimientos(strXML);
            case "OBTENER BOLETA PEDIDO": return this.dsObtenerBoletaPedido(strXML);
            case "OBTENER BOLETA PAGO": return this.dsObtenerBoletaPago(strXML);
            case "REGISTRO DATOS DEL CONTRIBUYENTE": return this.dsDatosDelContribuyente(strXML);
            case "OBTENER CONTRIBUYENTE": return this.dsObtenerContribuyente(strXML);
            case "OBTENER ENCABEZADO TICKET PEDIDO": return this.dsEncabezadoTicket_Pedido(strXML);
            case "OBTENER BOLETA NOTA REMISION": return this.dsObtenerBoleta_NotaRemision(strXML);
            case "MANTENIMIENTO OBTENER DATOS CLIENTE": return this.dsObtenerDatosCliente(strXML);
            case "MANTENIMIENTO DATOS CONTRIBUYENTES": return this.dsMantenimientoDatosContribuyente(strXML);
            case "MANTENIMIENTO CANCELAR NOTA REMISION": return this.dsCancelarNotaRemision(strXML);
            case "BITACORA REGISTRO CLIENTE MASIVO": return this.dsBitacoraRegistroCliente(strXML);
            case "BUSQUEDA DE PEDIDO": return this.dsBusquedaPedido(strXML);
            case "OBTENER DATOS DEL PEDIDO": return this.dsObtenerDatosPedido(strXML);
            case "CARGAR COMBO MEDIDAS Y PESO": return this.dsCargarCombo_Medidas_Peso(strXML);
            default:
                return null;
        }
    }

    #region DATASET

    private DataSet dsCargarCombo_Medidas_Peso(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsCargarCombo_Medidas_Peso();
    }

    private DataSet dsObtenerDatosPedido(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsObtenerDatosPedido();
    }

    private DataSet dsBusquedaPedido(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsBusquedaPedido();
    }

    private DataSet dsBitacoraRegistroCliente(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsBitacoraRegistroCliente();
    }

    private DataSet dsCancelarNotaRemision(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsCancelarNotaRemision();
    }

    private DataSet dsMantenimientoDatosContribuyente(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsMantenimientoDatosContribuyente();
    }

    private DataSet dsObtenerDatosCliente(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsObtenerDatosCliente();
    }

    private DataSet dsObtenerBoleta_NotaRemision(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsObtenerBoleta_NotaRemision();
    }

    private DataSet dsEncabezadoTicket_Pedido(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsEncabezadoTicket_Pedido();
    }

    private DataSet dsObtenerContribuyente(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsObtenerContribuyente();
    }

    private DataSet dsDatosDelContribuyente(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsDatosDelContribuyente();
    }

    private DataSet dsObtenerBoletaPago(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsObtenerBoletaPago();
    }
    private DataSet dsObtenerBoletaPedido(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsObtenerBoletaPedido();
    }
    private DataSet dsReporteMovimientos(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsReporteMovimientos();
    }
    private DataSet dsNotasCanceladasID(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsNotasCanceladasID();
    }
    private DataSet dsPagosID(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsPagosID();
    }
    private DataSet dsNotasRemisionID(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsNotasRemisionID();
    }
    private DataSet dsPedidosID(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsPedidosID();
    }
    private DataSet dsObtenerDevoluciones(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsObtenerDevoluciones();
    }
    private DataSet dsMantenimientoFolioPedidos(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsMantenimientoFolioPedidos();
    }

    private DataSet dsObtenerDocumentoNotaRemision(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsObtenerDocumentoNotaRemision();
    }

    private DataSet dsRegistroPagoCliente(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsRegistroPagoCliente();
    }

    private DataSet dsObtenerNotasRemision(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsObtenerNotasRemision();
    }

    private DataSet dsObtenerUsuario(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsObtenerUsuario();
    }

    private DataSet dsRegistroNotaRemision(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsRegistroNotaRemision();
    }

    private DataSet dsGenerarPedido(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsGenerarPedido();
    }

    private DataSet dsObtenerClientes(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsObtenerClientes();
    }
    private DataSet dsClientesID(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsClientesID();
    }

    private DataSet dsRegistroInventarioInicial(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsRegistroInventarioInicial();
    }

    private DataSet dsCatalogoClientes(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsCatalogoClientes();
    }

    private DataSet dsCargarCombo(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsCargarCombo();
    }

    private DataSet dsCatalogoProducto(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsCatalogoProducto();
    }

    private DataSet dsCatalogoDepartamentos(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsCatalogoDepartamentos();
    }

    private DataSet dsCatalogoGrupos(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsCatalogoGrupos();
    }

    private DataSet dsCatalogoProveedores(string strXML)
    {
        ElyonManagerCxC.mgrInventario _mgrInventario = new ElyonManagerCxC.mgrInventario(strXML);
        return _mgrInventario.dsCatalogoProveedores();
    }

    private DataSet dsObtenerValiacionClaveBanco(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentaC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentaC.dsObtenerValiacionClaveBanco();
    }
    private DataSet CargarReporteEmpresas(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentaC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentaC.CargarReporteEmpresas();
    }
    private DataSet CargarReporteClientes(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentaC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentaC.CargarReporteClientes();
    }
    private DataSet CargarReporteVendedor(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentaC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentaC.CargarReporteVendedor();
    }
    private DataSet CargarReporteBancos(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentaC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentaC.CargarReporteBancos();
    }
    private DataSet dsBuscarClaveClienteEmpresa(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentaC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentaC.dsBuscarClaveClienteEmpresa();
    }
    private DataSet dsCargarvendedoresActivos(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentaC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentaC.dsCargarvendedoresActivos();
    }
    private DataSet dsBuscarVendedorClienteEmpresa(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentaC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentaC.dsBuscarVendedorClienteEmpresa();
    }
    private DataSet dsBuscarEmpresa(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentaC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentaC.dsBuscarEmpresa();
    }
    private DataSet dsBuscarEmpresaCodigo(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentaC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentaC.dsBuscarEmpresaCodigo();
    }
    private DataSet dsCargarEmpresas(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentaC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentaC.dsCargarEmpresas();
    }
    private DataSet dsBuscarCliente(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentaC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentaC.dsBuscarCliente();
    }
    private DataSet dsCargarClientes(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentaC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentaC.dsCargarClientes();
    }
    private DataSet dsBuscarClientes(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentaC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentaC.dsBuscarClientes();
    }
    private DataSet dsCargarvendedores(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentaC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentaC.dsCargarvendedores();
    }
    private DataSet dsBuscarvendedor(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentaC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentaC.dsBuscarvendedor();
    }
    private DataSet dsObtenerEstados(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentaC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentaC.dsObtenerEstados();
    }
    private DataSet dsObtenerCiudades(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentaC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentaC.dsObtenerCiudades();
    }
    private DataSet dsCargarBancos(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentaC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentaC.dsCargarBancos();
    }    
    #endregion DATASET


    [WebMethod]
    public bool bObtener1(string strXML, string strTipo)
    {
        switch (strTipo.ToUpper())
        {
            #region USUARIO                       
            case "ALMACENA BANCOS": return this.bGuardarBancos(strXML);
            case "ELIMINA BANCOS": return this.bEliminaBancos(strXML);
            case "ALMACENA VENDEDORES": return this.bGuardarVendedor(strXML);
            case "ELIMINA VENDEDORES": return this.bEliminaVendedor(strXML);
            case "ALMACENA CLIENTES": return this.bGuardarCliente(strXML);
            case "ELIMINA CLIENTES": return this.bEliminaCliente(strXML);
            case "ALMACENA EMPRESAS": return this.bGuardarEmpresa(strXML);
            case "ELIMINA EMPRESAS": return this.bEliminaEmpresa(strXML);
            case "ALMACENA VENDEDOR EMPRESAS": return this.bGuardarVendedorEmpresa(strXML);
            case "ALMACENA VENDEDOR CLIENTES": return this.bGuardarVendedorClientes(strXML);
            case "ELIMINA VENDEDOR EMPRESAS": return this.bEliminaVendedorEmpresa(strXML);
            case "ELIMINA VENDEDOR CLIENTES": return this.bEliminaVendedorClientes(strXML);
            #endregion USUARIO 
            default:
                return false;
        }
    }

    #region BOOL INSERT
    private bool bEliminaVendedorClientes(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentasC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentasC.bEliminaVendedorClientes();
    }
    private bool bEliminaVendedorEmpresa(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentasC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentasC.bEliminaVendedorEmpresa();
    }
    private bool bGuardarVendedorClientes(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentasC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentasC.bGuardarVendedorClientes();
    }
    private bool bGuardarVendedorEmpresa(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentasC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentasC.bGuardarVendedorEmpresa();
    }
    private bool bGuardarCliente(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentasC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentasC.bGuardarCliente();
    }
    private bool bEliminaCliente(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentasC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentasC.bEliminaCliente();
    }
    private bool bGuardarVendedor(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentasC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentasC.bGuardarVendedor();
    }
    private bool bEliminaVendedor(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentasC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentasC.bEliminaVendedor();
    }
    private bool bGuardarBancos(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentasC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentasC.bGuardarBancos();
    }
    private bool bEliminaBancos(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentasC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentasC.bEliminaBancos();
    }
    private bool bGuardarEmpresa(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentasC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentasC.bGuardarEmpresa();
    }
    private bool bEliminaEmpresa(string strXML)
    {
        ElyonManagerCxC.mgrCuentasC _mgrCuentasC = new ElyonManagerCxC.mgrCuentasC(strXML);
        return _mgrCuentasC.bEliminaEmpresa();
    }
    #endregion BOOL INSERT
}
