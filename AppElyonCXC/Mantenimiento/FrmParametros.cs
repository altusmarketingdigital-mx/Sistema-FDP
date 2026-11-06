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
    public partial class FrmParametros : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        //mSeguridadElyon.mSeguridad _mfinanciera = new mSeguridadElyon.mSeguridad();
        //mSeguridadElyon.mSeguridad _mSeguridad = new mSeguridadElyon.mSeguridad();
        #endregion

        #region Variables
        string Usuario = "";
        int inttot = 0;
        string NivelSeguridad;
        int UsuarioID;
        string MensajeProceso = "";
        string _strConexion = "";
        string _strConexionFin = "";
        int _intIdApp = 0;
        DataSet dsDatos = new DataSet();
        bool _bUsuarioAdmin;
        string _strUsuario;
        string _idBecaRH = "0";
        string _strMat = "";
        string _per = "";
        int _IdPlantelUsuario = 0;
        int intParametrosKey = 0;
        int regresa = 0;
        #endregion Variables

        #region CONSTRUCTORES
        public FrmParametros()
        {
            InitializeComponent();
        }
        public FrmParametros(DataSet dsParam)
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
                //_mfinanciera.strConexion = _strConexion;
                _strUsuario = UsuarioID.ToString();
                _strConexionFin = dsDatos.Tables["Parametros"].Rows[0][5].ToString();
                _bUsuarioAdmin = bool.Parse(dsDatos.Tables["Parametros"].Rows[0][6].ToString());
                Usuario = dsDatos.Tables[0].Rows[0]["UsuarioSistema"].ToString();
                //_IdPlantelUsuario = int.Parse(dsDatos.Tables["Parametros"].Rows[0]["PLANTEL"].ToString());
            }
        }
        #endregion CONSTRUCTORES
        private void FrmParametros_Load(object sender, EventArgs e)
        {
            this.Text = MensajeProceso;
            cargaGrid();           
        }      
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void limpiar()
        {
            txtfolio.Text = "";            
            txtServSalida.Text = "";
            txtPuertoSalida.Text = "";
            txtUsuServ.Text = "";
            txtCveServ.Text = "";            
            cmbVigente.Text = "";
            txtrutaimagen.Text = "";          
        }
       
        private void cargaGrid()
        {
            DataSet dsMns = new DataSet();
            try
            {
                dsMns = _mSeguridad.ObtenerParametros();
                if (dsMns.Tables[0].Rows.Count > 0)
                {
                    this.dataGridView1.DataSource = dsMns;
                    this.dataGridView1.DataMember = dsMns.Tables[0].TableName;


                }
                else
                {
                    MessageBox.Show("No hay datos que cargar", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {            
            //Actualizar            
            if (NivelSeguridad != "1")
            {
                try
                {
                    _mSeguridad.intParametro = intParametrosKey;
                    _mSeguridad.intAplicacion = _intIdApp;
                    _mSeguridad.intFolio = int.Parse(txtfolio.Text);
                    _mSeguridad.strServidorSalida = txtServSalida.Text;
                    _mSeguridad.strPuertoSalida = txtPuertoSalida.Text;
                    _mSeguridad.strUsuarioEnvia = txtUsuServ.Text;
                    _mSeguridad.strContraseñaEnvia = txtCveServ.Text;
                    if (cmbVigente.Text == "1")
                    {
                        _mSeguridad.intEstatus = 1;
                    }
                    else
                    {
                        _mSeguridad.intEstatus = 0;
                    }
                    _mSeguridad.strRutaImagen = txtrutaimagen.Text;                    
                    
                    //if (_mSeguridad.AlmacenaParametros())
                    //{
                    //    MessageBox.Show("Registro Almacenado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    //else
                    //{                        
                    //    MessageBox.Show("No se pudo Almacenar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    limpiar();
                    cargaGrid();
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
                cargaGrid();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Eliminar            
            if (NivelSeguridad == "3")
            {
                try
                {
                    _mSeguridad.intParametro = intParametrosKey;
                    _mSeguridad.intAplicacion = _intIdApp;                    

                    //if (_mSeguridad.EliminaParametros())
                    //{
                    //    MessageBox.Show("Registro Eliminado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    //}
                    //else
                    //{
                    //    MessageBox.Show("No se pudo Almacenar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    limpiar();
                    cargaGrid();
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
                cargaGrid();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtrutaimagen.Text = folderBrowserDialog1.SelectedPath;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una carpeta", "INFORNACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 0)
            {
                string KeyCelda;               
                DataSet dsMod = new DataSet();
                KeyCelda = dataGridView1.Rows[e.RowIndex].Cells["PK_ElyonParametro"].Value.ToString();
                intParametrosKey = int.Parse(KeyCelda);
                
                try
                {
                    _mSeguridad.intParametro = intParametrosKey;
                    dsMod = _mSeguridad.dsSelecionarParametro();

                    if (dsMod.Tables[0].Rows.Count > 0)
                    {                                                                        
                        txtUsuServ.Text = dsMod.Tables[0].Rows[0].ItemArray[2].ToString();
                        txtCveServ.Text = dsMod.Tables[0].Rows[0].ItemArray[3].ToString();
                        txtServSalida.Text = dsMod.Tables[0].Rows[0].ItemArray[4].ToString();
                        txtPuertoSalida.Text = dsMod.Tables[0].Rows[0].ItemArray[5].ToString();
                        txtrutaimagen.Text = dsMod.Tables[0].Rows[0].ItemArray[6].ToString();
                        bool est = bool.Parse(dsMod.Tables[0].Rows[0].ItemArray[7].ToString());

                        if (est == true)
                        {
                            cmbVigente.Text = "1";
                        }
                        else
                        {
                            cmbVigente.Text = "0";
                        }

                        //txtfolio.Text = dsMod.Tables[0].Rows[0].ItemArray[9].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No existen Datos.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
