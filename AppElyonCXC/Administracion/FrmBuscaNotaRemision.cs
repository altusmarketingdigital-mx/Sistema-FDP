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
    public partial class FrmBuscaNotaRemision : Form
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
        public FrmBuscaNotaRemision()
        {
            InitializeComponent();
        }
        public FrmBuscaNotaRemision(int paso, int app)
        {
            InitializeComponent();
            intDondeBiene = paso;
            _intidApp = app;
        }
        public FrmBuscaNotaRemision(int paso, int app, ElyonModelCxC.mInventario _mInv)
        {
            InitializeComponent();
            intDondeBiene = paso;
            _intidApp = app;
            _mInventario = _mInv;
        }
        #endregion constructores
        private void FrmBuscaNotaRemision_Load(object sender, EventArgs e)
        {
            this.Text = "Buscar Notas de Remision";
            CargaGridUsuarios();
        }
        public void CargaGridUsuarios()
        {
            try
            {                
                dsServ = _mInventario.dsNotasRemisionID();
                if (dsServ.Tables[0].Rows.Count > 0)
                {
                    uctrlGridNotas.DataSource = dsServ.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void uctrlGridNotas_cell_Datagrid_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idNotas;
            
            idNotas = int.Parse(uctrlGridNotas.gvGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString());            

            _mInventario.Id_NotaRemision = idNotas;          
            this.Close();
        }
    }
}
