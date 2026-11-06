using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.IO;

namespace AppElyonCXC
{
    public partial class frmPrincipal : Form
    {
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);

        #region VARIABLES
        int _intKeyAnt = 0;
        string KeyMenuAnterior = "";
        string strImgUsuario = "";
        int _intModImagen = 0;
        string UsuarioIFX = "";
        string Usuario = "";
        string MensajeProceso = "";
        string NombreMensaje;
        DataSet DsInicial;
        DataSet DsInicial1;
        string _strEmail;
        string NombreCompleto;
        private DateTime strFechaCumple;
        string _No_nomina = "";
        string _IdUsuario = "0";
        int intValida = 0;
        int _intRegresa = 0;
        int _intIdApp = 0;
        private int intNivelSeguridad = 0;
        private int EstMenu;
        string _strConexion;
        string _strConexionFin;
        string _strRutaImagen;        
        string _img;
        int _i = 0;
        int _x = 0;
        int tot;
        bool _bUsuarioAdmin;
        String[] strAvisos;
        public static int _intCierraForma = 0;
        public static int _intSalida = 0;
        int _intAquiSalida = 0;
        Font tFont = new Font("Century Gothic", 12);        
        public static string strConexionFP;
        public static DataSet DsInicalesFP;
        bool cmbcombo = false;
        #endregion VARIABLES

        #region Constructor
        public frmPrincipal()
        {
            InitializeComponent();
        }

        public frmPrincipal(DataSet dsVer)
        {
            InitializeComponent();
            //_strConexion = con;
            //_strConexionFin = conFin;
            DsInicial = dsVer;            
            try
            {
                if (DsInicial.Tables[0].Rows.Count > 0)
                {
                    NombreCompleto = DsInicial.Tables[0].Rows[0]["NombreCompleto"].ToString();// + " " + DsInicial.Tables[0].Rows[0].ItemArray[1].ToString() + " " + DsInicial.Tables[0].Rows[0].ItemArray[2].ToString();
                    _strEmail = DsInicial.Tables[0].Rows[0]["Correo"].ToString();
                    UsuarioIFX = DsInicial.Tables[0].Rows[0]["Usuario Sistema"].ToString();
                    Usuario = DsInicial.Tables[0].Rows[0]["Usuario"].ToString();
                    strFechaCumple = DateTime.Parse(DsInicial.Tables[0].Rows[0]["FechaNacimiento"].ToString());
                    _No_nomina = DsInicial.Tables[0].Rows[0]["NOMINA"].ToString();
                    _IdUsuario = DsInicial.Tables[0].Rows[0]["IDUSUARIO"].ToString();
                    lbldepto.Text = (DsInicial.Tables[0].Rows[0]["NOMBREDEPTO"].ToString()).Trim();                    
                    //lblfecha.Text = DsInicial.Tables[0].Rows[0]["FECHAINICIO"].ToString();
                    _intIdApp = int.Parse(DsInicial.Tables[0].Rows[0]["IDAPP"].ToString());
                    _mSeguridad.intAplicacion = _intIdApp;
                    _bUsuarioAdmin = bool.Parse(DsInicial.Tables[0].Rows[0]["ADMIN"].ToString());
                    _mSeguridad.bAdmin = _bUsuarioAdmin;
                    strImgUsuario = DsInicial.Tables[0].Rows[0]["IMAGEN"].ToString();
                    CargaImagen(strImgUsuario);
                    lblPuesto.Text = DsInicial.Tables[0].Rows[0]["PUESTO"].ToString();
                    _strConexionFin = DsInicial.Tables[0].Rows[0]["CONEXION"].ToString();
                }
            }
            catch { }
        }
        #endregion Constructor

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            MensajeProceso = "Tss - Inventario";
            this.Text = MensajeProceso;

            timer1.Start();
            CargaDatosUsuario();

