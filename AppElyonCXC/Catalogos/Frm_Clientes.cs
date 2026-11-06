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
    public partial class Frm_Clientes : Form
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

        public Frm_Clientes()
        {
            InitializeComponent();
        }

        public Frm_Clientes(DataSet dsParam)
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

            CargaPrecioFactura(cmb_CostoFactura, "Precio Factura");
        }

        #endregion CONSTRUCTORES

        private void CargaPrecioFactura(ComboBox Precio, String strTipoCombo)
        {
            try
            {
                DataTable dtSexo = new DataTable();
                DataColumn dcSexo;
                DataRow drSexo;

                dcSexo = new DataColumn();
                dcSexo.DataType = Type.GetType("System.String");
                dcSexo.ColumnName = "Id";
                dtSexo.Columns.Add(dcSexo);

                dcSexo = new DataColumn();
                dcSexo.DataType = Type.GetType("System.String");
                dcSexo.ColumnName = "Descr";
                dtSexo.Columns.Add(dcSexo);

                drSexo = dtSexo.NewRow();
                drSexo[0] = "1";
                drSexo[1] = "Precio Venta 1";
                dtSexo.Rows.Add(drSexo);

                drSexo = dtSexo.NewRow();
                drSexo[0] = "2";
                drSexo[1] = "Precio Venta 2";
                dtSexo.Rows.Add(drSexo);

                drSexo = dtSexo.NewRow();
                drSexo[0] = "3";
                drSexo[1] = "Precio Venta 3";
                dtSexo.Rows.Add(drSexo);

                Precio.ValueMember = "Id";
                Precio.DisplayMember = "Descr";
                dtSexo.Rows.InsertAt(dtSexo.NewRow(), 0);
                Precio.DataSource = dtSexo;
            }
            catch
            {
                //_bolErrorCargadoCombos = true;
                //_strCombosNoCargados += "\n-Sexo de " + strTipoCombo + ".";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (NivelSeguridad != "1")
            {
                try
                {
                    if (txtNombreCliente.Text.Trim() != "")
                    {
                        _mInventario.Id_Cliente = _Id_Cliente;
                        _mInventario.vchNombreCliente = txtNombreCliente.Text.Trim().ToString();
                        _mInventario.vchCalle = txt_Calle.Text.Trim().ToString();
                        _mInventario.vchNoExterior = txt_NoExt.Text.Trim().ToString();
                        _mInventario.vchNoInterior = txt_NoInt.Text.Trim().ToString();
                        _mInventario.vchColonia = txt_Colonia.Text.Trim().ToString();
                        _mInventario.vchCiudad = txt_Ciudad.Text.Trim().ToString();
                        _mInventario.vchCodigoPostal = txt_CodigoPostal.Text.Trim().ToString();
                        _mInventario.vchMunicipio = txt_Municipio.Text.Trim().ToString();
                        _mInventario.vchEstado = txt_Estado.Text.Trim().ToString();
                        _mInventario.vchPais = txt_Pais.Text.Trim().ToString();
                        _mInventario.vchEmail = txt_Email.Text.Trim().ToString();
                        _mInventario.vchTelefono = txt_Telefono.Text.Trim().ToString();
                        _mInventario.vchRFC = txt_RFC.Text.Trim().ToString();
                        _mInventario.vchLimiteCredito = txt_LimiteCredito.Text.Trim().ToString();
                        _mInventario.intDiasCredito = Convert.ToInt32(txt_DiasCredito.Text.Trim().ToString());
                        _mInventario.vchNoCuenta = txt_NoCuenta.Text.Trim().ToString();
                        _mInventario.bBloqueoCliente = chb_BloqueoCliente.Checked;
                        _mInventario.vchMotivoBloqueo = txt_MotivoBloqueo.Text.Trim().ToString();
                        _mInventario.bClienteExportacion = chb_ClienteExportacion.Checked;
                        _mInventario.intCostoFactuacion = Convert.ToInt32(cmb_CostoFactura.SelectedValue.ToString());
                        _mInventario.flDescuento = float.Parse(txt_Descuento.Text.Trim().ToString());
                        _mInventario.vchComentarios = txt_Comentarios.Text.Trim().ToString();
                        _mInventario.intAccionCliente = 1;

                        DataSet dsCliente = _mInventario.dsCatalogoClientes();

                        if (Convert.ToInt32(dsCliente.Tables[0].Rows[0]["respuesta"].ToString()) == 0)
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
            UcSplashScreen cargando = new UcSplashScreen("", "... Cargando Información de Clientes ... ");
            cargando.Show();
            cargando.Refresh();

            Frm_Historial_Clientes historial = new Frm_Historial_Clientes();
            historial.ShowDialog();

            cargando.Close();

            //if (NivelSeguridad != "1")
            //{
            //    try
            //    {
            //        dgv_Cliente.DataSource = null;
            //        _mInventario.intAccionCliente = 4;

            //        DataSet dsCliente = _mInventario.dsCatalogoClientes();

            //        if (dsCliente != null && dsCliente.Tables.Count > 0)
            //        {
            //            dgv_Cliente.DataSource = dsCliente.Tables[0];

            //            //COLUMNAS OCULTAS                    
            //            dgv_Cliente.gvGrid.Columns["Id"].ReadOnly = true;
            //            dgv_Cliente.gvGrid.Columns["Nombre"].ReadOnly = true;
            //            dgv_Cliente.gvGrid.Columns["Calle"].ReadOnly = true;
            //            dgv_Cliente.gvGrid.Columns["No_Exterior"].ReadOnly = true;
            //            dgv_Cliente.gvGrid.Columns["No_Interior"].ReadOnly = true;
            //            dgv_Cliente.gvGrid.Columns["Colonia"].ReadOnly = true;
            //            dgv_Cliente.gvGrid.Columns["Ciudad"].ReadOnly = true;
            //            dgv_Cliente.gvGrid.Columns["Codigo_Postal"].ReadOnly = true;
            //            dgv_Cliente.gvGrid.Columns["Municipio"].ReadOnly = true;
            //            dgv_Cliente.gvGrid.Columns["Estado"].ReadOnly = true;
            //            dgv_Cliente.gvGrid.Columns["Pais"].ReadOnly = true;
            //            dgv_Cliente.gvGrid.Columns["Email"].ReadOnly = true;
            //            dgv_Cliente.gvGrid.Columns["Telefono"].ReadOnly = true;
            //            dgv_Cliente.gvGrid.Columns["RFC"].ReadOnly = true;
            //            dgv_Cliente.gvGrid.Columns["Limite_Credito"].ReadOnly = true;
            //            dgv_Cliente.gvGrid.Columns["Dias_Credito"].ReadOnly = true;
            //            dgv_Cliente.gvGrid.Columns["No_Cuenta"].ReadOnly = true;
            //            dgv_Cliente.gvGrid.Columns["Bloqueo_Cliente"].ReadOnly = true;
            //            dgv_Cliente.gvGrid.Columns["Motivo_Bloqueo"].ReadOnly = true;
            //            dgv_Cliente.gvGrid.Columns["Exportacion"].ReadOnly = true;
            //            dgv_Cliente.gvGrid.Columns["Costo_Factura"].ReadOnly = true;
            //            dgv_Cliente.gvGrid.Columns["Descuento"].ReadOnly = true;
            //            dgv_Cliente.gvGrid.Columns["Comentarios"].ReadOnly = true;
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
                    if (txtNombreCliente.Text.Trim() != "" && txt_ClaveCliente.Text.Trim() != "")
                    {
                        _mInventario.Id_Cliente = _Id_Cliente;
                        _mInventario.intAccionCliente = 3;

                        DataSet dsCliente = _mInventario.dsCatalogoClientes();

                        if (Convert.ToInt32(dsCliente.Tables[0].Rows[0]["respuesta"].ToString()) == 0)
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
                _Id_Cliente = 0;
                txtNombreCliente.Text = "";
                txt_Calle.Text = "";
                txt_NoExt.Text = "";
                txt_NoInt.Text = "";
                txt_Colonia.Text = "";
                txt_Ciudad.Text = "";
                txt_CodigoPostal.Text = "";
                txt_Municipio.Text = "";
                txt_Estado.Text = "";
                txt_Pais.Text = "";
                txt_Email.Text = "";
                txt_Telefono.Text = "";
                txt_RFC.Text = "";
                txt_LimiteCredito.Text = "";
                txt_DiasCredito.Text = "";
                txt_NoCuenta.Text = "";
                chb_BloqueoCliente.Checked = false;
                txt_MotivoBloqueo.Text = "";
                chb_ClienteExportacion.Checked = false;
                cmb_CostoFactura.SelectedIndex = -1;
                txt_Descuento.Text = "";
                txt_Comentarios.Text = "";
                dgv_Cliente.DataSource = null;
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
                    if (txtNombreCliente.Text.Trim() != "" && txt_ClaveCliente.Text.Trim() != "")
                    {
                        _mInventario.Id_Cliente = _Id_Cliente;
                        _mInventario.vchNombreCliente = txtNombreCliente.Text.Trim().ToString();
                        _mInventario.vchCalle = txt_Calle.Text.Trim().ToString();
                        _mInventario.vchNoExterior = txt_NoExt.Text.Trim().ToString();
                        _mInventario.vchNoInterior = txt_NoInt.Text.Trim().ToString();
                        _mInventario.vchColonia = txt_Colonia.Text.Trim().ToString();
                        _mInventario.vchCiudad = txt_Ciudad.Text.Trim().ToString();
                        _mInventario.vchCodigoPostal = txt_CodigoPostal.Text.Trim().ToString();
                        _mInventario.vchMunicipio = txt_Municipio.Text.Trim().ToString();
                        _mInventario.vchEstado = txt_Estado.Text.Trim().ToString();
                        _mInventario.vchPais = txt_Pais.Text.Trim().ToString();
                        _mInventario.vchEmail = txt_Email.Text.Trim().ToString();
                        _mInventario.vchTelefono = txt_Telefono.Text.Trim().ToString();
                        _mInventario.vchRFC = txt_RFC.Text.Trim().ToString();
                        _mInventario.vchLimiteCredito = txt_LimiteCredito.Text.Trim().ToString();
                        _mInventario.intDiasCredito = Convert.ToInt32(txt_DiasCredito.Text.Trim().ToString());
                        _mInventario.vchNoCuenta = txt_NoCuenta.Text.Trim().ToString();
                        _mInventario.bBloqueoCliente = chb_BloqueoCliente.Checked;
                        _mInventario.vchMotivoBloqueo = txt_MotivoBloqueo.Text.Trim().ToString();
                        _mInventario.bClienteExportacion = chb_ClienteExportacion.Checked;
                        _mInventario.intCostoFactuacion = Convert.ToInt32(cmb_CostoFactura.SelectedValue.ToString());
                        _mInventario.flDescuento = float.Parse(txt_Descuento.Text.Trim().ToString());
                        _mInventario.vchComentarios = txt_Comentarios.Text.Trim().ToString();
                        _mInventario.intAccionCliente = 2;

                        DataSet dsCliente = _mInventario.dsCatalogoClientes();

                        if (Convert.ToInt32(dsCliente.Tables[0].Rows[0]["respuesta"].ToString()) == 0)
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

        private void dgv_Cliente_cell_Datagrid_ContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _Id_Cliente = Convert.ToInt32(dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                txt_ClaveCliente.Text = Convert.ToString(_Id_Cliente);
                txtNombreCliente.Text = dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txt_Calle.Text = dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["Calle"].Value.ToString();
                txt_NoExt.Text = dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["No_Exterior"].Value.ToString();
                txt_NoInt.Text = dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["No_Interior"].Value.ToString();
                txt_Colonia.Text = dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["Colonia"].Value.ToString();
                txt_Ciudad.Text = dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["Ciudad"].Value.ToString();
                txt_CodigoPostal.Text = dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["Codigo_Postal"].Value.ToString();
                txt_Municipio.Text = dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["Municipio"].Value.ToString();
                txt_Estado.Text = dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["Estado"].Value.ToString();
                txt_Pais.Text = dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["Pais"].Value.ToString();
                txt_Email.Text = dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txt_Telefono.Text = dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                txt_RFC.Text = dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["RFC"].Value.ToString();
                txt_LimiteCredito.Text = dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["Limite_Credito"].Value.ToString();
                txt_DiasCredito.Text = dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["Dias_Credito"].Value.ToString();
                txt_NoCuenta.Text = dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["No_Cuenta"].Value.ToString();
                chb_BloqueoCliente.Checked = Convert.ToBoolean(dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["Bloqueo_Cliente"].Value.ToString());
                txt_MotivoBloqueo.Text = dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["Motivo_Bloqueo"].Value.ToString();
                chb_ClienteExportacion.Checked = Convert.ToBoolean(dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["Exportacion"].Value.ToString());
                cmb_CostoFactura.SelectedValue = dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["Costo_Factura"].Value.ToString();
                txt_Descuento.Text = dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["Descuento"].Value.ToString();
                txt_Comentarios.Text = dgv_Cliente.gvGrid.Rows[e.RowIndex].Cells["Comentarios"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
