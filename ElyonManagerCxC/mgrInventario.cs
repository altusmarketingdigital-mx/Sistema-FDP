using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Security.Cryptography;

namespace ElyonManagerCxC
{
    public class mgrInventario
    {
        #region Referencia MODEL

        ElyonModelCxC.mCxC _mSeguridad;
        ElyonModelCxC.mInventario _mInventario;

        #endregion Referencia MODEL

        #region VARIABLES PRIVADAS       
                                                      
        DataSet dsDatos = new DataSet();
        SqlConnection cn;
        string strConWs = System.Configuration.ConfigurationManager.AppSettings["CUENTASC"];
        #endregion

        #region CONSTRUCTOR

        public mgrInventario(string strXML)
        {
            _mInventario = ElyonModelCxC.mInventario.FromXml(strXML);
        }

        #endregion CONSTRUCTOR

        #region DATASET

        public DataSet dsCargarCombo_Medidas_Peso()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[0];

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "sp_Tss_Cargar_Combo_Medidas", param);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsObtenerDatosPedido()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@IdPedido", _mInventario.IdPedido);
                param[1] = new SqlParameter("@IdFolioPedido", _mInventario.IdFolioPedido);
                param[2] = new SqlParameter("@IdCliente", _mInventario.IdCliente);
                param[3] = new SqlParameter("@intAccion", _mInventario.intAccion);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "sp_CargarPedido", param);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsBusquedaPedido()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@intAccion", _mInventario.intAccion);
                param[1] = new SqlParameter("@IdCliente", _mInventario.IdCliente);
                param[2] = new SqlParameter("@FolioPedido", _mInventario.FolioPedido);
                param[3] = new SqlParameter("@IdPedido", _mInventario.IdPedido);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "sp_Buscar_Pedido", param);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsBitacoraRegistroCliente()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ClavePV", _mInventario.strConsecutivoPV);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "sp_Tss_Bitacora_Registro_Cliente", param);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsCancelarNotaRemision()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@PK_Id_Cancelar_Nota_Remisio", _mInventario.Id_Cancelar_Nota_Remisio);
                param[1] = new SqlParameter("@FK_Id_Nota_Remision", _mInventario.Id_Nota_Remision_Cancelar);
                param[2] = new SqlParameter("@dtp_Fecha", _mInventario.dtp_Fecha_Cancelar);
                param[3] = new SqlParameter("@FK_Id_Cajero", _mInventario.Id_Cajero_Cancelar);
                param[4] = new SqlParameter("@intAccion", _mInventario.intAccionCancelar);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "sp_Tss_Cancelar_Nota_Remision", param);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsMantenimientoDatosContribuyente()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[13];
                param[0] = new SqlParameter("@intAccion", _mInventario.Accion_Datos_Contribuyente);
                param[1] = new SqlParameter("@vchRazonSocial", _mInventario.vchRazonSocial_Contribuyente);
                param[2] = new SqlParameter("@vchRFC", _mInventario.vchRFC_Contribuyente);
                param[3] = new SqlParameter("@vchPais", _mInventario.vchPais_Contribuyente);
                param[4] = new SqlParameter("@vchEstado", _mInventario.vchEstado_Contribuyente);
                param[5] = new SqlParameter("@vchCiudad", _mInventario.vchCiudad_Contribuyente);
                param[6] = new SqlParameter("@vchCalle", _mInventario.vchCalle_Contribuyente);
                param[7] = new SqlParameter("@vchNoInt", _mInventario.vchNoInt_Contribuyente);
                param[8] = new SqlParameter("@vchNoExt", _mInventario.vchNoExt_Contribuyente);
                param[9] = new SqlParameter("@vchColonia", _mInventario.vchColonia_Contribuyente);
                param[10] = new SqlParameter("@vchCodigoPostal", _mInventario.vchCodigoPostal_Contribuyente);
                param[11] = new SqlParameter("@vchTelefono", _mInventario.vchTelefono_Contribuyente);
                param[12] = new SqlParameter("@vchEmail", _mInventario.vchEmail_Contribuyente);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "sp_Adm_ASP_Datos_Contribuyente", param);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsObtenerDatosCliente()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Id_Pedido", _mInventario.Id_No_Pedido);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "sp_Tss_Datos_Del_Cliente_PEDIDO", param);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsEncabezadoTicket_Pedido()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@PK_Id_Genera_Pedido", _mInventario.Id_Generar_Pedido);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "ds_ObtenerDatosFormatoTicket", param);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsObtenerContribuyente()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[0];

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "sp_Datos_Contribuyente", param);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsDatosDelContribuyente()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[13];
                param[0] = new SqlParameter("@PK_Id_Datos", _mInventario.Id_Datos_Contribuyente);
                param[1] = new SqlParameter("@vchRazonSocial", _mInventario.vchRazonSocial_Contribuyente);
                param[2] = new SqlParameter("@vchRFC", _mInventario.vchRFC_Contribuyente);
                param[3] = new SqlParameter("@vchPais", _mInventario.vchPais_Contribuyente);
                param[4] = new SqlParameter("@vchEstado", _mInventario.vchEstado_Contribuyente);
                param[5] = new SqlParameter("@vchCiudad", _mInventario.vchCiudad_Contribuyente);
                param[6] = new SqlParameter("@vchCalle", _mInventario.vchCalle_Contribuyente);
                param[7] = new SqlParameter("@vchNoInt", _mInventario.vchNoInt_Contribuyente);
                param[8] = new SqlParameter("@vchNoExt", _mInventario.vchNoExt_Contribuyente);
                param[9] = new SqlParameter("@vchColonia", _mInventario.vchColonia_Contribuyente);
                param[10] = new SqlParameter("@vchCodigoPostal", _mInventario.vchCodigoPostal_Contribuyente);
                param[11] = new SqlParameter("@vchTelefono", _mInventario.vchTelefono_Contribuyente);
                param[12] = new SqlParameter("@vchEmail", _mInventario.vchEmail_Contribuyente);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "sp_Tss_Datos_Del_Contribuyente", param);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsObtenerBoletaPago()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@idPagos", _mInventario.Id_Pagos);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spObtenerBoletaPago", param);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;

        }
        public DataSet dsObtenerBoletaPedido()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@idPedido", _mInventario.Id_Generar_Pedido);
               
                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spObtenerBoletaPedido", param);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;

        }

        public DataSet dsObtenerBoleta_NotaRemision()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@idPedido", _mInventario.Id_Generar_Pedido);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "sp_ObtenerBoletaRemision", param);
            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;

        }

        public DataSet dsReporteMovimientos()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@vchDescripcion", _mInventario.strDescripcion);
                param[1] = new SqlParameter("@intTipo", _mInventario.intTipoMov);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSELReporteMovimientos", param);

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsNotasCanceladasID()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                //SqlParameter[] param = new SqlParameter[1];
                //param[0] = new SqlParameter("@accion", _mInventario.Accion);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSEL_Cancelar_Nota_Remision");

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsPagosID()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                //SqlParameter[] param = new SqlParameter[1];
                //param[0] = new SqlParameter("@accion", _mInventario.Accion);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSEL_Pago_Cliente");

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsNotasRemisionID()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                //SqlParameter[] param = new SqlParameter[1];
                //param[0] = new SqlParameter("@accion", _mInventario.Accion);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSEL_Nota_Remision");

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsPedidosID()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                //SqlParameter[] param = new SqlParameter[1];
                //param[0] = new SqlParameter("@IdPedidos", _mInventario.Id_Pedidos);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSEL_Generar_Pedido");

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsObtenerDevoluciones()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Id_Cliente", _mInventario.Id_Cliente);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSEL_Devoluciones", param);

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsObtenerNotasRemision()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Id_Cliente", _mInventario.Id_Cliente);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSEL_EstadosNotasRemision", param);

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsObtenerClientes()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                //SqlParameter[] param = new SqlParameter[1];
                //param[0] = new SqlParameter("@Id_Cliente", _mInventario.Id_Cliente);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSEL_Tss_CatalogoClientes");

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsClientesID()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Id_Cliente", _mInventario.Id_Cliente);               

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "spSEL_Tss_IdClientes", param);

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }
        public DataSet dsCatalogoProveedores()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[16];
                param[0] = new SqlParameter("@PK_Id_Proveedor", _mInventario.Id_Proveedor);
                param[1] = new SqlParameter("@vchNombre_Proveedor", _mInventario.vchNombre_Proveedor);
                param[2] = new SqlParameter("@vchCalle_Proveedor", _mInventario.vchCalle_Proveedor);
                param[3] = new SqlParameter("@vchNoExt_Proveedor", _mInventario.vchNoExt_Proveedor);
                param[4] = new SqlParameter("@vchNoInt_Proveedor", _mInventario.vchNoInt_Proveedor);
                param[5] = new SqlParameter("@vchColonia_Proveedor", _mInventario.vchColonia_Proveedor);
                param[6] = new SqlParameter("@vchCp_Proveedor", _mInventario.vchCp_Proveedor);
                param[7] = new SqlParameter("@vchCiudad_Proveedor", _mInventario.vchCiudad_Proveedor);
                param[8] = new SqlParameter("@vchEstado_Proveedor", _mInventario.vchEstado_Proveedor);
                param[9] = new SqlParameter("@vchPais_Proveedor", _mInventario.vchPais_Proveedor);
                param[10] = new SqlParameter("@vchEmail_Proveedor", _mInventario.vchEmail_Proveedor);
                param[11] = new SqlParameter("@vchTelefono_Proveedor", _mInventario.vchTelefono_Proveedor);
                param[12] = new SqlParameter("@vchCelular_Proveedor", _mInventario.vchCelular_Proveedor);
                param[13] = new SqlParameter("@vchRfc_Proveedor", _mInventario.vchRfc_Proveedor);
                param[14] = new SqlParameter("@vchNoDeCuenta_Proveeddor", _mInventario.vchNoDeCuenta_Proveeddor);
                param[15] = new SqlParameter("@intAccion", _mInventario.intAccionProveedor);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "sp_Tss_Proveedores", param);

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsCatalogoGrupos()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@PK_Id_Grupo", _mInventario.Id_Grupo);
                param[1] = new SqlParameter("@vchNombre_Grupo", _mInventario.vchNombre_Grupo);
                param[2] = new SqlParameter("@intAccion", _mInventario.intAccionGrupo);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "sp_Tss_Grupo", param);

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsCatalogoDepartamentos()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@PK_Id_Departamento", _mInventario.Id_Departamento);
                param[1] = new SqlParameter("@vchNombre_Departamento", _mInventario.vchNombre_Departamento);
                param[2] = new SqlParameter("@intAccion", _mInventario.intAccionDepartamento);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "sp_Tss_Departamento", param);

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsCatalogoProducto()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[25];

                param[0] = new SqlParameter("@PK_Id_Producto", _mInventario.Id_Producto);
                param[1] = new SqlParameter("@vchClaveProducto", _mInventario.vchClaveProducto); 
                param[2] = new SqlParameter("@vchNombre", _mInventario.vchNombre);
                param[3] = new SqlParameter("@vchLocalizacion", _mInventario.vchLocalizacion);
                param[4] = new SqlParameter("@bitArticuloConDecimal", _mInventario.bitArticuloConDecimal);
                param[5] = new SqlParameter("@vch_UM_Compra", _mInventario.UM_Compra);
                param[6] = new SqlParameter("@vch_UM_Venta", _mInventario.UM_Venta);
                param[7] = new SqlParameter("@vchContenido", _mInventario.vchContenido);
                param[8] = new SqlParameter("@intClaveGrupo", _mInventario.intClaveGrupo);
                param[9] = new SqlParameter("@intClaveDepartamento", _mInventario.intClaveDepartamento);
                param[10] = new SqlParameter("@vchInventarioMinimo", _mInventario.vchInventarioMinimo);
                param[11] = new SqlParameter("@vchInventarioMaximo", _mInventario.vchInventarioMaximo);
                param[12] = new SqlParameter("@bitProductoExento", _mInventario.bitProductoExento);
                param[13] = new SqlParameter("@fltIEPS", _mInventario.fltIEPS);
                param[14] = new SqlParameter("@fltIVA", _mInventario.fltIVA);
                param[15] = new SqlParameter("@fltPrecioCompra", _mInventario.fltPrecioCompra);
                param[16] = new SqlParameter("@ftl_MargenUtilidad_1", _mInventario.ftl_MargenUtilidad_1);
                param[17] = new SqlParameter("@flt_PrecioVenta_1", _mInventario.flt_PrecioVenta_1);
                param[18] = new SqlParameter("@ftl_MargenUtilidad_2", _mInventario.ftl_MargenUtilidad_2);
                param[19] = new SqlParameter("@flt_PrecioVenta_2", _mInventario.flt_PrecioVenta_2);
                param[20] = new SqlParameter("@ftl_MargenUtilidad_3", _mInventario.ftl_MargenUtilidad_3);
                param[21] = new SqlParameter("@flt_PrecioVenta_3", _mInventario.flt_PrecioVenta_3);
                param[22] = new SqlParameter("@vch_Clave_Unidad_Medida", _mInventario.Clave_Unidad_Medida);
                param[23] = new SqlParameter("@vch_Clave_ProdServicio", _mInventario.Clave_ProdServicio);
                param[24] = new SqlParameter("@intAccion", _mInventario.intAccionProducto); 

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "sp_Tss_Producto", param);

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsCargarCombo()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Valor1", _mInventario.intValor1);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "sp_Tss_CargaCombos", param);

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsCatalogoClientes()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[27];
                param[0] = new SqlParameter("@PK_Id_Cliente", _mInventario.Id_Cliente);
                param[1] = new SqlParameter("@vchConsecutivo_PV", _mInventario.vchConsecutivo_PV);
                param[2] = new SqlParameter("@vchContacto", _mInventario.vchContacto);
                param[3] = new SqlParameter("@vchNombre", _mInventario.vchNombreCliente);
                param[4] = new SqlParameter("@vchCalle", _mInventario.vchCalle);
                param[5] = new SqlParameter("@vchNoExterior", _mInventario.vchNoExterior);
                param[6] = new SqlParameter("@vchNoInterior", _mInventario.vchNoInterior);
                param[7] = new SqlParameter("@vchColonia", _mInventario.vchColonia);
                param[8] = new SqlParameter("@vchCiudad", _mInventario.vchCiudad);
                param[9] = new SqlParameter("@vchCodigoPostal", _mInventario.vchCodigoPostal);
                param[10] = new SqlParameter("@vchMunicipio", _mInventario.vchMunicipio);
                param[11] = new SqlParameter("@vchEstado", _mInventario.vchEstado);
                param[12] = new SqlParameter("@vchPais", _mInventario.vchPais);
                param[13] = new SqlParameter("@vchEmail", _mInventario.vchEmail);
                param[14] = new SqlParameter("@vchTelefono", _mInventario.vchTelefono);
                param[15] = new SqlParameter("@vchTelefono_2", _mInventario.vchTelefono_2);
                param[16] = new SqlParameter("@vchRFC", _mInventario.vchRFC);
                param[17] = new SqlParameter("@vchLimiteCredito", _mInventario.vchLimiteCredito);
                param[18] = new SqlParameter("@intDiasCredito", _mInventario.intDiasCredito);
                param[19] = new SqlParameter("@vchNoCuenta", _mInventario.vchNoCuenta);
                param[20] = new SqlParameter("@bBloqueoCliente", _mInventario.bBloqueoCliente);
                param[21] = new SqlParameter("@vchMotivoBloqueo", _mInventario.vchMotivoBloqueo);
                param[22] = new SqlParameter("@bClienteExportacion", _mInventario.bClienteExportacion);
                param[23] = new SqlParameter("@intCostoFactuacion", _mInventario.intCostoFactuacion);
                param[24] = new SqlParameter("@flDescuento", _mInventario.flDescuento);
                param[25] = new SqlParameter("@vchComentarios", _mInventario.vchComentarios);
                param[26] = new SqlParameter("@intAccion", _mInventario.intAccionCliente);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "sp_Tss_Cliente", param);

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsRegistroInventarioInicial()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@PK_Id_Inventario", _mInventario.Id_Inventario);
                param[1] = new SqlParameter("@FK_Id_ClaveProducto", _mInventario.Id_ClaveProducto);
                param[2] = new SqlParameter("@intUnidadesCompra_Fisco", _mInventario.intUnidadesCompra_Fisco);
                param[3] = new SqlParameter("@intUnidadesVenta_Fisco", _mInventario.intUnidadesVenta_Fisco);
                param[4] = new SqlParameter("@intUnidadesVenta_InicialCalculado", _mInventario.intUnidadesVenta_InicialCalculado);
                param[5] = new SqlParameter("@flt_Importa", _mInventario.flt_Importa);
                param[6] = new SqlParameter("@intAccion", _mInventario.intAccion_Inventario_Inicial);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "sp_Tss_Inventario_Producto", param);

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsObtenerUsuario()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@IdUsuario", _mInventario.IdUsuario);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "sp_Tss_Obtener_Cajero", param);

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsMantenimientoFolioPedidos()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@PK_Id_Folio_Pedido", _mInventario.Id_Folio_Pedido);
                param[1] = new SqlParameter("@vchClaveFolio", _mInventario.vchClaveFolio);
                param[2] = new SqlParameter("@FK_Id_Usuario", _mInventario.Id_Usuario);
                param[3] = new SqlParameter("@vch_IP_Equipo", _mInventario.IP_Equipo);
                param[4] = new SqlParameter("@intAccion", _mInventario.intAccionFolio);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "sp_Tss_Folio_Pedido", param);

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsGenerarPedido()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[20];
                param[0] = new SqlParameter("@intAccion", _mInventario.intAccionGenerarPedido);
                param[1] = new SqlParameter("@PK_Id_Genera_Pedido", _mInventario.Id_Generar_Pedido);
                param[2] = new SqlParameter("@vchFolio", _mInventario.vchFolio);
                param[3] = new SqlParameter("@FK_Id_Usuario", _mInventario.Id_Usuario);
                param[4] = new SqlParameter("@dtp_FechaVenta", _mInventario.dtp_FechaVenta);
                param[5] = new SqlParameter("@FK_Id_Cliente", _mInventario.Id_Cliente);
                param[6] = new SqlParameter("@intDiasCredito", _mInventario.intDiasCredito);
                param[7] = new SqlParameter("@dtp_FechaVencimientoCredito", _mInventario.dtp_FechaVencimientoCredito);
                param[8] = new SqlParameter("@FK_Metodo_Pago", _mInventario.Metodo_Pago);
                param[9] = new SqlParameter("@FK_Forma_Pago", _mInventario.Forma_Pago);
                param[10] = new SqlParameter("@flt_TotalVenta", _mInventario.TotalVenta);
                param[11] = new SqlParameter("@vchComentario", _mInventario.vchComentario);
                param[12] = new SqlParameter("@PK_Id_Generar_Pedido_Detalle", _mInventario.Id_Generar_Pedido_Detalle);
                param[13] = new SqlParameter("@FK_Id_Generar_Pedido", _mInventario.Id_Genera_Pedido);
                param[14] = new SqlParameter("@FK_Id_Clave_Producto", _mInventario.Id_Clave_Producto);
                param[15] = new SqlParameter("@fltCantidad", _mInventario.Cantidad);
                param[16] = new SqlParameter("@vchUmVenta", _mInventario.UM_Venta);
                param[17] = new SqlParameter("@fltPrecioVenta", _mInventario.PrecioVenta);
                param[18] = new SqlParameter("@dcDescuento", _mInventario.dcDescuento);
                param[19] = new SqlParameter("@fltImporte", _mInventario.Importe);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "sp_Tss_Generar_Pedido", param);

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsRegistroNotaRemision()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@PK_Id_Nota_Remision", _mInventario.Id_Nota_Remision);
                param[1] = new SqlParameter("@FK_Id_No_Pedido", _mInventario.Id_No_Pedido);
                param[2] = new SqlParameter("@dtp_Fecha_Nota_Remision", Convert.ToDateTime(_mInventario.Fecha_Nota_Remision));
                param[3] = new SqlParameter("@FK_Id_Cajero", _mInventario.Id_Cajero);
                param[4] = new SqlParameter("@vchEstatus_Nota_Remision", _mInventario.vchEstatus_Nota_Remision);
                param[5] = new SqlParameter("@FK_Id_Cliente", _mInventario.Id_Cliente);
                param[6] = new SqlParameter("@intAccion", _mInventario.intAccionNotaRemision);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "sp_Tss_Nota_Remision", param);

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsRegistroPagoCliente()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[16];
                param[0] = new SqlParameter("@PK_Id_Registro_Pago_Cliente", _mInventario.Id_Registro_Pago_Cliente);
                param[1] = new SqlParameter("@FK_Id_Cliente", _mInventario.Id_Cliente);
                param[2] = new SqlParameter("@FK_Id_Nota_Remision", _mInventario.Id_Nota_Remision);
                param[3] = new SqlParameter("@flt_Saldo_Anterior", _mInventario.Saldo_Anterior);
                param[4] = new SqlParameter("@flt_Interes", _mInventario.Interes);
                param[5] = new SqlParameter("@flt_Saldo_Favor", _mInventario.Saldo_Favor);
                param[6] = new SqlParameter("@flt_Pago_Aplicar", _mInventario.Pago_Aplicar);
                param[7] = new SqlParameter("@flt_Saldo_Nuevo", _mInventario.Saldo_Nuevo);
                param[8] = new SqlParameter("@dtp_Fecha_Timbrado", _mInventario.Fecha_Timbrado);
                param[9] = new SqlParameter("@PK_Id_Registro_Pago_Cliente_Detalle", _mInventario.Id_Registro_Pago_Cliente_Detalle);
                param[10] = new SqlParameter("@FK_Id_Registro_Pago_Cliente", _mInventario.Id_Registro_Pago_Cliente);
                param[11] = new SqlParameter("@FK_Id_Forma_Pago", _mInventario.Id_Forma_Pago);
                param[12] = new SqlParameter("@flt_Importe_Pago", _mInventario.Importe_Pago);
                param[13] = new SqlParameter("@flt_Total_Pago", _mInventario.Total_Pago);
                param[14] = new SqlParameter("@flt_Cambio_Pago", _mInventario.Cambio_Pago);
                param[15] = new SqlParameter("@intAccion", _mInventario.intAccionRegistroPagoCliente); 

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "sp_Tss_Registro_Pago_Cliente", param);

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        public DataSet dsObtenerDocumentoNotaRemision()
        {
            DataSet ds = new DataSet();
            cn = new SqlConnection(strConWs);
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FK_Id_Nota_Remision", _mInventario.Id_Nota_Remision);
                param[1] = new SqlParameter("@intAccion", _mInventario.intAccionNotaRemision);

                ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(cn, "sp_Tss_ObtenerInformacionDocumento_Nota_Remision", param);

            }
            catch (Exception ex)
            {

            }
            cn.Close();
            cn.Dispose();
            return ds;
        }

        #endregion
    }
}
