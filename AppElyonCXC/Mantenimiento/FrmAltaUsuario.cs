using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;

namespace AppElyonCXC.Mantenimiento
{
    public partial class FrmAltaUsuario : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);        
        #endregion

        string _strcon = "";
        int _idapp = 0;
        int _intpaso = 0;
        int _intPlantel;
        bool _bModificado = false;
        int _intModImagen = 0;

        public bool bModificado
        {
            get { return _bModificado; }
            set { _bModificado = value; }
        }

        public FrmAltaUsuario()
        {
            InitializeComponent();
        }
        #region apps
        public void CargaApps(CheckedListBox chkB)
        {

            string Apps;
            Apps = _mSeguridad.strJsonApps();
            List<ElyonModelCxC.Apps> LApps = JsonConvert.DeserializeObject<List<ElyonModelCxC.Apps>>(Apps);                                              
            chkB.DataSource = null;
            chkB.Items.Clear();

            foreach (var app in LApps)
            {
                chkB.Items.Add(new ElyonModelCxC.Apps { ID = app.ID, Nombre= app.Nombre });
            }
            chkB.DisplayMember = "Nombre";
            chkB.ValueMember = "ID";
        }

        
        #endregion apps
        public FrmAltaUsuario(int app, string con)
        {
            InitializeComponent();
            _idapp = app;
            _strcon = con;
            bModificado = false;
            //CargaPlantel();
            CargaApps(chkApps);
        }
        public string ListaAppsjson()
        {
            List<int> Lapps = new List<int>();
            for (int i = 0; i < chkApps.Items.Count; i++)
            {
                if (chkApps.GetItemChecked(i))
                {
                    ElyonModelCxC.Apps ap = (ElyonModelCxC.Apps)chkApps.Items[i];
                    Lapps.Add(ap.ID);
                }
            }

            return JsonConvert.SerializeObject(Lapps);

        }
        private void FrmAltaUsuario_Load(object sender, EventArgs e)
        {
            this.Text = "Mantenimiento de Alta de Usuario";           
            txtNomina.Focus();
            pbAltaFoto.Image = AppElyonCXC.Properties.Resources.add_user_128;
            pbAltaFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            _intModImagen = 0;
        }
        
        private void Reiniciar()
        {
            try
            {
                DataSet dsDatos = new DataSet();
                if (email_bien_escrito(txtCorreo.Text))
                {
                    string strNuevaContraseña;
                    string strPart1 = _mSeguridad.strUsuario.Substring(0, 1);
                    string strPart2 = _mSeguridad.strUsuario.Substring(_mSeguridad.strUsuario.Length - 1, 1);
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
                        
                        vEnviarCorreo(txtCorreo.Text.Trim(), "Recuperación de contraseña - Sistema de ELYON-Cuentas x Cobrar", strMensaje, strNuevaContraseña);
                        limpia();
                        
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
        private void vEnviarCorreo(string strPara, string strSubject, string strMensaje, string contra)
        {
            try
            {
                ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);

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



                string MiEmpresa = "PAtito.com";
                int i = 0;
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
                                "<tr><td width='401' style='border-top: #E46C0A solid 2px; text-align:right; color:#E46C0A'>Elyon- Cuentas X Cobrar</td></tr>" +
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
        //private void txtNomina_TextChanged(object sender, EventArgs e)
        //{
            //string fechaNac = "";
            //if (txtNomina.Text.Length == 10)
            //{
            //    try
            //    {
            //        _mSeguridad.strConexion = _strcon;
            //        txtNomina.Text = AgregaCeros(txtNomina.Text, 10);
            //        _mSeguridad.intNomina = txtNomina.Text;

            //           DataSet dsDatos = _mSeguridad.dsObtieneUsuario();

            //        if (dsDatos.Tables[0].Rows.Count > 0)
            //        {
            //            txtNombre.Text = dsDatos.Tables[0].Rows[0].ItemArray[0].ToString();
            //            txtApellidoPaterno.Text = dsDatos.Tables[0].Rows[0].ItemArray[1].ToString();
            //            txtApellidoMaterno.Text = dsDatos.Tables[0].Rows[0].ItemArray[2].ToString();
            //            fechaNac = dsDatos.Tables[0].Rows[0].ItemArray[3].ToString();

            //            try
            //            {
            //                if (fechaNac == "")
            //                {
            //                    dttpFecNac.Value = DateTime.Parse(DateTime.Now.ToLongDateString());
            //                }
            //                else
            //                {
            //                    fechaNac = fechaNac.Substring(0, 10);
            //                    dttpFecNac.Value = DateTime.Parse(fechaNac);
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                fechaNac = "";
            //            }
            //            //txtUsuario.Focus();
            //        }
            //    }
            //    catch (Exception ex) { }
            //}
        //}
        private string AgregaCeros(string recibeValor, int tipo)
        {
            string strRegresa = null;
            string strArma = "";
            int paso = 0;
            int i = 1;

            paso = (tipo - recibeValor.Length);

            while (i <= paso)
            {
                strRegresa += "0";
                i++;
            }
            strArma = strRegresa + recibeValor;
            strRegresa = strArma;
            return strRegresa;
        }
        private void FrmAltaUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpia();
        }
        private void limpia()
        {
            txtNomina.Text = "0";
            txtNombre.Text = null;
            txtApellidoPaterno.Text = null;
            txtApellidoMaterno.Text = null;
            dttpFecNac.Value = DateTime.Parse(DateTime.Now.ToLongDateString());
            txtUsuario.Text = null;
            txtDepto.Text = null;           
            txtPuesto.Text = null;
            txtCorreo.Text = null;
            txtNomina.Focus();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "")
            {
                MessageBox.Show("Se necesita Registrar un correo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Serializa la Imagen del picture box
            string ImagenSerializada = ImageToString(pbAltaFoto.Image);
            _mSeguridad.strvcImagen = ImagenSerializada;
            _mSeguridad.strConexion = _strcon;
            _mSeguridad.intNomina = txtNomina.Text;
            _mSeguridad.strUsuario = txtUsuario.Text;
            _mSeguridad.strUsuarioSistema = txtUsuario.Text; // txtUsuarioSistema.Text;
            _mSeguridad.strEmail = txtCorreo.Text;
            if (ckbActivo.Checked == true)
            {
                _mSeguridad.bActivo = ckbActivo.Checked;
            }
            else
                _mSeguridad.bActivo = false;

            //_mSeguridad.intPlantelID = cmbPlantel.SelectedValue.ToString();
            _mSeguridad.intPlantelID = "0";
            _mSeguridad.dtFechaNacimiento = DateTime.Parse(dttpFecNac.Value.ToShortDateString());
            _mSeguridad.intAplicacion = _idapp;

            _mSeguridad.StrJson = ListaAppsjson();



            if (chkAdmin.Checked == true)
            {
                _mSeguridad.bAdmin = chkAdmin.Checked;
            }
            else
                _mSeguridad.bAdmin = false;

            _mSeguridad.strvchNombre = txtNombre.Text;
            _mSeguridad.strvchPaterno = txtApellidoPaterno.Text;
            _mSeguridad.strvchMaterno = txtApellidoMaterno.Text;
            _mSeguridad.strvchClaveDepto = "001";
            _mSeguridad.strvchDescDepto = txtDepto.Text;
            _mSeguridad.strvchDescpuesto = txtPuesto.Text;

            if (_mSeguridad.AltaUsuario())
            {
                Reiniciar();
            }
            else
            {
                MessageBox.Show("Usuario ya Registrado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNomina.Focus();
            }
        }
        //Metodos para Serializar las Imagenes(
        public string ImageToString(Image imgx)
        {
            try
            {
                MemoryStream ms = new MemoryStream();

                imgx.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                byte[] array = ms.ToArray();

                return Convert.ToBase64String(array);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        private void pbAltaFoto_Click(object sender, EventArgs e)
        {
            //Cargar Fotos
            if (_intModImagen == 0)
            {
                string ruta = "";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ruta = openFileDialog1.FileName;

                    //Carga Foto
                    pbAltaFoto.ImageLocation = ruta;
                    _intModImagen = 1;

                }
                else
                {
                    MessageBox.Show("Debe seleccionar un archivo", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pbAltaFoto.Focus();
                }
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
        private void txtNomina_TextChanged(object sender, EventArgs e)
        {
            string fechaNac = "";
            if (txtNomina.Text.Length == 3)
            {
                try
                {
                    _mSeguridad.strConexion = _strcon;
                    txtNomina.Text = AgregaCeros(txtNomina.Text, 10);
                    _mSeguridad.intNomina = txtNomina.Text;

                    DataSet dsDatos = _mSeguridad.dsObtieneUsuario();

                    if (dsDatos.Tables[0].Rows.Count > 0)
                    {
                        txtNombre.Text = dsDatos.Tables[0].Rows[0].ItemArray[0].ToString();
                        txtApellidoPaterno.Text = dsDatos.Tables[0].Rows[0].ItemArray[1].ToString();
                        txtApellidoMaterno.Text = dsDatos.Tables[0].Rows[0].ItemArray[2].ToString();
                        fechaNac = dsDatos.Tables[0].Rows[0].ItemArray[3].ToString();
                        txtDepto.Text = dsDatos.Tables[0].Rows[0].ItemArray[4].ToString();
                        txtPuesto.Text = dsDatos.Tables[0].Rows[0].ItemArray[5].ToString();

                        try
                        {
                            if (fechaNac == "")
                            {
                                dttpFecNac.Value = DateTime.Parse(DateTime.Now.ToLongDateString());
                            }
                            else
                            {
                                fechaNac = fechaNac.Substring(0, 10);
                                dttpFecNac.Value = DateTime.Parse(fechaNac);
                            }
                        }
                        catch (Exception ex)
                        {
                            fechaNac = "";
                        }
                        //txtUsuario.Focus();
                    }
                }
                catch (Exception ex) { }
            }
        }
    }
}
