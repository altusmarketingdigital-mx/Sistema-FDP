using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppElyonCXC.Cliente
{
    public partial class Frm_Registrar_Pago_Cliente : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        ElyonModelCxC.mInventario _mInventario = new ElyonModelCxC.mInventario(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        Ticket _cticket = new Ticket();
        #endregion

        #region Variables 
        public static string _IdClaveCliente, _IdNotaRemision;
        int _Id_Registro_Pago_Cliente_Detalle, _Id_Registro_Pago_Cliente;
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

        public Frm_Registrar_Pago_Cliente()
        {
            InitializeComponent();
        }

        public Frm_Registrar_Pago_Cliente(DataSet dsParam)
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

            Cargar_Forma_Pago();
        }

        #endregion CONSTRUCTORES

        private void Cargar_Forma_Pago()
        {
            try
            {
                _mInventario.intValor1 = 5;
                DataSet dsTipo_Pago = _mInventario.dsCargarCombo();

                if (dsTipo_Pago.Tables[0].Rows.Count > 0)
                {
                    cmb_Tipo_Pago.DataSource = dsTipo_Pago.Tables[0].DefaultView;
                    cmb_Tipo_Pago.ValueMember = "Id";
                    cmb_Tipo_Pago.DisplayMember = "Descripcion";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void CargarDatosCliente()
        {
            try
            {
                _mInventario.Id_Cliente = Convert.ToInt32(txt_No_Cliente.Text.Trim().ToString());
                _mInventario.intAccionCliente = 6;

                DataSet dsCliente = _mInventario.dsCatalogoClientes();

                if (dsCliente != null && dsCliente.Tables.Count > 0)
                {
                    txt_Nombre_Cliente.Text = dsCliente.Tables[0].Rows[0]["Nombre"].ToString().Trim();
                    txt_RFC_Cliente.Text = dsCliente.Tables[0].Rows[0]["RFC"].ToString().Trim();
                    txt_Dias_Credito.Text = dsCliente.Tables[0].Rows[0]["Dias_Credito"].ToString().Trim();
                }

            }
            catch (Exception ex) { }
        }

        private void CargarNotaRemision()
        {
            _mInventario.Fecha_Nota_Remision = DateTime.Now;
            _mInventario.Id_Nota_Remision = Convert.ToInt32(txt_No_Remision.Text.Trim().ToString());
            _mInventario.intAccionNotaRemision = 4;

            DataSet dsNotaRemision = _mInventario.dsRegistroNotaRemision();

            if (dsNotaRemision != null && dsNotaRemision.Tables.Count > 0)
            {
                dtp_Fecha_Generacion.Value = Convert.ToDateTime(dsNotaRemision.Tables[0].Rows[0]["Fecha_Venta_Pedido"].ToString().Trim());
                txt_Estatus_Documento.Text = dsNotaRemision.Tables[0].Rows[0]["Estatus_Remision"].ToString().Trim();
                dtp_Fecha_Vencimientos.Value = Convert.ToDateTime(dsNotaRemision.Tables[0].Rows[0]["Fecha_Vencimiento_Credito"].ToString().Trim());
                txt_Plazo_Pago.Text = dsNotaRemision.Tables[0].Rows[0]["Dias_Credito"].ToString().Trim();

                DateTime fecha_1 = Convert.ToDateTime(dsNotaRemision.Tables[0].Rows[0]["Fecha_Venta_Pedido"].ToString().Trim());
                DateTime fecha_2 = Convert.ToDateTime(dsNotaRemision.Tables[0].Rows[0]["Fecha_Vencimiento_Credito"].ToString().Trim());
                TimeSpan difFechas = fecha_1 - fecha_2;
                int dias = difFechas.Days;
                int plazo = Convert.ToInt32(dsNotaRemision.Tables[0].Rows[0]["Dias_Credito"].ToString().Trim());

                txt_Dias_Vencidos.Text = Convert.ToString(plazo - dias);

                decimal adeudo = Convert.ToDecimal(dsNotaRemision.Tables[0].Rows[0]["Adeudo"].ToString().Trim());

                txt_Adeudo.Text = "$ " + adeudo.ToString("N2");
                txt_Intereses.Text = "0.00 ";

                //VALIDAMOS EL ULTIMO NUMERO DE PAGO
                _mInventario.intAccionRegistroPagoCliente = 1;
                _mInventario.Id_Cliente = Convert.ToInt32(txt_No_Cliente.Text.Trim().ToString());
                _mInventario.Id_Nota_Remision = Convert.ToInt32(txt_No_Remision.Text.ToString());
                _mInventario.Fecha_Timbrado = DateTime.Now;

                DataSet dsUltimoRegistro = _mInventario.dsRegistroPagoCliente();

                if (dsUltimoRegistro != null && dsNotaRemision.Tables.Count > 0)
                {
                    txt_No_Pago_Anterior.Text = dsUltimoRegistro.Tables[0].Rows[0]["No_Nota_Remision"].ToString().Trim();

                    _mInventario.intAccionRegistroPagoCliente = 2;
                    _mInventario.Id_Cliente = Convert.ToInt32(txt_No_Cliente.Text.Trim().ToString());
                    _mInventario.Id_Nota_Remision = Convert.ToInt32(txt_No_Remision.Text.ToString());
                    _mInventario.Fecha_Timbrado = DateTime.Now;

                    DataSet dsUltimoRegistro_2 = _mInventario.dsRegistroPagoCliente();

                    if (dsUltimoRegistro_2 != null && dsUltimoRegistro_2.Tables.Count > 0 && dsUltimoRegistro_2.Tables[0].Rows.Count > 0)
                    {

                    }

                    else
                    {
                        txt_Saldo_Anterio.Text = "$ " + Convert.ToDecimal(dsNotaRemision.Tables[0].Rows[0]["Adeudo"]).ToString("N2");
                        txt_Cantidad_Interes.Text = "0.00";
                        txt_Saldo_Favor.Text = "0.00";
                        txt_Importe_A_Pagar.Text = "0.00";
                        txt_Saldo_Nuevo.Text = "$ " + Convert.ToDecimal(dsNotaRemision.Tables[0].Rows[0]["Adeudo"]).ToString("N2");
                        dtp_Fecha_Timbrado.Value = DateTime.Now;
                        //DATOS PAGO
                        txt_Importe_Pago.Text = Convert.ToDecimal(dsNotaRemision.Tables[0].Rows[0]["Adeudo"]).ToString("N2");
                    }
                }
            }
        }

        private void txt_No_Cliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                CargarDatosCliente();
            }
        }

        private void txt_No_Remision_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                try
                {
                    CargarNotaRemision();
                }
                catch (Exception ex) { }
            }
        }

        private void txt_Total_Pagado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                try
                {
                    decimal total = Convert.ToDecimal(txt_Importe_Pago.Text.ToString()); 
                    decimal cantidadPago = Convert.ToDecimal(txt_Total_Pagado.Text.ToString());

                    decimal cambio = cantidadPago - total;

                    txt_Cambio.Text = cambio.ToString("N2");
                }
                catch (Exception ex) { }
            }
        }

        private void btnGenerarPago_Click(object sender, EventArgs e)
        {
            int _intID_PagoCliente = 0;
            try
            {
                char delimitador = '$';
                _mInventario.Id_Registro_Pago_Cliente = _Id_Registro_Pago_Cliente;
                _mInventario.Id_Cliente = Convert.ToInt32(txt_No_Cliente.Text.ToString());
                _mInventario.Id_Nota_Remision = Convert.ToInt32(txt_No_Remision.Text.ToString());

                string[] salso_anterior = txt_Saldo_Anterio.Text.ToString().Split(delimitador);
                _mInventario.Saldo_Anterior = float.Parse(salso_anterior[1]);

                string[] interes = txt_Cantidad_Interes.Text.ToString().Split(delimitador);
                _mInventario.Interes = float.Parse(interes[0]);

                string[] saldo_favor = txt_Saldo_Favor.Text.ToString().Split(delimitador);
                _mInventario.Saldo_Favor = float.Parse(saldo_favor[0]);

                string[] importe_pagar = txt_Importe_A_Pagar.Text.ToString().Split(delimitador);
                _mInventario.Pago_Aplicar = float.Parse(importe_pagar[0]);

                string[] saldo_nuevo = txt_Saldo_Nuevo.Text.ToString().Split(delimitador);
                _mInventario.Saldo_Nuevo = float.Parse(saldo_nuevo[1]);

                _mInventario.Fecha_Timbrado = dtp_Fecha_Timbrado.Value; 
                _mInventario.intAccionRegistroPagoCliente = 3;

                DataSet dsRegistroPagoCliente = _mInventario.dsRegistroPagoCliente();

                if (dsRegistroPagoCliente != null && dsRegistroPagoCliente.Tables.Count > 0 && dsRegistroPagoCliente.Tables[0].Rows.Count > 0)
                {
                    _mInventario.Id_Registro_Pago_Cliente_Detalle = _Id_Registro_Pago_Cliente_Detalle;
                    _mInventario.Id_Registro_Pago_Cliente = Convert.ToInt32(dsRegistroPagoCliente.Tables[1].Rows[0][0].ToString());
                    _intID_PagoCliente = Convert.ToInt32(dsRegistroPagoCliente.Tables[1].Rows[0][0].ToString());
                    _mInventario.Id_Forma_Pago = Convert.ToInt32(cmb_Tipo_Pago.SelectedValue.ToString());
                    _mInventario.Importe_Pago = float.Parse(txt_Importe_Pago.Text.ToString()); 
                    _mInventario.Total_Pago = float.Parse(txt_Total_Pagado.Text.ToString());  
                    _mInventario.Cambio_Pago = float.Parse(txt_Cambio.Text.ToString());
                    _mInventario.intAccionRegistroPagoCliente = 4;

                    DataSet dsRegistroPagoCliente_Detalle = _mInventario.dsRegistroPagoCliente();

                    if (dsRegistroPagoCliente_Detalle != null && dsRegistroPagoCliente_Detalle.Tables.Count > 0 && dsRegistroPagoCliente_Detalle.Tables[0].Rows.Count > 0)
                    {
                        _mInventario.Id_Nota_Remision = Convert.ToInt32(txt_No_Remision.Text.ToString());
                        _mInventario.intAccionNotaRemision = 5;

                        DataSet dsActualizarNotaRemision = _mInventario.dsRegistroNotaRemision();

                        if (dsRegistroPagoCliente_Detalle != null && dsRegistroPagoCliente_Detalle.Tables.Count > 0 && dsRegistroPagoCliente_Detalle.Tables[0].Rows.Count > 0)
                        {
                            //Generar Impresion de Ticket
                            vImprimirBoletaPago(_intID_PagoCliente);
                            MessageBox.Show("¡Proceso realizo de forma correcta!", "REGISTRO PAGO CLIENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLimpiar_Click(this, null);
                        }
                    }
                }
            } catch (Exception ex) { }
        }

        private void vImprimirBoletaPago(int idPagoCliente)
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

                    vImprimirTicket(idPagoCliente);

                    //Reportes.FrmRepTicket_Pedido bol = new Reportes.FrmRepTicket_Pedido();
                    //bol.IdPedido = idPagoCliente;
                    //bol.GeneraReporte();

                    //bol.ShowDialog();
                }
            }
            else
            {
                //Generamos el PDF y lo guardamos
                //Reportes.FrmRepTicket_Pedido bol = new Reportes.FrmRepTicket_Pedido();
                //bol.IdPedido = idPagoCliente;
                //bol.GeneraReporte();

                //ParaTicket
                vImprimirTicket(idPagoCliente);

                //Generamos el Ticket en PDF
            }
        }

        private void vImprimirTicket(int idPagoCliente)
        {
            _cticket = new Ticket();
            string _strConcepto = "";
            string _CveProdcuto = "";
            //string strFolio = "";
            //string srtFecha = "";
            //string strHora = "";
            string Condicion = "";
            //string Cajero = "";
            decimal decTotal = 0;
            int intUnidades = 0;

            decimal decSubTotal = 0;
            decimal decIva = 0;
            string strCode = "";
            //string strLetra = "";

            string strFolio = "";
            string srtFecha = "";
            string strHora = "";

            string Documento = "";
            string Adeudo = "";
            string FechaDocumento = "";
            string Vencimiento = "";
            string Estado = "";
            string Cajero = "";

            decimal dcSaldo_Ant = 0;
            decimal dcInteres = 0;
            decimal dcSaldo_Favor = 0;
            decimal dcAplicado = 0;
            decimal dcSaldo_Nuevo = 0;

            string srtFechaPago = "";
            decimal dcImporte = 0;
            string strLetra = "";

            try
            {
                _mInventario.Id_Pagos = idPagoCliente;
                DataSet dsCFD = _mInventario.dsObtenerBoletaPago();

                if (dsCFD.Tables[0].Rows.Count > 0)
                {
                    DataRow drEncabezado = dsCFD.Tables[0].Rows[0];
                    DataRow drDetalle = dsCFD.Tables[1].Rows[0];

                    strFolio = drEncabezado["FOLIO"].ToString();
                    srtFecha = drEncabezado["FECHA"].ToString();
                    strHora = drEncabezado["HORA"].ToString();

                    Documento = drEncabezado["Documento"].ToString();
                    Adeudo = drEncabezado["ADEUDO"].ToString();
                    FechaDocumento = drEncabezado["FECHADO_CUMENTO"].ToString();
                    Vencimiento = drEncabezado["VENCIMIENTO"].ToString();
                    Estado = drEncabezado["ESTADO"].ToString();

                    dcSaldo_Ant = decimal.Parse(drEncabezado["Saldo_anterior"].ToString());
                    dcInteres = decimal.Parse(drEncabezado["INTERES"].ToString());
                    dcSaldo_Favor = decimal.Parse(drEncabezado["Saldo_Favor"].ToString());
                    dcAplicado = decimal.Parse(drEncabezado["Aplicado"].ToString());
                    dcSaldo_Nuevo = decimal.Parse(drEncabezado["Saldo_Nuevo"].ToString());

                    Cajero = drEncabezado["CAJERO"].ToString();

                    srtFechaPago = drDetalle["FECHA"].ToString();
                    dcImporte = decimal.Parse(drDetalle["IMPORTE"].ToString());
                    strLetra = drDetalle["Letra"].ToString();

                    string strDot = "";
                    //_cticket = new ModelElyonTimbrador.Ticket();
                    _cticket.FontName = txtFuenteTicket.Text;
                    //_cticket.HeaderImage = Properties.Resources.LogoUNIVAgrises_vSEP;
                    _cticket.intAjusImg = 24;
                    _cticket.FontSize = Convert.ToInt32(9);

                    for (int i = 0; i < _cticket.MaxChar; i++)
                        strDot += "-";

                    //_cticket.AddHeaderLine("   Emisor RFC :EIVG671203TK7    ");
                    //_cticket.AddHeaderLine("            CAJAS               ");
                    //_cticket.AddHeaderLine("Regimen Fiscal: 601 GENERAL DE LEY DE");
                    //_cticket.AddHeaderLine("LAS PERSONAS MORALES");
                    //_cticket.AddHeaderLine("     ");
                    //_cticket.AddHeaderLine("          Expedido en: 45059    ");
                    //_cticket.AddHeaderLine(" AV. TEPEYAC 5131-77 RESIDENCIAL");
                    //_cticket.AddHeaderLine("MOCTEZUMA ZAPOPAN, JAL 45059 MEXICO");
                    //_cticket.AddHeaderLine("                 3331700238");
                    //_cticket.AddHeaderLine("     ");
                    //_cticket.AddHeaderLine("   Receptor RFC: XAXX010101000  ");
                    //_cticket.AddHeaderLine("ABARROTES 3 REYES (SRA EDITH). UY-YUI");
                    //_cticket.AddHeaderLine("FTGH YUI FGH, . DFGH FGH");
                    //_cticket.AddHeaderLine("     ");

                    DataSet dsContribuyente = _mInventario.dsObtenerContribuyente();

                    _cticket.AddHeaderLine("                                          ");
                    _cticket.AddHeaderLine(dsContribuyente.Tables[0].Rows[0]["vchRazonSocial"].ToString().Trim());
                    _cticket.AddHeaderLine("RFC. " + dsContribuyente.Tables[0].Rows[0]["vchRFC"].ToString().Trim());
                    _cticket.AddHeaderLine(dsContribuyente.Tables[0].Rows[0]["vchCalle"].ToString().Trim() + " #"
                        + dsContribuyente.Tables[0].Rows[0]["vchNoExt"].ToString().Trim() + ", " + dsContribuyente.Tables[0].Rows[0]["vchNoInt"].ToString().Trim());
                    _cticket.AddHeaderLine("Colonia. " + dsContribuyente.Tables[0].Rows[0]["vchColonia"].ToString().Trim());
                    _cticket.AddHeaderLine("Cp. " + dsContribuyente.Tables[0].Rows[0]["vchCodigoPostal"].ToString().Trim() + " | Tel. " + dsContribuyente.Tables[0].Rows[0]["vchTelefono"].ToString().Trim());
                    _cticket.AddHeaderLine("Telefono. " + dsContribuyente.Tables[0].Rows[0]["vchTelefono"].ToString().Trim());
                    //_cticket.AddHeaderLine("                                          ");

                    //bool bEsMayor = false;
                    int intLimit = 35; //28

                    //Obtenemos los datos del CLIENTE
                    _mInventario.Id_No_Pedido = Convert.ToInt32(drEncabezado["ID"].ToString());
                    DataSet dsCliente = _mInventario.dsObtenerDatosCliente();

                    _cticket.AddHeaderLine("                                          ");
                    _cticket.AddHeaderLine("DATOS DEL CLIENTE: ");
                    //_cticket.AddHeaderLine("No. de Cliente: " + dsCliente.Tables[0].Rows[0]["Id_Cliente"].ToString().Trim());
                    _cticket.AddHeaderLine(dsCliente.Tables[0].Rows[0]["Nombre"].ToString().Trim());
                    _cticket.AddHeaderLine("RFC. " + dsCliente.Tables[0].Rows[0]["RFC"].ToString().Trim());
                    _cticket.AddHeaderLine(dsCliente.Tables[0].Rows[0]["Calle"].ToString().Trim());
                    _cticket.AddHeaderLine("Colonia. " + dsCliente.Tables[0].Rows[0]["Colonia"].ToString().Trim());
                    _cticket.AddHeaderLine("Cp." + dsCliente.Tables[0].Rows[0]["Codigo_Postal"].ToString().Trim());
                    _cticket.AddHeaderLine("                                          ");

                    _cticket.AddHeaderLine("            RECIBO DE PAGO        ");                    
                    _cticket.AddSubHeaderLine(" ==========================================");
                    _cticket.AddSubHeaderLine("   Serie Folio N° " + strFolio);
                    _cticket.AddSubHeaderLine("   Fecha:" + srtFecha + " | Hora:" + strHora);
                    _cticket.AddSubHeaderLine(" ==========================================");                    
                    _cticket.AddSubHeaderLine("            DATOS DE LA CUENTA      "); //32
                    _cticket.AddSubHeaderLine("   Documento N°: " + Documento);
                    _cticket.AddSubHeaderLine("   Adeudo cliente: " + Adeudo);
                    _cticket.AddSubHeaderLine("   Fecha documento: " + FechaDocumento);
                    _cticket.AddSubHeaderLine("   Fecha vencimiento: " + Vencimiento);
                    _cticket.AddSubHeaderLine("   Estado: " + Estado);
                    _cticket.AddSubHeaderLine(" ==========================================");
                    _cticket.AddFooterLine("            DATOS DEL PAGO APLICADO    "); //32
                    _cticket.AddFooterLine("   Fecha del pago: " + srtFechaPago);
                    _cticket.AddFooterLine("   Importe del pago: " + String.Format("{0:c}", dcImporte));

                    if (strLetra.Length > 35)
                    {
                        string[] strLetras = strLetra.Split(' ');
                        int intTot = 0;
                        string strCLetra = "";

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
                        _cticket.AddFooterLine(strCLetra);
                    }
                    else
                    {
                        _cticket.AddFooterLine(strLetra);
                    }

                    _cticket.AddFooterLine(" ==========================================");
                    _cticket.AddFooterLine("       ESTADO DE CUENTA         ");
                    _cticket.AddFooterLine("   Saldo anterior: " + String.Format("{0:c}", dcSaldo_Ant));
                    _cticket.AddFooterLine("   Intereses moratorios: " + String.Format("{0:c}", dcInteres));
                    _cticket.AddFooterLine("   Saldo a favor aplicado: " + String.Format("{0:c}", dcSaldo_Favor));
                    _cticket.AddFooterLine("   Pago aplicado: " + String.Format("{0:c}", dcAplicado));
                    _cticket.AddFooterLine("   Saldo a la fecha: " + String.Format("{0:c}", dcSaldo_Nuevo));
                    _cticket.AddFooterLine(" ==========================================");                    
                    _cticket.AddFooterLine("   Cajero: " + Cajero);

                    _cticket.PrintTicket(Properties.Settings.Default.strImpresora);
                }
                else
                {
                    MessageBox.Show("NO EXISTE No PAGO, Validar", "BOLETA DE PAGO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al generar boleta de Pago", "BOLETA DE PAGO - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_Plazo_Pago_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                txt_No_Cliente.Text = "";
                txt_Nombre_Cliente.Text = "";
                txt_RFC_Cliente.Text = "";
                txt_Dias_Credito.Text = "";
                txt_No_Remision.Text = "";
                dtp_Fecha_Generacion.Value = DateTime.Now;
                dtp_Fecha_Vencimientos.Value = DateTime.Now;
                textBox1.Text = "";
                txt_Plazo_Pago.Text = "";
                txt_Dias_Vencidos.Text = "";
                dtp_Fecha_Ultimo_Pago.Value = DateTime.Now;
                txt_Adeudo.Text = "";
                txt_Estatus_Documento.Text = "";
                txt_Intereses.Text = "";
                txt_UUID.Text = "";
                txt_No_Pago_Anterior.Text = "";
                txt_Saldo_Anterio.Text = "";
                txt_Cantidad_Interes.Text = "";
                txt_Saldo_Favor.Text = "";
                txt_Importe_A_Pagar.Text = "";
                txt_Saldo_Nuevo.Text = "";
                dtp_Fecha_Timbrado.Value = DateTime.Now;
                txt_Comentario_Pago.Text = "";
                cmb_Tipo_Pago.SelectedIndex = -1; 
                txt_Importe_Pago.Text = "";
                txt_Total_Pagado.Text = "";
                txt_Cambio.Text = "";

                _IdClaveCliente = "";
                _IdNotaRemision = "";
                _Id_Registro_Pago_Cliente_Detalle = 0;
                _Id_Registro_Pago_Cliente = 0;
                total_final = 0; 
                IP_Local = "";
                _Id_Folio_Pedido = 0;
                _Id_Generar_Pedido_Detalle = 0;
                _intProcesoAutomatico = 0;
    }
            catch (Exception ex) { }
        }

        private void btnCancelarPago_Click(object sender, EventArgs e)
        {
            btnLimpiar_Click(this, null);
        }

        private void btnBuscarRemision_Click(object sender, EventArgs e)
        {
            try
            {
                Catalogos.Frm_Historial_Notas_Remision._IdNotaRemision = txt_No_Cliente.Text.ToString();
                Catalogos.Frm_Historial_Notas_Remision nota = new Catalogos.Frm_Historial_Notas_Remision();
                
                nota.ShowDialog();

                if (_IdNotaRemision != "0" && _IdNotaRemision != null)
                {
                    txt_No_Remision.Text = Convert.ToString(_IdNotaRemision);
                    CargarNotaRemision();
                }
            }
            catch (Exception ex) { }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Catalogos.Frm_Historial_Clientes cliente = new Catalogos.Frm_Historial_Clientes();
                cliente.ShowDialog();

                if (_IdClaveCliente != "0" && _IdClaveCliente != null)
                {
                    txt_No_Cliente.Text = Convert.ToString(_IdClaveCliente);
                    CargarDatosCliente();
                }
            }
            catch (Exception ex) { }
        }
    }
}
