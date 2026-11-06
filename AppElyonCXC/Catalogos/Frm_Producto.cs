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
    public partial class Frm_Producto : Form
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

        #region CONSTRUCTORES

        public Frm_Producto()
        {
            InitializeComponent();
        }

        public Frm_Producto(DataSet dsParam)
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

            CargarGrupo();
            CargarDepartamento();
        }
        #endregion CONSTRUCTORES

        private void CargarGrupo()
        {
            try
            {
                _mInventario.intValor1 = 1;
                DataSet dsGrupo = _mInventario.dsCargarCombo();

                if (dsGrupo.Tables[0].Rows.Count > 0)
                {
                    //Inserta Registro en Blanco
                    dsGrupo.Tables[0].Rows.InsertAt(dsGrupo.Tables[0].NewRow(), 0);

                    cmbGrupo.DataSource = dsGrupo.Tables[0].DefaultView;
                    cmbGrupo.ValueMember = "Id";
                    cmbGrupo.DisplayMember = "Grupo";
                }
                else
                {
                    //MessageBox.Show("No hay datos a cargar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void CargarDepartamento()
        {
            try
            {
                _mInventario.intValor1 = 2;
                DataSet dsDepartamento = _mInventario.dsCargarCombo();

                if (dsDepartamento.Tables[0].Rows.Count > 0)
                {
                    //Inserta Registro en Blanco
                    dsDepartamento.Tables[0].Rows.InsertAt(dsDepartamento.Tables[0].NewRow(), 0);

                    cmbDepartamento.DataSource = dsDepartamento.Tables[0].DefaultView;
                    cmbDepartamento.ValueMember = "Id";
                    cmbDepartamento.DisplayMember = "Departamento";
                }
                else
                {
                    //MessageBox.Show("No hay datos a cargar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad != "1")
            {
                try
                {
                    if (txtNombre.Text.Trim() != "")
                    {
                        _mInventario.Id_Producto = _Id_Producto;
                        _mInventario.vchClaveProducto = txt_ClaveProducto.Text.Trim().ToString();
                        _mInventario.vchNombre = txtNombre.Text.Trim().ToString(); 
                        _mInventario.vchLocalizacion = txt_Localizacion.Text.Trim().ToString();
                        _mInventario.bitArticuloConDecimal = chb_Decimales.Checked; 
                        _mInventario.UM_Compra = txt_UM_Compra.Text.Trim().ToString();
                        _mInventario.UM_Venta = txt_UM_Venta.Text.Trim().ToString();
                        _mInventario.vchContenido = txt_Contenido.Text.Trim().ToString();
                        _mInventario.intClaveGrupo = Convert.ToInt32(cmbGrupo.SelectedValue.ToString()); 
                        _mInventario.intClaveDepartamento = Convert.ToInt32(cmbDepartamento.SelectedValue.ToString());
                        _mInventario.vchInventarioMinimo = txt_InvMinimo.Text.Trim().ToString(); 
                        _mInventario.vchInventarioMaximo = txt_InvMaximo.Text.Trim().ToString();
                        _mInventario.bitProductoExento = chb_Producto_Excento.Checked;
                        _mInventario.fltIEPS = float.Parse(txt_IEPS.Text.Trim().ToString()); 
                        _mInventario.fltIVA = float.Parse(txt_IVA.Text.Trim().ToString());
                        _mInventario.fltPrecioCompra = float.Parse(txt_Precio_Compra.Text.Trim().ToString());
                        _mInventario.ftl_MargenUtilidad_1 = float.Parse(txt_Mrg_Utilidad_1.Text.Trim().ToString());
                        _mInventario.flt_PrecioVenta_1 = float.Parse(txt_Precio_Venta_1.Text.Trim().ToString());
                        _mInventario.ftl_MargenUtilidad_2 = float.Parse(txt_Mrg_Utilidad_2.Text.Trim().ToString());
                        _mInventario.flt_PrecioVenta_2 = float.Parse(txt_Precio_Venta_2.Text.Trim().ToString());
                        _mInventario.ftl_MargenUtilidad_3 = float.Parse(txt_Mrg_Utilidad_3.Text.Trim().ToString());
                        _mInventario.flt_PrecioVenta_3 = float.Parse(txt_Precio_Venta_3.Text.Trim().ToString());
                        _mInventario.Clave_Unidad_Medida = txt_Clave_Und_Med.Text.Trim().ToString(); 
                        _mInventario.Clave_ProdServicio = txt_Clave_Prod_Serv.Text.Trim().ToString();
                        _mInventario.intAccionProducto = 1;

                        DataSet dsProducto = _mInventario.dsCatalogoProducto();

                        if (Convert.ToInt32(dsProducto.Tables[0].Rows[0]["respuesta"].ToString()) == 0)
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
            UcSplashScreen cargando = new UcSplashScreen("", "... Cargando Información de Productos ... ");
            cargando.Show();
            cargando.Refresh();

            Frm_Historial_Productos historial = new Frm_Historial_Productos();
            historial.ShowDialog();

            cargando.Close();

            //if (NivelSeguridad != "1")
            //{
            //    try
            //    {
            //        dgv_Producto.DataSource = null;
            //        _mInventario.intAccionProducto = 4;

            //        DataSet dsProducto = _mInventario.dsCatalogoProducto();

            //        if (dsProducto != null && dsProducto.Tables.Count > 0)
            //        {
            //            dgv_Producto.DataSource = dsProducto.Tables[0];

            //            //COLUMNAS OCULTAS                    
            //            //dgv_Producto.gvGrid.Columns["Id"].ReadOnly = true;
            //            //dgv_Producto.gvGrid.Columns["Grupo"].ReadOnly = true;
            //        }
            //        else
            //        {
            //            MessageBox.Show("No se pudo Almacenar Registro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("NO estas Autorizado para Consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad != "1")
            {
                try
                {
                    if (txtNombre.Text.Trim() != "" && txt_ClaveProducto.Text.Trim() != "")
                    {
                        _mInventario.Id_Producto = _Id_Producto;
                        _mInventario.intAccionProducto = 3;

                        DataSet dsProducto = _mInventario.dsCatalogoProducto();

                        if (Convert.ToInt32(dsProducto.Tables[0].Rows[0]["respuesta"].ToString()) == 0)
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
                _Id_Producto = 0;
                txtNombre.Text = ""; 
                txt_Localizacion.Text = "";
                chb_Decimales.Checked = false; 
                txt_UM_Compra.Text = "";
                txt_UM_Venta.Text = "";
                txt_Contenido.Text = "";
                cmbGrupo.SelectedItem = -1; 
                cmbDepartamento.SelectedItem = -1;
                txt_InvMinimo.Text = "";
                txt_InvMaximo.Text = "";
                chb_Producto_Excento.Checked = false; 
                txt_IEPS.Text = "";
                txt_IVA.Text = "";
                txt_Precio_Compra.Text = "";
                txt_Mrg_Utilidad_1.Text = "";
                txt_Precio_Venta_1.Text = "";
                txt_Mrg_Utilidad_2.Text = "";
                txt_Precio_Venta_2.Text = "";
                txt_Mrg_Utilidad_3.Text = "";
                txt_Precio_Venta_3.Text = "";
                txt_Clave_Und_Med.Text = "";
                txt_Clave_Prod_Serv.Text = "";

                //dgv_Producto.DataSource = null;
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
                    if (txtNombre.Text.Trim() != "" && txt_Localizacion.Text.Trim() != "") 
                    {
                        _mInventario.Id_Producto = _Id_Producto;
                        _mInventario.vchNombre = txtNombre.Text.Trim().ToString();
                        _mInventario.vchLocalizacion = txt_Localizacion.Text.Trim().ToString();
                        _mInventario.bitArticuloConDecimal = chb_Decimales.Checked;
                        _mInventario.UM_Compra = txt_UM_Compra.Text.Trim().ToString();
                        _mInventario.UM_Venta = txt_UM_Venta.Text.Trim().ToString();
                        _mInventario.vchContenido = txt_Contenido.Text.Trim().ToString();
                        _mInventario.intClaveGrupo = Convert.ToInt32(cmbGrupo.SelectedValue.ToString());
                        _mInventario.intClaveDepartamento = Convert.ToInt32(cmbDepartamento.SelectedValue.ToString());
                        _mInventario.vchInventarioMinimo = txt_InvMinimo.Text.Trim().ToString();
                        _mInventario.vchInventarioMaximo = txt_InvMaximo.Text.Trim().ToString();
                        _mInventario.bitProductoExento = chb_Producto_Excento.Checked;
                        _mInventario.fltIEPS = float.Parse(txt_IEPS.Text.Trim().ToString());
                        _mInventario.fltIVA = float.Parse(txt_IVA.Text.Trim().ToString());
                        _mInventario.fltPrecioCompra = float.Parse(txt_Precio_Compra.Text.Trim().ToString());
                        _mInventario.ftl_MargenUtilidad_1 = float.Parse(txt_Mrg_Utilidad_1.Text.Trim().ToString());
                        _mInventario.flt_PrecioVenta_1 = float.Parse(txt_Precio_Venta_1.Text.Trim().ToString());
                        _mInventario.ftl_MargenUtilidad_2 = float.Parse(txt_Mrg_Utilidad_2.Text.Trim().ToString());
                        _mInventario.flt_PrecioVenta_2 = float.Parse(txt_Precio_Venta_2.Text.Trim().ToString());
                        _mInventario.ftl_MargenUtilidad_3 = float.Parse(txt_Mrg_Utilidad_3.Text.Trim().ToString());
                        _mInventario.flt_PrecioVenta_3 = float.Parse(txt_Precio_Venta_3.Text.Trim().ToString());
                        _mInventario.Clave_Unidad_Medida = txt_Clave_Und_Med.Text.Trim().ToString();
                        _mInventario.Clave_ProdServicio = txt_Clave_Prod_Serv.Text.Trim().ToString();
                        _mInventario.intAccionProducto = 2;

                        DataSet dsProveedor = _mInventario.dsCatalogoProducto();

                        if (Convert.ToInt32(dsProveedor.Tables[0].Rows[0]["respuesta"].ToString()) == 0)
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

        private void dgv_Producto_cell_Datagrid_ContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    _Id_Producto = Convert.ToInt32(dgv_Producto.gvGrid.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            //    txt_ClaveProducto.Text = _Id_Producto.ToString();
            //    txtNombre.Text = dgv_Producto.gvGrid.Rows[e.RowIndex].Cells["Producto"].Value.ToString();
            //    txt_Localizacion.Text = dgv_Producto.gvGrid.Rows[e.RowIndex].Cells["Localizacion"].Value.ToString();
            //    chb_Decimales.Checked = Convert.ToBoolean(dgv_Producto.gvGrid.Rows[e.RowIndex].Cells["Tiene_Decimal"].Value.ToString());
            //    txt_UM_Compra.Text = dgv_Producto.gvGrid.Rows[e.RowIndex].Cells["UM_Compra"].Value.ToString();
            //    txt_UM_Venta.Text = dgv_Producto.gvGrid.Rows[e.RowIndex].Cells["UM_Venta"].Value.ToString();
            //    txt_Contenido.Text = dgv_Producto.gvGrid.Rows[e.RowIndex].Cells["Contenido"].Value.ToString();
            //    cmbGrupo.SelectedValue = dgv_Producto.gvGrid.Rows[e.RowIndex].Cells["Clave_Grupo"].Value.ToString();
            //    cmbDepartamento.SelectedValue = dgv_Producto.gvGrid.Rows[e.RowIndex].Cells["Clave_Departamento"].Value.ToString();
            //    txt_InvMinimo.Text = dgv_Producto.gvGrid.Rows[e.RowIndex].Cells["Inventario_Minimo"].Value.ToString();
            //    txt_InvMaximo.Text = dgv_Producto.gvGrid.Rows[e.RowIndex].Cells["Inventario_Maximo"].Value.ToString();
            //    chb_Producto_Excento.Checked = Convert.ToBoolean(dgv_Producto.gvGrid.Rows[e.RowIndex].Cells["Producto_Excento"].Value.ToString());
            //    txt_IEPS.Text = dgv_Producto.gvGrid.Rows[e.RowIndex].Cells["IEPS"].Value.ToString();
            //    txt_IVA.Text = dgv_Producto.gvGrid.Rows[e.RowIndex].Cells["IVA"].Value.ToString();
            //    txt_Precio_Compra.Text = dgv_Producto.gvGrid.Rows[e.RowIndex].Cells["Precio_Compra"].Value.ToString();
            //    txt_Mrg_Utilidad_1.Text = dgv_Producto.gvGrid.Rows[e.RowIndex].Cells["Margen_Utilidad_1"].Value.ToString();
            //    txt_Precio_Venta_1.Text = dgv_Producto.gvGrid.Rows[e.RowIndex].Cells["Precio_Venta_1"].Value.ToString();
            //    txt_Mrg_Utilidad_2.Text = dgv_Producto.gvGrid.Rows[e.RowIndex].Cells["Margen_Utilidad_2"].Value.ToString();
            //    txt_Precio_Venta_2.Text = dgv_Producto.gvGrid.Rows[e.RowIndex].Cells["Precio_Venta_2"].Value.ToString();
            //    txt_Mrg_Utilidad_3.Text = dgv_Producto.gvGrid.Rows[e.RowIndex].Cells["Margen_Utilidad_3"].Value.ToString();
            //    txt_Precio_Venta_3.Text = dgv_Producto.gvGrid.Rows[e.RowIndex].Cells["Precio_Venta_3"].Value.ToString();
            //    txt_Clave_Und_Med.Text = dgv_Producto.gvGrid.Rows[e.RowIndex].Cells["Clave_Unidad_Medida"].Value.ToString();
            //    txt_Clave_Prod_Serv.Text = dgv_Producto.gvGrid.Rows[e.RowIndex].Cells["Clave_Prod_Servicio"].Value.ToString();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void dgv_Producto_Load(object sender, EventArgs e)
        {

        }

        private void btnArchivo_Click(object sender, EventArgs e)
        {
            Frm_CargaMasiva_Productos carga = new Frm_CargaMasiva_Productos();
            carga.ShowDialog();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                _mInventario.intAccionProducto = 8;
                _mInventario.vchClaveProducto = txt_ClaveProducto.Text.Trim().ToString();

                DataSet dsProductos = _mInventario.dsCatalogoProducto();

                if (dsProductos.Tables[0].Rows.Count > 0)
                {
                    //txtCampus.Text = dsObtenerInfo.Tables[0].Rows[0]["Campus"].ToString();

                    _Id_Producto = Convert.ToInt32(dsProductos.Tables[0].Rows[0]["Id"].ToString());
                    txtNombre.Text = dsProductos.Tables[0].Rows[0]["Producto"].ToString();
                    txt_Localizacion.Text = dsProductos.Tables[0].Rows[0]["Localizacion"].ToString();
                    chb_Decimales.Checked = Convert.ToBoolean(dsProductos.Tables[0].Rows[0]["Tiene_Decimal"].ToString());
                    txt_UM_Compra.Text = dsProductos.Tables[0].Rows[0]["UM_Compra"].ToString();
                    txt_UM_Venta.Text = dsProductos.Tables[0].Rows[0]["UM_Venta"].ToString();
                    txt_Contenido.Text = dsProductos.Tables[0].Rows[0]["Contenido"].ToString();
                    cmbGrupo.SelectedValue = dsProductos.Tables[0].Rows[0]["Clave_Grupo"].ToString();
                    cmbDepartamento.SelectedValue = dsProductos.Tables[0].Rows[0]["Clave_Departamento"].ToString();
                    txt_InvMinimo.Text = dsProductos.Tables[0].Rows[0]["Inventario_Minimo"].ToString();
                    txt_InvMaximo.Text = dsProductos.Tables[0].Rows[0]["Inventario_Maximo"].ToString();
                    chb_Producto_Excento.Checked = Convert.ToBoolean(dsProductos.Tables[0].Rows[0]["Producto_Excento"].ToString());
                    txt_IEPS.Text = dsProductos.Tables[0].Rows[0]["IEPS"].ToString();
                    txt_IVA.Text = dsProductos.Tables[0].Rows[0]["IVA"].ToString();
                    txt_Precio_Compra.Text = dsProductos.Tables[0].Rows[0]["Precio_Compra"].ToString();
                    txt_Mrg_Utilidad_1.Text = dsProductos.Tables[0].Rows[0]["Margen_Utilidad_1"].ToString();
                    txt_Precio_Venta_1.Text = dsProductos.Tables[0].Rows[0]["Precio_Venta_1"].ToString();
                    txt_Mrg_Utilidad_2.Text = dsProductos.Tables[0].Rows[0]["Margen_Utilidad_2"].ToString();
                    txt_Precio_Venta_2.Text = dsProductos.Tables[0].Rows[0]["Precio_Venta_2"].ToString();
                    txt_Mrg_Utilidad_3.Text = dsProductos.Tables[0].Rows[0]["Margen_Utilidad_3"].ToString();
                    txt_Precio_Venta_3.Text = dsProductos.Tables[0].Rows[0]["Precio_Venta_3"].ToString();
                    txt_Clave_Und_Med.Text = dsProductos.Tables[0].Rows[0]["Clave_Unidad_Medida"].ToString();
                    txt_Clave_Prod_Serv.Text = dsProductos.Tables[0].Rows[0]["Clave_Prod_Servicio"].ToString();
                }
            }
            catch (Exception ex) { }
        }

        private void btnAgregarUnidad_Click(object sender, EventArgs e)
        {

        }
    }
}
