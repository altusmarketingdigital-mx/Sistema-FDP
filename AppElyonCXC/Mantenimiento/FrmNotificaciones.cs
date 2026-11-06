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
    public partial class FrmNotificaciones : Form
    {
        #region CONEXIONES LOCALES        
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        #endregion

        #region //Variables
        string Usuario = "";
        string NivelSeguridad;
        int UsuarioID;
        string MensajeProceso = "";
        string _strConexion = "";
        string _strConexionFin = "";
        int _intIdApp = 0;
        DataSet dsDatos = new DataSet();
        bool _bUsuarioAdmin;
        string _strUsuario;
        int intIDconvenios = 0;
        string plant = "";
        string perio = " ";
        int intIDUsuario = 0;
        int cont = 0;
        int Aplicacion = 0;
        bool cmbcombo = false;
        int Idmenu = 0;
        #endregion

        public FrmNotificaciones()
        {
            InitializeComponent();
        }
        public FrmNotificaciones(DataSet dsParam)
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
                Idmenu = int.Parse(dsDatos.Tables["Parametros"].Rows[0]["IdMenu"].ToString());
            }
        }
        private void FrmNotificaciones_Load(object sender, EventArgs e)
        {
            this.Text = MensajeProceso;
            CargaUsuarios();
            CargaNotificaciones();
        }
        private void CargaUsuarios()
        {
            DataSet dsUsu = new DataSet();

            try
            {
                DataSet dtsConUsu = _mSeguridad.CargarUsuariosLogeados();
                if (dtsConUsu.Tables[0].Rows.Count > 0)
                {
                    ucgUsuariosLog.DataSource = dtsConUsu.Tables[0];
                    ucgUsuariosLog.gvGrid.Columns["ID"].Visible = false;
                    ucgUsuariosLog.gvGrid.Columns["AplicacionID"].Visible = false;
                }
                else
                {
                    MessageBox.Show("No existen usuarios logeados", "USUARIOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void rbtnUsuario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnUsuario.Checked == true)
            {
                //               
            }
        }

        private void rbtntodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtntodos.Checked == true)
            {
                txtMensaje.Focus();
                rbtnUsuario.Checked = false;               
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            //Manda Mensaje
            if (txtMensaje.Text.Length > 0)
            {
                InsertMessage(txtMensaje.Text);

                txtMensaje.Clear(); //Limpia txtMensaje
                txtMensaje.Focus(); //Mueve el foco hacia txtMensaje                
            }
        }
        private void InsertMessage(string text)
        {
            //Inserta entrada de Usuario
            if (rbtnUsuario.Checked == true)
            {
                try
                {
                    //Actualizar                    
                    GuardaNotificacion(intIDUsuario, Aplicacion, txtMensaje.Text, DateTime.Now, 0, 0, 0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (rbtntodos.Checked == true)
            {
                // para todos
                try
                {
                    //Actualizar                    
                    GuardaNotificacion(intIDUsuario, Aplicacion, txtMensaje.Text, DateTime.Now, 0, 0, 1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            CargaNotificaciones();
        }
        public void GuardaNotificacion(int usuario, int app, string mensaje, DateTime fec, int leido, int borrar, int tipo)
        {
            try
            {
                _mSeguridad.strUsuario = usuario.ToString();
                _mSeguridad.intAplicacion = app;
                _mSeguridad.Mensaje = mensaje;
                _mSeguridad.dtFecha = fec;
                _mSeguridad.intLeido = leido;
                _mSeguridad.intBorrado = borrar;
                _mSeguridad.intTipo = tipo;

                //if (_mSeguridad.AltaNotificaciones())
                //{
                //    //
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show("No almaceno notificacion");
            }
        }
        private void CargaNotificaciones()
        {
            string paso = "";
            string Msj = "";
            string Fecha = "";
            string estatus = "";
            string Usuario = "";
            string Plantel = "";
            int i = 0;
            int d = 0;

            rtxtMensaje.Clear();
           
            DataSet dsCNot = _mSeguridad.CargarNotificacionesAdministrador();

            if (dsCNot.Tables[0].Rows.Count > 0)
            {
                while (i < dsCNot.Tables[0].Rows.Count)
                {
                    _mSeguridad.AppendText(rtxtMensaje, Color.Black, " ");
                    Msj = dsCNot.Tables[0].Rows[i].ItemArray[0].ToString();
                    Fecha = dsCNot.Tables[0].Rows[i].ItemArray[1].ToString();
                    estatus = dsCNot.Tables[0].Rows[i].ItemArray[2].ToString();
                    Usuario = dsCNot.Tables[0].Rows[i].ItemArray[3].ToString();
                    Plantel = dsCNot.Tables[0].Rows[i].ItemArray[4].ToString();

                    paso = Fecha + " - ";
                    _mSeguridad.AppendText(rtxtMensaje, Color.Black, paso);
                    _mSeguridad.AppendText(rtxtMensaje, Color.Green, estatus + "\n");
                    _mSeguridad.AppendText(rtxtMensaje, Color.Black, "Usuario: " + Usuario + " - Plantel: " + Plantel + "\n");
                    _mSeguridad.AppendText(rtxtMensaje, Color.Blue, Msj + "\n\r");

                    i++;
                }
            }
        }

        private void ucgUsuariosLog_cell_Datagrid_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            intIDUsuario = int.Parse(ucgUsuariosLog.gvGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            txtUsuario.Text = ucgUsuariosLog.gvGrid.Rows[e.RowIndex].Cells["Usuarios"].Value.ToString();
            Aplicacion = int.Parse(ucgUsuariosLog.gvGrid.Rows[e.RowIndex].Cells["AplicacionID"].Value.ToString());
        }

        private void tsbtnActualiza_Click(object sender, EventArgs e)
        {
            CargaNotificaciones();
        }

        private void TlsBorrar_Click(object sender, EventArgs e)
        {
           //
        }
    }
}