            if (_bUsuarioAdmin)
            {
                tlsbtnAccesos.Visible = true;
            }
            lblNotificaciones2.Visible = false;
        }    

        private void CargaDatosUsuario()
        {
            _x = 0;
            try
            {
                lblNomVersionIni.Text = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                lblver2.Text = lblNomVersionIni.Text;
            }
            catch
            {
                lblNomVersionIni.Text = "Compilado";
                lblver2.Text = lblNomVersionIni.Text;
            }
           
            _mSeguridad.strConexion = _strConexion;
            tsslblNombre.Text = "Bienvenid@ :" + NombreCompleto;
            lblNombreUsuIni.Text = NombreCompleto;           
            CargaMenus1();            
            CargaBotones();
            ValidaCumpleanos(strFechaCumple);
            tabControl1.SelectedIndex = 0;
            CargaAvisos();
            //CargaFormasUsadas();
        }

        private void ValidaCumpleanos(DateTime strcumple)
        {
            string strHoy = "";
            int intDia = 0;
            int intMes = 0;
            int intDiaUsuario = 0;
            int intMesUsuario = 0;

            //Obtiene el dia y el mes de Hoy
            strHoy = DateTime.Now.ToShortDateString();
            intDia = DateTime.Now.Day;
            intMes = DateTime.Now.Month;
            //intDia = int.Parse(strHoy.Substring(0, 2));
            //intMes = int.Parse(strHoy.Substring(3, 2));

            //Obtiene el dia y el mes del Usuario            
            intDiaUsuario = strcumple.Day;
            intMesUsuario = strcumple.Month;
            //intDiaUsuario = int.Parse(strcumple.Substring(0, 2));
            //intMesUsuario = int.Parse(strcumple.Substring(3, 2));


            if (intDia == intDiaUsuario && intMes == intMesUsuario)
            {
                frmAniversario frmcumple = new frmAniversario(NombreCompleto);
                frmcumple.ShowDialog();
                //MessageBox.Show("FELIZ CUMPLEAÑOS, que tengas un excelente dia hoy", "FELICIDADES", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            cerrar();
        }

        #region CREACION MENU BOTONES       
        private void CargaBotones()
        {
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic["IDUSUARIO"] = _IdUsuario;
            Dic["IDAPP"] = _intIdApp;
            Dic["USUARIO"] = Usuario;
            _mSeguridad.CargaMenusBotones(_IdUsuario, _intIdApp, pnlMenuPadre, pnlHijo, lblMnuHijo, tabControl1);
        }       
        void MiBoton_Click(object sender, EventArgs e)
        {
            int hj = 0;
            string KeyMenu = "";
            int intCargaMenu;
            int Lxh = 24; 
            int Lyh = 25; 
            int Lpasoh = 0;
            int intCuentaColumna = 0;            
            string NombreMenu;
            DataSet dtMenuBtnH = new DataSet();
            MenuItem mnuMenuItem = new MenuItem();
            _strRutaImagen = "";

            //Limpiar PANEL
            LimpiaPanel(pnlHijo);
            if (_intKeyAnt == 0)
            {
                Button btn = sender as Button;
                KeyMenu = btn.Text;
                KeyMenuAnterior = KeyMenu;
            }
            else
            {
                //Button btn = sender as Button;
                KeyMenu = KeyMenuAnterior;
                _intKeyAnt = 0;
            }

            pnlHijo.Visible = true;

            lblMnuHijo.Visible = true;
            lblMnuHijo.Text = "MENU/" + KeyMenu;
            lblMnuHijo.BringToFront();

            intCargaMenu = ObtieneNombreHijo(KeyMenu);
            hj = VerificaSitieneHijos(intCargaMenu.ToString());
            
            if (hj > 0)
            {
                _mSeguridad.strUsuario = _IdUsuario;
                _mSeguridad.strTipo = "0"; //0 = Escritorio y 1= WEB
                _mSeguridad.IDMenu = intCargaMenu;
                _mSeguridad.intAplicacion = _intIdApp;
                dtMenuBtnH = _mSeguridad.dsCargaMenuHijos();

                foreach (DataRow drMenuItem in dtMenuBtnH.Tables[0].Rows)
                {
                    //'esta condicion indica q son elementos padre.   
                    if (drMenuItem["PK_Menu"].ToString() != drMenuItem["idpadre"].ToString())                                 
                    {
                        intCuentaColumna++;

                        //Para cambio de columna
                        if (intCuentaColumna == 9)
                        {
                            intCuentaColumna = 0;
                            Lxh = Lxh + 223;
                            Lyh = 25;
                            intCuentaColumna++;
                        }

                        //Para la separacion de los botones Vertical
                        if (Lpasoh != 0)
                        {
                            Lpasoh = 1;
                        }
                        else
                        {
                            Lyh = Lyh + 58;
                        }

                        NombreMenu = drMenuItem["NombreProceso"].ToString();

                        #region CREACION DE BOTONES
                        Button miBoton = new Button();
                        miBoton.Name = drMenuItem["PK_Menu"].ToString();
                        miBoton.Text = drMenuItem["NombreProceso"].ToString();
                        miBoton.TextImageRelation = TextImageRelation.ImageAboveText;
                        _strRutaImagen = drMenuItem["Ruta"].ToString();

                        #region Asigna Imagen
                        object O = AppElyonCXC.Properties.Resources.ResourceManager.GetObject(_strRutaImagen);
                        miBoton.Image = (Image)O;
                        #endregion Asigna Imagen

                        #region Diseño de boton                                  
                        miBoton.Click += new EventHandler(MiBoton_Click1);
                        miBoton.MouseLeave += new EventHandler(MiBoton_MouseLeave);
                        miBoton.MouseMove +=  new MouseEventHandler(MiBoton_MouseMove);
                        if (NombreMenu.Length > 11)
                        {
                            miBoton.TextAlign = ContentAlignment.MiddleRight;
                        }
                        else
                        {
                            miBoton.TextAlign = ContentAlignment.MiddleCenter;
                        }
                        miBoton.ImageAlign = ContentAlignment.MiddleLeft;
                        miBoton.FlatStyle = FlatStyle.Flat;

                        miBoton.Width = 203;
                        miBoton.Height = 42;
                        miBoton.Location = new Point(Lxh, Lyh);
                        miBoton.Font = tFont;
                        #endregion Diseño de boton                                  
                        #endregion CREACION DE BOTONES

                        #region CREACION ETIQUETA
                        //Label miLabel = new Label();
                        //miLabel.Name = drMenuItem["PK_Menu"].ToString();
                        //miLabel.Text = drMenuItem["NombreProceso"].ToString();                        
                        //_strRutaImagen = drMenuItem["Ruta"].ToString();

                        #region Asigna Imagen
                        //object O = AppElyonCXC.Properties.Resources.ResourceManager.GetObject(_strRutaImagen);
                        //miLabel.Image = (Image)O;
                        #endregion Asigna Imagen

                        #region Diseño de label                                                         
                        //miLabel.Click += new EventHandler(MiLabel_Click);
                        //miLabel.MouseLeave += new EventHandler(MiLabel_MouseLeave);
                        //miLabel.MouseMove += new MouseEventHandler(MiLabel_MouseMove);

                        ////miLabel.AutoSize = true;
                        //if (NombreMenu.Length > 11)
                        //{
                        //    miLabel.TextAlign = ContentAlignment.MiddleRight;
                        //}
                        //else
                        //{
                        //    miLabel.TextAlign = ContentAlignment.MiddleCenter;
                        //}

                        //miLabel.ImageAlign = ContentAlignment.MiddleLeft;
                        //miLabel.FlatStyle = FlatStyle.Flat;

                        //miLabel.Width = 203; 
                        //miLabel.Height = 42; 
                        //miLabel.Location = new Point(Lxh, Lyh);
                        //miLabel.Font = tFont;
                        #endregion Diseño de boton 

                        //this.pnlHijo.Controls.Add(miLabel);
                        #endregion CREACION ETIQUETA

                        this.pnlHijo.Controls.Add(miBoton);
                    }

                }                        
                
            }
            else
                MessageBox.Show("NO HIJOS, que voy hacer?");

        }

        private void MiBoton_MouseMove(object sender, MouseEventArgs e)
        {
            Button ybtn = sender as Button;
            ybtn.BackColor = Color.FromArgb(0, 121, 192);
            ybtn.ForeColor = Color.White;
        }

        private void MiBoton_MouseLeave(object sender, EventArgs e)
        {
            Button xbtn = sender as Button;
            xbtn.BackColor = Color.Transparent;
            xbtn.ForeColor = Color.Black;
        }       

        //ClicK de los Hijos
        private void MiBoton_Click1(object sender, EventArgs e)
        {
            int hj = 0;
            string KeyMenu = "";
            int intCargaMenu;
            int Lxh = 24;
            int Lyh = 25;
            int Lpasoh = 0;
            int intCuentaColumna = 0;
            string NombreMenu;
            DataSet dtMenuBtnH = new DataSet();
            MenuItem mnuMenuItem = new MenuItem();
            _strRutaImagen = "";

            Button btn = sender as Button;
            KeyMenu = btn.Text;

            pnlHijo.Visible = true;

            intCargaMenu = ObtieneNombreHijo(KeyMenu);
            hj = VerificaSitieneHijos(intCargaMenu.ToString());

            if (hj > 0)
            {
                //Limpiar PANEL
                LimpiaPanel(pnlHijo);

                #region BOTON REGRESAR            
                PictureBox pcRegrsar = new PictureBox();
                pcRegrsar.Name = "pboxRegresar";
                #region Asigna Imagen
                object Oi = AppElyonCXC.Properties.Resources.left_circular_32;
                pcRegrsar.Image = (Image)Oi;
                pcRegrsar.Location = new Point(3, 3);
                pcRegrsar.SizeMode = PictureBoxSizeMode.AutoSize;
                pcRegrsar.Click += new EventHandler(PcRegrsar_Click);
                this.pnlHijo.Controls.Add(pcRegrsar);
                #endregion Asigna Imagen                        
                #endregion BOTON REGRESAR

                lblMnuHijo.Visible = true;
                lblMnuHijo.Text = lblMnuHijo.Text + "/" + KeyMenu;
                lblMnuHijo.BringToFront();

                _mSeguridad.strUsuario = _IdUsuario;
                _mSeguridad.strTipo = "0"; //0 = Escritorio y 1= WEB
                _mSeguridad.IDMenu = intCargaMenu;
                _mSeguridad.intAplicacion = _intIdApp;
                dtMenuBtnH = _mSeguridad.dsCargaMenuHijos();

                foreach (DataRow drMenuItem in dtMenuBtnH.Tables[0].Rows)
                {
                    //'esta condicion indica q son elementos padre.   
                    if (drMenuItem["PK_Menu"].ToString() != drMenuItem["idpadre"].ToString())
                    {
                        intCuentaColumna++;

                        //Para cambio de columna
                        if (intCuentaColumna == 9)
                        {
                            intCuentaColumna = 0;
                            Lxh = Lxh + 223;
                            Lyh = 25;
                            intCuentaColumna++;
                        }

                        //Para la separacion de los botones Vertical
                        if (Lpasoh != 0)
                        {
                            Lpasoh = 1;
                        }
                        else
                        {
                            Lyh = Lyh + 58;
                        }

                        NombreMenu = drMenuItem["NombreProceso"].ToString();

                        #region CREACION DE BOTONES
                        Button miBoton1 = new Button();
                        miBoton1.Name = drMenuItem["PK_Menu"].ToString();
                        miBoton1.Text = drMenuItem["NombreProceso"].ToString();
                        miBoton1.TextImageRelation = TextImageRelation.ImageAboveText;
                        _strRutaImagen = drMenuItem["Ruta"].ToString();

                        #region Asigna Imagen
                        object O = AppElyonCXC.Properties.Resources.ResourceManager.GetObject(_strRutaImagen);
                        miBoton1.Image = (Image)O;
                        #endregion Asigna Imagen

                        #region Diseño de boton   
                        miBoton1.Click += new EventHandler(MiBoton1_Click);
                        miBoton1.MouseLeave += new EventHandler(MiBoton1_MouseLeave);
                        miBoton1.MouseMove += new MouseEventHandler(MiBoton1_MouseMove);

                        if (NombreMenu.Length > 11)
                        {
                            miBoton1.TextAlign = ContentAlignment.MiddleRight;
                        }
                        else
                        {
                            miBoton1.TextAlign = ContentAlignment.MiddleCenter;
                        }
                        miBoton1.ImageAlign = ContentAlignment.MiddleLeft;
                        miBoton1.FlatStyle = FlatStyle.Flat;

                        miBoton1.Width = 203;
                        miBoton1.Height = 42;
                        miBoton1.Location = new Point(Lxh, Lyh);
                        miBoton1.Font = tFont;
                        #endregion Diseño de boton                                  
                        #endregion CREACION DE BOTONES



                        this.pnlHijo.Controls.Add(miBoton1);
                    }

                }

            }
            else
            {
                MiBoton1_Click(sender, e);
            }
        }

        private void PcRegrsar_Click(object sender, EventArgs e)
        {
            _intKeyAnt = 1;
            MiBoton_Click(sender, e);
        }

        private void MiBoton1_MouseMove(object sender, MouseEventArgs e)
        {
            Button ybtn = sender as Button;
            ybtn.BackColor = Color.FromArgb(0, 121, 192);
            ybtn.ForeColor = Color.White;
        }

        private void MiBoton1_MouseLeave(object sender, EventArgs e)
        {
            Button xbtn = sender as Button;
            xbtn.BackColor = Color.Transparent;
            xbtn.ForeColor = Color.Black;
        }

        private void MiBoton1_Click(object sender, EventArgs e)
        {
            string KeyMenu;
            Button btn = sender as Button;
            KeyMenu = btn.Text;

            ObtieneNombreMenu(KeyMenu);
        }
        #endregion CREACION MENU BOTONES

        #region FORMA MENU
        private void CargaMenus1()
        {
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic["IDUSUARIO"] = _IdUsuario;
            Dic["IDAPP"] = _intIdApp;
            Dic["USUARIO"] = Usuario;
            _mSeguridad.CargaMenus(Dic, menuStrip1, tabControl1);
            //_mSeguridad.CargaMenus(_IdUsuario, _intIdApp, menuStrip1, tabControl1);                        
        }       
        #endregion FORMA MENU

        #region ARMA FORMA
        private void ObtieneNombreMenu(string KeyMenu)
        {
            string strItem;
            string strPrograma = "";
            string strMenuId = "";
            DataSet DsMnus = new DataSet();

            try
            {
                _mSeguridad.strNombreMenu = KeyMenu;
                DsMnus = _mSeguridad.dsSeleccionaMenusNombre();

                if (DsMnus.Tables[0].Rows.Count > 0)
                {
                    NombreMensaje = DsMnus.Tables[0].Rows[0].ItemArray[1].ToString();
                    strItem = DsMnus.Tables[0].Rows[0].ItemArray[2].ToString();
                    strPrograma = DsMnus.Tables[0].Rows[0].ItemArray[9].ToString();
                    strMenuId = DsMnus.Tables[0].Rows[0].ItemArray[10].ToString();

                    OpcionMenu(strPrograma, strItem, NombreMensaje, strMenuId);
                }
                else
                {
                    MessageBox.Show("NO existen Menus");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Procedimiento fallo");
            }
        }

        private void OpcionMenu(string strPrograma, string strItem, string NomMje, string strMid)
        {
            if (strPrograma == null || strPrograma == "")
            {
                MessageBox.Show("Menu Padre");
            }
            else
            {
                //Valida Nivel de Seguridad
                intValida = VerificaAcceso(strMid, _IdUsuario);
                if (intValida == 0)
                {
                    MessageBox.Show("Acceso No Permitido");
                }
                else
                {
                    EstatusMenu(strItem);
                    if (EstMenu == 0)
                    {
                        MessageBox.Show("Programa en Mantenimiento ó Programa Deshabilitado");
                    }
                    else
                    {
                        //Cargar Opcion de Menus                       
                        CargaFormax(strPrograma, NomMje);
                    }
                }
            }
        }
        private void CargaFormax(string strPrograma, string NombreMje)
        {

            try
            {
                Form Formulario = default(Form);
                Type tipoObjeto = null;

                #region Creas tabla Parametros 
                DataTable dtbDatos = new DataTable("Parametros");
                dtbDatos.Columns.Add("Usuario");
                dtbDatos.Columns.Add("NivelSeguridad");
                dtbDatos.Columns.Add("NombreMensaje");
                dtbDatos.Columns.Add("Conexion");
                dtbDatos.Columns.Add("Aplicacion");
                dtbDatos.Columns.Add("ConexionFin");
                dtbDatos.Columns.Add("UsuarioAdmin");
                dtbDatos.Columns.Add("UsuarioSistema");
                #endregion

                #region Para Almacenar en la tabla parametros a mostrar
                DataRow dtrError = dtbDatos.NewRow();
                dtrError["Usuario"] = _IdUsuario;
                dtrError["NivelSeguridad"] = intNivelSeguridad.ToString();
                dtrError["NombreMensaje"] = NombreMje;
                dtrError["Conexion"] = _mSeguridad.strConexion;
                dtrError["Aplicacion"] = _mSeguridad.intAplicacion;
                dtrError["ConexionFin"] = _strConexionFin;
                dtrError["UsuarioAdmin"] = _bUsuarioAdmin;
                dtrError["UsuarioSistema"] = Usuario;

                dtbDatos.Rows.Add(dtrError);
                DataSet DsParam = new DataSet();
                DsParam.Tables.Add(dtbDatos);
                #endregion Para Almacenar en la tabla a mostrar

                System.Reflection.Assembly assb = System.Reflection.Assembly.GetExecutingAssembly();
                tipoObjeto = assb.GetType(strPrograma);

                string wSTproyecto = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                string wSTformulario = wSTproyecto + '.' + strPrograma;

                if (wSTformulario.Contains("Report"))
                {
                    object objeto = Activator.CreateInstance(Type.GetType(wSTformulario));
                    Formulario = (Form)objeto;
                }
                else
                {
                    //MessageBox.Show(wSTformulario);
                    //MessageBox.Show(Type.GetType(wSTformulario).ToString());
                    object objeto = Activator.CreateInstance(Type.GetType(wSTformulario), DsParam);
                    Formulario = (Form)objeto;
                }
                
                //Crea Tabpage
                string title = "TabPage" + (tabControl1.TabCount + 1).ToString();
                TabPage myTabPage = new TabPage(title);
                myTabPage.Text = NombreMje;
                //Crea Panel
                Panel pnl = new Panel();
                pnl.Dock = DockStyle.Fill;                                               

                if (pnl.Controls.Count > 0)
                    pnl.Controls.RemoveAt(0);

                _intCierraForma = 1;                
                Formulario.TopLevel = false;
                Formulario.FormBorderStyle = FormBorderStyle.None;
                Formulario.Dock = DockStyle.Fill;
                
                //Asigna Formulario al panel
                pnl.Controls.Add(Formulario);                
                pnl.Tag = Formulario;
                myTabPage.Controls.Add(pnl);                
                tabControl1.TabPages.Add(myTabPage);
                Formulario.Show();
                tabControl1.SelectedTab = myTabPage;

                //Para formulario normal
                //--------------------------------------------------
                //Formulario.WindowState = FormWindowState.Normal;
                //Formulario.ControlBox = true;
                //Formulario.StartPosition = FormStartPosition.CenterParent;
                //Formulario.Text = NombreMje;
                //Formulario.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Formulario no encontrado \n\n" + ex.Message);
                _intCierraForma = 0;
            }
        }
       #endregion ARMA FORMA

        #region VERIFICA ACCESOS
        public int VerificaAcceso(string NombreItem, string Usuario)
        {
            try
            {
                DataSet dsPermiso = new DataSet();
                _mSeguridad.strUsuario = _IdUsuario;
                _mSeguridad.strNombreItem = NombreItem;
                _mSeguridad.intNivel = 0;
                _mSeguridad.intAplicacion = _intIdApp;

                dsPermiso = _mSeguridad.dsCargaPermisosMenus();


                if (dsPermiso.Tables[0].Rows.Count > 0)
                {
                    _intRegresa = (int)dsPermiso.Tables[0].Rows[0].ItemArray[0];
                    if (_intRegresa > 0)
                    {
                        intValida = 1;
                        intNivelSeguridad = _intRegresa;
                    }
                    else
                    {
                        intValida = 0;
                        intNivelSeguridad = _intRegresa;
                    }
                }
                else
                {
                    intValida = 0;
                    intNivelSeguridad = _intRegresa;
                }
            }
            catch
            {
                intValida = 0;
                intNivelSeguridad = _intRegresa;
            }
            
            return intValida;
        }

        public int EstatusMenu(string strItemNombre)
        {
            
                DataSet dsEstMnu = new DataSet();
                try
                {
                    _mSeguridad.strNombreItem = strItemNombre;
                    _mSeguridad.intAplicacion = _intIdApp;

                    dsEstMnu = _mSeguridad.dsVerificaEstadoMenu();

                    if (dsEstMnu.Tables[0].Rows.Count > 0)
                    {
                        EstMenu = (int)dsEstMnu.Tables[0].Rows[0].ItemArray[0];
                    }
                    else
                    {
                        EstMenu = 0;
                    }

                }
                catch (Exception ex)
                { }
           
            return EstMenu;
        }
        #endregion VERIFICA ACCESOS

        #region FORMA MENU HIJO
        private int ObtieneNombreHijo(string KeyMenu)
        {            
            string strItem;
            string strPrograma = "";
            string strMenuId = "";
            DataSet DsMnus = new DataSet();

            try
            {
                _mSeguridad.strNombreMenu = KeyMenu;
                _mSeguridad.intAplicacion = _intIdApp;
                DsMnus = _mSeguridad.dsSeleccionaMenusNombre();

                if (DsMnus.Tables[0].Rows.Count > 0)
                {
                    NombreMensaje = DsMnus.Tables[0].Rows[0].ItemArray[1].ToString();
                    strItem = DsMnus.Tables[0].Rows[0].ItemArray[2].ToString();
                    strPrograma = DsMnus.Tables[0].Rows[0].ItemArray[9].ToString();
                    strMenuId = DsMnus.Tables[0].Rows[0].ItemArray[10].ToString();                    
                }
                else
                {
                    MessageBox.Show("NO existen Menus");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Procedimiento fallo");
            }

            
            return int.Parse(strMenuId);
        }

        private int VerificaSitieneHijos(string ID)
        {
            int intReg = 0;

            _mSeguridad.IDMenu = int.Parse(ID);
            DataSet dsVl =_mSeguridad.dsValidaMenusHijos();

            if (dsVl.Tables[0].Rows.Count > 0)
            {
                intReg = int.Parse(dsVl.Tables[0].Rows[0].ItemArray[0].ToString());
            }
            else
                intReg = 0;

            return intReg;
        }

        #endregion FORMA MENU HIJO
       
        #region AVISOS
        private void CargaAvisos()
        {
            DataSet dsimg =  _mSeguridad.dsCargaAvisos();
            
            if (dsimg.Tables[0].Rows.Count > 0)
            {
                //btnder.Enabled = true;
                //btnIzq.Enabled = true;
                //btnRecraga.Enabled = true;
                //pictureBox1.Image = StringToImage(dsimg.Tables[0].Rows[0].ItemArray[2].ToString());
                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                CargaArregloAvisos(dsimg);
            }
            else
            {
                //pictureBox1.Image = null;
                //btnder.Enabled = false;
                //btnIzq.Enabled = false;
                //btnRecraga.Enabled = false;
            }
           
        }

        private void CargaArregloAvisos(DataSet dsimg)
        {
            _i = 0;
            
            //DataSet dsimg = _mSeguridad.dsCargaAvisos();
            if (dsimg.Tables[0].Rows.Count > 0)
            {
                strAvisos = new string[dsimg.Tables[0].Rows.Count];

                while (_i < dsimg.Tables[0].Rows.Count)
                {
                    _img = dsimg.Tables[0].Rows[_i].ItemArray[2].ToString();

                    strAvisos[_i] = _img;
                    if (_i >= 9)
                        break;

                    _i++;
                }
            }            
        }        
        public Image StringToImage(string imageString)
        {

            if (imageString == null)

                throw new ArgumentNullException("imageString");

            byte[] array = Convert.FromBase64String(imageString);

            System.Drawing.Image image = System.Drawing.Image.FromStream(new MemoryStream(array));

            return image;

        }       
        #endregion AVISOS

        #region FUNCIONES
        private void LimpiaPanel (Panel pnl)
        {
            //Limpiar PANEL
            if (pnl.Controls.Count > 0)
            {

                for (int x = 0; x <= pnl.Controls.Count - 1; x++)
                {
                    Control c = pnl.Controls[x];
                    if (c.GetType() != typeof(Label))
                    {
                        pnl.Controls.Remove(c);
                        x--;
                    }
                }
            }
        }
        private void RecibeUsuario(DataSet dsVer, string con)
        {
            DsInicial = dsVer;
            strImgUsuario = "";
            try
            {
                if (DsInicial.Tables[0].Rows.Count > 0)
                {
                    NombreCompleto = DsInicial.Tables[0].Rows[0].ItemArray[0].ToString();// + " " + DsInicial.Tables[0].Rows[0].ItemArray[1].ToString() + " " + DsInicial.Tables[0].Rows[0].ItemArray[2].ToString();
                    _strEmail = DsInicial.Tables[0].Rows[0].ItemArray[1].ToString();
                    UsuarioIFX = DsInicial.Tables[0].Rows[0].ItemArray[5].ToString();
                    Usuario = DsInicial.Tables[0].Rows[0].ItemArray[6].ToString();
                    strFechaCumple = DateTime.Parse(DsInicial.Tables[0].Rows[0].ItemArray[7].ToString());
                    _No_nomina = DsInicial.Tables[0].Rows[0].ItemArray[8].ToString();
                    _IdUsuario = DsInicial.Tables[0].Rows[0].ItemArray[9].ToString();
                    lbldepto.Text = (DsInicial.Tables[0].Rows[0].ItemArray[10].ToString()).Trim() + "-" + (DsInicial.Tables[0].Rows[0].ItemArray[11].ToString()).Trim();
                    lblPuesto.Text = DsInicial.Tables[0].Rows[0].ItemArray[17].ToString();
                    //lblfecha.Text = DsInicial.Tables[0].Rows[0].ItemArray[12].ToString();
                    _intIdApp = int.Parse(DsInicial.Tables[0].Rows[0].ItemArray[13].ToString());
                    _mSeguridad.intAplicacion = _intIdApp;
                    strImgUsuario = DsInicial.Tables[0].Rows[0]["IMAGEN"].ToString();
                    CargaImagen(strImgUsuario);
                }
            }
            catch { }
        }
        private void CargaImagen(string img)
        {
            if (img == null || img == "")
            {
                pbAltaFoto.Image = AppElyonCXC.Properties.Resources.add_user_128;
                pbAltaFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                _intModImagen = 0;
            }
            else
            {
                pbAltaFoto.Image = _mSeguridad.StringToImage(img);
                pbAltaFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                _intModImagen = 1;
            }
        }
        private void CerrarTabcontrols()
        {
            //Cerrar todos los Tabcontrols
            foreach (TabPage pa in tabControl1.TabPages)
            {
                if (!pa.Text.Equals("INICIO") && !pa.Text.Equals("MENU"))
                {
                    //Para cerra la forma abierta
                    foreach (Control ss in pa.Controls)
                    {
                        if (ss.GetType() == typeof(Panel))
                        {
                            foreach (Control ss1 in ss.Controls)
                            {
                                if (ss1.GetType().BaseType == typeof(Form))
                                {
                                    ((Form)ss1).Close();
                                }
                            }
                        }
                    }
                    tabControl1.TabPages.Remove(pa);
                }
            }
        }
        public string NombreProceso(string NomProceso)
        {
            string Regresar = "";
            DataSet dsmp = new DataSet();
            try
            {
                _mSeguridad.strNombreProceso = NomProceso;
                dsmp = _mSeguridad.dsNombreProceso();
                if (dsmp.Tables[0].Rows.Count > 0)
                {
                    Regresar = dsmp.Tables[0].Rows[0].ItemArray[0].ToString();
                }
                else
                {
                    Regresar = "ELYON-Finanzas[Falta registrar nombre]";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO existe Opcion de menu", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Regresar;
        }
        public string ObtieneSiglasProceso(string SigProceso)
        {
            string SiglasProceso = "";
            DataSet dsmp = new DataSet();
            try
            {
                _mSeguridad.strNombreProceso = SigProceso;
                dsmp = _mSeguridad.dsNombreProceso();
                if (dsmp.Tables[0].Rows.Count > 0)
                {
                    SiglasProceso = dsmp.Tables[0].Rows[0].ItemArray[1].ToString();
                }
                else
                {
                    SiglasProceso = SigProceso;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO existe Opcion de menu", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return SiglasProceso;
        }

        //private void CargaFormasUsadas()
        //{
        //    DataSet dtmns = new DataSet();
        //    cmbUsadosMas.DataSource = null;
        //    try
        //    {
        //        _mSeguridad.intIdUsuario = int.Parse(_IdUsuario);
        //        _mSeguridad.intAplicacion = _intIdApp;
        //        _mSeguridad.intCantidad = 10; //Total de Menus a cargar               

        //        dtmns = _mSeguridad.dsobtieneMenusUsados();
        //        if (dtmns.Tables[0].Rows.Count > 0)
        //        {
        //            //Inserta Registro en Blanco
        //            dtmns.Tables[0].Rows.InsertAt(dtmns.Tables[0].NewRow(), 0);

        //            cmbUsadosMas.DataSource = dtmns.Tables[0].DefaultView;
        //            cmbUsadosMas.ValueMember = "ID";
        //            cmbUsadosMas.DisplayMember = "Nombre";
        //            cmbcombo = true;
        //        }
        //        else
        //        {
        //            cmbcombo = false;
        //            MessageBox.Show("No hay datos de Menus Usados a cargar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        cmbcombo = false;
        //        //MessageBox.Show(ex.ToString());
        //    }
        //}

        #endregion FUNCIONES

        #region NOTIFICACIONES
        private int BuscaNotificacion()
        {
            int repnot = 0;

            try
            {
                _mSeguridad.strUsuario = _IdUsuario.ToString();
                _mSeguridad.intAplicacion = _intIdApp;

                DataSet dsnot = _mSeguridad.BuscaNotificaciones();
                if (dsnot.Tables[0].Rows.Count > 0)
                {
                    repnot = int.Parse(dsnot.Tables[0].Rows[0].ItemArray[0].ToString());
                }

            }
            catch (Exception ex)
            {
                repnot = 0;
                GuardaNotificacion(int.Parse(_IdUsuario), _intIdApp, "Msj SisError BuscaNotificaciones:" + ex.ToString(), DateTime.Now, 0, 0, 0);
            }
            return repnot;
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            int RepNoti = 0;
            RepNoti = BuscaNotificacion();

            if (RepNoti > 0)
            {
                lblNotificaciones2.Visible = true;
                tlspNotificacion1.Image = AppElyonCXC.Properties.Resources.NotificacionBlackBlue1;
                if (RepNoti == 1)
                {
                    lblNotificaciones2.Text = "Tienes " + RepNoti + " nueva notificacion.";
                }
                else
                {
                    lblNotificaciones2.Text = "Tienes " + RepNoti + " nuevas notificaciones...";
                }
            }
            else
            {
                lblNotificaciones2.Visible = false;
                tlspNotificacion1.Image = AppElyonCXC.Properties.Resources.NotificacionBlack1;
                //lblNotificaciones.Text = "Tiene " + Repnoti + " nuevas notificaciones...";
            }

            //Para Girar Automatica las imagenes
            //try
            //{
            //    tot = strAvisos.Count();
            //    _x++;
            //    pictureBox1.Image = StringToImage(strAvisos[_x]);
            //    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            //}
            //catch (Exception ex)
            //{
            //    _i = 0;
            //    CargaAvisos();                
            //    _x = 0;               
            //    pictureBox1.Image = StringToImage(strAvisos[_x]);
            //    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //}
        }

        private void tlspNotificacion1_Click(object sender, EventArgs e)
        {
            AppElyonCXC.Mantenimiento.FrmAvisosFlotante frmAviso = new Mantenimiento.FrmAvisosFlotante(_IdUsuario, _intIdApp);
            frmAviso.ShowDialog();

            tlspNotificacion1.Image = AppElyonCXC.Properties.Resources.NotificacionBlack1;
        }
        #endregion NOTIFICACIONES

        #region EVENTO
        private void cambioDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //cierra tabpages
            CerrarTabcontrols();
            //cierra session
            menuStrip1.Items.Clear();
            //Limpiar PANEL PADRE
            LimpiaPanel(pnlMenuPadre);
            //Limpiar PANEL HIJO
            LimpiaPanel(pnlHijo);

            //Marca inicio de Session
            _mSeguridad.CerrarSession(int.Parse(_IdUsuario), _intIdApp, 0);

            //Llama uSuario Nuevo
            Login fp = new Login(1);
            fp.ShowDialog();
            _intAquiSalida = _intSalida;
            DsInicial1 = DsInicalesFP;

            if (_intAquiSalida == 0)
            {
                //Regresa de Principal
                DsInicial = DsInicial1;
                _strConexion = strConexionFP;

                //Procesa Informacion de Principal
                menuStrip1.Items.Clear();
                RecibeUsuario(DsInicial, _strConexion);
                CargaDatosUsuario();
            }
            else
            {
                //Procesa Informacion de Principal
                menuStrip1.Items.Clear();
                CargaDatosUsuario();
            }
        }
        private void actualizaMenusToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            menuStrip1.Items.Clear();
            //Limpiar PANEL PADRE
            LimpiaPanel(pnlMenuPadre);
            //Limpiar PANEL HIJO
            LimpiaPanel(pnlHijo);
            CargaMenus1();
            CargaBotones();
        }
        private void btnZoom_Click(object sender, EventArgs e)
        {
            //mandar a un form
            //Mantenimiento.FrmZoomAvisos zoom = new Mantenimiento.FrmZoomAvisos(pictureBox1);
            //zoom.ShowDialog();
        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerrar();
        }
        private void cerrar()
        {
            timer1.Stop();
            AlmacenarImagen();
            _mSeguridad.CerrarSession(int.Parse(_IdUsuario), _intIdApp, 0);
            Application.Exit();
        }
        private void AlmacenarImagen()
        {
            //Almacena Imagen Usuario

            //Serializa la Imagen del picture box
            string ImagenSerializada = _mSeguridad.ImageToString(pbAltaFoto.Image);

            _mSeguridad.intIdUsuario = int.Parse(_IdUsuario);
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
        private void pbAltaFoto_Click(object sender, EventArgs e)
        {
            //Cargar Fotos
            
            if (_intModImagen == 0)
            {
                MessageBox.Show("La imagen debe de ser de 240 x 320 con resolucioin de 100", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void MnuTsbtnAccesos_Click(object sender, EventArgs e)
        {
            //Key del Menus
            DataSet dsParam = GeneraTablaTemporalInicial();
            Mantenimiento.FrmMenus frmnu = new Mantenimiento.FrmMenus(dsParam);
            frmnu.ShowDialog();
        }
        private DataSet GeneraTablaTemporalInicial()
        {
            #region Creas tabla Parametros 
            DataTable dtbDatos = new DataTable("Parametros");
            dtbDatos.Columns.Add("Usuario");
            dtbDatos.Columns.Add("NivelSeguridad");
            dtbDatos.Columns.Add("NombreMensaje");
            dtbDatos.Columns.Add("Conexion");
            dtbDatos.Columns.Add("Aplicacion");
            dtbDatos.Columns.Add("ConexionFin");
            dtbDatos.Columns.Add("UsuarioAdmin");
            dtbDatos.Columns.Add("UsuarioSistema");
            dtbDatos.Columns.Add("PLANTEL");
            dtbDatos.Columns.Add("IdMenu");
            #endregion

            #region Para Almacenar en la tabla parametros a mostrar
            DataRow dtrError = dtbDatos.NewRow();
            dtrError["Usuario"] = _IdUsuario;
            dtrError["NivelSeguridad"] = intNivelSeguridad.ToString();
            dtrError["NombreMensaje"] = "Inicial";
            dtrError["Conexion"] = _mSeguridad.strConexion;
            dtrError["Aplicacion"] = _mSeguridad.intAplicacion;
            dtrError["ConexionFin"] = _strConexionFin;
            dtrError["UsuarioAdmin"] = _bUsuarioAdmin;
            dtrError["UsuarioSistema"] = Usuario;
            dtrError["PLANTEL"] = "";
            dtrError["IdMenu"] = 152; //ID Accesos

            dtbDatos.Rows.Add(dtrError);
            DataSet DsParam = new DataSet();
            DsParam.Tables.Add(dtbDatos);
            #endregion Para Almacenar en la tabla a mostrar

            return DsParam;
        }
        private void AccesosTsbtnAccesos_Click(object sender, EventArgs e)
        {
            //Key del Menu de Accesos
            DataSet dsParam = GeneraTablaTemporalInicial();
            Mantenimiento.FrmAccesos frmnu = new Mantenimiento.FrmAccesos(dsParam);
            frmnu.ShowDialog();           
        }

        private void tabControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TabPage pa = tabControl1.SelectedTab;
            if (!pa.Text.Equals("INICIO") && !pa.Text.Equals("MENU"))
            {
                //Para cerra la forma abierta
                foreach (Control ss in pa.Controls)
                {
                    if (ss.GetType() == typeof(Panel))
                    {
                        foreach (Control ss1 in ss.Controls)
                        {
                            if (ss1.GetType().BaseType == typeof(Form))
                            {
                                ((Form)ss1).Close();
                            }
                        }
                    }
                }
                tabControl1.TabPages.Remove(pa);
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            cmbcombo = false;
            //cmbUsadosMas.Text = null;
            //CargaFormasUsadas();
        }
        private void cmbUsadosMas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbcombo)
                {
                    //_mSeguridad.ObtieneNombreMenusUsados(cmbUsadosMas.SelectedValue.ToString(), tabControl1, int.Parse(_IdUsuario));                   
                }
            }
            catch (Exception ex)
            {
                cmbcombo = false;
            }
        }
        private void pnlMenuPadre_Click(object sender, EventArgs e)
        {
            if (pnlHijo.Controls.Count > 0)
            {
                pnlHijo.Visible = false;
                lblMnuHijo.Visible = false;
            }
        }
        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }               
        private void pbAltaFoto_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void pbAltaFoto_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }
      
        private void portalFacturaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.sat.gob.mx/home");
        }       
        #endregion EVENTO

        
    }
}
