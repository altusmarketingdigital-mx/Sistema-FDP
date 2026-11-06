using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppElyonCXC.Cargas
{
    public partial class FrmBancos : Form
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
        string strValidaSeleccion = "";
        DataSet dsDatos = new DataSet();
        DataSet dsRes;
        bool _bUsuarioAdmin;
        string _IdPlantelUsuario = "";
        int _intIDMenu;
        string Usuario = "";
        string _strUsuario;
        string _intNivelId = "";
        string _strAcadPlan = "";
        string _strPlanCarrera = "";
        string _strGpoAcad = "";
        string _strMatricula = "";
        bool cmbcombo = false;
        int Idmenu = 0;               
        bool regresa = false;
        int _intIDBanco;
        #endregion //Variables

        #region CONSTRUCTORES
        public FrmBancos()
        {
            InitializeComponent();
        }
        public FrmBancos(DataSet dsParam)
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

        private void FrmBancos_Load(object sender, EventArgs e)
        {
            this.Text = MensajeProceso;           
        }       
        private void CargaGrid()
        {
            try
            {               
                DataSet dtsConUsu = _mcuentas.dsCargarBancos();

                ucGBanco.DataSource = dtsConUsu.Tables[0];
                ucGBanco.gvGrid.Columns["PLANTEL"].Visible = false;
            }
            catch (Exception ex) { }
        }
        private void Limpiar()
        {
            _intIDBanco = 0;            
            txtdescripcion.Text = null;
            ucGBanco.DataSource = null;
            txtnombreCorto.Text = null;
            txtclavebanco.Text = null;
            txtComisionCred.Text = null;
            txtComisionCred.Text = null;
            txtComisionChDev.Text = null;
            chkEstatus.Checked = false;                                               
        }
        private void bnCargar_Click(object sender, EventArgs e)
        {
            CargaGrid();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void ucGUsuario_cell_Datagrid_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _intIDBanco = int.Parse(ucGBanco.gvGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString());            
            txtdescripcion.Text = ucGBanco.gvGrid.Rows[e.RowIndex].Cells["NOMBRE"].Value.ToString();
            txtnombreCorto.Text = ucGBanco.gvGrid.Rows[e.RowIndex].Cells["NOMBRE_CORTO"].Value.ToString();
            txtclavebanco.Text = ucGBanco.gvGrid.Rows[e.RowIndex].Cells["CLAVE"].Value.ToString();
            txtComisionCred.Text = ucGBanco.gvGrid.Rows[e.RowIndex].Cells["COMISION_CREDITO"].Value.ToString();
            txtComisionDeb.Text = ucGBanco.gvGrid.Rows[e.RowIndex].Cells["COMISION_DEBITO"].Value.ToString();
            txtComisionChDev.Text = ucGBanco.gvGrid.Rows[e.RowIndex].Cells["COMISION_CHEQUEDEV"].Value.ToString();

            chkEstatus.Checked = bool.Parse(ucGBanco.gvGrid.Rows[e.RowIndex].Cells["ESTATUS"].Value.ToString());

            //if (paso == true)
            //{
            //    chkEstatus.Checked = true;
            //}
            //else
            //{
            //    chkEstatus.Checked = false;
            //}
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad != "1")
            {
                try
                {
                    _mcuentas.intBancoID = _intIDBanco;
                    _mcuentas.strDescripcion = txtdescripcion.Text;
                    _mcuentas.strDescripcionCorta = txtnombreCorto.Text;
                    _mcuentas.intClaveBanco = int.Parse(txtclavebanco.Text);
                    _mcuentas.dcComisionCredito = decimal.Parse(txtComisionCred.Text);
                    _mcuentas.dcComisionDebito = decimal.Parse(txtComisionDeb.Text);
                    _mcuentas.dcComisionChequeDevuelto = decimal.Parse(txtComisionChDev.Text);

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


                    regresa = _mcuentas.bGuardarBancos();
                    if (regresa)
                    {
                        MessageBox.Show("Registro Almacenado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Almacenar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    _mcuentas.intBancoID = _intIDBanco;
                    regresa = _mcuentas.bEliminaBancos();

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

        private void btnReporte_Click(object sender, EventArgs e)
        {
            AppElyonCXC.Reportes.FrmRepBancos repBancos = new Reportes.FrmRepBancos(dsDatos);
            repBancos.Show();
        }

        private void txtclavebanco_Validated(object sender, EventArgs e)
        {
            //Validar clave Banco
            if (_intIDBanco == 0)
            {
                try
                {
                    _mcuentas.intClaveBanco = int.Parse(txtclavebanco.Text);
                    DataSet dscveb = _mcuentas.dsObtenerValiacionClaveBanco();

                    if (dscveb.Tables[0].Rows.Count > 0)
                    {
                        txtclavebanco.Text = dscveb.Tables[0].Rows[0][0].ToString();
                    }
                }
                catch (Exception ex) { }
            }
        }

        private void txtclavebanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (_intIDBanco == 0)
                {
                    //Valdar Clave Banco
                    try
                    {
                        _mcuentas.intClaveBanco = int.Parse(txtclavebanco.Text);
                        DataSet dscveb = _mcuentas.dsObtenerValiacionClaveBanco();

                        if (dscveb.Tables[0].Rows.Count > 0)
                        {
                            txtclavebanco.Text = dscveb.Tables[0].Rows[0][0].ToString();
                        }
                    }
                    catch (Exception ex) { }
                }
            }
        }
    }
}
