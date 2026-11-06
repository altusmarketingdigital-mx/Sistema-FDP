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
    public partial class FrmAvisosFlotante : Form
    {
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        string _IdUsuario = "0";
        int _intIdApp = 0;

        public FrmAvisosFlotante()
        {
            InitializeComponent();
        }
        public FrmAvisosFlotante(string usuario, int app)
        {
            InitializeComponent();
            _IdUsuario = usuario;
            _intIdApp = app;
        }
        private void FrmAvisosFlotante_Load(object sender, EventArgs e)
        {
            CargaNotificaciones();
            MarcaNotificaciones();
        }
        private void CargaNotificaciones()
        {
            string paso = "";
            string Msj = "";
            string Fecha = "";
            string estatus = "";
            int i = 0;
            int d = 0;

            rtxtMensaje.Clear();

            _mSeguridad.strUsuario = _IdUsuario.ToString();
            _mSeguridad.intAplicacion = _intIdApp;
            DataSet dsCNot = _mSeguridad.CargarNotificaciones();

            if (dsCNot.Tables[0].Rows.Count > 0)
            {
                while (i < dsCNot.Tables[0].Rows.Count)
                {
                    _mSeguridad.AppendText(rtxtMensaje, Color.Black, " ");
                    Msj = dsCNot.Tables[0].Rows[i].ItemArray[0].ToString();
                    Fecha = dsCNot.Tables[0].Rows[i].ItemArray[1].ToString();
                    estatus = dsCNot.Tables[0].Rows[i].ItemArray[2].ToString();

                    paso = Fecha + " - ";
                    _mSeguridad.AppendText(rtxtMensaje, Color.Black, paso);
                    _mSeguridad.AppendText(rtxtMensaje, Color.Green, estatus + "\n");
                    _mSeguridad.AppendText(rtxtMensaje, Color.Blue, Msj + "\n\r");

                    i++;
                }
            }
        }
        private void MarcaNotificaciones()
        {
            try
            {
                _mSeguridad.strUsuario = _IdUsuario.ToString();
                _mSeguridad.intAplicacion = _intIdApp;

                if (!_mSeguridad.MarcarNotificaciones())
                {
                    MessageBox.Show("NO pudo marcar notificaciones", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GuardaNotificacion(int.Parse(_IdUsuario), _intIdApp, "Msj SisError:" + ex.ToString(), DateTime.Now, 0, 0, 0);
            }
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

                if (_mSeguridad.AltaNotificaciones())
                {
                    //
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No almaceno notificacion");
            }
        }

        private void tlNotCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TlsBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                _mSeguridad.strUsuario = _IdUsuario.ToString();
                _mSeguridad.intAplicacion = _intIdApp;

                if (!_mSeguridad.BorrarNotificaciones())
                {
                    MessageBox.Show("NO pudo borrar notificaciones", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //GuardaNotificacion(int.Parse(_IdUsuario), _intIdApp, "Mensajes Eliminados por el Usuario", DateTime.Now, 0, 0, 0);
                    CargaNotificaciones();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GuardaNotificacion(int.Parse(_IdUsuario), _intIdApp, "Msj SisError:" + ex.ToString(), DateTime.Now, 0, 0, 0);
            }
        }
    }
}
