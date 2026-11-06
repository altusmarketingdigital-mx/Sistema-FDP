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
    public partial class FrmBuscaEmpresas : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        ElyonModelCxC.mCuentasC _mCuentasC = new ElyonModelCxC.mCuentasC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        #endregion

        #region Variables       
        int intDondeBiene = 0;        
        int _intidApp;
        DataSet dsServ = new DataSet();
        #endregion Variables

        #region constructores
        public FrmBuscaEmpresas()
        {
            InitializeComponent();
        }
        public FrmBuscaEmpresas(int paso, int app)
        {
            InitializeComponent();
            intDondeBiene = paso;
            _intidApp = app;
        }
        #endregion constructores
        private void FrmBuscaEmpresas_Load(object sender, EventArgs e)
        {
            this.Text = "Buscar Empresas";
            CargaGridUsuarios();
        }
        public void CargaGridUsuarios()
        {
            string strNom = "";

            try
            {               
                _mCuentasC.strNombre = strNom.ToUpper();

                dsServ = _mCuentasC.dsBuscarEmpresa();
                if (dsServ.Tables[0].Rows.Count > 0)
                {
                    uctrlGridEmpresa.DataSource = dsServ.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void Biene(string nombres, string RazonSocial, string RFC, string Cve, string ID)
        {
            switch (intDondeBiene)
            {
                case 0: //Mantenimiento de VendedorEmpresaCliente
                    //Administracion.FrmVendedorEmpresaCliente.strIdEmpresa = ID;
                    //Administracion.FrmVendedorEmpresaCliente.strClaveEmpresa = Cve;
                    break;                
            }
        }
        private void BuscaEmpresas(string vchUsuario, string idusu)
        {
            int pasoUsuario = 0;
            string nombres = "";
            string RazonSocial = "";
            string RFC = "";
            int strEstado;

            DataSet dku = new DataSet();

            try
            {
                _mCuentasC.strCodigoCliente = vchUsuario;

                dku = _mCuentasC.dsBuscarEmpresaCodigo();


                strEstado = int.Parse(dku.Tables[0].Rows[0].ItemArray[15].ToString());
                if (strEstado == 1)
                {
                    nombres = dku.Tables[0].Rows[0].ItemArray[2].ToString();
                    RazonSocial = dku.Tables[0].Rows[0].ItemArray[3].ToString();
                    RFC = dku.Tables[0].Rows[0].ItemArray[4].ToString();

                    pasoUsuario = 1;

                    Biene(nombres, RazonSocial, RFC, vchUsuario, idusu);

                }
                else
                {
                    pasoUsuario = 0;
                    MessageBox.Show("Usuario Inactivo", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void uctrlGridEmpresa_cell_Datagrid_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string vchUsuario;
            string idusu;


            vchUsuario = uctrlGridEmpresa.gvGrid.Rows[e.RowIndex].Cells["CODIGO"].Value.ToString();
            idusu = uctrlGridEmpresa.gvGrid.Rows[e.RowIndex].Cells["EmpresaID"].Value.ToString();

            BuscaEmpresas(vchUsuario, idusu);
            this.Close();
        }
    }
}
