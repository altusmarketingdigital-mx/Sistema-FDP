using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppElyonCXC.Reportes
{
    public partial class FrmRepClientes : Form
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
        DataSet dsRepBanco = null;
        #endregion VARIABLES PRIVADAS

        #region CONSTRUCTOR
        public FrmRepClientes()
        {
            InitializeComponent();
        }
        public FrmRepClientes(DataSet dsParam)
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
        private void FrmRepClientes_Load(object sender, EventArgs e)
        {
            this.Text = MensajeProceso;
            GenerarReporte();
        }
        private void GenerarReporte()
        {
            //Dataset Generado Antes
            int i = 0;
            dsClientes dsRepCliente = new dsClientes();
            try
            {

                dsRepBanco = _mcuentas.CargarReporteClientes();

                dsRepBanco.Tables[0].TableName = "dsCliente";


                #region  llena CargaEstadoCta
                DataRow drts;
                while (i < dsRepBanco.Tables["dsCliente"].Rows.Count)
                {
                    drts = dsRepCliente.Tables["dsCliente"].NewRow();
                    drts["ID"] = dsRepBanco.Tables["dsCliente"].Rows[i].ItemArray[0].ToString();
                    drts["Codigo"] = dsRepBanco.Tables["dsCliente"].Rows[i].ItemArray[1].ToString();
                    drts["Nombre"] = dsRepBanco.Tables["dsCliente"].Rows[i].ItemArray[2].ToString();
                    drts["RazonSocial"] = dsRepBanco.Tables["dsCliente"].Rows[i].ItemArray[3].ToString();
                    drts["Domiciio"] = dsRepBanco.Tables["dsCliente"].Rows[i].ItemArray[4].ToString();
                    drts["NoInterior"] = dsRepBanco.Tables["dsCliente"].Rows[i].ItemArray[5].ToString();
                    drts["NoExterior"] = dsRepBanco.Tables["dsCliente"].Rows[i].ItemArray[6].ToString();
                    drts["Colonia"] = dsRepBanco.Tables["dsCliente"].Rows[i].ItemArray[7].ToString();
                    drts["CP"] = dsRepBanco.Tables["dsCliente"].Rows[i].ItemArray[8].ToString();
                    drts["Estado"] = dsRepBanco.Tables["dsCliente"].Rows[i].ItemArray[9].ToString();
                    drts["Ciudad"] = dsRepBanco.Tables["dsCliente"].Rows[i].ItemArray[10].ToString();
                    drts["Email"] = dsRepBanco.Tables["dsCliente"].Rows[i].ItemArray[11].ToString();
                    drts["Telefono"] = dsRepBanco.Tables["dsCliente"].Rows[i].ItemArray[12].ToString();
                    drts["Contacto"] = dsRepBanco.Tables["dsCliente"].Rows[i].ItemArray[13].ToString();
                    drts["Estatus"] = dsRepBanco.Tables["dsCliente"].Rows[i].ItemArray[14].ToString();

                    dsRepCliente.Tables["dsCliente"].Rows.Add(drts);
                    i++;
                }
                #endregion  llena CargaEstadoCta

                if (dsRepCliente.Tables[0].Rows.Count > 0)
                {
                    //CrystalDecisions.CrystalReports.Engine.ReportDocument rdReporte = new Reportes.CrReporteClientes();
                    //rdReporte.SetDataSource(dsRepCliente);

                    //foreach (CrystalDecisions.CrystalReports.Engine.ReportDocument rptSubReporte in rdReporte.Subreports)
                    //{
                    //    if (rptSubReporte.Database.Tables.Count > 0)
                    //    {
                    //        rptSubReporte.SetDataSource(dsRepCliente);
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
                    dsRepCliente = null;
                    this.crvbancos.ReportSource = null;
                    this.crvbancos.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas al generar el reporte.", "Reporte Bancos");
                dsRepCliente = null;

                this.crvbancos.ReportSource = null;
                this.crvbancos.Hide();
            }
        }
    }
}
