using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Security.Cryptography;
using System.DirectoryServices;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Mail;

namespace ElyonModelCxC
{
    [System.Xml.Serialization.XmlRootAttribute("mInventario", Namespace = "ELYON", IsNullable = false)]

    public class mInventario
    {
        #region CONFIGURACIÓN 

        Wscxc.WsCxC _wsSegElyon = new Wscxc.WsCxC();
        //wsInventario.wsInventario _wsCuentasC = new wsInventario.wsInventario();

        string _strUrlCuentas;
        string _strConexion;

        [System.Xml.Serialization.XmlElementAttribute]
        public string strUrlCuentas
        {
            get { return _strUrlCuentas; }
            set { _strUrlCuentas = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strConexion
        {
            get { return _strConexion; }
            set { _strConexion = value; }
        }

        public mInventario()
        {

        }

        public mInventario(string strConexion, string strUrlCuentas)
        {
            this._strConexion = strConexion;
            this._strUrlCuentas = strUrlCuentas;
        }

        #endregion

        #region XML

        public virtual string XML
        {
            get
            {
                return Serializer.ToXml(this, this.GetType());
            }
        }

        public static mInventario FromXml(string XmlString)
        {
            return ((mInventario)Serializer.FromXml(XmlString, typeof(mInventario)));
        }

        #endregion XML

        #region Variables Serializacion
        string _strNombre;

        [System.Xml.Serialization.XmlElementAttribute]
        public string strNombre
        {
            get { return _strNombre; }
            set { _strNombre = value; }
        }
        #endregion Variables Serializacion

        #region CATALOGO PROVEEDORES

        //VARIABLES

        int _Id_Proveedor;
        string _vchNombre_Proveedor;
	    string _vchCalle_Proveedor;
        string _vchNoExt_Proveedor;
	    string _vchNoInt_Proveedor;
	    string _vchColonia_Proveedor;
	    string _vchCp_Proveedor;
	    string _vchCiudad_Proveedor;
	    string _vchEstado_Proveedor;
	    string _vchPais_Proveedor;
	    string _vchEmail_Proveedor;
	    string _vchTelefono_Proveedor;
	    string _vchCelular_Proveedor;
	    string _vchRfc_Proveedor;
	    string _vchNoDeCuenta_Proveeddor;
	    int _intAccionProveedor;

        //SERIALIZADO

        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_Proveedor
        {
            get { return _Id_Proveedor; }
            set { _Id_Proveedor = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchNombre_Proveedor
        {
            get { return _vchNombre_Proveedor; }
            set { _vchNombre_Proveedor = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchCalle_Proveedor
        {
            get { return _vchCalle_Proveedor; }
            set { _vchCalle_Proveedor = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchNoExt_Proveedor
        {
            get { return _vchNoExt_Proveedor; }
            set { _vchNoExt_Proveedor = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchNoInt_Proveedor
        {
            get { return _vchNoInt_Proveedor; }
            set { _vchNoInt_Proveedor = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchColonia_Proveedor
        {
            get { return _vchColonia_Proveedor; }
            set { _vchColonia_Proveedor = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchCp_Proveedor
        {
            get { return _vchCp_Proveedor; }
            set { _vchCp_Proveedor = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchCiudad_Proveedor
        {
            get { return _vchCiudad_Proveedor; }
            set { _vchCiudad_Proveedor = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchEstado_Proveedor
        {
            get { return _vchEstado_Proveedor; }
            set { _vchEstado_Proveedor = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchPais_Proveedor
        {
            get { return _vchPais_Proveedor; }
            set { _vchPais_Proveedor = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchEmail_Proveedor
        {
            get { return _vchEmail_Proveedor; }
            set { _vchEmail_Proveedor = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchTelefono_Proveedor
        {
            get { return _vchTelefono_Proveedor; }
            set { _vchTelefono_Proveedor = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchCelular_Proveedor
        {
            get { return _vchCelular_Proveedor; }
            set { _vchCelular_Proveedor = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchRfc_Proveedor
        {
            get { return _vchRfc_Proveedor; }
            set { _vchRfc_Proveedor = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchNoDeCuenta_Proveeddor
        {
            get { return _vchNoDeCuenta_Proveeddor; }
            set { _vchNoDeCuenta_Proveeddor = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intAccionProveedor
        {
            get { return _intAccionProveedor; }
            set { _intAccionProveedor = value; }
        }

        //DATASET

        public DataSet dsCatalogoProveedores()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "MANTENIMIENTO CATALOGO PROVEEDORES");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region CATALOGO DE GRUPOS

        //VARIABLES
        int _Id_Grupo;
        string _vchNombre_Grupo;
        int _intAccionGrupo;

        //SERIALIZADO
        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_Grupo
        {
            get { return _Id_Grupo; }
            set { _Id_Grupo = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchNombre_Grupo
        {
            get { return _vchNombre_Grupo; }
            set { _vchNombre_Grupo = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intAccionGrupo
        {
            get { return _intAccionGrupo; }
            set { _intAccionGrupo = value; }
        }

        //DATASET
        public DataSet dsCatalogoGrupos()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "MANTENIMIENTO CATALOGO GRUPOS");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region CATALOGO DE DEPARTAMENTO

        //VARIABLES
        int _Id_Departamento;
        string _vchNombre_Departamento;
        int _intAccionDepartamento;

        //SERIALIZADO
        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_Departamento
        {
            get { return _Id_Departamento; }
            set { _Id_Departamento = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchNombre_Departamento
        {
            get { return _vchNombre_Departamento; }
            set { _vchNombre_Departamento = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intAccionDepartamento
        {
            get { return _intAccionDepartamento; }
            set { _intAccionDepartamento = value; }
        }

        //DATASET
        public DataSet dsCatalogoDepartamentos()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "MANTENIMIENTO CATALOGO DEPARTAMENTOS");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region CATALOGO DE PRODUCTO

        //VARIABLES
        int _Id_Producto;
        string _vchClaveProducto; 
        string _vchNombre;
        string _vchLocalizacion;
        bool _bitArticuloConDecimal;
        string _UM_Compra;
        string _UM_Venta;
        string _vchContenido;
        int _intClaveGrupo;
        int _intClaveDepartamento;
	    string _vchInventarioMinimo;
        string _vchInventarioMaximo;
        bool _bitProductoExento;
        float _fltIEPS;
        float _fltIVA;
        float _fltPrecioCompra;
        float _ftl_MargenUtilidad_1;
        float _flt_PrecioVenta_1;
        float _ftl_MargenUtilidad_2;
        float _flt_PrecioVenta_2;
        float _ftl_MargenUtilidad_3;
        float _flt_PrecioVenta_3;
        string _Clave_Unidad_Medida;
        string _Clave_ProdServicio;
        int _intAccionProducto;

        //SERIALIZADO
        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_Producto
        {
            get { return _Id_Producto; }
            set { _Id_Producto = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchClaveProducto
        {
            get { return _vchClaveProducto; }
            set { _vchClaveProducto = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchNombre
        {
            get { return _vchNombre; }
            set { _vchNombre = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchLocalizacion
        {
            get { return _vchLocalizacion; }
            set { _vchLocalizacion = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public bool bitArticuloConDecimal
        {
            get { return _bitArticuloConDecimal; }
            set { _bitArticuloConDecimal = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string UM_Compra
        {
            get { return _UM_Compra; }
            set { _UM_Compra = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string UM_Venta
        {
            get { return _UM_Venta; }
            set { _UM_Venta = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchContenido
        {
            get { return _vchContenido; }
            set { _vchContenido = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intClaveGrupo
        {
            get { return _intClaveGrupo; }
            set { _intClaveGrupo = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intClaveDepartamento
        {
            get { return _intClaveDepartamento; }
            set { _intClaveDepartamento = value; }
        }
        
        [System.Xml.Serialization.XmlElementAttribute]
        public string vchInventarioMinimo
        {
            get { return _vchInventarioMinimo; }
            set { _vchInventarioMinimo = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchInventarioMaximo
        {
            get { return _vchInventarioMaximo; }
            set { _vchInventarioMaximo = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public bool bitProductoExento
        {
            get { return _bitProductoExento; }
            set { _bitProductoExento = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public float fltIEPS
        {
            get { return _fltIEPS; }
            set { _fltIEPS = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public float fltIVA
        {
            get { return _fltIVA; }
            set { _fltIVA = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public float fltPrecioCompra
        {
            get { return _fltPrecioCompra; }
            set { _fltPrecioCompra = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public float ftl_MargenUtilidad_1
        {
            get { return _ftl_MargenUtilidad_1; }
            set { _ftl_MargenUtilidad_1 = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public float flt_PrecioVenta_1
        {
            get { return _flt_PrecioVenta_1; }
            set { _flt_PrecioVenta_1 = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public float ftl_MargenUtilidad_2
        {
            get { return _ftl_MargenUtilidad_2; }
            set { _ftl_MargenUtilidad_2 = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public float flt_PrecioVenta_2
        {
            get { return _flt_PrecioVenta_2; }
            set { _flt_PrecioVenta_2 = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public float ftl_MargenUtilidad_3
        {
            get { return _ftl_MargenUtilidad_3; }
            set { _ftl_MargenUtilidad_3 = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public float flt_PrecioVenta_3
        {
            get { return _flt_PrecioVenta_3; }
            set { _flt_PrecioVenta_3 = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string Clave_Unidad_Medida
        {
            get { return _Clave_Unidad_Medida; }
            set { _Clave_Unidad_Medida = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string Clave_ProdServicio
        {
            get { return _Clave_ProdServicio; }
            set { _Clave_ProdServicio = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intAccionProducto
        {
            get { return _intAccionProducto; }
            set { _intAccionProducto = value; }
        }

        //DATASET
        public DataSet dsCatalogoProducto()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "MANTENIMIENTO CATALOGO PRODUCTO");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region CATALOGO DE CLIENTE

        #region VARIABLE
        int _Id_Cliente;
        int _Id_Pedidos;
        string _vchConsecutivo_PV;
        string _vchContacto;
        string _vchNombreCliente;
        string _vchCalle;
        string _vchNoExterior;
        string _vchNoInterior;
        string _vchColonia;
        string _vchCiudad;
        string _vchCodigoPostal;
        string _vchMunicipio;
        string _vchEstado;
        string _vchPais;
        string _vchEmail;
        string _vchTelefono;
        string _vchTelefono_2;
        string _vchRFC;
        string _vchLimiteCredito;
        int _intDiasCredito;
        string _vchNoCuenta;
        bool _bBloqueoCliente;
        string _vchMotivoBloqueo;
        bool _bClienteExportacion;
        int _intCostoFactuacion;
        float _flDescuento;
        string _vchComentarios;
        int _intAccionCliente;
        int _Id_NotaRemision;
        int _Id_Pagos;
        int _Accion;
        int _Id_NotaCanceladas;
        string _strDescripcion;
        int _intTipoMov;

        string _strConsecutivoPV;
        #endregion VARIABLE

        #region SERIALIZADO

        [System.Xml.Serialization.XmlElementAttribute]
        public string strConsecutivoPV
        {
            get { return _strConsecutivoPV; }
            set { _strConsecutivoPV = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchTelefono_2
        {
            get { return _vchTelefono_2; }
            set { _vchTelefono_2 = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchConsecutivo_PV
        {
            get { return _vchConsecutivo_PV; }
            set { _vchConsecutivo_PV = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchContacto
        {
            get { return _vchContacto; }
            set { _vchContacto = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strDescripcion
        {
            get { return _strDescripcion; }
            set { _strDescripcion = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intTipoMov
        {
            get { return _intTipoMov; }
            set { _intTipoMov = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_NotaCanceladas
        {
            get { return _Id_NotaCanceladas; }
            set { _Id_NotaCanceladas = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int Accion
        {
            get { return _Accion; }
            set { _Accion = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_NotaRemision
        {
            get { return _Id_NotaRemision; }
            set { _Id_NotaRemision = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_Pagos
        {
            get { return _Id_Pagos; }
            set { _Id_Pagos = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_Pedidos
        {
            get { return _Id_Pedidos; }
            set { _Id_Pedidos = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchNoExterior
        {
            get { return _vchNoExterior; }
            set { _vchNoExterior = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchNoInterior
        {
            get { return _vchNoInterior; }
            set { _vchNoInterior = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchColonia
        {
            get { return _vchColonia; }
            set { _vchColonia = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchCiudad
        {
            get { return _vchCiudad; }
            set { _vchCiudad = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchCodigoPostal
        {
            get { return _vchCodigoPostal; }
            set { _vchCodigoPostal = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchMunicipio
        {
            get { return _vchMunicipio; }
            set { _vchMunicipio = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchEstado
        {
            get { return _vchEstado; }
            set { _vchEstado = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchPais
        {
            get { return _vchPais; }
            set { _vchPais = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchEmail
        {
            get { return _vchEmail; }
            set { _vchEmail = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchTelefono
        {
            get { return _vchTelefono; }
            set { _vchTelefono = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchRFC
        {
            get { return _vchRFC; }
            set { _vchRFC = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchLimiteCredito
        {
            get { return _vchLimiteCredito; }
            set { _vchLimiteCredito = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intDiasCredito
        {
            get { return _intDiasCredito; }
            set { _intDiasCredito = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchNoCuenta
        {
            get { return _vchNoCuenta; }
            set { _vchNoCuenta = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public bool bBloqueoCliente
        {
            get { return _bBloqueoCliente; }
            set { _bBloqueoCliente = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchMotivoBloqueo
        {
            get { return _vchMotivoBloqueo; }
            set { _vchMotivoBloqueo = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public bool bClienteExportacion
        {
            get { return _bClienteExportacion; }
            set { _bClienteExportacion = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intCostoFactuacion
        {
            get { return _intCostoFactuacion; }
            set { _intCostoFactuacion = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public float flDescuento
        {
            get { return _flDescuento; }
            set { _flDescuento = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchComentarios
        {
            get { return _vchComentarios; }
            set { _vchComentarios = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intAccionCliente
        {
            get { return _intAccionCliente; }
            set { _intAccionCliente = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchCalle
        {
            get { return _vchCalle; }
            set { _vchCalle = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_Cliente
        {
            get { return _Id_Cliente; }
            set { _Id_Cliente = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchNombreCliente
        {
            get { return _vchNombreCliente; }
            set { _vchNombreCliente = value; }
        }
        #endregion SERIALIZADO

        //DATASET
        public DataSet dsBitacoraRegistroCliente()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "BITACORA REGISTRO CLIENTE MASIVO");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet dsCatalogoClientes()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "MANTENIMIENTO CATALOGO CLIENTES");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet dsObtenerDatosCliente()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "MANTENIMIENTO OBTENER DATOS CLIENTE");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion CATALOGO DE CLIENTE

        #region REGISTRO INVENTARIO INICIAL PRODUCTO

        //VARIABLES
        int _Id_Inventario;
        int _Id_ClaveProducto;
        int _intUnidadesCompra_Fisco;
        int _intUnidadesVenta_Fisco;
        int _intUnidadesVenta_InicialCalculado;
        float _flt_Importa;
        int _intAccion_Inventario_Inicial;

        //SERIALIZADO
        [System.Xml.Serialization.XmlElementAttribute]
        public int intAccion_Inventario_Inicial
        {
            get { return _intAccion_Inventario_Inicial; }
            set { _intAccion_Inventario_Inicial = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public float flt_Importa
        {
            get { return _flt_Importa; }
            set { _flt_Importa = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intUnidadesVenta_InicialCalculado
        {
            get { return _intUnidadesVenta_InicialCalculado; }
            set { _intUnidadesVenta_InicialCalculado = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intUnidadesVenta_Fisco
        {
            get { return _intUnidadesVenta_Fisco; }
            set { _intUnidadesVenta_Fisco = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_Inventario
        {
            get { return _Id_Inventario; }
            set { _Id_Inventario = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_ClaveProducto
        {
            get { return _Id_ClaveProducto; }
            set { _Id_ClaveProducto = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intUnidadesCompra_Fisco
        {
            get { return _intUnidadesCompra_Fisco; }
            set { _intUnidadesCompra_Fisco = value; }
        }

        //DATASET
        public DataSet dsRegistroInventarioInicial()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "REGISTRO INVENTARIO INICIAL");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region CARGAR COMBOS

        //VARIABLE
        int _intValor1; 

        //SERIALIZADO
        [System.Xml.Serialization.XmlElementAttribute]
        public int intValor1
        {
            get { return _intValor1; }
            set { _intValor1 = value; }
        }

        //DATASET
        public DataSet dsCargarCombo()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "CARGAR COMBO");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet dsCargaUnidadMedida()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "CARGAR UNIDAD MEDIDA");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region DATASET

        public DataSet dsEncabezadoTicket_Pedido()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "OBTENER ENCABEZADO TICKET PEDIDO");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet dsObtenerBoletaPago()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "OBTENER BOLETA PAGO");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet dsObtenerBoletaPedido()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "OBTENER BOLETA PEDIDO");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsReporteMovimientos()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "OBTENER REPORTE DE MOVIMIENTOS");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsNotasCanceladasID()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "OBTENER NOTAS CANCELADAS");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsPagosID()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "OBTENER PAGOS CLIENTE");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsNotasRemisionID()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "OBTENER NOTAS DE REMISION ID");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsPedidosID()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "OBTENER PEDIDOS");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsObtenerDevoluciones()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "OBTENER DEVOLUCIONES");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsObtenerNotasRemision()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "OBTENER NOTAS REMISION");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsObtenerClientes()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "OBTENER CLIENTES");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsClientesID()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "OBTENER CLIENTES POR ID");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet dsObtenerBoleta_NotaRemision()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "OBTENER BOLETA NOTA REMISION");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region GENERAR PEDIDO

        //VARIABLE
        int _intAccionGenerarPedido;

        int _Id_Genera_Pedido;
        string _vchFolio;
        //int _Id_Usuario;
        DateTime _dtp_FechaVenta;
        //int _Id_Cliente;
        //int _intDiasCredito;
        DateTime _dtp_FechaVencimientoCredito;
        int _Metodo_Pago;
        int _Forma_Pago;
        float _TotalVenta;
        string _vchComentario;

        int _Id_Generar_Pedido_Detalle;
        int _Id_Generar_Pedido;
        string _Id_Clave_Producto;
        float _Cantidad;
        float _PrecioVenta;
        decimal _dcDescuento;
        float _Importe;

        //SERIALIZADO
        [System.Xml.Serialization.XmlElementAttribute]
        public int intAccionGenerarPedido
        {
            get { return _intAccionGenerarPedido; }
            set { _intAccionGenerarPedido = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_Genera_Pedido
        {
            get { return _Id_Genera_Pedido; }
            set { _Id_Genera_Pedido = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchFolio
        {
            get { return _vchFolio; }
            set { _vchFolio = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public DateTime dtp_FechaVenta
        {
            get { return _dtp_FechaVenta; }
            set { _dtp_FechaVenta = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public DateTime dtp_FechaVencimientoCredito
        {
            get { return _dtp_FechaVencimientoCredito; }
            set { _dtp_FechaVencimientoCredito = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int Metodo_Pago
        {
            get { return _Metodo_Pago; }
            set { _Metodo_Pago = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int Forma_Pago
        {
            get { return _Forma_Pago; }
            set { _Forma_Pago = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public float TotalVenta
        {
            get { return _TotalVenta; }
            set { _TotalVenta = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchComentario
        {
            get { return _vchComentario; }
            set { _vchComentario = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_Generar_Pedido_Detalle
        {
            get { return _Id_Generar_Pedido_Detalle; }
            set { _Id_Generar_Pedido_Detalle = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_Generar_Pedido
        {
            get { return _Id_Generar_Pedido; }
            set { _Id_Generar_Pedido = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string Id_Clave_Producto
        {
            get { return _Id_Clave_Producto; }
            set { _Id_Clave_Producto = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public float Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public float PrecioVenta
        {
            get { return _PrecioVenta; }
            set { _PrecioVenta = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public decimal dcDescuento
        {
            get { return _dcDescuento; }
            set { _dcDescuento = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public float Importe
        {
            get { return _Importe; }
            set { _Importe = value; }
        }

        //DATASET
        public DataSet dsGenerarPedido()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "GENERAR PEDIDO");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region OBTENER INFORMACIÓN USUARIO

        //VARIABLE
        int _IdUsuario;

        //SERIALIZADO
        [System.Xml.Serialization.XmlElementAttribute]
        public int IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }

        //DATASET
        public DataSet dsObtenerUsuario()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "OBTENER USUARIO");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region OBTENER FOLIO

        //VARIALBES
        int _Id_Folio_Pedido;
        string _vchClaveFolio;
        int _Id_Usuario;
        string _IP_Equipo;
        int _intAccionFolio;

        //SERIALIZADO
        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_Folio_Pedido
        {
            get { return _Id_Folio_Pedido; }
            set { _Id_Folio_Pedido = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchClaveFolio
        {
            get { return _vchClaveFolio; }
            set { _vchClaveFolio = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_Usuario
        {
            get { return _Id_Usuario; }
            set { _Id_Usuario = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string IP_Equipo
        {
            get { return _IP_Equipo; }
            set { _IP_Equipo = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intAccionFolio
        {
            get { return _intAccionFolio; }
            set { _intAccionFolio = value; }
        }

        //DATASET
        public DataSet dsMantenimientoFolioPedidos()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "MANTENIMIENTO FOLIO PEDIDOS");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region GENERA NOTA DE REMISIÓN
        
        //VARIABLES
        int _Id_Nota_Remision;
        int _Id_No_Pedido;
        DateTime _Fecha_Nota_Remision;
        int _Id_Cajero;
        string _vchEstatus_Nota_Remision;
	    int _intAccionNotaRemision;

        //SERIALIZADO
        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_Nota_Remision
        {
            get { return _Id_Nota_Remision; }
            set { _Id_Nota_Remision = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_No_Pedido
        {
            get { return _Id_No_Pedido; }
            set { _Id_No_Pedido = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public DateTime Fecha_Nota_Remision
        {
            get { return _Fecha_Nota_Remision; }
            set { _Fecha_Nota_Remision = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_Cajero
        {
            get { return _Id_Cajero; }
            set { _Id_Cajero = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchEstatus_Nota_Remision
        {
            get { return _vchEstatus_Nota_Remision; }
            set { _vchEstatus_Nota_Remision = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intAccionNotaRemision
        {
            get { return _intAccionNotaRemision; }
            set { _intAccionNotaRemision = value; }
        }

        //DATASET
        public DataSet dsRegistroNotaRemision()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "REGISTRO NOTA REMISION");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet dsObtenerDocumentoNotaRemision()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "OBTENER DOCUMENTO NOTA REMISION");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region REGISTRO PAGO CLIENTE

        //VARIABLES
        int _Id_Registro_Pago_Cliente;
        //int _Id_Cliente;
        //int _Id_Nota_Remision;
        float _Saldo_Anterior;
        float _Interes;
        float _Saldo_Favor;
        float _Pago_Aplicar;
        float _Saldo_Nuevo;
        DateTime _Fecha_Timbrado;

        int _Id_Registro_Pago_Cliente_Detalle;
        //int _Id_Registro_Pago_Cliente;
        int _Id_Forma_Pago;
        float _Importe_Pago;
        float _Total_Pago;
        float _Cambio_Pago;

        int _intAccionRegistroPagoCliente;

        //SERIALIZADO

        [System.Xml.Serialization.XmlElementAttribute]
        public int intAccionRegistroPagoCliente
        {
            get { return _intAccionRegistroPagoCliente; }
            set { _intAccionRegistroPagoCliente = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public float Cambio_Pago
        {
            get { return _Cambio_Pago; }
            set { _Cambio_Pago = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public float Total_Pago
        {
            get { return _Total_Pago; }
            set { _Total_Pago = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public float Importe_Pago
        {
            get { return _Importe_Pago; }
            set { _Importe_Pago = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_Forma_Pago
        {
            get { return _Id_Forma_Pago; }
            set { _Id_Forma_Pago = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_Registro_Pago_Cliente_Detalle
        {
            get { return _Id_Registro_Pago_Cliente_Detalle; }
            set { _Id_Registro_Pago_Cliente_Detalle = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public DateTime Fecha_Timbrado
        {
            get { return _Fecha_Timbrado; }
            set { _Fecha_Timbrado = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public float Saldo_Nuevo
        {
            get { return _Saldo_Nuevo; }
            set { _Saldo_Nuevo = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public float Pago_Aplicar
        {
            get { return _Pago_Aplicar; }
            set { _Pago_Aplicar = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public float Saldo_Favor
        {
            get { return _Saldo_Favor; }
            set { _Saldo_Favor = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_Registro_Pago_Cliente
        {
            get { return _Id_Registro_Pago_Cliente; }
            set { _Id_Registro_Pago_Cliente = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public float Saldo_Anterior
        {
            get { return _Saldo_Anterior; }
            set { _Saldo_Anterior = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public float Interes
        {
            get { return _Interes; }
            set { _Interes = value; }
        }

        //DATASET
        public DataSet dsRegistroPagoCliente()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "REGISTRO PAGO CLIENTE");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region REGISTRO DATOS DEL CONTRIBUYENTE

        //VARIABLES
        int _Id_Datos_Contribuyente;
        string _vchRazonSocial_Contribuyente;
	    string _vchRFC_Contribuyente;
        string _vchPais_Contribuyente;
        string _vchEstado_Contribuyente;
        string _vchCiudad_Contribuyente;
        string _vchCalle_Contribuyente;
        string _vchNoInt_Contribuyente;
        string _vchNoExt_Contribuyente;
        string _vchColonia_Contribuyente;
        string _vchCodigoPostal_Contribuyente;
        string _vchTelefono_Contribuyente;
        string _vchEmail_Contribuyente;
        int _Accion_Datos_Contribuyente;

        //SERIALIZADO

        [System.Xml.Serialization.XmlElementAttribute]
        public int Accion_Datos_Contribuyente
        {
            get { return _Accion_Datos_Contribuyente; }
            set { _Accion_Datos_Contribuyente = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_Datos_Contribuyente
        {
            get { return _Id_Datos_Contribuyente; }
            set { _Id_Datos_Contribuyente = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchRazonSocial_Contribuyente
        {
            get { return _vchRazonSocial_Contribuyente; }
            set { _vchRazonSocial_Contribuyente = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchRFC_Contribuyente
        {
            get { return _vchRFC_Contribuyente; }
            set { _vchRFC_Contribuyente = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchPais_Contribuyente
        {
            get { return _vchPais_Contribuyente; }
            set { _vchPais_Contribuyente = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchEstado_Contribuyente
        {
            get { return _vchEstado_Contribuyente; }
            set { _vchEstado_Contribuyente = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchCiudad_Contribuyente
        {
            get { return _vchCiudad_Contribuyente; }
            set { _vchCiudad_Contribuyente = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchCalle_Contribuyente
        {
            get { return _vchCalle_Contribuyente; }
            set { _vchCalle_Contribuyente = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchNoInt_Contribuyente
        {
            get { return _vchNoInt_Contribuyente; }
            set { _vchNoInt_Contribuyente = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchNoExt_Contribuyente
        {
            get { return _vchNoExt_Contribuyente; }
            set { _vchNoExt_Contribuyente = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchColonia_Contribuyente
        {
            get { return _vchColonia_Contribuyente; }
            set { _vchColonia_Contribuyente = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchCodigoPostal_Contribuyente
        {
            get { return _vchCodigoPostal_Contribuyente; }
            set { _vchCodigoPostal_Contribuyente = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchTelefono_Contribuyente
        {
            get { return _vchTelefono_Contribuyente; }
            set { _vchTelefono_Contribuyente = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string vchEmail_Contribuyente
        {
            get { return _vchEmail_Contribuyente; }
            set { _vchEmail_Contribuyente = value; }
        }

        //DATASET
        public DataSet dsDatosDelContribuyente()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "REGISTRO DATOS DEL CONTRIBUYENTE");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet dsObtenerContribuyente()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "OBTENER CONTRIBUYENTE");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet dsMantenimientoDatosContribuyente()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "MANTENIMIENTO DATOS CONTRIBUYENTES");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region BUSCAR PEDIDO

        /* VARIABLES */
        int _intAccion;
        int _IdCliente;
        string _FolioPedido;
        int _IdPedido; 

        /* SERIALIZADO */
        [System.Xml.Serialization.XmlElementAttribute]
        public int intAccion
        {
            get { return _intAccion; }
            set { _intAccion = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string FolioPedido
        {
            get { return _FolioPedido; }
            set { _FolioPedido = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int IdPedido
        {
            get { return _IdPedido; }
            set { _IdPedido = value; }
        }

        /* DATASET */
        public DataSet dsBusquedaPedido()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "BUSQUEDA DE PEDIDO");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region OBTENER DATOS DE PEDIDO

        /* SERIALIZADO */
        //int _IdPedido;
        string _IdFolioPedido;
        //int _IdCliente;
        //int _intAccion; 

        /* SERIALIZADO */
        [System.Xml.Serialization.XmlElementAttribute]
        public string IdFolioPedido
        {
            get { return _IdFolioPedido; }
            set { _IdFolioPedido = value; }
        }

        /* DATASET */
        public DataSet dsObtenerDatosPedido()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "OBTENER DATOS DEL PEDIDO");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region CARGAR COMBO DE MEDIDAS Y PESO
        public DataSet dsCargarCombo_Medidas_Peso()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "CARGAR COMBO MEDIDAS Y PESO");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region 
        //VARIABLES
        int _Id_Cancelar_Nota_Remisio;
        int _Id_Nota_Remision_Cancelar;
        DateTime _dtp_Fecha_Cancelar;
        int _Id_Cajero_Cancelar;
        int _intAccionCancelar;

        //SERIALIZADO
        [System.Xml.Serialization.XmlElementAttribute]
        public int intAccionCancelar
        {
            get { return _intAccionCancelar; }
            set { _intAccionCancelar = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_Cajero_Cancelar
        {
            get { return _Id_Cajero_Cancelar; }
            set { _Id_Cajero_Cancelar = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_Cancelar_Nota_Remisio
        {
            get { return _Id_Cancelar_Nota_Remisio; }
            set { _Id_Cancelar_Nota_Remisio = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int Id_Nota_Remision_Cancelar
        {
            get { return _Id_Nota_Remision_Cancelar; }
            set { _Id_Nota_Remision_Cancelar = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public DateTime dtp_Fecha_Cancelar
        {
            get { return _dtp_Fecha_Cancelar; }
            set { _dtp_Fecha_Cancelar = value; }
        }

        //DATASET
        public DataSet dsCancelarNotaRemision()
        {
            try
            {
                _wsSegElyon.Url = _strUrlCuentas;
                return _wsSegElyon.dsObtener(this.XML, "MANTENIMIENTO CANCELAR NOTA REMISION");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
