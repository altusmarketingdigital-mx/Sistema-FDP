using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppElyonCXC.Cargas
{
    public partial class FrmCargosBanco : Form
    {      
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);

        #region //Variables
        string NivelSeguridad;
        int UsuarioID;
        string MensajeProceso = "";
        string _strConexion = "";
        string strKeyMenu = "0";
        bool regresa = false;
        string SiglasProceso = "";
        private int EstMenu;
        int intValida = 0;
        int _intIdApp = 0;
        string strtipoM;
        int _intArmaMenu = 0;
        DataSet dsDatos = new DataSet();
        bool _bUsuarioAdmin;        
        int _intbit = 0;
        string str_Fecha = "";
        string str_Codigo = "";
        string str_Cliente = "";
        string str_banco = "";
        string str_importe = "";
        string str_vendedor = "";
        string str_Referencia = "";
        string str_Factura = "";
        string str_FormaPago = "";
        string str_Complemento = "";
        string str_Observaciones = "";
        DataTable tbLimpiar = new DataTable();
        bool cmbcombo = false;
        string strConexion;
        string ConexionTrainman;
        string ConexionCastalia;
        int _intIDMenu;
        #endregion //Variables

        #region Constructores
        public FrmCargosBanco()
        {
            InitializeComponent();
        }
        public FrmCargosBanco(DataSet dsParam)
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
                _bUsuarioAdmin = bool.Parse(dsDatos.Tables["Parametros"].Rows[0][6].ToString());
                _intIDMenu = int.Parse(dsDatos.Tables["Parametros"].Rows[0][9].ToString());
            }
            _mSeguridad.ValidarBotones(this.Controls, UsuarioID, _intIDMenu);
        }
        #endregion Constructores
        private void FrmPagosBanamex_Load(object sender, EventArgs e)
        {
            this.Text = MensajeProceso;           
        }               
        private void btnCargar_Click(object sender, EventArgs e)
        {
            string filePath;
            System.Windows.Forms.OpenFileDialog dlCarpeta = new System.Windows.Forms.OpenFileDialog();

            if (dlCarpeta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Ruta del Archivo
                txtNombre.Text = dlCarpeta.FileName;
                filePath = dlCarpeta.FileName;

                CargaArchivoGrid();
            }
        }
        private void CargaArchivoGrid()
        {
            #region Cargar Archivoa GRID           
            int i = 0;
            _intbit = 0;
            int vuelta = 1;
            char[] cDelimeter = { '|' };
            string[] strDivision;
            DataTable dtbDatos = new DataTable("CARGABANCO");
            //Insert en tabla                                                                        
            dtbDatos.Columns.Add("fecha");
            dtbDatos.Columns.Add("Codigo");
            dtbDatos.Columns.Add("Cliente");
            dtbDatos.Columns.Add("Banco");           
            dtbDatos.Columns.Add("Importe", typeof(decimal));
            dtbDatos.Columns.Add("Vendedor");
            dtbDatos.Columns.Add("Referencia");
            dtbDatos.Columns.Add("Factura");
            dtbDatos.Columns.Add("FormaPago");
            dtbDatos.Columns.Add("Complemento");
            dtbDatos.Columns.Add("Observaciones");            

            if (txtNombre.Text == "" || txtNombre.Text == null)
            {
                MessageBox.Show("Favor de Asignar el Archivo.", "ERROR DE CARGA", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                txtNombre.Focus();
            }
            else
            {
                using (StreamReader srLeer = new StreamReader(txtNombre.Text))
                {
                    string linea;
                    try
                    {

                        while ((linea = srLeer.ReadLine()) != null)
                        {
                            if (srLeer.EndOfStream)
                            {
                                //Carga datos NUevos
                                strDivision = linea.Split(cDelimeter);
                                str_Fecha = strDivision[0];
                                str_Codigo = strDivision[1];
                                str_Cliente = strDivision[2];
                                str_banco = strDivision[3];
                                str_importe = strDivision[4];
                                str_vendedor = strDivision[5];
                                str_Referencia = strDivision[6];                               
                                str_Factura = strDivision[7];
                                str_FormaPago = strDivision[8];                               
                                str_Complemento = strDivision[9];
                                str_Observaciones = strDivision[10];
                                

                                //Inserta Datos los datos nuevos
                                DataRow dtrError1 = dtbDatos.NewRow();
                                dtrError1["fecha"] = str_Fecha.Trim();
                                dtrError1["Codigo"] = str_Codigo.Trim();
                                dtrError1["Cliente"] = str_Cliente.Trim();
                                dtrError1["Banco"] = str_banco;
                                dtrError1["Importe"] = str_importe;
                                dtrError1["Vendedor"] = str_vendedor;
                                dtrError1["Referencia"] = str_Referencia.Trim();
                                dtrError1["Factura"] = str_Factura.Trim();
                                dtrError1["FormaPago"] = str_FormaPago.Trim();
                                dtrError1["Complemento"] = str_Complemento;
                                dtrError1["Observaciones"] = str_Observaciones;                                                               

                                dtbDatos.Rows.Add(dtrError1);

                                //Cargas grid
                                dtgCarga.DataSource = dtbDatos;

                                break;
                            }
                            else
                            {
                                if (vuelta != 1)
                                {
                                    #region Carga                                   
                                    if (linea != "" || linea != null)
                                    {

                                        strDivision = linea.Split(cDelimeter);
                                        str_Fecha = strDivision[0];
                                        str_Codigo = strDivision[1];
                                        str_Cliente = strDivision[2];
                                        str_banco = strDivision[3];
                                        str_importe = strDivision[4];
                                        str_vendedor = strDivision[5];
                                        str_Referencia = strDivision[6];
                                        str_Factura = strDivision[7];
                                        str_FormaPago = strDivision[8];
                                        str_Complemento = strDivision[9];
                                        str_Observaciones = strDivision[10];


                                        //Inserta Datos los datos nuevos
                                        DataRow dtrError = dtbDatos.NewRow();
                                        dtrError["fecha"] = str_Fecha.Trim();
                                        dtrError["Codigo"] = str_Codigo.Trim();
                                        dtrError["Cliente"] = str_Cliente.Trim();
                                        dtrError["Banco"] = str_banco;
                                        dtrError["Importe"] = str_importe;
                                        dtrError["Vendedor"] = str_vendedor;
                                        dtrError["Referencia"] = str_Referencia.Trim();
                                        dtrError["Factura"] = str_Factura.Trim();
                                        dtrError["FormaPago"] = str_FormaPago.Trim();
                                        dtrError["Complemento"] = str_Complemento;
                                        dtrError["Observaciones"] = str_Observaciones;

                                        dtbDatos.Rows.Add(dtrError);

                                        //Cargas grid
                                        dtgCarga.DataSource = dtbDatos;

                                        
                                    }
                                    #endregion

                                   
                                }
                                else
                                {
                                    //Carga datos NUevos
                                    strDivision = linea.Split(cDelimeter);
                                    str_Fecha = strDivision[0];
                                    str_Codigo = strDivision[1];
                                    str_Cliente = strDivision[2];
                                    str_banco = strDivision[3];
                                    str_importe = strDivision[4];
                                    str_vendedor = strDivision[5];
                                    str_Referencia = strDivision[6];
                                    str_Factura = strDivision[7];
                                    str_FormaPago = strDivision[8];
                                    str_Complemento = strDivision[9];
                                    str_Observaciones = strDivision[10];

                                    DataRow dtrError = dtbDatos.NewRow();
                                    dtrError["fecha"] = str_Fecha.Trim();
                                    dtrError["Codigo"] = str_Codigo.Trim();
                                    dtrError["Cliente"] = str_Cliente.Trim();
                                    dtrError["Banco"] = str_banco;
                                    dtrError["Importe"] = str_importe;
                                    dtrError["Vendedor"] = str_vendedor;
                                    dtrError["Referencia"] = str_Referencia.Trim();
                                    dtrError["Factura"] = str_Factura.Trim();
                                    dtrError["FormaPago"] = str_FormaPago.Trim();
                                    dtrError["Complemento"] = str_Complemento;
                                    dtrError["Observaciones"] = str_Observaciones;

                                    dtbDatos.Rows.Add(dtrError);

                                    //Cargas grid
                                    dtgCarga.DataSource = dtbDatos;
                                }
                            }
                            vuelta++;
                        }
                    }
                    catch (Exception)
                    {

                    }
                    srLeer.Close();
                }
                MessageBox.Show("Proceso terminado archivo cargado", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            #endregion
        }
        private void btnprocesa_Click(object sender, EventArgs e)
        {

            if (txtNombre.Text == "")
            {
                MessageBox.Show("Es necesario ingresar el archivo y su ruta", "ERROR DE CARGA", MessageBoxButtons.OK, MessageBoxIcon.Error);               
                return;
            }          

                cargadatos();
                MessageBox.Show("Datos almacenados", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Information);                            
        }       
        private void cargadatos()
        {
            //Thread.Sleep(2000);
            //Almacenar Respuestas de Grid  
            
            foreach(DataGridViewRow drvDatos in dtgCarga.gvGrid.Rows)
            {
                str_Fecha = drvDatos.Cells[0].Value.ToString();                                                
                str_importe = drvDatos.Cells[4].Value.ToString();                
                str_Referencia = drvDatos.Cells[6].Value.ToString();
                str_Factura = drvDatos.Cells[7].Value.ToString();
                str_FormaPago = drvDatos.Cells[8].Value.ToString();
                str_Complemento = drvDatos.Cells[9].Value.ToString();
                str_Observaciones = drvDatos.Cells[10].Value.ToString();

                //Datos de busqueda
                str_Codigo = drvDatos.Cells[1].Value.ToString();
                str_Cliente = drvDatos.Cells[2].Value.ToString();
                str_banco = drvDatos.Cells[3].Value.ToString();
                str_vendedor = drvDatos.Cells[5].Value.ToString();


                try
                {
                    if (AlmacenaDatos())
                    {
                        continue;
                    }
                    else
                    {
                        //Agregar a una tabla o los muestras
                    }

                }
                catch { }
            }

        }      
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbcombo = false;
            txtNombre.Text = null;           
            _intbit = 0;
            dtgCarga.DataSource = null;
            str_Fecha = "";
            str_Codigo = "";
            str_Cliente = "";
            str_banco = "";
            str_importe = "0";
            str_vendedor = "";
            str_Referencia = "";
            str_Factura = "";
            str_FormaPago = "";
            str_Complemento = "";
            str_Observaciones = "";
        }      
        private bool AlmacenaDatos()
        {
            MessageBox.Show("EN DESAROLLO......", "DESARROLLO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
    }
}      