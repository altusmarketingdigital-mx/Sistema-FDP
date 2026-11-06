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
    public partial class Frm_Historial_Clientes : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        ElyonModelCxC.mInventario _mInventario = new ElyonModelCxC.mInventario(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        Ticket _cticket = new Ticket();
        #endregion

        #region Variables 
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

        public Frm_Historial_Clientes()
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
                    dgv_Cliente.DataSource = null;
                    _mInventario.intAccionCliente = 4;

                    DataSet dsCliente = _mInventario.dsCatalogoClientes();

                    if (dsCliente != null && dsCliente.Tables.Count > 0)
                    {
                        dgv_Cliente.DataSource = dsCliente.Tables[0];

                        //COLUMNAS OCULTAS                    
                        dgv_Cliente.gvGrid.Columns["Id"].ReadOnly = true;
                        dgv_Cliente.gvGrid.Columns["Nombre"].ReadOnly = true;
                        dgv_Cliente.gvGrid.Columns["Calle"].ReadOnly = true;
                        dgv_Cliente.gvGrid.Columns["No_Exterior"].ReadOnly = true;
                        dgv_Cliente.gvGrid.Columns["No_Interior"].ReadOnly = true;
                        dgv_Cliente.gvGrid.Columns["Colonia"].ReadOnly = true;
                        dgv_Cliente.gvGrid.Columns["Ciudad"].ReadOnly = true;
                        dgv_Cliente.gvGrid.Columns["Codigo_Postal"].ReadOnly = true;
                        dgv_Cliente.gvGrid.Columns["Municipio"].ReadOnly = true;
                        dgv_Cliente.gvGrid.Columns["Estado"].ReadOnly = true;
                        dgv_Cliente.gvGrid.Columns["Pais"].ReadOnly = true;
                        dgv_Cliente.gvGrid.Columns["Email"].ReadOnly = true;
                        dgv_Cliente.gvGrid.Columns["Telefono"].ReadOnly = true;
                        dgv_Cliente.gvGrid.Columns["RFC"].ReadOnly = true;
                        dgv_Cliente.gvGrid.Columns["Limite_Credito"].ReadOnly = true;
                        dgv_Cliente.gvGrid.Columns["Dias_Credito"].ReadOnly = true;
                        dgv_Cliente.gvGrid.Columns["No_Cuenta"].ReadOnly = true;
                        dgv_Cliente.gvGrid.Columns["Bloqueo_Cliente"].ReadOnly = true;
                        dgv_Cliente.gvGrid.Columns["Motivo_Bloqueo"].ReadOnly = true;
                        dgv_Cliente.gvGrid.Columns["Exportacion"].ReadOnly = true;
                        dgv_Cliente.gvGrid.Columns["Costo_Factura"].ReadOnly = true;
                        dgv_Cliente.gvGrid.Columns["Descuento"].ReadOnly = true;
                        dgv_Cliente.gvGrid.Columns["Comentarios"].ReadOnly = true;
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

        private void dgv_Cliente_cell_Datagrid_ContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cliente.Frm_Registrar_Pago_Cliente._IdClaveCliente = dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            this.Close();
        }
    }
}
