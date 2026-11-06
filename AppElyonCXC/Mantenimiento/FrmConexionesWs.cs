using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace AppElyonCXC.Mantenimiento
{
    public partial class FrmConexionesWs : Form
    {
        
        private bool _bCambio = false;
        int _intIdApp = 0;
        public bool bCambio
        {
            get { return _bCambio; }
            set { _bCambio = value; }
        }

        #region CONSTRUCTOR  
        public FrmConexionesWs()
        {
            InitializeComponent();
        }
        public FrmConexionesWs(ElyonModelCxC.mCxC mSeguridad)
        {
            InitializeComponent();
        }
        public FrmConexionesWs(int App)
        {
            InitializeComponent();
            _intIdApp = App;
        }
        #endregion CONSTRUCTOR
        private void FrmConexionesWs_Load(object sender, EventArgs e)
        {
            this.Text = "Configuracion de Conexiones";
            try
            {
                txtWSTesoreria.Text = Properties.Settings.Default.UrlCuentas;
                txtWSSeguridad.Text = Properties.Settings.Default.UrlSeguridad;               
                cboConexion.Text = Properties.Settings.Default.strConexionM;
                cmbImpresora.Text = Properties.Settings.Default.strImpresora;
                cmbImpresoraPDF.Text = Properties.Settings.Default.str_Impresora_1;

                foreach (string strImpresora in PrinterSettings.InstalledPrinters)
                {
                    cmbImpresora.Items.Add(strImpresora);
                    if (strImpresora == Properties.Settings.Default.strImpresora)
                        cmbImpresora.SelectedIndex = cmbImpresora.Items.IndexOf(strImpresora);
                }

                foreach (string strImpresora_1 in PrinterSettings.InstalledPrinters)
                {
                    cmbImpresoraPDF.Items.Add(strImpresora_1);
                    if (strImpresora_1 == Properties.Settings.Default.str_Impresora_1)
                        cmbImpresoraPDF.SelectedIndex = cmbImpresoraPDF.Items.IndexOf(strImpresora_1);
                }

            }
            catch { }
        }
        private void btlLimpiar_Click(object sender, EventArgs e)
        {
            txtWSTesoreria.Text = null;
            txtWSSeguridad.Text = null;           
            cboConexion.Text = null;
            cmbImpresora.Text = null;           
            txtWSTesoreria.Focus();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtWSTesoreria.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Por favor ingrese la ruta del servicio de facturación", "Párametros Iniciales");
                    return;
                }
                if (txtWSSeguridad.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Por favor ingrese la ruta del servidor de correos", "Párametros Iniciales");
                    return;
                }                
                if (cboConexion.Text.Trim().Length == 0 || cboConexion.Text.Trim().Equals("Seleccione.."))
                {
                    MessageBox.Show("Por favor seleccione la conexión a la Base de Datos", "Párametros Iniciales");
                    return;
                }

                Properties.Settings.Default.UrlCuentas = txtWSTesoreria.Text;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.UrlSeguridad = txtWSSeguridad.Text;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.strConexionM = cboConexion.Text;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.strImpresora = cmbImpresora.Text;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.str_Impresora_1 = cmbImpresoraPDF.Text;
                Properties.Settings.Default.Save();

                MessageBox.Show("Configuraciones Almacenadas correctamente", "Configuracion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL VERIFICAR ACCESO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Escape)
            {
                _bCambio = false;
            }
            return false;
        }
    }
}
