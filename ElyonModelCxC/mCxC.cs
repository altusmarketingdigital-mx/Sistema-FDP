using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Security.Cryptography;
using System.Data.SqlTypes;
using System.Configuration;
using System.DirectoryServices;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Mail;

namespace ElyonModelCxC
{
    [System.Xml.Serialization.XmlRootAttribute("mCxC", Namespace = "ELYON", IsNullable = false)]
    public class mCxC
    {
        //Referencia WEB
        Wscxc.WsCxC _wsSegElyon = new Wscxc.WsCxC();        

        #region Variables
        int _intIDAplcacion;
        string _vchUsuarioNombre;
        string _strUsuarioMenu;
        string _strRutaImagen;
        string _strConexion;
        string _strConexionSagu;
        string _strConexionSAES;
        string _conFinanzas;
        string _strUsuario;
        string _strTipo;
        string _strContraseña;
        string _strNombreUsuario;
        string _strNombreMenu;
        string _strNombreItem;
        string _strEmail;
        string _strClaveTipoProceso;
        string _strDescTipoProceso;
        string _strClaveNivSeg;
        string _strDescNivSeg;
        string _strStatusNivSeg;
        string _strTipoProceso;
        string _strNombreProceso;
        string _strSiglas;
        string _strMensaje;
        string _strvcPrograma;
        string _strvchProgEsc;
        string _strvcImagen;
        string _strchrTipo;
        string _strImgSerializada;
        string _strUsuarioSistema;
        string _strServidorSalida;
        string _strPuertoSalida;
        string _strUsuarioEnvia;
        string _strContraseñaEnvia;
        string _strNombreCortoApp;
        string _strNombreLargoApp;
        string _StrJson;
        string _strvchNombre; 
        string _strvchPaterno;
        string _strvchMaterno;
        string _strvchClaveDepto;
        string _strvchDescDepto;
        string _strvchDescPuesto;
        bool _bActivo;
        bool _bAdmin;
        int _intFolio;
        int _intParametro;
        int _intNivelProceso;
        int _intNavegacion;
        int _intEstatus;
        int _intPadre;
        int _intMenuKey;
        int _intAplicacion;
        int _intTipoMenu;
        int _intNivSeguridad;
        int _intTipoProceso;
        string _intNomina;
        int _intNivel;
        int _IDMenu;
        int _intArmaMenus;
        int _intOrden;
        int _intIDAviso;
        string _intPlantelID;
        string _IdPlantelUsuario;
        int _intPrimeraVes;
        int _intIdUsuario;
        int _intIdUsuario1;
        DateTime _dtFechaNacimiento;
        DateTime _dtFecha;
        bool _bAsignaAutomatico;
        bool _bSeguridaplantel;
        bool _bSeguridadAdmin;
        int _intLeido;
        int _intBorrado;
        int _intTipo;
        string _Mensaje;
        int _intIdConcepto;
        int _intCantidad;
        string _strDescripcion;
        string _strIdBoton;

        Font tFont = new Font("Century Gothic", 12);
        int _intKeyAnt = 0;
        string KeyMenuAnterior = "";
        string NombreMensaje;
        string tipoMenu = "";
        int _bVisible;
        string _strUrlSeguridad;       
        int _intCajVentas;
        int _intCanVenta;
        int _intSoloCanVenta;
        int _intDesArticulo;
        int _intSoloDesArticulo;
        int _intCantVenta;
        int _intSoloCantVenta;
        int _intNoModPre;
        int _intSoloNoModPre;
        int _intPrecioVen;
        int _intSoloPrecioVen;
        int _intOtoDesc;
        int _intSoloOtoDesc;
        int _intModDatCred;
        int _intSoloModDatCred;
        int _intParMoneda;
        int _intSoloParMoneda;
        int _intCajon;
        int _intIDValUsuario;
        #endregion Variables

