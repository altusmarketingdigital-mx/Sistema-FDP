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
    public partial class FrmConfiguracion : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        //mSeguridadElyon.mSeguridad _mSeguridad = new mSeguridadElyon.mSeguridad();
        #endregion

        #region //Variables
        string _strConexion = "";
        int _intIdApp = 0;
        #endregion //Variables

        public FrmConfiguracion()
        {
            InitializeComponent();
        }
        public FrmConfiguracion(int App, string con)
        {
            InitializeComponent();
            _strConexion = con;
            _intIdApp = App;
        }
        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            this.Text = "Configuracion de Conexiones";
            CargarConexiones();
        }

        private void CargarConexiones()
        {
            DataSet dtmns = new DataSet();
            try
            {
                _mSeguridad.strConexion = _strConexion;
                _mSeguridad.intAplicacion = _intIdApp;

                dtmns = _mSeguridad.dsCargaTipoConcexiones();
                if (dtmns.Tables[0].Rows.Count > 0)
                {
                    //Inserta Registro en Blanco
                    dtmns.Tables[0].Rows.InsertAt(dtmns.Tables[0].NewRow(), 0);

                    cmbConexion.DataSource = dtmns.Tables[0].DefaultView;
                    cmbConexion.ValueMember = "PK_conn";
                    cmbConexion.DisplayMember = "Tipo";

                }
                else
                {
                    MessageBox.Show("No hay datos a cargar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                vEscribirRegistroConexion(cmbConexion.Text);
            }
            catch { }
            this.Close();
        }

        public void vEscribirRegistroConexion(string Nombre)
        {

            try
            {
                Properties.Settings.Default["strConn"] = Nombre;
                Properties.Settings.Default.Save(); // Saves settings in application configuration file
            }
            catch
            { }

        }
    }
}
