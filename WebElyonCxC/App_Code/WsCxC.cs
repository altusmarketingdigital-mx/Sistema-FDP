using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.DirectoryServices;


/// <summary>
/// Summary description for WsCxC
/// ///
/// </summary>
[WebService(Namespace = "AppElyonCXC")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WsCxC : System.Web.Services.WebService
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

    public WsCxC()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public DataSet dsObtener(string strXML, string strTipo)
    {
        switch (strTipo.ToUpper())
        {
            case "ACCESO": return this.dsVerificaAcceso(strXML);
            case "INFO": return this.dsInfoUsuario(strXML);
            case "MENU": return this.dsCargaMenu(strXML);
            case "NOMBREMENU": return this.dsSeleccionaMenusNombre(strXML);
            case "PERMISO MENU": return this.dsCargaPermisosMenus(strXML);
            case "ESTADO DEL MENU": return this.dsVerificaEstadoMenu(strXML);
            case "VALIDA HIJOS MENU": return this.dsValidaMenusHijos(strXML);
            case "MENU HIJOS": return this.dsCargaMenuHijos(strXML);
            case "VALIDA EMAIL": return this.dsValidaEmail(strXML);
            case "CARGA TIPO PROCESO": return this.dsCargaTipoProceso(strXML);
            case "OBTIENE DATOS TIPO PROCESO": return this.dsObtieneDatosTipoProceso(strXML);
            case "CLAVE TIPO PROCESO": return this.dsObtieneClaveTipoProceso(strXML);
            case "CARGA NIVEL SEGURIDAD": return this.dsCargaNivelSeguridad(strXML);
            case "OBTIENE NIVEL SEGURIDAD": return this.dsObtieneNivelSeguridad(strXML);
            case "OBTIENE CLAVE NIVEL SEGURIDAD": return this.dsObtieneClaveNivelSeguridad(strXML);
            case "CARGA TIPO MENU": return this.dsCargaTipomenus(strXML);
            case "SELECCIONA PROCESOS": return this.dsSeleccionaProcesos(strXML);
            case "SELECCIONA TIPO PROCESOS": return this.dsSeleccionaTipoprocesos(strXML);
            case "SELECCIONA MENUS": return this.dsSeleccionamenus(strXML);
            case "CARGA AVISOS": return this.dsCargaAvisos(strXML);
            case "CARGA TOTAL DE AVISOS": return this.dsCargaTotalAvisos(strXML);
            case "TOTAL DE AVISOS ACTIVOS MAS 1": return this.dsTotalAvisos(strXML);
            case "OBTIENE AVISOS POR KEY": return this.dsObtieneAvisosKeys(strXML);
            case "OBTIENE PLANTELES": return this.dsObtienePlanteles(strXML);
            case "OBTIENE PLANTELES SAGU": return this.dsObtienePlantelesSagu(strXML);
            case "OBTIENE MENUS PADRES": return this.dsCargaPadres(strXML);
            case "OBTIENE USUARIO": return this.dsObtieneUsuario(strXML);
            case "BUSCAR PERSONA": return this.dsBuscarPersonas(strXML);
            case "CARGA MENU ACCESOS": return this.dsCargaMenuAccesos(strXML);
            case "OBTIENE NOMBRE PROCESOS": return this.dsNombreProceso(strXML);
            case "CARGAR CONEXIONES": return this.dsCargaTipoConcexiones(strXML);
            case "OBTIENE CONEXIONES": return this.dsobtieneConexion(strXML);
            case "OBTENER PARAMETROS": return this.obtenerParametros(strXML);
            case "SELECCIONAR PARAMETROS": return this.dsSelecionarParametro(strXML);
            case "REPORTE NIVELES DE ESTUDIO": return this.obtenerReporteNivelEstudio(strXML);
            case "OBTENER FOLIO": return this.ObtenerFolio(strXML);
            case "CARGA PLANTELES SELECCION": return this.dsCargaPlantelesSeleccion(strXML);
            case "BUSCA NOTIFICACIONES": return this.BuscaNotificaciones(strXML);
            case "CARGAR NOTIFICACIONES": return this.CargarNotificaciones(strXML);
            case "CARGAR USUARIOS LOGEADOS": return this.CargarUsuariosLogeados(strXML);
            case "CARGAR NOTIFICACIONES ADMIN": return this.CargarNotificacionesAdministrador(strXML);
            case "CARGAR PLANTELES CONCEPTOS": return this.dsCargaPlantelesSeleccionConcepto(strXML);
            case "OBTIENE MENUS USADOS POR USUARIOS": return this.dsobtieneMenusUsados(strXML);
            case "OBTIENE MENUS BOTONES": return this.dsoObtieneBotonesMenu(strXML);
            case "OBTIENE MENUS BOTONES USUARIOS": return this.dsCargaBotonesUsuarioMenu(strXML);
            case "CARGAR VALIDACION BOTONES": return this.dsCargaValidacionBotones(strXML);
            case "CARGAR PK FORMA": return this.dsObtenerPkFormas(strXML);
            case "CARGAR APLICACIONES": return this.CargarAplicaciones(strXML);
            case "CARGAR VALIDACIONES USUARIO": return this.dsObtenerValidacionesUsuario(strXML);
            case "CARGAR CONSULTA ACCESOS USUARIO": return this.dsObtenerConsultaAccesosUsuarios(strXML);

            default:
                return null;
        }
    }

    #region DATASET

    private DataSet dsObtenerConsultaAccesosUsuarios(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsObtenerConsultaAccesosUsuarios();
    }
    private DataSet dsObtenerValidacionesUsuario(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsObtenerValidacionesUsuario();
    }
    private DataSet dsVerificaAcceso(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);        
        return _mgrSeguridad.dsVerificaAcceso();
    }
    
    private DataSet CargarAplicaciones(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.CargarAplicaciones();
    }
    private DataSet dsObtenerPkFormas(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsObtenerPkFormas();
    }
    private DataSet dsCargaValidacionBotones(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsCargaValidacionBotones();
    }
    private DataSet dsCargaBotonesUsuarioMenu(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsCargaBotonesUsuarioMenu();
    }
    private DataSet dsoObtieneBotonesMenu(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsoObtieneBotonesMenu();
    }
    private DataSet dsobtieneMenusUsados(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsobtieneMenusUsados();
    }
    private DataSet dsCargaPlantelesSeleccionConcepto(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsCargaPlantelesSeleccionConcepto();
    }
    private DataSet CargarNotificacionesAdministrador(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.CargarNotificacionesAdministrador();
    }
    private DataSet CargarUsuariosLogeados(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.CargarUsuariosLogeados();
    }
    private DataSet CargarNotificaciones(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.CargarNotificaciones();
    }
    private DataSet BuscaNotificaciones(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.BuscaNotificaciones();
    }
    private DataSet dsCargaPlantelesSeleccion(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsCargaPlantelesSeleccion();
    }
    private DataSet ObtenerFolio(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.ObtenerFolio();
    }

    private DataSet obtenerReporteNivelEstudio(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.obtenerReporteNivelEstudio();
    }

    private DataSet dsSelecionarParametro(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsSelecionarParametro();
    }

    private DataSet obtenerParametros(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.obtenerParametros();
    }
    private DataSet dsobtieneConexion(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsobtieneConexion();
    }
    private DataSet dsCargaTipoConcexiones(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsCargaTipoConcexiones();
    }
    private DataSet dsNombreProceso(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsNombreProceso();
    }
    private DataSet dsCargaMenuAccesos(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsCargaMenuAccesos();
    }
    private DataSet dsBuscarPersonas(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsBuscarPersonas();
    }
    private DataSet dsObtieneUsuario(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsObtieneUsuario();
    }
    private DataSet dsCargaPadres(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsCargaPadres();
    }
    private DataSet dsObtienePlantelesSagu(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsObtienePlantelesSagu();
    }
    private DataSet dsObtienePlanteles(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsObtienePlanteles();
    }
    private DataSet dsObtieneAvisosKeys(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsObtieneAvisosKeys();
    }
    private DataSet dsTotalAvisos(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsTotalAvisos();
    }
    private DataSet dsCargaTotalAvisos(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsCargaTotalAvisos();
    }
    private DataSet dsCargaAvisos(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsCargaAvisos();
    }
    private DataSet dsSeleccionaTipoprocesos(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsSeleccionaTipoprocesos();
    }
    private DataSet dsSeleccionamenus(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsSeleccionamenus();
    }
    private DataSet dsSeleccionaProcesos(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsSeleccionaProcesos();
    }
    private DataSet dsCargaTipomenus(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsCargaTipomenus();
    }
    private DataSet dsObtieneClaveNivelSeguridad(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsObtieneClaveNivelSeguridad();
    }
    private DataSet dsObtieneNivelSeguridad(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsObtieneNivelSeguridad();
    }
    private DataSet dsCargaNivelSeguridad(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsCargaNivelSeguridad();
    }
   
    private DataSet dsInfoUsuario(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsInfoUsuario();
    }
    private DataSet dsCargaMenu(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsCargaMenu();
    }
    private DataSet dsSeleccionaMenusNombre(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsSeleccionaMenusNombre();
    }
    private DataSet dsCargaPermisosMenus(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsCargaPermisosMenus();
    }
    private DataSet dsVerificaEstadoMenu(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsVerificaEstadoMenu();
    }
    private DataSet dsValidaMenusHijos(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsValidaMenusHijos();
    }
    private DataSet dsCargaMenuHijos(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsCargaMenuHijos();
    }
    private DataSet dsValidaEmail(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsValidaEmail();
    }
    private DataSet dsCargaTipoProceso(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsCargaTipoProceso();
    }
    private DataSet dsObtieneDatosTipoProceso(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsObtieneDatosTipoProceso();
    }
    private DataSet dsObtieneClaveTipoProceso(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsObtieneClaveTipoProceso();
    }    
    #endregion DATASET
  
    
    [WebMethod]
    public bool bObtener1(string strXML, string strTipo)
    {
        switch (strTipo.ToUpper())
        {
            #region USUARIO            
            //case "ALMACENA TIPO PROCESO": return this.AlmacenaTipoProceso(strXML);
            //case "ELIMINA TIPO PROCESO": return this.EliminaTipoProceso(strXML);
            case "ALMACENA NIVEL SEGURIDAD": return this.AlmacenaNivelSeguridad(strXML);
            case "ELIMINA NIVEL SEGURIDAD": return this.EliminaNivelSeguridad(strXML);
            case "ALMACENA MENUS": return this.AlmacenaMenus(strXML);
            case "ELIMINA MENUS": return this.EliminaMenus(strXML);
            case "ALMACENA AVISOS": return this.AlmacenaImagenSerializada(strXML);
            case "ELIMINA AVISOS": return this.EliminaAvisos(strXML);
            case "MODIFICA CONTRASEÑA": return this.ModificaContraseña(strXML);
            case "ALTA USUARIO": return this.AltaUsuario(strXML);
            case "ALTA MENUS POR GRUPO": return this.AltaGrupoMenus(strXML);
            case "ALTA MENUS POR USUARIO": return this.AltaMenuUsuarios(strXML);
            case "ELIMINA MENUS POR USUARIO": return this.EliminaMenuUsuarios(strXML);
            case "ALTA IMAGEN USUARIO": return this.bAltaImagen(strXML);
            //case "ALMACENA PARAMETROS": return this.AlmacenaParametros(strXML);
            //case "ELIMINA PARAMETROS": return this.EliminaParametros(strXML);
            //case "ALTA PLANTEL USUARIOS": return this.AltaPlantelesUsuarios(strXML);
            case "ALTA USUARIOS LOGEADO": return this.ValidaUsuariosLogeados(strXML);
            case "ALTA NOTIFICACIONES": return this.AltaNotificaciones(strXML);
            case "MARCAR NOTIFICACIONES": return this.MarcarNotificaciones(strXML);
            case "BORRAR NOTIFICACIONES": return this.BorrarNotificaciones(strXML);
            case "ELIMINA FOTO USUARIO": return this.EliminaFotoUsuarios(strXML);
            //case "ALTA CONCEPTOS POR PLANTEL": return this.dsActualizarConceptoPlantelDetalle(strXML);
            case "ALTA APLICACIONES": return this.AltaAplicaciones(strXML);
            case "ELIMINA APLICACIONES": return this.EliminaAplicacion(strXML);
            case "MODIFICA APLICACIONES USUARIOS": return this.ModificaAppsUsuarios(strXML);
            case "ALTA MENUS USADOS POR USUARIOS": return this.AltaUsoMenus(strXML);
            case "ALTA MENUS BOTONES": return this.AltaMenuBotones(strXML);
            case "ELIMINA MENUS BOTONES": return this.EliminaBotonesMenu(strXML);
            case "ALTA BOTONES USUARIOS": return this.AltaBotonesUsuarios(strXML);
            case "MODIFICACION USUARIOS": return this.ModificaDatosUsuario(strXML);
            case "ALTA VALIDACIONES USUARIO": return this.AltaValidacionUsuario(strXML);
            case "ELIMNA VALIDACIONES USUARIO": return this.EliminaValidacionUsuario(strXML);
            #endregion USUARIO 
            default:
                return false;
        }
    }

    #region BOOL INSERT
    private bool AltaValidacionUsuario(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.AltaValidacionUsuario();
    }
    private bool EliminaValidacionUsuario(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.EliminaValidacionUsuario();
    }
    private bool AltaAplicaciones(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.AltaAplicaciones();
    }    
    private bool ModificaDatosUsuario(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.ModificaDatosUsuario();
    }
    private bool AltaBotonesUsuarios(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.AltaBotonesUsuarios();
    }
    private bool EliminaBotonesMenu(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.EliminaBotonesMenu();
    }
    private bool AltaMenuBotones(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.AltaMenuBotones();
    }
    private bool AltaUsoMenus(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.AltaUsoMenus();
    }
    private bool ModificaAppsUsuarios(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.ModificaAppsUsuarios();
    }
    private bool EliminaAplicacion(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.EliminaAplicacion();
    }
  
    private bool dsActualizarConceptoPlantelDetalle(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.dsActualizarConceptoPlantelDetalle();
    }
    private bool EliminaFotoUsuarios(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.EliminaFotoUsuarios();
    }
    private bool BorrarNotificaciones(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.BorrarNotificaciones();
    }
    private bool MarcarNotificaciones(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.MarcarNotificaciones();
    }
    private bool AltaNotificaciones(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.AltaNotificaciones();
    }
    private bool ValidaUsuariosLogeados(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.ValidaUsuariosLogeados();
    }
    private bool AltaPlantelesUsuarios(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.AltaPlantelesUsuarios();
    }
    private bool EliminaAvisos(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.EliminaAvisos();
    }
    private bool EliminaParametros(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.EliminaParametros();
    }
    private bool AlmacenaParametros(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.AlmacenaParametros();
    }
    private bool bAltaImagen(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.bAltaImagen();
    }
    private bool EliminaMenuUsuarios(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.EliminaMenuUsuarios();
    }
    private bool AltaMenuUsuarios(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.AltaMenuUsuarios();
    }
    private bool AltaGrupoMenus(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.AltaGrupoMenus();
    }
    private bool ModificaContraseña(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.ModificaContraseña();
    }
    private bool AlmacenaImagenSerializada(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.AlmacenaImagenSerializada();
    }
    private bool EliminaMenus(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.EliminaMenus();
    }
    private bool AlmacenaMenus(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.AlmacenaMenus();
    }
    private bool EliminaNivelSeguridad(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.EliminaNivelSeguridad();
    }
    private bool AlmacenaNivelSeguridad(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.AlmacenaNivelSeguridad();
    }
    private bool AlmacenaTipoProceso(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.AlmacenaTipoProceso();
    }
    private bool EliminaTipoProceso(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.EliminaTipoProceso();
    }
    private bool AltaUsuario(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.AltaUsuario();
    }
    #endregion BOOL INSERT
    
    #region BOOL USUARIO
    
    [WebMethod]
    public bool bObtener(string strTipo, string Usuario, string Contraseña)
    {
        switch (strTipo.ToUpper())
        {
            #region USUARIO
            case "AUTENTICA": return this.bAutentificado(Usuario, Contraseña);

            #endregion
            default:
                return false;
        }
    }
    private bool bAutentificado(string strUsuario, string pwd)
    {
        string strDomain = "univa.mx";
        //string strDist = "DC=univa,DC=mx";
        //string strErr;
        String strPath = "LDAP://univa.mx";
        String filterAttribute;

        string domainAndUsername = strDomain + @"\" + strUsuario;
        DirectoryEntry entry = new DirectoryEntry(strPath, domainAndUsername, pwd);

        try
        {
            if (strUsuario.Substring(0, 2).Equals("00"))
            {
                return false;
            }
            else
            {
                //Bind to the native AdsObject to force authentication.			
                Object obj = entry.NativeObject;

                DirectorySearcher search = new DirectorySearcher(entry);

                search.Filter = "(SAMAccountName=" + strUsuario + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();

                if (null == result)
                {
                    return false;
                }

                //Update the new path to the user in the directory.
                strPath = result.Path;
                filterAttribute = (String)result.Properties["cn"][0];
            }
        }
        catch (Exception ex)
        {
            return false;
        }

        return true;
    }    
    #endregion BOOL USUARIO

    #region ENCRIPTA
    public string EncriptarContraseña(string texto)
    {
        //arreglo de bytes donde guardaremos la llave
        byte[] keyArray;
        //arreglo de bytes donde guardaremos el texto
        //que vamos a encriptar
        byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(texto);

        //se utilizan las clases de encriptación
        //provistas por el Framework
        //Algoritmo MD5
        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
        //se guarda la llave para que se le realice
        //hashing
        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

        hashmd5.Clear();

        //Algoritmo 3DAS
        TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

        tdes.Key = keyArray;
        tdes.Mode = CipherMode.ECB;
        tdes.Padding = PaddingMode.PKCS7;

        //se empieza con la transformación de la cadena
        ICryptoTransform cTransform = tdes.CreateEncryptor();

        //arreglo de bytes donde se guarda la
        //cadena cifrada
        byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);

        tdes.Clear();

        //se regresa el resultado en forma de una cadena
        return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
    }
    public string DesencriptarContraseña(string textoEncriptado)
    {
        byte[] keyArray;
        //convierte el texto en una secuencia de bytes
        byte[] Array_a_Descifrar = Convert.FromBase64String(textoEncriptado);

        //se llama a las clases que tienen los algoritmos
        //de encriptación se le aplica hashing
        //algoritmo MD5
        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

        hashmd5.Clear();

        TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

        tdes.Key = keyArray;
        tdes.Mode = CipherMode.ECB;
        tdes.Padding = PaddingMode.PKCS7;

        ICryptoTransform cTransform = tdes.CreateDecryptor();

        byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);

        tdes.Clear();
        //se regresa en forma de cadena
        return UTF8Encoding.UTF8.GetString(resultArray);
    }
    #endregion ENCRIPTA
    
    #region strJson
    [WebMethod]
    public string strJson(string strXML, string strTipo)
    {
        switch (strTipo.ToUpper())
        {
            case "CONFIGURACION MAIL": return this.strJsonParametrosMail(strXML);
            case "APLICACIONES": return this.strJsonApps(strXML);
            case "CARGA NIVEL SEGURIDAD": return this.jsonCargaNivelSeguridad(strXML);
            case "CARGAR APLICACIONES": return this.strJsonCargarApps(strXML);
            case "CARGAR APLICACIONES USUARIO": return this.strJsonCargaAppsUsuario(strXML);
            case "CARGA MENUSUSUARIO": return this.jsonMenusUsuario(strXML);
            default:
                return "Sin Valores";
        }
    }
    private string jsonMenusUsuario(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.jsonMenusUsuario();
    }    
     private string strJsonParametrosMail(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.strJsonParametrosMail();
    }
     private string strJsonApps(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);        
        return _mgrSeguridad.strJsonApps();

    }
     private string strJsonCargarApps(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.strJsonCargarApps();

    }
     private string jsonCargaNivelSeguridad(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.jsonCargaNivelSeguridad();
    }
     private string strJsonCargaAppsUsuario(string strXML)
    {
        ElyonManagerCxC.mgrCxC _mgrSeguridad = new ElyonManagerCxC.mgrCxC(strXML);
        return _mgrSeguridad.strJsonCargaAppsUsuario();
    }
   
    #endregion strJson
    
}
