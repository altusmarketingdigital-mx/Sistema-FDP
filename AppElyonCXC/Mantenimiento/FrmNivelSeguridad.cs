using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace AppElyonCXC.Mantenimiento
{
    public partial class FrmNivelSeguridad : Form
    {
        #region CONEXIONES 

        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        #endregion

        //Variables
        string NivelSeguridad;
        int UsuarioID;
        string strKeyNivelSeguridad = "0";
        int Perfil = 0;
        string MensajeProceso = "";
        string _strConexionAdmin = "";
        string _strConexion = "";
        string strKeyMenu = "0";
        bool regresa = false;
        string SiglasProceso = "";
        private int EstMenu;
        int intValida = 0;
        int _intIDMenu;     
        DataSet dsDatos = new DataSet();
        int busqueda = 0;

        public FrmNivelSeguridad()
        {
            InitializeComponent();
        }

        public FrmNivelSeguridad(DataSet dsParam)
        {
            InitializeComponent();

            dsDatos = dsParam;
            if (dsDatos.Tables[0].Rows.Count > 0)
            {
                UsuarioID = int.Parse(dsDatos.Tables["Parametros"].Rows[0][0].ToString());
                NivelSeguridad = dsDatos.Tables["Parametros"].Rows[0][1].ToString();
                MensajeProceso = dsDatos.Tables["Parametros"].Rows[0][2].ToString();
                _strConexion = dsDatos.Tables["Parametros"].Rows[0][3].ToString();
                _intIDMenu = int.Parse(dsDatos.Tables["Parametros"].Rows[0][9].ToString());
                _mSeguridad.strConexion = _strConexion;
            }

            _mSeguridad.ValidarBotones(this.Controls, UsuarioID, _intIDMenu);

        }

        private void FrmNivelSeguridad_Load(object sender, EventArgs e)
        {
            this.Text = MensajeProceso;
            //CargaGrid();
            CargaGridjson();
           
        }
              
        public void CargaGrid()
        {
            DataSet dsServ = new DataSet();

            try
            {
                dsServ = _mSeguridad.dsCargaNivelSeguridad();
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

        public void CargaGridjson()
        {
            DataTable dtv = new DataTable();

            try
            {
                string strCarga = _mSeguridad.jsonCargaNivelSeguridad();

                if (strCarga != "")
                {
                    dtv = (DataTable)JsonConvert.DeserializeObject(strCarga, (typeof(DataTable)));
                }

                if (dtv != null)
                {
                    this.dataGridView1.DataSource = dtv;
                    this.dataGridView1.DataMember = dtv.TableName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiar()
        {
            strKeyNivelSeguridad = "0";
            regresa = false;
            txtClave.Text = null;
            txtDescripcion.Text = null;
            cmbEstatus.Text = null;
            busqueda = 0;
        }
       
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string KeyCelda;
            DataSet dku = new DataSet();

            KeyCelda = dataGridView1.Rows[e.RowIndex].Cells["PK_NivelSeguridad"].Value.ToString();
            strKeyNivelSeguridad = KeyCelda;
            try
            {
                _mSeguridad.intNivSeguridad = int.Parse(KeyCelda);
                dku = _mSeguridad.dsObtieneNivelSeguridad();
                if (dku.Tables[0].Rows.Count > 0)
                {
                    busqueda = 1;
                    txtClave.Text = dku.Tables[0].Rows[0].ItemArray[1].ToString();
                    txtDescripcion.Text = dku.Tables[0].Rows[0].ItemArray[2].ToString();
                    cmbEstatus.Text = dku.Tables[0].Rows[0].ItemArray[3].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad != "1")
            {
                try
                {
                    string strEstatus = cmbEstatus.Text.Substring(0, 1);
                    _mSeguridad.intNivSeguridad = int.Parse(strKeyNivelSeguridad);
                    _mSeguridad.strClaveNivSeg = txtClave.Text;
                    _mSeguridad.strDescNivSeg = txtDescripcion.Text;
                    _mSeguridad.strStatusNivSeg = strEstatus;
                    regresa = _mSeguridad.AlmacenaNivelSeguridad();
                    if (regresa)
                    {
                        MessageBox.Show("Registro Almacenado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Almacenar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    limpiar();
                    CargaGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
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
            if (NivelSeguridad == "3")
            {
                try
                {
                    _mSeguridad.intNivSeguridad = int.Parse(strKeyNivelSeguridad);
                    regresa = _mSeguridad.EliminaNivelSeguridad();

                    if (regresa)
                    {
                        MessageBox.Show("Registro Eliminado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Eliminar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    limpiar();
                    CargaGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("NO estas Autorizado para Actualizar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpiar();
                CargaGrid();
            }
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            DataSet dsvc = new DataSet();
            int valor = 0;

            if (busqueda != 1)
            {
                try
                {
                    _mSeguridad.strClaveNivSeg = txtClave.Text;
                    dsvc = _mSeguridad.dsObtieneClaveNivelSeguridad();
                    if (dsvc.Tables[0].Rows.Count > 0)
                    {
                        valor = int.Parse(dsvc.Tables[0].Rows[0].ItemArray[0].ToString());
                    }

                    if (valor == 1)
                    {
                        MessageBox.Show("La clave ya existe Asignar otra", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtClave.Focus();
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
