using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace AppElyonCXC
{
    public partial class UcGrid : UserControl
    {
        #region Variables Globales
        DataTable datasource;
        string _strTitulo;
        Dictionary<string, string> Filtro;
        public List<string> BusquedaDirecta = new List<string>();
        public Boolean bAgregarFilto = true;
        public Boolean likeNumerico = false;
        public Boolean filtroBool = false;
        int _intExcel = 0;
        int _intPDF = 0;
        Microsoft.Office.Interop.Excel.Range oRng;
        #endregion Variables Globales

        #region Propiedades        
        public bool bFiltro
        {
            get { return bAgregarFilto; }
            set
            {
                bAgregarFilto = value;
                txtGrid.Visible = bAgregarFilto;
            }
        }
        public string strTitulo
        {
            get { return _strTitulo; }
            set { _strTitulo = value; }
        }
        public DataTable DataSource
        {
            get
            {
                try
                {
                    return (DataTable)gvGrid.DataSource;
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                if (value == null)
                {                    
                    gvGrid.DataSource = null;
                    lbltotReg.Text = "0 / 0";
                }
                else
                {
                    try
                    {
                        lbltotReg.Text = "";
                        datasource = value;
                        Filtro = new Dictionary<string, string>();
                        gvGrid.DataSource = datasource;                                                                                               
                        lbltotReg.Text = datasource.Rows.Count.ToString() + " / " +
                        datasource.Rows.Count.ToString();
                    }
                    catch
                    {
                    }
                }
            }
        }
        #endregion Propiedades

        #region Constructor
        public UcGrid()
        {
            InitializeComponent();
        }
        #endregion Constructor

        private void txtGrid_TextChanged(object sender, EventArgs e)
        {
            if (datasource != null)
            {
                tmrDebounce.Enabled = true;
                tmrDebounce.Stop();
                tmrDebounce.Interval = 1500;
                tmrDebounce.Start();
            }
        }

        #region Crear Eventos
        // EVENTO GRIDDATOS MOSTRAR
        public class gvGrid_MostrarEnventArgs : EventArgs { }
        public delegate void gvGrid_MostrarEventHandler(object sender, gvGrid_MostrarEnventArgs e);
        public event gvGrid_MostrarEventHandler gvGrid_Mostrar;
        protected virtual void OnGridDatos_Mostrar(gvGrid_MostrarEnventArgs e)
        {
            if (gvGrid_Mostrar != null)
            {
                gvGrid_Mostrar(this, e);
            }
        }
        // EVENTO GRIDDATOS SELECCION CAMBIA
        public event System.EventHandler OnSeleccionCambia;
        // EVENTO GRIDDATOS CONTENIDO CLICK
        public event System.EventHandler OnContenido_Click;
        // EVENTO GRIDDATOS CONTENIDO CLICK
        public event System.Windows.Forms.KeyPressEventHandler OnKey_Press;
        // EVENTO GRIDDATOS DOUBLE CLICK
        public class gvGrid_DoubleClickEnventArgs : EventArgs { }
        public delegate void gvGrid_DoubleClickEventHandler(object sender, gvGrid_DoubleClickEnventArgs e);
        public event gvGrid_DoubleClickEventHandler GvGrid_DoubleClick;

        public event DataGridViewCellEventHandler OnCellValueChanged_Click;        
        public event DataGridViewCellValueEventHandler OnCellValueNeeded_Click;
        public event System.EventHandler OnCurrentCellDirtySTCgd_Click;

        protected virtual void OnGridDatos_DoubleClick(gvGrid_DoubleClickEnventArgs e)
        {
            if (GvGrid_DoubleClick != null)
            {
                GvGrid_DoubleClick(this, e);
            }
        }        
                      
        public event DataGridViewCellEventHandler cell_Datagrid_DoubleClick;
        public event DataGridViewCellEventHandler cell_Datagrid_ContentClick;
        public event DataGridViewCellEventHandler cell_Datagrid_ContentDoubleClick;
        // EVENTO DATAGRID END EDIT
        public event DataGridViewCellEventHandler DataGrid_CellEndEdit;
        // EVENTO DATAGRID DATA ERROR
        public event DataGridViewDataErrorEventHandler DataGrid_DataError;
        public event DataGridViewCellMouseEventHandler DataGrid_ColumnHeaderMC;
        public event DataGridViewCellMouseEventHandler DataGrid_ColumnHeaderMDC;
        #endregion Crear Eventos

        #region Eventos del UserControl
        private void gvGrid_SelectionChanged(object sender, EventArgs e)
        {
            OnGridDatos_Mostrar(new gvGrid_MostrarEnventArgs());
            if (OnSeleccionCambia != null)
            {
                OnSeleccionCambia(null, null);
            }
        }

        private void gvGrid_DoubleClick(object sender, EventArgs e)
        {
            OnGridDatos_DoubleClick(new gvGrid_DoubleClickEnventArgs());
        }

        private void gvGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (OnContenido_Click != null)
            {
                OnContenido_Click(sender, e);
            }
        }

        private void gvGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                OnKey_Press(sender, e);
            }
            catch { }
        }
       
        private void gvGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cell_Datagrid_DoubleClick != null)
            {
                cell_Datagrid_DoubleClick(sender, e);
            }
        }

        private void gvGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cell_Datagrid_ContentDoubleClick != null)
            {
                cell_Datagrid_ContentDoubleClick(sender, e);
            }
        }

        private void gvGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGrid_CellEndEdit != null)
                DataGrid_CellEndEdit(sender, e);
        }

        private void gvGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (DataGrid_DataError != null)
                DataGrid_DataError(sender, e);
        }

        private void gvGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DataGrid_ColumnHeaderMC != null)
                DataGrid_ColumnHeaderMC(sender, e);
        }

        private void gvGrid_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DataGrid_ColumnHeaderMDC != null)
                DataGrid_ColumnHeaderMDC(sender, e);
        }
        private void gvGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (OnCurrentCellDirtySTCgd_Click != null)
            {
                OnCurrentCellDirtySTCgd_Click(sender, e);
            }
        }
        private void gvGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (OnCellValueChanged_Click != null)
            {
                OnCellValueChanged_Click(sender, e);
            }
        }
        private void gvGrid_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (OnCellValueNeeded_Click != null)
            {
                OnCellValueNeeded_Click(sender, e);
            }
        }
        #endregion Eventos del UserControl
        public void Recargar()
        {
            DataSource = datasource;
        }             
        
        public void ExportarExcel(DataSet dtsDatos, string strTitulo, string strFileName)
        {
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            

            try
            {

                worksheet = workbook.ActiveSheet;
                int i = 0;
                worksheet.Name = strTitulo;

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //i Inicia en -1 para que tome la primera linea.
                //Loop through each row and read value from each column. 
                pgb.Visible = true;
                pgb.Maximum = gvGrid.Rows.Count;
                for (i =-1; i < gvGrid.Rows.Count ; i++)
                {
                    for (int j = 0; j < gvGrid.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = gvGrid.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = gvGrid.Rows[i].Cells[j].Value.ToString();

                            //oRng = worksheet.get_Range("A" + cellRowIndex, "D" + cellColumnIndex);
                            //oRng.NumberFormat = "@";
                            //oRng = worksheet.get_Range("F" + cellRowIndex, "I" + cellColumnIndex);
                            //oRng.NumberFormat = "@";
                        }
                        cellColumnIndex++;                       
                    }
                    cellColumnIndex = 1;
                   
                    cellRowIndex++;
                    if (i < pgb.Minimum)
                    {
                        pgb.Minimum = 1;
                    }
                    else
                    {
                        pgb.Value = i;
                    }
                }
                pgb.Visible = false;
                workbook.SaveAs(strFileName);
               
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                _intExcel = 1;
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }

        }
      
        public void ExportarPDF(DataSet dtsDatos)
        {
           
                Reportes.Reportes RP = new Reportes.Reportes();

                RP.GenerarReporte(dtsDatos, _strTitulo);
           
        }

        private void EETSMenu_Click(object sender, EventArgs e)
        {
            #region EXCEL
            _intExcel = 0;
            try
            {

                string filePath;

                SaveFileDialog dlCarpeta = new SaveFileDialog();
                dlCarpeta.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                if (dlCarpeta.ShowDialog() == DialogResult.OK)
                {


                    filePath = dlCarpeta.FileName.ToString();
                    string result = filePath.Substring(filePath.LastIndexOf("\\") + 1);

                    DataTable dt = gvGrid.DataSource as DataTable;
                    DataSet dtsExcel = new DataSet();
                    dtsExcel.Tables.Add(dt.Copy());
                    //poner try
                    if (dtsExcel == null)
                        MessageBox.Show("No hay datos por mostrar. Favor de verificar", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                    {
                        ExportarExcel(dtsExcel, result, filePath);
                        if (_intExcel == 1)
                        {
                            MessageBox.Show("No se pudo generar el archivo", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("El archivo se generó correctamente en la siguiente ruta: " + filePath, "Generación Exitosa!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("No se pudo generar el archivo debido al siguiente error: " + ex.Message, "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #endregion
        }

        private void EPTSMenu_Click(object sender, EventArgs e)
        {
            #region PDF
            try
            {
                DataTable dt = gvGrid.DataSource as DataTable;
                DataSet dtsExcel = new DataSet();
                dtsExcel.Tables.Add(dt.Copy());
                //poner try
                if (dtsExcel == null)
                    MessageBox.Show("No hay datos por mostrar. Favor de verificar", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    ExportarPDF(dtsExcel);
                    if (_intPDF == 1)
                    {
                        MessageBox.Show("No se pudo generar el archivo", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("El archivo se generó correctamente ", "Generación Exitosa!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("No se pudo generar el archivo debido al siguiente error: " + ex.Message, "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #endregion
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void opcionesTSMItem_Click(object sender, EventArgs e)
        {

        }

        private void tmrDebounce_Tick(object sender, EventArgs e)
        {
            tmrDebounce.Stop();
            tmrDebounce.Interval = 1000000;
            tmrDebounce.Enabled = false;
            if (datasource != null)
            {
                int total = datasource.Columns.Count;
                string strSort = "";
                string NombreCol;
                int paso = 0;
                string str1 = "";
                string str2 = "";
                string strWhere = "";
                DataTable dtFilUsu = datasource.Clone();
                string totalFilas = datasource.Rows.Count.ToString();

                if (txtGrid.Text.Contains("&"))
                {
                    string[] strFil = txtGrid.Text.Split('&').ToArray();

                    for (int j = 0; j < strFil.Length; j++)
                    {
                        for (int i = 0; i <= (total - 1); i++)
                        {
                            #region ARMA FILTRO
                            if (paso == 0)
                            {
                                NombreCol = "[" + datasource.Columns[i].ColumnName + "]";

                                if (datasource.Columns[i].DataType.FullName != "System.String")
                                {
                                    if (j == 0)
                                    {
                                        strSort += @"" + NombreCol;
                                    }
                                    str1 = @"(CONVERT(" + NombreCol + ", 'System.String') like '%" + strFil[j].Trim();
                                    paso++;
                                }
                                else
                                {
                                    if (j == 0)
                                    {
                                        strSort += @"" + NombreCol;
                                    }
                                    str1 = @"(" + NombreCol + " like '%" + strFil[j].Trim();
                                    paso++;
                                }
                            }
                            else
                            {
                                if (datasource.Columns[i].DataType.FullName != "System.String")
                                {
                                    str1 = "";
                                    NombreCol = "[" + datasource.Columns[i].ColumnName + "]";
                                    if (j == 0)
                                    {
                                        strSort += "," + NombreCol;
                                    }
                                    str2 = "%' OR CONVERT(" + NombreCol + ", 'System.String') like '%" + strFil[j].Trim();
                                }
                                else
                                {
                                    str1 = "";
                                    NombreCol = "[" + datasource.Columns[i].ColumnName + "]";
                                    if (j == 0)
                                    {
                                        strSort += "," + NombreCol;
                                    }
                                    str2 = "%' OR " + NombreCol + " like '%" + strFil[j].Trim();
                                }
                            }

                            if (i == (total - 1) && j == strFil.Length - 1)
                            {
                                if (j == strFil.Length - 1)
                                {
                                    strWhere += str1.Trim() + str2.Trim() + "%'" + ")" + @"";
                                }
                                strSort += @"";
                            }
                            else
                            {
                                strWhere += str1.Trim() + str2.Trim();
                            }
                            #endregion ARMA FILTRO
                        }
                    }
                    DataRow[] drFil = datasource.Select(strWhere, strSort);


                    foreach (DataRow drNuevo in drFil)
                        dtFilUsu.ImportRow(drNuevo);

                    lbltotReg.Text = dtFilUsu.Rows.Count.ToString() + " / " + totalFilas;
                }
                else
                {
                    for (int i = 0; i <= (total - 1); i++)
                    {
                        //Solo filtra por campos String
                        #region ARMA FILTRO
                        if (paso == 0)
                        {
                            NombreCol = "[" + datasource.Columns[i].ColumnName + "]";

                            if (datasource.Columns[i].DataType.FullName != "System.String")
                            {
                                strSort += @"" + NombreCol;
                                str1 = @"(CONVERT(" + NombreCol + ", 'System.String') like '%" + txtGrid.Text.Trim();
                                paso++;
                            }
                            else
                            {
                                strSort += @"" + NombreCol;
                                str1 = @"(" + NombreCol + " like '%" + txtGrid.Text.Trim();
                                paso++;
                            }
                        }
                        else
                        {
                            if (datasource.Columns[i].DataType.FullName != "System.String")
                            {
                                str1 = "";
                                NombreCol = "[" + datasource.Columns[i].ColumnName + "]";
                                strSort += "," + NombreCol;
                                str2 = "%' OR CONVERT(" + NombreCol + ", 'System.String') like '%" + txtGrid.Text.Trim();
                            }
                            else
                            {
                                str1 = "";
                                NombreCol = "[" + datasource.Columns[i].ColumnName + "]";
                                strSort += "," + NombreCol;
                                str2 = "%' OR " + NombreCol + " like '%" + txtGrid.Text.Trim();
                            }
                        }

                        if (i == (total - 1))
                        {
                            strWhere += str1.Trim() + str2.Trim() + "%'" + ")" + @"";
                            strSort += @"";
                        }
                        else
                        {
                            strWhere += str1.Trim() + str2.Trim();
                        }
                        #endregion ARMA FILTRO
                    }
                    DataRow[] drFil = datasource.Select(strWhere, strSort);


                    foreach (DataRow drNuevo in drFil)
                        dtFilUsu.ImportRow(drNuevo);
                    
                    lbltotReg.Text = dtFilUsu.Rows.Count.ToString() + " / " + totalFilas;
                }

                gvGrid.DataSource = dtFilUsu;
            }
        }
    }
}
