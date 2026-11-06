using AppElyonCXC.Mantenimiento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace AppElyonCXC.Pedidos
{
    public partial class Frm_GenerarPedido : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        ElyonModelCxC.mInventario _mInventario = new ElyonModelCxC.mInventario(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        Ticket _cticket = new Ticket();
        #endregion

        #region Variables 
        public static bool _bActualizar; 
        public static int _NoPedido;
        public static string _FolioPedido; 

        public static int _intDiasCredito;
        public static DateTime _dtp_FechaVencimientoCredito = DateTime.Now;

        public static string _ClaveCliente;
        public static string _Id_Clave_Producto;
        public static string _Id_Cliente;

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

        int _intProcesoAutomatico = 0;
        #endregion //Variables

        #region CONSTRUCTORES

        public Frm_GenerarPedido()
        {
            InitializeComponent();
        }

        public Frm_GenerarPedido(DataSet dsParam)
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

        private void Frm_GenerarPedido_Load(object sender, EventArgs e)
        {
            CrearTabla();
            dsObtenerUsuario();
            ObtenerIP();
            ObtenerFolio();
            ObtenerNoPedido();
            Combo_Metodo_Pago();
            Combo_Forma_Pago();

            txtFuenteTicket.Text = _cticket.FontName;
            txtTamañoTicket.Text = _cticket.FontSize.ToString();

        }

        private void dsObtenerUsuario()
        {
            _mInventario.IdUsuario = UsuarioID;
            DataSet dsUsuario = _mInventario.dsObtenerUsuario();

            if (dsUsuario.Tables[0].Rows.Count > 0)
            {
                txt_Cajero.Text = dsUsuario.Tables[0].Rows[0]["Usuario"].ToString().Trim();
            }
        }

        private void ObtenerIP()
        {
            String strHostName = string.Empty;
            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] addr = ipEntry.AddressList;

            for (int i = 0; i < addr.Length; i++)
            {
                IP_Local = addr[i].ToString();

                //Console.WriteLine("IP Address {0}: {1} ", i, addr[i].ToString());
            }
        }

        private void ObtenerFolio()
        {
            try
            {
                _mInventario.Id_Usuario = UsuarioID;
                _mInventario.IP_Equipo = IP_Local;
                _mInventario.intAccionFolio = 6;

                DataSet dsFolioPedido = _mInventario.dsMantenimientoFolioPedidos();

                if (dsFolioPedido.Tables[0].Rows.Count > 0)
                {
                    txt_Folio.Text = dsFolioPedido.Tables[0].Rows[0]["Clave"].ToString().Trim();
                }

                else
                {
                    txt_Folio.Text = "TK"; 
                }
            }
            catch (Exception ex) { txt_Folio.Text = "TK"; }
        }

        private void ObtenerNoPedido()
        {
            try
            {
                _mInventario.intAccionGenerarPedido = 1;
                _mInventario.dtp_FechaVenta = dtp_Fecha.Value;
                _mInventario.dtp_FechaVencimientoCredito = DateTime.Now;
                DataSet dsNoPedido = _mInventario.dsGenerarPedido();

                if (dsNoPedido.Tables[0].Rows.Count > 0)
                {
                    txt_No_Pedido.Text = dsNoPedido.Tables[0].Rows[0]["No_Pedido"].ToString().Trim();
                }

                else
                {
                    txt_No_Pedido.Text = "0";
                }
            }
            catch (Exception ex) { txt_No_Pedido.Text = "0"; }
            
        }

        private void CrearTabla()
        {
            try
            {
                #region Creas tabla Conceptos  
                dtbDatos.Columns.Add("Clave Producto");
                dtbDatos.Columns.Add("Descripcion");
                dtbDatos.Columns.Add("Cantidad");
                dtbDatos.Columns.Add("Precio Venta");
                dtbDatos.Columns.Add("Precio Venta 2");
                dtbDatos.Columns.Add("Precio Venta 3");
                dtbDatos.Columns.Add("Descuento");
                dtbDatos.Columns.Add("Importe");
                #endregion Creas tabla Conceptos
            }
            catch (Exception ex) { }
        }

        private void Combo_Metodo_Pago()
        {
            try
            {
                _mInventario.intValor1 = 3;
                DataSet dsMetodoPago = _mInventario.dsCargarCombo();

                if (dsMetodoPago.Tables[0].Rows.Count > 0)
                {
                    cmb_Metodo_Pago.DataSource = dsMetodoPago.Tables[0].DefaultView;
                    cmb_Metodo_Pago.ValueMember = "Clave";
                    cmb_Metodo_Pago.DisplayMember = "Descr";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void Combo_Forma_Pago()
        {
            //try
            //{
            //    _mInventario.intValor1 = 4;
            //    DataSet dsFormaPago = _mInventario.dsCargarCombo();

            //    if (dsFormaPago.Tables[0].Rows.Count > 0)
            //    {
            //        cmb_Forma_Pago.DataSource = dsFormaPago.Tables[0].DefaultView;
            //        cmb_Forma_Pago.ValueMember = "Clave";
            //        cmb_Forma_Pago.DisplayMember = "Descr";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show(ex.ToString());
            //}
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                try
                {
                    _mInventario.Id_Cliente = Convert.ToInt32(txt_ClaveCliente.Text.Trim().ToString());
                    _mInventario.intAccionCliente = 6;

                    DataSet dsCliente = _mInventario.dsCatalogoClientes();

                    if (dsCliente != null && dsCliente.Tables.Count > 0)
                    {
                        txt_ClaveCliente.Text = null; 
                         txt_Cliente.Text = dsCliente.Tables[0].Rows[0]["Nombre"].ToString().Trim();
                        txt_Direccion.Text = dsCliente.Tables[0].Rows[0]["Calle"].ToString().Trim() + ", # " + dsCliente.Tables[0].Rows[0]["No_Exterior"].ToString().Trim() + " - " 
                            + dsCliente.Tables[0].Rows[0]["No_Interior"].ToString().Trim() + ", Col. " + dsCliente.Tables[0].Rows[0]["Colonia"].ToString().Trim();
                        txt_Desc.Text = dsCliente.Tables[0].Rows[0]["Descuento"].ToString().Trim();
                        //txt_Dias_Credito.Text = dsCliente.Tables[0].Rows[0]["Dias_Credito"].ToString().Trim();

                        txt_ClaveCliente.Text = _mInventario.Id_Cliente.ToString();
                    }

                }
                catch (Exception ex) { }
            }
        }

        private void txt_ClaveProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == (int)Keys.Enter)
                {
                    DataTable dsReq = cargaTabla_PedidoDetalle();
                    dgv_Pedido.DataSource = dsReq;

                    if (dgv_Pedido.Columns[""] != null)
                    {
                        //MessageBox.Show("Existe");
                    }

                    else
                    {
                        string[] tipocentro = new[] { "Bulto", "Caja", "Kilo", "Pieza", "1/2 Caja",
                        "Arpilla", "Manojo", "Paq.", "Pesos", "Exhibidor", "Lata" };
                        DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();

                        cmb.DataSource = tipocentro;
                        cmb.Width = 150;
                        cmb.HeaderText = "UM";
                        //cmb.ValueMember = "UM";
                        dgv_Pedido.Columns.Add(cmb);
                        cmb.DisplayIndex = 3;
                    }

                    dgv_Pedido.CurrentCell = dgv_Pedido.Rows[dgv_Pedido.RowCount - 1].Cells[2];

                    //dgv_Pedido.Columns["Clave Producto"].DisplayIndex = 0;
                    //dgv_Pedido.Columns["Descripcion"].DisplayIndex = 1;
                    //dgv_Pedido.Columns["Cantidad"].DisplayIndex = 2;
                    ////dgv_Pedido.Columns
                    //dgv_Pedido.Columns["Precio Venta"].DisplayIndex = 4;
                    //dgv_Pedido.Columns["Descuento"].DisplayIndex = 5;
                    //dgv_Pedido.Columns["Importe"].DisplayIndex = 6;

                }
            }
            catch (Exception ex) { }
        }
    
        private DataTable cargaTabla_PedidoDetalle()
        {
            #region Para Almacenar en la tabla INFO a mostrar    
            bool bandera = false;
            DataRow dtrError1 = dtbDatos.NewRow();
            int fila;
            int cantidad = 0;
            //total_final = 0;
            //txt_Total_Pedido.Text = "0.00";

            _mInventario.vchClaveProducto = txt_ClaveProducto.Text.Trim().ToString();
            _mInventario.intAccionProducto = 6;

            DataSet dsProducto = _mInventario.dsCatalogoProducto();

            if (dsProducto.Tables[0].Rows.Count > 0)
            {
                if (dgv_Pedido.RowCount > 0)
                {
                    #region REGISTRO
                    for (int i = 0; i < dgv_Pedido.RowCount; i++)
                    {
                        if (dgv_Pedido.Rows[i].Cells["Clave Producto"].Value.ToString().Trim() == dsProducto.Tables[0].Rows[0]["Clave"].ToString().Trim())
                        {
                            fila = i;

                            cantidad = Convert.ToInt32(dgv_Pedido.Rows[fila].Cells["Cantidad"].Value) + 1;
                            decimal precioVenta = Convert.ToDecimal(dsProducto.Tables[0].Rows[0]["Precio_Venta_1"].ToString().Trim());
                            decimal precioVenta_2 = Convert.ToDecimal(dsProducto.Tables[0].Rows[0]["Precio_Venta_2"].ToString().Trim());
                            decimal precioVenta_3 = Convert.ToDecimal(dsProducto.Tables[0].Rows[0]["Precio_Venta_3"].ToString().Trim());
                            decimal importe = cantidad * Convert.ToDecimal(dsProducto.Tables[0].Rows[0]["Precio_Venta_1"].ToString().Trim());

                            dgv_Pedido.Rows[fila].Cells["Cantidad"].Value = cantidad;
                            dgv_Pedido.Rows[fila].Cells["Precio Venta"].Value = precioVenta.ToString("N2");
                            dgv_Pedido.Rows[fila].Cells["Precio Venta 2"].Value = precioVenta_2.ToString("N2");
                            dgv_Pedido.Rows[fila].Cells["Precio Venta 3"].Value = precioVenta_3.ToString("N2");
                            dgv_Pedido.Rows[fila].Cells["Importe"].Value = importe.ToString("N2");

                            total_final = 0;

                            for (int x = 0; x < dgv_Pedido.RowCount; x++)
                            {
                                decimal total = Convert.ToDecimal(dgv_Pedido.Rows[x].Cells["Importe"].Value.ToString());
                                total_final = total_final + total;
                            }

                            //total_final = total_final + importe;
                            txt_Total_Pedido.Text = total_final.ToString("N2");
                            txt_ClaveProducto.Text = null;

                            txt_ClaveProducto.Text = null;
                            bandera = false;
                            break;
                        }

                        else
                        {
                            bandera = true;
                        }
                    }

                    if (bandera == true)
                    {
                        _mInventario.IdPedido = _NoPedido;
                        _mInventario.IdFolioPedido = _FolioPedido;
                        _mInventario.IdCliente = Convert.ToInt32(_Id_Cliente);
                        _mInventario.intAccion = 2;

                        DataSet dsDetallePedido = _mInventario.dsObtenerDatosPedido();

                        if (dsDetallePedido != null && dsDetallePedido.Tables.Count > 0)
                        {
                            cantidad = 1;
                            decimal precioVenta = Convert.ToDecimal(dsProducto.Tables[0].Rows[0]["Precio_Venta_1"].ToString().Trim());
                            decimal precioVenta_2 = Convert.ToDecimal(dsProducto.Tables[0].Rows[0]["Precio_Venta_2"].ToString().Trim());
                            decimal precioVenta_3 = Convert.ToDecimal(dsProducto.Tables[0].Rows[0]["Precio_Venta_3"].ToString().Trim());

                            decimal importe = cantidad * Convert.ToDecimal(dsProducto.Tables[0].Rows[0]["Precio_Venta_1"].ToString().Trim());

                            //dtrError1["Clave Producto"] = dsProducto.Tables[0].Rows[0]["Clave"].ToString().Trim();
                            //dtrError1["Descripcion"] = dsProducto.Tables[0].Rows[0]["Producto"].ToString().Trim();
                            //dtrError1["Cantidad"] = cantidad;
                            //dtrError1["Precio Venta"] = precioVenta.ToString("N2");
                            //dtrError1["Descuento"] = "0.00";
                            //dtrError1["Importe"] = importe.ToString("N2");

                            //dtbDatos.Rows.Add(dtrError1);

                            //Agregar las Filas al DataRow y asignar el valor correspondiente. 
                            DataTable dt2 = new DataTable();
                            dt2 = dgv_Pedido.DataSource as DataTable;

                            DataRow datarow;
                            datarow = dt2.NewRow(); //Con esto le indica que es una nueva fila.

                            datarow["Clave Producto"] = dsProducto.Tables[0].Rows[0]["Clave"].ToString().Trim();
                            datarow["Descripcion"] = dsProducto.Tables[0].Rows[0]["Producto"].ToString().Trim();
                            datarow["Cantidad"] = cantidad;
                            datarow["Precio Venta"] = precioVenta.ToString("N2");
                            datarow["Precio Venta 2"] = precioVenta_2.ToString("N2");
                            datarow["Precio Venta 3"] = precioVenta_3.ToString("N2");
                            datarow["Descuento"] = "0.00";
                            datarow["Importe"] = importe.ToString("N2");

                            total_final = total_final + importe;

                            float total_A = 0;

                            /* ACTUALIZAMOS EL TOTAL */
                            foreach(DataGridViewRow drvDatos in dgv_Pedido.Rows)
                            {
                                float total = float.Parse(drvDatos.Cells[3].Value.ToString());
                                //string x = drvDatos.Cells[3].Value.ToString(); 

                                total_A = total_A + total;
                            }

                            txt_Total_Pedido.Text = total_A.ToString("N2");
                            txt_ClaveProducto.Text = null;

                            //Esto se encargará de agregar la fila.
                            dt2.Rows.Add(datarow);
                            dtbDatos.Rows.Add(datarow);
                        }
                    }
                }

                else
                {
                    if (dgv_Pedido.RowCount == 0)
                    {
                        cantidad = 1;
                        decimal precioVenta = Convert.ToDecimal(dsProducto.Tables[0].Rows[0]["Precio_Venta_1"].ToString().Trim());
                        decimal precioVenta_2 = Convert.ToDecimal(dsProducto.Tables[0].Rows[0]["Precio_Venta_2"].ToString().Trim());
                        decimal precioVenta_3 = Convert.ToDecimal(dsProducto.Tables[0].Rows[0]["Precio_Venta_3"].ToString().Trim());
                        decimal importe = cantidad * Convert.ToDecimal(dsProducto.Tables[0].Rows[0]["Precio_Venta_1"].ToString().Trim());

                        dtrError1["Clave Producto"] = dsProducto.Tables[0].Rows[0]["Clave"].ToString().Trim();
                        dtrError1["Descripcion"] = dsProducto.Tables[0].Rows[0]["Producto"].ToString().Trim();
                        dtrError1["Cantidad"] = cantidad;
                        dtrError1["Precio Venta"] = precioVenta.ToString("N2");
                        dtrError1["Precio Venta 2"] = precioVenta_2.ToString("N2");
                        dtrError1["Precio Venta 3"] = precioVenta_3.ToString("N2");
                        dtrError1["Descuento"] = "0.00";
                        dtrError1["Importe"] = importe.ToString("N2");

                        dtbDatos.Rows.Add(dtrError1);

                        total_final = total_final + importe;
                        txt_Total_Pedido.Text = total_final.ToString("N2");
                        txt_ClaveProducto.Text = null;
                    }
                }

                #endregion
            }
            else
            {
                MessageBox.Show("¡Producto no encontrado!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_ClaveProducto.Text = null;
            }

            return dtbDatos;
            #endregion Para Almacenar en la tabla a mostrar

        }

        private void dgv_Pedido_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_Pedido_KeyUp(object sender, KeyEventArgs e)
        {
            int rowIndex = dgv_Pedido.CurrentCell.RowIndex;
            int ColumnIndex = dgv_Pedido.CurrentCell.ColumnIndex;

            if (e.KeyCode == Keys.Enter)
            {
                string cantidad = dgv_Pedido.Rows[rowIndex-1].Cells["Cantidad"].Value.ToString();
                string precio = dgv_Pedido.Rows[rowIndex-1].Cells["Precio Venta"].Value.ToString();
                decimal importe = Convert.ToDecimal(cantidad) * Convert.ToDecimal(precio);

                dgv_Pedido.Rows[rowIndex - 1].Cells["Importe"].Value = importe.ToString("N2");
                //dgv_Pedido.Rows[rowIndex].Cells["Importe"].Value = importe.ToString("N2");
                //dgv_Pedido.Rows[rowIndex].Cells["Precio Venta"].Value = precioVenta.ToString("N2");      

                total_final = total_final + importe;
                txt_Total_Pedido.Text = total_final.ToString("N2");
            }
        }

        private void btnCancelarPedido_Click(object sender, EventArgs e)
        {
            total_final = 0;
            IP_Local = "";

            txt_Folio.Text = "";
            txt_No_Pedido.Text = "";
            txt_Cajero.Text = "";
            dtp_Fecha.Value = DateTime.Now;
            txt_ClaveProducto.Text = "";
            txt_ClaveCliente.Text = "";
            txt_Cliente.Text = "";
            txt_Direccion.Text = "";
            txt_Desc.Text = "";
            dgv_Pedido.DataSource = null;
            //txt_Dias_Credito.Text = "";
            //dtp_Fecha_Vencimiento.Value = DateTime.Now;
            //cmb_Forma_Pago.SelectedItem = -1;
            cmb_Metodo_Pago.SelectedItem = -1;
            txt_Total_Pedido.Text = "";
            txt_Comentario.Text = "";
        }

        private void btnGenerarPedido_Click(object sender, EventArgs e)
        {
            int _intGeneraPedido = 0;
            UcSplashScreen cargando = new UcSplashScreen("", "... Generando Pedido ... ");

            if (NivelSeguridad != "1")
            {
                try
                {
                    if (txt_Cliente.Text.Trim() != "")
                    {
                        cargando.Show();
                        cargando.Refresh();

                        if (_bActualizar == false)
                        {
                            _mInventario.intAccionGenerarPedido = 2;
                            _mInventario.Id_Generar_Pedido = _Id_Generar_Pedido;
                        }
                        else
                        {
                            _mInventario.intAccionGenerarPedido = 7;
                            _mInventario.Id_Generar_Pedido = Convert.ToInt32(txt_No_Pedido.Text.ToString());
                        }

                        //_mInventario.Id_Generar_Pedido = _Id_Generar_Pedido;
                        _mInventario.vchFolio = txt_Folio.Text.ToString(); 
                        _mInventario.Id_Usuario = UsuarioID;
                        _mInventario.dtp_FechaVenta = dtp_Fecha.Value;
                        _mInventario.Id_Cliente = Convert.ToInt32(txt_ClaveCliente.Text.ToString());
                        _mInventario.intDiasCredito = _intDiasCredito;
                        _mInventario.dtp_FechaVencimientoCredito = _dtp_FechaVencimientoCredito;
                        _mInventario.Metodo_Pago = Convert.ToInt32(cmb_Metodo_Pago.SelectedValue.ToString()); 
                        //_mInventario.Forma_Pago = Convert.ToInt32(cmb_Forma_Pago.SelectedValue.ToString());
                        _mInventario.TotalVenta = float.Parse(txt_Total_Pedido.Text.ToString());
                        _mInventario.vchComentario = txt_Comentario.Text.ToString(); 

                        DataSet dsGeneraPedido = _mInventario.dsGenerarPedido();

                        if (Convert.ToInt32(dsGeneraPedido.Tables[0].Rows[0]["respuesta"].ToString()) == 0)
                        {
                            foreach (DataGridViewRow drvDatos in dgv_Pedido.Rows)
                            {
                                //if (_bActualizar == false)
                                //{
                                //    _mInventario.intAccionGenerarPedido = 3;
                                //    _mInventario.Id_Generar_Pedido = _Id_Generar_Pedido;
                                //}
                                //else
                                //{
                                //    _mInventario.intAccionGenerarPedido = 8;
                                //    _mInventario.Id_Generar_Pedido = Convert.ToInt32(txt_No_Pedido.Text.ToString());
                                //}

                                if (_bActualizar == false)
                                    _mInventario.intAccionGenerarPedido = 3;
                                else
                                    _mInventario.intAccionGenerarPedido = 8;

                                try
                                {
                                    _mInventario.Id_Generar_Pedido_Detalle = _Id_Generar_Pedido_Detalle;
                                    _mInventario.Id_Genera_Pedido = Convert.ToInt32(dsGeneraPedido.Tables[1].Rows[0]["Id"].ToString());
                                    _intGeneraPedido = Convert.ToInt32(dsGeneraPedido.Tables[1].Rows[0]["Id"].ToString());
                                    _mInventario.Id_Clave_Producto = drvDatos.Cells[0].Value.ToString();
                                    _mInventario.Cantidad = float.Parse(drvDatos.Cells[2].Value.ToString());
                                    _mInventario.UM_Venta = drvDatos.Cells[3].Value.ToString();
                                    _mInventario.PrecioVenta = float.Parse(drvDatos.Cells[4].Value.ToString());
                                    _mInventario.dcDescuento = decimal.Parse(drvDatos.Cells[7].Value.ToString());
                                    _mInventario.Importe = float.Parse(drvDatos.Cells[8].Value.ToString());
                                }
                                catch (Exception ex)
                                {
                                    _mInventario.Id_Generar_Pedido_Detalle = _Id_Generar_Pedido_Detalle;
                                    _mInventario.Id_Genera_Pedido = Convert.ToInt32(dsGeneraPedido.Tables[1].Rows[0]["Id"].ToString());
                                    _intGeneraPedido = Convert.ToInt32(dsGeneraPedido.Tables[1].Rows[0]["Id"].ToString());
                                    _mInventario.Id_Clave_Producto = drvDatos.Cells[0].Value.ToString();
                                    _mInventario.Cantidad = float.Parse(drvDatos.Cells[2].Value.ToString());
                                    _mInventario.UM_Venta = drvDatos.Cells[8].Value.ToString();
                                    _mInventario.PrecioVenta = float.Parse(drvDatos.Cells[3].Value.ToString());
                                    _mInventario.dcDescuento = decimal.Parse(drvDatos.Cells[6].Value.ToString());
                                    _mInventario.Importe = float.Parse(drvDatos.Cells[7].Value.ToString());
                                }

                                DataSet dsGeneraPedidoDetalle = _mInventario.dsGenerarPedido();

                                if (Convert.ToInt32(dsGeneraPedidoDetalle.Tables[0].Rows[0]["respuesta"].ToString()) == 0)
                                {
                                    _bandera = true;
                                }
                            }

                            if (_bandera == true)
                            {
                                //Genera Impresion Boleta
                                vImprimirBoletaPago(_intGeneraPedido);

                                btnLimpiar_Click(null, null);

                                cargando.Close();
                                MessageBox.Show("Pedido generado", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("Pedido NO generado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            FrmDiasCreditoPedido credito = new FrmDiasCreditoPedido();

            if (rb_Requiere_Credito.Checked == true)
            {
                credito.ShowDialog();
                rb_No_Requiere_Credito.Checked = false;
                rb_Requiere_Credito.Checked = true;
            }
            else
                credito.Close();
        }
        private void btnAgregar_Producto_Click(object sender, EventArgs e)
        {
            FrmObtenerProducto producto = new FrmObtenerProducto();
            producto.Show();
        }
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            Catalogos.Frm_BusquedaCliente busqCliente = new Catalogos.Frm_BusquedaCliente();
            busqCliente.ShowDialog();

            txt_ClaveCliente.Text = _ClaveCliente;


            //CARGAR LA INFORMACIÓN
            try
            {
                _mInventario.Id_Cliente = Convert.ToInt32(txt_ClaveCliente.Text.Trim().ToString());
                _mInventario.intAccionCliente = 6;

                DataSet dsCliente = _mInventario.dsCatalogoClientes();

                if (dsCliente != null && dsCliente.Tables.Count > 0)
                {
                    txt_Cliente.Text = dsCliente.Tables[0].Rows[0]["Nombre"].ToString().Trim();
                    txt_Direccion.Text = dsCliente.Tables[0].Rows[0]["Calle"].ToString().Trim() + ", # " + dsCliente.Tables[0].Rows[0]["No_Exterior"].ToString().Trim() + " - "
                        + dsCliente.Tables[0].Rows[0]["No_Interior"].ToString().Trim() + ", Col. " + dsCliente.Tables[0].Rows[0]["Colonia"].ToString().Trim();
                    txt_Desc.Text = dsCliente.Tables[0].Rows[0]["Descuento"].ToString().Trim();
                    //txt_Dias_Credito.Text = dsCliente.Tables[0].Rows[0]["Dias_Credito"].ToString().Trim();
                }

            }
            catch (Exception ex) { }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            { 
                txt_Folio.Text = "";
                txt_No_Pedido.Text = "";
                txt_Cajero.Text = "";
                dtp_Fecha.Value = DateTime.Now;

                txt_ClaveCliente.Text = "";
                txt_Cliente.Text = "";
                txt_Desc.Text = "";
                txt_Direccion.Text = "";
                txt_ClaveProducto.Text = "";
                
                dgv_Pedido.DataSource = null;
                dgv_Pedido.Columns.RemoveAt(dgv_Pedido.Columns.Count - 1);
                cmb_Metodo_Pago.SelectedValue = 0;

                rb_Requiere_Credito.Checked = false;
                rb_No_Requiere_Credito.Checked = false;
                txt_Comentario.Text = "";
                txt_Total_Pedido.Text = "0.00";
                total_final = 0;
                dtbDatos.Clear();

                CrearTabla();
                dsObtenerUsuario();
                ObtenerIP();
                ObtenerFolio();
                ObtenerNoPedido();
                Combo_Metodo_Pago();
                Combo_Forma_Pago();

                txtFuenteTicket.Text = _cticket.FontName;
                txtTamañoTicket.Text = _cticket.FontSize.ToString();
            }
            catch (Exception ex)
            {
                CrearTabla();
                dsObtenerUsuario();
                ObtenerIP();
                ObtenerFolio();
                ObtenerNoPedido();
                Combo_Metodo_Pago();
                Combo_Forma_Pago();

                txtFuenteTicket.Text = _cticket.FontName;
                txtTamañoTicket.Text = _cticket.FontSize.ToString();
            }
        }

        private void vImprimirBoletaPago(int idPedido)
        {
            bool bImprimeTicket = false;
            if (_intProcesoAutomatico != 1)
            {
                System.Drawing.Printing.PrinterSettings printer = new System.Drawing.Printing.PrinterSettings();
                printer.PrinterName = Properties.Settings.Default.strImpresora;
                foreach (System.Drawing.Printing.PaperSize page in printer.PaperSizes)
                {
                    if (page.PaperName.ToUpper().Contains("ROLL")
                        || page.PaperName.Contains("76 x 297mm"))
                        bImprimeTicket = true;
                }
            }


            if (!bImprimeTicket)
            {
                if (_intProcesoAutomatico != 1)
                {
                    //Para  PDF

                    vImprimirTicket(idPedido);

                    Reportes.FrmRepTicket_Pedido bol = new Reportes.FrmRepTicket_Pedido();
                    bol.IdPedido = idPedido;
                    bol.GeneraReporte(); 

                    //bol.ShowDialog();
                }
            }
            else
            {
                //Generamos el PDF y lo guardamos
                Reportes.FrmRepTicket_Pedido bol = new Reportes.FrmRepTicket_Pedido();
                bol.IdPedido = idPedido;
                bol.GeneraReporte();

                //ParaTicket
                vImprimirTicket(idPedido);

                //Generamos el Ticket en PDF
            }
        }

        private void vImprimirTicket(int IdPedido)
        {
            _cticket = new Ticket();
            string _strConcepto = "";
            string _CveProdcuto = "";
            string strFolio = "";
            string srtFecha = "";
            string strHora = "";
            string Condicion = "";
            string Cajero = "";
            decimal decTotal = 0;
            int intUnidades = 0;

            decimal decSubTotal = 0;
            decimal decIva = 0;            
            string strCode = "";
            string strLetra = "";
              
            try
            {
                _mInventario.Id_Generar_Pedido = IdPedido;
                DataSet dsCFD = _mInventario.dsObtenerBoletaPedido();

                if (dsCFD.Tables[0].Rows.Count > 0)
                {
                    DataRow drEncabezado = dsCFD.Tables[0].Rows[0];

                    Condicion = drEncabezado["CONDICION"].ToString();
                    Cajero = drEncabezado["CAJERO"].ToString();
                    srtFecha = drEncabezado["FECHA"].ToString();
                    //strCode = drEncabezado["TICKET"].ToString();

                    string strDot = " ";
                    //_cticket = new ModelElyonTimbrador.Ticket();
                    _cticket.FontName = txtFuenteTicket.Text;
                    //_cticket.HeaderImage = Properties.Resources.logo_frutería_ticket__1_;
                    //_cticket.intAjusImg = 14;
                    _cticket.FontSize = Convert.ToInt32(8);
                    for (int i = 0; i < _cticket.MaxChar; i++)
                        strDot += "-";

                    DataSet dsContribuyente = _mInventario.dsObtenerContribuyente();

                    _cticket.AddHeaderLine("                                          ");
                    _cticket.AddHeaderLine(dsContribuyente.Tables[0].Rows[0]["vchRazonSocial"].ToString().Trim());
                    _cticket.AddHeaderLine("RFC. " + dsContribuyente.Tables[0].Rows[0]["vchRFC"].ToString().Trim());
                    _cticket.AddHeaderLine(dsContribuyente.Tables[0].Rows[0]["vchCalle"].ToString().Trim() + " #"
                        + dsContribuyente.Tables[0].Rows[0]["vchNoExt"].ToString().Trim() + ", " + dsContribuyente.Tables[0].Rows[0]["vchNoInt"].ToString().Trim());
                    _cticket.AddHeaderLine("Colonia. " + dsContribuyente.Tables[0].Rows[0]["vchColonia"].ToString().Trim());
                    _cticket.AddHeaderLine("Cp. " + dsContribuyente.Tables[0].Rows[0]["vchCodigoPostal"].ToString().Trim()); // + " | Tel. " + dsContribuyente.Tables[0].Rows[0]["vchTelefono"].ToString().Trim());
                    _cticket.AddHeaderLine("Tel. 753 53 215 45");
                    //_cticket.AddHeaderLine("     753 53 212 45");
                    //_cticket.AddHeaderLine("     753 53 702 42");
                    //_cticket.AddHeaderLine("                                          ");

                    //bool bEsMayor = false;
                    int intLimit = 35; //28

                    //Obtenemos los datos del CLIENTE
                    _mInventario.Id_No_Pedido = Convert.ToInt32(drEncabezado["ID"].ToString());
                    DataSet dsCliente = _mInventario.dsObtenerDatosCliente();

                    //_cticket.AddHeaderLine("                                          ");
                    _cticket.AddHeaderLine("DATOS DEL CLIENTE: ");
                    //_cticket.AddHeaderLine("No. de Cliente: " + dsCliente.Tables[0].Rows[0]["Id_Cliente"].ToString().Trim());
                    _cticket.AddHeaderLine("\n" + dsCliente.Tables[0].Rows[0]["Nombre"].ToString().Trim());
                    //_cticket.AddHeaderLine("\nRFC. " + dsCliente.Tables[0].Rows[0]["RFC"].ToString().Trim());
                    _cticket.AddHeaderLine("\nDomicilio. " + dsCliente.Tables[0].Rows[0]["Calle"].ToString().Trim());
                    _cticket.AddHeaderLine("\nColonia. " + dsCliente.Tables[0].Rows[0]["Colonia"].ToString().Trim());
                    //_cticket.AddHeaderLine("Cp." + dsCliente.Tables[0].Rows[0]["Codigo_Postal"].ToString().Trim());
                    _cticket.AddHeaderLine("                                          ");

                    _cticket.AddSubHeaderLine(" =========== SOLICITUD DE PEDIDO ==========");
                    //_cticket.AddSubHeaderLine(" ==========================================");
                    _cticket.AddSubHeaderLine("   Serie Folio     N° " + drEncabezado["FOLIO"].ToString());
                    _cticket.AddSubHeaderLine("   Fecha: " + drEncabezado["FECHA"].ToString() + " | Hora: " + drEncabezado["HORA"].ToString());
                    _cticket.AddSubHeaderLine(" ==========================================");

                    //_cticket.AddSubHeaderLine(strDot);                                  
                    //_cticket.AddSubHeaderLine("Desc.        Cantidad     %Dsct    Importe");
                    //_cticket.AddSubHeaderLine  ("Clave        Descripcion          Cantidad");
                    _cticket.AddSubHeaderLine  ("Cantidad    Descripcion");
                    _cticket.AddSubHeaderLine(strDot);

                    foreach (DataRow drDetalle in dsCFD.Tables[1].Rows)
                    {
                        _strConcepto = drDetalle["Descripcion"].ToString().Trim();
                        _CveProdcuto = drDetalle["CLAVE_PRODUCTO"].ToString();

                        //_cticket.AddItemPedido(_CveProdcuto, _strConcepto, (Convert.ToInt32(drDetalle["Cantidad"])).ToString());

                        _cticket.AddItemPedido(_CveProdcuto, drDetalle["Cantidad"].ToString(), _strConcepto,
                        string.Format("{0:n}", drDetalle["PRECIO"]), string.Format("{0:n}", drDetalle["DESCUENTO"]), string.Format("{0:n}", drDetalle["IMPORTE"]));

                        string cadena = drDetalle["Cantidad"].ToString();
                        char delimitador = ' ';
                        string[] valores = cadena.Split(delimitador);

                        intUnidades += Convert.ToInt32(valores[0]);
                        decSubTotal += Convert.ToDecimal(drDetalle["IMPORTE"].ToString());
                        //strLetra = drDetalle["Letra"].ToString();
                    }

                    //_cticket.AddFooterLine(strDot);
                    //_cticket.AddFooterLine("   TOTAL        " + String.Format("{0:c}", decSubTotal));
                    //_cticket.AddFooterLine(strDot);

                    if (strLetra.Length > 35)
                    {
                        string[] strLetras = strLetra.Split(' ');
                        int intTot = 0;
                        string strCLetra = "   ";

                        for (int i = 0; i < strLetras.Length; i++)
                        {
                            intTot += strLetras[i].ToString().Length;
                            if (intTot < 30)
                            {
                                strCLetra += strLetras[i].ToString() + " ";
                            }
                            else
                            {
                                intTot = strLetras[i].ToString().Length;
                                _cticket.AddFooterLine(strCLetra);
                                strCLetra = strLetras[i].ToString();
                            }
                        }
                        //_cticket.AddFooterLine(" "+strCLetra);
                        //_cticket.AddFooterLine("   Total: " + String.Format("{0:c}", decSubTotal));
                        //_cticket.AddFooterLine("   " + strCLetra);
                    }
                    else
                    {
                        //_cticket.AddFooterLine(strLetra);
                        //_cticket.AddFooterLine("   Total: " + String.Format("{0:c}", decSubTotal));
                        //_cticket.AddFooterLine("   " + strLetra);
                    }

                    Condicion = cmb_Metodo_Pago.Text.ToString();

                    //_cticket.AddFooterLine("   Total de unidades:  " + intUnidades.ToString());
                    //_cticket.AddFooterLine("   Condiciones:  " + Condicion);
                    //_cticket.AddFooterLine("   Fecha de Entrega:  " + srtFecha +" | Cajero: " + Cajero);
                    //_cticket.AddFooterLine("                                          ");
                    //_cticket.AddFooterLine("   ESTA COTIZACION, FUNGIRA COMO PEDIDO   ");
                    //_cticket.AddFooterLine("   UNA VEZ QUE EL CLIENTE LA HAYA FIRMADO ");
                    //_cticket.AddFooterLine("   ACEPTANDO LOS: PRECIOS, PLAZOS Y       ");
                    //_cticket.AddFooterLine("   CONDICIONES QUE SE INDICAN  EN LA      ");
                    //_cticket.AddFooterLine("   PRESENTE.                              ");
                    //_cticket.AddFooterLine("                                          ");
                    //_cticket.AddFooterLine("   ACEPTO:");
                    //_cticket.AddFooterLine("                                          ");
                    //_cticket.AddFooterLine("                                          ");
                    //_cticket.AddFooterLine("   ==========================================");
                    //_cticket.AddFooterLine("   " + dsCliente.Tables[0].Rows[0]["Nombre"].ToString().Trim());
                    //_cticket.AddFooterLine("   " + dsCliente.Tables[0].Rows[0]["RFC"].ToString().Trim() + " | " + srtFecha);
                    _cticket.AddFooterLine("   Comentarios: " + drEncabezado["Comentario"].ToString());
                    _cticket.AddFooterLine("                                          ");
                    _cticket.AddFooterLine("   Autorizado por: ");
                    //_cticket.AddFooterLine("                                          ");
                    _cticket.AddFooterLine("                                          ");
                    _cticket.AddFooterLine("  ==========================================");
                    _cticket.AddFooterLine("   Usuario: " + Cajero);

                    //decTotal = decSubTotal + decIva;
                    //_cticket.AddTotal("SUBTOTAL :", String.Format("{0:c}", decSubTotal));
                    //_cticket.AddTotal("IVA :", String.Format("{0:c}", decIva));
                    //_cticket.AddTotal("TOTAL :", String.Format("{0:c}", decTotal));

                    string impresora = Properties.Settings.Default.strImpresora;

                    MessageBox.Show(impresora, "IMPRESORA SELECCIONADA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _cticket.PrintTicket(impresora);
                }
                else
                {
                    MessageBox.Show("NO EXISTE PEDIDO, Validar", "BOLETA DE PEDIDO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR al generar boleta de Pedido", "BOLETA DE PEDIDO - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Frm_BuscarPedido_Actualizar buscarPedido = new Frm_BuscarPedido_Actualizar();
            buscarPedido.ShowDialog();

            //CARGAR LA INFORMACIÓN
            try
            {
                /* OBTENEMOS LA INFORMACIÓN DEL ENCABEZADO */

                _mInventario.IdPedido = _NoPedido;
                _mInventario.IdFolioPedido = _FolioPedido;
                _mInventario.IdCliente = Convert.ToInt32(_Id_Cliente); 
                _mInventario.intAccion = 1; 

                DataSet dsInfoPedido = _mInventario.dsObtenerDatosPedido();

                if (dsInfoPedido != null && dsInfoPedido.Tables.Count > 0)
                {
                    txt_Folio.Text = dsInfoPedido.Tables[0].Rows[0]["Folio"].ToString().Trim();
                    txt_No_Pedido.Text = dsInfoPedido.Tables[0].Rows[0]["Id"].ToString().Trim();
                    dtp_Fecha.Value = Convert.ToDateTime(dsInfoPedido.Tables[0].Rows[0]["Fecha_Venta"].ToString().Trim());
                    txt_ClaveCliente.Text = dsInfoPedido.Tables[0].Rows[0]["Id_Cliente"].ToString().Trim();
                    txt_Comentario.Text = dsInfoPedido.Tables[0].Rows[0]["Comentario"].ToString().Trim();

                    decimal valor = Convert.ToDecimal(dsInfoPedido.Tables[0].Rows[0]["Total_Venta"].ToString().Trim());
                    string dosDecimal = valor.ToString("0.##");

                    txt_Total_Pedido.Text = dosDecimal;

                    /* Cargamos los datos del cliente */
                    txt_Cliente.Text = dsInfoPedido.Tables[0].Rows[0]["Nombre_Cliente"].ToString().Trim();
                    txt_Desc.Text = dsInfoPedido.Tables[0].Rows[0]["Descuento"].ToString().Trim();
                    txt_Direccion.Text = dsInfoPedido.Tables[0].Rows[0]["Domicilio_Cliente"].ToString().Trim();

                    /* CARGAMOS EL DETALLE DE VENTA DEL PEDIDO */
                    _mInventario.IdPedido = _NoPedido;
                    _mInventario.IdFolioPedido = _FolioPedido;
                    _mInventario.IdCliente = Convert.ToInt32(_Id_Cliente);
                    _mInventario.intAccion = 2;

                    DataSet dsDetallePedido = _mInventario.dsObtenerDatosPedido();

                    if (dsDetallePedido != null && dsDetallePedido.Tables.Count > 0)
                    {
                        dgv_Pedido.DataSource = dsDetallePedido.Tables[0];

                        if (dgv_Pedido.Columns[""] != null)
                        {
                            //MessageBox.Show("Existe");
                        }

                        else
                        {
                            string[] tipocentro = new[] { "Bulto", "Caja", "Kilo", "Pieza", "1/2 Caja",
                        "Arpilla", "Manojo", "Paq.", "Pesos", "Exhibidor", "Lata"};
                            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();

                            cmb.DataSource = tipocentro;
                            cmb.Width = 150;
                            cmb.HeaderText = "UM";
                            //cmb.DisplayMember = "UM";
                            cmb.DataPropertyName = "UM";
                            //cmb.ValueMember = "UM";
                            dgv_Pedido.Columns.Add(cmb);
                            cmb.DisplayIndex = 3; //Posicion de la columna en la tabla. 
                        }

                        dgv_Pedido.CurrentCell = dgv_Pedido.Rows[dgv_Pedido.RowCount - 1].Cells[2];

                        /* CARGAR LA UNIDAD DE MEDIDA */
                        try
                        {
                            for (int i = 0; i < dgv_Pedido.RowCount; i++)
                            {
                                _mInventario.IdPedido = _NoPedido;
                                _mInventario.IdFolioPedido = _FolioPedido;
                                _mInventario.IdCliente = Convert.ToInt32(dgv_Pedido.Rows[i].Cells["Clave Producto"].Value.ToString().Trim());
                                _mInventario.intAccion = 3;

                                DataSet dsUnidadDeMedida = _mInventario.dsObtenerDatosPedido();

                                if (dsUnidadDeMedida != null && dsUnidadDeMedida.Tables.Count > 0)
                                {
                                    string um = dsUnidadDeMedida.Tables[0].Rows[0]["UM"].ToString();

                                    dgv_Pedido.Rows[i].Cells["UM"].Value = um;
                                }
                            }

                        } catch (Exception ex) { }

                        try
                        {
                            dgv_Pedido.Columns[3].Visible = false;
                        }
                        catch (Exception ex) { }
                    }
                }

            }
            catch (Exception ex) { }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Catalogo_Productos producto = new Frm_Catalogo_Productos();
                producto.ShowDialog();

                if (_Id_Clave_Producto != "0" && _Id_Clave_Producto != null)
                {
                    txt_ClaveProducto.Text = Convert.ToString(_Id_Clave_Producto);

                    DataTable dsReq = cargaTabla_PedidoDetalle();
                    dgv_Pedido.DataSource = dsReq;

                    if (dgv_Pedido.Columns[""] != null)
                    {
                        //MessageBox.Show("Existe");
                    }

                    else
                    {
                        string[] tipocentro = new[] { "Bulto", "Caja", "Kilo", "Pieza", "1/2 Caja",
                            "Arpilla", "Manojo", "Paq.", "Pesos", "Exhibidor" , "Lata"};
                        DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();

                        cmb.DataSource = tipocentro;
                        cmb.Width = 150;
                        cmb.HeaderText = "UM";
                        //cmb.ValueMember = "UM";
                        dgv_Pedido.Columns.Add(cmb);
                        cmb.DisplayIndex = 3;
                    }

                    dgv_Pedido.CurrentCell = dgv_Pedido.Rows[dgv_Pedido.RowCount - 1].Cells[2];
                }
            }
            catch (Exception ex) { }
            
        }

        private void txt_ClaveProducto_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dgv_Pedido_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_Pedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string valor = Convert.ToString(dgv_Pedido.CurrentCell.Value.ToString());
            }

            if (e.KeyChar == 27)
            {
                txt_ClaveProducto.Focus();
            }
        }

        private void dgv_Pedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string valor = Convert.ToString(dgv_Pedido.CurrentCell.Value.ToString());
            }
        }

        private void dgv_Pedido_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //string valor = Convert.ToString(dgv_Pedido.CurrentCell.Value.ToString());

                int cell = 0, row = 0, a = 0;
                string x = null; 
                int lastRow = 0;
                var totalRow = string.Empty; 

                cell = dgv_Pedido.CurrentCell.ColumnIndex; //Columna
                row = dgv_Pedido.CurrentCell.RowIndex; //Fila

                if (dgv_Pedido.CurrentRow == null)
                    return;

                //lastRow = dgv_Pedido.Rows.ToString();
                //totalRow = dgv_Pedido.CurrentRow.ToString(); 

                if (cell == 2) //Validamos si damos click en cantidad
                {
                    lastRow = dgv_Pedido.RowCount;

                    if (lastRow != row)
                    {
                        row = row - 1;
                    }

                    //else if (row == -1)
                    //{
                    //    row = row + 1; 
                    //}
                    //if (lastRow.Equals(row))
                    //{
                    //    row = row - 1;
                    //}
                    //else
                    //{
                    //    row = row + 1;
                    //}

                    int cantidad = Convert.ToInt32(dgv_Pedido.Rows[row].Cells[cell].Value.ToString());

                    if (cantidad == 0)
                    {
                        dgv_Pedido.Rows.RemoveAt(row);
                    }

                    else
                    {
                        float precio = float.Parse(dgv_Pedido.Rows[row].Cells[3].Value.ToString());
                        float descuento = float.Parse(dgv_Pedido.Rows[row].Cells[4].Value.ToString());
                        float total = float.Parse(dgv_Pedido.Rows[row].Cells[5].Value.ToString());

                        //Valores Actualizado
                        float precio_2 = precio;
                        float descuento_2 = descuento;
                        float total_2 = cantidad * precio_2;

                        // Precio
                        dgv_Pedido.Rows[row].Cells[3].Value = Convert.ToString(precio_2);

                        // Descuento
                        dgv_Pedido.Rows[row].Cells[4].Value = Convert.ToString(descuento_2);

                        // Total
                        dgv_Pedido.Rows[row].Cells[5].Value = Convert.ToString(total_2);
                    }
                }

                else if (cell == 3)
                {
                    float precio = float.Parse(dgv_Pedido.Rows[row].Cells[cell].Value.ToString());

                    int cantidad = Convert.ToInt32(dgv_Pedido.Rows[row].Cells[2].Value.ToString());
                    float descuento = float.Parse(dgv_Pedido.Rows[row].Cells[4].Value.ToString());
                    float total = float.Parse(dgv_Pedido.Rows[row].Cells[5].Value.ToString());

                    float descuentoTotal = (descuento / 100) * precio;

                    // Valores Actualizado
                    float cantidad_2 = cantidad;
                    float descuento_2 = descuento;
                    //float total_2 = cantidad * precio;
                    float subtotal = cantidad * precio;
                    float total_2 = subtotal - descuentoTotal;

                    // Cantidad
                    dgv_Pedido.Rows[row].Cells[2].Value = Convert.ToString(cantidad);

                    // Descuento
                    dgv_Pedido.Rows[row].Cells[4].Value = Convert.ToString(descuento_2);

                    // Total
                    dgv_Pedido.Rows[row].Cells[5].Value = Convert.ToString(total_2);
                }

                else if (cell == 4)
                {
                    float descuento = float.Parse(dgv_Pedido.Rows[row].Cells[cell].Value.ToString());

                    int cantidad = Convert.ToInt32(dgv_Pedido.Rows[row].Cells[2].Value.ToString());
                    float precio = float.Parse(dgv_Pedido.Rows[row].Cells[3].Value.ToString());
                    float total = float.Parse(dgv_Pedido.Rows[row].Cells[5].Value.ToString());

                    float descuentoTotal = (descuento / 100) * precio;
                    // Valores Actualizado

                    float cantidad_2 = cantidad;
                    float descuento_2 = descuento;
                    float subtotal = cantidad * precio;
                    float total_2 = subtotal - descuentoTotal;

                    // Cantidad
                    dgv_Pedido.Rows[row].Cells[2].Value = Convert.ToString(cantidad);

                    // Descuento
                    dgv_Pedido.Rows[row].Cells[4].Value = Convert.ToString(descuento_2);

                    // Total
                    dgv_Pedido.Rows[row].Cells[5].Value = Convert.ToString(total_2);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Catalogo_Productos producto = new Frm_Catalogo_Productos();
                producto.ShowDialog();

                if (_Id_Clave_Producto != "0" && _Id_Clave_Producto != null)
                {
                    txt_ClaveProducto.Text = Convert.ToString(_Id_Clave_Producto);

                    DataTable dsReq = cargaTabla_PedidoDetalle();
                    dgv_Pedido.DataSource = dsReq;

                    if (dgv_Pedido.Columns[""] != null)
                    {
                        //MessageBox.Show("Existe");
                    }

                    else
                    {
                        string[] tipocentro = new[] { "Bulto", "Caja", "Kilo", "Pieza", "1/2 Caja",
                        "Arpilla", "Manojo", "Paq.", "Pesos", "Exhibidor", "Lata" };
                        DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();

                        cmb.DataSource = tipocentro;
                        cmb.Width = 150;
                        cmb.HeaderText = "UM";
                        //cmb.ValueMember = "UM";
                        dgv_Pedido.Columns.Add(cmb);
                        cmb.DisplayIndex = 3;
                    }

                    dgv_Pedido.CurrentCell = dgv_Pedido.Rows[dgv_Pedido.RowCount - 1].Cells[2];
                }
            }
            catch (Exception ex) { }
        }

        private void dgv_Pedido_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            } catch (Exception ex) { }
        }
    }
}
