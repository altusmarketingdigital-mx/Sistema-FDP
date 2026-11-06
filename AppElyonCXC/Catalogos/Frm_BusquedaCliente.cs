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
    public partial class Frm_BusquedaCliente : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        ElyonModelCxC.mInventario _mInventario = new ElyonModelCxC.mInventario(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        #endregion

        #region Variables  
        int _Id_Cliente;
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
        #endregion //Variables

        #region CONSTRUCTORES

        public Frm_BusquedaCliente()
        {
            InitializeComponent();
        }

        public Frm_BusquedaCliente(DataSet dsParam)
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
                _IdPlantelUsuario = dsDatos.Tables["Parametros"].Rows[0]["PLANTEL"].ToString();
                Idmenu = int.Parse(dsDatos.Tables["Parametros"].Rows[0]["IdMenu"].ToString());
                _intIDMenu = _mSeguridad.RegresaPkMenu(_intIdApp, this.Name);
            }
            _mSeguridad.ValidarBotones(this.Controls, UsuarioID, _intIDMenu);
        }

        #endregion CONSTRUCTORES

        private void Frm_BusquedaCliente_Load(object sender, EventArgs e)
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
            Pedidos.Frm_GenerarPedido._ClaveCliente = dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            this.Close();
        }
    }
}
