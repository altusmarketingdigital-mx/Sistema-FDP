using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace AppElyonCXC.Reportes
{
    public partial class FrmReporteMovimientos : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        ElyonModelCxC.mCuentasC _mcuentas = new ElyonModelCxC.mCuentasC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        ElyonModelCxC.mInventario _mInventario = new ElyonModelCxC.mInventario(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        #endregion

        #region //Variables        
        string NivelSeguridad;
        int UsuarioID;
        string MensajeProceso = "";
        string _strConexion = "";
        string _strConexionFin = "";
        int _intIdApp = 0;
        public static string _StrMat = "";
        DataSet dsDatos = new DataSet();
        bool _bUsuarioAdmin;
        string _IdPlantelUsuario = "";
        int _intIDMenu;
        string Usuario = "";
        string _strUsuario;
        bool cmbcombo = false;
        int Idmenu = 0;
        bool regresa = false;
        int _intIDUsuario = 0;
        int _intIDValidaUsuario = 0;

        public static string strIdUsuario = "0";
        public static string strClaveUsuario = "";
        DataSet dsrpd;
        #endregion //Variables

        #region CONSTRUCTORES
        public FrmReporteMovimientos()
        {
            InitializeComponent();
        }
        public FrmReporteMovimientos(DataSet dsParam)
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
                //_IdPlantelUsuario = dsDatos.Tables["Parametros"].Rows[0]["PLANTEL"].ToString();
                Idmenu = int.Parse(dsDatos.Tables["Parametros"].Rows[0]["IdMenu"].ToString());
                _intIDMenu = _mSeguridad.RegresaPkMenu(_intIdApp, this.Name);
            }
            _mSeguridad.ValidarBotones(this.Controls, UsuarioID, _intIDMenu);
        }
        #endregion CONSTRUCTORES

        private void FrmReporteMovimientos_Load(object sender, EventArgs e)
        {
            this.Text = MensajeProceso;
            btnBuscaCliente.Visible = false;
            lblTipo.Visible = false;
            txtTipo.Visible = false;
            crystalReportViewer1.Visible = false;
            ucGridMov.Visible = false;
        }

        private void cmbMovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMovimiento.Text == "No. Cliente")
            {
                lblTipo.Text = "No. Cliente";
                btnBuscaCliente.Visible = true;
                lblTipo.Visible = true;
                txtTipo.Visible = true;
            }
            if (cmbMovimiento.Text == "No. Pedido")
            {
                lblTipo.Text = "No.Pedido";
                btnBuscaCliente.Visible = true;
                lblTipo.Visible = true;
                txtTipo.Visible = true;
            }
            if (cmbMovimiento.Text == "No. Nota Remision")
            {
                lblTipo.Text = "No. Nota Remision";
                btnBuscaCliente.Visible = true;
                lblTipo.Visible = true;
                txtTipo.Visible = true;
            }
            if (cmbMovimiento.Text == "No. Pago")
            {
                lblTipo.Text = "No. Pago";
                btnBuscaCliente.Visible = true;
                lblTipo.Visible = true;
                txtTipo.Visible = true;
            }
        }

        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {
            if (cmbMovimiento.Text == "No. Cliente")
            {
                Administracion.FrmBuscarClientes frbusC = new Administracion.FrmBuscarClientes(2, _intIdApp, _mInventario);
                frbusC.ShowDialog();

                txtTipo.Text = _mInventario.Id_Cliente.ToString();
            }
            if (cmbMovimiento.Text == "No. Pedido")
            {
                Administracion.FrmBuscarPedidos frBuscP = new Administracion.FrmBuscarPedidos(2, _intIdApp, _mInventario);
                frBuscP.ShowDialog();
                txtTipo.Text = _mInventario.Id_Pedidos.ToString();
            }

            if (cmbMovimiento.Text == "No. Nota Remision")
            {
                Administracion.FrmBuscaNotaRemision frBuscN = new Administracion.FrmBuscaNotaRemision(2, _intIdApp, _mInventario);
                frBuscN.ShowDialog();
                txtTipo.Text = _mInventario.Id_NotaRemision.ToString();
            }

            if (cmbMovimiento.Text == "No. Pago")
            {
                Administracion.FrmBuscaPagos frBuscPg = new Administracion.FrmBuscaPagos(2, _intIdApp, _mInventario);
                frBuscPg.ShowDialog();
                txtTipo.Text = _mInventario.Id_Pagos.ToString();
            }
        }

        private void btngenerar_Click(object sender, EventArgs e)
        {
            if (chkGrid.Checked == true)
            {
                this.crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Visible = false;
                ucGridMov.Visible = true;
                GenereGrid();
            }
            else
            {
                ucGridMov.DataSource = null;
                ucGridMov.Visible = false;
                crystalReportViewer1.Visible = true;
                GeneraReporte();
            }
        }

        private void GenereGrid()
        {
            try
            {
                _mInventario.strDescripcion = cmbMovimiento.Text;
                _mInventario.intTipoMov = int.Parse(txtTipo.Text);

                //DataSet dsrpd = _mtesoreria.dsobtieneInformeCierre();
                Thread tAux = new Thread(new ThreadStart(ejecutarCalculo));
                tAux.Start();
                while (!tAux.IsAlive) ;

                // ---------  Cargamos y mostramos el formulario Progress bar  -------
                AppElyonCXC.Mantenimiento.FrmProgresBar f1 = new Mantenimiento.FrmProgresBar(5, tAux);
                f1.ShowDialog();


                if (dsrpd.Tables[0].Rows.Count > 0)
                {
                    ucGridMov.DataSource = dsrpd.Tables[0];
                }
                else
                {
                    ucGridMov.DataSource = null;
                }
            }
            catch(Exception ex)
            {
                ucGridMov.DataSource = null;
            }
        }

        private void GeneraReporte()
        {
            this.crystalReportViewer1.ReportSource = null;
            int i = 0;
            DsRepMovimientos dsRepInforme = new DsRepMovimientos();

            try
            {
                _mInventario.strDescripcion = cmbMovimiento.Text;
                _mInventario.intTipoMov = int.Parse(txtTipo.Text);

                //DataSet dsrpd = _mtesoreria.dsobtieneInformeCierre();
                Thread tAux = new Thread(new ThreadStart(ejecutarCalculo));
                tAux.Start();
                while (!tAux.IsAlive) ;

                // ---------  Cargamos y mostramos el formulario Progress bar  -------
                AppElyonCXC.Mantenimiento.FrmProgresBar f1 = new Mantenimiento.FrmProgresBar(5, tAux);
                f1.ShowDialog();


                if (dsrpd.Tables[0].Rows.Count > 0)
                {
                    //DataSet dsReporte = dsrpd.Copy();
                    dsrpd.Tables[0].TableName = "dtRepMovimiento";
                                      
                    #region  llena dtSaldo_Usuario
                    DataRow drts;
                    while (i < dsrpd.Tables["dtRepMovimiento"].Rows.Count)
                    {
                        drts = dsRepInforme.Tables["dtRepMovimiento"].NewRow();
                        drts["ID"] = dsrpd.Tables["dtRepMovimiento"].Rows[i]["ID"].ToString();
                        drts["idCliente"] = dsrpd.Tables["dtRepMovimiento"].Rows[i]["idCliente"].ToString();
                        drts["NombreCliente"] = dsrpd.Tables["dtRepMovimiento"].Rows[i]["NombreCliente"].ToString();
                        drts["RFC"] = dsrpd.Tables["dtRepMovimiento"].Rows[i]["RFC"].ToString();
                        drts["IDPedido"] = dsrpd.Tables["dtRepMovimiento"].Rows[i]["IDPedido"].ToString();
                        drts["Folio"] = dsrpd.Tables["dtRepMovimiento"].Rows[i]["Folio"].ToString();
                        drts["FechaVentaPedido"] = dsrpd.Tables["dtRepMovimiento"].Rows[i]["FechaVentaPedido"].ToString();
                        drts["IDNotaRemision"] = dsrpd.Tables["dtRepMovimiento"].Rows[i]["IDNotaRemision"].ToString();
                        drts["FechaNotaRemision"] = dsrpd.Tables["dtRepMovimiento"].Rows[i]["FechaNotaRemision"].ToString();
                        drts["IDCajeroNota"] = dsrpd.Tables["dtRepMovimiento"].Rows[i]["IDCajeroNota"].ToString();
                        drts["NombreCajeroNota"] = dsrpd.Tables["dtRepMovimiento"].Rows[i]["NombreCajeroNota"].ToString();
                        drts["EstatusNotas"] = dsrpd.Tables["dtRepMovimiento"].Rows[i]["EstatusNotas"].ToString();
                        drts["IDCancelar"] = dsrpd.Tables["dtRepMovimiento"].Rows[i]["IDCancelar"].ToString();
                        drts["FechaCancelar"] = dsrpd.Tables["dtRepMovimiento"].Rows[i]["FechaCancelar"].ToString();
                        drts["IDCajeroCancela"] = dsrpd.Tables["dtRepMovimiento"].Rows[i]["IDCajeroCancela"].ToString();
                        drts["NombreCajeroCancela"] = dsrpd.Tables["dtRepMovimiento"].Rows[i]["NombreCajeroCancela"].ToString();
                        drts["IDPago"] = dsrpd.Tables["dtRepMovimiento"].Rows[i]["IDPago"].ToString();
                        drts["SaldoAnterior"] = dsrpd.Tables["dtRepMovimiento"].Rows[i]["SaldoAnterior"].ToString();
                        drts["SaldoNuevo"] = dsrpd.Tables["dtRepMovimiento"].Rows[i]["SaldoNuevo"].ToString();
                        drts["FechaTimbrado"] = dsrpd.Tables["dtRepMovimiento"].Rows[i]["FechaTimbrado"].ToString();

                        dsRepInforme.Tables["dtRepMovimiento"].Rows.Add(drts);
                        i++;
                    }
                    #endregion  llena dtSaldo_Usuario  

                    if (dsRepInforme.Tables[0].Rows.Count > 0)
                    {

                        CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new rptRepMovimientos();

                        rd.SetDataSource(dsRepInforme);
                        foreach (CrystalDecisions.CrystalReports.Engine.ReportDocument sr in rd.Subreports)
                        {
                            if (sr.Database.Tables.Count > 0)
                            {
                                sr.SetDataSource(dsRepInforme);
                            }
                        }

                        //rd.SetParameterValue("Cajero", (txtUsuario.Text.Equals("") ? "TODOS" : txtUsuario.Text));
                        //rd.SetParameterValue("Fechainicial", dtFechainicial.Value);
                        //rd.SetParameterValue("FechaFinal", dtFechaFinal.Value);

                        this.crystalReportViewer1.ReportSource = rd;
                        this.crystalReportViewer1.Show();
                    }
                }
                else
                {
                    MessageBox.Show("No hay datos a cargar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.crystalReportViewer1.ReportSource = null;
                }
            }
            catch (Exception ex) { }
        }
        private void ejecutarCalculo()
        {
            try
            {
                dsrpd = _mInventario.dsReporteMovimientos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
