using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using AppElyonCXC.Mantenimiento;

namespace AppElyonCXC
{
    public partial class Login : Form
    {
        #region Variables
        int _intDondeBiene = 0;
        private bool _bAutentica = false;
        string NombreCompleto = "";
        string _strContra = "";
        string _strEmail = "";
        string _strmail;
        string Email = "";
        string ClaveUsuario = "";
        string NombreServidor = "";
        string puerto = "";
        string strConexion;
        string strConexionFinanzas;
        int _IdApp = 0;
        bool bAdmin = false;
        DataSet dsVerifica;
        int _idUsuario = 0;
        #endregion Variables

        #region Constructores
        public Login()
        {
            InitializeComponent();
            lblVersion.Text = VersionSistema();
        }
        public Login(int DondeBiene)
        {
            InitializeComponent();
            lblVersion.Text = VersionSistema();
            _intDondeBiene = DondeBiene;
        }
        #endregion Constructores

        #region EVENTOS
        private void Login_Load(object sender, EventArgs e)
        {
            lblerror.Visible = false;
            _IdApp = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["IdApp"]);

            #region Ultimo Usuario Registrado
            try
            {                
                txtUsuario.Text = Properties.Settings.Default.strUsuario;
                strConexionFinanzas = Properties.Settings.Default.strConn;
            }
            catch { }

            //vConexiones(strConexionFinanzas);
            #endregion Ultimo Usuario Registrado

