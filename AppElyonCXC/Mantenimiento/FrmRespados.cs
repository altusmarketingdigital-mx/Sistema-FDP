using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
//using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Server;
//using Microsoft.SqlServer.Management.Smo.RegisteredServers;
//using Microsoft.SqlServer.Management.Common;
using System.Management;

namespace AppElyonCXC.Mantenimiento
{
    public partial class FrmRespados : Form
    {
        //#region CONEXIONES 
        //ElyonModelCxC.mCxC _mSeguridad = new ElyonModelCxC.mCxC(Properties.Settings.Default.strConexionM, Properties.Settings.Default.UrlSeguridad);
        //#endregion

        ////Agregar estas Referencias.
        ////1.- Microsoft.SqlServer.ConnectionInfo.dll
        ////2.- Microsoft.SqlServer.Smo.dll
        ////3.- Microsoft.SqlServer.SmoEnum.dll
        ////4.- EN .NET alli busca el System.Managment 

        //// inicializacion del servidor
        //// . es para servidor local

        ////Server servidor = new Server(@".\SQLEXPRESS");


        ////Variables       
        //private static Server srvr;
        //DataTable dtServers = new DataTable();
        //string NombreMensaje = "";       
        //string strUsuario = "";
        //public string cnString = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
        //private SqlConnection conConexion;

        ////Variables
        //string NivelSeguridad;
        //int UsuarioID;
        //string strKeyNivelSeguridad = "0";
        //int Perfil = 0;
        //string MensajeProceso = "";
        //string _strConexionAdmin = "";
        //string _strConexion = "";
        //string strKeyMenu = "0";
        //bool regresa = false;
        //string SiglasProceso = "";
        //private int EstMenu;
        //int intValida = 0;
        //DataSet dsDatos = new DataSet();
        //int busqueda = 0;
        //public FrmRespados()
        //{
        //    InitializeComponent();
        //}
        //public FrmRespados(DataSet dsParam)
        //{
        //    InitializeComponent();

        //    dsDatos = dsParam;
        //    if (dsDatos.Tables[0].Rows.Count > 0)
        //    {
        //        UsuarioID = int.Parse(dsDatos.Tables["Parametros"].Rows[0][0].ToString());
        //        NivelSeguridad = dsDatos.Tables["Parametros"].Rows[0][1].ToString();
        //        MensajeProceso = dsDatos.Tables["Parametros"].Rows[0][2].ToString();
        //        _strConexion = dsDatos.Tables["Parametros"].Rows[0][3].ToString();
        //        _mSeguridad.strConexion = _strConexion;
        //    }
        //}
        //private void FrmRespados_Load(object sender, EventArgs e)
        //{
        //    this.Text = MensajeProceso;                      
        //}
        //private void psServidores()
        //{
        //    this.cboServidor.Items.Clear();

        //    // If there are any servers
        //    if (dtServers.Rows.Count > 0)
        //    {
        //        // Loop through each server in the DataTable
        //        foreach (DataRow drServer in dtServers.Rows)
        //        {
        //            cboServidor.Items.Add(drServer["Name"]);
        //            //cboServidor.Text = Convert.ToString(drServer["Name"]);
        //        }
        //    }

        //    //foreach (RegisteredServer srvServidor in SmoApplication.SqlServerRegistrations.EnumRegisteredServers())
        //    //{
        //    //    this.cboServidor.Items.Add(srvServidor.Name);
        //    //}
           
        //}
        //private void CargaDB(string Server)
        //{
        //    if (Server != "")
        //    {
        //        Server servidor = new Server(Server);

        //        //if (this.cboServidor.Items.Count > 0)
        //        //    this.cboServidor.SelectedIndex = 0;

        //        try
        //        {
        //            cboBD.Text = null;
        //            cboBD.Items.Clear();
        //            foreach (Database db in servidor.Databases)
        //            {
        //                if (!db.IsSystemObject) // Las BD del Sistema NO las contemplamos
        //                {
        //                    if (db.Name == "ELYON_dbPermisos" || db.Name == "ELYON_Finanzas")
        //                        cboBD.Items.Add(db.Name);
        //                }
        //            }
        //        }
        //        catch (Exception ex) { }
        //    }
        //}


        //private void btnExaminar_Click(object sender, EventArgs e)
        //{
        //    //FolderBrowserDialog dlgDestino = new FolderBrowserDialog();

        //    //dlgDestino.Description = "Seleccione el directorio de destino";

