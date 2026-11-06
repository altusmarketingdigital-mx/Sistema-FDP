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
    public partial class FrmUsuariosPermisos : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        ElyonModelCxC.mCuentasC _mcuentas = new ElyonModelCxC.mCuentasC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
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
        public FrmUsuariosPermisos()
        {
            InitializeComponent();
        }
        public FrmUsuariosPermisos(DataSet dsParam)
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

        private void FrmUsuariosPermisos_Load(object sender, EventArgs e)
        {
            this.Text = MensajeProceso;
        }
        private void btnBuscaUsuario_Click(object sender, EventArgs e)
        {
            AppElyonCXC.Mantenimiento.FrmBuscaUsuario frbus = new Mantenimiento.FrmBuscaUsuario(0, _strConexion, _intIdApp, _mSeguridad);
            frbus.ShowDialog();

            _intIDUsuario = _mSeguridad.intIdUsuario;
            txtCveUsuario.Text = _mSeguridad.strUsuario;

            CargarValidaciones();
            CargaGrid();
        }
        private void Limpiar()
        {
            _intIDUsuario = 0;
            chkCajeroventa.Checked = false;
            chkCancelaVenta.Checked = false;
            chkSoloCancelaVenta.Checked = false;
            chkDescArticulo.Checked = false;
            chkSoloDescArticulo.Checked = false;
            chkModCantVenta.Checked = false;
            chkModSoloCantVenta.Checked = false;
            chkModPrecio.Checked = false;
            chkModSoloPrecio.Checked = false;
            chkPrecVenta.Checked = false;
            chkSoloPrecVenta.Checked = false;
            chkOtorgaDesc.Checked = false;
            chkSoloOtorgaDesc.Checked = false;
            chkModDtoCrediito.Checked = false;
            chkModSoloDtoCrediito.Checked = false;
            chkParidadMoneda.Checked = false;
            chkSoloParidadMoneda.Checked = false;
            chkAbreCajon.Checked = false;
            txtCveUsuario.Text = null;
            dgvAccesos.DataSource = null;
        }
        private void CargarValidaciones()
        {
            try
            {
                _mSeguridad.intIdUsuario = _intIDUsuario;
                DataSet dsVakusu = _mSeguridad.dsObtenerValidacionesUsuario();
                if (dsVakusu.Tables[0].Rows.Count > 0)
                {
                    int bCajeroventa = int.Parse(dsVakusu.Tables[0].Rows[0]["intCajeroVentas"].ToString());
                    int bCancelaVenta = int.Parse(dsVakusu.Tables[0].Rows[0]["intCancelaVenta"].ToString());
                    int bSoloCancelaVenta = int.Parse(dsVakusu.Tables[0].Rows[0]["intSoloCancelaVenta"].ToString());
                    int bDescArticulo = int.Parse(dsVakusu.Tables[0].Rows[0]["intDescripArticulo"].ToString());
                    int bSoloDescArticulo = int.Parse(dsVakusu.Tables[0].Rows[0]["intSoloDescripArticulo"].ToString());
                    int bModCantVenta = int.Parse(dsVakusu.Tables[0].Rows[0]["intCantidadVenta"].ToString());
                    int bModSoloCantVenta = int.Parse(dsVakusu.Tables[0].Rows[0]["intSoloCantidadVenta"].ToString());
                    int bModPrecio = int.Parse(dsVakusu.Tables[0].Rows[0]["intNoModPrecio"].ToString());
                    int bModSoloPrecio = int.Parse(dsVakusu.Tables[0].Rows[0]["intSoloNoModPrecio"].ToString());
                    int bPrecVenta = int.Parse(dsVakusu.Tables[0].Rows[0]["intPrecioVenta"].ToString());
                    int bSoloPrecVenta = int.Parse(dsVakusu.Tables[0].Rows[0]["intSoloPrecioVenta"].ToString());
                    int bOtorgaDesc = int.Parse(dsVakusu.Tables[0].Rows[0]["intOtorgaDesc"].ToString());
                    int bSoloOtorgaDesc = int.Parse(dsVakusu.Tables[0].Rows[0]["intSoloOtorgaDesc"].ToString());
                    int bModDtoCrediito = int.Parse(dsVakusu.Tables[0].Rows[0]["intModDatosCred"].ToString());
                    int bModSoloDtoCrediito = int.Parse(dsVakusu.Tables[0].Rows[0]["intSoloModDatosCred"].ToString());
                    int bParidadMoneda = int.Parse(dsVakusu.Tables[0].Rows[0]["intParidadMoneda"].ToString());
                    int bSoloParidadMoneda = int.Parse(dsVakusu.Tables[0].Rows[0]["intSoloParidadMoneda"].ToString());
                    int bAbreCajon = int.Parse(dsVakusu.Tables[0].Rows[0]["intAbreCajon"].ToString());

                    if (bCajeroventa == 1)
                    {
                        chkCajeroventa.Checked = true;
                    }
                    else
                    {
                        chkCajeroventa.Checked = false;
                    }

                    if (bCancelaVenta == 1)
                    {
                        chkCancelaVenta.Checked = true;
                    }
                    else
                    {
                        chkCancelaVenta.Checked = false;
                    }

                    if (bSoloCancelaVenta == 1)
                    {
                        chkSoloCancelaVenta.Checked = true;
                    }
                    else
                    {
                        chkSoloCancelaVenta.Checked = false;
                    }

                    if (bDescArticulo == 1)
                    {
                        chkDescArticulo.Checked = true;
                    }
                    else
                    {
                        chkDescArticulo.Checked = false;
                    }

                    if (bSoloDescArticulo == 1)
                    {
                        chkSoloDescArticulo.Checked = true;
                    }
                    else
                    {
                        chkSoloDescArticulo.Checked = false;
                    }

                    if (bModCantVenta == 1)
                    {
                        chkModCantVenta.Checked = true;
                    }
                    else
                    {
                        chkModCantVenta.Checked = false;
                    }

                    if (bModSoloCantVenta == 1)
                    {
                        chkModSoloCantVenta.Checked = true;
                    }
                    else
                    {
                        chkModSoloCantVenta.Checked = false;
                    }

                    if (bModPrecio == 1)
                    {
                        chkModPrecio.Checked = true;
                    }
                    else
                    {
                        chkModPrecio.Checked = false;
                    }

                    if (bModSoloPrecio == 1)
                    {
                        chkModSoloPrecio.Checked = true;
                    }
                    else
                    {
                        chkModSoloPrecio.Checked = false;
                    }

                    if (bPrecVenta == 1)
                    {
                        chkPrecVenta.Checked = true;
                    }
                    else
                    {
                        chkPrecVenta.Checked = false;
                    }

                    if (bSoloPrecVenta == 1)
                    {
                        chkSoloPrecVenta.Checked = true;
                    }
                    else
                    {
                        chkSoloPrecVenta.Checked = false;
                    }

                    if (bOtorgaDesc == 1)
                    {
                        chkOtorgaDesc.Checked = true;
                    }
                    else
                    {
                        chkOtorgaDesc.Checked = false;
                    }

                    if (bSoloOtorgaDesc == 1)
                    {
                        chkSoloOtorgaDesc.Checked = true;
                    }
                    else
                    {
                        chkSoloOtorgaDesc.Checked = false;
                    }

                    if (bModDtoCrediito == 1)
                    {
                        chkModDtoCrediito.Checked = true;
                    }
                    else
                    {
                        chkModDtoCrediito.Checked = false;
                    }

                    if (bModSoloDtoCrediito == 1)
                    {
                        chkModSoloDtoCrediito.Checked = true;
                    }
                    else
                    {
                        chkModSoloDtoCrediito.Checked = false;
                    }

                    if (bParidadMoneda == 1)
                    {
                        chkParidadMoneda.Checked = true;
                    }
                    else
                    {
                        chkParidadMoneda.Checked = false;
                    }

                    if (bSoloParidadMoneda == 1)
                    {
                        chkSoloParidadMoneda.Checked = true;
                    }
                    else
                    {
                        chkSoloParidadMoneda.Checked = false;
                    }

                    if (bAbreCajon == 1)
                    {
                        chkAbreCajon.Checked = true;
                    }
                    else
                    {
                        chkAbreCajon.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void CargaGrid()
        {
            try
            {
                _mSeguridad.intIdUsuario = _intIDUsuario;
                DataSet dtsConUsu = _mSeguridad.dsObtenerConsultaAccesosUsuarios();
                if (dtsConUsu.Tables[0].Rows.Count > 0)
                {
                    dgvAccesos.DataSource = dtsConUsu.Tables[0];
                    //dgvAccesos.Columns["ID"].Visible = false;
                }
                else
                {
                    dgvAccesos.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                dgvAccesos.DataSource = null;
                MessageBox.Show("ERROR en Procedimiento", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCargarUsuarios_Click(object sender, EventArgs e)
        {
            CargaGridUsuarios();
        }
        public void CargaGridUsuarios()
        {
            string strNom = "";


            //if (txtNombre.Text == "")
            //{
            //strNom = "";
            //}

            //strNom = txtNombre.Text;

            try
            {
                _mSeguridad.strConexion = _strConexion;
                _mSeguridad.intAplicacion = _intIdApp;
                _mSeguridad.strNombreUsuario = strNom.ToUpper();

                DataSet dsServ = _mSeguridad.dsBuscarPersonas();
                if (dsServ.Tables[0].Rows.Count > 0)
                {
                    ucgUsuarios.DataSource = dsServ.Tables[0];
                    ucgUsuarios.gvGrid.Columns["imagen"].Visible = false;
                    ucgUsuarios.gvGrid.Columns["estatus"].Visible = false;
                    ucgUsuarios.gvGrid.Columns["ADMIN"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void ucgUsuarios_cell_Datagrid_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _intIDUsuario = int.Parse(ucgUsuarios.gvGrid.Rows[e.RowIndex].Cells["usuarioID"].Value.ToString());
           
            CargarValidaciones();
            CargaGrid();
        }
    }
}
