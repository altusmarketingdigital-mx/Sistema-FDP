using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace AppElyonCXC.Mantenimiento
{
    public partial class FrmDatosUsuario : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);        
        #endregion

        #region //Variables
        string Usuario = "";
        string NivelSeguridad;
        int UsuarioID;
        string MensajeProceso = "";
        DataSet dsDatos = new DataSet();
        string _strConexion = "";
        string _strConexionFin = "";
        int _intIdApp = 0;
        bool _bUsuarioAdmin;
        string _strUsuario;
        int Idmenu = 0;
        string NewUser;
        string AppNew;
        string _strcon = "";
        int _idapp = 0;
        int _intpaso = 0;
        string _intPlantel = "UNIGD";
        bool bModifica = false;
        bool bPrimera = false;
        bool bValido = false;
        bool _bModificado = false;
        int _intBiene = 0;
        int _idUsuario = 0;
        string strImgUsuario = "";

        #endregion //Variables

        public bool bModificado
        {
            get { return _bModificado; }
            set { _bModificado = value; }
        }

        #region Constructores
        public FrmDatosUsuario()
        {
            InitializeComponent();           
        }

        public FrmDatosUsuario(string strUsuario, bool bCambioContraseña, int app, int intBin, int usu, bool badm)
        {
            InitializeComponent();
            _bUsuarioAdmin = badm;
            _mSeguridad.strUsuario = strUsuario;
            bModifica = true;
            txtPswActual.Enabled = true;
            txtPswConfirmar.Enabled = true;
            txtPswNueva.Enabled = true;
            gbContraseña.Enabled = true;
            bPrimera = bCambioContraseña;
            bModificado = false;
            bModifica = true;           
            _idapp = app;
            _intBiene = intBin;
            _idUsuario = usu;            
            if (_intBiene == 0)
            {
                string strApp = Microsoft.VisualBasic.Interaction.InputBox("Escribe el numero de la Aplicacion:", "Datos del Usuario", AppNew);
                if (strApp == "0" || strApp == "")
                {
                    MessageBox.Show("No se realizo ninguna busqueda, reiniciar", "INFORMACION CONTRASEÑA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                _idapp = int.Parse((strApp.Length == 0 ? AppNew : strApp));

                string stru = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el Usuario:", "Datos del Usuario", NewUser);
                if (stru == "0" || stru == "")
                {
                    MessageBox.Show("No se realizo ninguna busqueda, reiniciar", "INFORMACION CONTRASEÑA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                _mSeguridad.strUsuario = (stru.Length == 0 ? NewUser : stru);
            }

            
            vCargarUsuario();
            //CargaPlantel();
            //cmbPlantel.SelectedValue = _intPlantel;
        }

        public FrmDatosUsuario(DataSet dsParam)
        {
            InitializeComponent();
            _intpaso = 2;
            dsDatos = dsParam;
            if (dsDatos.Tables[0].Rows.Count > 0)
            {
                UsuarioID = int.Parse(dsDatos.Tables["Parametros"].Rows[0][0].ToString());
                NivelSeguridad = dsDatos.Tables["Parametros"].Rows[0][1].ToString();
                MensajeProceso = dsDatos.Tables["Parametros"].Rows[0][2].ToString();
                _strConexion = dsDatos.Tables["Parametros"].Rows[0][3].ToString();
                _idapp = int.Parse(dsDatos.Tables["Parametros"].Rows[0][4].ToString());
                _strUsuario = UsuarioID.ToString();
                _strConexionFin = dsDatos.Tables["Parametros"].Rows[0][5].ToString();
                _bUsuarioAdmin = bool.Parse(dsDatos.Tables["Parametros"].Rows[0][6].ToString());
                Usuario = dsDatos.Tables[0].Rows[0]["UsuarioSistema"].ToString();
                Idmenu = int.Parse(dsDatos.Tables["Parametros"].Rows[0]["IdMenu"].ToString());
                
            }

            _mSeguridad.ValidarBotones(this.Controls, UsuarioID, Idmenu);

            if (_intBiene == 0)
            {
                string strApp = Microsoft.VisualBasic.Interaction.InputBox("Escribe el numero de la Aplicacion:", "Datos del Usuario", AppNew);
                if (strApp == "0" || strApp == "")
                {
                    MessageBox.Show("No se realizo ninguna busqueda, reiniciar", "INFORMACION CONTRASEÑA", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                    return;
                }
                _idapp = int.Parse((strApp.Length == 0 ? AppNew : strApp));

                string stru = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el Usuario:", "Datos del Usuario", NewUser);
                if (stru == "0" || stru == "")
                {
                    MessageBox.Show("No se realizo ninguna busqueda, reiniciar", "INFORMACION CONTRASEÑA", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                    return;
                }
                _mSeguridad.strUsuario = (stru.Length == 0 ? NewUser : stru);
            }

            
            vCargarUsuario();
            //CargaPlantel();
            //cmbPlantel.SelectedValue = _intPlantel;

        }
        #endregion Constructores

        public void CargaApps(int Usuario)
        {

            string Apps;
            _mSeguridad.intIdUsuario = Usuario;
            Apps = _mSeguridad.strJsonCargaAppsUsuario();
            DataTable LApps = JsonConvert.DeserializeObject<DataTable>(Apps);

            dtGridApps.DataSource = LApps;
                      
        }
        private void CargaPlantel()
        {
            DataSet dtmns = new DataSet();

            try
            {
                _mSeguridad.strUsuario = _idUsuario.ToString();
                _mSeguridad.intAplicacion = _idapp;
                _mSeguridad.intMenuKey = 0;

                dtmns = _mSeguridad.dsObtienePlanteles();
                if (dtmns.Tables[0].Rows.Count > 0)
                {
                    //Inserta Registro en Blanco
                    dtmns.Tables[0].Rows.InsertAt(dtmns.Tables[0].NewRow(), 0);

                    cmbPlantel.DataSource = dtmns.Tables[0].DefaultView;
                    cmbPlantel.ValueMember = "ID";
                    cmbPlantel.DisplayMember = "Descripcion";

                }
                else
                {

                    MessageBox.Show("No hay datos de procesos a cargar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void vCargarUsuario()
        {
            DataSet dsDatos = new DataSet();
            _mSeguridad.intPlantelID = "";
            _mSeguridad.strConexion = _strcon;
            _mSeguridad.intAplicacion = _idapp;
            dsDatos = _mSeguridad.dsInfoUsuarios();
            if (dsDatos.Tables[0].Rows.Count > 0)
            {

                txtUsuario.Text = _mSeguridad.strUsuario;
                txtUsuario.Enabled = false;
                txtUsuarioSistema.Text = dsDatos.Tables[0].Rows[0]["Usuario Sistema"].ToString();

                txtNombre.Text = dsDatos.Tables[0].Rows[0]["Nombre"].ToString();
                txtNombre.Enabled = false;
                txtApellidoPaterno.Text = dsDatos.Tables[0].Rows[0]["Apellido Paterno"].ToString();
                txtApellidoPaterno.Enabled = false;
                txtApellidoMaterno.Text = dsDatos.Tables[0].Rows[0]["Apellido Materno"].ToString();
                txtApellidoMaterno.Enabled = false;
                txtCorreo.Text = dsDatos.Tables[0].Rows[0]["Correo"].ToString();
                //txtCorreo.Enabled = false;
                _intPlantel = dsDatos.Tables[0].Rows[0]["PLANTEL"].ToString();

               
                cmbPlantel.Enabled = false;
                ckbActivo.Checked = bool.Parse(dsDatos.Tables[0].Rows[0]["Activo"].ToString());
                if (ckbActivo.Checked)
                    ckbActivo.Text = "Activo";
                else
                    ckbActivo.Text = "Inactivo";
                
                imgVerifica.Visible = true;
                bValido = true;
                _mSeguridad.strContraseña = dsDatos.Tables[0].Rows[0]["Contraseña"].ToString();
                chkAdmin.Checked = bool.Parse(dsDatos.Tables[0].Rows[0]["ADMIN"].ToString());
                _idUsuario = int.Parse(dsDatos.Tables[0].Rows[0]["IDUSUARIO"].ToString());
                strImgUsuario = dsDatos.Tables[0].Rows[0]["IMAGEN"].ToString();
                CargaImagen(strImgUsuario);
                CargaApps(_idUsuario);

                gpoApps.Enabled = false;
            }
            else
            {
                txtUsuario.Enabled = false;
                txtNombre.Enabled = false;
                txtApellidoPaterno.Enabled = false;
                txtApellidoMaterno.Enabled = false;
                cmbPlantel.Enabled = false;
                txtUsuarioSistema.Enabled = false;
                txtCorreo.Enabled = false;
            }
            CamposBloqueados();
        }

        private void CamposBloqueados()
        {
            if (_intBiene == 1)
            {
                txtUsuarioSistema.Enabled = false;
                ckbActivo.Enabled = false;
                chkAdmin.Enabled = false;
            }
        }

        private void FrmDatosUsuario_Load(object sender, EventArgs e)
        {
            this.Text = "Mantenimiento de Datos de usuario, Cambio de Contraseña";  
            if (_bUsuarioAdmin == true)
            {
                gpoApps.Enabled = true;
            }
          
        }

        private void FrmDatosUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_intpaso != 2)
            {
                MessageBox.Show("Se necesita reiniciar el sistema para que tome los nuevos cambios", "INFORMACION CONTRASEÑA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void txtPswActual_TextChanged(object sender, EventArgs e)
        {
            if (txtPswActual.Text != _mSeguridad.strContraseña)
            {
                imgContraseña.BackgroundImage = global::AppElyonCXC.Properties.Resources.cerrar;
                txtPswConfirmar.Enabled = false;
                txtPswNueva.Enabled = false;
            }
            else
            {
                imgContraseña.BackgroundImage = global::AppElyonCXC.Properties.Resources.Nuevo_Aceptar;
                txtPswConfirmar.Enabled = true;
                txtPswNueva.Enabled = true;
            }
            imgContraseña.Visible = true;
        }

        private void vEnviarCorreo(string strPara, string strSubject, string strMensaje, string contra)
        {
            try
            {
                //ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC();
                //mSeguridadElyon.mSeguridad _mSeguridad = new mSeguridadElyon.mSeguridad();

                string strMiEmail = "";
                string strServMail = "";
                string strUsuPasMail = "";
                string strPueMail = "";

                _mSeguridad.strContraseña = contra;

                DataSet dsParam = _mSeguridad.ObtenerParametros();
                if (dsParam.Tables[0].Rows.Count > 0)
                {
                    strMiEmail = dsParam.Tables[0].Rows[0].ItemArray[2].ToString();
                    strServMail = dsParam.Tables[0].Rows[0].ItemArray[4].ToString();
                    strUsuPasMail = dsParam.Tables[0].Rows[0].ItemArray[3].ToString();
                    strPueMail = dsParam.Tables[0].Rows[0].ItemArray[5].ToString();
                }

                int i = 0;


                string MiEmpresa = "UNIVA";
                string strEmail = strPara;
                string emailTo = strEmail;
                System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
                correo.From = new System.Net.Mail.MailAddress(MiEmpresa + "<" + strMiEmail + ">");
                correo.To.Add(emailTo);

                string strBody = "<table width='800' height='262' border='0' cellpadding='0' cellspacing='0'>" +
                                "<tr><td height='19' align='right'>" + DateTime.Now.ToShortDateString() + "</td></tr>" +
                                "<tr><td height='19'>Buen dia,</td></tr>" +
                                "<tr><td height='49' valign='bottom'>" + strMensaje + "</td></tr>" +
                                "<tr><td>&nbsp;</td></tr>" +
                                "<tr><td><b>Nombre:</b>" + txtNombre.Text + " " + txtApellidoPaterno.Text + " " + txtApellidoMaterno.Text + "</td></tr>" +
                                "<tr><td><b>Usuario:</b>" + _mSeguridad.strUsuario + "</td></tr>" +
                                "<tr><td><b>Contaseña:</b>" + _mSeguridad.strContraseña + "</td></tr>" +
                                "<tr><td>&nbsp;</td></tr>" +
                                "<tr><td width='401' style='border-top: #E46C0A solid 2px; text-align:right; color:#E46C0A'>Elyon- Cuentas x Cobrar</td></tr>" +
                                "</table>";


                correo.Body = strBody;
                correo.Subject = strSubject;
                correo.IsBodyHtml = true;
                correo.Priority = System.Net.Mail.MailPriority.High;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Host = strServMail;
                smtp.Port = int.Parse(strPueMail);
                smtp.Credentials = new System.Net.NetworkCredential(strMiEmail, strUsuPasMail);

                //Pendiente para Office 365
                //---------------------------
                smtp.EnableSsl = true;
                //---------------------------

                smtp.Send(correo);
                MessageBox.Show("Los datos de acceso han sido enviados al correo " + strPara, "Envió de Contraseña");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas al Enviar el correo. ERROR: " + ex.Message, "Envió de CONTRASEÑA");

            }

        }

        private Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsDatos = new DataSet();
                if (email_bien_escrito(txtCorreo.Text.Trim()))
                {
                    string strNuevaContraseña;
                    string strPart1 = !_mSeguridad.strConexion.Equals("INFORMIX") ? _mSeguridad.strUsuario.Substring(0, 1) : _mSeguridad.strUsuario.Substring(0, 1);
                    string strPart2 = !_mSeguridad.strConexion.Equals("INFORMIX") ? _mSeguridad.strUsuario.Substring(_mSeguridad.strUsuario.Length - 1, 1) : _mSeguridad.strUsuario.Substring(_mSeguridad.strUsuario.Length - 1, 1);
                    int intAlfa = 0;
                    string strCode1;
                    string strCode2;

                    switch (strPart1.ToLower())
                    {
                        case "a":
                            intAlfa = 1;
                            break;
                        case "b":
                            intAlfa = 2;
                            break;
                        case "c":
                            intAlfa = 3;
                            break;
                        case "d":
                            intAlfa = 4;
                            break;
                        case "e":
                            intAlfa = 5;
                            break;
                        case "f":
                            intAlfa = 6;
                            break;
                        case "g":
                            intAlfa = 7;
                            break;
                        case "h":
                            intAlfa = 8;
                            break;
                        case "i":
                            intAlfa = 9;
                            break;
                        case "j":
                            intAlfa = 10;
                            break;
                        case "k":
                            intAlfa = 11;
                            break;
                        case "l":
                            intAlfa = 12;
                            break;
                        case "m":
                            intAlfa = 13;
                            break;
                        case "n":
                            intAlfa = 14;
                            break;
                        case "ñ":
                            intAlfa = 15;
                            break;
                        case "o":
                            intAlfa = 16;
                            break;
                        case "p":
                            intAlfa = 17;
                            break;
                        case "q":
                            intAlfa = 18;
                            break;
                        case "r":
                            intAlfa = 19;
                            break;
                        case "s":
                            intAlfa = 20;
                            break;
                        case "t":
                            intAlfa = 21;
                            break;
                        case "u":
                            intAlfa = 22;
                            break;
                        case "w":
                            intAlfa = 23;
                            break;
                        case "x":
                            intAlfa = 24;
                            break;
                        case "y":
                            intAlfa = 25;
                            break;
                        case "z":
                            intAlfa = 26;
                            break;


                    }

                    strCode1 = (intAlfa * _mSeguridad.strUsuario.Length).ToString();

                    switch (strPart2.ToLower())
                    {
                        case "a":
                            intAlfa = 1;
                            break;
                        case "b":
                            intAlfa = 2;
                            break;
                        case "c":
                            intAlfa = 3;
                            break;
                        case "d":
                            intAlfa = 4;
                            break;
                        case "e":
                            intAlfa = 5;
                            break;
                        case "f":
                            intAlfa = 6;
                            break;
                        case "g":
                            intAlfa = 7;
                            break;
                        case "h":
                            intAlfa = 8;
                            break;
                        case "i":
                            intAlfa = 9;
                            break;
                        case "j":
                            intAlfa = 10;
                            break;
                        case "k":
                            intAlfa = 11;
                            break;
                        case "l":
                            intAlfa = 12;
                            break;
                        case "m":
                            intAlfa = 13;
                            break;
                        case "n":
                            intAlfa = 14;
                            break;
                        case "ñ":
                            intAlfa = 15;
                            break;
                        case "o":
                            intAlfa = 16;
                            break;
                        case "p":
                            intAlfa = 17;
                            break;
                        case "q":
                            intAlfa = 18;
                            break;
                        case "r":
                            intAlfa = 19;
                            break;
                        case "s":
                            intAlfa = 20;
                            break;
                        case "t":
                            intAlfa = 21;
                            break;
                        case "u":
                            intAlfa = 22;
                            break;
                        case "w":
                            intAlfa = 23;
                            break;
                        case "x":
                            intAlfa = 24;
                            break;
                        case "y":
                            intAlfa = 25;
                            break;
                        case "z":
                            intAlfa = 26;
                            break;


                    }


                    strCode2 = (intAlfa * _mSeguridad.strUsuario.Length).ToString();

                    strNuevaContraseña = strCode1 + DateTime.Now.Millisecond + strCode2;

                    string strMensaje = "El sistema de ELYON-Cuentas X Cobrar le envia su nueva contraseña,  Es necesario cambiar la contraseña al ingresar por primera vez al sistema. ";


                    _mSeguridad.strUsuario = txtUsuario.Text.Trim();
                    _mSeguridad.strContraseña = strNuevaContraseña;

                    //Modifica Datos Usuarios
                    _mSeguridad.strConexion = _strcon;
                    _mSeguridad.intPrimeraVes = 1;
                    if (_mSeguridad.ModificaContraseña())
                    {
                        vEnviarCorreo(txtCorreo.Text.Trim(), "Recuperación de contraseña - Sistema de ELYON-Cuentas X Cobrar", strMensaje, strNuevaContraseña);
                        cerrar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Modificar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void cerrar()
        {
            if (_intpaso != 2)
            {
                _intpaso = 1;
                MessageBox.Show("Se necesita reiniciar el sistema para que tome los nuevos cambios", "INFORMACION CONTRASEÑA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (email_bien_escrito(txtCorreo.Text))
            {
                if (bValido)
                {
                    _mSeguridad.strUsuario = txtUsuario.Text.Trim();
                    _mSeguridad.strUsuarioSistema = txtUsuarioSistema.Text.Trim();
                    _mSeguridad.bActivo = ckbActivo.Checked;
                    _mSeguridad.bAdmin = chkAdmin.Checked;
                    _mSeguridad.strEmail = txtCorreo.Text.Trim();

                    if (txtPswNueva.Text.Equals(txtPswConfirmar.Text) && (txtPswNueva.Text != _mSeguridad.strContraseña))
                        if (_mSeguridad.strContraseña.Length > 0)
                        {
                            _mSeguridad.strContraseña = txtPswNueva.Text;
                        }
                        else
                        {
                            MessageBox.Show("La contraseña no puede estar vacia");
                            return;
                        }
                    else
                    {
                        MessageBox.Show("Las contraseñas no son iguales");
                        return;
                    }

                    _mSeguridad.strConexion = _strcon;
                    _mSeguridad.intPrimeraVes = 2;

                    if (_mSeguridad.ModificaContraseña())
                    {
                       
                        if (txtPswNueva.Text != txtPswActual.Text)
                        {
                            string strMensaje = "Le informamos que su contraseña ha sido modificada sus nuevo datos de acceso son:";
                            vEnviarCorreo(_mSeguridad.strEmail, "Cambio de Contraseña - ELYON-Cuentas x Cobrar", strMensaje, txtPswNueva.Text);
                            cerrar();
                        }
                        else
                        {
                            string strMensaje = "Le informamos que ha sido dado de alta en el sistema de ELYON:Cuentas x Cobrar.";
                            vEnviarCorreo(_mSeguridad.strEmail, "Bienvenido al Sistema ELYON Cuentas x Cobrar", strMensaje, txtPswNueva.Text);
                            cerrar();

                        }
                    }
                }
                else
                    MessageBox.Show("El Usuario " + txtUsuario.Text + " ya existe");
            }
            else
                MessageBox.Show("El correo ingresado no es un correo valido");
        }

        private void btnEliminafoto_Click(object sender, EventArgs e)
        {
            try
            {
                _mSeguridad.intIdUsuario = _idUsuario;

                if (_mSeguridad.EliminaFotoUsuarios())
                {
                    MessageBox.Show("Imagen limpia, favor de reiniciar el sistema", "INFORMACION IMAGEN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex) { }
        }

        private void CargaImagen(string img)
        {
            if (img == null || img == "")
            {
                pbAltaFoto.Image = AppElyonCXC.Properties.Resources.add_user_128;
                pbAltaFoto.SizeMode = PictureBoxSizeMode.StretchImage;               
            }
            else
            {
                pbAltaFoto.Image = _mSeguridad.StringToImage(img);
                pbAltaFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }       
      
        private void btnCopiaImagen_Click(object sender, EventArgs e)
        {
            Image Tmp;
            string paso = "";
            string Paso1 = "";
            string RutaImagenesSalvadas = "";
            Tmp = pbAltaFoto.Image;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                RutaImagenesSalvadas = saveFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnCopiaImagen.Focus();
            }

             paso = RutaImagenesSalvadas;

            try
            {
                Tmp.Save(paso, ImageFormat.Jpeg);

                Paso1 = "La imagen fue copiada con exito a esta ruta: " + paso;
                MessageBox.Show(Paso1, "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDatos_Click(object sender, EventArgs e)
        {
            #region Almacenar Respuestas de Grid                          
            try
            {
                foreach (DataGridViewRow item in dtGridApps.Rows)
                {
                    _mSeguridad.intIdUsuario = _idUsuario;
                    _mSeguridad.intAplicacion = int.Parse(item.Cells[0].Value.ToString()); 
                    _mSeguridad.bAsignaAutomatico = bool.Parse(item.Cells[3].Value.ToString());

                    _mSeguridad.ModificaAppsUsuarios();
                }
            }
            catch (Exception ex) { }
            //dtGridApps.DataSource = null;
            CargaApps(_idUsuario);
            #endregion Almacenar Respuestas de Grid
        }

        private void AlmacenarImagen()
        {
            //Almacena Imagen Usuario

            //Serializa la Imagen del picture box
            string ImagenSerializada = _mSeguridad.ImageToString(pbAltaFoto.Image);

            _mSeguridad.intIdUsuario = _idUsuario;
            _mSeguridad.strvcImagen = ImagenSerializada;

            if (_mSeguridad.bAltaImagen())
            {
                //MessageBox.Show("Imagen Almacenada con exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("ERROR al Almacenar la Imagen", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnActDatos_Click(object sender, EventArgs e)
        {
            try
            {
                

                _mSeguridad.strUsuario = txtUsuario.Text.Trim();
                _mSeguridad.strUsuarioSistema = txtUsuarioSistema.Text.Trim();                                
                _mSeguridad.strEmail = txtCorreo.Text.Trim();
                if (ckbActivo.Checked == true)
                {
                    _mSeguridad.bActivo = ckbActivo.Checked;
                }
                else
                    _mSeguridad.bActivo = false;

                if (chkAdmin.Checked == true)
                {
                    _mSeguridad.bAdmin = chkAdmin.Checked;
                }
                else
                    _mSeguridad.bAdmin = false;

                if (_mSeguridad.ModificaDatosUsuario())
                {
                    MessageBox.Show("Usuario Actualizado...", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AlmacenarImagen();
                }
                else
                {
                    MessageBox.Show("ERROR al Actualiza el Usuario", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCorreo.Focus();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR al Actualiza el Usuario", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbAltaFoto_Click(object sender, EventArgs e)
        {
            //Cargar Fotos
            MessageBox.Show("La imagen debe de ser de 240 x 320 con resolucioin de 100", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
                string ruta = "";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ruta = openFileDialog1.FileName;

                    //Carga Foto
                    pbAltaFoto.ImageLocation = ruta;                    

                }
                else
                {
                    MessageBox.Show("Debe seleccionar un archivo", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pbAltaFoto.Focus();
                }
            
        }

        private void pbAltaFoto_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void pbAltaFoto_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
    }
}
