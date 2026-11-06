using AppElyonCXC.Mantenimiento;
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
    public partial class Frm_Historial_Productos : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        ElyonModelCxC.mInventario _mInventario = new ElyonModelCxC.mInventario(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        #endregion

        public Frm_Historial_Productos()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void CargarProductos()
        {
           
            try
            {
                dgv_Productos.DataSource = null;
                _mInventario.intAccionProducto = 4;

                DataSet dsProducto = _mInventario.dsCatalogoProducto();

                if (dsProducto != null && dsProducto.Tables.Count > 0)
                {
                    dgv_Productos.DataSource = dsProducto.Tables[0];

                    //COLUMNAS OCULTAS                    
                    //dgv_Producto.gvGrid.Columns["Id"].ReadOnly = true;
                    //dgv_Producto.gvGrid.Columns["Grupo"].ReadOnly = true;
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

        private void dgv_Productos_cell_Datagrid_ContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
