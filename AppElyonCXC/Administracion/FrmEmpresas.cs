using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppElyonCXC.Administracion
{
    public partial class FrmEmpresas : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        ElyonModelCxC.mCuentasC _mcuentas = new ElyonModelCxC.mCuentasC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        #endregion

        #region //Variables        
        string NivelSeguridad;
        int UsuarioID;
        string MensajeProceso = "";
        string _strConexion = "";
        string _strConexionFin = "";
        int _intIdApp = 0;
        public static string _StrMat = "";
        DataSet dsDatos = new DataSet();
        bool _bUsuarioAdmin;
        string _IdPlantelUsuario = "";
        int _intIDMenu;
        string Usuario = "";
        string _strUsuario;
        bool cmbcombo = false;
        int Idmenu = 0;
        bool regresa = false;
        int _intIDEmpresa;
        string _strEstado;
        string _strCiudad;

        #endregion //Variables

        #region CONSTRUCTORES
        public FrmEmpresas()
        {
            InitializeComponent();
        }
        public FrmEmpresas(DataSet dsParam)
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
                _IdPlantelUsuario = dsDatos.Tables["Parametros"].Rows[0]["PLANTEL"].ToString();
                Idmenu = int.Parse(dsDatos.Tables["Parametros"].Rows[0]["IdMenu"].ToString());
                _intIDMenu = _mSeguridad.RegresaPkMenu(_intIdApp, this.Name);
            }
            _mSeguridad.ValidarBotones(this.Controls, UsuarioID, _intIDMenu);
        }
