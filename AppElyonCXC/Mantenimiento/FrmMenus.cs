using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppElyonCXC.Mantenimiento
{
    public partial class FrmMenus : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        #endregion

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
        string KeyCeldaElimina;
        int _intIDMenu;
        bool CargoPadres = false;
        #endregion //Variables

        #region Constructores
        public FrmMenus()
        {
            InitializeComponent();
        }

        public FrmMenus(DataSet dsParam)
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
                _intIDMenu = int.Parse(dsDatos.Tables["Parametros"].Rows[0][9].ToString());
                _mSeguridad.strConexion = _strConexion;
            }
            _mSeguridad.ValidarBotones(this.Controls, UsuarioID, _intIDMenu);
        }
        #endregion Constructores

        #region Funciones
        private void FrmMenus_Load(object sender, EventArgs e)
        {
            this.Text = MensajeProceso;
            //CargaGrid();
            llenaProcesos();
            //CargaPadres();
           
            CargaApps();
        }

        private void CargaApps()
        {
            DataSet dsper = new DataSet();
            try
            {
                dsper = _mSeguridad.CargarAplicaciones();
                if (dsper.Tables[0].Rows.Count > 0)
                {
                    //Inserta Registro en Blanco
                    //dsper.Tables[0].Rows.InsertAt(dsper.Tables[0].NewRow(), 0);

                    cmbApps.DataSource = dsper.Tables[0].DefaultView;
                    cmbApps.ValueMember = "PK_Aplicacion";
                    cmbApps.DisplayMember = "NombreAplicacion";
                    cmbApps.SelectedItem = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void CargaGridMenu(int IdApps)
        {
            DataSet dsMnu = new DataSet();

            try
            {
                _mSeguridad.intTipoMenu = 0;
                _mSeguridad.intAplicacion = IdApps;
                dsMnu = _mSeguridad.dsCargaTipomenus();
                if (dsMnu.Tables[0].Rows.Count > 0)
                {
                    ucGrid1Menu.DataSource = dsMnu.Tables[0];                   
                }
                else
                {
                    ucGrid1Menu.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void CargaGrid()
        {
            DataSet dsMnu = new DataSet();

            try
            {
                _mSeguridad.intTipoMenu = 0;
                _mSeguridad.intAplicacion = _intIdApp;
                dsMnu = _mSeguridad.dsCargaTipomenus();
                if (dsMnu.Tables[0].Rows.Count > 0)
                {
                    //this.dataGridView1.DataSource = dsMnu;
                    //this.dataGridView1.DataMember = dsMnu.Tables[0].TableName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void llenaProcesos()
        {
            DataSet dtmns = new DataSet();
            try
            {

                dtmns = _mSeguridad.dsSeleccionaProcesos();
                if (dtmns.Tables[0].Rows.Count > 0)
                {
                    //Inserta Registro en Blanco
                    dtmns.Tables[0].Rows.InsertAt(dtmns.Tables[0].NewRow(), 0);

                    cmbProceso.DataSource = dtmns.Tables[0].DefaultView;
                    cmbProceso.ValueMember = "PK_TipoProceso";
                    cmbProceso.DisplayMember = "Descripcion";

                }
                else
                {
                    MessageBox.Show("No hay datos de procesos a cargar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void CargaPadres()
        {
            CargoPadres = false;
            DataSet dtmns = new DataSet();
            try
            {
                _mSeguridad.intAplicacion = int.Parse(cmbApps.SelectedValue.ToString());
                dtmns = _mSeguridad.dsCargaPadres();
                if (dtmns.Tables[0].Rows.Count > 0)
                {
                    //Inserta Registro en Blanco
                    dtmns.Tables[0].Rows.InsertAt(dtmns.Tables[0].NewRow(), 0);

                    cmbPadre.DataSource = dtmns.Tables[0].DefaultView;
                    cmbPadre.ValueMember = "PK_Menu";
                    cmbPadre.DisplayMember = "NombreProceso";

                    CargoPadres = true;

                }
                else
                {
                    MessageBox.Show("No hay datos de Padres a cargar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargoPadres = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                CargoPadres = false;
            }

        }

        private void limpiar()
        {
            strKeyMenu = "0";
            regresa = false;
            txtNombre.Text = null;
            txtMensaje.Text = null;
            txtSiglas.Text = null;
            txtNIvel.Text = null;
            txtNavegacion.Text = null;
            cmbProceso.Text = null;
            txtprogEsc.Text = null;
            txtProgWeb.Text = null;
            txtimgIcono.Text = null;
            cmbEstatus.Text = null;
            cmbPadre.Text = null;
            cmbArmamenu.Text = null;
            cmbTipoProg.Text = null;
            CargaPadres();
            chkSegPlantel.Checked = false;
            txtIdBoton.Text = null;
            txtDescripBoton.Text = null;
            chkEstatus.Checked = false;
            dgvBotones.DataSource = null;
            chkSoloAdmin.Checked = false;
        }
        #endregion Funciones

        #region EVENTOS        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string CveTipoProceso;
            DataSet dsTp = new DataSet();

            if (NivelSeguridad != "1")
            {
                try
                {
                    //Obtiene Clave de proceso
                    _mSeguridad.intTipoProceso = int.Parse(cmbProceso.SelectedValue.ToString());
                    dsTp = _mSeguridad.dsSeleccionaTipoprocesos();
                    if (dsTp.Tables[0].Rows.Count > 0)
                    {
                        CveTipoProceso = dsTp.Tables[0].Rows[0].ItemArray[0].ToString();
                    }
                    else
                    {
                        CveTipoProceso = cmbProceso.SelectedValue.ToString();
                    }
                }
                catch (Exception ex)
                {
                    CveTipoProceso = cmbProceso.SelectedValue.ToString();
                    MessageBox.Show(ex.ToString());
                }
                
                try
                {
                    string TipProg = cmbTipoProg.Text.Substring(0, 1);
                    //Actualizar  
                    _mSeguridad.intAplicacion = int.Parse(cmbApps.SelectedValue.ToString());
                    _mSeguridad.strNombreProceso = txtNombre.Text;
                    _mSeguridad.strSiglas = txtSiglas.Text;
                    _mSeguridad.strMensaje = txtMensaje.Text;
                    _mSeguridad.intNivelProceso = int.Parse(txtNIvel.Text);
                    _mSeguridad.intNavegacion = int.Parse(txtNavegacion.Text);
                    _mSeguridad.intTipoProceso = int.Parse(CveTipoProceso);
                    _mSeguridad.intEstatus = int.Parse(cmbEstatus.Text);

                    try
                    {
                        _mSeguridad.intPadre = int.Parse(cmbPadre.SelectedValue.ToString());
                    }catch(Exception ex) { _mSeguridad.intPadre = 0; }

                    _mSeguridad.intMenuKey = int.Parse(strKeyMenu);
                    _mSeguridad.strvcPrograma = txtProgWeb.Text;
                    _mSeguridad.strvchProgEsc = txtprogEsc.Text;
                    _mSeguridad.strvcImagen = txtimgIcono.Text;
                    _mSeguridad.strchrTipo = TipProg;
                    _mSeguridad.intArmaMenus = int.Parse(cmbArmamenu.Text.Substring(0,1));
                    _mSeguridad.bSeguridaplantel = chkSegPlantel.Checked;
                    _mSeguridad.bSeguridadAdmin = chkSoloAdmin.Checked;

                    regresa = _mSeguridad.AlmacenaMenus();

                    if (regresa)
                    {
                        MessageBox.Show("Registro Almacenado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaGridMenu(int.Parse(cmbApps.SelectedValue.ToString()));
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Almacenar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("NO estas Autorizado para Actualizar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpiar();
            }
        }
        
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad == "3")
            {
                try
                {
                    _mSeguridad.intMenuKey = int.Parse(strKeyMenu);
                    regresa = _mSeguridad.EliminaMenus();

                    if (regresa)
                    {
                        MessageBox.Show("Registro Eliminado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaGridMenu(int.Parse(cmbApps.SelectedValue.ToString()));
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Eliminar tiene Submenus registrados", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnproceso_Click(object sender, EventArgs e)
        {
            frmPrincipal frmMenup = new frmPrincipal();
            MensajeProceso = frmMenup.NombreProceso("Mantenimiento.FrmTipoProceso");
            SiglasProceso = frmMenup.ObtieneSiglasProceso("Mantenimiento.FrmTipoProceso");

            intValida = frmMenup.VerificaAcceso(SiglasProceso, UsuarioID.ToString());
            if (intValida == 0)
            {
                MessageBox.Show("Acceso No Permitido");
            }
            //else
            {
                EstMenu = frmMenup.EstatusMenu(SiglasProceso);
                if (EstMenu == 0)
                {
                    MessageBox.Show("Programa en Mantenimiento ó Programa Deshabilitado");
                }
                else
                {
                    // Entrada de FrmTipoProcesos.
                    Mantenimiento.FrmTipoProceso Regtipop = new Mantenimiento.FrmTipoProceso(dsDatos);                    
                    Regtipop.ShowDialog();
                }
            }

            //Carga de nuevo Combo tipo procesos
            llenaProcesos();
        }

        private void btnExaminaLogo_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtimgIcono.Text = openFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnExaminaLogo.Focus();
            }
        }

        private void ucGrid1Menu_cell_Datagrid_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CargaPadres();
            string KeyCelda;
            DataSet dsMod = new DataSet();
            //CargaPadres();
            //KeyCelda = ucGrid1Menu.gvGrid.CurrentRow.Cells["PK_Menus"].Value.ToString();
            KeyCelda = ucGrid1Menu.gvGrid.Rows[e.RowIndex].Cells["PK_Menus"].Value.ToString();

            strKeyMenu = KeyCelda;

            try
            {
                _mSeguridad.intMenuKey = int.Parse(KeyCelda);
                dsMod = _mSeguridad.dsSeleccionamenus();

                if (dsMod.Tables[0].Rows.Count > 0)
                {
                    txtNombre.Text = dsMod.Tables[0].Rows[0].ItemArray[0].ToString();
                    txtMensaje.Text = dsMod.Tables[0].Rows[0].ItemArray[1].ToString();
                    txtSiglas.Text = dsMod.Tables[0].Rows[0].ItemArray[2].ToString();
                    txtNIvel.Text = dsMod.Tables[0].Rows[0].ItemArray[3].ToString();
                    txtNavegacion.Text = dsMod.Tables[0].Rows[0].ItemArray[4].ToString();
                    cmbProceso.SelectedValue = dsMod.Tables[0].Rows[0].ItemArray[5].ToString();
                    cmbEstatus.Text = dsMod.Tables[0].Rows[0].ItemArray[6].ToString();
                    try
                    {
                        cmbPadre.SelectedValue = int.Parse(dsMod.Tables[0].Rows[0].ItemArray[7].ToString());
                    }
                    catch (Exception ex) { }


                    txtProgWeb.Text = dsMod.Tables[0].Rows[0].ItemArray[8].ToString();
                    txtprogEsc.Text = dsMod.Tables[0].Rows[0].ItemArray[9].ToString();
                    txtimgIcono.Text = dsMod.Tables[0].Rows[0].ItemArray[11].ToString();
                    strtipoM = dsMod.Tables[0].Rows[0].ItemArray[12].ToString();

                    if (strtipoM == "P")
                        cmbTipoProg.Text = "P = Programa";
                    if (strtipoM == "M")
                        cmbTipoProg.Text = "M = Menu";

                    _intArmaMenu = int.Parse(dsMod.Tables[0].Rows[0].ItemArray[13].ToString());
                    if (_intArmaMenu == 0)
                        cmbArmamenu.Text = "0 = Todos";
                    if (_intArmaMenu == 1)
                        cmbArmamenu.Text = "1 = Menu Admin";
                    if (_intArmaMenu == 2)
                        cmbArmamenu.Text = "2 = Menu Admin + Menu Botones";

                    bool bsp = bool.Parse(dsMod.Tables[0].Rows[0].ItemArray[14].ToString());

                    if (bsp == true)
                    {
                        chkSegPlantel.Checked = true;
                    }
                    else
                    {
                        chkSegPlantel.Checked = false;
                    }
                    bool bsp1 = bool.Parse(dsMod.Tables[0].Rows[0].ItemArray[15].ToString());

                    if (bsp1 == true)
                    {
                        chkSoloAdmin.Checked = true;
                    }
                    else
                    {
                        chkSoloAdmin.Checked = false;
                    }
                    CargaBotonesMenu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion EVENTOS   

        private void btnAgrBoton_Click(object sender, EventArgs e)
        {
            try
            {
                _mSeguridad.IDMenu = int.Parse(strKeyMenu);
                _mSeguridad.strIdBoton = txtIdBoton.Text;
                _mSeguridad.strDescripcion = txtDescripBoton.Text;
                if (chkEstatus.Checked == true)
                {
                    _mSeguridad.intEstatus = 1;
                }
                else
                {
                    _mSeguridad.intEstatus = 0;
                }
                if (_mSeguridad.AltaMenuBotones())
                {
                    txtIdBoton.Text = null;
                    txtDescripBoton.Text = null;
                    chkEstatus.Checked = false;
                    txtIdBoton.Focus();
                    CargaBotonesMenu();
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void CargaBotonesMenu()
        {
            try
            {
                _mSeguridad.IDMenu = int.Parse(strKeyMenu);
                DataSet dsmb =  _mSeguridad.dsoObtieneBotonesMenu();
                if (dsmb.Tables[0].Rows.Count > 0)
                {
                    dgvBotones.DataSource = dsmb.Tables[0];
                }
                else
                {
                    dgvBotones.DataSource = null;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void btnEliBoton_Click(object sender, EventArgs e)
        {
            try
            {
                _mSeguridad.intMenuKey = int.Parse(KeyCeldaElimina);

                if (_mSeguridad.EliminaBotonesMenu())
                {
                    txtIdBoton.Text = null;
                    txtDescripBoton.Text = null;
                    chkEstatus.Checked = false;
                    txtIdBoton.Focus();
                    CargaBotonesMenu();
                    MessageBox.Show("Registro Eliminado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo Eliminar el registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvBotones_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            KeyCeldaElimina = dgvBotones.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            txtIdBoton.Text = dgvBotones.Rows[e.RowIndex].Cells["IDBoton"].Value.ToString();
            txtDescripBoton.Text = dgvBotones.Rows[e.RowIndex].Cells["DESCRIPCION"].Value.ToString();
            chkEstatus.Checked = bool.Parse(dgvBotones.Rows[e.RowIndex].Cells["ESTATUS"].Value.ToString());
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargaGridMenu(int.Parse(cmbApps.SelectedValue.ToString()));
            CargaPadres();
        }

      
        
    }
}
