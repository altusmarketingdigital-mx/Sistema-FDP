using AppElyonCXC.Mantenimiento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppElyonCXC.Pedidos
{
    public partial class Frm_Convertir_Remision_Pedido : Form
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
        public static int IdPedido;
        public static string FolioPedido;
        #endregion //Variables

        #region CONSTRUCTORES

        public Frm_Convertir_Remision_Pedido()
        {
            InitializeComponent();
        }

        public Frm_Convertir_Remision_Pedido(DataSet dsParam)
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

            dsObtenerUsuario();
            ObtenerNoPedido();
        }

        #endregion CONSTRUCTORES

        private void dsObtenerUsuario()
        {
            _mInventario.IdUsuario = UsuarioID;
            DataSet dsUsuario = _mInventario.dsObtenerUsuario();

            if (dsUsuario.Tables[0].Rows.Count > 0)
            {
                txt_Usuario.Text = dsUsuario.Tables[0].Rows[0]["Usuario"].ToString().Trim();
            }
        }

        private void ObtenerNoPedido()
        {
            try
            {
                _mInventario.intAccionNotaRemision = 1;
                _mInventario.Fecha_Nota_Remision = DateTime.Now;
                DataSet dsNoNota = _mInventario.dsRegistroNotaRemision();

                if (dsNoNota.Tables[0].Rows.Count > 0)
                {
                    txt_Nota_Remision.Text = dsNoNota.Tables[0].Rows[0]["No_Nota_Remision"].ToString().Trim();
                }
                else
                {
                    txt_Nota_Remision.Text = "0";
                    MessageBox.Show("No se obtuvo información de la tabla", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { txt_Nota_Remision.Text = "0"; }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                try
                {
                    _mInventario.Id_No_Pedido = Convert.ToInt32(txtNoPedido.Text.ToString());
                    _mInventario.Fecha_Nota_Remision = dtp_Fecha_Remison.Value;
                    _mInventario.intAccionNotaRemision = 3;

                    DataSet dsNotaRemision = _mInventario.dsRegistroNotaRemision();

                    if (Convert.ToInt32(dsNotaRemision.Tables[0].Rows[0]["respuesta"].ToString()) == 0)
                    {
                        _mInventario.intAccionGenerarPedido = 4;
                        _mInventario.Id_Generar_Pedido = Convert.ToInt32(txtNoPedido.Text.ToString());
                        _mInventario.dtp_FechaVenta = DateTime.Now;
                        _mInventario.dtp_FechaVencimientoCredito = DateTime.Now;

                        DataSet dsNoPedido = _mInventario.dsGenerarPedido();

                        if (dsNoPedido.Tables[0].Rows.Count > 0)
                        {
                            txt_UsuarioPedido.Text = dsNoPedido.Tables[0].Rows[0]["Cajero"].ToString().Trim();
                            dtp_FechaPedido.Value = Convert.ToDateTime(dsNoPedido.Tables[0].Rows[0]["Fecha_Venta"].ToString().Trim());
                            txtNoCliente.Text = dsNoPedido.Tables[0].Rows[0]["Id_Cliente"].ToString().Trim();
                            txt_Cliente.Text = dsNoPedido.Tables[0].Rows[0]["Nombre_Cliente"].ToString().Trim();
                            txt_Forma_Pago.Text = dsNoPedido.Tables[0].Rows[0]["Forma_Pago"].ToString().Trim();
                            txt_Metodo_Pago.Text = dsNoPedido.Tables[0].Rows[0]["Metodo_Pago"].ToString().Trim();
                            txt_Folio_Pedido.Text = dsNoPedido.Tables[0].Rows[0]["Folio"].ToString().Trim();
                            //txtNoPedido.Text = _mInventario.Id_No_Pedido.ToString();

                            decimal total = Convert.ToDecimal(dsNoPedido.Tables[0].Rows[0]["Total_Pedido"].ToString().Trim());
                            txt_Total_Pedido.Text = "$ " + total.ToString("N2");

                            //CARGAR DETALLE PEDIDO
                            _mInventario.intAccionGenerarPedido = 5;
                            _mInventario.Id_Generar_Pedido = Convert.ToInt32(txtNoPedido.Text.ToString());
                            _mInventario.dtp_FechaVenta = DateTime.Now;
                            _mInventario.dtp_FechaVencimientoCredito = DateTime.Now;

                            DataSet dsDetallePedido = _mInventario.dsGenerarPedido();

                            if (dsDetallePedido.Tables[0].Rows.Count > 0)
                            {
                                dgv_Pedido.DataSource = dsDetallePedido.Tables[0];

                                //txtNoPedido.Text = _mInventario.Id_No_Pedido.ToString();
                            }
                        }
                    }

                    else
                    {
                        MessageBox.Show("El No. de pedido, ya cuenta con nota de remisión", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNoPedido.Text = "";
                        txt_Folio_Pedido.Text = ""; 
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void btnGenerarPedido_Click(object sender, EventArgs e)
        {
            UcSplashScreen cargando = new UcSplashScreen("", "... Generando Pedido ... ");

            if (NivelSeguridad != "1")
            {
                cargando.Show();
                cargando.Refresh();

                try
                {
                    if (txtNoPedido.Text.Trim() != "")
                    {
                        _mInventario.Id_Nota_Remision = Convert.ToInt32(txt_Nota_Remision.Text.ToString()); 
                        _mInventario.Id_No_Pedido = Convert.ToInt32(txtNoPedido.Text.ToString());
                        _mInventario.Fecha_Nota_Remision = dtp_Fecha_Remison.Value;
                        _mInventario.Id_Cajero = UsuarioID;
                        _mInventario.vchEstatus_Nota_Remision = "Sin Pago";
                        _mInventario.Id_Cliente = Convert.ToInt32(txtNoCliente.Text.ToString());
                        _mInventario.intAccionNotaRemision = 2; 
        
                        DataSet dsNotaRemision = _mInventario.dsRegistroNotaRemision();

                        if (Convert.ToInt32(dsNotaRemision.Tables[0].Rows[0]["respuesta"].ToString()) == 0)
                        {
                            vImprimirComprobante(_mInventario.Id_Nota_Remision);

                            cargando.Close();
                            MessageBox.Show("Nota de remisión creada de forma correcta", "NOTA DE REMISIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLimpiar_Click(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Nota de remisión NO creada", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void vImprimirComprobante(int idPedido)
        {
            Reportes.FrmRepTicket_NotaRemision bol = new Reportes.FrmRepTicket_NotaRemision();
            bol.IdPedido = idPedido;
            bol.GeneraReporte();
            //bol.ShowDialog();
        }

        private void btnCancelarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Nota_Remision.Text = "";
                txt_Usuario.Text = "";
                dtp_Fecha_Remison.Value = DateTime.Now;
                txtNoCliente.Text = "";
                txt_Folio_Pedido.Text = "";
                txtNoPedido.Text = "";
                txt_UsuarioPedido.Text = "";
                dtp_FechaPedido.Value = DateTime.Now;
                txt_Cliente.Text = "";
                txt_Forma_Pago.Text = "";
                txt_Metodo_Pago.Text = "";
                txt_Total_Pedido.Text = "";
                dgv_Pedido.DataSource = null;

                dsObtenerUsuario();
                ObtenerNoPedido();
            }
            catch (Exception ex) { }
        }

        private void btnBuscarPedido_Click(object sender, EventArgs e)
        {
            Frm_Buscar_Pedido pedido = new Frm_Buscar_Pedido();
            pedido.ShowDialog();

            try
            {
                txtNoPedido.Text = Convert.ToString(IdPedido);
                txt_Folio_Pedido.Text = FolioPedido.ToString();
            }
            catch (Exception ex) { }

            CargarPedido();
        }

        private void CargarPedido()
        {
            try
            {
                if (txtNoPedido.Text.ToString() != "0" || txt_Folio_Pedido.Text.ToString() != "")
                {
                    _mInventario.Id_No_Pedido = Convert.ToInt32(txtNoPedido.Text.ToString());
                    _mInventario.Fecha_Nota_Remision = dtp_Fecha_Remison.Value;
                    _mInventario.intAccionNotaRemision = 3;

                    DataSet dsNotaRemision = _mInventario.dsRegistroNotaRemision();

                    if (Convert.ToInt32(dsNotaRemision.Tables[0].Rows[0]["respuesta"].ToString()) == 0)
                    {
                        _mInventario.intAccionGenerarPedido = 4;
                        _mInventario.Id_Generar_Pedido = Convert.ToInt32(txtNoPedido.Text.ToString());
                        _mInventario.dtp_FechaVenta = DateTime.Now;
                        _mInventario.dtp_FechaVencimientoCredito = DateTime.Now;

                        DataSet dsNoPedido = _mInventario.dsGenerarPedido();

                        if (dsNoPedido.Tables[0].Rows.Count > 0)
                        {
                            txt_UsuarioPedido.Text = dsNoPedido.Tables[0].Rows[0]["Cajero"].ToString().Trim();
                            dtp_FechaPedido.Value = Convert.ToDateTime(dsNoPedido.Tables[0].Rows[0]["Fecha_Venta"].ToString().Trim());
                            txtNoCliente.Text = dsNoPedido.Tables[0].Rows[0]["Id_Cliente"].ToString().Trim();
                            txt_Cliente.Text = dsNoPedido.Tables[0].Rows[0]["Nombre_Cliente"].ToString().Trim();
                            txt_Forma_Pago.Text = dsNoPedido.Tables[0].Rows[0]["Forma_Pago"].ToString().Trim();
                            txt_Metodo_Pago.Text = dsNoPedido.Tables[0].Rows[0]["Metodo_Pago"].ToString().Trim();
                            txt_Folio_Pedido.Text = dsNoPedido.Tables[0].Rows[0]["Folio"].ToString().Trim();
                            //txtNoPedido.Text = _mInventario.Id_No_Pedido.ToString();

                            decimal total = Convert.ToDecimal(dsNoPedido.Tables[0].Rows[0]["Total_Pedido"].ToString().Trim());
                            txt_Total_Pedido.Text = "$ " + total.ToString("N2");

                            //CARGAR DETALLE PEDIDO
                            _mInventario.intAccionGenerarPedido = 5;
                            _mInventario.Id_Generar_Pedido = Convert.ToInt32(txtNoPedido.Text.ToString());
                            _mInventario.dtp_FechaVenta = DateTime.Now;
                            _mInventario.dtp_FechaVencimientoCredito = DateTime.Now;

                            DataSet dsDetallePedido = _mInventario.dsGenerarPedido();

                            if (dsDetallePedido.Tables[0].Rows.Count > 0)
                            {
                                dgv_Pedido.DataSource = dsDetallePedido.Tables[0];

                                //txtNoPedido.Text = _mInventario.Id_No_Pedido.ToString();
                            }
                        }
                    }

                    else
                    {
                        MessageBox.Show("El No. de pedido, ya cuenta con nota de remisión", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNoPedido.Text = "";
                        txt_Folio_Pedido.Text = "";
                    }
                }

                //txtNoPedido.Text = "";
            }            
            catch (Exception ex)
            {

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Nota_Remision.Text = "";
                txt_Usuario.Text = "";
                dtp_Fecha_Remison.Value = DateTime.Now;
                txtNoCliente.Text = "";
                txt_Folio_Pedido.Text = "";
                txtNoPedido.Text = "";
                txt_UsuarioPedido.Text = "";
                dtp_FechaPedido.Value = DateTime.Now;
                txt_Cliente.Text = "";
                txt_Forma_Pago.Text = "";
                txt_Metodo_Pago.Text = "";
                txt_Total_Pedido.Text = "";
                dgv_Pedido.DataSource = null;

                dsObtenerUsuario();
                ObtenerNoPedido();
            }
            catch (Exception ex) { }
        }
    }
}
