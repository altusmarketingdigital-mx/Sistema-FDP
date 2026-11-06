using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace AppElyonCXC.Mantenimiento
{
    public partial class FrmCargarAvisos : Form
    {
        #region CONEXIONES 
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        #endregion

        //Variables
        string NivelSeguridad;
        int UsuarioID;
        string MensajeProceso = "";
        string _strConexion = "";
        string strKeyIdAviso = "0";
        bool regresa = false;
        int busqueda = 0;
        string ImagenSerializada = "";
        DataSet dsDatos = new DataSet();
        int _intIDMenu;
        public FrmCargarAvisos()
        {
            InitializeComponent();
        }

        public FrmCargarAvisos(DataSet dsParam)
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

        private void FrmCargarAvisos_Load(object sender, EventArgs e)
        {
            this.Text = MensajeProceso;
            CargaGrid();
            ObtieneUltimoId();
        }

        public void CargaGrid()
        {
            DataSet dsServ = new DataSet();

            try
            {
                dsServ = _mSeguridad.dsCargaTotalAvisos();
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

        private void ObtieneUltimoId()
        {
            
            DataSet dkt = _mSeguridad.dsTotalAvisos();
            if (dkt.Tables[0].Rows.Count > 0)
            {                
                txtorden.Text = dkt.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            else { txtorden.Text = "0"; }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int _activo = 0;
            if (cmbestatus.Text == "Activa")
            {                
                _activo = 1;
            }
            if (cmbestatus.Text == "Inactiva")
            {
                _activo = 0;
            }

            //Serializa la Imagen del picture box
            ImagenSerializada = ImageToString(pboxImagen.Image);

            _mSeguridad.intOrden = int.Parse(txtorden.Text);
            _mSeguridad.strImgSerializada = ImagenSerializada;
            _mSeguridad.intEstatus = _activo;
            _mSeguridad.intIDAviso = int.Parse(strKeyIdAviso);

            if (_mSeguridad.AlmacenaImagenSerializada())
            {
                MessageBox.Show("Imagen Cargada con exito", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargaGrid();
                Limpiar();
            }
            else
            {
                MessageBox.Show("ERROR, la Imagen no pudo ser cargada", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = openFileDialog1.FileName;

                //Carga Foto
                pboxImagen.ImageLocation = txtRuta.Text;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnExaminar.Focus();
            }
        }

        //Metodos para Serializar las Imagenes(
        public string ImageToString(Image img)
        {
            try
            {
                MemoryStream ms = new MemoryStream();

                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                byte[] array = ms.ToArray();

                return Convert.ToBase64String(array);
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private void txtorden_Validating(object sender, CancelEventArgs e)
        {            
            if (!IsNumber(txtorden.Text))
            {                                
                MessageBox.Show("Debe ingresar un numero valido","ERROR de Validacion");
                txtorden.Focus();
            }


        }

        public bool IsNumber(string inputvalue)
        {
            try
            {
                double x = Convert.ToDouble(inputvalue);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            strKeyIdAviso = "0";
            ObtieneUltimoId();
            txtRuta.Text = null;
            cmbestatus.Text = "";
            pboxImagen.Image = null;
            txtorden.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string KeyCelda;
            DataSet dku = new DataSet();

            if (dataGridView1.CurrentCell.ColumnIndex == 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["PK_AvisoImg"].Value.ToString() == "")
                {
                    MessageBox.Show("No existe dato registrado", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    KeyCelda = dataGridView1.Rows[e.RowIndex].Cells["PK_AvisoImg"].Value.ToString();
                    strKeyIdAviso = KeyCelda;
                    try
                    {
                        _mSeguridad.intIDAviso = int.Parse(KeyCelda);
                        dku = _mSeguridad.dsObtieneAvisosKeys();
                        if (dku.Tables[0].Rows.Count > 0)
                        {
                            busqueda = 1;  
                            txtorden.Text = dku.Tables[0].Rows[0].ItemArray[1].ToString();
                            pboxImagen.Image = StringToImage(dku.Tables[0].Rows[0].ItemArray[2].ToString());                            
                            pboxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                            string est = dku.Tables[0].Rows[0].ItemArray[3].ToString();

                            if (est == "1")
                            {
                                cmbestatus.Text = "Activa";
                            }
                            if (est == "0")
                            {
                                cmbestatus.Text = "Inactiva";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        //Desserializa la Imagen
        public Image StringToImage(string imageString)
        {

            if (imageString == null)

                throw new ArgumentNullException("imageString");

            byte[] array = Convert.FromBase64String(imageString);

            System.Drawing.Image image = System.Drawing.Image.FromStream(new MemoryStream(array));

            return image;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad == "3")
            {
                try
                {
                    _mSeguridad.intIDAviso = int.Parse(strKeyIdAviso);
                    regresa = _mSeguridad.EliminaAvisos();

                    if (regresa)
                    {
                        MessageBox.Show("Registro Eliminado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Eliminar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    CargaGrid();
                    Limpiar();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("NO estas Autorizado para Eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpiar();

            }
        }
    }
}
