using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppElyonCXC.Catalogos
{
    public partial class Frm_Historial_Notas_Remision : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        ElyonModelCxC.mInventario _mInventario = new ElyonModelCxC.mInventario(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        Ticket _cticket = new Ticket();
        #endregion

        #region Variables 
        public static string _IdNotaRemision;
        int _Id_Registro_Pago_Cliente_Detalle;
        int _Id_Registro_Pago_Cliente;
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

        public Frm_Historial_Notas_Remision()
        {
            InitializeComponent();
            CargarHistorialCliente();
        }

        private void CargarHistorialCliente()
        {
            if (NivelSeguridad != "1")
            {
                try
                {
                    _mInventario.Id_Nota_Remision = 0;
                    _mInventario.Id_No_Pedido = 0;
                    _mInventario.Fecha_Nota_Remision = DateTime.Now;
                    _mInventario.Id_Cajero = 0;
                    _mInventario.vchEstatus_Nota_Remision = "";
                    _mInventario.Id_Cliente = Convert.ToInt32(_IdNotaRemision);
                    _mInventario.intAccionNotaRemision = 7; 
    
                    DataSet dsNotaRemision = _mInventario.dsRegistroNotaRemision();

                    if (dsNotaRemision != null && dsNotaRemision.Tables.Count > 0)
                    {
                        dgv_Nota_Remision.DataSource = dsNotaRemision.Tables[0];

                        //COLUMNAS OCULTAS                    
                        dgv_Nota_Remision.gvGrid.Columns["Id_Nota"].ReadOnly = true;
                        dgv_Nota_Remision.gvGrid.Columns["Id_Pedido"].ReadOnly = true;
                        dgv_Nota_Remision.gvGrid.Columns["Fecha_Nota_Remision"].ReadOnly = true;
                        dgv_Nota_Remision.gvGrid.Columns["Id_Cajero"].ReadOnly = true;
                        dgv_Nota_Remision.gvGrid.Columns["Estatus_Remision"].ReadOnly = true;
                        dgv_Nota_Remision.gvGrid.Columns["Fecha_Venta_Pedido"].ReadOnly = true;
                        dgv_Nota_Remision.gvGrid.Columns["Fecha_Vencimiento_Credito"].ReadOnly = true;
                        dgv_Nota_Remision.gvGrid.Columns["Dias_Credito"].ReadOnly = true;
                        dgv_Nota_Remision.gvGrid.Columns["Adeudo"].ReadOnly = true;
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
                MessageBox.Show("NO estas Autorizado para Consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_Nota_Remision_cell_Datagrid_ContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cliente.Frm_Registrar_Pago_Cliente._IdNotaRemision = dgv_Nota_Remision.gvGrid.Rows[e.RowIndex].Cells["Id_Nota"].Value.ToString();
            this.Close();
        }
    }
}
