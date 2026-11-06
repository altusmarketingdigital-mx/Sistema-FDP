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
    public partial class FrmAutorizaUsuarios : Form
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
        int _intIDUsuario = 0;
        int _intIDValidaUsuario = 0;

        public static string strIdUsuario = "0";
        public static string strClaveUsuario = "";
        #endregion //Variables

        #region CONSTRUCTORES
        public FrmAutorizaUsuarios()
        {
            InitializeComponent();
        }

        public FrmAutorizaUsuarios(DataSet dsParam)
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
                //_IdPlantelUsuario = dsDatos.Tables["Parametros"].Rows[0]["PLANTEL"].ToString();
                Idmenu = int.Parse(dsDatos.Tables["Parametros"].Rows[0]["IdMenu"].ToString());
                _intIDMenu = _mSeguridad.RegresaPkMenu(_intIdApp, this.Name);
            }
            _mSeguridad.ValidarBotones(this.Controls, UsuarioID, _intIDMenu);
        }
        #endregion CONSTRUCTORES

        private void FrmAutorizaUsuarios_Load(object sender, EventArgs e)
        {
            this.Text = MensajeProceso;
        }
        private void btnBuscaUsuario_Click(object sender, EventArgs e)
        {
            AppElyonCXC.Mantenimiento.FrmBuscaUsuario frbus = new Mantenimiento.FrmBuscaUsuario(0, _strConexion, _intIdApp, _mSeguridad);
            frbus.ShowDialog();
            
            _intIDUsuario = _mSeguridad.intIdUsuario;
            txtCveUsuario.Text = _mSeguridad.strUsuario;

            CargarValidaciones();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad == "3")
            {
                try
                {
                    _mSeguridad.intIdUsuario = _intIDUsuario;
                    regresa = _mSeguridad.EliminaValidacionUsuario();

                    if (regresa)
                    {
                        MessageBox.Show("Registro Eliminado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Eliminar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Limpiar();                    
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
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void Limpiar()
        {
            _intIDUsuario = 0;
            chkCajeroventa.Checked = false;
            chkCancelaVenta.Checked = false;
            chkSoloCancelaVenta.Checked = false;
            chkDescArticulo.Checked = false;
            chkSoloDescArticulo.Checked = false;
            chkModCantVenta.Checked = false;
            chkModSoloCantVenta.Checked = false;
            chkModPrecio.Checked = false;
            chkModSoloPrecio.Checked = false;
            chkPrecVenta.Checked = false;
            chkSoloPrecVenta.Checked = false;
            chkOtorgaDesc.Checked = false;
            chkSoloOtorgaDesc.Checked = false;
            chkModDtoCrediito.Checked = false;
            chkModSoloDtoCrediito.Checked = false;
            chkParidadMoneda.Checked = false;
            chkSoloParidadMoneda.Checked = false;
            chkAbreCajon.Checked = false;
            txtCveUsuario.Text = null;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad != "1")
            {

                try
                {
                    _mSeguridad.intIDValUsuario = _intIDValidaUsuario;
                    _mSeguridad.intIdUsuario = _intIDUsuario;
                                                                             
                    if (chkCajeroventa.Checked == false)
                    {
                        _mSeguridad.intCajVentas = 0;
                    }
                    else
                    {
                        _mSeguridad.intCajVentas = 1;
                    }
                    
                    if (chkCancelaVenta.Checked == false)
                    {
                        _mSeguridad.intCanVenta = 0;
                    }
                    else
                    {
                        _mSeguridad.intCanVenta = 1;
                    }
                    
                    if (chkSoloCancelaVenta.Checked == false)
                    {
                        _mSeguridad.intSoloCanVenta = 0;
                    }
                    else
                    {
                        _mSeguridad.intSoloCanVenta = 1;
                    }
                    
                    if (chkDescArticulo.Checked == false)
                    {
                        _mSeguridad.intDesArticulo = 0;
                    }
                    else
                    {
                        _mSeguridad.intDesArticulo = 1;
                    }
                    
                    if (chkSoloDescArticulo.Checked == false)
                    {
                        _mSeguridad.intSoloDesArticulo = 0;
                    }
                    else
                    {
                        _mSeguridad.intSoloDesArticulo = 1;
                    }
                    
                    if (chkModCantVenta.Checked == false)
                    {
                        _mSeguridad.intCantVenta = 0;
                    }
                    else
                    {
                        _mSeguridad.intCantVenta = 1;
                    }

                    
                    if (chkModSoloCantVenta.Checked == false)
                    {
                        _mSeguridad.intSoloCantVenta = 0;
                    }
                    else
                    {
                        _mSeguridad.intSoloCantVenta = 1;
                    }

                    
                    if (chkModPrecio.Checked == false)
                    {
                        _mSeguridad.intNoModPre = 0;
                    }
                    else
                    {
                        _mSeguridad.intNoModPre = 1;
                    }
                    
                    if (chkModSoloPrecio.Checked == false)
                    {
                        _mSeguridad.intSoloNoModPre = 0;
                    }
                    else
                    {
                        _mSeguridad.intSoloNoModPre = 1;
                    }
                    
                    if (chkPrecVenta.Checked == false)
                    {
                        _mSeguridad.intPrecioVen = 0;
                    }
                    else
                    {
                        _mSeguridad.intPrecioVen = 1;
                    }
                    
                    if (chkSoloPrecVenta.Checked == false)
                    {
                        _mSeguridad.intSoloPrecioVen = 0;
                    }
                    else
                    {
                        _mSeguridad.intSoloPrecioVen = 1;
                    }
                    
                    if (chkOtorgaDesc.Checked == false)
                    {
                        _mSeguridad.intOtoDesc = 0;
                    }
                    else
                    {
                        _mSeguridad.intOtoDesc = 1;
                    }
                    
                    if (chkSoloOtorgaDesc.Checked == false)
                    {
                        _mSeguridad.intSoloOtoDesc = 0;
                    }
                    else
                    {
                        _mSeguridad.intSoloOtoDesc = 1;
                    }
                    
                    if (chkModDtoCrediito.Checked == false)
                    {
                        _mSeguridad.intModDatCred = 0;
                    }
                    else
                    {
                        _mSeguridad.intModDatCred = 1;
                    }
                    
                    if (chkModSoloDtoCrediito.Checked == false)
                    {
                        _mSeguridad.intSoloModDatCred = 0;
                    }
                    else
                    {
                        _mSeguridad.intSoloModDatCred = 1;
                    }
                    
                    if (chkParidadMoneda.Checked == false)
                    {
                        _mSeguridad.intParMoneda = 0;
                    }
                    else
                    {
                        _mSeguridad.intParMoneda = 1;
                    }
                    
                    if (chkSoloParidadMoneda.Checked == false)
                    {
                        _mSeguridad.intSoloParMoneda = 0;
                    }
                    else
                    {
                        _mSeguridad.intSoloParMoneda = 1;
                    }
                    
                    if (chkAbreCajon.Checked == false)
                    {
                        _mSeguridad.intCajon = 0;
                    }
                    else
                    {
                        _mSeguridad.intCajon = 1;
                    }
                    
                    regresa = _mSeguridad.AltaValidacionUsuario();
                    if (regresa)
                    {
                        MessageBox.Show("Registro Almacenado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();                       
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
            }

        }
        private void CargarValidaciones()
        {
            try
            {
                _mSeguridad.intIdUsuario = _intIDUsuario;
                DataSet dsVakusu = _mSeguridad.dsObtenerValidacionesUsuario();
                if (dsVakusu.Tables[0].Rows.Count > 0)
                {
                    int bCajeroventa = int.Parse(dsVakusu.Tables[0].Rows[0]["intCajeroVentas"].ToString());
                    int bCancelaVenta = int.Parse(dsVakusu.Tables[0].Rows[0]["intCancelaVenta"].ToString());
                    int bSoloCancelaVenta = int.Parse(dsVakusu.Tables[0].Rows[0]["intSoloCancelaVenta"].ToString());
                    int bDescArticulo = int.Parse(dsVakusu.Tables[0].Rows[0]["intDescripArticulo"].ToString());
                    int bSoloDescArticulo = int.Parse(dsVakusu.Tables[0].Rows[0]["intSoloDescripArticulo"].ToString());
                    int bModCantVenta = int.Parse(dsVakusu.Tables[0].Rows[0]["intCantidadVenta"].ToString());
                    int bModSoloCantVenta = int.Parse(dsVakusu.Tables[0].Rows[0]["intSoloCantidadVenta"].ToString());
                    int bModPrecio = int.Parse(dsVakusu.Tables[0].Rows[0]["intNoModPrecio"].ToString());
                    int bModSoloPrecio = int.Parse(dsVakusu.Tables[0].Rows[0]["intSoloNoModPrecio"].ToString());
                    int bPrecVenta = int.Parse(dsVakusu.Tables[0].Rows[0]["intPrecioVenta"].ToString());
                    int bSoloPrecVenta = int.Parse(dsVakusu.Tables[0].Rows[0]["intSoloPrecioVenta"].ToString());
                    int bOtorgaDesc = int.Parse(dsVakusu.Tables[0].Rows[0]["intOtorgaDesc"].ToString());
                    int bSoloOtorgaDesc = int.Parse(dsVakusu.Tables[0].Rows[0]["intSoloOtorgaDesc"].ToString());
                    int bModDtoCrediito = int.Parse(dsVakusu.Tables[0].Rows[0]["intModDatosCred"].ToString());
                    int bModSoloDtoCrediito = int.Parse(dsVakusu.Tables[0].Rows[0]["intSoloModDatosCred"].ToString());
                    int bParidadMoneda = int.Parse(dsVakusu.Tables[0].Rows[0]["intParidadMoneda"].ToString());
                    int bSoloParidadMoneda = int.Parse(dsVakusu.Tables[0].Rows[0]["intSoloParidadMoneda"].ToString());
                    int bAbreCajon = int.Parse(dsVakusu.Tables[0].Rows[0]["intAbreCajon"].ToString());

                    if (bCajeroventa == 1)
                    {
                        chkCajeroventa.Checked = true;
                    }
                    else
                    {
                        chkCajeroventa.Checked = false;
                    }

                    if (bCancelaVenta == 1)
                    {
                        chkCancelaVenta.Checked = true;
                    }
                    else
                    {
                        chkCancelaVenta.Checked = false;
                    }

                    if (bSoloCancelaVenta == 1)
                    {
                        chkSoloCancelaVenta.Checked = true;
                    }
                    else
                    {
                        chkSoloCancelaVenta.Checked = false;
                    }

                    if (bDescArticulo == 1)
                    {
                        chkDescArticulo.Checked = true;
                    }
                    else
                    {
                        chkDescArticulo.Checked = false;
                    }

                    if (bSoloDescArticulo == 1)
                    {
                        chkSoloDescArticulo.Checked = true;
                    }
                    else
                    {
                        chkSoloDescArticulo.Checked = false;
                    }

                    if (bModCantVenta == 1)
                    {
                        chkModCantVenta.Checked = true;
                    }
                    else
                    {
                        chkModCantVenta.Checked = false;
                    }

                    if (bModSoloCantVenta == 1)
                    {
                        chkModSoloCantVenta.Checked = true;
                    }
                    else
                    {
                        chkModSoloCantVenta.Checked = false;
                    }

                    if (bModPrecio == 1)
                    {
                        chkModPrecio.Checked = true;
                    }
                    else
                    {
                        chkModPrecio.Checked = false;
                    }

                    if (bModSoloPrecio == 1)
                    {
                        chkModSoloPrecio.Checked = true;
                    }
                    else
                    {
                        chkModSoloPrecio.Checked = false;
                    }

                    if (bPrecVenta == 1)
                    {
                        chkPrecVenta.Checked = true;
                    }
                    else
                    {
                        chkPrecVenta.Checked = false;
                    }

                    if (bSoloPrecVenta == 1)
                    {
                        chkSoloPrecVenta.Checked = true;
                    }
                    else
                    {
                        chkSoloPrecVenta.Checked = false;
                    }

                    if (bOtorgaDesc == 1)
                    {
                        chkOtorgaDesc.Checked = true;
                    }
                    else
                    {
                        chkOtorgaDesc.Checked = false;
                    }

                    if (bSoloOtorgaDesc == 1)
                    {
                        chkSoloOtorgaDesc.Checked = true;
                    }
                    else
                    {
                        chkSoloOtorgaDesc.Checked = false;
                    }

                    if (bModDtoCrediito == 1)
                    {
                        chkModDtoCrediito.Checked = true;
                    }
                    else
                    {
                        chkModDtoCrediito.Checked = false;
                    }

                    if (bModSoloDtoCrediito == 1)
                    {
                        chkModSoloDtoCrediito.Checked = true;
                    }
                    else
                    {
                        chkModSoloDtoCrediito.Checked = false;
                    }

                    if (bParidadMoneda == 1)
                    {
                        chkParidadMoneda.Checked = true;
                    }
                    else
                    {
                        chkParidadMoneda.Checked = false;
                    }

                    if (bSoloParidadMoneda == 1)
                    {
                        chkSoloParidadMoneda.Checked = true;
                    }
                    else
                    {
                        chkSoloParidadMoneda.Checked = false;
                    }

                    if (bAbreCajon == 1)
                    {
                        chkAbreCajon.Checked = true;
                    }
                    else
                    {
                        chkAbreCajon.Checked = false;
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