#endregion CONSTRUCTORES
        private void FrmEmpresas_Load(object sender, EventArgs e)
        {
            this.Text = MensajeProceso;
            llenaEstados(cmbestado);
            CargaGrid();
        }
        private void llenaEstados(ComboBox cmb)
        {
            DataSet dtmns = new DataSet();
            cmbcombo = false;
            try
            {
                dtmns = _mcuentas.dsObtenerEstados();
                if (dtmns.Tables[0].Rows.Count > 0)
                {
                    //Inserta Registro en Blanco
                    dtmns.Tables[0].Rows.InsertAt(dtmns.Tables[0].NewRow(), 0);

                    cmb.DataSource = dtmns.Tables[0].DefaultView;
                    cmb.ValueMember = "ID";
                    cmb.DisplayMember = "NOMBRE";
                    cmbcombo = true;

                }
                else
                {
                    cmbcombo = false;
                    MessageBox.Show("No hay datos de procesos a cargar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                cmbcombo = false;
                MessageBox.Show(ex.ToString());
            }

        }
        private void llenaCiudades(ComboBox cmb, int est)
        {
            DataSet dtmns = new DataSet();
            cmbcombo = false;
            try
            {
                _mcuentas.intEstado = est;
                dtmns = _mcuentas.dsObtenerCiudades();
                if (dtmns.Tables[0].Rows.Count > 0)
                {
                    //Inserta Registro en Blanco
                    dtmns.Tables[0].Rows.InsertAt(dtmns.Tables[0].NewRow(), 0);

                    cmb.DataSource = dtmns.Tables[0].DefaultView;
                    cmb.ValueMember = "ID";
                    cmb.DisplayMember = "NOMBRE";
                    cmbcombo = true;

                }
                else
                {
                    cmbcombo = false;
                    MessageBox.Show("No hay datos de procesos a cargar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                cmbcombo = false;
                MessageBox.Show(ex.ToString());
            }

        }
        private void CargaGrid()
        {
            try
            {
                DataSet dtsConUsu = _mcuentas.dsCargarEmpresas();

                ucGEmpresa.DataSource = dtsConUsu.Tables[0];
                //ucGvendedor.gvGrid.Columns["ID"].Visible = false;
            }
            catch (Exception ex) { }
        }
        private void Limpiar()
        {
            _intIDEmpresa = 0;
            ucGEmpresa.DataSource = null;
            chkEstatus.Checked = false;
            txtNombre.Text = null;
            txtrazonSocial.Text = null;
            txtRfc.Text = null;
            txtDomicilio.Text = null;
            txtnoInterior.Text = null;
            txtNoExterior.Text = null;
            txtColonia.Text = null;
            txtCp.Text = null;
            txtEmail.Text = null;
            txtTelefono.Text = null;
            txtCodigo.Text = null;
            cmbestado.Text = " ";
            cmbciudad.Text = " ";
            txtContacto.Text = null;
            CargaGrid();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void cmbestado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbcombo)
            {
                llenaCiudades(cmbciudad, int.Parse(cmbestado.SelectedValue.ToString()));
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad != "1")
            {
                try
                {
                    _mcuentas.intIDEmpresa = _intIDEmpresa;
                    _mcuentas.strClave = txtCodigo.Text;
                    _mcuentas.strNombre = txtNombre.Text;
                    _mcuentas.strRazonSocial = txtrazonSocial.Text;
                    _mcuentas.strRFC = txtRfc.Text;
                    _mcuentas.strDomicilio = txtDomicilio.Text;
                    try
                    {
                        _mcuentas.intnoInterior = int.Parse(txtnoInterior.Text);
                    }
                    catch (Exception ex) { _mcuentas.intnoInterior = 0; }

                    try
                    {
                        _mcuentas.intNoExterior = int.Parse(txtNoExterior.Text);
                    }
                    catch (Exception ex) { _mcuentas.intNoExterior = 0; }

                    _mcuentas.strColonia = txtColonia.Text;
                    _mcuentas.strCp = txtCp.Text;
                    _mcuentas.intEstado = int.Parse(cmbestado.SelectedValue.ToString());
                    _mcuentas.intciudad = int.Parse(cmbciudad.SelectedValue.ToString());
                    _mcuentas.strEmail = txtEmail.Text;
                    _mcuentas.strTelefono = txtTelefono.Text;
                    _mcuentas.strContacto = txtContacto.Text;
                    int _intpaso = 0;
                    if (chkEstatus.Checked == false)
                    {
                        _intpaso = 0;
                    }
                    else
                    {
                        _intpaso = 1;
                    }
                    _mcuentas.bEstatus = _intpaso;

                    regresa = _mcuentas.bGuardarEmpresa();
                    if (regresa)
                    {
                        MessageBox.Show("Registro Almacenado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        CargaGrid();
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
                Limpiar();
                CargaGrid();
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad == "3")
            {
                try
                {
                    _mcuentas.intIDEmpresa = _intIDEmpresa;
                    regresa = _mcuentas.bEliminaEmpresa();

                    if (regresa)
                    {
                        MessageBox.Show("Registro Eliminado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Eliminar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Limpiar();
                    CargaGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("NO estas Autorizado para Eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpiar();
                CargaGrid();
            }
        }
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
        private void ucGEmpresa_cell_Datagrid_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _intIDEmpresa = int.Parse(ucGEmpresa.gvGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            txtCodigo.Text = ucGEmpresa.gvGrid.Rows[e.RowIndex].Cells["CLAVE"].Value.ToString();
            txtNombre.Text = ucGEmpresa.gvGrid.Rows[e.RowIndex].Cells["NOMBRE"].Value.ToString();
            txtrazonSocial.Text = ucGEmpresa.gvGrid.Rows[e.RowIndex].Cells["RAZON_SOCIAL"].Value.ToString();
            txtRfc.Text = ucGEmpresa.gvGrid.Rows[e.RowIndex].Cells["RFC"].Value.ToString();
            txtDomicilio.Text = ucGEmpresa.gvGrid.Rows[e.RowIndex].Cells["DOMICILIO"].Value.ToString();
            txtnoInterior.Text = ucGEmpresa.gvGrid.Rows[e.RowIndex].Cells["No_INTERIOR"].Value.ToString();
            txtNoExterior.Text = ucGEmpresa.gvGrid.Rows[e.RowIndex].Cells["No_EXTERIOR"].Value.ToString();
            txtColonia.Text = ucGEmpresa.gvGrid.Rows[e.RowIndex].Cells["COLONIA"].Value.ToString();
            txtCp.Text = ucGEmpresa.gvGrid.Rows[e.RowIndex].Cells["CP"].Value.ToString();
            cmbestado.SelectedValue = ucGEmpresa.gvGrid.Rows[e.RowIndex].Cells["ID_ESTADO"].Value.ToString();
            llenaCiudades(cmbciudad, int.Parse(cmbestado.SelectedValue.ToString()));
            cmbciudad.SelectedValue = ucGEmpresa.gvGrid.Rows[e.RowIndex].Cells["ID_CIUDAD"].Value.ToString();
            txtEmail.Text = ucGEmpresa.gvGrid.Rows[e.RowIndex].Cells["EMAIL"].Value.ToString();
            txtTelefono.Text = ucGEmpresa.gvGrid.Rows[e.RowIndex].Cells["TELEFONO"].Value.ToString();
            txtContacto.Text = ucGEmpresa.gvGrid.Rows[e.RowIndex].Cells["CONTACTO"].Value.ToString();
            _strEstado = ucGEmpresa.gvGrid.Rows[e.RowIndex].Cells["ESTADO"].Value.ToString();
            _strCiudad = ucGEmpresa.gvGrid.Rows[e.RowIndex].Cells["CIUDAD"].Value.ToString();


            int paso = int.Parse(ucGEmpresa.gvGrid.Rows[e.RowIndex].Cells["ESTATUS"].Value.ToString());

            if (paso == 1)
            {
                chkEstatus.Checked = true;
            }
            else
            {
                chkEstatus.Checked = false;
            }
            txtNombre.Focus();
        }
        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length == 3)
            {
                txtCodigo.Text = AgregaCeros(txtCodigo.Text, 10);
                try
                {
                    _mcuentas.strClave = txtCodigo.Text;


                    DataSet dsDatos = _mcuentas.dsBuscarEmpresaCodigo();
                    if (dsDatos.Tables[0].Rows.Count > 0)
                    {
                        _intIDEmpresa = int.Parse(dsDatos.Tables[0].Rows[0].ItemArray[0].ToString());
                        txtNombre.Text = dsDatos.Tables[0].Rows[0].ItemArray[2].ToString();
                        txtrazonSocial.Text = dsDatos.Tables[0].Rows[0].ItemArray[3].ToString();
                        txtRfc.Text = dsDatos.Tables[0].Rows[0].ItemArray[4].ToString();
                        txtDomicilio.Text = dsDatos.Tables[0].Rows[0].ItemArray[5].ToString();
                        txtnoInterior.Text = dsDatos.Tables[0].Rows[0].ItemArray[6].ToString();
                        txtNoExterior.Text = dsDatos.Tables[0].Rows[0].ItemArray[7].ToString();
                        txtColonia.Text = dsDatos.Tables[0].Rows[0].ItemArray[8].ToString();
                        txtCp.Text = dsDatos.Tables[0].Rows[0].ItemArray[9].ToString();
                        cmbestado.SelectedValue = int.Parse(dsDatos.Tables[0].Rows[0].ItemArray[10].ToString());
                        cmbciudad.SelectedValue = int.Parse(dsDatos.Tables[0].Rows[0].ItemArray[12].ToString());
                        txtEmail.Text = dsDatos.Tables[0].Rows[0].ItemArray[14].ToString();
                        txtTelefono.Text = dsDatos.Tables[0].Rows[0].ItemArray[15].ToString();
                        txtContacto.Text = dsDatos.Tables[0].Rows[0].ItemArray[16].ToString();
                        int paso = int.Parse(dsDatos.Tables[0].Rows[0].ItemArray[17].ToString());
                        if (paso == 1)
                        {
                            chkEstatus.Checked = true;
                        }
                        else
                        {
                            chkEstatus.Checked = false;
                        }
                    }
                    else
                    {
                        txtNombre.Focus();
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            AppElyonCXC.Reportes.FrmRepEmpresas repEmpresas = new Reportes.FrmRepEmpresas(dsDatos);
            repEmpresas.Show();
        }
    }
}