        //    //if (dlgDestino.ShowDialog() == DialogResult.OK)
        //    //{
        //    //    string strDestino = dlgDestino.SelectedPath.ToString();
        //    //    this.txtDestino.Text = strDestino + "\\";
        //    //}

        //    OpenFileDialog dlCarpeta = new OpenFileDialog();
        //    if (dlCarpeta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        this.txtDestino.Text = dlCarpeta.FileName;
        //    }
        //}

        //private void btnRespaldar_Click(object sender, EventArgs e)
        //{
        //    if (this.cboBD.Text.Trim() != "" && txtDestino.Text.Trim() != "")
        //    {                                
        //        string cnx = @"data source=" + this.cboServidor.Text + ";initial catalog=" + this.cboBD.Text + ";user id=Programmer" + ";password =Pr0gr4mm3rUs3r" + ";Connection Timeout=8000";
        //        conConexion = new SqlConnection(cnx);

        //        this.txtDestino.Text = @"C:\Program Files\Microsoft SQL Server\MSSQL13.JORGE\MSSQL\Backup\Jorge\";
        //        string DBFull = "N" + "'" + this.cboBD.Text + "-Full Database Backup'";
                
        //        try
        //        {
        //            string fecha = DateTime.Now.ToShortDateString();
        //            fecha = fecha.Substring(0, 2) + fecha.Substring(3, 2) + fecha.Substring(6, 4);
        //            string strNombreRespaldo = "BD_" + this.cboBD.Text + fecha + ".bak";
        //            conConexion.Open();
        //            SqlCommand cmdSQL = new SqlCommand("BACKUP DATABASE [" + this.cboBD.Text + "] TO DISK='" + txtDestino.Text + strNombreRespaldo + "'"
        //                + " WITH NOFORMAT, NOINIT, NAME = " + DBFull + "," + "SKIP, NOREWIND, NOUNLOAD,  STATS = 10", conConexion);
        //            cmdSQL.CommandTimeout = 0;
        //            cmdSQL.ExecuteNonQuery();

        //            MessageBox.Show("Respaldo " + strNombreRespaldo + " creado correctamente.", "SQL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error al tratar de crear el .bak", "SQL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        finally
        //        {
        //            conConexion.Close();
        //        }
        //    }
        //    else
        //    {
        //        if (this.cboBD.Text == "")
        //        {
        //            if (this.cboServidor.Text != "")
        //            {
        //                MessageBox.Show("Por favor, conéctese al servidor", "SQL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Especifique el destino del respaldo.", "SQL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            this.btnExaminar.Focus();
        //        }
        //    }
        //}

        //private void btnRestore_Click(object sender, EventArgs e)
        //{            
        //    this.btnRestore.Enabled = false;
        //    this.btnRestore.Text = "Restaurando...";
        //    this.btnRestore.Refresh();

        //    string sBackup = "RESTORE DATABASE " + cboBD.Text +
        //                     " FROM DISK = '" + this.txtDestino.Text + "'" +
        //                     " WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 5";

        //    SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
        //    csb.DataSource = this.cboServidor.Text;
        //    // Es mejor abrir la conexión con la base Master
        //    csb.InitialCatalog = "master";
        //    csb.IntegratedSecurity = true;
        //    //csb.ConnectTimeout = 480; // el predeterminado es 15

        //    using (SqlConnection con = new SqlConnection(csb.ConnectionString))
        //    {
        //        try
        //        {
        //            con.Open();

        //            SqlCommand cmdBackUp = new SqlCommand(sBackup, con);
        //            cmdBackUp.ExecuteNonQuery();
        //            MessageBox.Show("Se ha restaurado la copia de la base de datos.",
        //                            "Restaurar base de datos",
        //                            MessageBoxButtons.OK,
        //                            MessageBoxIcon.Information);

        //            con.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message,
        //                            "Error al restaurar la base de datos",
        //                            MessageBoxButtons.OK,
        //                            MessageBoxIcon.Error);
        //        }
        //    }

        //    this.btnRestore.Text = "Restaurar";
        //    this.btnRestore.Enabled = true;
        //    this.btnRestore.Refresh();
        //}

        //private void btncargaSql_Click(object sender, EventArgs e)
        //{
        //    dtServers = SmoApplication.EnumAvailableSqlServers(false);
        //    this.psServidores();
        //}

        //private void cboServidor_SelectedIndexChanged(object sender, EventArgs e)
        //{
           
        //    CargaDB(cboServidor.Text);
        //}

        //private void cboServidor_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)13)
        //    {
        //        CargaDB(cboServidor.Text);
        //    }
        //}
    }
}