            txtUsuario.Focus();
        }
        private void btnInicio_Click(object sender, EventArgs e)
        {
            UcSplashScreen cargando = new UcSplashScreen("", "... Validando acceso ... ");

            cargando.Show();
            cargando.Refresh();

            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtcontrasena.Text))
            {
                lblerror.Visible = true;
                cargando.Close();
            }
            else
            {
                lblerror.Visible = false;
                VerificaAcceso();
                cargando.Close();
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                lblerror.Visible = false;
                txtcontrasena.Focus();
            }
        }

        private void txtcontrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                lblerror.Visible = false;
                VerificaAcceso();
            }
        }

        private void lnkBtnSalir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_intDondeBiene == 0)
            {
                Application.Exit();
            }
            else
            {
                frmPrincipal._intSalida = 1;
                this.Close();
                this.Dispose();
            }
        }

        private void lnkEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC();
            ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);

            string stru = Microsoft.VisualBasic.Interaction.InputBox("Ingresa tu Correo :", "", _strmail);
            _strEmail = (stru.Length == 0 ? _strmail : stru);

            //Datos Usaurio
            try
            {
                _mSeguridad.strUsuario = txtUsuario.Text;
                _mSeguridad.strEmail = _strEmail;
                DataSet dsc = _mSeguridad.dsValidaEmail();

                if (dsc.Tables[0].Rows.Count > 0)
                {
                    NombreCompleto = dsc.Tables[0].Rows[0].ItemArray[0].ToString() + " " + dsc.Tables[0].Rows[0].ItemArray[1].ToString() + " " + dsc.Tables[0].Rows[0].ItemArray[2].ToString();
                    _strEmail = dsc.Tables[0].Rows[0].ItemArray[3].ToString();
                    _strContra = dsc.Tables[0].Rows[0].ItemArray[4].ToString();
                }
                else
                    _strEmail = "";

                string strMensaje = "El sistema le envía su contraseña.";
                string strTittle = "Recuperación de Contraseña - ";

                try
                {
                    if (_strEmail == "" || _strEmail == null)
                    {
                        MessageBox.Show("La cuenta ingresada no figura en el sistema.", "CONFIRMACIÓN CONTRASEÑA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        if (MessageBox.Show("El sistema le enviará la contraseña a su correo electrónico. Si no llega mensaje a su correo, comuníquese con el área de sistemas.", "CONFIRMACIÓN CONTRASEÑA", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            vEnviarCorreo(_strEmail, strTittle, strMensaje);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("La cuenta ingresada no figura en el sistema.", "CONFIRMACIÓN CONTRASEÑA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        #endregion EVENTOS

        #region Funciones
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
            
            if (keyData == Keys.Escape)
            {
                this.Close();
                this.Dispose();
                return true;
            }

            #region Alta de Usuarios CTRL-A
            //Alta de Usuarios
            if (keyData == (Keys.Control | Keys.A))
            {
                try
                {
                    _mSeguridad.strUsuario = txtUsuario.Text;
                    _mSeguridad.strContraseña = txtcontrasena.Text;
                    _mSeguridad.intAplicacion = _IdApp;
                    _bAutentica = _mSeguridad.dsVerificaAcceso();
                }
                catch (Exception ex)
                { _bAutentica = false; }

                if (_bAutentica)
                {
                    //Valida Usuario Administrador
                    bAdmin = false;
                    _mSeguridad.intAplicacion = _IdApp;
                    _mSeguridad.strUsuario = txtUsuario.Text;
                    DataSet dsinf = _mSeguridad.dsInfoUsuarios();
                    if (dsinf.Tables[0].Rows.Count > 0)
                    {
                        bAdmin = bool.Parse(dsinf.Tables[0].Rows[0]["ADMIN"].ToString());
                    }

                    if (bAdmin)
                    {
                        AppElyonCXC.Mantenimiento.FrmAltaUsuario Alta = new Mantenimiento.FrmAltaUsuario(_IdApp, _mSeguridad.strConexion);
                        Alta.ShowDialog();
                        if (Alta.bModificado)
                            this.Hide();
                    }
                    else
                        MessageBox.Show("NO tienes Acceso Solo Usuario Administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("NO tienes Acceso Solo Usuario Administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return true;
            }
            #endregion Alta de Conexion

            #region Modifica Contraseña CTRL-M
            //Modificacion de contraseña
            if (keyData == (Keys.Control | Keys.M))
            {
                try
                {
                    _mSeguridad.strUsuario = txtUsuario.Text;
                    _mSeguridad.strContraseña = txtcontrasena.Text;
                    _mSeguridad.intAplicacion = _IdApp;
                    _bAutentica = _mSeguridad.dsVerificaAcceso();
                }
                catch (Exception ex)
                {
                    _bAutentica = false;
                }

                if (_bAutentica)
                {
                    //Valida Usuario Administrador
                    bAdmin = false;
                    _mSeguridad.strUsuario = txtUsuario.Text;
                    _mSeguridad.intAplicacion = _IdApp;
                    DataSet dsinf = _mSeguridad.dsInfoUsuarios();
                    if (dsinf.Tables[0].Rows.Count > 0)
                    {
                        bAdmin = bool.Parse(dsinf.Tables[0].Rows[0]["ADMIN"].ToString());
                        _idUsuario = int.Parse(dsinf.Tables[0].Rows[0]["IDUSUARIO"].ToString());
                    }

                    if (bAdmin)
                    {                       
                        _mSeguridad.strUsuario = txtUsuario.Text;
                        _mSeguridad.strConexion = strConexion;
                        AppElyonCXC.Mantenimiento.FrmDatosUsuario usuario = new AppElyonCXC.Mantenimiento.FrmDatosUsuario(_mSeguridad.strUsuario, true, _IdApp, 0, _idUsuario, bAdmin);
                        usuario.ShowDialog();
                        if (usuario.bModificado)
                            this.Hide();
                    }
                    else
                        MessageBox.Show("NO tienes Acceso, Solo Usuario Administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("NO tienes Acceso, Solo Usuario Administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return true;
            }
            #endregion Modifica Contraseña

            #region Configuracion Conexion CTRL-N
            //Configurar Conexion
            if (keyData == (Keys.Control | Keys.N))
            {
                //Valida Usuario Administrador
                bAdmin = false;
                _mSeguridad.intAplicacion = _IdApp;
                _mSeguridad.strUsuario = txtUsuario.Text;
                DataSet dsinf = _mSeguridad.dsInfoUsuarios();
                if (dsinf.Tables[0].Rows.Count > 0)
                {
                    bAdmin = bool.Parse(dsinf.Tables[0].Rows[0]["ADMIN"].ToString());
                }

                if (bAdmin)
                {
                    AppElyonCXC.Mantenimiento.FrmConfiguracion confg = new Mantenimiento.FrmConfiguracion(_IdApp, strConexionFinanzas);
                    confg.ShowDialog();
                }
                else
                    MessageBox.Show("NO tienes Acceso Solo Usuario Administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                #region Ultimo Usuario Registrado
                try
            {
                txtUsuario.Text = Properties.Settings.Default.strUsuario;
                strConexionFinanzas = Properties.Settings.Default.strConn;
            }
            catch { }

            vConexiones(strConexionFinanzas);
            #endregion Ultimo Usuario Registrado             
            }
            #endregion Configuracion Conexion
            return false;
        }

        private void VerificaAcceso()
        {
            ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
                        
            try
            {
                _mSeguridad.strUsuario = txtUsuario.Text;
                _mSeguridad.strContraseña = txtcontrasena.Text;
                _mSeguridad.intAplicacion = _IdApp;

                //Versión Desarrollo--> UTLIZA LA CLAVE DE SISTEMAS EL NUMERO 12
                if (txtcontrasena.Text == System.Configuration.ConfigurationSettings.AppSettings["Sistemas"])
                {
                    _bAutentica = true;
                }
                else
                {
                    _bAutentica = _mSeguridad.dsVerificaAcceso();
                }


                if (_bAutentica)
                {
                    try
                    {
                        dsVerifica = _mSeguridad.dsInfoUsuarios();
                        dsVerifica = _mSeguridad.ArmaTablaInformacion(dsVerifica, strConexionFinanzas);
                    }
                    catch(Exception ex) { }

                    if (dsVerifica != null && dsVerifica.Tables.Count == 1)
                    {
                        _idUsuario = int.Parse(dsVerifica.Tables[0].Rows[0]["IDUSUARIO"].ToString());
                        bAdmin = bool.Parse(dsVerifica.Tables[0].Rows[0]["ADMIN"].ToString());

                        //Validacion para Cambiar de Usuario
                        if (_intDondeBiene == 0)
                        {
                            //Almacena el ultimo Usuario que Entro.
                            try
                            {
                                vEscribirRegistro(txtUsuario.Text.Trim());
                            }
                            catch { }

                            if (!bool.Parse(dsVerifica.Tables[0].Rows[0]["Verifcado"].ToString()))
                            {                                
                                AppElyonCXC.Mantenimiento.FrmDatosUsuario usuario = new AppElyonCXC.Mantenimiento.FrmDatosUsuario(_mSeguridad.strUsuario, true, _IdApp, 1, _idUsuario, bAdmin);
                                usuario.ShowDialog();
                                if (usuario.bModificado)
                                    this.Hide();
                            }
                            else
                            {
                                //Marca inicio de Session
                                _mSeguridad.CerrarSession(_idUsuario, _IdApp, 1);
                                                              
                                this.Hide();
                                frmPrincipal mp = new frmPrincipal(dsVerifica);
                                mp.Show();
                            }
                        }
                        else
                        {
                            //Almacena el ultimo Usuario que Entro.
                            try
                            {
                                vEscribirRegistro(txtUsuario.Text.Trim());
                            }
                            catch { }

                            if (!bool.Parse(dsVerifica.Tables[0].Rows[0]["Verifcado"].ToString()))
                            {
                                _idUsuario = int.Parse(dsVerifica.Tables[0].Rows[0]["IDUSUARIO"].ToString());

                                AppElyonCXC.Mantenimiento.FrmDatosUsuario usuario = new AppElyonCXC.Mantenimiento.FrmDatosUsuario(_mSeguridad.strUsuario, true, _IdApp, 1, _idUsuario, bAdmin);
                                usuario.ShowDialog();
                                if (usuario.bModificado)
                                    this.Hide();
                            }
                            else
                            {
                                //Marca inicio de Session
                                _mSeguridad.CerrarSession(_idUsuario, _IdApp, 1);

                                //frmPrincipal.strConexionFP = _mSeguridad.strConexion;
                                frmPrincipal.DsInicalesFP = dsVerifica;
                                frmPrincipal._intSalida = 0;

                                this.Close();
                                this.Dispose();
                            }
                        }
                    }
                    else
                    {
                        if (dsVerifica != null && dsVerifica.Tables.Count > 1)
                        {
                            if (dsVerifica.Tables[1].Rows.Count > 0)
                            {
                                string error = dsVerifica.Tables[1].Rows[0][0].ToString();
                                if (error == "Usuario o Contraseña incorrecta")
                                {
                                    lblerror.Visible = true;
                                }
                            }
                        }
                        else
                        {
                            lblerror.Visible = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ERROR AL VERIFICAR ACCESO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ////Almacena el ultimo Usuario que Entro.
                    //try
                    //{
                    //    vEscribirRegistro(txtUsuario.Text.Trim());
                    //}
                    //catch { }

                    //if (_intDondeBiene == 0)
                    //{
                    //    //Acceso por CLAVE SISTEMAS
                    //    this.Hide();
                    //    frmPrincipal mp = new frmPrincipal(dsVerifica);
                    //    mp.Show();
                    //}
                    //else
                    //{
                    //    //frmPrincipal.strConexionFP = _mSeguridad.strConexion;
                    //    frmPrincipal.DsInicalesFP = dsVerifica;
                    //    frmPrincipal._intSalida = 0;

                    //    this.Close();
                    //    this.Dispose();
                    //}
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL VERIFICAR ACCESO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private string VersionSistema()
        {
            //string mLocation = null;
            string Version = "";

            Version ver = new Version();
            try
            {
                Version = "Versión : " + System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
            }
            catch
            {
                Version = "Versión : Compilado";
                //mLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
                //Version = "Versión :" + System.Diagnostics.FileVersionInfo.GetVersionInfo(mLocation).FileVersion;               
            }

            return Version;
        }

        private void vConexiones(string Con)
        {
            ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC();
            
            try
            {
                //_mSeguridad.strConexion = System.Configuration.ConfigurationSettings.AppSettings["ConnStringSQL1"];               
                strConexion = System.Configuration.ConfigurationSettings.AppSettings["ConnStringSQL1"];
            }
            catch
            { }


            try
            {
                //_mSeguridad.strConexion = strConexion;
                _mSeguridad.strTipo = Con;
                _mSeguridad.intAplicacion = _IdApp;
                DataSet DS = _mSeguridad.dsobtieneConexion();

                if (DS.Tables[0].Rows.Count > 0)
                {
                    strConexionFinanzas = DS.Tables[0].Rows[0].ItemArray[2].ToString();
                }
                else
                {
                    strConexionFinanzas = strConexion;
                }

            }
            catch
            {
                strConexionFinanzas = strConexion;
            }
        }

        public void vEscribirRegistro(string Nombre)
        {

            try
            {
                Properties.Settings.Default["strUsuario"] = Nombre;
                Properties.Settings.Default.Save(); // Saves settings in application configuration file
            }
            catch
            { }

        }
        public static string strLeerRegistro(string Nombre)
        {

            RegistryKey myKey = getLlaveRegistro();
            if (myKey != null)
            {
                try
                {
                    return myKey.GetValue(Nombre).ToString();
                }
                catch
                {
                    return string.Empty;
                }
            }
            else
                return System.Configuration.ConfigurationSettings.AppSettings.Get(Nombre);
        }
        private static RegistryKey getLlaveRegistro()
        {
            RegistryKey ret;
            try
            {
                Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Elyon");
                ret = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Elyon", true);

            }
            catch
            {
                ret = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Elyon", true);
            }
            return ret;
        }
        private void vEnviarCorreo(string strPara, string strSubject, string strMensaje)
        {
            ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);            

            string strMiEmail = "";
            string strServMail = "";
            string strUsuPasMail = "";
            string strPueMail = "";

            DataSet dsParam = _mSeguridad.ObtenerParametros();
            if (dsParam.Tables[0].Rows.Count > 0)
            {
                strMiEmail = dsParam.Tables[0].Rows[0].ItemArray[2].ToString();
                strServMail = dsParam.Tables[0].Rows[0].ItemArray[4].ToString();
                strUsuPasMail = dsParam.Tables[0].Rows[0].ItemArray[3].ToString();
                strPueMail = dsParam.Tables[0].Rows[0].ItemArray[5].ToString();
            }
            string MiEmpresa = "";
            int i = 0;


            MiEmpresa = "CONTADORES";
            //imagen = img;
            DataSet dsGenEnvio = new DataSet();
            try
            {
                //Obtiene el correo del usuario o Usuarios           
                string strEmail = strPara; //strUsuAlmacenMail + "," + 
                string texto1 = "";

                string emailTo = strEmail;
                System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
                correo.From = new System.Net.Mail.MailAddress(MiEmpresa + "<" + strMiEmail + ">");
                correo.To.Add(emailTo);
                //correo.CC.Add("desarrollo.sistemas@univa.mx");
                correo.Subject = strSubject + MiEmpresa;
                correo.Priority = System.Net.Mail.MailPriority.High;

                //string sTemp = Application.ExecutablePath.ToUpper().Replace("\\SAGU.EXE", "") + "\\imgpantalla.jpg";
                //System.IO.FileStream strea = new System.IO.FileStream(sTemp, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
                //imagen.Save(strea, System.Drawing.Imaging.ImageFormat.Jpeg);
                //strea.Close();

                //System.Net.Mail.Attachment atach = new System.Net.Mail.Attachment(sTemp);
                //correo.Attachments.Add(atach);

                //Genera Texto para el correo

                texto1 = "Buen dia \n\n" + "Usuario: " + txtUsuario.Text + "\n" +
                       "\n\nGenerado por sistema automatico:\n" +
                       " Nombre: " + NombreCompleto + "\n" + "Contraseña: " + _strContra;



                correo.Body = texto1;

                //Configuracion de Correo                     

                correo.IsBodyHtml = false;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Host = strServMail;
                smtp.Port = int.Parse(strPueMail);
                smtp.Credentials = new System.Net.NetworkCredential(strMiEmail, strUsuPasMail);

                //Pendiente para Office 365
                //---------------------------
                smtp.EnableSsl = true;
                //---------------------------

                try
                {

                    smtp.Send(correo);
                    MessageBox.Show("Los datos de acceso han sido enviados al correo " + strPara, "Envío de correo");


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problemas al enviar el correo. ERROR: " + ex.Message, "Envío de correo");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion Funciones

        //private void lklblWs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    Mantenimiento.FrmConexionesWs fcon = new Mantenimiento.FrmConexionesWs();
        //    fcon.ShowDialog();

        //    MessageBox.Show("Se necesita reiniciar el sistema para que tome los nuevos cambios", "INFORMACION CONFIGURACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    Application.Exit();
        //}

        private void pbxOjo_MouseHover(object sender, EventArgs e)
        {
            txtcontrasena.UseSystemPasswordChar = false;
        }

        private void pbxOjo_MouseLeave(object sender, EventArgs e)
        {
            txtcontrasena.UseSystemPasswordChar = true;
        }

        private void lblNombre_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void lblNombre_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void lklblWs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AppElyonCXC.Mantenimiento.FrmConexionesWs confg = new Mantenimiento.FrmConexionesWs(_IdApp);
            confg.ShowDialog();
            if (confg.bCambio)
            {
                MessageBox.Show("Favor de ingresar de nuevo al sistema");
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_intDondeBiene == 0)
            {
                Application.Exit();
            }
            else
            {
                frmPrincipal._intSalida = 1;
                this.Close();
                this.Dispose();
            }
        }
    }
}
