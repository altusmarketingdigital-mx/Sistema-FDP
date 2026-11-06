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
    public partial class Frm_Grupo : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        ElyonModelCxC.mInventario _mInventario = new ElyonModelCxC.mInventario(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        #endregion

        #region Variables  
        int _Id_Grupo;
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
        #endregion //Variables

        #region CONSTRUCTORES

        public Frm_Grupo()
        {
            InitializeComponent();
        }

        public Frm_Grupo(DataSet dsParam)
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
                    if (txtNombre.Text.Trim() != "")
                    {
                        _mInventario.Id_Grupo = _Id_Grupo;
                        _mInventario.vchNombre_Grupo = txtNombre.Text.Trim().ToString();
                        _mInventario.intAccionGrupo = 1;

                        DataSet dsProveedor = _mInventario.dsCatalogoGrupos();

                        if (Convert.ToInt32(dsProveedor.Tables[0].Rows[0]["respuesta"].ToString()) == 0)
                        {
                            MessageBox.Show("Registro Almacenado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLimpiar_Click(null, null);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Almacenar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else
                    {
                        MessageBox.Show("No puede guardar campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("NO estas Autorizado para Registrar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad != "1")
            {
                try
                {
                    dgv_Grupo.DataSource = null;
                    _mInventario.intAccionGrupo = 4;

                    DataSet dsProveedor = _mInventario.dsCatalogoGrupos();

                    if (dsProveedor != null && dsProveedor.Tables.Count > 0)
                    {
                        dgv_Grupo.DataSource = dsProveedor.Tables[0];

                        //COLUMNAS OCULTAS                    
                        dgv_Grupo.gvGrid.Columns["Id"].ReadOnly = true;
                        dgv_Grupo.gvGrid.Columns["Grupo"].ReadOnly = true;
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
                MessageBox.Show("NO estas Autorizado para Consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad != "1")
            {
                try
                {
                    if (txtNombre.Text.Trim() != "" && txt_ClaveGrupo.Text.Trim() != "")
                    {
                        _mInventario.Id_Grupo = _Id_Grupo;
                        _mInventario.intAccionGrupo = 3;

                        DataSet dsProveedor = _mInventario.dsCatalogoGrupos();

                        if (Convert.ToInt32(dsProveedor.Tables[0].Rows[0]["respuesta"].ToString()) == 0)
                        {
                            MessageBox.Show("Registro Eliminado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLimpiar_Click(null, null);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Eliminado Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else
                    {
                        MessageBox.Show("No puede eliminar campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("NO estas Autorizado para Eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                _Id_Grupo = 0;
                txt_ClaveGrupo.Text = "";
                txtNombre.Text = "";

                dgv_Grupo.DataSource = null; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgv_Grupo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _Id_Grupo = Convert.ToInt32(dgv_Grupo.gvGrid.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                txt_ClaveGrupo.Text = Convert.ToString(_Id_Grupo);
                txtNombre.Text = dgv_Grupo.gvGrid.Rows[e.RowIndex].Cells["Grupo"].Value.ToString();
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
                    if (txtNombre.Text.Trim() != "" && txt_ClaveGrupo.Text.Trim() != "")
                    {
                        _mInventario.Id_Grupo = _Id_Grupo;
                        _mInventario.vchNombre_Grupo = txtNombre.Text.Trim().ToString();
                        _mInventario.intAccionGrupo = 2;

                        DataSet dsProveedor = _mInventario.dsCatalogoGrupos();

                        if (Convert.ToInt32(dsProveedor.Tables[0].Rows[0]["respuesta"].ToString()) == 0)
                        {
                            MessageBox.Show("Registro Actualizado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLimpiar_Click(null, null);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Actualizar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else
                    {
                        MessageBox.Show("No puede actualizar campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
