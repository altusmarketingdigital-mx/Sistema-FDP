using AppElyonCXC.Mantenimiento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppElyonCXC.Catalogos
{
    public partial class Frm_CargaMasiva_Productos : Form
    {
        #region CONEXIONES LOCALES
        ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        ElyonModelCxC.mInventario _mInventario = new ElyonModelCxC.mInventario(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlCuentas);
        #endregion

        #region VARIABLES
        char[] delimitador_cc = { ',' };
        char[] delimitador_adjunto = { '|' };
        int _IdAsignarVendedorProspecto;
        int _intbit = 0;

        string _vchClaveProducto;
        string _vchNombre;
        string _vch_UM_Venta;
        float _flt_PrecioVenta_1;
        float _flt_PrecioVenta_2;
        float _flt_PrecioVenta_3;

        /* CLIENTES */
        string _Id_Cliente;
        string _vchConsecutivo_PV;
        string _vchContacto;
      //string _vchNombre;
        string _vchCalle;
        string _vchNoExterior;
        string _vchNoInterior;
        string _vchColonia;
        string _vchCiudad;
        string _vchCodigoPostal;
        string _vchMunicipio;
        string _vchEstado;
        string _vchPais;
        string _vchEmail;
        string _vchTelefono;
        string _vchTelefono_2;
        string _vchRFC;
        string _vchLimiteCredito;
        string _DiasCredito;
        string _vchNoCuenta;
        string _bBloqueoCliente;
        string _vchMotivoBloqueo;
        string _bClienteExportacion;
        string _intCostoFactuacion;
        string _flDescuento;
        string _vchComentarios;
        string _bActivo;
        #endregion

        public Frm_CargaMasiva_Productos()
        {
            InitializeComponent();
        }

        private void CargarTipoDocumento()
        {
            try
            {
                _mInventario.intValor1 = 6;
                DataSet dsTipoCatalogo = _mInventario.dsCargarCombo();

                if (dsTipoCatalogo.Tables[0].Rows.Count > 0)
                {
                    comboBox1.DataSource = dsTipoCatalogo.Tables[0].DefaultView;
                    comboBox1.ValueMember = "Id";
                    comboBox1.DisplayMember = "Descripcion";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            string filePath;
            System.Windows.Forms.OpenFileDialog dlCarpeta = new System.Windows.Forms.OpenFileDialog();

            if (dlCarpeta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Ruta del Archivo
                txtRuta.Text = dlCarpeta.FileName;
                filePath = dlCarpeta.FileName;

                /* Validamos el tipo de documento a cargar */
                char tipo = Convert.ToChar(comboBox1.SelectedValue.ToString()); 

                switch (tipo)
                {
                    case '1': //CLIENTE
                        CargaArchivoGrid_Cliente();
                        break;
                    case '2': //PROVEEDOR
                        Console.WriteLine("Excellent!");
                        break;
                    case '3': //PRODUCTO
                        CargaArchivoGrid_Productos();
                        break;
                    case '4': //GRUPO
                        Console.WriteLine("Excellent!");
                        break;
                    case '5': //DEPARTAMENTO
                        Console.WriteLine("Excellent!");
                        break;
                    default:
                        break;
                }
            }
        }

        private void CargaArchivoGrid_Productos()
        {
            #region Cargar Archivoa GRID           
            int i = 0;
            _intbit = 0;
            int vuelta = 1;
            char[] cDelimeter = { ',' };
            string[] strDivision;
            DataTable dtbDatos = new DataTable("CARGAR_PRODUCTOS");
            //Insert en tabla                                                                        
            dtbDatos.Columns.Add("vchClaveProducto").ReadOnly = true;
            dtbDatos.Columns.Add("vchNombre").ReadOnly = true;
            dtbDatos.Columns.Add("vch_UM_Venta").ReadOnly = true;
            dtbDatos.Columns.Add("flt_PrecioVenta_1").ReadOnly = true;
            dtbDatos.Columns.Add("flt_PrecioVenta_2").ReadOnly = true;
            dtbDatos.Columns.Add("flt_PrecioVenta_3").ReadOnly = true;

            if (txtRuta.Text == "" || txtRuta.Text == null)
            {
                MessageBox.Show("Favor de Asignar el Archivo.", "ERROR DE CARGA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRuta.Focus();
            }
            else
            {
                using (StreamReader srLeer = new StreamReader(txtRuta.Text))
                {
                    string linea;
                    try
                    {

                        while ((linea = srLeer.ReadLine()) != null)
                        {
                            if (srLeer.EndOfStream)
                            {
                                //Carga datos NUevos
                                strDivision = linea.Split(cDelimeter);

                                _vchClaveProducto = strDivision[0];
                                _vchNombre = strDivision[1];
                                _vch_UM_Venta = strDivision[2];
                                _flt_PrecioVenta_1 = float.Parse(strDivision[3]);
                                _flt_PrecioVenta_2 = float.Parse(strDivision[4]);
                                _flt_PrecioVenta_3 = float.Parse(strDivision[5]);

                                if (_intbit == 1)
                                {
                                    //Inserta Datos Anteriores si es 15
                                    DataRow dtrError = dtbDatos.NewRow();

                                    dtrError["vchClaveProducto"] = _vchClaveProducto;
                                    dtrError["vchNombre"] = _vchNombre;
                                    dtrError["vch_UM_Venta"] = _vch_UM_Venta;
                                    dtrError["flt_PrecioVenta_1"] = _flt_PrecioVenta_1;
                                    dtrError["flt_PrecioVenta_2"] = _flt_PrecioVenta_2;
                                    dtrError["flt_PrecioVenta_3"] = _flt_PrecioVenta_3;

                                    dtbDatos.Rows.Add(dtrError);
                                    dgv_Productos.DataSource = dtbDatos;
                                }


                                //Inserta Datos los datos nuevos
                                DataRow dtrError1 = dtbDatos.NewRow();

                                dtrError1["vchClaveProducto"] = _vchClaveProducto;
                                dtrError1["vchNombre"] = _vchNombre;
                                dtrError1["vch_UM_Venta"] = _vch_UM_Venta;
                                dtrError1["flt_PrecioVenta_1"] = _flt_PrecioVenta_1;
                                dtrError1["flt_PrecioVenta_2"] = _flt_PrecioVenta_2;
                                dtrError1["flt_PrecioVenta_3"] = _flt_PrecioVenta_3;

                                dtbDatos.Rows.Add(dtrError1);
                                dgv_Productos.DataSource = dtbDatos;

                                break;
                            }
                            else
                            {
                                if (vuelta != 1)
                                {
                                    #region Carga 

                                    if (linea != "" || linea != null)
                                    {
                                        strDivision = linea.Split(cDelimeter);

                                        _vchClaveProducto = strDivision[0];
                                        _vchNombre = strDivision[1];
                                        _vch_UM_Venta = strDivision[2];
                                        _flt_PrecioVenta_1 = float.Parse(strDivision[3]);
                                        _flt_PrecioVenta_2 = float.Parse(strDivision[4]);
                                        _flt_PrecioVenta_3 = float.Parse(strDivision[5]);

                                        if (_intbit == 1)
                                        {
                                            DataRow dtrError = dtbDatos.NewRow();

                                            dtrError["vchClaveProducto"] = _vchClaveProducto;
                                            dtrError["vchNombre"] = _vchNombre;
                                            dtrError["vch_UM_Venta"] = _vch_UM_Venta;
                                            dtrError["flt_PrecioVenta_1"] = _flt_PrecioVenta_1;
                                            dtrError["flt_PrecioVenta_2"] = _flt_PrecioVenta_2;
                                            dtrError["flt_PrecioVenta_3"] = _flt_PrecioVenta_3;

                                            dtbDatos.Rows.Add(dtrError);

                                            //Cargas grid
                                            dgv_Productos.DataSource = dtbDatos;

                                            _intbit = 1;
                                        }
                                    }
                                    #endregion

                                    if (_intbit == 0)
                                    {
                                        DataRow dtrError = dtbDatos.NewRow();

                                        dtrError["vchClaveProducto"] = _vchClaveProducto;
                                        dtrError["vchNombre"] = _vchNombre;
                                        dtrError["vch_UM_Venta"] = _vch_UM_Venta;
                                        dtrError["flt_PrecioVenta_1"] = _flt_PrecioVenta_1;
                                        dtrError["flt_PrecioVenta_2"] = _flt_PrecioVenta_2;
                                        dtrError["flt_PrecioVenta_3"] = _flt_PrecioVenta_3;

                                        dtbDatos.Rows.Add(dtrError);
                                        dgv_Productos.DataSource = dtbDatos;
                                    }
                                }
                            }
                            vuelta++;
                        }
                    }
                    catch (Exception ex) { }
                    srLeer.Close();
                }
                MessageBox.Show("Proceso terminado archivo cargado", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
        }

        private void CargaArchivoGrid_Cliente()
        {
            #region Cargar Archivoa GRID       

            UcSplashScreen cargando = new UcSplashScreen("", "... Cargando Clientes ... ");
            cargando.Show();
            cargando.Refresh();

            int i = 0;
            _intbit = 0;
            int vuelta = 1;
            char[] cDelimeter = { ',' };
            string[] strDivision;
            DataTable dtbDatos = new DataTable("CARGAR_PRODUCTOS");
            //Insert en tabla                   

            dtbDatos.Columns.Add("PK_Id_Cliente").ReadOnly = true; // 0
            dtbDatos.Columns.Add("vchConsecutivo_PV").ReadOnly = true; // 1
            dtbDatos.Columns.Add("vchContacto").ReadOnly = true; // 2
            dtbDatos.Columns.Add("vchNombre").ReadOnly = true; // 3
            dtbDatos.Columns.Add("vchCalle").ReadOnly = true; // 4
            dtbDatos.Columns.Add("vchNoExterior").ReadOnly = true; // 5
            dtbDatos.Columns.Add("vchNoInterior").ReadOnly = true; // 6
            dtbDatos.Columns.Add("vchColonia").ReadOnly = true; // 7
            dtbDatos.Columns.Add("vchCiudad").ReadOnly = true; // 8
            dtbDatos.Columns.Add("vchCodigoPostal").ReadOnly = true; // 9
            dtbDatos.Columns.Add("vchMunicipio").ReadOnly = true; // 10
            dtbDatos.Columns.Add("vchEstado").ReadOnly = true; // 11
            dtbDatos.Columns.Add("vchPais").ReadOnly = true; // 12
            dtbDatos.Columns.Add("vchEmail").ReadOnly = true; // 13
            dtbDatos.Columns.Add("vchTelefono").ReadOnly = true; // 14
            dtbDatos.Columns.Add("vchTelefono_2").ReadOnly = true; // 15
            dtbDatos.Columns.Add("vchRFC").ReadOnly = true; // 16
            dtbDatos.Columns.Add("vchLimiteCredito").ReadOnly = true; // 17
            dtbDatos.Columns.Add("intDiasCredito").ReadOnly = true; // 18
            dtbDatos.Columns.Add("vchNoCuenta").ReadOnly = true; // 19
            dtbDatos.Columns.Add("bBloqueoCliente").ReadOnly = true; // 20
            dtbDatos.Columns.Add("vchMotivoBloqueo").ReadOnly = true; // 21
            dtbDatos.Columns.Add("bClienteExportacion").ReadOnly = true; // 22
            dtbDatos.Columns.Add("intCostoFactuacion").ReadOnly = true; // 23
            dtbDatos.Columns.Add("flDescuento").ReadOnly = true; // 24
            dtbDatos.Columns.Add("vchComentarios").ReadOnly = true; // 25
            dtbDatos.Columns.Add("bActivo").ReadOnly = true; // 26

            if (txtRuta.Text == "" || txtRuta.Text == null)
            {
                MessageBox.Show("Favor de Asignar el Archivo.", "ERROR DE CARGA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRuta.Focus();
            }
            else
            {
                using (StreamReader srLeer = new StreamReader(txtRuta.Text))
                {
                    string linea;
                    try
                    {

                        while ((linea = srLeer.ReadLine()) != null)
                        {
                            if (srLeer.EndOfStream)
                            {
                                //Carga datos NUevos
                                strDivision = linea.Split(cDelimeter);

                                _Id_Cliente = strDivision[0].Trim();
                                _vchConsecutivo_PV = strDivision[1].Trim();
                                _vchContacto = strDivision[2].Trim();
                                _vchNombre = strDivision[3].Trim();
                                _vchCalle = strDivision[4].Trim();
                                _vchNoExterior = strDivision[5].Trim();
                                _vchNoInterior = strDivision[6].Trim();
                                _vchColonia = strDivision[7].Trim();
                                _vchCiudad = strDivision[8].Trim();
                                _vchCodigoPostal = strDivision[9].Trim();
                                _vchMunicipio = strDivision[10].Trim();
                                _vchEstado = strDivision[11].Trim();
                                _vchPais = strDivision[12].Trim();
                                _vchEmail = strDivision[13].Trim();
                                _vchTelefono = strDivision[14].Trim();
                                _vchTelefono_2 = strDivision[15].Trim();
                                _vchRFC = strDivision[16].Trim();
                                _vchLimiteCredito = strDivision[17].Trim();
                                _DiasCredito = strDivision[18].Trim();
                                _vchNoCuenta = strDivision[19].Trim();
                                _bBloqueoCliente = strDivision[20].Trim();
                                _vchMotivoBloqueo = strDivision[21].Trim();
                                _bClienteExportacion = strDivision[22].Trim();
                                _intCostoFactuacion = strDivision[23].Trim();
                                _flDescuento = strDivision[24].Trim();
                                _vchComentarios = strDivision[25].Trim();
                                _bActivo = strDivision[26].Trim();

                                if (_intbit == 1)
                                {
                                    //Inserta Datos Anteriores si es 15
                                    DataRow dtrError = dtbDatos.NewRow();

                                    dtrError["PK_Id_Cliente"] = _Id_Cliente;
                                    dtrError["vchConsecutivo_PV"] = _vchConsecutivo_PV;
                                    dtrError["vchContacto"] = _vchContacto;
                                    dtrError["vchNombre"] = _vchNombre;
                                    dtrError["vchCalle"] = _vchCalle;
                                    dtrError["vchNoExterior"] = _vchNoExterior;
                                    dtrError["vchNoInterior"] = _vchNoInterior;
                                    dtrError["vchColonia"] = _vchColonia;
                                    dtrError["vchCiudad"] = _vchCiudad;
                                    dtrError["vchCodigoPostal"] = _vchCodigoPostal;
                                    dtrError["vchMunicipio"] = _vchMunicipio;
                                    dtrError["vchEstado"] = _vchEstado;
                                    dtrError["vchPais"] = _vchPais;
                                    dtrError["vchEmail"] = _vchEmail;
                                    dtrError["vchTelefono"] = _vchTelefono;
                                    dtrError["vchTelefono_2"] = _vchTelefono_2;
                                    dtrError["vchRFC"] = _vchRFC;
                                    dtrError["vchLimiteCredito"] = _vchLimiteCredito;
                                    dtrError["intDiasCredito"] = _DiasCredito;
                                    dtrError["vchNoCuenta"] = _vchNoCuenta;
                                    dtrError["bBloqueoCliente"] = _bBloqueoCliente;
                                    dtrError["vchMotivoBloqueo"] = _vchMotivoBloqueo;
                                    dtrError["bClienteExportacion"] = _bClienteExportacion;
                                    dtrError["intCostoFactuacion"] = _intCostoFactuacion;
                                    dtrError["flDescuento"] = _flDescuento;
                                    dtrError["vchComentarios"] = _vchComentarios;
                                    dtrError["bActivo"] = _bActivo;


                                    dtbDatos.Rows.Add(dtrError);
                                    dgv_Productos.DataSource = dtbDatos;
                                }


                                //Inserta Datos los datos nuevos
                                DataRow dtrError1 = dtbDatos.NewRow();

                                dtrError1["PK_Id_Cliente"] = _Id_Cliente;
                                dtrError1["vchConsecutivo_PV"] = _vchConsecutivo_PV;
                                dtrError1["vchContacto"] = _vchContacto;
                                dtrError1["vchNombre"] = _vchNombre;
                                dtrError1["vchCalle"] = _vchCalle;
                                dtrError1["vchNoExterior"] = _vchNoExterior;
                                dtrError1["vchNoInterior"] = _vchNoInterior;
                                dtrError1["vchColonia"] = _vchColonia;
                                dtrError1["vchCiudad"] = _vchCiudad;
                                dtrError1["vchCodigoPostal"] = _vchCodigoPostal;
                                dtrError1["vchMunicipio"] = _vchMunicipio;
                                dtrError1["vchEstado"] = _vchEstado;
                                dtrError1["vchPais"] = _vchPais;
                                dtrError1["vchEmail"] = _vchEmail;
                                dtrError1["vchTelefono"] = _vchTelefono;
                                dtrError1["vchTelefono_2"] = _vchTelefono_2;
                                dtrError1["vchRFC"] = _vchRFC;
                                dtrError1["vchLimiteCredito"] = _vchLimiteCredito;
                                dtrError1["intDiasCredito"] = _DiasCredito;
                                dtrError1["vchNoCuenta"] = _vchNoCuenta;
                                dtrError1["bBloqueoCliente"] = _bBloqueoCliente;
                                dtrError1["vchMotivoBloqueo"] = _vchMotivoBloqueo;
                                dtrError1["bClienteExportacion"] = _bClienteExportacion;
                                dtrError1["intCostoFactuacion"] = _intCostoFactuacion;
                                dtrError1["flDescuento"] = _flDescuento;
                                dtrError1["vchComentarios"] = _vchComentarios;
                                dtrError1["bActivo"] = _bActivo;

                                dtbDatos.Rows.Add(dtrError1);
                                dgv_Productos.DataSource = dtbDatos;

                                break;
                            }
                            else
                            {
                                if (vuelta != 1)
                                {
                                    #region Carga 

                                    if (linea != "" || linea != null)
                                    {
                                        strDivision = linea.Split(cDelimeter);

                                        _Id_Cliente = strDivision[0].Trim();
                                        _vchConsecutivo_PV = strDivision[1].Trim();
                                        _vchContacto = strDivision[2].Trim();
                                        _vchNombre = strDivision[3].Trim();
                                        _vchCalle = strDivision[4].Trim();
                                        _vchNoExterior = strDivision[5].Trim();
                                        _vchNoInterior = strDivision[6].Trim();
                                        _vchColonia = strDivision[7].Trim();
                                        _vchCiudad = strDivision[8].Trim();
                                        _vchCodigoPostal = strDivision[9].Trim();
                                        _vchMunicipio = strDivision[10].Trim();
                                        _vchEstado = strDivision[11].Trim();
                                        _vchPais = strDivision[12].Trim();
                                        _vchEmail = strDivision[13].Trim();
                                        _vchTelefono = strDivision[14].Trim();
                                        _vchTelefono_2 = strDivision[15].Trim();
                                        _vchRFC = strDivision[16].Trim();
                                        _vchLimiteCredito = strDivision[17].Trim();
                                        _DiasCredito = strDivision[18].Trim();
                                        _vchNoCuenta = strDivision[19].Trim();
                                        _bBloqueoCliente = strDivision[20].Trim();
                                        _vchMotivoBloqueo = strDivision[21].Trim();
                                        _bClienteExportacion = strDivision[22].Trim();
                                        _intCostoFactuacion = strDivision[23].Trim();
                                        _flDescuento = strDivision[24].Trim();
                                        _vchComentarios = strDivision[25].Trim();
                                        _bActivo = strDivision[26].Trim();

                                        if (_intbit == 1)
                                        {
                                            DataRow dtrError = dtbDatos.NewRow();

                                            dtrError["PK_Id_Cliente"] = _Id_Cliente;
                                            dtrError["vchConsecutivo_PV"] = _vchConsecutivo_PV;
                                            dtrError["vchContacto"] = _vchContacto;
                                            dtrError["vchNombre"] = _vchNombre;
                                            dtrError["vchCalle"] = _vchCalle;
                                            dtrError["vchNoExterior"] = _vchNoExterior;
                                            dtrError["vchNoInterior"] = _vchNoInterior;
                                            dtrError["vchColonia"] = _vchColonia;
                                            dtrError["vchCiudad"] = _vchCiudad;
                                            dtrError["vchCodigoPostal"] = _vchCodigoPostal;
                                            dtrError["vchMunicipio"] = _vchMunicipio;
                                            dtrError["vchEstado"] = _vchEstado;
                                            dtrError["vchPais"] = _vchPais;
                                            dtrError["vchEmail"] = _vchEmail;
                                            dtrError["vchTelefono"] = _vchTelefono;
                                            dtrError["vchTelefono_2"] = _vchTelefono_2;
                                            dtrError["vchRFC"] = _vchRFC;
                                            dtrError["vchLimiteCredito"] = _vchLimiteCredito;
                                            dtrError["intDiasCredito"] = _DiasCredito;
                                            dtrError["vchNoCuenta"] = _vchNoCuenta;
                                            dtrError["bBloqueoCliente"] = _bBloqueoCliente;
                                            dtrError["vchMotivoBloqueo"] = _vchMotivoBloqueo;
                                            dtrError["bClienteExportacion"] = _bClienteExportacion;
                                            dtrError["intCostoFactuacion"] = _intCostoFactuacion;
                                            dtrError["flDescuento"] = _flDescuento;
                                            dtrError["vchComentarios"] = _vchComentarios;
                                            dtrError["bActivo"] = _bActivo;

                                            dtbDatos.Rows.Add(dtrError);

                                            //Cargas grid
                                            dgv_Productos.DataSource = dtbDatos;

                                            _intbit = 1;
                                        }
                                    }
                                    #endregion

                                    if (_intbit == 0)
                                    {
                                        DataRow dtrError = dtbDatos.NewRow();

                                        dtrError["PK_Id_Cliente"] = _Id_Cliente;
                                        dtrError["vchConsecutivo_PV"] = _vchConsecutivo_PV;
                                        dtrError["vchContacto"] = _vchContacto;
                                        dtrError["vchNombre"] = _vchNombre;
                                        dtrError["vchCalle"] = _vchCalle;
                                        dtrError["vchNoExterior"] = _vchNoExterior;
                                        dtrError["vchNoInterior"] = _vchNoInterior;
                                        dtrError["vchColonia"] = _vchColonia;
                                        dtrError["vchCiudad"] = _vchCiudad;
                                        dtrError["vchCodigoPostal"] = _vchCodigoPostal;
                                        dtrError["vchMunicipio"] = _vchMunicipio;
                                        dtrError["vchEstado"] = _vchEstado;
                                        dtrError["vchPais"] = _vchPais;
                                        dtrError["vchEmail"] = _vchEmail;
                                        dtrError["vchTelefono"] = _vchTelefono;
                                        dtrError["vchTelefono_2"] = _vchTelefono_2;
                                        dtrError["vchRFC"] = _vchRFC;
                                        dtrError["vchLimiteCredito"] = _vchLimiteCredito;
                                        dtrError["intDiasCredito"] = _DiasCredito;
                                        dtrError["vchNoCuenta"] = _vchNoCuenta;
                                        dtrError["bBloqueoCliente"] = _bBloqueoCliente;
                                        dtrError["vchMotivoBloqueo"] = _vchMotivoBloqueo;
                                        dtrError["bClienteExportacion"] = _bClienteExportacion;
                                        dtrError["intCostoFactuacion"] = _intCostoFactuacion;
                                        dtrError["flDescuento"] = _flDescuento;
                                        dtrError["vchComentarios"] = _vchComentarios;
                                        dtrError["bActivo"] = _bActivo;

                                        dtbDatos.Rows.Add(dtrError);
                                        dgv_Productos.DataSource = dtbDatos;
                                    }
                                }
                            }
                            vuelta++;
                        }
                    }
                    catch (Exception ex) { }
                    srLeer.Close();
                }
                MessageBox.Show("Proceso terminado archivo cargado", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargando.Close();
            }
            #endregion
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (txtRuta.Text == "")
            {
                MessageBox.Show("Es necesario ingresar el archivo y su ruta", "ERROR DE CARGA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                /* Validamos el tipo de documento a cargar */
                char tipo = Convert.ToChar(comboBox1.SelectedValue.ToString());

                switch (tipo)
                {
                    case '1': //CLIENTE
                        Guardar_Cliente();
                        break;
                    case '2': //PROVEEDOR
                        Console.WriteLine("Excellent!");
                        break;
                    case '3': //PRODUCTO
                        Guardar_Producto();
                        break;
                    case '4': //GRUPO
                        Console.WriteLine("Excellent!");
                        break;
                    case '5': //DEPARTAMENTO
                        Console.WriteLine("Excellent!");
                        break;
                    default:
                        break;
                }
            }
        }

        private void Guardar_Producto()
        {
            UcSplashScreen cargando = new UcSplashScreen("", "... Registrando Productos ... ");

            foreach (DataGridViewRow drvDatos in dgv_Productos.gvGrid.Rows)
            {
                try
                {
                    cargando.Show();
                    cargando.Refresh();

                    //_mCele.IdEmpresa = Convert.ToInt32(drvDatos.Cells[0].Value.ToString());

                    _mInventario.vchClaveProducto = drvDatos.Cells[0].Value.ToString();
                    _mInventario.vchNombre = drvDatos.Cells[1].Value.ToString();
                    _mInventario.UM_Venta = drvDatos.Cells[2].Value.ToString();
                    _mInventario.flt_PrecioVenta_1 = float.Parse(drvDatos.Cells[3].Value.ToString());
                    _mInventario.flt_PrecioVenta_2 = float.Parse(drvDatos.Cells[4].Value.ToString());
                    _mInventario.flt_PrecioVenta_3 = float.Parse(drvDatos.Cells[5].Value.ToString());
                    _mInventario.intAccionProducto = 7;

                    DataSet dsProducto = _mInventario.dsCatalogoProducto();

                    if (dsProducto.Tables[0].Rows.Count > 0)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Proceso NO realizado...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                }
            }

            MessageBox.Show("¡Empresas registradas!", "EXITO - REGISTRO PRODUCTOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cargando.Close();
            this.Close();
        }

        private void Guardar_Cliente()
        {
            UcSplashScreen cargando = new UcSplashScreen("", "... Registrando Clientes ... ");
            bool bandera = false; 

            foreach (DataGridViewRow drvDatos in dgv_Productos.gvGrid.Rows)
            {
                try
                {
                    cargando.Show();
                    cargando.Refresh();

                    //_mCele.IdEmpresa = Convert.ToInt32(drvDatos.Cells[0].Value.ToString());

                    _mInventario.Id_Cliente = Convert.ToInt32(drvDatos.Cells[0].Value.ToString());
                    _mInventario.vchConsecutivo_PV = drvDatos.Cells[1].Value.ToString();
                    _mInventario.vchContacto = drvDatos.Cells[2].Value.ToString();
                    _mInventario.vchNombreCliente = drvDatos.Cells[3].Value.ToString();
                    _mInventario.vchCalle = drvDatos.Cells[4].Value.ToString();
                    _mInventario.vchNoExterior = drvDatos.Cells[5].Value.ToString();
                    _mInventario.vchNoInterior = drvDatos.Cells[6].Value.ToString();
                    _mInventario.vchColonia = drvDatos.Cells[7].Value.ToString();
                    _mInventario.vchCiudad = drvDatos.Cells[8].Value.ToString();
                    _mInventario.vchCodigoPostal = drvDatos.Cells[9].Value.ToString();
                    _mInventario.vchMunicipio = drvDatos.Cells[10].Value.ToString();
                    _mInventario.vchEstado = drvDatos.Cells[11].Value.ToString();
                    _mInventario.vchPais = drvDatos.Cells[12].Value.ToString();
                    _mInventario.vchEmail = drvDatos.Cells[13].Value.ToString();
                    _mInventario.vchTelefono = drvDatos.Cells[14].Value.ToString();
                    _mInventario.vchTelefono_2 = drvDatos.Cells[15].Value.ToString();
                    _mInventario.vchRFC = drvDatos.Cells[16].Value.ToString();
                    _mInventario.vchLimiteCredito = drvDatos.Cells[17].Value.ToString();
                    _mInventario.intDiasCredito = Convert.ToInt32(drvDatos.Cells[18].Value.ToString());
                    _mInventario.vchNoCuenta = drvDatos.Cells[19].Value.ToString();
                    _mInventario.bBloqueoCliente = false; 
                    _mInventario.vchMotivoBloqueo = drvDatos.Cells[21].Value.ToString();
                    _mInventario.bClienteExportacion = false;
                    _mInventario.intCostoFactuacion = Convert.ToInt32(drvDatos.Cells[23].Value.ToString());
                    _mInventario.flDescuento = float.Parse(drvDatos.Cells[24].Value.ToString());
                    _mInventario.vchComentarios = drvDatos.Cells[25].Value.ToString();
                    _mInventario.intAccionCliente = 1; 

                    DataSet dsProducto = _mInventario.dsCatalogoClientes();

                    if (dsProducto.Tables[0].Rows.Count > 0)
                    {
                        _mInventario.strConsecutivoPV = drvDatos.Cells[1].Value.ToString();
                        DataSet dsConsecutivoPV = _mInventario.dsBitacoraRegistroCliente();

                        if (dsConsecutivoPV.Tables[0].Rows.Count > 0)
                        {
                            bandera = true; 
                        }
                    }
                    else
                    {
                        MessageBox.Show("Proceso NO realizado...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Proceso NO realizado...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cargando.Close();
                    bandera = false;
                    break; 
                    //MessageBox.Show(ex.ToString());
                }
            }

            if (bandera == true)
            {
                MessageBox.Show("¡Empresas registradas!", "EXITO - REGISTRO PRODUCTOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargando.Close();
                this.Close();
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            CargarTipoDocumento();
        }
    }
}
