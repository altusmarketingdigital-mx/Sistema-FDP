using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppElyonCXC.Inventario
{
    public partial class FrmRegistroInventarioProducto : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        ElyonModelCxC.mInventario _mInventario = new ElyonModelCxC.mInventario(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        #endregion

        #region Variables  
        int _Id_Inventario_Inicial;
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

        public FrmRegistroInventarioProducto()
        {
            InitializeComponent();
        }

        public FrmRegistroInventarioProducto(DataSet dsParam)
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

        private void BuscarProducto()
        {
            try
            {
                _mInventario.Id_Producto = Convert.ToInt32(txt_ClaveProducto.Text.Trim().ToString());
                _mInventario.intAccionProducto = 6;

                DataSet dsProducto = _mInventario.dsCatalogoProducto();

                if (dsProducto != null && dsProducto.Tables.Count > 0)
                {
                    txtNombre.Text = dsProducto.Tables[0].Rows[0]["Producto"].ToString().Trim();
                    txt_Contenido.Text = dsProducto.Tables[0].Rows[0]["Contenido"].ToString().Trim();
                    txt_PrecioCompra.Text = dsProducto.Tables[0].Rows[0]["Precio_Compra"].ToString().Trim();
                    chb_Decimales.Checked = Convert.ToBoolean(dsProducto.Tables[0].Rows[0]["Tiene_Decimal"].ToString().Trim());
                }

            }
            catch (Exception ex) { }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad != "1")
            {
                try
                {
                    if (txtNombre.Text.Trim() != "")
                    {
                        _mInventario.Id_Inventario = _Id_Inventario_Inicial;
                        _mInventario.Id_ClaveProducto = Convert.ToInt32(txt_ClaveProducto.Text.Trim().ToString());
                        _mInventario.intUnidadesCompra_Fisco = Convert.ToInt32(txt_UnidadCompra.Text.Trim().ToString()); 
                        _mInventario.intUnidadesVenta_Fisco = Convert.ToInt32(txt_UnidadVenta.Text.Trim().ToString());
                        _mInventario.intUnidadesVenta_InicialCalculado = Convert.ToInt32(txt_UnidadVenta_Calculado.Text.Trim().ToString());
                        _mInventario.flt_Importa = float.Parse(txt_Importe.Text.Trim().ToString()); 
                        _mInventario.intAccion_Inventario_Inicial = 1;

                        DataSet dsInventario_Inicial = _mInventario.dsRegistroInventarioInicial();

                        if (Convert.ToInt32(dsInventario_Inicial.Tables[0].Rows[0]["respuesta"].ToString()) == 0)
                        {
                            MessageBox.Show("Registro Almacenado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLimpiar_Click(null, null);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Almacenar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else
                    {
                        MessageBox.Show("No puede guardar campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("NO estas Autorizado para Registrar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad != "1")
            {
                try
                {
                    dgv_Inventario_Inicial.DataSource = null;
                    _mInventario.intAccion_Inventario_Inicial = 4;

                    DataSet dsInventario_Inicial = _mInventario.dsRegistroInventarioInicial();

                    if (dsInventario_Inicial != null && dsInventario_Inicial.Tables.Count > 0)
                    {
                        dgv_Inventario_Inicial.DataSource = dsInventario_Inicial.Tables[0];

                        //COLUMNAS OCULTAS                    
                        dgv_Inventario_Inicial.gvGrid.Columns["Id"].ReadOnly = true;
                        dgv_Inventario_Inicial.gvGrid.Columns["Clave"].ReadOnly = true;
                        dgv_Inventario_Inicial.gvGrid.Columns["Unidad_Compra_Fisico"].ReadOnly = true;
                        dgv_Inventario_Inicial.gvGrid.Columns["Unidad_Venta_Fisico"].ReadOnly = true;
                        dgv_Inventario_Inicial.gvGrid.Columns["Unidad_Venta_Inicial_Calculado"].ReadOnly = true;
                        dgv_Inventario_Inicial.gvGrid.Columns["Importe"].ReadOnly = true;
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad != "1")
            {
                try
                {
                    if (txtNombre.Text.Trim() != "" && txt_ClaveProducto.Text.Trim() != "")
                    {
                        _mInventario.Id_Inventario = _Id_Inventario_Inicial;
                        _mInventario.intAccion_Inventario_Inicial = 3;

                        DataSet dsInventario_Inicial = _mInventario.dsRegistroInventarioInicial();

                        if (Convert.ToInt32(dsInventario_Inicial.Tables[0].Rows[0]["respuesta"].ToString()) == 0)
                        {
                            MessageBox.Show("Registro Eliminado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLimpiar_Click(null, null);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Eliminado Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else
                    {
                        MessageBox.Show("No puede eliminar campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("NO estas Autorizado para Eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                _Id_Inventario_Inicial = 0;
                txtNombre.Text = "";
                txt_Contenido.Text = "";
                chb_Decimales.Checked = false;
                txt_ClaveProducto.Text = "";
                txt_UnidadCompra.Text = "";
                txt_UnidadVenta.Text = "";
                txt_PrecioCompra.Text = ""; 
                txt_UnidadVenta_Calculado.Text = "";
                txt_Importe.Text = ""; 

                dgv_Inventario_Inicial.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad != "1")
            {
                try
                {
                    if (txtNombre.Text.Trim() != "" && txt_Contenido.Text.Trim() != "")
                    {
                        _mInventario.Id_Inventario = _Id_Inventario_Inicial;
                        _mInventario.Id_ClaveProducto = Convert.ToInt32(txt_ClaveProducto.Text.Trim().ToString());
                        _mInventario.intUnidadesCompra_Fisco = Convert.ToInt32(txt_UnidadCompra.Text.Trim().ToString());
                        _mInventario.intUnidadesVenta_Fisco = Convert.ToInt32(txt_UnidadVenta.Text.Trim().ToString());
                        _mInventario.intUnidadesVenta_InicialCalculado = Convert.ToInt32(txt_UnidadVenta_Calculado.Text.Trim().ToString());
                        _mInventario.flt_Importa = float.Parse(txt_Importe.Text.Trim().ToString());
                        _mInventario.intAccion_Inventario_Inicial = 2;

                        DataSet dsInventario_Inicial = _mInventario.dsRegistroInventarioInicial();

                        if (Convert.ToInt32(dsInventario_Inicial.Tables[0].Rows[0]["respuesta"].ToString()) == 0)
                        {
                            MessageBox.Show("Registro Actualizado con Exito", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLimpiar_Click(null, null);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Actualizar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else
                    {
                        MessageBox.Show("No puede actualizar campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("NO estas Autorizado para Actualizar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_ClaveProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                BuscarProducto();
            }
        }

        private void dgv_Inventario_Inicial_cell_Datagrid_ContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _Id_Inventario_Inicial = Convert.ToInt32(dgv_Inventario_Inicial.gvGrid.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                txt_ClaveProducto.Text = dgv_Inventario_Inicial.gvGrid.Rows[e.RowIndex].Cells["Clave"].Value.ToString();
                BuscarProducto();
                txt_UnidadCompra.Text = dgv_Inventario_Inicial.gvGrid.Rows[e.RowIndex].Cells["Unidad_Compra_Fisico"].Value.ToString();
                txt_UnidadVenta.Text = dgv_Inventario_Inicial.gvGrid.Rows[e.RowIndex].Cells["Unidad_Venta_Fisico"].Value.ToString();
                txt_UnidadVenta_Calculado.Text = dgv_Inventario_Inicial.gvGrid.Rows[e.RowIndex].Cells["Unidad_Venta_Inicial_Calculado"].Value.ToString();
                txt_Importe.Text = dgv_Inventario_Inicial.gvGrid.Rows[e.RowIndex].Cells["Importe"].Value.ToString();
            }
            catch (Exception ex) { }
        }
    }
}
