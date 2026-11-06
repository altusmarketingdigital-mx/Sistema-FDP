using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppElyonCXC.Cancelar_Documentos
{
    public partial class Frm_Cancelar_Nota_Remision : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        ElyonModelCxC.mInventario _mInventario = new ElyonModelCxC.mInventario(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        #endregion

        #region Variables 
        bool _bandera = false;
        DataTable dtbDatos = new DataTable();
        decimal total_final;
        string IP_Local;
        int _Id_Generar_Pedido;
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
        int _Id_Folio_Pedido;
        int _Id_Generar_Pedido_Detalle;
        public static int Id_Nota_Remision;
        #endregion //Variables

        #region CONSTRUCTORES

        public Frm_Cancelar_Nota_Remision()
        {
            InitializeComponent();
        }

        public Frm_Cancelar_Nota_Remision(DataSet dsParam)
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

            //CrearTabla();
            //dsObtenerUsuario();
            //ObtenerIP();
            //ObtenerFolio();
            //ObtenerNoPedido();
            //Combo_Metodo_Pago();
            //Combo_Forma_Pago();
        }

        #endregion CONSTRUCTORES

        private void txt_No_Nota_Remision_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == (int)Keys.Enter)
                {
                    CargarNotaRemision();
                }
            }
            catch (Exception ex) { }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarPantalla();
        }

        private void LimpiarPantalla()
        {
            try
            {
                txt_No_Nota_Remision.Text = "";
                dtp_Fecha_Nota_Remision.Value = DateTime.Now;
                txt_Cajero.Text = "";
                txt_No_Pedido.Text = "";
                dtp_Fecha_Pedido.Value = DateTime.Now;
                txt_Estado_Nota_Remision.Text = "";
                txt_No_Pago.Text = "";
                dtp_Fecha_Timbrado.Text = "";
                txt_Forma_Pago.Text = "";
                txt_No_Cliente.Text = "";
                txt_Nombre_Cliente.Text = "";
                txt_RFC_Cliente.Text = "";
                dgv_Detalle_Pedido.DataSource = null;
            }
            catch (Exception ex) { }
        }

        private void btnCancelarDocumento_Click(object sender, EventArgs e)
        {
            _mInventario.Id_Cancelar_Nota_Remisio = 0;
            _mInventario.Id_Nota_Remision_Cancelar = Convert.ToInt32(txt_No_Nota_Remision.Text.ToString());
            _mInventario.dtp_Fecha_Cancelar = DateTime.Now;
            _mInventario.Id_Cajero_Cancelar = UsuarioID;
            _mInventario.intAccionCancelar = 3; 

            DataSet dsCancelar_Nota_Remision = _mInventario.dsCancelarNotaRemision();

            if (Convert.ToInt32(dsCancelar_Nota_Remision.Tables[0].Rows[0]["respuesta"].ToString()) == 0)
            {
                _mInventario.Id_Cancelar_Nota_Remisio = 0;
                _mInventario.Id_Nota_Remision_Cancelar = Convert.ToInt32(txt_No_Nota_Remision.Text.ToString());
                _mInventario.dtp_Fecha_Cancelar = DateTime.Now;
                _mInventario.Id_Cajero_Cancelar = UsuarioID;
                _mInventario.intAccionCancelar = 1;

                DataSet dsBitacora_Cancelar_Nota = _mInventario.dsCancelarNotaRemision();

                if (Convert.ToInt32(dsBitacora_Cancelar_Nota.Tables[0].Rows[0]["respuesta"].ToString()) == 0)
                {
                    MessageBox.Show("¡Documento cancelado!" , "CANCELAR NOTA REMISIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarPantalla();
                }

                else
                {
                    MessageBox.Show("¡Documento NO cancelado!", "CANCELAR NOTA REMISIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarPantalla();
                }
            }

            else
            {
                MessageBox.Show("¡Documento NO cancelado!", "CANCELAR NOTA REMISIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarPantalla();
            }
        }

        private void btnBuscarDocumento_Click(object sender, EventArgs e)
        {
            Frm_Buscar_Documentos documentos = new Frm_Buscar_Documentos();
            documentos.ShowDialog();

            try
            {
                txt_No_Nota_Remision.Text = Convert.ToString(Id_Nota_Remision);
                //txt_Folio_Pedido.Text = FolioPedido.ToString();
            }
            catch (Exception ex) { }

            CargarNotaRemision();
        }

        private void CargarNotaRemision()
        {
            // VALIAMOS QUE LA NOTA DE REMISIÓN EXISTA
            _mInventario.Id_Nota_Remision = Convert.ToInt32(txt_No_Nota_Remision.Text.ToString());
            _mInventario.Fecha_Nota_Remision = DateTime.Now;
            _mInventario.intAccionNotaRemision = 6;

            DataSet dsValidarNotaRemision = _mInventario.dsRegistroNotaRemision();

            if (Convert.ToInt32(dsValidarNotaRemision.Tables[0].Rows[0]["respuesta"].ToString()) == 1)
            {
                // VALIDAMOS QUE LA NOTA DE REMISIÓN NO TENGA PAGO REGISTRADO
                _mInventario.Fecha_Timbrado = DateTime.Now;
                _mInventario.Id_Nota_Remision = Convert.ToInt32(txt_No_Nota_Remision.Text.ToString());
                _mInventario.intAccionRegistroPagoCliente = 5;
                DataSet dsValidarPagoCliente = _mInventario.dsRegistroPagoCliente();

                if (Convert.ToInt32(dsValidarPagoCliente.Tables[0].Rows[0]["respuesta"].ToString()) == 0)
                {
                    _mInventario.intAccionNotaRemision = 1;
                    _mInventario.Id_Nota_Remision = Convert.ToInt32(txt_No_Nota_Remision.Text.ToString());
                    DataSet dsNotaRemision = _mInventario.dsObtenerDocumentoNotaRemision();

                    if (dsNotaRemision.Tables[0].Rows.Count > 0)
                    {
                        dtp_Fecha_Nota_Remision.Value = Convert.ToDateTime(dsNotaRemision.Tables[0].Rows[0]["Fecha_Nota_Remision"].ToString().Trim());
                        txt_Cajero.Text = dsNotaRemision.Tables[0].Rows[0]["Id_Cajero_Nota_Remision"].ToString().Trim();
                        txt_No_Pedido.Text = dsNotaRemision.Tables[0].Rows[0]["Id_Pedido"].ToString().Trim();
                        dtp_Fecha_Pedido.Value = Convert.ToDateTime(dsNotaRemision.Tables[0].Rows[0]["Fecha_Pedido"].ToString().Trim());
                        txt_Estado_Nota_Remision.Text = dsNotaRemision.Tables[0].Rows[0]["Estatus_Nota_Remision"].ToString().Trim();

                        txt_No_Cliente.Text = dsNotaRemision.Tables[0].Rows[0]["Id_Cliente"].ToString().Trim();
                        txt_Nombre_Cliente.Text = dsNotaRemision.Tables[0].Rows[0]["Nombre_Cliente"].ToString().Trim();
                        txt_RFC_Cliente.Text = dsNotaRemision.Tables[0].Rows[0]["RFC_Cliente"].ToString().Trim();

                        /***************************************************************************************/

                        _mInventario.intAccionNotaRemision = 3;
                        _mInventario.Id_Nota_Remision = Convert.ToInt32(txt_No_Nota_Remision.Text.ToString());
                        DataSet dsNota = _mInventario.dsObtenerDocumentoNotaRemision();

                        if (dsNotaRemision.Tables[0].Rows.Count > 0)
                        {
                            try
                            {
                                txt_No_Pago.Text = dsNota.Tables[0].Rows[0]["No_Pago"].ToString().Trim();
                                dtp_Fecha_Timbrado.Value = Convert.ToDateTime(dsNota.Tables[0].Rows[0]["Fecha_Pago"].ToString().Trim());
                                txt_Forma_Pago.Text = dsNota.Tables[0].Rows[0]["Fecha_Pedido"].ToString().Trim();
                            }
                            catch (Exception ex)
                            {
                                txt_No_Pago.Text = "Sin Pago";
                                dtp_Fecha_Timbrado.Value = DateTime.Now;
                                txt_Forma_Pago.Text = "Sin Pago";
                            }

                            /***************************************************************************************/

                            dgv_Detalle_Pedido.DataSource = null;
                            _mInventario.intAccionNotaRemision = 2;
                            _mInventario.Id_Nota_Remision = Convert.ToInt32(txt_No_Nota_Remision.Text.ToString());
                            DataSet dsDetalleNotaRemision = _mInventario.dsObtenerDocumentoNotaRemision();

                            if (dsDetalleNotaRemision.Tables[0].Rows.Count > 0)
                            {
                                dgv_Detalle_Pedido.DataSource = dsDetalleNotaRemision.Tables[0];
                            }
                        }
                    }
                }

                else
                {

                    MessageBox.Show("La nota de remisión (No. " + txt_No_Nota_Remision.Text.ToString() + "), cuanto con registro de pago"
                        , "CANCELAR NOTA REMISIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_No_Nota_Remision.Text = null;
                }
            }

            else
            {

                MessageBox.Show("La nota de remisión (No. " + txt_No_Nota_Remision.Text.ToString() + "), no existe"
                    , "VALIDAR NOTA DE REMISIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_No_Nota_Remision.Text = null;
            }
        }
    }
}
