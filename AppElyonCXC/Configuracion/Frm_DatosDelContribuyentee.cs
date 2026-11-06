using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppElyonCXC.Configuracion
{
    public partial class Frm_DatosDelContribuyentee : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        ElyonModelCxC.mInventario _mInventario = new ElyonModelCxC.mInventario(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        #endregion

        #region Variables  
        int _Id_Cliente;
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
        int Idmenu = 0;
        #endregion //Variables

        #region CONSTRUCTORES

        public Frm_DatosDelContribuyentee()
        {
            InitializeComponent();
        }

        public Frm_DatosDelContribuyentee(DataSet dsParam)
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad != "1")
            {
                try
                {
                    if (txt_RazonSocial.Text.Trim() != "")
                    {
                        _mInventario.Id_Datos_Contribuyente = _Id_Cliente;
                        _mInventario.vchRazonSocial_Contribuyente = txt_RazonSocial.Text.ToString();
                        _mInventario.vchRFC_Contribuyente = txt_RFC.Text.ToString();
                        _mInventario.vchPais_Contribuyente = txt_Pais.Text.ToString();
                        _mInventario.vchEstado_Contribuyente = txt_Estado.Text.ToString();
                        _mInventario.vchCiudad_Contribuyente = txt_Ciudad.Text.ToString();
                        _mInventario.vchCalle_Contribuyente = txt_Calle.Text.ToString();
                        _mInventario.vchNoInt_Contribuyente = txt_NoInt.Text.ToString();
                        _mInventario.vchNoExt_Contribuyente = txt_NoExt.Text.ToString();
                        _mInventario.vchColonia_Contribuyente = txt_Colonia.Text.ToString();
                        _mInventario.vchCodigoPostal_Contribuyente = txt_CP.Text.ToString();
                        _mInventario.vchTelefono_Contribuyente = txt_Telefono.Text.ToString();
                        _mInventario.vchEmail_Contribuyente = txt_Email.Text.ToString();
        
                        DataSet dsContribuyente = _mInventario.dsDatosDelContribuyente();

                        if (Convert.ToInt32(dsContribuyente.Tables[0].Rows[0]["respuesta"].ToString()) == 0)
                        {
                            MessageBox.Show("Registro Almacenado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Almacenar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else
                    {
                        MessageBox.Show("No puede guardar campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("NO estas Autorizado para Registrar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
