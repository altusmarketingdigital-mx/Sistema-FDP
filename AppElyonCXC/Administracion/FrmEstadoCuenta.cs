using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppElyonCXC.Administracion
{
    public partial class FrmEstadoCuenta : Form
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
        #endregion //Variables

        #region CONSTRUCTORES
        public FrmEstadoCuenta()
        {
            InitializeComponent();
        }
        public FrmEstadoCuenta(DataSet dsParam)
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

        private void FrmEstadoCuenta_Load(object sender, EventArgs e)
        {
            this.Text = MensajeProceso;
        }

        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {
            Administracion.FrmBuscarClientes frbusC = new Administracion.FrmBuscarClientes(2, _intIdApp, _mInventario);
            frbusC.ShowDialog();

            txtidCliente.Text = _mInventario.Id_Cliente.ToString();
            lblNombreSel.Text = _mInventario.strNombre;

            BuscarClientes();
            CargarNotas();
            CargarDevoluciones();
        }
        private void BuscarClientes()
        {
            try
            {
                _mInventario.Id_Cliente = int.Parse(txtidCliente.Text);
                DataSet dscl = _mInventario.dsClientesID();

                if(dscl.Tables[0].Rows.Count > 0)
                {
                    lblrfcSel.Text = dscl.Tables[0].Rows[0]["RFC"].ToString();
                    lblNombreSel.Text = dscl.Tables[0].Rows[0]["Nombre"].ToString();
                    lblTelefonoSel.Text = dscl.Tables[0].Rows[0]["Telefono"].ToString();
                    lblCorreoSel.Text = dscl.Tables[0].Rows[0]["Email"].ToString();
                }
                else
                {
                    lblrfcSel.Text = "Rfc...";
                    lblNombreSel.Text = "Nombre...";
                    lblTelefonoSel.Text = "33...";
                    lblCorreoSel.Text = "Email...";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Procedimiento fallo, busca cliente", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            BuscarClientes();
            CargarNotas();
            CargarDevoluciones();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void Limpiar()
        {
            lblrfcSel.Text = "Rfc...";
            lblNombreSel.Text = "Nombre...";
            lblTelefonoSel.Text = "33...";
            lblCorreoSel.Text = "Email...";
            txtidCliente.Text = null;
            ucGridDevoluciones.DataSource = null;
            ucGridNotasCredito.DataSource = null;
        }
        private void CargarNotas()
        {
            try
            {
                _mInventario.Id_Cliente = int.Parse(txtidCliente.Text);
                DataSet dsNr = _mInventario.dsObtenerNotasRemision();

                if (dsNr.Tables[0].Rows.Count > 0)
                {
                    ucGridNotasCredito.DataSource = dsNr.Tables[0];
                    ucGridNotasCredito.gvGrid.Columns["IDCAJERO"].Visible = false;
                }
                else
                {
                    ucGridNotasCredito.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Procedimiento fallo, busca cliente", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarDevoluciones()
        {
            try
            {
                _mInventario.Id_Cliente = int.Parse(txtidCliente.Text);
                DataSet dsNr = _mInventario.dsObtenerDevoluciones();

                if (dsNr.Tables[0].Rows.Count > 0)
                {
                    ucGridDevoluciones.DataSource = dsNr.Tables[0];
                    ucGridDevoluciones.gvGrid.Columns["PK_Id_Nota_Remision"].Visible = false;
                    ucGridDevoluciones.gvGrid.Columns["ACTIVO"].Visible = false;

                }
                else
                {
                    ucGridDevoluciones.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Procedimiento fallo, busca Devolucion", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
