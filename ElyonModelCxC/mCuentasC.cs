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
    [System.Xml.Serialization.XmlRootAttribute("mCuentasC", Namespace = "ELYON", IsNullable = false)]
    public class mCuentasC
    {
        //Referencia WEB
        Wscxc.WsCxC _wsSegElyon = new Wscxc.WsCxC();
        WsCuentasC.WsCuentasC _wsCuentasC = new WsCuentasC.WsCuentasC();

        #region Variables        
        int _intBancoID;
        string _strDescripcion;
        string _strDescripcionCorta;
        int _intClaveBanco;
        decimal _dcComisionCredito;
        decimal _dcComisionDebito;
        decimal _dcComisionChequeDevuelto;
        int _bEstatus;
        int _intEstado;
        string _strNomina;

        int _intIDVendedor;                                    
        string _strNombre;
        string _strApellidoPaterno;
        string _strApellidoMaterno;
        DateTime _dtFecNac;
        DateTime _dtfecIngreso;
        DateTime _dtfecEgreso;
        string _strDomicilio;
        int _intnoInterior;
        int _intNoExterior;
        string _strColonia;
        string _strCp;        
        int _intciudad;
        string _strEmail;
        string _strTelefono;
        int _intIDCliente;
        string _strCodigoCliente;
        string _strDomicilioCliente;
        int _intnoInteriorCliente;
        int _intNoExteriorCliente;
        string _strColoniaCliente;
        string _strCpCliente;
        int _intciudadCliente;
        string _strEmailCliente;
        string _strTelefonoCliente;
        string _strNombreCliente;
        string _strRazonSocial;
        string _strRFC;
        string _strContacto;
        string _strDepto;
        string _strPuesto;
        int _intIDEmpresa;
        string _strClave;
        string _strUrlCuentas;
        string _strConexion;
        #endregion Variables

        #region Serializacion Variables
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

        [System.Xml.Serialization.XmlElementAttribute]
        public string strClave
        {
            get { return _strClave; }
            set { _strClave = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public int intIDEmpresa
        {
            get { return _intIDEmpresa; }
            set { _intIDEmpresa = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strDepto
        {
            get { return _strDepto; }
            set { _strDepto = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strPuesto
        {
            get { return _strPuesto; }
            set { _strPuesto = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strContacto
        {
            get { return _strContacto; }
            set { _strContacto = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strNombreCliente
        {
            get { return _strNombreCliente; }
            set { _strNombreCliente = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strRazonSocial
        {
            get { return _strRazonSocial; }
            set { _strRazonSocial = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strRFC
        {
            get { return _strRFC; }
            set { _strRFC = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strDomicilioCliente
        {
            get { return _strDomicilioCliente; }
            set { _strDomicilioCliente = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intnoInteriorCliente
        {
            get { return _intnoInteriorCliente; }
            set { _intnoInteriorCliente = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intNoExteriorCliente
        {
            get { return _intNoExteriorCliente; }
            set { _intNoExteriorCliente = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strColoniaCliente
        {
            get { return _strColoniaCliente; }
            set { _strColoniaCliente = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strCpCliente
        {
            get { return _strCpCliente; }
            set { _strCpCliente = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intciudadCliente
        {
            get { return _intciudadCliente; }
            set { _intciudadCliente = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strEmailCliente
        {
            get { return _strEmailCliente; }
            set { _strEmailCliente = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strTelefonoCliente
        {
            get { return _strTelefonoCliente; }
            set { _strTelefonoCliente = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strCodigoCliente
        {
            get { return _strCodigoCliente; }
            set { _strCodigoCliente = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public int intIDCliente
        {
            get { return _intIDCliente; }
            set { _intIDCliente = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intIDVendedor
        {
            get { return _intIDVendedor; }
            set { _intIDVendedor = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strNombre
        {
            get { return _strNombre; }
            set { _strNombre = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strApellidoPaterno
        {
            get { return _strApellidoPaterno; }
            set { _strApellidoPaterno = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strApellidoMaterno
        {
            get { return _strApellidoMaterno; }
            set { _strApellidoMaterno = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public DateTime dtFecNac
        {
            get { return _dtFecNac; }
            set { _dtFecNac = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public DateTime dtfecIngreso
        {
            get { return _dtfecIngreso; }
            set { _dtfecIngreso = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public DateTime dtfecEgreso
        {
            get { return _dtfecEgreso; }
            set { _dtfecEgreso = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strDomicilio
        {
            get { return _strDomicilio; }
            set { _strDomicilio = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intnoInterior
        {
            get { return _intnoInterior; }
            set { _intnoInterior = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intNoExterior
        {
            get { return _intNoExterior; }
            set { _intNoExterior = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strColonia
        {
            get { return _strColonia; }
            set { _strColonia = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strCp
        {
            get { return _strCp; }
            set { _strCp = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intciudad
        {
            get { return _intciudad; }
            set { _intciudad = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strEmail
        {
            get { return _strEmail; }
            set { _strEmail = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strTelefono
        {
            get { return _strTelefono; }
            set { _strTelefono = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strNomina
        {
            get { return _strNomina; }
            set { _strNomina = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intEstado
        {
            get { return _intEstado; }
            set { _intEstado = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int bEstatus
        {
            get { return _bEstatus; }
            set { _bEstatus = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public decimal dcComisionChequeDevuelto
        {
            get { return _dcComisionChequeDevuelto; }
            set { _dcComisionChequeDevuelto = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public decimal dcComisionDebito
        {
            get { return _dcComisionDebito; }
            set { _dcComisionDebito = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public decimal dcComisionCredito
        {
            get { return _dcComisionCredito; }
            set { _dcComisionCredito = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intClaveBanco
        {
            get { return _intClaveBanco; }
            set { _intClaveBanco = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strDescripcionCorta
        {
            get { return _strDescripcionCorta; }
            set { _strDescripcionCorta = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intBancoID
        {
            get { return _intBancoID; }
            set { _intBancoID = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strDescripcion
        {
            get { return _strDescripcion; }
            set { _strDescripcion = value; }

        }
        #endregion Serializacion Variables

        #region CONSTRUCTOR
        public mCuentasC()
        {

        }

        public mCuentasC(string strConexion, string strUrlCuentas)
        {
            this._strConexion = strConexion;
            this._strUrlCuentas = strUrlCuentas;
        }
        #endregion CONSTRUCTOR

        #region XML
        public virtual string XML
        {
            get
            {
                return Serializer.ToXml(this, this.GetType());
            }
        }
        public static mCuentasC FromXml(string XmlString)
        {
            return ((mCuentasC)Serializer.FromXml(XmlString, typeof(mCuentasC)));
        }
        #endregion XML

        #region DATASET 
        public DataSet dsObtenerValiacionClaveBanco()
        {
            try
            {
                _wsCuentasC.Url = _strUrlCuentas;
                return _wsCuentasC.dsObtener(this.XML, "OBTENER VALIDACION CLAVES BANCO");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet CargarReporteEmpresas()
        {
            try
            {
                _wsCuentasC.Url = _strUrlCuentas;
                return _wsCuentasC.dsObtener(this.XML, "CARGAR REPORTE EMPRESAS");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet CargarReporteClientes()
        {
            try
            {
                _wsCuentasC.Url = _strUrlCuentas;
                return _wsCuentasC.dsObtener(this.XML, "CARGAR REPORTE CLIENTES");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet CargarReporteVendedor()
        {
            try
            {
                _wsCuentasC.Url = _strUrlCuentas;
                return _wsCuentasC.dsObtener(this.XML, "CARGAR REPORTE VENDEDORES");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet CargarReporteBancos()
        {
            try
            {
                _wsCuentasC.Url = _strUrlCuentas;
                return _wsCuentasC.dsObtener(this.XML, "CARGAR REPORTE BANCOS");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsCargarClientes()
        {
            try
            {
                _wsCuentasC.Url = _strUrlCuentas;
                return _wsCuentasC.dsObtener(this.XML, "CARGAR CLIENTES");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsBuscarClientes()
        {
            try
            {
                _wsCuentasC.Url = _strUrlCuentas;
                return _wsCuentasC.dsObtener(this.XML, "BUSCAR CLIENTES");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsCargarvendedores()
        {
            try
            {
                _wsCuentasC.Url = _strUrlCuentas;
                return _wsCuentasC.dsObtener(this.XML, "CARGAR VENDEDORES");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsBuscarvendedor()
        {
            try
            {
                _wsCuentasC.Url = _strUrlCuentas;
                return _wsCuentasC.dsObtener(this.XML, "BUSCAR VENDEDOR");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsObtenerEstados()
        {
            try
            {
                _wsCuentasC.Url = _strUrlCuentas;
                return _wsCuentasC.dsObtener(this.XML, "CARGAR ESTADOS");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsObtenerCiudades()
        {
            try
            {
                _wsCuentasC.Url = _strUrlCuentas;
                return _wsCuentasC.dsObtener(this.XML, "CARGAR CIUDADES");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsCargarBancos()
        {
            try
            {
                _wsCuentasC.Url = _strUrlCuentas;
                return _wsCuentasC.dsObtener(this.XML, "CARGAR BANCOS");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsBuscarCliente()
        {
            try
            {
                _wsCuentasC.Url = _strUrlCuentas;
                return _wsCuentasC.dsObtener(this.XML, "BUSCA LOS CLIENTE");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsCargarEmpresas()
        {
            try
            {
                _wsCuentasC.Url = _strUrlCuentas;
                return _wsCuentasC.dsObtener(this.XML, "CARGAR EMPRESAS");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsBuscarEmpresaCodigo()
        {
            try
            {
                _wsCuentasC.Url = _strUrlCuentas;
                return _wsCuentasC.dsObtener(this.XML, "BUSCA EMPRESAS POR CLAVE");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsBuscarEmpresa()
        {
            try
            {
                _wsCuentasC.Url = _strUrlCuentas;
                return _wsCuentasC.dsObtener(this.XML, "BUSCA EMPRESAS");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsBuscarVendedorClienteEmpresa()
        {
            try
            {
                _wsCuentasC.Url = _strUrlCuentas;
                return _wsCuentasC.dsObtener(this.XML, "BUSCA VENDEDOR CLIENTES EMPRESAS");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsCargarvendedoresActivos()
        {
            try
            {
                _wsCuentasC.Url = _strUrlCuentas;
                return _wsCuentasC.dsObtener(this.XML, "CARGAR VENDEDOR ACTIVOS");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsBuscarClaveClienteEmpresa()
        {
            try
            {
                _wsCuentasC.Url = _strUrlCuentas;
                return _wsCuentasC.dsObtener(this.XML, "CARGAR GRID CLIENTES EMPRESA");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        #endregion DATASET 

        #region BOOL 
        public bool bGuardarBancos()
        {
            _wsCuentasC.Url = _strUrlCuentas;
            return _wsCuentasC.bObtener1(this.XML, "ALMACENA BANCOS");
        }
        public bool bEliminaBancos()
        {
            _wsCuentasC.Url = _strUrlCuentas;
            return _wsCuentasC.bObtener1(this.XML, "ELIMINA BANCOS");
        }
        public bool bGuardarVendedor()
        {
            _wsCuentasC.Url = _strUrlCuentas;
            return _wsCuentasC.bObtener1(this.XML, "ALMACENA VENDEDORES");
        }
        public bool bEliminaVendedor()
        {
            _wsCuentasC.Url = _strUrlCuentas;
            return _wsCuentasC.bObtener1(this.XML, "ELIMINA VENDEDORES");
        }
        public bool bGuardarCliente()
        {
            _wsCuentasC.Url = _strUrlCuentas;
            return _wsCuentasC.bObtener1(this.XML, "ALMACENA CLIENTES");
        }
        public bool bEliminaCliente()
        {
            _wsCuentasC.Url = _strUrlCuentas;
            return _wsCuentasC.bObtener1(this.XML, "ELIMINA CLIENTES");
        }
        public bool bGuardarEmpresa()
        {
            _wsCuentasC.Url = _strUrlCuentas;
            return _wsCuentasC.bObtener1(this.XML, "ALMACENA EMPRESAS");
        }
        public bool bEliminaEmpresa()
        {
            _wsCuentasC.Url = _strUrlCuentas;
            return _wsCuentasC.bObtener1(this.XML, "ELIMINA EMPRESAS");
        }
        public bool bGuardarVendedorEmpresa()
        {
            _wsCuentasC.Url = _strUrlCuentas;
            return _wsCuentasC.bObtener1(this.XML, "ALMACENA VENDEDOR EMPRESAS");
        }
        public bool bGuardarVendedorClientes()
        {
            _wsCuentasC.Url = _strUrlCuentas;
            return _wsCuentasC.bObtener1(this.XML, "ALMACENA VENDEDOR CLIENTES");
        }
        public bool bEliminaVendedorEmpresa()
        {
            _wsCuentasC.Url = _strUrlCuentas;
            return _wsCuentasC.bObtener1(this.XML, "ELIMINA VENDEDOR EMPRESAS");
        }
        public bool bEliminaVendedorClientes()
        {
            _wsCuentasC.Url = _strUrlCuentas;
            return _wsCuentasC.bObtener1(this.XML, "ELIMINA VENDEDOR CLIENTES");
        }
        #endregion BOOL
    }
}
