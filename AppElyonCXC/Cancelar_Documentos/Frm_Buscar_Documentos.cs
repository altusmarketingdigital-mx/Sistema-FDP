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
    public partial class Frm_Buscar_Documentos : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        ElyonModelCxC.mInventario _mInventario = new ElyonModelCxC.mInventario(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        #endregion

        public Frm_Buscar_Documentos()
        {
            InitializeComponent();
            CargarHistorialDocumentos();
        }

        private void CargarHistorialDocumentos()
        {
            try
            {
                _mInventario.intAccionNotaRemision = 8;
                _mInventario.Fecha_Nota_Remision = DateTime.Now;

                DataSet dsGeneraPedido = _mInventario.dsRegistroNotaRemision();

                if (dsGeneraPedido != null && dsGeneraPedido.Tables.Count > 0)
                {
                    dgv_Documentos.DataSource = dsGeneraPedido.Tables[0];
                }
            }
            catch (Exception ex) { }
        }

        private void dgv_Documentos_cell_Datagrid_ContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Frm_Cancelar_Nota_Remision.Id_Nota_Remision = Convert.ToInt32(dgv_Documentos.gvGrid.Rows[e.RowIndex].Cells["No_Nota"].Value.ToString());
            this.Close();
        }
    }
}
