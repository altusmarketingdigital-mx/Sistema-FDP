using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppElyonCXC.Catalogos
{
    public partial class Frm_Proveedores : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        ElyonModelCxC.mInventario _mInventario = new ElyonModelCxC.mInventario(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        #endregion

        #region Variables  
        int _Id_Proveedor;
        string NivelSeguridad;
        int UsuarioID;
        string MensajeProceso = "";
        string _strConexion = "";
        string _strConexionFin = "";
        int _intIdApp = 0;
        public static string _StrMat = "";
        string strValidaSeleccion = "";
        DataSet dsDatos = new DataSet();
        DataSet dsRes;
        bool _bUsuarioAdmin;
        string _IdPlantelUsuario = "";
        int _intIDMenu;
        string Usuario = "";
        string _strUsuario;
        string _intNivelId = "";
        string _strAcadPlan = "";
        string _strPlanCarrera = "";
        string _strGpoAcad = "";
        string _strMatricula = "";
        bool cmbcombo = false;
        int Idmenu = 0;
        bool regresa = false;
        int _intIDBanco;
        #endregion //Variables

        #region CONSTRUCTORES

        public Frm_Proveedores()
        {
            InitializeComponent();
        }

        public Frm_Proveedores(DataSet dsParam)
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad != "1")
            {
                try
                {
                    _mInventario.Id_Proveedor = _Id_Proveedor;
                    _mInventario.vchNombre_Proveedor = txtNombre.Text.ToString();
                    _mInventario.vchCalle_Proveedor = txtCalle.Text.ToString();
                    _mInventario.vchNoExt_Proveedor = txtNoExt.Text.ToString();
                    _mInventario.vchNoInt_Proveedor = txtNoInt.Text.ToString();
                    _mInventario.vchColonia_Proveedor = txtColonia.Text.ToString();
                    _mInventario.vchCp_Proveedor = txtCp.Text.ToString();
                    _mInventario.vchCiudad_Proveedor = txtCiudad.Text.ToString();
                    _mInventario.vchEstado_Proveedor = txtEstado.Text.ToString();
                    _mInventario.vchPais_Proveedor = txtPais.Text.ToString();
                    _mInventario.vchEmail_Proveedor = txtEmail.Text.ToString();
                    _mInventario.vchTelefono_Proveedor = txtTelefono.Text.ToString();
                    _mInventario.vchCelular_Proveedor = txtCelular.Text.ToString();
                    _mInventario.vchRfc_Proveedor = txtRfc.Text.ToString();
                    _mInventario.vchNoDeCuenta_Proveeddor = txtNoCuenta.Text.ToString();
                    _mInventario.intAccionProveedor = 1; 

                    DataSet dsProveedor = _mInventario.dsCatalogoProveedores();

                    if (Convert.ToInt32(dsProveedor.Tables[0].Rows[0]["respuesta"].ToString()) == 0)
                    {
                        MessageBox.Show("Registro Almacenado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Limpiar();
                        //CargaGrid();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Almacenar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("NO estas Autorizado para Actualizar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad != "1")
            {
                try
                {
                    dgv_Proveedor.DataSource = null;
                    _mInventario.intAccionProveedor = 4;

                    DataSet dsProveedor = _mInventario.dsCatalogoProveedores();

                    if (dsProveedor != null && dsProveedor.Tables.Count > 0)
                    {
                        dgv_Proveedor.DataSource = dsProveedor.Tables[0];

                        //COLUMNAS OCULTAS                    
                        //dgvEmpresa.gvGrid.Columns["Id_Plantel"].Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Almacenar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("NO estas Autorizado para Actualizar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad != "1")
            {
                try
                {
                    dgv_Proveedor.DataSource = null;
                    _mInventario.Id_Proveedor = Convert.ToInt32(txt_ClaveProveedor.Text.ToString());
                    _mInventario.intAccionProveedor = 6;

                    DataSet dsProveedor = _mInventario.dsCatalogoProveedores();

                    if (dsProveedor != null && dsProveedor.Tables.Count > 0)
                    {
                        dgv_Proveedor.DataSource = dsProveedor.Tables[0];

                        //COLUMNAS OCULTAS                    
                        //dgvEmpresa.gvGrid.Columns["Id_Plantel"].Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Almacenar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("NO estas Autorizado para Actualizar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                txtNombre.Text = "";
                txtCalle.Text = "";
                txtNoExt.Text = "";
                txtNoInt.Text = "";
                txtColonia.Text = "";
                txtCp.Text = "";
                txtCiudad.Text = "";
                txtEstado.Text = "";
                txtPais.Text = "";
                txtEmail.Text = "";
                txtTelefono.Text = "";
                txtCelular.Text = "";
                txtRfc.Text = "";
                txtNoCuenta.Text = "";
                dgv_Proveedor.DataSource = null;
            } catch (Exception ex) { }
        }
    }
}
