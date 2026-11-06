using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppElyonCXC.Mantenimiento
{
    public partial class FrmTipoProceso : Form
    {

        #region CONEXIONES 
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        #endregion

        //Variables
        string NivelSeguridad;
        int UsuarioID;
        string MensajeProceso = "";        
        string _strConexion = "";
        string strKeyTipProceso = "0";
        bool regresa = false;
        int busqueda = 0;
        DataSet dsDatos = new DataSet();
        int _intIDMenu;

        public FrmTipoProceso()
        {
            InitializeComponent();
        }

        public FrmTipoProceso(DataSet dsParam)
        {
            InitializeComponent();

            dsDatos = dsParam;
            if (dsDatos.Tables[0].Rows.Count > 0)
            {
                UsuarioID = int.Parse(dsDatos.Tables["Parametros"].Rows[0][0].ToString());
                NivelSeguridad = dsDatos.Tables["Parametros"].Rows[0][1].ToString();
                MensajeProceso = dsDatos.Tables["Parametros"].Rows[0][2].ToString();
                _strConexion = dsDatos.Tables["Parametros"].Rows[0][3].ToString();               
                _mSeguridad.strConexion = _strConexion;
                _intIDMenu = int.Parse(dsDatos.Tables["Parametros"].Rows[0][9].ToString());
            }
            _mSeguridad.ValidarBotones(this.Controls, UsuarioID, _intIDMenu);
        }

        private void FrmTipoProceso_Load(object sender, EventArgs e)
        {
            this.Text = MensajeProceso;
            CargaGrid();
        }
       
        public void CargaGrid()
        {
            DataSet dsServ = new DataSet();

            try
            {
                dsServ = _mSeguridad.dsCargaTipoProceso();
                if (dsServ.Tables[0].Rows.Count > 0)
                {
                    this.dataGridView1.DataSource = dsServ;
                    this.dataGridView1.DataMember = dsServ.Tables[0].TableName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiar()
        {
            txtcveTipo.Text = null;
            txtDescripcion.Text = null;
            strKeyTipProceso = "0";
            regresa = false;
            busqueda = 0;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            
            frmPrincipal._intCierraForma = 0;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string KeyCelda;
            DataSet dku = new DataSet();

            if (dataGridView1.CurrentCell.ColumnIndex == 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["PK_TipoProceso"].Value.ToString() == "")
                {
                    MessageBox.Show("No existe dato registrado", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    KeyCelda = dataGridView1.Rows[e.RowIndex].Cells["PK_TipoProceso"].Value.ToString();
                    strKeyTipProceso = KeyCelda;
                    try
                    {
                        _mSeguridad.intTipoProceso = int.Parse(KeyCelda);
                        dku = _mSeguridad.dsObtieneDatosTipoProceso();
                        if (dku.Tables[0].Rows.Count > 0)
                        {
                            busqueda = 1;
                            txtcveTipo.Text = dku.Tables[0].Rows[0].ItemArray[1].ToString();
                            txtDescripcion.Text = dku.Tables[0].Rows[0].ItemArray[2].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Actualizar            
            if (NivelSeguridad != "1")
            {
                try
                {
                    _mSeguridad.intTipoProceso = int.Parse(strKeyTipProceso);
                    _mSeguridad.strClaveTipoProceso = txtcveTipo.Text;
                    _mSeguridad.strDescTipoProceso = txtDescripcion.Text;
                    //regresa = _mSeguridad.AlmacenaTipoProceso();
                    //if (regresa)
                    //{
                    //    MessageBox.Show("No se pudo Almacenar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    //else
                    //{
                    //    //Registro Almacenado con Exito                       
                    //    MessageBox.Show("Registro Almacenado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    limpiar();
                    CargaGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {

                MessageBox.Show("NO estas Autorizado para Actualizar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpiar();
                CargaGrid();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Eliminar            
            if (NivelSeguridad == "3")
            {
                try
                {
                    _mSeguridad.intTipoProceso = int.Parse(strKeyTipProceso);
                    //regresa = _mSeguridad.EliminaTipoProceso();

                    //if (regresa)
                    //{
                    //    MessageBox.Show("No se pudo Eliminar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Registro Eliminado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    limpiar();
                    CargaGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("NO estas Autorizado para Eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpiar();
                CargaGrid();
            }
        }

        private void txtcveTipo_TextChanged(object sender, EventArgs e)
        {
            DataSet dsvc = new DataSet();
            int valor = 0;

            if (busqueda != 1)
            {
                try
                {
                    _mSeguridad.strClaveTipoProceso = txtcveTipo.Text;
                    dsvc = _mSeguridad.dsObtieneClaveTipoProceso();
                    if (dsvc.Tables[0].Rows.Count > 0)
                    {
                        valor = int.Parse(dsvc.Tables[0].Rows[0].ItemArray[0].ToString());
                    }

                    if (valor == 1)
                    {
                        MessageBox.Show("La clave ya existe Asignar otra", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtcveTipo.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

    }
}
