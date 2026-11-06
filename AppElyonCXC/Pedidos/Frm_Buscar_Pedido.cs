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
    public partial class Frm_Buscar_Pedido : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        ElyonModelCxC.mInventario _mInventario = new ElyonModelCxC.mInventario(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        #endregion

        public Frm_Buscar_Pedido()
        {
            InitializeComponent();
            CargarHistorialPedidos();
        }

        private void CargarHistorialPedidos()
        {
            try
            {
                _mInventario.intAccionGenerarPedido = 6;
                _mInventario.dtp_FechaVenta = DateTime.Now;
                _mInventario.dtp_FechaVencimientoCredito = DateTime.Now;

                DataSet dsGeneraPedido = _mInventario.dsGenerarPedido();

                if (dsGeneraPedido != null && dsGeneraPedido.Tables.Count > 0)
                {
                    dgv_Historial_Pedido.DataSource = dsGeneraPedido.Tables[0];

                    //COLUMNAS OCULTAS                    
                    dgv_Historial_Pedido.gvGrid.Columns["Id_Forma_Pago"].Visible = false;
                    dgv_Historial_Pedido.gvGrid.Columns["Id_Metodo_Pago"].Visible = false;
                    dgv_Historial_Pedido.gvGrid.Columns["Id_Cliente"].Visible = false;
                    dgv_Historial_Pedido.gvGrid.Columns["Id_Cajero"].Visible = false;
                    dgv_Historial_Pedido.gvGrid.Columns["Folio"].Visible = false;
                    dgv_Historial_Pedido.gvGrid.Columns["Id_Pedido"].Visible = false;
                }
            }
            catch (Exception ex) { }
        }

        private void dgv_Historial_Pedido_cell_Datagrid_ContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string idPedido, folioPedido, cadena;

            cadena = dgv_Historial_Pedido.gvGrid.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            string[] words = cadena.Split(' ');
            
            folioPedido = words[0];
            idPedido = words[1];

            Frm_Convertir_Remision_Pedido.IdPedido = int.Parse(idPedido);
            Frm_Convertir_Remision_Pedido.FolioPedido = folioPedido;
            this.Close();
        }
    }
}
