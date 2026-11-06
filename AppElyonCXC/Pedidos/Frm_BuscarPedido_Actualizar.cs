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
    public partial class Frm_BuscarPedido_Actualizar : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        ElyonModelCxC.mInventario _mInventario = new ElyonModelCxC.mInventario(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        #endregion

        #region Variables 

        int _Id_Producto;
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

        public Frm_BuscarPedido_Actualizar()
        {
            InitializeComponent();
        }

        private void btn_Historial_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_BuscarPedido.DataSource = null;
                _mInventario.intAccion = 1;

                DataSet dsBuscar = _mInventario.dsBusquedaPedido();

                if (dsBuscar != null && dsBuscar.Tables.Count > 0)
                {
                    dgv_BuscarPedido.DataSource = dsBuscar.Tables[0];

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

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            try
            {
                txtFolio.Text = "";
                txtNoPedido.Text = "";
                dtpFecha.Value = DateTime.Now;
                txtNoCliente.Text = "";
                txtCliente.Text = "";
                dgv_BuscarPedido.DataSource = null; 
            }
            catch (Exception ex) { } 
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFolio.Text.ToString() != "" && txtNoPedido.Text.ToString() != "")
                {
                    dgv_BuscarPedido.DataSource = null;
                    _mInventario.intAccion = 3;
                    _mInventario.FolioPedido = txtFolio.Text.ToString();
                    _mInventario.IdPedido = Convert.ToInt32(txtNoPedido.Text.ToString()); 

                    DataSet dsBuscar = _mInventario.dsBusquedaPedido();

                    if (dsBuscar != null && dsBuscar.Tables.Count > 0)
                    {
                        dgv_BuscarPedido.DataSource = dsBuscar.Tables[0];
                        txtCliente.Text = dsBuscar.Tables[0].Rows[0]["Cliente"].ToString();
                        txtNoCliente.Text = dsBuscar.Tables[0].Rows[0]["Id_Cliente"].ToString();
                        dtpFecha.Value = Convert.ToDateTime(dsBuscar.Tables[0].Rows[0]["Fecha_Pedido"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Almacenar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    dgv_BuscarPedido.DataSource = null;
                    _mInventario.intAccion = 2;
                    _mInventario.IdCliente = Convert.ToInt32(txtNoCliente.Text.ToString());

                    DataSet dsBuscar = _mInventario.dsBusquedaPedido();

                    if (dsBuscar != null && dsBuscar.Tables.Count > 0)
                    {
                        dgv_BuscarPedido.DataSource = dsBuscar.Tables[0];
                        txtCliente.Text = dsBuscar.Tables[0].Rows[0]["Cliente"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Almacenar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            Frm_GenerarPedido._NoPedido = Convert.ToInt32(txtNoPedido.Text.ToString());
            Frm_GenerarPedido._FolioPedido = txtFolio.Text.ToString();
            Frm_GenerarPedido._Id_Cliente = txtNoCliente.Text.ToString();
            Frm_GenerarPedido._bActualizar = true; 

            this.Close(); 
        }
    }
}
