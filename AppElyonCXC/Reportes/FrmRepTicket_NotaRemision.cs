using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppElyonCXC.Reportes
{
    public partial class FrmRepTicket_NotaRemision : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        ElyonModelCxC.mCuentasC _mcuentas = new ElyonModelCxC.mCuentasC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        ElyonModelCxC.mInventario _mInventario = new ElyonModelCxC.mInventario(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
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
        public int IdPedido = 0; 
        DataSet dsrpd;
        #endregion //Variables

        #region CONSTRUCTORES
        public FrmRepTicket_NotaRemision()
        {
            InitializeComponent();
        }

        public FrmRepTicket_NotaRemision(DataSet dsParam)
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

        private void FrmRepTicket_NotaRemision_Load(object sender, EventArgs e)
        {
            this.Text = MensajeProceso;
            GeneraReporte();
        }

        public void GeneraReporte()
        {
            this.crystalReportViewer1.ReportSource = null;
            int i = 0;
            dsTicket_Remision dsRepInforme = new dsTicket_Remision();

            try
            {
                #region CUERPO DEL REPORTE

                //DataSet dsrpd = _mtesoreria.dsobtieneInformeCierre();
                _mInventario.Id_Generar_Pedido = IdPedido;
                dsrpd = _mInventario.dsObtenerBoleta_NotaRemision();

                // ---------  Cargamos y mostramos el formulario Progress bar  -------

                if (dsrpd.Tables[1].Rows.Count > 0)
                {
                    MessageBox.Show("Consulta generada", "CONSULTA - NOTA REMISIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    /*******************************************************/

                    dsrpd.Tables[1].TableName = "dtTicketRemision";

                    #region  llena dtSaldo_Usuario
                    DataRow drts;
                    while (i < dsrpd.Tables["dtTicketRemision"].Rows.Count)
                    {
                        drts = dsRepInforme.Tables["dtTicketRemision"].NewRow();

                        drts["CLAVE_PRODUCTO"] = dsrpd.Tables["dtTicketRemision"].Rows[i]["CLAVE_PRODUCTO"].ToString();
                        drts["DESCRIPCION"] = dsrpd.Tables["dtTicketRemision"].Rows[i]["DESCRIPCION"].ToString();
                        drts["CANTIDAD"] = dsrpd.Tables["dtTicketRemision"].Rows[i]["CANTIDAD"].ToString();

                        decimal precio = Convert.ToDecimal(String.Format("{0:C}", dsrpd.Tables["dtTicketRemision"].Rows[i]["PRECIO"].ToString()));
                        string precio_2 = precio.ToString("C");
                        drts["PRECIO"] = precio_2;

                        drts["DESCUENTO"] = dsrpd.Tables["dtTicketRemision"].Rows[i]["DESCUENTO"].ToString();

                        decimal importe = Convert.ToDecimal(String.Format("{0:C}", dsrpd.Tables["dtTicketRemision"].Rows[i]["IMPORTE"].ToString()));
                        string importe_2 = precio.ToString("C");
                        drts["IMPORTE"] = importe_2;



                        //drts["Fecha_Venta"] = dsrpd.Tables["dtTicketRemision"].Rows[i]["Id_Cliente"].ToString();

                        drts["Id_Cliente"] = dsrpd.Tables["dtTicketRemision"].Rows[i]["Id_Cliente"].ToString();

                        drts["Nombre_Cliente"] = dsrpd.Tables["dtTicketRemision"].Rows[i]["Id_Cliente"].ToString() + " - " + 
                            (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(dsrpd.Tables["dtTicketRemision"].Rows[i]["Nombre_Cliente"].ToString())) +
                            " (" + dsrpd.Tables["dtTicketRemision"].Rows[i]["RFC_Cliente"].ToString() + ")";
                        //drts["RFC_Cliente"] = "RFC: " + dsrpd.Tables["dtTicketRemision"].Rows[i]["RFC_Cliente"].ToString();
                        drts["Domicilio_Cliente"] = dsrpd.Tables["dtTicketRemision"].Rows[i]["Domicilio_Cliente"].ToString() + " Col. "+ dsrpd.Tables["dtTicketRemision"].Rows[i]["Colonia_Cliente"].ToString() +
                            " Cp. " + dsrpd.Tables["dtTicketRemision"].Rows[i]["Cp_Cliente"].ToString() + ", " + dsrpd.Tables["dtTicketRemision"].Rows[i]["Municipio_Cliente"].ToString();
                        //drts["Colonia_Cliente"] = "Colonia: " + dsrpd.Tables["dtTicketRemision"].Rows[i]["Colonia_Cliente"].ToString();
                        //drts["Ciudad_Cliente"] = dsrpd.Tables["dtTicketRemision"].Rows[i]["Municipio_Cliente"].ToString();
                        //drts["Cp_Cliente"] = "Codigo Postal: " + dsrpd.Tables["dtTicketRemision"].Rows[i]["Cp_Cliente"].ToString();
                        //drts["Telefono_Cliente"] = "Telefono: " + dsrpd.Tables["dtTicketRemision"].Rows[i]["Telefono_Cliente"].ToString();

                        //drts["Municipio_Cliente"] = dsrpd.Tables["dtTicketRemision"].Rows[i]["Pais_Cliente"].ToString();
                        //drts["Estado_Cliente"] = dsrpd.Tables["dtTicketRemision"].Rows[i]["Correo_Cliente"].ToString();
                        //rts["Pais_Cliente"] = dsrpd.Tables["dtTicketRemision"].Rows[i]["Telefono_Cliente"].ToString();

                        //drts["Correo_Cliente"] = dsrpd.Tables["dtTicketRemision"].Rows[i]["RFC_Cliente"].ToString();
                        
                        
                        //drts["Limite_Credito_Cliente"] = dsrpd.Tables["dtTicketRemision"].Rows[i]["No_Cuenta_Cliente"].ToString();
                        //drts["Dias_Credito_Cliente"] = dsrpd.Tables["dtTicketRemision"].Rows[i]["Folio"].ToString() + " " + dsrpd.Tables["dtTicketRemision"].Rows[i]["Id_Pedido"].ToString();

                        //drts["No_Cuenta_Cliente"] = dsrpd.Tables["dtTicketRemision"].Rows[i]["Folio"].ToString() + " " + dsrpd.Tables["dtTicketRemision"].Rows[i]["Id_Pedido"].ToString();
                        //drts["CLAVE_PRODUCTO"] = dsrpd.Tables["dtTicketRemision"].Rows[i]["Folio"].ToString() + " " + dsrpd.Tables["dtTicketRemision"].Rows[i]["Id_Pedido"].ToString();
                        //drts["DESCRIPCION"] = dsrpd.Tables["dtTicketRemision"].Rows[i]["Folio"].ToString() + " " + dsrpd.Tables["dtTicketRemision"].Rows[i]["Id_Pedido"].ToString();
                        //drts["CANTIDAD"] = dsrpd.Tables["dtTicketRemision"].Rows[i]["Folio"].ToString() + " " + dsrpd.Tables["dtTicketRemision"].Rows[i]["Id_Pedido"].ToString();
                        //drts["PRECIO"] = dsrpd.Tables["dtTicketRemision"].Rows[i]["Folio"].ToString() + " " + dsrpd.Tables["dtTicketRemision"].Rows[i]["Id_Pedido"].ToString();
                        //drts["DESCUENTO"] = dsrpd.Tables["dtTicketRemision"].Rows[i]["Folio"].ToString() + " " + dsrpd.Tables["dtTicketRemision"].Rows[i]["Id_Pedido"].ToString();
                        //drts["IMPORTE"] = dsrpd.Tables["dtTicketRemision"].Rows[i]["Folio"].ToString() + " " + dsrpd.Tables["dtTicketRemision"].Rows[i]["Id_Pedido"].ToString();
                        //drts["Letra"] = dsrpd.Tables["dtTicketRemision"].Rows[i]["Folio"].ToString() + " " + dsrpd.Tables["dtTicketRemision"].Rows[i]["Id_Pedido"].ToString();

                        dsRepInforme.Tables["dtTicketRemision"].Rows.Add(drts);
                        i++;

                        drts["Razon_Social"] = dsrpd.Tables[2].Rows[0]["Razon_Social"].ToString().Trim();
                        drts["RFC"] = dsrpd.Tables[2].Rows[0]["RFC"].ToString().Trim();
                        drts["Domicilio"] = dsrpd.Tables[2].Rows[0]["Domicilio"].ToString().Trim();
                        drts["Colonia"] = dsrpd.Tables[2].Rows[0]["Colonia"].ToString().Trim();
                        drts["CP"] = dsrpd.Tables[2].Rows[0]["CP"].ToString().Trim();
                        drts["Telefono"] = dsrpd.Tables[2].Rows[0]["Telefono"].ToString().Trim();

                        drts["No_Nota_Remision"] = dsrpd.Tables[0].Rows[0]["No_Nota_Remision"].ToString();
                        drts["Folio"] = dsrpd.Tables[0].Rows[0]["Id_Pedido_Generado"].ToString();

                        DateTime fecha = Convert.ToDateTime(dsrpd.Tables[0].Rows[0]["Fecha_Nota_Remision"].ToString()); 
                        drts["Fecha_Nota_Remision"] = fecha.ToString("dd/MM/yyyy");

                        drts["Cajero"] = dsrpd.Tables[0].Rows[0]["Cajero"].ToString();
                        drts["Estatus_Nota_Remision"] = dsrpd.Tables[0].Rows[0]["Estatus_Nota_Remision"].ToString();

                        try
                        {
                            decimal importeNota = Convert.ToDecimal(String.Format("{0:C}", dsrpd.Tables[3].Rows[0]["Total_Venta"].ToString()));
                            string TotalNota = precio.ToString("C");
                            drts["Limite_Credito_Cliente"] = TotalNota;
                            drts["Letra"] = dsrpd.Tables[3].Rows[0]["Total_Letra"].ToString();
                        }
                        catch (Exception ex) { }
                    }

                    #endregion  llena dtSaldo_Usuario  

                    if (dsRepInforme.Tables[0].Rows.Count > 0)
                    {

                        CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CR_Ticket_Nota_Remision();

                        rd.SetDataSource(dsRepInforme);
                        foreach (CrystalDecisions.CrystalReports.Engine.ReportDocument sr in rd.Subreports)
                        {
                            if (sr.Database.Tables.Count > 0)
                            {
                                sr.SetDataSource(dsRepInforme);
                            }
                        }

                        ////rd.SetParameterValue("Cajero", (txtUsuario.Text.Equals("") ? "TODOS" : txtUsuario.Text));
                        ////rd.SetParameterValue("Fechainicial", dtFechainicial.Value);
                        ////rd.SetParameterValue("FechaFinal", dtFechaFinal.Value);

                        try
                        {
                            MessageBox.Show("IMPRESION", "ERROR - IMPRESIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            rd.PrintToPrinter(2, false, 0, 0);//Imprimo 2 copias
                            rd.PrintOptions.PrinterName = Properties.Settings.Default.str_Impresora_1;
                        }
                        catch (Exception ex) { MessageBox.Show(ex.ToString(), "ERROR - IMPRESIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

                        try
                        {
                            this.crystalReportViewer1.ReportSource = rd;
                            this.crystalReportViewer1.Show();
                        }
                        catch (Exception ex) { MessageBox.Show(ex.ToString(), "ERROR - IMPRESIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

                        try
                        {
                            string nombreDocumento = "Nota_Remision_" + IdPedido;
                            string archivo = @"C:\Tss_Inventario_PDF\\" + nombreDocumento + ".pdf";
                            //"C:\\Users\\miriam.castro\\Documents\\Centro de Admision\\Cambio cédulas 11_2019\\cedula.pdf"; 
                            rd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, archivo);
                        }
                        catch (Exception ex) { MessageBox.Show(ex.ToString(), "ERROR - GUARDAR EN CARPETA", MessageBoxButtons.OK, MessageBoxIcon.Warning); }


                    }
                }
                else
                {
                    MessageBox.Show("No hay datos a cargar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.crystalReportViewer1.ReportSource = null;
                }

                #endregion
            }
            catch (Exception ex) { }
        }
    }
}
