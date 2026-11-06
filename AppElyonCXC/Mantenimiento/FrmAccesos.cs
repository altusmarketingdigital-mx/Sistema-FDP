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
    public partial class FrmAccesos : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);        
        #endregion

        #region //Variables
        string NivelSeguridad;
        int UsuarioID;
        string _IdUsuario = "0";
        bool _bUsuarioAdmin;
        string MensajeProceso = "";
        string _strConexion = "";
        string strKeyAccesos = "0";
        string strKeyusuaurio = "0";
        string strKeyusuaurio1 = "0";
        string strKeyusuaurio2 = "0";
        bool regresa = false;
        int _intRegresa = 0;
        string SiglasProceso = "";
        private int EstMenu;
        int intValida = 0;
        int _intIdApp = 0;
        string strtipoM;
        int _intArmaMenu = 0;
        DataSet dsDatos = new DataSet();
        DataSet ds = new DataSet();
        string _strRutaImagen;
        public static string strClaveUsuario = "";
        public static string strIdUsuario = "0";
        private string sesidUsu;
        private string sesidMenu;
        string tipoMenu = "";
        bool _bSegPlantel;
        int _intMenuSeleccionado;
        int _intIDMenu;
        bool bcargo;
        #endregion //Variables

        public FrmAccesos()
        {
            InitializeComponent();
        }

        public FrmAccesos(DataSet dsParam)
        {
            InitializeComponent();            
            dsDatos = dsParam;
            if (dsDatos.Tables["Parametros"].Rows.Count > 0)
            {
                UsuarioID = int.Parse(dsDatos.Tables["Parametros"].Rows[0][0].ToString());
                NivelSeguridad = dsDatos.Tables["Parametros"].Rows[0][1].ToString();
                MensajeProceso = dsDatos.Tables["Parametros"].Rows[0][2].ToString();
                _strConexion = dsDatos.Tables["Parametros"].Rows[0][3].ToString();
                _intIdApp = int.Parse(dsDatos.Tables["Parametros"].Rows[0][4].ToString());
                _IdUsuario = dsDatos.Tables["Parametros"].Rows[0].ItemArray[0].ToString();
                _mSeguridad.strConexion = _strConexion;
                _bUsuarioAdmin = bool.Parse(dsDatos.Tables["Parametros"].Rows[0][6].ToString());
                _intIDMenu = int.Parse(dsDatos.Tables["Parametros"].Rows[0][9].ToString());
            }
            _mSeguridad.ValidarBotones(this.Controls, UsuarioID, _intIDMenu);
        }

        private void FrmAccesos_Load(object sender, EventArgs e)
        {
            this.Text = MensajeProceso;
            CargaDatos();
        }

        private void CargaDatos()
        {           
            CargaPermisos();
            CargaApps(cmbAplicacion);
            CargaApps(cmbApps);
        }

        private void CargaPermisos()
        {
            DataSet dsper = new DataSet();
            try
            {
                dsper = _mSeguridad.dsCargaNivelSeguridad();                
                if (dsper.Tables[0].Rows.Count > 0)
                {
                    //Inserta Registro en Blanco
                    //dsper.Tables[0].Rows.InsertAt(dsper.Tables[0].NewRow(), 0);

                    cmbPermisos.DataSource = dsper.Tables[0].DefaultView;
                    cmbPermisos.ValueMember = "PK_NivelSeguridad";
                    cmbPermisos.DisplayMember = "DescripcionNivel";
                    cmbPermisos.SelectedItem = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CargaApps(ComboBox cmb)
        {
            DataSet dsper = new DataSet();
            bcargo = false;
            try
            {
                dsper = _mSeguridad.CargarAplicaciones();
                if (dsper.Tables[0].Rows.Count > 0)
                {
                    //Inserta Registro en Blanco
                    dsper.Tables[0].Rows.InsertAt(dsper.Tables[0].NewRow(), 0);

                    cmb.DataSource = dsper.Tables[0].DefaultView;
                    cmb.ValueMember = "PK_Aplicacion";
                    cmb.DisplayMember = "NombreAplicacion";
                    cmb.SelectedItem = -1;
                    bcargo = true;

                }
            }
            catch (Exception ex)
            {
                bcargo = false;
                MessageBox.Show(ex.ToString());
            }
            bcargo = true;
        }

        private void limpiar()
        {
            strKeyAccesos = "0";
            strKeyusuaurio = "0";
            regresa = false;
            txtCveUsuario.Text = null;
            txtNomMenu.Text = null;
            cmbPermisos.Text = null;
            strClaveUsuario = "";
            strIdUsuario = "0";
            txtCveUsu1.Text = "0";
            txtCveUsu2.Text = "0";
            dgvBotones.DataSource = null;
            dgvPlantel.DataSource = null;
            dgvPlantel.Enabled = false;
            //menuStrip1.Items.Clear();
            //cmbApps.Text = null;
            //cmbAplicacion.Text = null;
        }

        #region MENU
        private void CargaMenus()
        {
            DataSet dtAccMenuItems = new DataSet();
            _strRutaImagen = "";

            try
            {
                _mSeguridad.strConexion = _strConexion;
                _mSeguridad.strTipo = "0"; //0 = Escritorio y 1= WEB
                _mSeguridad.intAplicacion = int.Parse(cmbAplicacion.SelectedValue.ToString());
                _mSeguridad.strUsuario = _IdUsuario;

                dtAccMenuItems = _mSeguridad.dsCargaMenuAccesos();
                MenuItem mnuMenuItem = new MenuItem();
                MenuItem mnuMenuItem1 = new MenuItem();


                foreach (DataRow drMenuItem in dtAccMenuItems.Tables[0].Rows)
                {
                    //'esta condicion indica q son elementos padre.                
                    if (drMenuItem["PK_Menu"].Equals(drMenuItem["idpadre"]))
                    {
                        mnuMenuItem.Name = drMenuItem["PK_Menu"].ToString();
                        mnuMenuItem.Text = drMenuItem["NombreProceso"].ToString();
                        tipoMenu = drMenuItem["tipo"].ToString();
                        _strRutaImagen = drMenuItem["Ruta"].ToString().Replace(@"Resources\", "");
                        _strRutaImagen = _strRutaImagen.Replace(".png", "");

                        //Agrega imagen a cada Menu
                        //---------------------------
                        object O = AppElyonCXC.Properties.Resources.ResourceManager.GetObject(_strRutaImagen);

                        ToolStripMenuItem File = new ToolStripMenuItem(drMenuItem["NombreProceso"].ToString());
                        File.Name = mnuMenuItem.Name;
                        File.Image = (Image)O;
                        File.ForeColor = Color.Black;
                        menuStrip1.Items.Add(File);

                        DataSet dtMenuItems1 = new DataSet();
                        dtMenuItems1 = dtAccMenuItems;

                        if (tipoMenu == "P")
                        {
                            File.Click += new EventHandler(New_Click);
                        }
                        else
                        {
                            AddMenus(mnuMenuItem, dtMenuItems1, File);
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "CargaMenus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Genera Menus Hijos del 2 Nivel
        private void AddMenus(MenuItem mnuMenuItem, DataSet dtMenuItems1, ToolStripMenuItem File)
        {
            MenuItem mnuMenuItem1 = new MenuItem();
            _strRutaImagen = "";

            foreach (DataRow drMenuItem1 in dtMenuItems1.Tables[0].Rows)
            {
                if (drMenuItem1["idpadre"].ToString().Equals(mnuMenuItem.Name) & !drMenuItem1["PK_Menu"].Equals(drMenuItem1["idpadre"]))
                {
                    mnuMenuItem1.Name = drMenuItem1["PK_Menu"].ToString();
                    mnuMenuItem1.Text = drMenuItem1["NombreProceso"].ToString();
                    _strRutaImagen = drMenuItem1["Ruta"].ToString().Replace(@"Resources\", "");
                    _strRutaImagen = _strRutaImagen.Replace(".png", "");

                    //Agrega imagen a cada Menu
                    //---------------------------
                    object O = AppElyonCXC.Properties.Resources.ResourceManager.GetObject(_strRutaImagen);

                    ToolStripMenuItem New = new ToolStripMenuItem(drMenuItem1["NombreProceso"].ToString());
                    New.Name = mnuMenuItem1.Name;
                    New.Image = (Image)O;
                    New.ForeColor = Color.Black;
                    New.Click += new EventHandler(New_Click);
                    File.DropDownItems.Add(New);


                    DataSet dtMenuItems2 = new DataSet();
                    dtMenuItems2 = dtMenuItems1;

                    AddMenuHijos(mnuMenuItem1, dtMenuItems2, New);

                }

            }

        }

        //Genera Menus Hijos del 3 Nivel
        private void AddMenuHijos(MenuItem mnuMenuItem1, DataSet dtMenuItems2, ToolStripMenuItem New)
        {
            _strRutaImagen = "";
            foreach (DataRow drMenuItem2 in dtMenuItems2.Tables[0].Rows)
            {
                if (drMenuItem2["idpadre"].ToString().Equals(mnuMenuItem1.Name) & !drMenuItem2["PK_Menu"].Equals(drMenuItem2["idpadre"]))
                {
                    _strRutaImagen = drMenuItem2["Ruta"].ToString().Replace(@"Resources\", "");
                    _strRutaImagen = _strRutaImagen.Replace(".png", "");

                    //Agrega imagen a cada Menu
                    //---------------------------
                    object O = AppElyonCXC.Properties.Resources.ResourceManager.GetObject(_strRutaImagen);


                    ToolStripMenuItem New1 = new ToolStripMenuItem(drMenuItem2["NombreProceso"].ToString());
                    New1.Name = drMenuItem2["PK_menu"].ToString();
                    New1.Image = (Image)O;
                    New1.ForeColor = Color.Black;
                    //w1.Click += new EventHandler(New1_Click);
                    New1.Click += new EventHandler(New_Click);
                    New.DropDownItems.Add(New1);
                }
            }
        }

        //void File_Click(object sender, EventArgs e)
        //{
        //    string KeyMenu = "";

        //    KeyMenu = sender.ToString();
        //    ObtieneNombreMenu(KeyMenu);
        //}

        void New_Click(object sender, EventArgs e)
        {
            string KeyMenu = "";

            ToolStripMenuItem cb = (ToolStripMenuItem)sender;
            KeyMenu = cb.Name;
            ObtieneNombreMenu(KeyMenu);
        }

        //void New1_Click(object sender, EventArgs e)
        //{
        //    string KeyMenu = "";

        //    KeyMenu = sender.ToString();
        //    ObtieneNombreMenu(KeyMenu);
        //}

        private void ObtieneNombreMenu(string KeyMenu)
        {
            string strItem;
            string strPrograma = "";

            DataSet DsMnus = new DataSet();
            try
            {
                _mSeguridad.intMenuKey = int.Parse(KeyMenu);
                DsMnus = _mSeguridad.dsSeleccionamenus();

                if (DsMnus.Tables[0].Rows.Count > 0)
                {
                    MensajeProceso = DsMnus.Tables[0].Rows[0].ItemArray[1].ToString();
                    strItem = DsMnus.Tables[0].Rows[0].ItemArray[2].ToString();
                    strPrograma = DsMnus.Tables[0].Rows[0].ItemArray[9].ToString();
                    strKeyAccesos = DsMnus.Tables[0].Rows[0].ItemArray[10].ToString();
                    _bSegPlantel = bool.Parse(DsMnus.Tables[0].Rows[0].ItemArray[14].ToString());

                    OpcionMenu(strPrograma, strItem, MensajeProceso, KeyMenu);
                }
                else
                {
                    MessageBox.Show("NO existen Menus");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Procedimiento fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpcionMenu(string strPrograma, string strItem, string MjeProceso, string KeyMenu)
        {
            if (strPrograma == null || strPrograma == "")
            {
                MessageBox.Show("Menu Padre");
            }
            else
            {
                _intMenuSeleccionado = int.Parse(KeyMenu);
                EstatusMenu(KeyMenu);
                if (EstMenu == 0)
                {
                    MessageBox.Show("Programa en Mantenimiento ó Programa Deshabilitado");
                }
                else
                {
                    //Cargar Opcion de Menus
                    CargaClases(MjeProceso);
                }

            }
        }

        private void CargaClases(string NombreMenu)
        {
            txtNomMenu.Text = NombreMenu;          
            if (_bSegPlantel)
            {                
                MessageBox.Show("Este menu requiere registrarle un Plantel al Usuario", "REGISTRA ACCESOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void VerificaAcceso(string NombreItem, string Usuario)
        {
            if (_bUsuarioAdmin)
            {
                intValida = 1;
                NivelSeguridad = "3";
            }
            else
            {
                _mSeguridad.strUsuario = _IdUsuario;
                _mSeguridad.strNombreItem = NombreItem;
                _mSeguridad.intNivel = 0;
                _mSeguridad.intAplicacion = _intIdApp;

                ds = _mSeguridad.dsCargaPermisosMenus();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    _intRegresa = (int)ds.Tables[0].Rows[0].ItemArray[0];
                    if (_intRegresa > 0)
                    {
                        intValida = 1;
                        NivelSeguridad = regresa.ToString();
                    }
                    else
                    {
                        intValida = 0;
                        NivelSeguridad = regresa.ToString();
                    }
                }
                else
                {
                    intValida = 0;
                    NivelSeguridad = regresa.ToString();
                }
            }
        }

        private int EstatusMenu(string strItemNombre)
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
        #endregion MENU

        private void btnBuscaUsuario_Click(object sender, EventArgs e)
        {
            AppElyonCXC.Mantenimiento.FrmBuscaUsuario frbus = new FrmBuscaUsuario(0, _strConexion, int.Parse(cmbAplicacion.SelectedValue.ToString()), _mSeguridad);            
            frbus.ShowDialog();

            strKeyusuaurio = _mSeguridad.intIdUsuario.ToString();
            txtCveUsuario.Text = _mSeguridad.strUsuario;

            //strKeyusuaurio = strIdUsuario;
            //txtCveUsuario.Text = strClaveUsuario;
            if (_bSegPlantel)
            {
                //CargaPlanteles();
            }
            CargaBotonesMenu();
        }

        private void btnPermisos_Click(object sender, EventArgs e)
        {
            frmPrincipal frmMenup = new frmPrincipal();
            MensajeProceso = frmMenup.NombreProceso("FrmNivelSeguridad");
            SiglasProceso = frmMenup.ObtieneSiglasProceso("FrmNivelSeguridad");

            intValida = frmMenup.VerificaAcceso(SiglasProceso, _IdUsuario);
            if (intValida == 0)
            {
                MessageBox.Show("Acceso No Permitido");
            }
            else
            {
                EstMenu = frmMenup.EstatusMenu(SiglasProceso);
                if (EstMenu == 0)
                {
                    MessageBox.Show("Programa en Mantenimiento ó Programa Deshabilitado");
                }
                else
                {
                    // Entrada de FrmNivelSeguridad.
                    Mantenimiento.FrmNivelSeguridad RegNivelS = new Mantenimiento.FrmNivelSeguridad(dsDatos);                    
                    RegNivelS.ShowDialog();
                }
            }

            //Carga de nuevo Combo Estatus
            CargaPermisos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad != "1")
            {
                //Actualizar
                sesidUsu = strKeyusuaurio;
                sesidMenu = strKeyAccesos;

                try
                {
                    _mSeguridad.strConexion = _strConexion;
                    _mSeguridad.intIdUsuario = int.Parse(sesidUsu);
                    _mSeguridad.intMenuKey = int.Parse(sesidMenu);
                    _mSeguridad.intNivSeguridad = int.Parse(cmbPermisos.SelectedValue.ToString());
                    _mSeguridad.intAplicacion = int.Parse(cmbAplicacion.SelectedValue.ToString());
                    _mSeguridad.intAplicacion = _intIdApp;
                    if (chkvisible.Checked == true)
                    {
                        _mSeguridad.bVisible = 1;
                    }
                    else
                    {
                        _mSeguridad.bVisible = 0;
                    }
                    regresa = _mSeguridad.AltaMenuUsuarios();

                    if (!regresa)
                    {
                        MessageBox.Show("NO se pudo almacenar registro", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        #region Almacenar Respuestas de Grid                          
                            try
                            {
                                foreach (DataGridViewRow item in dgvBotones.Rows)
                                {
                                    _mSeguridad.strUsuario = sesidUsu;                                   
                                    _mSeguridad.intMenuKey = int.Parse(item.Cells[0].Value.ToString());
                                    _mSeguridad.bAsignaAutomatico = bool.Parse(item.Cells[3].Value.ToString());

                                _mSeguridad.AltaBotonesUsuarios();
                            }
                        }
                            catch (Exception ex) { }
                        dgvBotones.DataSource = null;                        
                        #endregion Almacenar Respuestas de Grid

                        MessageBox.Show("Registro Almacenado", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                limpiar();
            }
            else
            {
                MessageBox.Show("NO estas Autorizado para Actualizar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpiar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad == "3")
            {
                //Eliminar
                sesidUsu = strKeyusuaurio;
                sesidMenu = strKeyAccesos;
                try
                {
                    _mSeguridad.strConexion = _strConexion;
                    _mSeguridad.intAplicacion = _intIdApp;
                    _mSeguridad.intIdUsuario = int.Parse(sesidUsu);
                    _mSeguridad.intMenuKey = int.Parse(sesidMenu);

                    regresa = _mSeguridad.EliminaMenuUsuarios();
                    if (!regresa)
                    {
                        MessageBox.Show("No se pudo Eliminar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Registro Eliminado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("NO estas Autorizado para Eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpiar();
            }
        }

        private void btnBuscaGpo1_Click(object sender, EventArgs e)
        {
            if (cmbApps.SelectedValue.ToString() == "" || cmbApps.SelectedValue.ToString() == null)
            {
                MessageBox.Show("Selecciona una Aplicacion", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            AppElyonCXC.Mantenimiento.FrmBuscaUsuario frbus1 = new FrmBuscaUsuario(1, _strConexion, int.Parse(cmbApps.SelectedValue.ToString()), _mSeguridad);            
            frbus1.ShowDialog();

            strKeyusuaurio1 = _mSeguridad.intIdUsuario.ToString();
            txtCveUsu1.Text = _mSeguridad.strUsuario;

            //strKeyusuaurio1 = strIdUsuario;
            //txtCveUsu1.Text = strClaveUsuario;            
        }

        private void btnBuscaGpo2_Click(object sender, EventArgs e)
        {
            if (cmbApps.SelectedValue.ToString() == "" || cmbApps.SelectedValue.ToString() == null)
            {
                MessageBox.Show("Selecciona una Aplicacion", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AppElyonCXC.Mantenimiento.FrmBuscaUsuario frbus2 = new FrmBuscaUsuario(1, _strConexion, int.Parse(cmbApps.SelectedValue.ToString()), _mSeguridad);
            frbus2.ShowDialog();

            strKeyusuaurio2 = _mSeguridad.intIdUsuario.ToString();
            txtCveUsu2.Text = _mSeguridad.strUsuario;

            //strKeyusuaurio2 = strIdUsuario;
            //txtCveUsu2.Text = strClaveUsuario;           
        }

        private void btnAgregaGpo_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad != "1")
            {
                //Actualizar               
                try
                {
                    _mSeguridad.strConexion = _strConexion;
                    _mSeguridad.intIdUsuario = int.Parse(strKeyusuaurio1);
                    _mSeguridad.intIdUsuario1 = int.Parse(strKeyusuaurio2);
                    _mSeguridad.intAplicacion = int.Parse(cmbApps.SelectedValue.ToString());
                    regresa = _mSeguridad.AltaGrupoMenus();

                    if (!regresa)
                    {
                        MessageBox.Show("NO se pudo almacenar registro", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Registro Almacenado", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                limpiar();
            }
            else
            {
                MessageBox.Show("NO estas Autorizado para Actualizar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpiar();
            }
        }

        private void btnImprime_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En Desarrollo...");
        }

        private void btnLImpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void CargaBotonesMenu()
        {
            try
            {
                _mSeguridad.strUsuario = strKeyusuaurio;
                _mSeguridad.IDMenu =_intMenuSeleccionado;
                DataSet dsmb = _mSeguridad.dsCargaBotonesUsuarioMenu();
                if (dsmb.Tables[0].Rows.Count > 0)
                {
                    dgvBotones.DataSource = dsmb.Tables[0];
                    dgvBotones.Columns["ID"].ReadOnly = true;
                    dgvBotones.Columns["IDBoton"].ReadOnly = true;
                    dgvBotones.Columns["Descripcion"].ReadOnly = true;
                }
                else
                {
                    dgvBotones.DataSource = null;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void CargaPlanteles()
        {
            try
            {
                _mSeguridad.strUsuario = strKeyusuaurio;
                DataSet dtsConUsu = _mSeguridad.dsCargaPlantelesSeleccion();
                dgvPlantel.DataSource = dtsConUsu.Tables[0];
                dgvPlantel.Columns["ID"].ReadOnly = true;
                dgvPlantel.Columns["Descripcion"].ReadOnly = true;
            }
            catch (Exception ex)
            { }
        }

        private void cmbAplicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bcargo)
            {
                menuStrip1.Items.Clear();
                CargaMenus();
            }
        }
    }
}
