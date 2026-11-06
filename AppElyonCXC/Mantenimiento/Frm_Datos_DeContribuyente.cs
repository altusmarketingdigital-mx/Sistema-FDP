using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppElyonCXC.Mantenimiento
{
    public partial class Frm_Datos_DeContribuyente : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        ElyonModelCxC.mInventario _mInventario = new ElyonModelCxC.mInventario(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        Ticket _cticket = new Ticket();
        #endregion

        #region Variables 
        bool _bandera = false;
        DataTable dtbDatos = new DataTable();
        decimal total_final;
        string IP_Local;
        int _Id_Generar_Pedido;
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
        int Idmenu = 0;
        int _intProcesoAutomatico = 0;
        #endregion //Variables

        #region CONSTRUCTORES

        public Frm_Datos_DeContribuyente()
        {
            InitializeComponent();
        }

        public Frm_Datos_DeContribuyente(DataSet dsParam)
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

        #endregion CONSTRUCTORES

        private void dgv_Contribuyente_cell_Datagrid_ContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txt_RazonSocial.Text = dgv_Contribuyente.gvGrid.Rows[e.RowIndex].Cells["Razon_Social"].Value.ToString();
                txt_RFC.Text = dgv_Contribuyente.gvGrid.Rows[e.RowIndex].Cells["RFC"].Value.ToString();
                txt_Pais.Text = dgv_Contribuyente.gvGrid.Rows[e.RowIndex].Cells["Pais"].Value.ToString();
                txt_Estado.Text = dgv_Contribuyente.gvGrid.Rows[e.RowIndex].Cells["Estado"].Value.ToString();
                txt_Ciudad.Text = dgv_Contribuyente.gvGrid.Rows[e.RowIndex].Cells["Ciudad"].Value.ToString();
                txt_Calle.Text = dgv_Contribuyente.gvGrid.Rows[e.RowIndex].Cells["Calle"].Value.ToString();
                txt_No_Int.Text = dgv_Contribuyente.gvGrid.Rows[e.RowIndex].Cells["No_Int"].Value.ToString();
                txt_No_Ext.Text = dgv_Contribuyente.gvGrid.Rows[e.RowIndex].Cells["No_Ext"].Value.ToString();
                txt_Colonia.Text = dgv_Contribuyente.gvGrid.Rows[e.RowIndex].Cells["Colonia"].Value.ToString();
                txt_Codigo_Postal.Text = dgv_Contribuyente.gvGrid.Rows[e.RowIndex].Cells["Codigo_Postal"].Value.ToString();
                txt_Telefono.Text = dgv_Contribuyente.gvGrid.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                txt_Email.Text = dgv_Contribuyente.gvGrid.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnGuadar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad != "1")
            {
                try
                {
                    dgv_Contribuyente.DataSource = null;

                    _mInventario.Accion_Datos_Contribuyente = 2;
                    _mInventario.vchRazonSocial_Contribuyente = txt_RazonSocial.Text.ToString();
                    _mInventario.vchRFC_Contribuyente = txt_RFC.Text.ToString();
                    _mInventario.vchPais_Contribuyente = txt_Pais.Text.ToString();
                    _mInventario.vchEstado_Contribuyente = txt_Estado.Text.ToString();
                    _mInventario.vchCiudad_Contribuyente = txt_Ciudad.Text.ToString();
                    _mInventario.vchCalle_Contribuyente = txt_Calle.Text.ToString();
                    _mInventario.vchNoInt_Contribuyente = txt_No_Int.Text.ToString();
                    _mInventario.vchNoExt_Contribuyente = txt_No_Ext.Text.ToString();
                    _mInventario.vchColonia_Contribuyente = txt_Colonia.Text.ToString();
                    _mInventario.vchCodigoPostal_Contribuyente = txt_Codigo_Postal.Text.ToString();
                    _mInventario.vchTelefono_Contribuyente = txt_Telefono.Text.ToString();
                    _mInventario.vchEmail_Contribuyente = txt_Email.Text.ToString();

                    DataSet dsDepartamento = _mInventario.dsMantenimientoDatosContribuyente();

                    if (dsDepartamento != null && dsDepartamento.Tables.Count > 0)
                    {
                        MessageBox.Show("¡Información actualizada de forma correcta!", "DATOS DE CONTRIBUYENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarPantalla();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("NO estas Autorizado para Consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad != "1")
            {
                try
                {
                    dgv_Contribuyente.DataSource = null;

                    _mInventario.Accion_Datos_Contribuyente = 1;
                    DataSet dsContribuyente = _mInventario.dsMantenimientoDatosContribuyente();

                    if (dsContribuyente != null && dsContribuyente.Tables.Count > 0)
                    {
                        dgv_Contribuyente.DataSource = dsContribuyente.Tables[0];

                        //COLUMNAS OCULTAS                    
                        //dgv_Contribuyente.gvGrid.Columns["Id"].ReadOnly = true;
                        //dgv_Contribuyente.gvGrid.Columns["Departamento"].ReadOnly = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("NO estas Autorizado para Consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarPantalla();
        }

        private void LimpiarPantalla()
        {
            try
            {
                txt_RazonSocial.Text = "";
                txt_RFC.Text = "";
                txt_Pais.Text = "";
                txt_Estado.Text = "";
                txt_Ciudad.Text = "";
                txt_Calle.Text = "";
                txt_No_Int.Text = "";
                txt_No_Ext.Text = "";
                txt_Colonia.Text = "";
                txt_Codigo_Postal.Text = "";
                txt_Telefono.Text = "";
                txt_Email.Text = "";

                dgv_Contribuyente.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad != "1")
            {
                try
                {
                    _mInventario.Accion_Datos_Contribuyente = 3;
                    _mInventario.vchRFC_Contribuyente = txt_RFC.Text.ToString();
                    DataSet dsContribuyente = _mInventario.dsMantenimientoDatosContribuyente();

                    if (dsContribuyente != null && dsContribuyente.Tables.Count > 0)
                    {
                        txt_RazonSocial.Text = dsContribuyente.Tables[0].Rows[0]["Razon_Social"].ToString();
                        txt_RFC.Text = dsContribuyente.Tables[0].Rows[0]["RFC"].ToString();
                        txt_Pais.Text = dsContribuyente.Tables[0].Rows[0]["Pais"].ToString();
                        txt_Estado.Text = dsContribuyente.Tables[0].Rows[0]["Estado"].ToString();
                        txt_Ciudad.Text = dsContribuyente.Tables[0].Rows[0]["Ciudad"].ToString();
                        txt_Calle.Text = dsContribuyente.Tables[0].Rows[0]["Calle"].ToString();
                        txt_No_Int.Text = dsContribuyente.Tables[0].Rows[0]["No_Int"].ToString();
                        txt_No_Ext.Text = dsContribuyente.Tables[0].Rows[0]["No_Ext"].ToString();
                        txt_Colonia.Text = dsContribuyente.Tables[0].Rows[0]["Colonia"].ToString();
                        txt_Codigo_Postal.Text = dsContribuyente.Tables[0].Rows[0]["Codigo_Postal"].ToString();
                        txt_Telefono.Text = dsContribuyente.Tables[0].Rows[0]["Telefono"].ToString();
                        txt_Email.Text = dsContribuyente.Tables[0].Rows[0]["Email"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("NO estas Autorizado para Consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
