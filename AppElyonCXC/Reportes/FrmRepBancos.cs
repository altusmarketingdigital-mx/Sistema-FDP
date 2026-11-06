using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppElyonCXC.Reportes
{
    public partial class FrmRepBancos : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        ElyonModelCxC.mCuentasC _mcuentas = new ElyonModelCxC.mCuentasC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        #endregion CONEXIONES LOCALES

        #region VARIABLES PRIVADAS
        DataSet dsDatos = new DataSet();
        string NivelSeguridad;
        int UsuarioID;
        string MensajeProceso = "";
        string _strConexion = "";
        string _strUsuario = "";
        int _intIdApp = 0;
        bool _bUsuarioAdmin;
        string _strConexionFin = "";
        string Usuario = "";
        string _IdPlantelUsuario = "";
        int Idmenu = 0;
        int _intIDMenu;
        string _intNivelId = "";
        string _strAcadPlan = "";
        string _strPlanCarrera = "";
        string _strGpoAcad = "";
        bool cmbcombo = false;
        string _strPeriodo;
        int _intFinanciera = 0;
        DataTable _dtDatos = new DataTable();
        DataSet dsRepBanco1 = null;
        #endregion VARIABLES PRIVADAS

        #region CONSTRUCTOR
        public FrmRepBancos()
        {
            InitializeComponent();
        }
        public FrmRepBancos(DataSet dsParam)
        {
            InitializeComponent();
            dsDatos = dsParam;            

            if (dsDatos.Tables[0].Rows.Count > 0)
            {
                UsuarioID = int.Parse(dsDatos.Tables["Parametros"].Rows[0][0].ToString());
                NivelSeguridad = dsDatos.Tables["Parametros"].Rows[0][1].ToString();
                MensajeProceso = dsDatos.Tables["Parametros"].Rows[0][2].ToString();
                _strConexion = dsDatos.Tables["Parametros"].Rows[0][3].ToString();
                _intIdApp = int.Parse(dsDatos.Tables["Parametros"].Rows[0][4].ToString());
                _strUsuario = UsuarioID.ToString();
                _strConexionFin = dsDatos.Tables["Parametros"].Rows[0][5].ToString();
                _bUsuarioAdmin = bool.Parse(dsDatos.Tables["Parametros"].Rows[0][6].ToString());
                Usuario = dsDatos.Tables[0].Rows[0]["UsuarioSistema"].ToString();
                _IdPlantelUsuario = dsDatos.Tables["Parametros"].Rows[0]["PLANTEL"].ToString();
                Idmenu = int.Parse(dsDatos.Tables["Parametros"].Rows[0]["IdMenu"].ToString());
                _intIDMenu = _mSeguridad.RegresaPkMenu(_intIdApp, this.Name);
            }
            _mSeguridad.ValidarBotones(this.Controls, UsuarioID, _intIDMenu);
        }
        #endregion CONSTRUCTOR
        private void FrmRepBancos_Load(object sender, EventArgs e)
        {
            this.Text = MensajeProceso;
            GenerarReporte();
        }
        private void GenerarReporte()
        {
            //Dataset Generado Antes
            int i = 0;
            dsBancos dsRepBancos = new dsBancos();
            try
            {

                dsRepBanco1 = _mcuentas.CargarReporteBancos();

                dsRepBanco1.Tables[0].TableName = "dtBancos";
                

                #region  llena CargaEstadoCta
                DataRow drts;
                while (i < dsRepBanco1.Tables["dtBancos"].Rows.Count)
                {
                    drts = dsRepBancos.Tables["dtBancos"].NewRow();
                    drts["ID"] = dsRepBanco1.Tables["dtBancos"].Rows[i].ItemArray[0].ToString();
                    drts["Clave"] = dsRepBanco1.Tables["dtBancos"].Rows[i].ItemArray[1].ToString();
                    drts["NombreBanco"] = dsRepBanco1.Tables["dtBancos"].Rows[i].ItemArray[2].ToString();
                    drts["NombreCorto"] = dsRepBanco1.Tables["dtBancos"].Rows[i].ItemArray[3].ToString();
                    drts["Estatus"] = dsRepBanco1.Tables["dtBancos"].Rows[i].ItemArray[4].ToString();
                    drts["ComisionCredito"] = dsRepBanco1.Tables["dtBancos"].Rows[i].ItemArray[5].ToString();
                    drts["ComsionDebito"] = dsRepBanco1.Tables["dtBancos"].Rows[i].ItemArray[6].ToString();
                    drts["ComsionChequeDevuelto"] = dsRepBanco1.Tables["dtBancos"].Rows[i].ItemArray[7].ToString();
                    dsRepBancos.Tables["dtBancos"].Rows.Add(drts);
                    i++;
                }
                #endregion  llena CargaEstadoCta
              
                if (dsRepBancos.Tables[0].Rows.Count > 0)
                {
                    //CrystalDecisions.CrystalReports.Engine.ReportDocument rdReporte = new Reportes.CrReporteBancos();
                    //rdReporte.SetDataSource(dsRepBancos);

                    //foreach (CrystalDecisions.CrystalReports.Engine.ReportDocument rptSubReporte in rdReporte.Subreports)
                    //{
                    //    if (rptSubReporte.Database.Tables.Count > 0)
                    //    {
                    //        rptSubReporte.SetDataSource(dsRepBancos);
                    //    }
                    //}

                    //rdReporte.SetParameterValue("PERIODO", cmbPeriodo.SelectedValue.ToString());
                    //rdReporte.SetParameterValue("Fecha", DateTime.Now);
                    //rdReporte.SetParameterValue("Cajero", (tstUsuario.Text.Equals("") ? "TODOS" : tstUsuario.Text));
                    //this.crvbancos.ReportSource = rdReporte;
                    this.crvbancos.Show();
                }
                else
                {
                    MessageBox.Show("No existen datos.", "Reporte Bancos.");
                    dsRepBancos = null;
                    this.crvbancos.ReportSource = null;
                    this.crvbancos.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas al generar el reporte.", "Reporte Bancos");
                dsRepBancos = null;

                this.crvbancos.ReportSource = null;
                this.crvbancos.Hide();
            }
        }
    }
}
