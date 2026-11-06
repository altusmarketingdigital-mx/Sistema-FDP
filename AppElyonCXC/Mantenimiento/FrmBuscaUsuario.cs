using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppElyonCXC.Mantenimiento
{
    public partial class FrmBuscaUsuario : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        #endregion

        #region Variables
        string strKeyusuaurio = "";
        int intDondeBiene = 0;
        string _strConexion;
        int _intidApp;
        DataSet dsServ = new DataSet();
        #endregion Variables

        #region constructores
        public FrmBuscaUsuario()
        {
            InitializeComponent();
        }
        public FrmBuscaUsuario(int paso, string con, int app)
        {
            InitializeComponent();
            intDondeBiene = paso;
            _strConexion = con;
            _intidApp = app;
        }

        public FrmBuscaUsuario(int paso, string con, int app, ElyonModelCxC.mCxC _mSeg)
        {
            InitializeComponent();
            intDondeBiene = paso;
            _strConexion = con;
            _intidApp = app;
            _mSeguridad = _mSeg;
        }
        #endregion constructores

        private void FrmBuscaUsuario_Load(object sender, EventArgs e)
        {
            this.Text = "Buscar Usuario";            
            CargaGridUsuarios();
        }

        public void CargaGridUsuarios()
        {            
            string strNom = "";

            
            //if (txtNombre.Text == "")
            //{
                //strNom = "";
            //}

            //strNom = txtNombre.Text;

            try
            {
                _mSeguridad.strConexion = _strConexion;
                _mSeguridad.intAplicacion = _intidApp;
                _mSeguridad.strNombreUsuario = strNom.ToUpper();

                dsServ = _mSeguridad.dsBuscarPersonas();
                if (dsServ.Tables[0].Rows.Count > 0)
                {
                    uctrlGridUsuario.DataSource = dsServ.Tables[0];                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

       

        private void Biene(string nombres, string Paterno, string Materno, string CveUsuario, string KeyPersona)
        {
            switch (intDondeBiene)
            {
                case 0: //Mantenimiento de Accesos
                    Mantenimiento.FrmAccesos.strIdUsuario = KeyPersona;
                    Mantenimiento.FrmAccesos.strClaveUsuario = CveUsuario;                   
                    break;                
                case 1: //Mantenimiento de Accesos Grupo
                    Mantenimiento.FrmAccesos.strIdUsuario = KeyPersona;
                    Mantenimiento.FrmAccesos.strClaveUsuario = CveUsuario;
                    break;
                case 2: //Mantenimiento de Parametros
                    //FrmParametros.idusuarioCom = int.Parse(KeyPersona);
                    //FrmParametros.NombreUsuarioCom = nombres + " " + Paterno + " " + Materno;
                    break;
            }
        }

        private void BuscaPersonal(string vchUsuario, string idusu)
        {
            int pasoUsuario = 0;
            string nombres = "";
            string Paterno = "";
            string Materno = "";           
            bool strEstado;
            
            DataSet dku = new DataSet();

            try
            {
                _mSeguridad.strConexion = _strConexion;
                _mSeguridad.intAplicacion = _intidApp;
                _mSeguridad.strUsuario = vchUsuario;

                dku = _mSeguridad.dsInfoUsuarios();
                

                strEstado = bool.Parse(dku.Tables[0].Rows[0].ItemArray[5].ToString());
                if (strEstado)
                {
                    nombres = dku.Tables[0].Rows[0].ItemArray[0].ToString();
                    Paterno = dku.Tables[0].Rows[0].ItemArray[1].ToString();
                    Materno = dku.Tables[0].Rows[0].ItemArray[2].ToString();
                    
                    pasoUsuario = 1;

                    //Biene(nombres, Paterno, Materno, vchUsuario, idusu);
                    _mSeguridad.strUsuario = vchUsuario;
                    _mSeguridad.intIdUsuario = int.Parse(idusu);

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

        private void uctrlGridUsuario_cell_Datagrid_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string vchUsuario;
            string idusu;

           
                vchUsuario = uctrlGridUsuario.gvGrid.Rows[e.RowIndex].Cells["USUARIO"].Value.ToString();
                idusu = uctrlGridUsuario.gvGrid.Rows[e.RowIndex].Cells["UsuarioID"].Value.ToString();

            // BuscaPersonal(vchUsuario, idusu);
                _mSeguridad.strUsuario = vchUsuario;
                _mSeguridad.intIdUsuario = int.Parse(idusu);
            this.Close();
        }
        
    }
}