        #region Serializacion Variables  
        [System.Xml.Serialization.XmlElementAttribute]
        public int intIDValUsuario
        {
            get { return _intIDValUsuario; }
            set { _intIDValUsuario = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intCajVentas
        {
            get { return _intCajVentas; }
            set { _intCajVentas = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intCanVenta
        {
            get { return _intCanVenta; }
            set { _intCanVenta = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intSoloCanVenta
        {
            get { return _intSoloCanVenta; }
            set { _intSoloCanVenta = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intDesArticulo
        {
            get { return _intDesArticulo; }
            set { _intDesArticulo = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intSoloDesArticulo
        {
            get { return _intSoloDesArticulo; }
            set { _intSoloDesArticulo = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intCantVenta
        {
            get { return _intCantVenta; }
            set { _intCantVenta = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intSoloCantVenta
        {
            get { return _intSoloCantVenta; }
            set { _intSoloCantVenta = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intNoModPre
        {
            get { return _intNoModPre; }
            set { _intNoModPre = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intSoloNoModPre
        {
            get { return _intSoloNoModPre; }
            set { _intSoloNoModPre = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intPrecioVen
        {
            get { return _intPrecioVen; }
            set { _intPrecioVen = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intSoloPrecioVen
        {
            get { return _intSoloPrecioVen; }
            set { _intSoloPrecioVen = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intOtoDesc
        {
            get { return _intOtoDesc; }
            set { _intOtoDesc = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intSoloOtoDesc
        {
            get { return _intSoloOtoDesc; }
            set { _intSoloOtoDesc = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intModDatCred
        {
            get { return _intModDatCred; }
            set { _intModDatCred = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intSoloModDatCred
        {
            get { return _intSoloModDatCred; }
            set { _intSoloModDatCred = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intParMoneda
        {
            get { return _intParMoneda; }
            set { _intParMoneda = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intSoloParMoneda
        {
            get { return _intSoloParMoneda; }
            set { _intSoloParMoneda = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intCajon
        {
            get { return _intCajon; }
            set { _intCajon = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strUrlSeguridad
        {
            get { return _strUrlSeguridad; }
            set { _strUrlSeguridad = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public bool bSeguridadAdmin
        {
            get { return _bSeguridadAdmin; }
            set { _bSeguridadAdmin = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strvchClaveDepto
        {
            get { return _strvchClaveDepto; }
            set { _strvchClaveDepto = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strvchDescpuesto
        {
            get { return _strvchDescPuesto; }
            set { _strvchDescPuesto = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strvchDescDepto
        {
            get { return _strvchDescDepto; }
            set { _strvchDescDepto = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strvchMaterno
        {
            get { return _strvchMaterno; }
            set { _strvchMaterno = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strvchPaterno
        {
            get { return _strvchPaterno; }
            set { _strvchPaterno = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strvchNombre
        {
            get { return _strvchNombre; }
            set { _strvchNombre = value; }

        }


        [System.Xml.Serialization.XmlElementAttribute]
        public int bVisible
        {
            get { return _bVisible; }
            set { _bVisible = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strIdBoton
        {
            get { return _strIdBoton; }
            set { _strIdBoton = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strDescripcion
        {
            get { return _strDescripcion; }
            set { _strDescripcion = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intCantidad
        {
            get { return _intCantidad; }
            set { _intCantidad = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strNombreLargoApp
        {
            get { return _strNombreLargoApp; }
            set { _strNombreLargoApp = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strNombreCortoApp
        {
            get { return _strNombreCortoApp; }
            set { _strNombreCortoApp = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intIdConcepto
        {
            get { return _intIdConcepto; }
            set { _intIdConcepto = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string Mensaje
        {
            get { return _Mensaje; }
            set { _Mensaje = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string StrJson
        {
            get { return _StrJson; }
            set { _StrJson = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intTipo
        {
            get { return _intTipo; }
            set { _intTipo = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intBorrado
        {
            get { return _intBorrado; }
            set { _intBorrado = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intLeido
        {
            get { return _intLeido; }
            set { _intLeido = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public DateTime dtFecha
        {
            get { return _dtFecha; }
            set { _dtFecha = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public bool bSeguridaplantel
        {
            get { return _bSeguridaplantel; }
            set { _bSeguridaplantel = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public bool bAsignaAutomatico
        {
            get { return _bAsignaAutomatico; }
            set { _bAsignaAutomatico = value; }

        }
        public string strRutaImagen
        {
            get { return _strRutaImagen; }
            set { _strRutaImagen = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strUsuarioSistema
        {
            get { return _strUsuarioSistema; }
            set { _strUsuarioSistema = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strServidorSalida
        {
            get { return _strServidorSalida; }
            set { _strServidorSalida = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strPuertoSalida
        {
            get { return _strPuertoSalida; }
            set { _strPuertoSalida = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strUsuarioEnvia
        {
            get { return _strUsuarioEnvia; }
            set { _strUsuarioEnvia = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strContraseñaEnvia
        {
            get { return _strContraseñaEnvia; }
            set { _strContraseñaEnvia = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intFolio
        {
            get { return _intFolio; }
            set { _intFolio = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intParametro
        {
            get { return _intParametro; }
            set { _intParametro = value; }

        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string conFinanzas
        {
            get { return _conFinanzas; }
            set { _conFinanzas = value; }

        }
        [System.Xml.Serialization.XmlElementAttribute]
        public bool bAdmin
        {
            get { return _bAdmin; }
            set { _bAdmin = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intIdUsuario1
        {
            get { return _intIdUsuario1; }
            set { _intIdUsuario1 = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intIdUsuario
        {
            get { return _intIdUsuario; }
            set { _intIdUsuario = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strNombreUsuario
        {
            get { return _strNombreUsuario; }
            set { _strNombreUsuario = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public DateTime dtFechaNacimiento
        {
            get { return _dtFechaNacimiento; }
            set { _dtFechaNacimiento = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intPrimeraVes
        {
            get { return _intPrimeraVes; }
            set { _intPrimeraVes = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public bool bActivo
        {
            get { return _bActivo; }
            set { _bActivo = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string IdPlantelUsuario
        {
            get { return _IdPlantelUsuario; }
            set { _IdPlantelUsuario = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string intPlantelID
        {
            get { return _intPlantelID; }
            set { _intPlantelID = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intIDAviso
        {
            get { return _intIDAviso; }
            set { _intIDAviso = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strImgSerializada
        {
            get { return _strImgSerializada; }
            set { _strImgSerializada = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intOrden
        {
            get { return _intOrden; }
            set { _intOrden = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intArmaMenus
        {
            get { return _intArmaMenus; }
            set { _intArmaMenus = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strTipoProceso
        {
            get { return _strTipoProceso; }
            set { _strTipoProceso = value; }
        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strNombreProceso
        {
            get { return _strNombreProceso; }
            set { _strNombreProceso = value; }
        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strSiglas
        {
            get { return _strSiglas; }
            set { _strSiglas = value; }
        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strMensaje
        {
            get { return _strMensaje; }
            set { _strMensaje = value; }
        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strvcPrograma
        {
            get { return _strvcPrograma; }
            set { _strvcPrograma = value; }
        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strvchProgEsc
        {
            get { return _strvchProgEsc; }
            set { _strvchProgEsc = value; }
        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strvcImagen
        {
            get { return _strvcImagen; }
            set { _strvcImagen = value; }
        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strchrTipo
        {
            get { return _strchrTipo; }
            set { _strchrTipo = value; }
        }
        [System.Xml.Serialization.XmlElementAttribute]
        public int intNivelProceso
        {
            get { return _intNivelProceso; }
            set { _intNivelProceso = value; }
        }
        [System.Xml.Serialization.XmlElementAttribute]
        public int intNavegacion
        {
            get { return _intNavegacion; }
            set { _intNavegacion = value; }
        }
        [System.Xml.Serialization.XmlElementAttribute]
        public int intEstatus
        {
            get { return _intEstatus; }
            set { _intEstatus = value; }
        }
        [System.Xml.Serialization.XmlElementAttribute]
        public int intPadre
        {
            get { return _intPadre; }
            set { _intPadre = value; }
        }
        [System.Xml.Serialization.XmlElementAttribute]
        public int intMenuKey
        {
            get { return _intMenuKey; }
            set { _intMenuKey = value; }
        }
        [System.Xml.Serialization.XmlElementAttribute]
        public int intAplicacion
        {
            get { return _intAplicacion; }
            set { _intAplicacion = value; }
        }
        [System.Xml.Serialization.XmlElementAttribute]
        public int intTipoMenu
        {
            get { return _intTipoMenu; }
            set { _intTipoMenu = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strClaveNivSeg
        {
            get { return _strClaveNivSeg; }
            set { _strClaveNivSeg = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strDescNivSeg
        {
            get { return _strDescNivSeg; }
            set { _strDescNivSeg = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strStatusNivSeg
        {
            get { return _strStatusNivSeg; }
            set { _strStatusNivSeg = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intNivSeguridad
        {
            get { return _intNivSeguridad; }
            set { _intNivSeguridad = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strClaveTipoProceso
        {
            get { return _strClaveTipoProceso; }
            set { _strClaveTipoProceso = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strDescTipoProceso
        {
            get { return _strDescTipoProceso; }
            set { _strDescTipoProceso = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int intTipoProceso
        {
            get { return _intTipoProceso; }
            set { _intTipoProceso = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strConexionSagu
        {
            get { return _strConexionSagu; }
            set { _strConexionSagu = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strConexionSAES
        {
            get { return _strConexionSAES; }
            set { _strConexionSAES = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strEmail
        {
            get { return _strEmail; }
            set { _strEmail = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public int IDMenu
        {
            get { return _IDMenu; }
            set { _IDMenu = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public string strNombreItem
        {
            get { return _strNombreItem; }
            set { _strNombreItem = value; }
        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strNombreMenu
        {
            get { return _strNombreMenu; }
            set { _strNombreMenu = value; }
        }
        [System.Xml.Serialization.XmlElementAttribute]
        public int intNivel
        {
            get { return _intNivel; }
            set { _intNivel = value; }
        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strConexion
        {
            get { return _strConexion; }
            set { _strConexion = value; }
        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strUsuario
        {
            get { return _strUsuario; }
            set { _strUsuario = value; }
        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strTipo
        {
            get { return _strTipo; }
            set { _strTipo = value; }
        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string strContraseña
        {
            get { return _strContraseña; }
            set { _strContraseña = value; }
        }
        [System.Xml.Serialization.XmlElementAttribute]
        public string intNomina
        {
            get { return _intNomina; }
            set { _intNomina = value; }
        }
        #endregion Serializacion Variables

        #region CONSTRUCTOR
        public mCxC()
        {

        }
        public mCxC(string strConexion, string strUrlSeguridad)
        {
            this._strConexion = strConexion;
            this._strUrlSeguridad = strUrlSeguridad;
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
        public static mCxC FromXml(string XmlString)
        {
            return ((mCxC)Serializer.FromXml(XmlString, typeof(mCxC)));
        }
        #endregion XML
        
        #region FORMA MENU       
        public void CargaMenus(Dictionary<string, object> Dic, MenuStrip menuStrip1, TabControl tabcontrolMnu)
        {
            DataSet dtMenuItems = new DataSet();
            MenuItem mnuMenuItem = new MenuItem();
            MenuItem mnuMenuItem1 = new MenuItem();

            _strUsuario = Dic["IDUSUARIO"].ToString();
            _strRutaImagen = "";
            _vchUsuarioNombre = Dic["USUARIO"].ToString();
            intAplicacion = int.Parse(Dic["IDAPP"].ToString());
            _intIDAplcacion = int.Parse(Dic["IDAPP"].ToString());
            try
            {
                strUsuario = _strUsuario;
                strTipo = "0"; //0 = Escritorio y 1= WEB
                intArmaMenus = 1;
                dtMenuItems = dsCargaMenu();

                foreach (DataRow drMenuItem in dtMenuItems.Tables[0].Rows)
                {
                    //'esta condicion indica q son elementos padre.                
                    if (drMenuItem["PK_Menu"].Equals(drMenuItem["idpadre"]))
                    {
                        mnuMenuItem.Name = drMenuItem["PK_Menu"].ToString();
                        mnuMenuItem.Text = drMenuItem["NombreProceso"].ToString();
                        tipoMenu = drMenuItem["tipo"].ToString();
                        _strRutaImagen = drMenuItem["Ruta"].ToString();


                        //Agrega imagen a cada Menu
                        //---------------------------                        
                        //object O = AppElyonCXC.Properties.Resources.ResourceManager.GetObject(_strRutaImagen);

                        ToolStripMenuItem File = new ToolStripMenuItem();
                        try
                        {
                            File.Text = drMenuItem["NombreProceso"].ToString();
                            File.Name = mnuMenuItem.Name;
                            if (_strRutaImagen != "")
                            {
                                string fullimagepath = Path.Combine(Application.StartupPath, _strRutaImagen);
                                File.Image = Image.FromFile(fullimagepath);
                                File.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                            }
                        }
                        catch (Exception e)
                        {

                        }

                        File.ForeColor = Color.Black;
                        menuStrip1.Items.Add(File);

                        DataSet dtMenuItems1 = new DataSet();
                        dtMenuItems1 = dtMenuItems;
                        if (tipoMenu == "P")
                        {
                            File.Click += new EventHandler((sender1, e1) => New_Click(sender1, e1, tabcontrolMnu));
                        }
                        else
                        {
                            AddMenus(mnuMenuItem, dtMenuItems1, File, tabcontrolMnu);
                        }
                    }

                }
            }
            catch (Exception ex) { }
        }
        public void CargaMenus(string IdUsuario, int _intIdApp, MenuStrip menuStrip1, TabControl tabcontrolMnu, string _vchUsuario)
        {
            DataSet dtMenuItems = new DataSet();
            MenuItem mnuMenuItem = new MenuItem();
            MenuItem mnuMenuItem1 = new MenuItem();

            _vchUsuarioNombre = _vchUsuario;
            _strUsuario = IdUsuario;
            _strRutaImagen = "";
            _intIDAplcacion = _intIdApp;

            try
            {
                strUsuario = IdUsuario;
                strTipo = "0"; //0 = Escritorio y 1= WEB
                intArmaMenus = 1;
                intAplicacion = _intIDAplcacion;
                dtMenuItems = dsCargaMenu();

                //foreach (DataRow drMenuItem in dtMenuItems.Tables["pObtenerMenuUsuarios"].Rows)
                foreach (DataRow drMenuItem in dtMenuItems.Tables[0].Rows)
                {
                    //'esta condicion indica q son elementos padre.                
                    if (drMenuItem["PK_Menu"].Equals(drMenuItem["idpadre"]))
                    {
                        mnuMenuItem.Name = drMenuItem["PK_Menu"].ToString();
                        mnuMenuItem.Text = drMenuItem["NombreProceso"].ToString();
                        tipoMenu = drMenuItem["tipo"].ToString();
                        _strRutaImagen = drMenuItem["Ruta"].ToString();


                        //Agrega imagen a cada Menu
                        //---------------------------                        
                        //object O = AppElyonCXC.Properties.Resources.ResourceManager.GetObject(_strRutaImagen);

                        ToolStripMenuItem File = new ToolStripMenuItem();
                        try
                        {
                            File.Text = drMenuItem["NombreProceso"].ToString();
                            File.Name = mnuMenuItem.Name;
                            if (_strRutaImagen != "")
                            {
                                string fullimagepath = Path.Combine(Application.StartupPath, _strRutaImagen);
                                File.Image = Image.FromFile(fullimagepath);
                                File.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                            }
                        }
                        catch (Exception e)
                        {

                        }

                        File.ForeColor = Color.Black;
                        menuStrip1.Items.Add(File);

                        DataSet dtMenuItems1 = new DataSet();
                        dtMenuItems1 = dtMenuItems;
                        if (tipoMenu == "P")
                        {
                            File.Click += new EventHandler((sender1, e1) => New_Click(sender1, e1, tabcontrolMnu));
                        }
                        else
                        {
                            AddMenus(mnuMenuItem, dtMenuItems1, File, tabcontrolMnu);
                        }
                    }

                }
            }
            catch (Exception ex) { }
        }

        //Genera Menus Hijos del 2 Nivel
        private void AddMenus(MenuItem mnuMenuItem, DataSet dtMenuItems1, ToolStripMenuItem File, TabControl tabcontrolMnu)
        {
            _strRutaImagen = "";
            MenuItem mnuMenuItem1 = new MenuItem();

            //foreach (DataRow drMenuItem1 in dtMenuItems1.Tables["pObtenerMenuUsuarios"].Rows)
            foreach (DataRow drMenuItem1 in dtMenuItems1.Tables[0].Rows)
            {
                if (drMenuItem1["idpadre"].ToString().Equals(mnuMenuItem.Name) & !drMenuItem1["PK_Menu"].Equals(drMenuItem1["idpadre"]))
                {
                    mnuMenuItem1.Name = drMenuItem1["PK_Menu"].ToString();
                    mnuMenuItem1.Text = drMenuItem1["NombreProceso"].ToString();
                    _strRutaImagen = drMenuItem1["Ruta"].ToString();

                    //Agrega imagen a cada Menu
                    //---------------------------
                    //System.Drawing.Image ssA;
                    //object O = AppElyonCXC.Properties.Resources.ResourceManager.GetObject(_strRutaImagen);

                    ToolStripMenuItem New = new ToolStripMenuItem(drMenuItem1["NombreProceso"].ToString());
                    New.Name = mnuMenuItem1.Name;
                    try
                    {
                        if (_strRutaImagen != "")
                        {
                            string fullimagepath = Path.Combine(Application.StartupPath, _strRutaImagen);
                            New.Image = Image.FromFile(fullimagepath);
                            New.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                        }
                    }
                    catch (Exception e)
                    {

                    }

                    New.Click += new EventHandler((sender1, e1) => New_Click(sender1, e1, tabcontrolMnu));

                    File.DropDownItems.Add(New);


                    DataSet dtMenuItems2 = new DataSet();
                    dtMenuItems2 = dtMenuItems1;

                    AddMenuHijos(mnuMenuItem1, dtMenuItems2, New, tabcontrolMnu);

                }

            }
        }

        //Genera Menus Hijos del 3 Nivel
        private void AddMenuHijos(MenuItem mnuMenuItem1, DataSet dtMenuItems2, ToolStripMenuItem New, TabControl tabcontrolMnu)
        {
            _strRutaImagen = "";
            //foreach (DataRow drMenuItem2 in dtMenuItems2.Tables["pObtenerMenuUsuarios"].Rows)
            foreach (DataRow drMenuItem2 in dtMenuItems2.Tables[0].Rows)
            {
                if (drMenuItem2["idpadre"].ToString().Equals(mnuMenuItem1.Name) & !drMenuItem2["PK_Menu"].Equals(drMenuItem2["idpadre"]))
                {
                    _strRutaImagen = drMenuItem2["Ruta"].ToString();
                    #region Agrega imagen a cada Menu
                    //---------------------------                  
                    //object O = AppElyonCXC.Properties.Resources.ResourceManager.GetObject(_strRutaImagen);


                    ToolStripMenuItem New1 = new ToolStripMenuItem(drMenuItem2["NombreProceso"].ToString());
                    New1.Name = drMenuItem2["PK_Menu"].ToString();
                    try
                    {
                        if (_strRutaImagen != "")
                        {
                            string fullimagepath = Path.Combine(Application.StartupPath, _strRutaImagen);
                            New1.Image = Image.FromFile(fullimagepath);
                            New1.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                        }
                    }
                    catch (Exception e)
                    {

                    }

                    New1.Click += new EventHandler((sender1, e1) => New_Click(sender1, e1, tabcontrolMnu));
                    #endregion Agrega imagen a cada Menu

                    New.DropDownItems.Add(New1);
                }
            }
        }

        void New_Click(object sender, EventArgs e, TabControl tabcontrolMnu)
        {
            string KeyMenu = "";

            ToolStripMenuItem cb = (ToolStripMenuItem)sender;
            KeyMenu = cb.Name;
            //KeyMenu = sender.ToString();
            ObtieneNombreMenu(KeyMenu, tabcontrolMnu);
        }

        private void ObtieneNombreMenu(string KeyMenu, TabControl tabcontrolMnu)
        {
            string strItem;
            string strPrograma = "";
            string strMenuId = "";
            string NombreMensaje = "";
            DataSet DsMnus = new DataSet();

            try
            {
                intMenuKey = int.Parse(KeyMenu);
                DsMnus = dsSeleccionamenus();

                if (DsMnus.Tables[0].Rows.Count > 0)
                {
                    NombreMensaje = DsMnus.Tables[0].Rows[0].ItemArray[1].ToString();
                    strItem = DsMnus.Tables[0].Rows[0].ItemArray[2].ToString();
                    strPrograma = DsMnus.Tables[0].Rows[0].ItemArray[9].ToString();
                    strMenuId = DsMnus.Tables[0].Rows[0].ItemArray[10].ToString();

                    OpcionMenu(strPrograma, strItem, NombreMensaje, strMenuId, tabcontrolMnu);
                }
                else
                {
                    MessageBox.Show("NO existen Menus");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Procedimiento fallo");
            }
        }
        public void ObtieneNombreMenusUsados(string KeyMenu, TabControl tabcontrolMnu, int Usu)
        {
            string strItem;
            string strPrograma = "";
            string strMenuId = "";
            string NombreMensaje = "";
            DataSet DsMnus = new DataSet();
            _strUsuario = Usu.ToString();

            try
            {
                intMenuKey = int.Parse(KeyMenu);
                DsMnus = dsSeleccionamenus();

                if (DsMnus.Tables[0].Rows.Count > 0)
                {
                    NombreMensaje = DsMnus.Tables[0].Rows[0].ItemArray[1].ToString();
                    strItem = DsMnus.Tables[0].Rows[0].ItemArray[2].ToString();
                    strPrograma = DsMnus.Tables[0].Rows[0].ItemArray[9].ToString();
                    strMenuId = DsMnus.Tables[0].Rows[0].ItemArray[10].ToString();

                    OpcionMenu(strPrograma, strItem, NombreMensaje, strMenuId, tabcontrolMnu);
                }
                else
                {
                    MessageBox.Show("NO existen Menus");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Procedimiento fallo");
            }
        }
        private void OpcionMenu(string strPrograma, string strItem, string NomMje, string strMid, TabControl tabcontrolMnu)
        {
            int intValida = 0;
            if (strPrograma == null || strPrograma == "")
            {
                MessageBox.Show("Menu Padre");
            }
            else
            {
                //Valida Nivel de Seguridad
                intValida = VerificaAcceso(strMid, _strUsuario);
                if (intValida > 0)
                {
                    if (EstatusMenu(strMid) == 0)
                    {
                        MessageBox.Show("Programa en Mantenimiento ó Programa Deshabilitado");
                    }
                    else
                    {
                        //Cargar Opcion de Menus                       
                        CargaFormax(strPrograma, NomMje, tabcontrolMnu, strMid);
                    }
                }
            }
        }

        public int VerificaAcceso(string NombreItem, string Usuario)
        {
            int _intRegresa = 0;
            int intValida = 0;
            try
            {
                DataSet dsPermiso = new DataSet();
                strUsuario = _strUsuario;
                strNombreItem = NombreItem;
                intNivel = 0;
                intAplicacion = _intIDAplcacion;

                dsPermiso = dsCargaPermisosMenus();


                if (dsPermiso.Tables[0].Rows.Count > 0)
                {
                    _intRegresa = (int)dsPermiso.Tables[0].Rows[0].ItemArray[0];
                    if (_intRegresa > 0)
                    {
                        intValida = 1;
                        intNivel = _intRegresa;
                    }
                    else
                    {
                        intValida = 0;
                        intNivel = _intRegresa;
                    }
                }
                else
                {
                    intValida = 0;
                    intNivel = _intRegresa;
                    MessageBox.Show("El usuario no tiene permiso a este Programa");
                }
            }
            catch
            {
                intValida = 0;
                intNivel = _intRegresa;
            }

            return intValida;
        }

        public int EstatusMenu(string strMid)
        {
            int EstMenu = 0;
            DataSet dsEstMnu = new DataSet();
            try
            {
                strNombreItem = strMid;
                intAplicacion = _intIDAplcacion;
                dsEstMnu = dsVerificaEstadoMenu(); //aqui me quede

                if (dsEstMnu.Tables[0].Rows.Count > 0)
                {
                    EstMenu = (int)dsEstMnu.Tables[0].Rows[0].ItemArray[0];
                }
                else
                {
                    EstMenu = 0;
                }

            }
            catch (Exception ex)
            { }

            return EstMenu;
        }

        private void CargaFormax(string strPrograma, string NombreMje, TabControl tabcontrolMnu, string strMid)
        {
            int _intCierraForma = 0;
            try
            {
                //if (Application.OpenForms.Count > 3)
                //{
                //    return;
                //}
                Form Formulario = default(Form);
                Type tipoObjeto = null;

                #region Creas tabla Parametros 
                DataTable dtbDatos = new DataTable("Parametros");
                dtbDatos.Columns.Add("Usuario");
                dtbDatos.Columns.Add("NivelSeguridad");
                dtbDatos.Columns.Add("NombreMensaje");
                dtbDatos.Columns.Add("Conexion");
                dtbDatos.Columns.Add("Aplicacion");
                dtbDatos.Columns.Add("ConexionFin");
                dtbDatos.Columns.Add("UsuarioAdmin");
                dtbDatos.Columns.Add("UsuarioSistema");
                dtbDatos.Columns.Add("PLANTEL");
                dtbDatos.Columns.Add("IdMenu");
                #endregion

                #region Para Almacenar en la tabla parametros a mostrar
                DataRow dtrError = dtbDatos.NewRow();
                dtrError["Usuario"] = _strUsuario;
                dtrError["NivelSeguridad"] = intNivel.ToString();
                dtrError["NombreMensaje"] = NombreMje;
                dtrError["Conexion"] = strConexion;
                dtrError["Aplicacion"] = _intAplicacion;
                dtrError["ConexionFin"] = _strConexion;
                dtrError["UsuarioAdmin"] = _bAdmin;
                dtrError["UsuarioSistema"] = _vchUsuarioNombre;
                dtrError["PLANTEL"] = IdPlantelUsuario;
                dtrError["IdMenu"] = strMid;

                dtbDatos.Rows.Add(dtrError);
                DataSet DsParam = new DataSet();
                DsParam.Tables.Add(dtbDatos);
                #endregion Para Almacenar en la tabla a mostrar

                System.Reflection.Assembly assb = System.Reflection.Assembly.GetExecutingAssembly();
                tipoObjeto = assb.GetType(strPrograma);


                //Type tipo = default(Type);
                System.Reflection.Assembly Ensamblado = System.Reflection.Assembly.GetEntryAssembly();
                Type tipo = Ensamblado.GetType(Ensamblado.GetName().Name + "." + strPrograma);

                //string wSTproyecto = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                //string wSTformulario = wSTproyecto + '.' + strPrograma;

                //if (wSTformulario.Contains("Report"))
                if (tipo == null)
                {
                    MessageBox.Show("No se encontró el formulario", "Error de ubicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //object objeto = Activator.CreateInstance(Type.GetType(wSTformulario));
                    //Formulario = (Form)objeto;
                }
                else
                {

                    object objeto = Activator.CreateInstance(tipo, DsParam);
                    //object objeto = Activator.CreateInstance(Type.GetType(wSTformulario), DsParam);
                    Formulario = (Form)objeto;

                    BitacoraAccesos(int.Parse(_strUsuario), int.Parse(strMid), _intAplicacion);
                }

                #region Crea Tabpage                                                
                string title = "TabPage" + (tabcontrolMnu.TabCount + 1).ToString();
                TabPage myTabPage = new TabPage(title);
                myTabPage.Text = NombreMje;
                tabcontrolMnu.DoubleClick += new EventHandler((sender1, e1) => TabcontrolMnu_DoubleClick(sender1, e1, tabcontrolMnu));
                #endregion Crea Tabpage

                #region Crea Panel
                Panel pnl = new Panel();
                pnl.Dock = DockStyle.Fill;

                if (pnl.Controls.Count > 0)
                    pnl.Controls.RemoveAt(0);

                _intCierraForma = 1;
                Formulario.TopLevel = false;
                Formulario.FormBorderStyle = FormBorderStyle.None;
                Formulario.Dock = DockStyle.Fill;
                Formulario.AutoScroll = true;
                #endregion Crea Panel

                #region Asigna Formulario al panel
                pnl.Controls.Add(Formulario);
                pnl.Tag = Formulario;
                myTabPage.Controls.Add(pnl);
                tabcontrolMnu.TabPages.Add(myTabPage);
                Formulario.Show();
                tabcontrolMnu.SelectedTab = myTabPage;
                #endregion Asigna Formulario al panel
            }
            catch (Exception ex)
            {
                MessageBox.Show("Formulario no encontrado \n\n" + ex.Message);
                _intCierraForma = 0;
            }
        }

        private void TabcontrolMnu_DoubleClick(object sender, EventArgs e, TabControl tabcontrolMnu)
        {
            TabPage pa = tabcontrolMnu.SelectedTab;
            if (!pa.Text.Equals("INICIO") && !pa.Text.Equals("MENU"))
            {
                //Para cerra la forma abierta
                foreach (Control ss in pa.Controls)
                {
                    if (ss.GetType() == typeof(Panel))
                    {
                        foreach (Control ss1 in ss.Controls)
                        {
                            if (ss1.GetType().BaseType == typeof(Form))
                            {
                                ((Form)ss1).Close();
                            }
                        }
                    }
                }
                tabcontrolMnu.TabPages.Remove(pa);
            }
        }
        private void BitacoraAccesos(int Usuario, int Menukey, int app)
        {
            try
            {
                intIdUsuario = Usuario;
                intMenuKey = Menukey;
                intAplicacion = app;
                if (AltaUsoMenus())
                {
                    //Inserto con Exito
                }

            }
            catch (Exception ex) { }
        }
        #endregion FORMA MENU

        #region FORMA MENU BOTONES
        public void CargaMenusBotones(string IdUsuario, int _intIdApp, Panel PnlPanelPadre, Panel PnlHijo, Label lblMnuHijo, TabControl tabcontrolMnu)
        {
            int Lx = 20; //19
            int Ly = 12; //53
            int Lpaso = 0;
            string NombreMenu;

            DataSet dtMenuItems = new DataSet();
            MenuItem mnuMenuItem = new MenuItem();
            _strUsuario = IdUsuario;
            _strRutaImagen = "";
            _intIDAplcacion = _intIdApp;
            _strUsuarioMenu = IdUsuario;

            try
            {
                strUsuario = IdUsuario;
                strTipo = "0"; //0 = Escritorio y 1= WEB
                intArmaMenus = 0;
                intAplicacion = _intIDAplcacion;
                dtMenuItems = dsCargaMenu();

                foreach (DataRow drMenuItem in dtMenuItems.Tables[0].Rows)
                {
                    //'esta condicion indica q son elementos padre.                
                    if (drMenuItem["PK_Menu"].Equals(drMenuItem["idpadre"]))
                    {
                        if (Lpaso != 0)
                        {
                            Lpaso = 1;
                        }
                        else
                        {
                            Ly = Ly + 53;
                        }

                        NombreMenu = drMenuItem["NombreProceso"].ToString();
                        Button miBoton = new Button();
                        miBoton.Name = drMenuItem["PK_Menu"].ToString();
                        miBoton.Text = drMenuItem["NombreProceso"].ToString();
                        miBoton.TextImageRelation = TextImageRelation.ImageAboveText;
                        _strRutaImagen = drMenuItem["Ruta"].ToString();
                        //_strRutaImagen = drMenuItem["Ruta"].ToString().Replace(@"Resources\", "");
                        //_strRutaImagen = _strRutaImagen.Replace(".png", "");


                        //Agrega imagen a cada Menu
                        //---------------------------                                                
                        try
                        {
                            if (_strRutaImagen != "")
                            {
                                string fullimagepath = Path.Combine(Application.StartupPath, _strRutaImagen);
                                miBoton.Image = Image.FromFile(fullimagepath);
                            }
                        }
                        catch (Exception e) { }

                        #region Diseño de boton  
                        _intKeyAnt = 0;
                        //miBoton.Click += new EventHandler(MiBoton_Click);
                        miBoton.Click += new EventHandler((sender1, e1) => MiBoton_Click(sender1, e1, PnlHijo, lblMnuHijo, tabcontrolMnu));
                        miBoton.MouseLeave += new EventHandler(MiBoton_MouseLeave);
                        miBoton.MouseMove += new MouseEventHandler(MiBoton_MouseMove);
                        if (NombreMenu.Length > 10)
                        {
                            miBoton.TextAlign = ContentAlignment.MiddleLeft;
                        }
                        else
                        {
                            miBoton.TextAlign = ContentAlignment.MiddleLeft;
                        }
                        miBoton.ImageAlign = ContentAlignment.MiddleRight;
                        miBoton.FlatStyle = FlatStyle.Flat;


                        miBoton.Width = 203; //114
                        miBoton.Height = 42; //35
                        miBoton.Location = new Point(Lx, Ly);
                        miBoton.Font = tFont;
                        #endregion Diseño de boton 

                        PnlPanelPadre.Controls.Add(miBoton);
                    }

                }
            }
            catch (Exception ex) { }
        }

        void MiBoton_MouseMove(object sender, MouseEventArgs e)
        {
            Button ybtn = sender as Button;
            ybtn.BackColor = Color.FromArgb(0, 121, 192);
            ybtn.ForeColor = Color.White;
        }

        void MiBoton_MouseLeave(object sender, EventArgs e)
        {
            Button xbtn = sender as Button;
            xbtn.BackColor = Color.Transparent;
            xbtn.ForeColor = Color.Black;
        }

        void MiBoton_Click(object sender, EventArgs e, Panel pnlHijo, Label lblMnuHijo, TabControl tabcontrolMnu)
        {
            int hj = 0;
            string KeyMenu = "";
            int intCargaMenu;
            int Lxh = 24;
            int Lyh = 25;
            int Lpasoh = 0;
            int intCuentaColumna = 0;
            string NombreMenu;
            DataSet dtMenuBtnH = new DataSet();
            MenuItem mnuMenuItem = new MenuItem();
            _strRutaImagen = "";

            //Limpiar PANEL
            LimpiaPanel(pnlHijo);

            if (_intKeyAnt == 0)
            {
                Button btn = sender as Button;
                KeyMenu = btn.Text;
                KeyMenuAnterior = KeyMenu;
            }
            else
            {
                //Button btn = sender as Button;
                KeyMenu = KeyMenuAnterior;
                _intKeyAnt = 0;
            }

            pnlHijo.Visible = true;

            lblMnuHijo.Visible = true;
            lblMnuHijo.Text = "MENU/" + KeyMenu;
            lblMnuHijo.BringToFront();

            intCargaMenu = ObtieneNombreHijo(KeyMenu);
            hj = VerificaSitieneHijos(intCargaMenu.ToString());

            if (hj > 0)
            {
                strUsuario = _strUsuarioMenu;
                strTipo = "0"; //0 = Escritorio y 1= WEB
                IDMenu = intCargaMenu;
                intAplicacion = _intIDAplcacion;
                dtMenuBtnH = dsCargaMenuHijos();

                foreach (DataRow drMenuItem in dtMenuBtnH.Tables[0].Rows)
                {
                    //'esta condicion indica q son elementos padre.   
                    if (drMenuItem["PK_Menu"].ToString() != drMenuItem["idpadre"].ToString())
                    {
                        intCuentaColumna++;

                        //Para cambio de columna
                        if (intCuentaColumna == 9)
                        {
                            intCuentaColumna = 0;
                            Lxh = Lxh + 223;
                            Lyh = 25;
                            intCuentaColumna++;
                        }

                        //Para la separacion de los botones Vertical
                        if (Lpasoh != 0)
                        {
                            Lpasoh = 1;
                        }
                        else
                        {
                            Lyh = Lyh + 58;
                        }

                        NombreMenu = drMenuItem["NombreProceso"].ToString();

                        #region CREACION DE BOTONES
                        Button miBoton = new Button();
                        miBoton.Name = drMenuItem["PK_Menu"].ToString();
                        miBoton.Text = drMenuItem["NombreProceso"].ToString();
                        miBoton.TextImageRelation = TextImageRelation.ImageAboveText;
                        //_strRutaImagen = drMenuItem["Ruta"].ToString().Replace(@"Resources\", "");
                        //_strRutaImagen = _strRutaImagen.Replace(".png", "");
                        _strRutaImagen = drMenuItem["Ruta"].ToString();

                        #region Diseño de boton                                  
                        //miBoton.Click += new EventHandler(MiBoton_Click1);                        
                        miBoton.Click += new EventHandler((sender1, e1) => MiBoton_Click1(sender1, e1, pnlHijo, lblMnuHijo, tabcontrolMnu));
                        miBoton.MouseLeave += new EventHandler(MiBoton_MouseLeave);
                        miBoton.MouseMove += new MouseEventHandler(MiBoton_MouseMove);
                        if (NombreMenu.Length > 11)
                        {
                            miBoton.TextAlign = ContentAlignment.MiddleLeft;
                        }
                        else
                        {
                            miBoton.TextAlign = ContentAlignment.MiddleLeft;
                        }
                        miBoton.ImageAlign = ContentAlignment.MiddleRight;
                        miBoton.FlatStyle = FlatStyle.Flat;

                        miBoton.Width = 203;
                        miBoton.Height = 42;
                        miBoton.Location = new Point(Lxh, Lyh);
                        miBoton.Font = tFont;
                        #endregion Diseño de boton                                  
                        #endregion CREACION DE BOTONES

                        #region Asigna Imagen
                        try
                        {
                            if (_strRutaImagen != "")
                            {
                                string fullimagepath = Path.Combine(Application.StartupPath, _strRutaImagen);
                                miBoton.Image = Image.FromFile(fullimagepath);
                            }
                        }
                        catch (Exception ex) { }
                        #endregion Asigna Imagen


                        pnlHijo.Controls.Add(miBoton);
                    }
                }
            }
        }

        private void MiBoton_Click1(object sender, EventArgs e, Panel pnlHijo, Label lblMnuHijo, TabControl tabcontrolMnu)
        {
            int hj = 0;
            string KeyMenu = "";
            int intCargaMenu;
            int Lxh = 24;
            int Lyh = 25;
            int Lpasoh = 0;
            int intCuentaColumna = 0;
            string NombreMenu;
            DataSet dtMenuBtnH = new DataSet();
            MenuItem mnuMenuItem = new MenuItem();
            _strRutaImagen = "";

            Button btn = sender as Button;
            KeyMenu = btn.Text;

            pnlHijo.Visible = true;

            intCargaMenu = ObtieneNombreHijo(KeyMenu);
            hj = VerificaSitieneHijos(intCargaMenu.ToString());

            if (hj > 0)
            {
                //Limpiar PANEL
                LimpiaPanel(pnlHijo);

                #region BOTON REGRESAR            
                PictureBox pcRegrsar = new PictureBox();
                pcRegrsar.Name = "pboxRegresar";
                #region Asigna Imagen
                _strRutaImagen = @"Resources\left_circular-26.png";
                try
                {
                    if (_strRutaImagen != "")
                    {
                        string fullimagepath = Path.Combine(Application.StartupPath, _strRutaImagen);
                        pcRegrsar.Image = Image.FromFile(fullimagepath);
                    }
                }
                catch (Exception ex) { }

                pcRegrsar.Location = new Point(3, 3);
                pcRegrsar.SizeMode = PictureBoxSizeMode.AutoSize;
                //pcRegrsar.Click += new EventHandler(PcRegrsar_Click);
                pcRegrsar.Click += new EventHandler((sender1, e1) => PcRegrsar_Click(sender1, e1, pnlHijo, lblMnuHijo, tabcontrolMnu));
                pnlHijo.Controls.Add(pcRegrsar);
                #endregion Asigna Imagen                        
                #endregion BOTON REGRESAR

                lblMnuHijo.Visible = true;
                lblMnuHijo.Text = lblMnuHijo.Text + "/" + KeyMenu;
                lblMnuHijo.BringToFront();

                strUsuario = _strUsuarioMenu;
                strTipo = "0"; //0 = Escritorio y 1= WEB
                IDMenu = intCargaMenu;
                intAplicacion = _intIDAplcacion;
                dtMenuBtnH = dsCargaMenuHijos();

                foreach (DataRow drMenuItem in dtMenuBtnH.Tables[0].Rows)
                {
                    //'esta condicion indica q son elementos padre.   
                    if (drMenuItem["PK_Menu"].ToString() != drMenuItem["idpadre"].ToString())
                    {
                        intCuentaColumna++;

                        //Para cambio de columna
                        if (intCuentaColumna == 9)
                        {
                            intCuentaColumna = 0;
                            Lxh = Lxh + 223;
                            Lyh = 25;
                            intCuentaColumna++;
                        }

                        //Para la separacion de los botones Vertical
                        if (Lpasoh != 0)
                        {
                            Lpasoh = 1;
                        }
                        else
                        {
                            Lyh = Lyh + 58;
                        }

                        NombreMenu = drMenuItem["NombreProceso"].ToString();

                        #region CREACION DE BOTONES
                        Button miBoton1 = new Button();
                        miBoton1.Name = drMenuItem["PK_Menu"].ToString();
                        miBoton1.Text = drMenuItem["NombreProceso"].ToString();
                        miBoton1.TextImageRelation = TextImageRelation.ImageAboveText;
                        //_strRutaImagen = drMenuItem["Ruta"].ToString().Replace(@"Resources\", "");
                        //_strRutaImagen = _strRutaImagen.Replace(".png", "");
                        _strRutaImagen = drMenuItem["Ruta"].ToString();

                        #region Asigna Imagen
                        try
                        {
                            if (_strRutaImagen != "")
                            {
                                string fullimagepath = Path.Combine(Application.StartupPath, _strRutaImagen);
                                miBoton1.Image = Image.FromFile(fullimagepath);
                            }
                        }
                        catch (Exception ex) { }
                        #endregion Asigna Imagen

                        #region Diseño de boton   
                        //miBoton1.Click += new EventHandler(MiBoton1_Click);
                        miBoton1.Click += new EventHandler((sender1, e1) => MiBoton1_Click(sender1, e1, tabcontrolMnu));
                        miBoton1.MouseLeave += new EventHandler(MiBoton_MouseLeave);
                        miBoton1.MouseMove += new MouseEventHandler(MiBoton_MouseMove);

                        if (NombreMenu.Length > 11)
                        {
                            miBoton1.TextAlign = ContentAlignment.MiddleLeft;
                        }
                        else
                        {
                            miBoton1.TextAlign = ContentAlignment.MiddleLeft;
                        }
                        miBoton1.ImageAlign = ContentAlignment.MiddleRight;
                        miBoton1.FlatStyle = FlatStyle.Flat;

                        miBoton1.Width = 203;
                        miBoton1.Height = 42;
                        miBoton1.Location = new Point(Lxh, Lyh);
                        miBoton1.Font = tFont;
                        #endregion Diseño de boton                                  
                        #endregion CREACION DE BOTONES

                        pnlHijo.Controls.Add(miBoton1);
                    }

                }

            }
            else
            {
                MiBoton1_Click(sender, e, tabcontrolMnu);
            }
        }

        private void MiBoton1_Click(object sender, EventArgs e, TabControl tabcontrolMnu)
        {
            string KeyMenu;
            Button btn = sender as Button;
            KeyMenu = btn.Name;

            ObtieneNombreMenu(KeyMenu, tabcontrolMnu);
        }

        private void PcRegrsar_Click(object sender, EventArgs e, Panel pnlHijo, Label lblMnuHijo, TabControl tabcontrolMnu)
        {
            _intKeyAnt = 1;
            MiBoton_Click(sender, e, pnlHijo, lblMnuHijo, tabcontrolMnu);
        }

        private void LimpiaPanel(Panel pnl)
        {
            //Limpiar PANEL
            if (pnl.Controls.Count > 0)
            {

                for (int x = 0; x <= pnl.Controls.Count - 1; x++)
                {
                    Control c = pnl.Controls[x];
                    if (c.GetType() != typeof(Label))
                    {
                        pnl.Controls.Remove(c);
                        x--;
                    }
                }
            }
        }
        private int ObtieneNombreHijo(string KeyMenu)
        {
            string strItem;
            string strPrograma = "";
            string strMenuId = "";
            DataSet DsMnus = new DataSet();

            try
            {
                strNombreMenu = KeyMenu;
                intAplicacion = _intIDAplcacion;
                DsMnus = dsSeleccionaMenusNombre();

                if (DsMnus.Tables[0].Rows.Count > 0)
                {
                    NombreMensaje = DsMnus.Tables[0].Rows[0].ItemArray[1].ToString();
                    strItem = DsMnus.Tables[0].Rows[0].ItemArray[2].ToString();
                    strPrograma = DsMnus.Tables[0].Rows[0].ItemArray[9].ToString();
                    strMenuId = DsMnus.Tables[0].Rows[0].ItemArray[10].ToString();
                }
                else
                {
                    MessageBox.Show("NO existen Menus");
                }

            }
            catch (Exception ex)
            {
                strMenuId = "0";
                MessageBox.Show("Procedimiento fallo");
            }


            return int.Parse(strMenuId);
        }

        private int VerificaSitieneHijos(string ID)
        {
            int intReg = 0;

            IDMenu = int.Parse(ID);
            try
            {
                intAplicacion = _intIDAplcacion;
                DataSet dsVl = dsValidaMenusHijos();
           
                if (dsVl.Tables[0].Rows.Count > 0)
                {
                    intReg = int.Parse(dsVl.Tables[0].Rows[0].ItemArray[0].ToString());
                }
                else
                    intReg = 0;
            }
            catch(Exception ex)
            {
                intReg = 0;
            }

            return intReg;
        }
        #endregion FORMA MENU BOTONES

        #region DATASET 
        public DataSet dsObtenerConsultaAccesosUsuarios()
        {
            try
            {
                _wsSegElyon.Url = _strUrlSeguridad;
                return _wsSegElyon.dsObtener(this.XML, "CARGAR CONSULTA ACCESOS USUARIO");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsObtenerValidacionesUsuario()
        {
            try
            {
                _wsSegElyon.Url = _strUrlSeguridad;
                return _wsSegElyon.dsObtener(this.XML, "CARGAR VALIDACIONES USUARIO");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet CargarAplicaciones()
        {
            try
            {
                _wsSegElyon.Url = _strUrlSeguridad;
                return _wsSegElyon.dsObtener(this.XML, "CARGAR APLICACIONES");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsObtenerPkFormas()
        {
            try
            {
                _wsSegElyon.Url = _strUrlSeguridad;
                return _wsSegElyon.dsObtener(this.XML, "CARGAR PK FORMA");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsCargaValidacionBotones()
        {
            try
            {
                _wsSegElyon.Url = _strUrlSeguridad;
                return _wsSegElyon.dsObtener(this.XML, "CARGAR VALIDACION BOTONES");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsCargaPlantelesSeleccionConcepto()
        {
            try
            {
                _wsSegElyon.Url = _strUrlSeguridad;
                return _wsSegElyon.dsObtener(this.XML, "CARGAR PLANTELES CONCEPTOS");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet CargarNotificacionesAdministrador()
        {
            try
            {
                _wsSegElyon.Url = _strUrlSeguridad;
                return _wsSegElyon.dsObtener(this.XML, "CARGAR NOTIFICACIONES ADMIN");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet CargarUsuariosLogeados()
        {
            try
            {
                _wsSegElyon.Url = _strUrlSeguridad;
                return _wsSegElyon.dsObtener(this.XML, "CARGAR USUARIOS LOGEADOS");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet CargarNotificaciones()
        {
            try
            {
                _wsSegElyon.Url = _strUrlSeguridad;
                return _wsSegElyon.dsObtener(this.XML, "CARGAR NOTIFICACIONES");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet BuscaNotificaciones()
        {
            try
            {
                _wsSegElyon.Url = _strUrlSeguridad;
                return _wsSegElyon.dsObtener(this.XML, "BUSCA NOTIFICACIONES");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsCargaPlantelesSeleccion()
        {
            try
            {
                _wsSegElyon.Url = _strUrlSeguridad;
                return _wsSegElyon.dsObtener(this.XML, "CARGA PLANTELES SELECCION");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet ObtenerFolio()
        {
            try
            {
                _wsSegElyon.Url = _strUrlSeguridad;
                return _wsSegElyon.dsObtener(this.XML, "OBTENER FOLIO");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
       
        public DataSet ObtenerParametros()
        {
            try
            {
                _wsSegElyon.Url = _strUrlSeguridad;
                return _wsSegElyon.dsObtener(this.XML, "OBTENER PARAMETROS");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsSelecionarParametro()
        {
            try
            {
                _wsSegElyon.Url = _strUrlSeguridad;
                return _wsSegElyon.dsObtener(this.XML, "SELECCIONAR PARAMETROS");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

      
        public DataSet ArmaTablaInformacion(DataSet ds, string strCon)
        {
            #region Variables
            string _strNombreCompleto = "";
            string _strCorreo = "";
            string _strContraseña = "";
            string _strActivo = "";
            string _strVerifcado = "";
            string _strUsuarioSistema = "";
            string _strUsuario = "";
            string _strFechaNacimiento = "";
            string _strNOMINA = "";
            string _strIDUSUARIO = "";
            string _strCLAVEDEPTO = "";
            string _strNOMBREDEPTO = "";
            string _strFECHAINICIO = "";
            string _strIDAPP = "";
            string _strPLANTEL = "";
            string _strADMIN = "";
            string _strIMAGEN = "";
            string _strPuesto = "";
            string _strAcceso = "0";
            string _strConexion = "";
            int _acc = 0;
            #endregion Variables

            _strConexion = strCon;

            #region Validar Acceso
            DataTable dtbDatos1 = new DataTable("ACCESO");
            if (ds != null && ds.Tables.Count == 1)
            {
                _strAcceso = "Usuario o Contraseña Correcta";
                _acc = 0;
            }
            else
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    string error = ds.Tables[1].Rows[0][0].ToString();
                    if (error == "Usuario o Contraseña incorrecta")
                    {
                        _strAcceso = error;

                        dtbDatos1.Columns.Add("Acceso");
                        DataRow dtrError1 = dtbDatos1.NewRow();
                        dtrError1["Acceso"] = _strAcceso;
                        dtbDatos1.Rows.Add(dtrError1);
                        _acc = 1;
                    }
                }
            }
            #endregion Validar Acceso

            #region Creas tabla Final Informacion 
            DataTable dtbDatos = new DataTable("INFO");
            dtbDatos.Columns.Add("NombreCompleto");
            dtbDatos.Columns.Add("Correo");
            dtbDatos.Columns.Add("Contraseña");
            dtbDatos.Columns.Add("Activo");
            dtbDatos.Columns.Add("Verifcado");
            dtbDatos.Columns.Add("Usuario Sistema");
            dtbDatos.Columns.Add("Usuario");
            dtbDatos.Columns.Add("FechaNacimiento");
            dtbDatos.Columns.Add("NOMINA");
            dtbDatos.Columns.Add("IDUSUARIO");
            dtbDatos.Columns.Add("CLAVEDEPTO");
            dtbDatos.Columns.Add("NOMBREDEPTO");
            dtbDatos.Columns.Add("FECHAINICIO");
            dtbDatos.Columns.Add("IDAPP");
            dtbDatos.Columns.Add("PLANTEL");
            dtbDatos.Columns.Add("ADMIN");
            dtbDatos.Columns.Add("IMAGEN");
            dtbDatos.Columns.Add("PUESTO");
            dtbDatos.Columns.Add("CONEXION");

            #endregion Creas tabla Final Informacion

            #region Obtiene Informacion cuenta
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    _strNombreCompleto = ds.Tables[0].Rows[0]["Apellido Paterno"].ToString().Trim() + " " + ds.Tables[0].Rows[0]["Apellido Materno"].ToString().Trim() + " " + ds.Tables[0].Rows[0]["Nombre"].ToString().Trim();
                    _strCorreo = ds.Tables[0].Rows[0]["Correo"].ToString();
                    _strContraseña = ds.Tables[0].Rows[0]["Contraseña"].ToString();
                    _strActivo = ds.Tables[0].Rows[0]["Activo"].ToString();
                    _strVerifcado = ds.Tables[0].Rows[0]["Verifcado"].ToString();
                    _strUsuarioSistema = ds.Tables[0].Rows[0]["Usuario Sistema"].ToString();
                    _strUsuario = ds.Tables[0].Rows[0]["Usuario"].ToString();
                    _strNOMINA = ds.Tables[0].Rows[0]["NOMINA"].ToString();
                    _strIDUSUARIO = ds.Tables[0].Rows[0]["IDUSUARIO"].ToString();
                    _strFECHAINICIO = ds.Tables[0].Rows[0]["FECHAINICIO"].ToString();
                    _strIDAPP = ds.Tables[0].Rows[0]["IDAPP"].ToString();
                    _strPLANTEL = ds.Tables[0].Rows[0]["PLANTEL"].ToString();
                    _strADMIN = ds.Tables[0].Rows[0]["ADMIN"].ToString();
                    _strIMAGEN = ds.Tables[0].Rows[0]["IMAGEN"].ToString();
                    _strFechaNacimiento = ds.Tables[0].Rows[0]["FechaNacimiento"].ToString();
                    _strCLAVEDEPTO = ds.Tables[0].Rows[0]["CLAVEDEPTO"].ToString();
                    _strNOMBREDEPTO = ds.Tables[0].Rows[0]["NOMBREDEPTO"].ToString();
                    _strPuesto = ds.Tables[0].Rows[0]["PUESTO"].ToString();
                }
                else
                {
                    _strNOMINA = "0";
                    _strCLAVEDEPTO = " ";
                    _strNOMBREDEPTO = "Nombre no encontrado";
                }
            }
            catch (Exception ex)
            {
                _strNOMINA = "0";
                _strCLAVEDEPTO = " ";
                _strNOMBREDEPTO = "Nombre no encontrado";
            }
            #endregion Obtiene Informacion cuenta

            #region Para Almacenar en la tabla INFO a mostrar
            DataRow dtrError = dtbDatos.NewRow();
            dtrError["NombreCompleto"] = _strNombreCompleto;
            dtrError["Correo"] = _strCorreo;
            dtrError["Contraseña"] = _strContraseña;
            dtrError["Activo"] = _strActivo;
            dtrError["Verifcado"] = _strVerifcado;
            dtrError["Usuario Sistema"] = _strUsuarioSistema;
            dtrError["Usuario"] = _strUsuario;
            dtrError["FechaNacimiento"] = _strFechaNacimiento;
            dtrError["NOMINA"] = _strNOMINA;
            dtrError["IDUSUARIO"] = _strIDUSUARIO;
            dtrError["CLAVEDEPTO"] = _strCLAVEDEPTO;
            dtrError["NOMBREDEPTO"] = _strNOMBREDEPTO;
            dtrError["FECHAINICIO"] = _strFECHAINICIO;
            dtrError["IDAPP"] = _strIDAPP;
            dtrError["PLANTEL"] = _strPLANTEL;
            dtrError["ADMIN"] = _strADMIN;
            dtrError["IMAGEN"] = _strIMAGEN;
            dtrError["PUESTO"] = _strPuesto;
            dtrError["CONEXION"] = _strConexion;
            dtbDatos.Rows.Add(dtrError);

            DataSet DsParam = new DataSet();
            DsParam.Tables.Add(dtbDatos);
            if (_acc == 1)
            {
                DsParam.Tables.Add(dtbDatos1);
            }
            #endregion Para Almacenar en la tabla a mostrar

            return DsParam;
        }
        public DataSet dsInfoUsuarios()
        {
            try
            {
                _wsSegElyon.Url = _strUrlSeguridad;
                return _wsSegElyon.dsObtener(this.XML, "INFO");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet dsCargaMenu()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "MENU");

        }
        public DataSet dsSeleccionaMenusNombre()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "NOMBREMENU");

        }
        public DataSet dsCargaPermisosMenus()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "PERMISO MENU");

        }
        public DataSet dsVerificaEstadoMenu()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "ESTADO DEL MENU");

        }
        public DataSet dsValidaMenusHijos()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "VALIDA HIJOS MENU");
        }
        public DataSet dsCargaMenuHijos()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "MENU HIJOS");
        }
        public DataSet dsValidaEmail()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "VALIDA EMAIL");
        }
        public DataSet dsCargaTipoProceso()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "CARGA TIPO PROCESO");
        }
        public DataSet dsObtieneDatosTipoProceso()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "OBTIENE DATOS TIPO PROCESO");
        }
        public DataSet dsObtieneClaveTipoProceso()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "CLAVE TIPO PROCESO");
        }
        public DataSet dsCargaNivelSeguridad()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "CARGA NIVEL SEGURIDAD");
        }
        public DataSet dsObtieneNivelSeguridad()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "OBTIENE NIVEL SEGURIDAD");
        }
        public DataSet dsObtieneClaveNivelSeguridad()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "OBTIENE CLAVE NIVEL SEGURIDAD");
        }
        public DataSet dsCargaTipomenus()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "CARGA TIPO MENU");
        }
        public DataSet dsSeleccionaProcesos()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "SELECCIONA PROCESOS");
        }
        public DataSet dsSeleccionaTipoprocesos()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "SELECCIONA TIPO PROCESOS");
        }
        public DataSet dsSeleccionamenus()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "SELECCIONA MENUS");
        }
        public DataSet dsCargaAvisos()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "CARGA AVISOS");
        }
        public DataSet dsCargaTotalAvisos()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "CARGA TOTAL DE AVISOS");
        }
        public DataSet dsTotalAvisos()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "TOTAL DE AVISOS ACTIVOS MAS 1");
        }
        public DataSet dsObtieneAvisosKeys()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "OBTIENE AVISOS POR KEY");
        }
        public DataSet dsObtienePlanteles()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "OBTIENE PLANTELES");
        }
        public DataSet dsObtienePlantelesSagu()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "OBTIENE PLANTELES SAGU");
        }
        public DataSet dsCargaPadres()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "OBTIENE MENUS PADRES");
        }
        public DataSet dsObtieneUsuario()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "OBTIENE USUARIO");
        }
        public DataSet dsBuscarPersonas()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "BUSCAR PERSONA");
        }
        public DataSet dsCargaMenuAccesos()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "CARGA MENU ACCESOS");
        }
        public DataSet dsNombreProceso()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "OBTIENE NOMBRE PROCESOS");
        }
        public DataSet dsCargaTipoConcexiones()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "CARGAR CONEXIONES");
        }
        public DataSet dsobtieneConexion()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "OBTIENE CONEXIONES");
        }
        public DataSet obtenerReporteNivelEstudio()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "REPORTE NIVELES DE ESTUDIO");
        }
        public DataSet dsobtieneMenusUsados()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "OBTIENE MENUS USADOS POR USUARIOS");
        }
        public DataSet dsoObtieneBotonesMenu()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "OBTIENE MENUS BOTONES");
        }
        public DataSet dsCargaBotonesUsuarioMenu()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.dsObtener(this.XML, "OBTIENE MENUS BOTONES USUARIOS");
        }
        #endregion DATASET

        #region BOOL 
        public bool EliminaValidacionUsuario()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "ELIMNA VALIDACIONES USUARIO");
        }
        public bool AltaValidacionUsuario()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "ALTA VALIDACIONES USUARIO");
        }
        public bool AltaUsoMenus()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "ALTA MENUS USADOS POR USUARIOS");
        }
        public bool dsVerificaAcceso()
        {
            bool Acceso = false;
            _wsSegElyon.Url = _strUrlSeguridad;
            if (_wsSegElyon.bObtener("AUTENTICA", strUsuario, strContraseña))
            {
                Acceso = true;
                //DataSet dsinf = dsInfoUsuarios();
                //return ArmaTablaInformacion(dsinf);
            }
            else
            {
                //Obtener datos de contraseña
                //DataSet dsinf = dsInfoUsuarios();
                //-------------------------------------
                DataSet dsp = _wsSegElyon.dsObtener(this.XML, "ACCESO");
                if (bool.Parse(dsp.Tables[0].Rows[0][0].ToString()) == true)
                {
                    Acceso = true;
                }
                //return ArmaTablaInformacion(dsp);
            }
            return Acceso;
        }
        public bool ValidaUsuariosLogeados()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "ALTA USUARIOS LOGEADO");
        }
        public bool BorrarNotificaciones()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "BORRAR NOTIFICACIONES");
        }
        public bool MarcarNotificaciones()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "MARCAR NOTIFICACIONES");
        }
        public bool AltaNotificaciones()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "ALTA NOTIFICACIONES");
        }
        public bool bAltaImagen()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "ALTA IMAGEN USUARIO");
        }
        public bool AltaUsuario()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "ALTA USUARIO");
        }
        public bool ModificaContraseña()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "MODIFICA CONTRASEÑA");
        }
        public bool AlmacenaImagenSerializada()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "ALMACENA AVISOS");
        }
        public bool EliminaFotoUsuarios()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "ELIMINA FOTO USUARIO");
        }
        public bool ModificaAppsUsuarios()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "MODIFICA APLICACIONES USUARIOS");
        }
        public bool ModificaDatosUsuario()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "MODIFICACION USUARIOS");
        }
        public bool AlmacenaMenus()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "ALMACENA MENUS");
        }
        public bool EliminaMenus()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "ELIMINA MENUS");
        }
        public bool AltaBotonesUsuarios()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "ALTA BOTONES USUARIOS");
        }
        public bool EliminaBotonesMenu()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "ELIMINA MENUS BOTONES");
        }
        public bool AltaMenuBotones()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "ALTA MENUS BOTONES");
        }
        public bool AltaMenuUsuarios()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "ALTA MENUS POR USUARIO");
        }
        public bool AltaGrupoMenus()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "ALTA MENUS POR GRUPO");
        }
        public bool EliminaMenuUsuarios()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "ELIMINA MENUS POR USUARIO");
        }
        public bool AlmacenaNivelSeguridad()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "ALMACENA NIVEL SEGURIDAD");
        }
        public bool EliminaNivelSeguridad()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "ELIMINA NIVEL SEGURIDAD");
        }
        public bool AltaAplicaciones()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "ALTA APLICACIONES");
        }
        public bool EliminaAplicacion()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "ELIMINA APLICACIONES");
        }
        public bool EliminaAvisos()
        {
            _wsSegElyon.Url = _strUrlSeguridad;
            return _wsSegElyon.bObtener1(this.XML, "ELIMINA AVISOS");
        }
        /*                       
        public bool dsVerificaAcceso(string User, string Pass)
        {
            bool Acceso = false;
            _wsSegElyon.Url = _strUrlSeguridad;
            if (_wsSegElyon.bObtener("AUTENTICA", User, Pass))
            {
                Acceso = true;
                //DataSet dsinf = dsInfoUsuarios();
                //return ArmaTablaInformacion(dsinf);
            }
            else
            {
                DataSet dsp = _wsSegElyon.dsObtener(this.XML, "ACCESO");
                if (bool.Parse(dsp.Tables[0].Rows[0][0].ToString()) == true)
                {
                    Acceso = true;
                }
                //return ArmaTablaInformacion(dsp);
            }
            return Acceso;
        }
        public bool dsVerificaAcceso(string conexion)
        {
            bool Acceso = false;
            _wsSegElyon.Url = conexion;
            if (_wsSegElyon.bObtener("AUTENTICA", this.strUsuario, this.strContraseña))
            {
                Acceso = true;
                //DataSet dsinf = dsInfoUsuarios();
                //return ArmaTablaInformacion(dsinf);
            }
            else
            {
                DataSet dsp = _wsSegElyon.dsObtener(this.XML, "ACCESO");
                if (bool.Parse(dsp.Tables[0].Rows[0][0].ToString()) == true)
                {
                    Acceso = true;
                }
                //return ArmaTablaInformacion(dsp);
            }
            return Acceso;
        }
   
   
    
   

    public bool dsActualizarConceptoPlantelDetalle()
    {
        _wsSegElyon.Url = _strUrlSeguridad;
        return _wsSegElyon.bObtener1(this.XML, "ALTA CONCEPTOS POR PLANTEL");
    }
   
   
   
    public bool AltaPlantelesUsuarios()
    {
        _wsSegElyon.Url = _strUrlSeguridad;
        return _wsSegElyon.bObtener1(this.XML, "ALTA PLANTEL USUARIOS");
    }
   
   
   
   
   
    public bool AlmacenaTipoProceso()
    {
        _wsSegElyon.Url = _strUrlSeguridad;
        return _wsSegElyon.bObtener1(this.XML, "ALMACENA TIPO PROCESO");
    }
    public bool EliminaTipoProceso()
    {
        _wsSegElyon.Url = _strUrlSeguridad;
        return _wsSegElyon.bObtener1(this.XML, "ELIMINA TIPO PROCESO");
    }
   
  
    public bool AlmacenaParametros()
    {
        _wsSegElyon.Url = _strUrlSeguridad;
        return _wsSegElyon.bObtener1(this.XML, "ALMACENA PARAMETROS");
    }
    public bool EliminaParametros()
    {
        _wsSegElyon.Url = _strUrlSeguridad;
        return _wsSegElyon.bObtener1(this.XML, "ELIMINA PARAMETROS");
    } 
    */
        #endregion BOOL

        #region Funciones VARIAS
        public void AppendText(RichTextBox box, Color color, string text)
        {
            int start = box.TextLength;
            box.AppendText(text);

            int end = box.TextLength;

            // Textbox may transform chars, so (end-start) != text.Length
            box.Select(start, end - start);
            {
                box.SelectionColor = color;
                // could set box.SelectionBackColor, box.SelectionFont too.
            }
            box.SelectionLength = 0; // clear
        }

        public void CerrarSession(int Usuario, int Aplicacion, int estatus)
        {
            //Marca inicio de Session
            try
            {
                this.strUsuario = Usuario.ToString();
                this.intAplicacion = Aplicacion;
                this.intEstatus = estatus;

                this.ValidaUsuariosLogeados();
            }
            catch (Exception ex) { }
        }

        //Desserializa la Imagen
        public Image StringToImage(string imageString)
        {

            if (imageString == null)

                throw new ArgumentNullException("imageString");

            byte[] array = Convert.FromBase64String(imageString);

            System.Drawing.Image image = System.Drawing.Image.FromStream(new MemoryStream(array));

            return image;

        }
        //Metodos para Serializar las Imagenes(
        public string ImageToString(Image imgx)
        {
            try
            {
                MemoryStream ms = new MemoryStream();

                imgx.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                byte[] array = ms.ToArray();

                return Convert.ToBase64String(array);
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public bool BuscaBoton(string IdMenu, int Usuario, int menu)
        {
            bool tot = false;


            strUsuario = Usuario.ToString();
            IDMenu = menu;
            strIdBoton = IdMenu;

            DataSet dsValBtn = dsCargaValidacionBotones();
            if (dsValBtn.Tables[0].Rows.Count > 0)
            {
                tot = bool.Parse(dsValBtn.Tables[0].Rows[0].ItemArray[0].ToString());
            }

            return tot;
        }

        public void ValidarBotones(Control.ControlCollection itemobj, int Usuario, int menu)
        {
            foreach (Control item in itemobj)
            {
                //Valida los botones
                if (item is System.Windows.Forms.Button)
                {
                    if (!BuscaBoton(item.Name, Usuario, menu))
                    {
                        item.Enabled = false;
                    }
                }

                //Valida los botones que estan en el ToolStrip
                if (item is System.Windows.Forms.ToolStrip)
                {
                    foreach (ToolStripItem stpb in ((ToolStrip)item).Items)
                    {
                        if (stpb is ToolStripButton)
                        {
                            if (!BuscaBoton(stpb.Name, Usuario, menu))
                            {
                                stpb.Enabled = false;
                            }
                        }
                    }
                }

                ValidarBotones(item.Controls, Usuario, menu);
            }
        }

        public int RegresaPkMenu(int App, string NombreForma)
        {
            int regresa = 0;
            intAplicacion = App;
            strNombreMenu = NombreForma;
            DataSet dspk = dsObtenerPkFormas();
            if (dspk.Tables[0].Rows.Count > 0)
            {
                regresa = int.Parse(dspk.Tables[0].Rows[0].ItemArray[0].ToString());
            }
            return regresa;
        }
        #endregion Funciones VARIAS
       
        #region Metodos
        //public bool EnviarMail(string User, string Pass, int IDapp)
        //{
        //    bool envio = false;
        //    try
        //    {
        //        this._intIDAplcacion = IDapp;
        //        string strParam = this.strJsonParametrosMail(IDapp).Replace("\"", "'").Replace("[", "").Replace("]", "");
        //        Console.WriteLine(strParam);

        //         Dictionary<string, string> dMailDatos = JsonConvert.DeserializeObject<Dictionary<string, string>>(strParam);


        //        System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
        //        correo.From = new System.Net.Mail.MailAddress("UNIVA" + "<" + dMailDatos["USUARIO_ENVIA"] + ">");
        //        correo.To.Add("sergio.hidalgo@univa.mx");

        //       // MailMessage message = new MailMessage(dMailDatos["USUARIO_ENVIA"], "sergio.hidalgo@univa.mx");

        //       // message.Subject = "Datos De Acceso";                
        //        string strBody = this.Body(User, Pass);
        //        //message.Body = strBody;
        //        //message.IsBodyHtml = true;

        //        correo.Body = strBody;

        //        correo.Subject = "Datos De Acceso";
        //        // DEFINIMOS QUE EL CUERPO DEL CORREO SERA HTML
        //        System.Net.Mime.ContentType mTipo = new System.Net.Mime.ContentType("text/html");
        //        System.Net.Mail.AlternateView mVista = System.Net.Mail.AlternateView.CreateAlternateViewFromString(strBody, mTipo);
        //        correo.AlternateViews.Add(mVista);

        //        correo.Priority = System.Net.Mail.MailPriority.High;
        //        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        //        smtp.UseDefaultCredentials = false;
        //        smtp.Host = dMailDatos["SERVIDOR_SALIDA"];
        //        smtp.Port = int.Parse(dMailDatos["PUERTO"]);
        //        smtp.Credentials = new System.Net.NetworkCredential(dMailDatos["USUARIO_ENVIA"], dMailDatos["CONTRASEÑA"]);

        //        //Pendiente para Office 365
        //        //---------------------------
        //        smtp.EnableSsl = true;
        //        //---------------------------

        //        smtp.Send(correo);
        //      //  smtp.Send(message);
        //        MessageBox.Show("Los datos de acceso han sido enviados al correo " + User.Trim() + "@univa.mx", "Envió de Contraseña");
        //        envio = true;

        //    }
        //    catch (Exception ex)
        //    {
        //        envio = false;
        //        MessageBox.Show("Problemas al Enviar el correo. ERROR: " + ex.Message, "Envió de Correo");

        //    }




        //    return envio;
        //}

    
        private string Body(string Usuario, string Pass)
        {
            string Mensaje = "";
            //Mensaje = "Usuario: " + Usuario + "\n";
            //Mensaje += "Password: " + Pass + "\n";
            Mensaje = "< table width = '800' height = '262' border = '0' cellpadding = '0' cellspacing = '0' >"
                     + "< tr >< td height = '19' > Buen dia,</ td > </ tr >                                                                                     "
                     + "< tr >                                                                                                                                  "
                     + "< td height = '49' valign = 'bottom' > Le informamos que su contraseña ha sido modificada sus nuevo datos de acceso son:</ td >         "
                     + "</ tr >                                                                                                                                 "
                     + "< tr >                                                                                                                                  "
                     + "< td > &nbsp;</ td >                                                                                                                    "
                     + "</ tr >                                                                                                                                 "
                     + "< tr >                                                                                                                                  "
                     + "< td >< b > Usuario:</ b > < ins > Usuario </ ins > </ td >                                                                             "
                     + "</ tr >                                                                                                                                 "
                     + "< tr >                                                                                                                                  "
                     + "< td >< b > Contaseña: </ b >< ins > Pass </ ins ></ td >                                                                               "
                     + "</ tr >                                                                                                                                 "
                     + "< tr >                                                                                                                                  "
                     + "< td > &nbsp;</ td >                                                                                                                    "
                     + "</ tr >                                                                                                                                 "
                     + "< tr >                                                                                                                                  "
                     + "< td width = '401' style = 'border-top: #E46C0A solid 2px; text-align:right; color:#E46C0A' ></ td >                                    "
                     + "</ tr >                                                                                                                                 "
                     + "< tr >                                                                                                                                  "
                     + "< td >                                                                                                                                  "
                     + "< span >< a href = 'http://cedefi.univa.mx/'  >< ins > Cedefi </ ins ></ a >                                                            "
                     + "< a href = 'http://www.univa.mx/' >< ins > Univa </ ins ></ a >                                                                         "
                     + "< a href = 'http://www.univa.mx/sedes/guadalajara/servicios/ayudas-financieras'>< ins > Ayudas Financieras </ ins ></ a >               "
                     + "</ span >                                                                                                                               "
                     + "</ td >                                                                                                                                 "
                     + "</ tr >                                                                                                                                 "
                     + "</ table >";

            return Mensaje;
        }
        public string strJsonParametrosMail(int IDApp)
        {
            this._intIDAplcacion = IDApp;
            try
            {
                _wsSegElyon.Url = _strUrlSeguridad;
                return _wsSegElyon.strJson(this.XML, "CONFIGURACION MAIL");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public string jsonCargaNivelSeguridad()
        {
            try
            {
                _wsSegElyon.Url = _strUrlSeguridad;
                return _wsSegElyon.strJson(this.XML, "CARGA NIVEL SEGURIDAD");
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string jsonMenusUsuario()
        {
            try
            {
                _wsSegElyon.Url = _strUrlSeguridad;
                return _wsSegElyon.strJson(this.XML, "CARGA MENUSUSUARIO");
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string jsonMenusUsuario(string urlws)
        {
            try
            {
                _wsSegElyon.Url = urlws;
                return _wsSegElyon.strJson(this.XML, "CARGA MENUSUSUARIO");
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string strJsonApps()
        {
            try
            {
                _wsSegElyon.Url = _strUrlSeguridad;
                return _wsSegElyon.strJson(this.XML, "APLICACIONES");
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string strJsonCargarApps()
        {
            try
            {
                _wsSegElyon.Url = _strUrlSeguridad;
                return _wsSegElyon.strJson(this.XML, "CARGAR APLICACIONES");
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string strJsonCargaAppsUsuario()
        {
            try
            {
                _wsSegElyon.Url = _strUrlSeguridad;
                return _wsSegElyon.strJson(this.XML, "CARGAR APLICACIONES USUARIO");
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        #endregion Metodos
    }
}
