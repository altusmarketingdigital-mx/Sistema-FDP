using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace AppElyonCXC.Mantenimiento
{
    public partial class FrmAplicaciones : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        #endregion

        #region //Variables
        string NivelSeguridad;
        int UsuarioID;
        string MensajeProceso = "";
        string _strConexion = "";
        int intKeyApps = 0;
        bool regresa = false;
        string SiglasProceso = "";
        private int EstMenu;
        int intValida = 0;
        int _intIdApp = 0;
        string strtipoM;
        int _intArmaMenu = 0;
        DataSet dsDatos = new DataSet();
        int _intIDMenu;
        #endregion //Variables

        #region Constructores
        public FrmAplicaciones()
        {
            InitializeComponent();
        }
        public FrmAplicaciones(DataSet dsParam)
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
                _mSeguridad.strConexion = _strConexion;
                _intIDMenu = int.Parse(dsDatos.Tables["Parametros"].Rows[0][9].ToString());
            }
            _mSeguridad.ValidarBotones(this.Controls, UsuarioID, _intIDMenu);
        }
        #endregion Constructores

        private void FrmAplicaciones_Load(object sender, EventArgs e)
        {
            CargaGrid();
        }

        public void CargaGrid()
        {           
            try
            {
                string Apps;
                Apps = _mSeguridad.strJsonCargarApps();                
                DataTable DtApps = JsonConvert.DeserializeObject<DataTable>(Apps);

                ucGridApp.DataSource = DtApps;
                                                                              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ucGridApp_cell_Datagrid_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            intKeyApps = int.Parse(ucGridApp.gvGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            txtNombrecorto.Text = ucGridApp.gvGrid.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            txtNombrelargo.Text = ucGridApp.gvGrid.Rows[e.RowIndex].Cells["NombreLargo"].Value.ToString();
            chkEstatus.Checked = bool.Parse(ucGridApp.gvGrid.Rows[e.RowIndex].Cells["Estatus"].Value.ToString());
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
           Limpiar();
        }

        private void Limpiar()
        {
            intKeyApps = 0;
            txtNombrecorto.Text = null;
            txtNombrelargo.Text = null;
            chkEstatus.Checked = false;
            CargaGrid();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad != "1")
            {
                try
                {
                    _mSeguridad.intAplicacion = intKeyApps;
                    _mSeguridad.strNombreCortoApp = txtNombrecorto.Text;
                    _mSeguridad.strNombreLargoApp = txtNombrelargo.Text;
                    int bchk = 0;
                    if (chkEstatus.Checked == false)
                    {
                        bchk = 0;
                    }
                    else
                    {
                        bchk = 1;
                    }
                    _mSeguridad.intEstatus = bchk;

                    if (_mSeguridad.AltaAplicaciones())
                    {
                        MessageBox.Show("Registro Almacenado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaGrid();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Almacenar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                }
             }
            else
            {
                MessageBox.Show("NO estas Autorizado para Actualizar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpiar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad == "3")
            {
                _mSeguridad.intAplicacion = intKeyApps;
                regresa = _mSeguridad.EliminaAplicacion();

                if (regresa)
                {
                    MessageBox.Show("Registro Eliminado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargaGrid();
                }
                else
                {
                    MessageBox.Show("No se pudo Eliminar tiene Submenus registrados", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Limpiar();
            }
            else
            {
                MessageBox.Show("NO estas Autorizado para Eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpiar();
            }
        }
    }
}
