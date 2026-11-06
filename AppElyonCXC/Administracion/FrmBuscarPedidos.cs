using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppElyonCXC.Administracion
{
    public partial class FrmBuscarPedidos : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        ElyonModelCxC.mCuentasC _mCuentasC = new ElyonModelCxC.mCuentasC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        ElyonModelCxC.mInventario _mInventario = new ElyonModelCxC.mInventario(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        #endregion

        #region Variables        
        int intDondeBiene = 0;
        int _intidApp;
        DataSet dsServ = new DataSet();
        #endregion Variables

        #region constructores
        public FrmBuscarPedidos()
        {
            InitializeComponent();
        }
        public FrmBuscarPedidos(int paso, int app)
        {
            InitializeComponent();
            intDondeBiene = paso;
            _intidApp = app;
        }
        public FrmBuscarPedidos(int paso, int app, ElyonModelCxC.mInventario _mInv)
        {
            InitializeComponent();
            intDondeBiene = paso;
            _intidApp = app;
            _mInventario = _mInv;
        }
        #endregion constructores
        private void FrmBuscarPedidos_Load(object sender, EventArgs e)
        {
            this.Text = "Buscar Pedidos";
            CargaGridUsuarios();
        }
        public void CargaGridUsuarios()
        {           
            try
            {
                dsServ = _mInventario.dsPedidosID();
                if (dsServ.Tables[0].Rows.Count > 0)
                {
                    uctrlGridPedidos.DataSource = dsServ.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void uctrlGridPedidos_cell_Datagrid_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idPedido;
            string vchNombre;


            idPedido = int.Parse(uctrlGridPedidos.gvGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            vchNombre = uctrlGridPedidos.gvGrid.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            
            _mInventario.Id_Pedidos = idPedido;
            _mInventario.strNombre = vchNombre;
            this.Close();
        }
    }
}
