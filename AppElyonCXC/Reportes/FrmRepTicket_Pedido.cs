using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppElyonCXC.Reportes
{
    public partial class FrmRepTicket_Pedido : Form
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
        public FrmRepTicket_Pedido()
        {
            InitializeComponent();
        }

        public FrmRepTicket_Pedido(DataSet dsParam)
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

        private void FrmRepTicket_Pedido_Load(object sender, EventArgs e)
        {
            this.Text = MensajeProceso;
            GeneraReporte();
        }

        public void GeneraReporte()
        {
            this.crystalReportViewer1.ReportSource = null;
            int i = 0;
            dsTicket_Pedido dsRepInforme = new dsTicket_Pedido();

            try
            {
                #region CUERPO DEL REPORTE

                //DataSet dsrpd = _mtesoreria.dsobtieneInformeCierre();
                _mInventario.Id_Generar_Pedido = IdPedido;
                dsrpd = _mInventario.dsObtenerBoletaPedido();

                // ---------  Cargamos y mostramos el formulario Progress bar  -------

                if (dsrpd.Tables[1].Rows.Count > 0)
                {

                    /*******************************************************/

                    dsrpd.Tables[1].TableName = "dtTicketPedido";

                    #region  llena dtSaldo_Usuario
                    DataRow drts;
                    while (i < dsrpd.Tables["dtTicketPedido"].Rows.Count)
                    {
                        drts = dsRepInforme.Tables["dtTicketPedido"].NewRow();

                        drts["CLAVE_PRODUCTO"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["CLAVE_PRODUCTO"].ToString();
                        drts["DESCRIPCION"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["DESCRIPCION"].ToString();
                        drts["CANTIDAD"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["CANTIDAD"].ToString();
                        drts["PRECIO"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["PRECIO"].ToString();
                        drts["DESCUENTO"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["DESCUENTO"].ToString();
                        drts["IMPORTE"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["IMPORTE"].ToString();

                        drts["Id_Usuario"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["Id_Usuario"].ToString();
                        drts["Usuario"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["Usuario"].ToString();
                        drts["Fecha_Venta"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["Fecha_Venta"].ToString();
                        drts["Id_Cliente"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["Id_Cliente"].ToString();
                        drts["Nombre_Cliente"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["Nombre_Cliente"].ToString();
                        drts["Domicilio_Cliente"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["Domicilio_Cliente"].ToString();
                        drts["Colonia_Cliente"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["Colonia_Cliente"].ToString();
                        drts["Cp_Cliente"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["Cp_Cliente"].ToString();
                        drts["Municipio_Cliente"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["Municipio_Cliente"].ToString();
                        drts["Estado_Cliente"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["Estado_Cliente"].ToString();
                        drts["Pais_Cliente"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["Pais_Cliente"].ToString();
                        drts["Correo_Cliente"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["Correo_Cliente"].ToString();
                        drts["Telefono_Cliente"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["Telefono_Cliente"].ToString();

                        drts["RFC_Cliente"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["RFC_Cliente"].ToString();
                        drts["Limite_Credito_Cliente"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["Limite_Credito_Cliente"].ToString();
                        drts["Dias_Credito_Cliente"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["Dias_Credito_Cliente"].ToString();
                        drts["No_Cuenta_Cliente"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["No_Cuenta_Cliente"].ToString();
                        drts["Id_Pedido"] = dsrpd.Tables["dtTicketPedido"].Rows[i]["Folio"].ToString() + " " + dsrpd.Tables["dtTicketPedido"].Rows[i]["Id_Pedido"].ToString();

                        dsRepInforme.Tables["dtTicketPedido"].Rows.Add(drts);
                        i++;

                        drts["Razon_Social"] = dsrpd.Tables[2].Rows[0]["Razon_Social"].ToString().Trim();
                        drts["RFC"] = dsrpd.Tables[2].Rows[0]["RFC"].ToString().Trim();
                        drts["Domicilio"] = dsrpd.Tables[2].Rows[0]["Domicilio"].ToString().Trim();
                        drts["Colonia"] = dsrpd.Tables[2].Rows[0]["Colonia"].ToString().Trim();
                        drts["CP"] = dsrpd.Tables[2].Rows[0]["CP"].ToString().Trim();
                        drts["Telefono"] = dsrpd.Tables[2].Rows[0]["Telefono"].ToString().Trim();
                    }

                    #endregion  llena dtSaldo_Usuario  

                    if (dsRepInforme.Tables[0].Rows.Count > 0)
                    {

                        CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CR_Ticket_GeneracionDePedido();

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

                        this.crystalReportViewer1.ReportSource = rd;

                        try
                        {
                            string nombreDocumento = "Ticket_Pedido_" + IdPedido;
                            string archivo = @"C:\Tss_Inventario_PDF\\" + nombreDocumento + ".pdf";
                            //"C:\\Users\\miriam.castro\\Documents\\Centro de Admision\\Cambio cédulas 11_2019\\cedula.pdf"; 
                            rd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, archivo);
                        }
                        catch (Exception ex) { MessageBox.Show(ex.ToString(), "ERROR - GUARDAR EN CARPETA", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

                        //this.CrvReportes.Show();

                        //this.crystalReportViewer1.Show();
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
