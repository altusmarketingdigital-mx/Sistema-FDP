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
    public class mgrCuentasC
    {
        #region Referencia MODEL
        ElyonModelCxC.mCxC _mSeguridad;
        ElyonModelCxC.mCuentasC _mCuentasC;
        #endregion Referencia MODEL

        #region VARIABLES PRIVADAS                                                     
        DataSet dsDatos = new DataSet();
        SqlConnection cn;
        string strConWs = System.Configuration.ConfigurationManager.AppSettings["CUENTASC"];
        #endregion

        #region CONSTRUCTOR
        public mgrCuentasC(string strXML)
        {
            _mCuentasC = ElyonModelCxC.mCuentasC.FromXml(strXML);                
        }
        #endregion CONSTRUCTOR

        #region DATASET 
        public DataSet dsObtenerValiacionClaveBanco()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@intCveBanco", _mCuentasC.intClaveBanco);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSelValdaCveBancos", param);

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet CargarReporteEmpresas()
        {
            DataSet dsDatos = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {                
                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spRepEmpresas");
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet CargarReporteClientes()
        {
            DataSet dsDatos = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {               
                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spRepClientes");
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet CargarReporteVendedor()
        {
            DataSet dsDatos = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {               
                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spRepVendedor");
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet CargarReporteBancos()
        {
            DataSet dsDatos = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {               
                dsDatos = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spRepBancos");
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return dsDatos;
        }
        public DataSet dsCargarBancos() 
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                //SqlParameter[] param = new SqlParameter[1];
                //param[0] = new SqlParameter("@Plantel", _mCuentasC.strIdPlantel);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spCarga_Bancos");

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsObtenerEstados()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                //SqlParameter[] parametros = new SqlParameter[3];
                //parametros[0] = new SqlParameter("@Plantel", _meTimbrador.strPlantel);
                //parametros[1] = new SqlParameter("@rfc", _meTimbrador.strRfcs);
                //parametros[2] = new SqlParameter("@Matricula", _meTimbrador.strMatricula);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSelEstado");
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;

        }
        public DataSet dsObtenerCiudades()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@fkEstado", _mCuentasC.intEstado);
                //parametros[1] = new SqlParameter("@rfc", _meTimbrador.strRfcs);
                //parametros[2] = new SqlParameter("@Matricula", _meTimbrador.strMatricula);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSelCiudad", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;

        }
        public DataSet dsCargarvendedores() 
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                //SqlParameter[] param = new SqlParameter[1];
                //param[0] = new SqlParameter("@Plantel", _mCuentasC.strIdPlantel);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSelCargaVendedores");

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsBuscarvendedor()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Nomina", _mCuentasC.strNomina);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSelBuscaVendedor", param);

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsCargarClientes()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                //SqlParameter[] param = new SqlParameter[1];
                //param[0] = new SqlParameter("@Plantel", _mCuentasC.strIdPlantel);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSelCargaClientes");

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsBuscarClientes()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Codigo", _mCuentasC.strCodigoCliente);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSelBuscaClientes", param);

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsBuscarCliente()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@Nombres", _mCuentasC.strNombreCliente);               

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spBuscaClientes", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsCargarEmpresas()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                //SqlParameter[] param = new SqlParameter[1];
                //param[0] = new SqlParameter("@Plantel", _mCuentasC.strIdPlantel);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSelCargaEmpresas");

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsBuscarEmpresaCodigo()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ClaveEmp", _mCuentasC.strCodigoCliente);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSelBuscaEmpresas", param);

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsBuscarEmpresa()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@Nombres", _mCuentasC.strNombre);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spBuscaEmpresa", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsBuscarVendedorClienteEmpresa()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@NominaVendedor", _mCuentasC.strNomina);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSelBuscaVendedorClienteEmpresa", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsCargarvendedoresActivos()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                //SqlParameter[] param = new SqlParameter[1];
                //param[0] = new SqlParameter("@Plantel", _mCuentasC.strIdPlantel);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSelBuscaVendedorActivos");

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsBuscarClaveClienteEmpresa()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                cn.Open();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@NominaVendedor", _mCuentasC.strNomina);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSelBuscaClaveClienteEmpresa", parametros);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        #endregion DATASET 

        #region BOOL
        public bool bGuardarBancos()
        {
            SqlConnection sqlConexion = new SqlConnection(strConWs);
            sqlConexion.Open();
            SqlTransaction sqlTransaccion = sqlConexion.BeginTransaction();
            bool bRes = false;
            int bResultado = 0;

            try
            {

                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@PKIdBanco", _mCuentasC.intBancoID);                
                param[1] = new SqlParameter("@vchDescripcionBanco", _mCuentasC.strDescripcion);
                param[2] = new SqlParameter("@vchNombreBanco", _mCuentasC.strDescripcionCorta);
                param[3] = new SqlParameter("@bBanamex", _mCuentasC.bEstatus);
                param[4] = new SqlParameter("@intClaveBanco", _mCuentasC.intClaveBanco);
                param[5] = new SqlParameter("@dcComisionCredito", _mCuentasC.dcComisionCredito);
                param[6] = new SqlParameter("@dcComisionDebito", _mCuentasC.dcComisionDebito);
                param[7] = new SqlParameter("@dcComisionChequeDevuelto", _mCuentasC.dcComisionChequeDevuelto);

                DataSet DsBAluAlta = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spADDBanco", param);

                if (DsBAluAlta != null && DsBAluAlta.Tables.Count > 0 && DsBAluAlta.Tables[0].Rows.Count > 0)
                {
                    if (DsBAluAlta.Tables[0].Rows[0]["respuesta"].ToString().Equals("0"))
                    {
                        bRes = true;
                    }

                    bResultado = int.Parse(DsBAluAlta.Tables[0].Rows[0][1].ToString());
                }
            }
            catch (Exception ex)
            {
            }

            if (bRes)
                sqlTransaccion.Commit();
            else
                sqlTransaccion.Rollback();


            sqlTransaccion.Dispose();
            sqlConexion.Close();

            return bRes;
        }
        public bool bEliminaBancos()
        {
            SqlConnection sqlConexion = new SqlConnection(strConWs);
            sqlConexion.Open();
            SqlTransaction sqlTransaccion = sqlConexion.BeginTransaction();
            bool bRes = false;

            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@PKIdBanco", _mCuentasC.intBancoID);

                DataSet DsEstPro = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spDELBanco", param);

                if (DsEstPro != null && DsEstPro.Tables.Count > 0 && DsEstPro.Tables[0].Rows.Count > 0)
                {
                    if (DsEstPro.Tables[0].Rows[0]["respuesta"].ToString().Equals("0"))
                    {
                        bRes = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            if (bRes)
                sqlTransaccion.Commit();
            else
                sqlTransaccion.Rollback();


            sqlTransaccion.Dispose();
            sqlConexion.Close();

            return bRes;

        }
        public bool bGuardarVendedor()
        {
            SqlConnection sqlConexion = new SqlConnection(strConWs);
            sqlConexion.Open();
            SqlTransaction sqlTransaccion = sqlConexion.BeginTransaction();
            bool bRes = false;
            int bResultado = 0;

            try
            {

                SqlParameter[] param = new SqlParameter[20];
                param[0] = new SqlParameter("@idvendedor", _mCuentasC.intIDVendedor);
                param[1] = new SqlParameter("@vchNo_Nomina", _mCuentasC.strNomina);
                param[2] = new SqlParameter("@vchNombre", _mCuentasC.strNombre);
                param[3] = new SqlParameter("@vchPaterno", _mCuentasC.strApellidoPaterno);
                param[4] = new SqlParameter("@vchMaterno", _mCuentasC.strApellidoMaterno);
                param[5] = new SqlParameter("@dtFechaNacimiento", _mCuentasC.dtFecNac);
                param[6] = new SqlParameter("@vchDomicilio", _mCuentasC.strDomicilio);
                param[7] = new SqlParameter("@intNumeroInterior", _mCuentasC.intnoInterior);
                param[8] = new SqlParameter("@intNumeroExterior", _mCuentasC.intNoExterior);
                param[9] = new SqlParameter("@vchColonia", _mCuentasC.strColonia);
                param[10] = new SqlParameter("@vchCP", _mCuentasC.strCp);
                param[11] = new SqlParameter("@intEstado", _mCuentasC.intEstado);
                param[12] = new SqlParameter("@intCiudad", _mCuentasC.intciudad);
                param[13] = new SqlParameter("@vchEmail", _mCuentasC.strEmail);
                param[14] = new SqlParameter("@vchTelefono", _mCuentasC.strTelefono);
                param[15] = new SqlParameter("@vchFechaingreso", _mCuentasC.dtfecIngreso);
                param[16] = new SqlParameter("@vchFechaBaja", _mCuentasC.dtfecEgreso);
                param[17] = new SqlParameter("@vchDepartamento", _mCuentasC.strDepto);
                param[18] = new SqlParameter("@vchPuesto", _mCuentasC.strPuesto);
                param[19] = new SqlParameter("@bActivo", _mCuentasC.bEstatus);

                DataSet DsBAluAlta = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spAddVendedores", param);

                if (DsBAluAlta != null && DsBAluAlta.Tables.Count > 0 && DsBAluAlta.Tables[0].Rows.Count > 0)
                {
                    if (DsBAluAlta.Tables[0].Rows[0]["respuesta"].ToString().Equals("0"))
                    {
                        bRes = true;
                    }

                    bResultado = int.Parse(DsBAluAlta.Tables[0].Rows[0][1].ToString());
                }
            }
            catch (Exception ex)
            {
            }

            if (bRes)
                sqlTransaccion.Commit();
            else
                sqlTransaccion.Rollback();


            sqlTransaccion.Dispose();
            sqlConexion.Close();

            return bRes;
        }
        public bool bEliminaVendedor()
        {
            SqlConnection sqlConexion = new SqlConnection(strConWs);
            sqlConexion.Open();
            SqlTransaction sqlTransaccion = sqlConexion.BeginTransaction();
            bool bRes = false;

            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@idvendedor", _mCuentasC.intIDVendedor);

                DataSet DsEstPro = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spDelVendedores", param);

                if (DsEstPro != null && DsEstPro.Tables.Count > 0 && DsEstPro.Tables[0].Rows.Count > 0)
                {
                    if (DsEstPro.Tables[0].Rows[0]["respuesta"].ToString().Equals("0"))
                    {
                        bRes = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            if (bRes)
                sqlTransaccion.Commit();
            else
                sqlTransaccion.Rollback();


            sqlTransaccion.Dispose();
            sqlConexion.Close();

            return bRes;

        }
        public bool bGuardarCliente()
        {
            SqlConnection sqlConexion = new SqlConnection(strConWs);
            sqlConexion.Open();
            SqlTransaction sqlTransaccion = sqlConexion.BeginTransaction();
            bool bRes = false;
            int bResultado = 0;

            try
            {

                SqlParameter[] param = new SqlParameter[16];
                param[0] = new SqlParameter("@idCliente", _mCuentasC.intIDCliente);
                param[1] = new SqlParameter("@vchCodigoCliente", _mCuentasC.strCodigoCliente);
                param[2] = new SqlParameter("@vchNombreCliente", _mCuentasC.strNombreCliente);
                param[3] = new SqlParameter("@vchRazonSocial", _mCuentasC.strRazonSocial);
                param[4] = new SqlParameter("@vchRFC_Cliente", _mCuentasC.strRFC);                
                param[5] = new SqlParameter("@vchDomicilio", _mCuentasC.strDomicilioCliente);
                param[6] = new SqlParameter("@intNumeroInterior", _mCuentasC.intnoInteriorCliente);
                param[7] = new SqlParameter("@intNumeroExterior", _mCuentasC.intNoExteriorCliente);
                param[8] = new SqlParameter("@vchColonia", _mCuentasC.strColoniaCliente);
                param[9] = new SqlParameter("@vchCP", _mCuentasC.strCpCliente);
                param[10] = new SqlParameter("@intEstado", _mCuentasC.intEstado);
                param[11] = new SqlParameter("@intCiudad", _mCuentasC.intciudadCliente);
                param[12] = new SqlParameter("@vchEmail", _mCuentasC.strEmailCliente);
                param[13] = new SqlParameter("@vchTelefono", _mCuentasC.strTelefonoCliente);
                param[14] = new SqlParameter("@vchContacto", _mCuentasC.strContacto);                
                param[15] = new SqlParameter("@bActivo", _mCuentasC.bEstatus);

                DataSet DsBAluAlta = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spAddClientes", param);

                if (DsBAluAlta != null && DsBAluAlta.Tables.Count > 0 && DsBAluAlta.Tables[0].Rows.Count > 0)
                {
                    if (DsBAluAlta.Tables[0].Rows[0]["respuesta"].ToString().Equals("0"))
                    {
                        bRes = true;
                    }

                    bResultado = int.Parse(DsBAluAlta.Tables[0].Rows[0][1].ToString());
                }
            }
            catch (Exception ex)
            {
            }

            if (bRes)
                sqlTransaccion.Commit();
            else
                sqlTransaccion.Rollback();


            sqlTransaccion.Dispose();
            sqlConexion.Close();

            return bRes;
        }
        public bool bEliminaCliente()
        {
            SqlConnection sqlConexion = new SqlConnection(strConWs);
            sqlConexion.Open();
            SqlTransaction sqlTransaccion = sqlConexion.BeginTransaction();
            bool bRes = false;

            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@idCliente", _mCuentasC.intIDCliente);

                DataSet DsEstPro = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spDelClientes", param);

                if (DsEstPro != null && DsEstPro.Tables.Count > 0 && DsEstPro.Tables[0].Rows.Count > 0)
                {
                    if (DsEstPro.Tables[0].Rows[0]["respuesta"].ToString().Equals("0"))
                    {
                        bRes = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            if (bRes)
                sqlTransaccion.Commit();
            else
                sqlTransaccion.Rollback();


            sqlTransaccion.Dispose();
            sqlConexion.Close();

            return bRes;

        }
        public bool bGuardarEmpresa()
        {
            SqlConnection sqlConexion = new SqlConnection(strConWs);
            sqlConexion.Open();
            SqlTransaction sqlTransaccion = sqlConexion.BeginTransaction();
            bool bRes = false;
            int bResultado = 0;

            try
            {

                SqlParameter[] param = new SqlParameter[16];
                param[0] = new SqlParameter("@IDEmpresa", _mCuentasC.intIDEmpresa);
                param[1] = new SqlParameter("@vchClaveEmpresa", _mCuentasC.strClave);
                param[2] = new SqlParameter("@vchNombreEmpresa", _mCuentasC.strNombre);
                param[3] = new SqlParameter("@vchRazonSocial", _mCuentasC.strRazonSocial);
                param[4] = new SqlParameter("@vchRFCEmpresa", _mCuentasC.strRFC);
                param[5] = new SqlParameter("@vchDomicilio", _mCuentasC.strDomicilio);
                param[6] = new SqlParameter("@intNumeroInterior", _mCuentasC.intnoInterior);
                param[7] = new SqlParameter("@intNumeroExterior", _mCuentasC.intNoExterior);
                param[8] = new SqlParameter("@vchColonia", _mCuentasC.strColonia);
                param[9] = new SqlParameter("@vchCP", _mCuentasC.strCp);
                param[10] = new SqlParameter("@intEstado", _mCuentasC.intEstado);
                param[11] = new SqlParameter("@intCiudad", _mCuentasC.intciudad);
                param[12] = new SqlParameter("@vchEmail", _mCuentasC.strEmail);
                param[13] = new SqlParameter("@vchTelefono", _mCuentasC.strTelefono);
                param[14] = new SqlParameter("@vchContacto", _mCuentasC.strContacto);
                param[15] = new SqlParameter("@bActivo", _mCuentasC.bEstatus);

                DataSet DsBAluAlta = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spAddEmpresas", param);

                if (DsBAluAlta != null && DsBAluAlta.Tables.Count > 0 && DsBAluAlta.Tables[0].Rows.Count > 0)
                {
                    if (DsBAluAlta.Tables[0].Rows[0]["respuesta"].ToString().Equals("0"))
                    {
                        bRes = true;
                    }

                    bResultado = int.Parse(DsBAluAlta.Tables[0].Rows[0][1].ToString());
                }
            }
            catch (Exception ex)
            {
            }

            if (bRes)
                sqlTransaccion.Commit();
            else
                sqlTransaccion.Rollback();


            sqlTransaccion.Dispose();
            sqlConexion.Close();

            return bRes;
        }
        public bool bEliminaEmpresa()
        {
            SqlConnection sqlConexion = new SqlConnection(strConWs);
            sqlConexion.Open();
            SqlTransaction sqlTransaccion = sqlConexion.BeginTransaction();
            bool bRes = false;

            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@IDEmpresa", _mCuentasC.intIDEmpresa);

                DataSet DsEstPro = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spDelEmpresas", param);

                if (DsEstPro != null && DsEstPro.Tables.Count > 0 && DsEstPro.Tables[0].Rows.Count > 0)
                {
                    if (DsEstPro.Tables[0].Rows[0]["respuesta"].ToString().Equals("0"))
                    {
                        bRes = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            if (bRes)
                sqlTransaccion.Commit();
            else
                sqlTransaccion.Rollback();


            sqlTransaccion.Dispose();
            sqlConexion.Close();

            return bRes;

        }
        public bool bGuardarVendedorEmpresa()
        {
            SqlConnection sqlConexion = new SqlConnection(strConWs);
            sqlConexion.Open();
            SqlTransaction sqlTransaccion = sqlConexion.BeginTransaction();
            bool bRes = false;
            int bResultado = 0;

            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@idVendedor", _mCuentasC.intIDVendedor);
                param[1] = new SqlParameter("@idEmpresa", _mCuentasC.intIDEmpresa);               

                DataSet DsBAluAlta = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spADDVendedores_Empresas", param);

                if (DsBAluAlta != null && DsBAluAlta.Tables.Count > 0 && DsBAluAlta.Tables[0].Rows.Count > 0)
                {
                    if (DsBAluAlta.Tables[0].Rows[0]["respuesta"].ToString().Equals("0"))
                    {
                        bRes = true;
                    }

                    bResultado = int.Parse(DsBAluAlta.Tables[0].Rows[0][1].ToString());
                }
            }
            catch (Exception ex)
            {
            }

            if (bRes)
                sqlTransaccion.Commit();
            else
                sqlTransaccion.Rollback();


            sqlTransaccion.Dispose();
            sqlConexion.Close();

            return bRes;
        }
        public bool bGuardarVendedorClientes()
        {
            SqlConnection sqlConexion = new SqlConnection(strConWs);
            sqlConexion.Open();
            SqlTransaction sqlTransaccion = sqlConexion.BeginTransaction();
            bool bRes = false;
            int bResultado = 0;

            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@idVendedor", _mCuentasC.intIDVendedor);
                param[1] = new SqlParameter("@idCliente", _mCuentasC.intIDCliente);

                DataSet DsBAluAlta = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spADDVendedores_Clientes", param);

                if (DsBAluAlta != null && DsBAluAlta.Tables.Count > 0 && DsBAluAlta.Tables[0].Rows.Count > 0)
                {
                    if (DsBAluAlta.Tables[0].Rows[0]["respuesta"].ToString().Equals("0"))
                    {
                        bRes = true;
                    }

                    bResultado = int.Parse(DsBAluAlta.Tables[0].Rows[0][1].ToString());
                }
            }
            catch (Exception ex)
            {
            }

            if (bRes)
                sqlTransaccion.Commit();
            else
                sqlTransaccion.Rollback();


            sqlTransaccion.Dispose();
            sqlConexion.Close();

            return bRes;
        }
        public bool bEliminaVendedorEmpresa()
        {
            SqlConnection sqlConexion = new SqlConnection(strConWs);
            sqlConexion.Open();
            SqlTransaction sqlTransaccion = sqlConexion.BeginTransaction();
            bool bRes = false;

            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@idVendedor", _mCuentasC.intIDVendedor);
                param[1] = new SqlParameter("@idEmpresa", _mCuentasC.intIDEmpresa);

                DataSet DsEstPro = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spDELVendedores_Empresas", param);

                if (DsEstPro != null && DsEstPro.Tables.Count > 0 && DsEstPro.Tables[0].Rows.Count > 0)
                {
                    if (DsEstPro.Tables[0].Rows[0]["respuesta"].ToString().Equals("0"))
                    {
                        bRes = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            if (bRes)
                sqlTransaccion.Commit();
            else
                sqlTransaccion.Rollback();


            sqlTransaccion.Dispose();
            sqlConexion.Close();

            return bRes;

        }
        public bool bEliminaVendedorClientes()
        {
            SqlConnection sqlConexion = new SqlConnection(strConWs);
            sqlConexion.Open();
            SqlTransaction sqlTransaccion = sqlConexion.BeginTransaction();
            bool bRes = false;

            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@idVendedor", _mCuentasC.intIDVendedor);
                param[1] = new SqlParameter("@idCliente", _mCuentasC.intIDCliente);

                DataSet DsEstPro = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(sqlTransaccion, "spDELVendedores_Clientes", param);

                if (DsEstPro != null && DsEstPro.Tables.Count > 0 && DsEstPro.Tables[0].Rows.Count > 0)
                {
                    if (DsEstPro.Tables[0].Rows[0]["respuesta"].ToString().Equals("0"))
                    {
                        bRes = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            if (bRes)
                sqlTransaccion.Commit();
            else
                sqlTransaccion.Rollback();


            sqlTransaccion.Dispose();
            sqlConexion.Close();

            return bRes;

        }
        #endregion BOOL
    }
}
