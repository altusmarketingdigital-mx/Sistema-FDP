using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Security.Cryptography;

namespace ElyonManagerCxC
{
    public class mgrCxC
    {
        #region Referencia MODEL
        ElyonModelCxC.mCxC _mSeguridad;        
        #endregion Referencia MODEL

        #region VARIABLES PRIVADAS                                                     
        DataSet dsDatos = new DataSet();
        SqlConnection cn;
        string strConWs = System.Configuration.ConfigurationManager.AppSettings["SEGURIDAD"];
        #endregion

        #region CONSTRUCTOR
        public mgrCxC(string strXML)
        {
            _mSeguridad = ElyonModelCxC.mCxC.FromXml(strXML);            
        }
        #endregion

        #region DATASET 
        public DataSet dsObtenerConsultaAccesosUsuarios()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@idUsuario", _mSeguridad.intIdUsuario);

                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSEL_ConsultaAccesosUsuarios", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet dsObtenerValidacionesUsuario()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@idUsuario", _mSeguridad.intIdUsuario);
               
                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSELValidacionesUsuario", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet CargarAplicaciones()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSelCargaApp");
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet dsObtenerPkFormas()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("@IdApp", _mSeguridad.intAplicacion);
                parametros[1] = new SqlParameter("@strNombreForma", _mSeguridad.strNombreMenu);
                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSelPkFormaMenu", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet dsCargaValidacionBotones()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[3];
                parametros[0] = new SqlParameter("@Usuario", _mSeguridad.strUsuario);
                parametros[1] = new SqlParameter("@IDmenu", _mSeguridad.IDMenu);
                parametros[2] = new SqlParameter("@IDboton", _mSeguridad.strIdBoton);
                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSelIDBoton", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet dsCargaBotonesUsuarioMenu()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("@Usuario", _mSeguridad.strUsuario);
                parametros[1] = new SqlParameter("@IdMenu", _mSeguridad.IDMenu);
                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spCargaBotonesUsuarioMenu", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet obtenerAplicaciones()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();

                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "SpNivelSeguridad");
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet CargarNotificacionesAdministrador()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spCargaNotificacionAdmin");
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet CargarUsuariosLogeados()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spcargaUsuariosLogeados");
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet CargarNotificaciones()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("@usuario", _mSeguridad.strUsuario);
                parametros[1] = new SqlParameter("@App", _mSeguridad.intAplicacion);

                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spCargaNotificacion", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet BuscaNotificaciones()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("@usuario", _mSeguridad.strUsuario);
                parametros[1] = new SqlParameter("@App", _mSeguridad.intAplicacion);

                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSelNotificacion", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet dsCargaPlantelesSeleccion()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@Usuario", _mSeguridad.strUsuario);
                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spCargaPlantelesSeleccion", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet dsCargaPlantelesSeleccionConcepto()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@Concepto", _mSeguridad.intIdConcepto);
                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSelPlantelesConcepto", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet ObtenerFolio()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@App", _mSeguridad.intAplicacion);
                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spObtenerFolio", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }

        public DataSet dsSelecionarParametro()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@IDpar", _mSeguridad.intParametro);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSelObtieneParametros", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet obtenerParametros()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();

                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spObtieneParametros");
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet dsCargaAvisos()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();

                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spCargaAvisosImg");
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }

        public DataSet dsVerificaAcceso()
        {
            cn = new SqlConnection(strConWs);
           
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[3];
                parametros[0] = new SqlParameter("@vchUsuario", _mSeguridad.strUsuario);
                parametros[1] = new SqlParameter("@vchContraseña", _mSeguridad.strContraseña);
                parametros[1].Value = Encripta.EncriptarContraseña(_mSeguridad.strContraseña);
                parametros[2] = new SqlParameter("@IdApp", _mSeguridad.intAplicacion);


                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spr_VerificaUsuario", parametros);

                 //if (dsDatos.Tables[0].Rows.Count > 0)
                 //    dsDatos.Tables[0].Rows[0]["vchContraseña"] = Encripta.DesencriptarContraseña(dsDatos.Tables[0].Rows[0]["vchContraseña"].ToString());
                cn.Close();
            }
            catch (Exception ex)
            {

            }
            return dsDatos;
        }

        public DataSet dsInfoUsuario()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("@vchUsuario", _mSeguridad.strUsuario);
                parametros[1] = new SqlParameter("@IdApp", _mSeguridad.intAplicacion);

                int intOut = 0;

                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spr_ObtenerUsuario", parametros);

                if (dsDatos.Tables[0].Rows.Count > 0 && !int.TryParse(_mSeguridad.strUsuario, out intOut))

                    dsDatos.Tables[0].Rows[0]["Contraseña"] = Encripta.DesencriptarContraseña(dsDatos.Tables[0].Rows[0]["Contraseña"].ToString());
            }
            catch (Exception ex)
            {

            }
            return dsDatos;

        }

        public DataSet dsObtieneUsuario()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@vchNomina", _mSeguridad.intNomina);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSelUsuario", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsCargaMenu()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[4];
                parametros[0] = new SqlParameter("@UsuarioId", _mSeguridad.strUsuario);
                parametros[1] = new SqlParameter("@intTipo", _mSeguridad.strTipo); //
                parametros[2] = new SqlParameter("@ArmMenus", _mSeguridad.intArmaMenus);
                parametros[3] = new SqlParameter("@idApp", _mSeguridad.intAplicacion);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "pObtenerMenuUsuarios", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsCargaMenuAccesos()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[3];
                parametros[0] = new SqlParameter("@intTipo", _mSeguridad.strTipo);
                parametros[1] = new SqlParameter("@idApp", _mSeguridad.intAplicacion);
                parametros[2] = new SqlParameter("@idusuario", _mSeguridad.strUsuario);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spObtenerMenuAccesos", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsSeleccionaMenusNombre()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("@MenuNombre", _mSeguridad.strNombreMenu);
                parametros[1] = new SqlParameter("@Aplicaccion ", _mSeguridad.intAplicacion);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "pSelecionaMenuNombre", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsNombreProceso()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@Prog", _mSeguridad.strNombreProceso);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spObtieneMensajeProceso", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsCargaPermisosMenus()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[4];
                parametros[0] = new SqlParameter("@Usuario", _mSeguridad.strUsuario);
                parametros[1] = new SqlParameter("@NombreItem", _mSeguridad.strNombreItem);
                parametros[2] = new SqlParameter("@intNivel", _mSeguridad.intNivel);
                parametros[3] = new SqlParameter("@App", _mSeguridad.intAplicacion);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "pSelPermisosUsuarios", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsVerificaEstadoMenu()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("@MenuKey", _mSeguridad.intMenuKey);
                parametros[1] = new SqlParameter("@App", _mSeguridad.intAplicacion);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "pSelEstadoMenu", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsValidaMenusHijos()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("@IDMenu", _mSeguridad.IDMenu);
                parametros[1] = new SqlParameter("@app", _mSeguridad.intAplicacion);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spValidaHijos", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsCargaMenuHijos()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[4];
                parametros[0] = new SqlParameter("@UsuarioId", _mSeguridad.strUsuario);
                parametros[1] = new SqlParameter("@intTipo", _mSeguridad.strTipo);
                parametros[2] = new SqlParameter("@intPadre", _mSeguridad.IDMenu); //
                parametros[3] = new SqlParameter("@idApp", _mSeguridad.intAplicacion);


                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "pObtenerMenuHijosUsuario", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsValidaEmail()
        {
            cn = new SqlConnection(strConWs);
            cn.Open();
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@vchUsu", _mSeguridad.strUsuario);
            parametros[1] = new SqlParameter("@vchMail", _mSeguridad.strEmail);

            dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spValidaEmail", parametros);

            if (dsDatos.Tables[0].Rows.Count > 0)
                dsDatos.Tables[0].Rows[0]["Contraseña"] = Encripta.DesencriptarContraseña(dsDatos.Tables[0].Rows[0]["Contraseña"].ToString());
            cn.Close();
            return dsDatos;
        }

        public DataSet dsCargaTipoProceso()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();

                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "pTipoProceso");
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet dsCargaPadres()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@App", _mSeguridad.intAplicacion);

                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSelMenuPadres", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet dsObtieneDatosTipoProceso()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@idTpro", _mSeguridad.intTipoProceso);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "pselTipoProcesos", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsObtieneClaveTipoProceso()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@cve", _mSeguridad.strClaveTipoProceso);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spObtieneTipoProceso", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsCargaNivelSeguridad()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();

                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "pNivelSeguridad");
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet dsObtieneNivelSeguridad()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@NvSeg", _mSeguridad.intNivSeguridad);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "pSelNivelSeguridad", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsObtieneClaveNivelSeguridad()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@Cve", _mSeguridad.strClaveNivSeg);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spObtieneClaveNivelSeguridad", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsCargaTipomenus()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("@Tipo", _mSeguridad.intTipoMenu);
                parametros[1] = new SqlParameter("@IdApp", _mSeguridad.intAplicacion);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "pSelTipoMenus", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsSeleccionaProcesos()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();

                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "pSelProcesos");
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet dsSeleccionaTipoprocesos()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@idTpro", _mSeguridad.intTipoProceso);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "pselTipoProcesos", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsSeleccionamenus()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@Menu", _mSeguridad.intMenuKey);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "pSelecionaMenu", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsCargaTotalAvisos()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();

                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spCargaAvisos");
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet dsTotalAvisos()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();

                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spObtieneTotalAvisos");
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet dsObtieneAvisosKeys()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@idAviso", _mSeguridad.intIDAviso);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spObtieneAvisoKey", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsObtienePlantelesSagu()
        {
            DataSet dsDatos = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();

                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spObtienePantelesSAGU");
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet dsObtienePlanteles()
        {
            DataSet dsDatos = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[3];
                parametros[0] = new SqlParameter("@Usuario", _mSeguridad.strUsuario);
                parametros[1] = new SqlParameter("@App", _mSeguridad.intAplicacion);
                parametros[2] = new SqlParameter("@IdMenu", _mSeguridad.intMenuKey);

                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spObtienePanteles", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet dsBuscarPersonas()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("@Nombres", _mSeguridad.strNombreUsuario);
                parametros[1] = new SqlParameter("@IdApp", _mSeguridad.intAplicacion);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spBuscarPersonas", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsCargaTipoConcexiones()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@idApp", _mSeguridad.intAplicacion);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSelCargaConexiones", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsobtieneConexion()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("@idApp", _mSeguridad.intAplicacion);
                parametros[1] = new SqlParameter("@vchTp", _mSeguridad.strTipo);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSelObtieneConexion", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet obtenerReporteNivelEstudio()
        {
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();

                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "SpNivelSeguridad");
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet dsobtieneMenusUsados()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[3];
                parametros[0] = new SqlParameter("@intUsuario", _mSeguridad.intIdUsuario);
                parametros[1] = new SqlParameter("@intApp", _mSeguridad.intAplicacion);
                parametros[2] = new SqlParameter("@Total", _mSeguridad.intCantidad);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSelAppUsadasUsuarios", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsoObtieneBotonesMenu()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@IdMenu", _mSeguridad.IDMenu);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "SpCargaBotonesmenus", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        #endregion

        #region BOOL
        public bool EliminaValidacionUsuario()
        {
            bool bRes = false;
            SqlConnection sqlConexion = null;
            SqlTransaction sqlTransaccion = null;
            bool bLocalConnection = false;
            bool bLocalTransaction = false;

            try
            {
                #region CREAR CONEXIONES
                if (sqlConexion == null)
                {
                    sqlConexion = new SqlConnection(strConWs);
                    sqlConexion.Open();
                    bLocalConnection = true;
                }
                if (sqlTransaccion == null)
                {
                    sqlTransaccion = sqlConexion.BeginTransaction();
                    bLocalTransaction = true;
                }
                #endregion CREAR CONEXIONES

                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@id", _mSeguridad.intIdUsuario);

                DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spDelValidacionesUsuarios", parametros);
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
                {
                    bRes = true;
                }
                else
                {
                    bRes = false;
                }
                if (bRes)
                {
                    if (bLocalTransaction)
                    {
                        sqlTransaccion.Commit();
                        sqlTransaccion.Dispose();
                    }
                    if (bLocalConnection)
                    {
                        sqlConexion.Close();
                        sqlConexion.Dispose();
                    }
                }
                else
                {
                    if (bLocalTransaction)
                    {
                        sqlTransaccion.Rollback();
                        sqlTransaccion.Dispose();
                    }
                    if (bLocalConnection)
                    {
                        sqlConexion.Close();
                        sqlConexion.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                if (bLocalTransaction)
                {
                    sqlTransaccion.Rollback();
                    sqlTransaccion.Dispose();
                }
                if (bLocalConnection)
                {
                    sqlConexion.Close();
                    sqlConexion.Dispose();
                }
                throw ex;
            }
            return bRes;
        }
        public bool AltaValidacionUsuario()
        {
            bool bRes = false;
            SqlConnection sqlConexion = null;
            SqlTransaction sqlTransaccion = null;
            bool bLocalConnection = false;
            bool bLocalTransaction = false;

            try
            {
                #region CREAR CONEXIONES
                if (sqlConexion == null)
                {
                    sqlConexion = new SqlConnection(strConWs);
                    sqlConexion.Open();
                    bLocalConnection = true;
                }
                if (sqlTransaccion == null)
                {
                    sqlTransaccion = sqlConexion.BeginTransaction();
                    bLocalTransaction = true;
                }
                #endregion CREAR CONEXIONES

                SqlParameter[] parametros = new SqlParameter[20];
                parametros[0] = new SqlParameter("@id", _mSeguridad.intIDValUsuario);
                parametros[1] = new SqlParameter("@FkUsuario", _mSeguridad.intIdUsuario);
                parametros[2] = new SqlParameter("@intCajVentas", _mSeguridad.intCajVentas);
                parametros[3] = new SqlParameter("@intCanVenta", _mSeguridad.intCanVenta);
                parametros[4] = new SqlParameter("@intSoloCanVenta", _mSeguridad.intSoloCanVenta);
                parametros[5] = new SqlParameter("@intDesArticulo", _mSeguridad.intDesArticulo);
                parametros[6] = new SqlParameter("@intSoloDesArticulo", _mSeguridad.intSoloDesArticulo);
                parametros[7] = new SqlParameter("@intCantVenta", _mSeguridad.intCantVenta);
                parametros[8] = new SqlParameter("@intSoloCantVenta", _mSeguridad.intSoloCantVenta);
                parametros[9] = new SqlParameter("@intNoModPre", _mSeguridad.intNoModPre);
                parametros[10] = new SqlParameter("@intSoloNoModPre", _mSeguridad.intSoloNoModPre);
                parametros[11] = new SqlParameter("@intPrecioVen", _mSeguridad.intPrecioVen);
                parametros[12] = new SqlParameter("@intSoloPrecioVen", _mSeguridad.intSoloPrecioVen);
                parametros[13] = new SqlParameter("@intOtoDesc", _mSeguridad.intOtoDesc);
                parametros[14] = new SqlParameter("@intSoloOtoDesc", _mSeguridad.intSoloOtoDesc);
                parametros[15] = new SqlParameter("@intModDatCred", _mSeguridad.intModDatCred);
                parametros[16] = new SqlParameter("@intSoloModDatCred", _mSeguridad.intSoloModDatCred);
                parametros[17] = new SqlParameter("@intParMoneda", _mSeguridad.intParMoneda);
                parametros[18] = new SqlParameter("@intSoloParMoneda", _mSeguridad.intSoloParMoneda);
                parametros[19] = new SqlParameter("@intCajon", _mSeguridad.intCajon);                

                DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spADDValidacionesUsuario", parametros);
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
                {
                    bRes = true;
                }
                else
                {
                    bRes = false;
                }
                if (bRes)
                {
                    if (bLocalTransaction)
                    {
                        sqlTransaccion.Commit();
                        sqlTransaccion.Dispose();
                    }
                    if (bLocalConnection)
                    {
                        sqlConexion.Close();
                        sqlConexion.Dispose();
                    }
                }
                else
                {
                    if (bLocalTransaction)
                    {
                        sqlTransaccion.Rollback();
                        sqlTransaccion.Dispose();
                    }
                    if (bLocalConnection)
                    {
                        sqlConexion.Close();
                        sqlConexion.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                if (bLocalTransaction)
                {
                    sqlTransaccion.Rollback();
                    sqlTransaccion.Dispose();
                }
                if (bLocalConnection)
                {
                    sqlConexion.Close();
                    sqlConexion.Dispose();
                }
                throw ex;
            }
            return bRes;
        }
        public bool AltaAplicaciones()
        {
            bool bRes = false;
            SqlConnection sqlConexion = null;
            SqlTransaction sqlTransaccion = null;
            bool bLocalConnection = false;
            bool bLocalTransaction = false;

            try
            {
                #region CREAR CONEXIONES
                if (sqlConexion == null)
                {
                    sqlConexion = new SqlConnection(strConWs);
                    sqlConexion.Open();
                    bLocalConnection = true;
                }
                if (sqlTransaccion == null)
                {
                    sqlTransaccion = sqlConexion.BeginTransaction();
                    bLocalTransaction = true;
                }
                #endregion CREAR CONEXIONES

                SqlParameter[] parametros = new SqlParameter[4];
                parametros[0] = new SqlParameter("@idApp", _mSeguridad.intAplicacion);
                parametros[1] = new SqlParameter("@vchNombre", _mSeguridad.strNombreCortoApp);
                parametros[2] = new SqlParameter("@vchNomLargo", _mSeguridad.strNombreLargoApp);
                parametros[3] = new SqlParameter("@estado", _mSeguridad.intEstatus);


                DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spAddAplicaciones", parametros);
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
                {
                    bRes = true;
                }
                else
                {
                    bRes = false;
                }
                if (bRes)
                {
                    if (bLocalTransaction)
                    {
                        sqlTransaccion.Commit();
                        sqlTransaccion.Dispose();
                    }
                    if (bLocalConnection)
                    {
                        sqlConexion.Close();
                        sqlConexion.Dispose();
                    }
                }
                else
                {
                    if (bLocalTransaction)
                    {
                        sqlTransaccion.Rollback();
                        sqlTransaccion.Dispose();
                    }
                    if (bLocalConnection)
                    {
                        sqlConexion.Close();
                        sqlConexion.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                if (bLocalTransaction)
                {
                    sqlTransaccion.Rollback();
                    sqlTransaccion.Dispose();
                }
                if (bLocalConnection)
                {
                    sqlConexion.Close();
                    sqlConexion.Dispose();
                }
                throw ex;
            }
            return bRes;
        }
      public bool ModificaDatosUsuario()
      {

          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[5];
              parametros[0] = new SqlParameter("@vchUsuo", _mSeguridad.strUsuario);
              parametros[1] = new SqlParameter("@vchUsuSis", _mSeguridad.strUsuarioSistema);
              parametros[2] = new SqlParameter("@vchEmail", _mSeguridad.strEmail);
              parametros[3] = new SqlParameter("@bActivo", _mSeguridad.bActivo);
              parametros[4] = new SqlParameter("@bAdmin", _mSeguridad.bAdmin);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spModUsuario", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = true;
              }
              else
              {
                  bRes = false;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool AltaBotonesUsuarios()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[3];
              parametros[0] = new SqlParameter("@Usuario", _mSeguridad.strUsuario);
              parametros[1] = new SqlParameter("@menu", _mSeguridad.intMenuKey);
              parametros[2] = new SqlParameter("@asigna", _mSeguridad.bAsignaAutomatico);


              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spAddBotonesUsuarios", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = true;
              }
              else
              {
                  bRes = false;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool EliminaBotonesMenu()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[1];
              parametros[0] = new SqlParameter("@IdMenu", _mSeguridad.intMenuKey);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "SpDELBotonesmenus", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = true;
              }
              else
              {
                  bRes = false;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool AltaMenuBotones()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[4];
              parametros[0] = new SqlParameter("@IdMenus", _mSeguridad.IDMenu);
              parametros[1] = new SqlParameter("@vchIDBoton", _mSeguridad.strIdBoton);
              parametros[2] = new SqlParameter("@vchDescripcion", _mSeguridad.strDescripcion);
              parametros[3] = new SqlParameter("@bEstatus", _mSeguridad.intEstatus);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spADDBotonesMenu", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = true;
              }
              else
              {
                  bRes = false;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool AltaUsoMenus()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[3];
              parametros[0] = new SqlParameter("@intUsuarios", _mSeguridad.intIdUsuario);
              parametros[1] = new SqlParameter("@intMenu", _mSeguridad.intMenuKey);
              parametros[2] = new SqlParameter("@intApp", _mSeguridad.intAplicacion);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spADDBitacoraUsoAplicaciones", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = true;
              }
              else
              {
                  bRes = false;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool ModificaAppsUsuarios()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[3];
              parametros[0] = new SqlParameter("@Usuario", _mSeguridad.strUsuario);
              parametros[1] = new SqlParameter("@app", _mSeguridad.intAplicacion);
              parametros[2] = new SqlParameter("@asigna", _mSeguridad.bAsignaAutomatico);


              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spAddAppssUsuarios", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = true;
              }
              else
              {
                  bRes = false;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool EliminaAplicacion()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[1];
              parametros[0] = new SqlParameter("@idApp", _mSeguridad.intAplicacion);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spDELAplicaciones", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = true;
              }
              else
              {
                  bRes = false;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool dsActualizarConceptoPlantelDetalle()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[3];
              parametros[0] = new SqlParameter("@Concepto", _mSeguridad.intIdConcepto);
              parametros[1] = new SqlParameter("@Plantel", _mSeguridad.intPlantelID);
              parametros[2] = new SqlParameter("@asigna", _mSeguridad.bAsignaAutomatico);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "SpActualizaConceptoPlantelDetalle", parametros);

              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = true;
              }
              else
              {
                  bRes = false;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool EliminaFotoUsuarios()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[1];
              parametros[0] = new SqlParameter("@Usuario", _mSeguridad.intIdUsuario);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spModFotoUsuario", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = true;
              }
              else
              {
                  bRes = false;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool BorrarNotificaciones()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[2];
              parametros[0] = new SqlParameter("@usuario", _mSeguridad.strUsuario);
              parametros[1] = new SqlParameter("@App", _mSeguridad.intAplicacion);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spDelNotificacion", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = true;
              }
              else
              {
                  bRes = false;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool MarcarNotificaciones()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[2];
              parametros[0] = new SqlParameter("@usuario", _mSeguridad.strUsuario);
              parametros[1] = new SqlParameter("@App", _mSeguridad.intAplicacion);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spMarcaLeidosNotificacion", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = true;
              }
              else
              {
                  bRes = false;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool AltaNotificaciones()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[7];
              parametros[0] = new SqlParameter("@usuario", _mSeguridad.strUsuario);
              parametros[1] = new SqlParameter("@app", _mSeguridad.intAplicacion);
              parametros[2] = new SqlParameter("@Mnj", _mSeguridad.Mensaje);
              parametros[3] = new SqlParameter("@Fec", _mSeguridad.dtFecha);
              parametros[4] = new SqlParameter("@Ldo", _mSeguridad.intLeido);
              parametros[5] = new SqlParameter("@Br", _mSeguridad.intBorrado);
              parametros[6] = new SqlParameter("@Tipo", _mSeguridad.intTipo);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spAddNotificacion", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = true;
              }
              else
              {
                  bRes = false;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool ValidaUsuariosLogeados()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[3];
              parametros[0] = new SqlParameter("@Usuario", _mSeguridad.strUsuario);
              parametros[1] = new SqlParameter("@app", _mSeguridad.intAplicacion);
              parametros[2] = new SqlParameter("@Estado", _mSeguridad.intEstatus);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "SpModValidaUsuarioLogeado", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = true;
              }
              else
              {
                  bRes = false;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool AltaPlantelesUsuarios()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[5];
              parametros[0] = new SqlParameter("@Usuario", _mSeguridad.strUsuario);
              parametros[1] = new SqlParameter("@app", _mSeguridad.intAplicacion);
              parametros[2] = new SqlParameter("@menu", _mSeguridad.intMenuKey);
              parametros[3] = new SqlParameter("@plantel", _mSeguridad.intPlantelID);
              parametros[4] = new SqlParameter("@asigna", _mSeguridad.bAsignaAutomatico);


              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spAddPlantelesUsuarios", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = true;
              }
              else
              {
                  bRes = false;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool EliminaAvisos()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[1];
              parametros[0] = new SqlParameter("@IdAviso", _mSeguridad.intIDAviso);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "pEliminaAvisos", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = false;
              }
              else
              {
                  bRes = true;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool EliminaParametros()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[2];
              parametros[0] = new SqlParameter("@IDParam", _mSeguridad.intParametro);
              parametros[1] = new SqlParameter("@App", _mSeguridad.intAplicacion);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spEliminaParametros", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = false;
              }
              else
              {
                  bRes = true;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool AlmacenaParametros()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[9];
              parametros[0] = new SqlParameter("@IDParam", _mSeguridad.intParametro);
              parametros[1] = new SqlParameter("@App", _mSeguridad.intAplicacion);
              parametros[2] = new SqlParameter("@NumFolio", _mSeguridad.intFolio);
              parametros[3] = new SqlParameter("@SerSalida", _mSeguridad.strServidorSalida);
              parametros[4] = new SqlParameter("@PueSalida", _mSeguridad.strPuertoSalida);
              parametros[5] = new SqlParameter("@UsuServidor", _mSeguridad.strUsuarioEnvia);
              parametros[6] = new SqlParameter("@ConServidor", _mSeguridad.strContraseñaEnvia);
              parametros[7] = new SqlParameter("@Vig", _mSeguridad.intEstatus);
              parametros[8] = new SqlParameter("@Rutimg", _mSeguridad.strRutaImagen);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "pAlmacenaParametros", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = true;
              }
              else
              {
                  bRes = false;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool AlmacenaTipoProceso()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[3];
              parametros[0] = new SqlParameter("@idTipProc", _mSeguridad.intTipoProceso);
              parametros[1] = new SqlParameter("@CveTipo", _mSeguridad.strClaveTipoProceso);
              parametros[2] = new SqlParameter("@DescTipo", _mSeguridad.strDescTipoProceso);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "pAlmacenaProceso", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = false;
              }
              else
              {
                  bRes = true;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool EliminaTipoProceso()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[1];
              parametros[0] = new SqlParameter("@idTipProc", _mSeguridad.intTipoProceso);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "pEliminaProceso", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = false;
              }
              else
              {
                  bRes = true;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool AlmacenaNivelSeguridad()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[4];
              parametros[0] = new SqlParameter("@NvSeg", _mSeguridad.intNivSeguridad);
              parametros[1] = new SqlParameter("@CveNivel", _mSeguridad.strClaveNivSeg);
              parametros[2] = new SqlParameter("@DescNivel", _mSeguridad.strDescNivSeg);
              parametros[3] = new SqlParameter("@Estado", _mSeguridad.strStatusNivSeg);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "pAlmacenaNivelSeguridad", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = false;
              }
              else
              {
                  bRes = true;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool EliminaNivelSeguridad()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[1];
              parametros[0] = new SqlParameter("@NvSeg", _mSeguridad.intTipoProceso);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "pEliminaNivelSeguridad", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = false;
              }
              else
              {
                  bRes = true;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool AlmacenaMenus()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[17];
              parametros[0] = new SqlParameter("@Aplicacion", _mSeguridad.intAplicacion);
              parametros[1] = new SqlParameter("@NombreProceso", _mSeguridad.strNombreProceso);
              parametros[2] = new SqlParameter("@Siglas", _mSeguridad.strSiglas);
              parametros[3] = new SqlParameter("@Mensaje", _mSeguridad.strMensaje);
              parametros[4] = new SqlParameter("@NivelProceso", _mSeguridad.intNivelProceso);
              parametros[5] = new SqlParameter("@Navegacion", _mSeguridad.intNavegacion);
              parametros[6] = new SqlParameter("@TipoProceso", _mSeguridad.intTipoProceso);
              parametros[7] = new SqlParameter("@Estatus", _mSeguridad.intEstatus);
              parametros[8] = new SqlParameter("@Padre", _mSeguridad.intPadre);
              parametros[9] = new SqlParameter("@MenuKey", _mSeguridad.intMenuKey);
              parametros[10] = new SqlParameter("@vcPrograma", _mSeguridad.strvcPrograma);
              parametros[11] = new SqlParameter("@vchProgEsc", _mSeguridad.strvchProgEsc);
              parametros[12] = new SqlParameter("@vcImagen", _mSeguridad.strvcImagen);
              parametros[13] = new SqlParameter("@chrTipo", _mSeguridad.strchrTipo);
              parametros[14] = new SqlParameter("@intArma", _mSeguridad.intArmaMenus);
              parametros[15] = new SqlParameter("@bSeguridad", _mSeguridad.bSeguridaplantel);
              parametros[16] = new SqlParameter("@bSeguridadADM", _mSeguridad.bSeguridadAdmin);

                DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "AlmacenaMenus", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = false;
              }
              else
              {
                  bRes = true;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool EliminaMenus()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[1];
              parametros[0] = new SqlParameter("@idMenu", _mSeguridad.intMenuKey);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "pEliminaMenus", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = false;
              }
              else
              {
                  bRes = true;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool AlmacenaImagenSerializada()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[4];
              parametros[0] = new SqlParameter("@idOrden", _mSeguridad.intOrden);
              parametros[1] = new SqlParameter("@img", _mSeguridad.strImgSerializada);
              parametros[2] = new SqlParameter("@est", _mSeguridad.intEstatus);
              parametros[3] = new SqlParameter("@idav", _mSeguridad.intIDAviso);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "SpADDCargaAvisosImg", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = false;
              }
              else
              {
                  bRes = true;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool ModificaContraseña()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[3];
              parametros[0] = new SqlParameter("@vchUsuario", _mSeguridad.strUsuario);
              parametros[1] = new SqlParameter("@vchContraseña", _mSeguridad.strContraseña);
              parametros[1].Value = Encripta.EncriptarContraseña(_mSeguridad.strContraseña);
              parametros[2] = new SqlParameter("@pVez", _mSeguridad.intPrimeraVes);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spModificaContraseña", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = false;
              }
              else
              {
                  bRes = true;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool AltaUsuario()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[17];
              parametros[0] = new SqlParameter("@vchUsuo", _mSeguridad.strUsuario);
              parametros[1] = new SqlParameter("@vchUsuSis", _mSeguridad.strUsuarioSistema);
              parametros[2] = new SqlParameter("@vchnomina", _mSeguridad.intNomina);
              parametros[3] = new SqlParameter("@vchEmail", _mSeguridad.strEmail);
              parametros[4] = new SqlParameter("@bActivo", _mSeguridad.bActivo);
              parametros[5] = new SqlParameter("@idPlantel", _mSeguridad.intPlantelID);
              parametros[6] = new SqlParameter("@dttFechaNac", _mSeguridad.dtFechaNacimiento);
              parametros[7] = new SqlParameter("@idapp", _mSeguridad.intAplicacion);
              parametros[8] = new SqlParameter("@bAdmin", _mSeguridad.bAdmin);
              parametros[9] = new SqlParameter("@vchImagen", _mSeguridad.strvcImagen);
              parametros[10] = new SqlParameter("@ListaApps", _mSeguridad.StrJson);              
              parametros[11] = new SqlParameter("@vchNombre", _mSeguridad.strvchNombre);
              parametros[12] = new SqlParameter("@vchPaterno", _mSeguridad.strvchPaterno);
              parametros[13] = new SqlParameter("@vchMaterno", _mSeguridad.strvchMaterno);
              parametros[14] = new SqlParameter("@vchClaveDepto", _mSeguridad.strvchClaveDepto);
              parametros[15] = new SqlParameter("@vchDescDepto", _mSeguridad.strvchDescDepto);
              parametros[16] = new SqlParameter("@vchDescPuesto", _mSeguridad.strvchDescpuesto);

                DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spAddUsuario", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = false;
              }
              else
              {
                  bRes = true;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool AltaGrupoMenus()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[3];
              parametros[0] = new SqlParameter("@usuarioPadre", _mSeguridad.intIdUsuario);
              parametros[1] = new SqlParameter("@usuarioHijo", _mSeguridad.intIdUsuario1);
              parametros[2] = new SqlParameter("@intApp", _mSeguridad.intAplicacion);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spAddMenusGrupo", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = false;
              }
              else
              {
                  bRes = true;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool AltaMenuUsuarios()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[4];
              parametros[0] = new SqlParameter("@Usuario", _mSeguridad.intIdUsuario);
              parametros[1] = new SqlParameter("@Menu", _mSeguridad.intMenuKey);
              parametros[2] = new SqlParameter("@Seguridad", _mSeguridad.intNivSeguridad);
              parametros[3] = new SqlParameter("@intApp", _mSeguridad.intAplicacion);
              //parametros[4] = new SqlParameter("@bVisible", _mSeguridad.bVisible);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spAddMenuUsuario", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) > 0)
              {
                  bRes = true;
              }
              else
              {
                  bRes = false;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool EliminaMenuUsuarios()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[3];
              parametros[0] = new SqlParameter("@Usuario", _mSeguridad.intIdUsuario);
              parametros[1] = new SqlParameter("@Menu", _mSeguridad.intMenuKey);
              parametros[2] = new SqlParameter("@intApp", _mSeguridad.intAplicacion);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "EliminaMenuUsuario", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = false;
              }
              else
              {
                  bRes = true;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      public bool bAltaImagen()
      {
          bool bRes = false;
          SqlConnection sqlConexion = null;
          SqlTransaction sqlTransaccion = null;
          bool bLocalConnection = false;
          bool bLocalTransaction = false;

          try
          {
              #region CREAR CONEXIONES
              if (sqlConexion == null)
              {
                  sqlConexion = new SqlConnection(strConWs);
                  sqlConexion.Open();
                  bLocalConnection = true;
              }
              if (sqlTransaccion == null)
              {
                  sqlTransaccion = sqlConexion.BeginTransaction();
                  bLocalTransaction = true;
              }
              #endregion CREAR CONEXIONES

              SqlParameter[] parametros = new SqlParameter[2];
              parametros[0] = new SqlParameter("@vchUsuo", _mSeguridad.intIdUsuario);
              parametros[1] = new SqlParameter("@vchImagen", _mSeguridad.strvcImagen);

              DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spAddImagenUsuario", parametros);
              if (Convert.ToInt32(ds.Tables[0].Rows[0]["Respuesta"]) == 0)
              {
                  bRes = false;
              }
              else
              {
                  bRes = true;
              }
              if (bRes)
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Commit();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
              else
              {
                  if (bLocalTransaction)
                  {
                      sqlTransaccion.Rollback();
                      sqlTransaccion.Dispose();
                  }
                  if (bLocalConnection)
                  {
                      sqlConexion.Close();
                      sqlConexion.Dispose();
                  }
              }
          }
          catch (Exception ex)
          {
              if (bLocalTransaction)
              {
                  sqlTransaccion.Rollback();
                  sqlTransaccion.Dispose();
              }
              if (bLocalConnection)
              {
                  sqlConexion.Close();
                  sqlConexion.Dispose();
              }
              throw ex;
          }
          return bRes;
      }
      #endregion BOOL
             
     #region string    
        string strjson = "";
        public string jsonMenusUsuario()
        {
            try
            {
                string sprocname = "sp_MenuPorUsuario";
                string jsonOutputParam = "@jsonOutput";
                using (SqlConnection conn = new SqlConnection(strConWs))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sprocname, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        // Create output parameter. "-1" is used for nvarchar(max)
                        cmd.Parameters.Add("@nomina", SqlDbType.VarChar).Value = _mSeguridad.intNomina;
                        cmd.Parameters.Add("@APP", SqlDbType.VarChar).Value = _mSeguridad.intAplicacion;
                        cmd.Parameters.Add(jsonOutputParam, SqlDbType.NVarChar, -1).Direction = ParameterDirection.Output;

                        // Execute the command
                        cmd.ExecuteNonQuery();

                        // Get the values
                        strjson = cmd.Parameters[jsonOutputParam].Value.ToString();

                        Console.WriteLine(strjson);
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
            return strjson;
        }
        public string strJsonParametrosMail()
        {
            cn = new SqlConnection(strConWs);
            string strResult = "";
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@App", _mSeguridad.intAplicacion);

                strResult = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(cn, "spDatosEmail", parametros).ToString();
                //  strResult = Microsoft.ApplicationBlocks.Data.SqlHelper.re
            }
            catch (Exception ex)
            {
                strResult = "No se pudo completar la tarea";
            }
            cn.Close();
            cn.Dispose();
            return strResult;
        }
        public string strJsonApps()
        {
            cn = new SqlConnection(strConWs);
            string strResult = "";
            try
            {
                cn.Open();


                strResult = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(cn, "spObtieneApps").ToString();
                //  strResult = Microsoft.ApplicationBlocks.Data.SqlHelper.re
            }
            catch (Exception ex)
            {
                strResult = "No se pudo completar la tarea";
            }
            cn.Close();
            cn.Dispose();
            return strResult;
        }
        public string jsonCargaNivelSeguridad()
        {
            cn = new SqlConnection(strConWs);
            string regresa;
            try
            {
                cn.Open();

                regresa = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(cn, "spjsonNivelSeguridad").ToString();
            }
            catch (Exception ex)
            {
                regresa = "ERROR EN SELECT: " + ex;
            }
            cn.Close();
            cn.Dispose();
            return regresa;
        }
        public string strJsonCargarApps()
        {
            cn = new SqlConnection(strConWs);
            string strResult = "";
            try
            {
                cn.Open();


                strResult = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(cn, "spCargarApps").ToString();
                //  strResult = Microsoft.ApplicationBlocks.Data.SqlHelper.re
            }
            catch (Exception ex)
            {
                strResult = "No se pudo completar la tarea";
            }
            cn.Close();
            cn.Dispose();
            return strResult;
        }
        public string strJsonCargaAppsUsuario()
        {
            cn = new SqlConnection(strConWs);
            string strResult = "";
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@Usuario", _mSeguridad.intIdUsuario);

                strResult = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(cn, "spCargaAppsSeleccion", parametros).ToString();
                //  strResult = Microsoft.ApplicationBlocks.Data.SqlHelper.re
            }
            catch (Exception ex)
            {
                strResult = "No se pudo completar la tarea";
            }
            cn.Close();
            cn.Dispose();
            return strResult;
        }
        #endregion string
    
    }
}
