namespace AppElyonCXC.Administracion
{
    partial class FrmEstadoCuenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtidCliente = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblTelefonoSel = new System.Windows.Forms.Label();
            this.lblCorreoSel = new System.Windows.Forms.Label();
            this.lblrfcSel = new System.Windows.Forms.Label();
            this.lblNombreSel = new System.Windows.Forms.Label();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnBuscaCliente = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ucGridNotasCredito = new AppElyonCXC.UcGrid();
            this.ucGridDevoluciones = new AppElyonCXC.UcGrid();
            this.SuspendLayout();
            // 
            // txtidCliente
            // 
            this.txtidCliente.Location = new System.Drawing.Point(360, 145);
            this.txtidCliente.Multiline = true;
            this.txtidCliente.Name = "txtidCliente";
            this.txtidCliente.Size = new System.Drawing.Size(90, 24);
            this.txtidCliente.TabIndex = 15;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(64)))), ((int)(((byte)(9)))));
            this.btnLimpiar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(854, 11);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(112, 52);
            this.btnLimpiar.TabIndex = 14;
            this.btnLimpiar.Text = "&Limpiar";
            this.toolTip1.SetToolTip(this.btnLimpiar, "Limpiar Pantalla");
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblTelefonoSel
            // 
            this.lblTelefonoSel.AutoSize = true;
            this.lblTelefonoSel.BackColor = System.Drawing.Color.Transparent;
            this.lblTelefonoSel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefonoSel.Location = new System.Drawing.Point(474, 183);
            this.lblTelefonoSel.Name = "lblTelefonoSel";
            this.lblTelefonoSel.Size = new System.Drawing.Size(101, 19);
            this.lblTelefonoSel.TabIndex = 13;
            this.lblTelefonoSel.Text = "... Telefono ... ";
            // 
            // lblCorreoSel
            // 
            this.lblCorreoSel.AutoSize = true;
            this.lblCorreoSel.BackColor = System.Drawing.Color.Transparent;
            this.lblCorreoSel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreoSel.Location = new System.Drawing.Point(652, 183);
            this.lblCorreoSel.Name = "lblCorreoSel";
            this.lblCorreoSel.Size = new System.Drawing.Size(84, 19);
            this.lblCorreoSel.TabIndex = 12;
            this.lblCorreoSel.Text = "... Correo ...";
            // 
            // lblrfcSel
            // 
            this.lblrfcSel.AutoSize = true;
            this.lblrfcSel.BackColor = System.Drawing.Color.Transparent;
            this.lblrfcSel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrfcSel.Location = new System.Drawing.Point(289, 183);
            this.lblrfcSel.Name = "lblrfcSel";
            this.lblrfcSel.Size = new System.Drawing.Size(66, 19);
            this.lblrfcSel.TabIndex = 11;
            this.lblrfcSel.Text = "... RFC ...";
            // 
            // lblNombreSel
            // 
            this.lblNombreSel.AutoSize = true;
            this.lblNombreSel.BackColor = System.Drawing.Color.Transparent;
            this.lblNombreSel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreSel.Location = new System.Drawing.Point(665, 146);
            this.lblNombreSel.Name = "lblNombreSel";
            this.lblNombreSel.Size = new System.Drawing.Size(92, 19);
            this.lblNombreSel.TabIndex = 10;
            this.lblNombreSel.Text = "... Nombre ...";
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.btnCargar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.ForeColor = System.Drawing.Color.White;
            this.btnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargar.Location = new System.Drawing.Point(497, 140);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(83, 34);
            this.btnCargar.TabIndex = 9;
            this.btnCargar.Text = "&Cargar";
            this.toolTip1.SetToolTip(this.btnCargar, "Cargar Informacio Cliente");
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnBuscaCliente
            // 
            this.btnBuscaCliente.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscaCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscaCliente.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscaCliente.ForeColor = System.Drawing.Color.White;
            this.btnBuscaCliente.Image = global::AppElyonCXC.Properties.Resources.search_26;
            this.btnBuscaCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscaCliente.Location = new System.Drawing.Point(463, 144);
            this.btnBuscaCliente.Name = "btnBuscaCliente";
            this.btnBuscaCliente.Size = new System.Drawing.Size(29, 26);
            this.btnBuscaCliente.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnBuscaCliente, "Buscar Clientes");
            this.btnBuscaCliente.UseVisualStyleBackColor = false;
            this.btnBuscaCliente.Click += new System.EventHandler(this.btnBuscaCliente_Click);
            // 
            // ucGridNotasCredito
            // 
            this.ucGridNotasCredito.bFiltro = true;
            this.ucGridNotasCredito.DataSource = null;
            this.ucGridNotasCredito.Location = new System.Drawing.Point(496, 270);
            this.ucGridNotasCredito.Name = "ucGridNotasCredito";
            this.ucGridNotasCredito.Size = new System.Drawing.Size(445, 283);
            this.ucGridNotasCredito.strTitulo = null;
            this.ucGridNotasCredito.TabIndex = 11;
            // 
            // ucGridDevoluciones
            // 
            this.ucGridDevoluciones.bFiltro = true;
            this.ucGridDevoluciones.DataSource = null;
            this.ucGridDevoluciones.Location = new System.Drawing.Point(39, 270);
            this.ucGridDevoluciones.Name = "ucGridDevoluciones";
            this.ucGridDevoluciones.Size = new System.Drawing.Size(445, 283);
            this.ucGridDevoluciones.strTitulo = null;
            this.ucGridDevoluciones.TabIndex = 10;
            // 
            // FrmEstadoCuenta
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::AppElyonCXC.Properties.Resources.Estado_de_Cuenta__1___1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1084, 697);
            this.Controls.Add(this.lblCorreoSel);
            this.Controls.Add(this.lblTelefonoSel);
            this.Controls.Add(this.txtidCliente);
            this.Controls.Add(this.ucGridNotasCredito);
            this.Controls.Add(this.lblNombreSel);
            this.Controls.Add(this.lblrfcSel);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.ucGridDevoluciones);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.btnBuscaCliente);
            this.Name = "FrmEstadoCuenta";
            this.Text = "FrmEstadoCuenta";
            this.Load += new System.EventHandler(this.FrmEstadoCuenta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBuscaCliente;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Label lblTelefonoSel;
        private System.Windows.Forms.Label lblCorreoSel;
        private System.Windows.Forms.Label lblrfcSel;
        private System.Windows.Forms.Label lblNombreSel;
        private System.Windows.Forms.Button btnLimpiar;
        private UcGrid ucGridDevoluciones;
        private UcGrid ucGridNotasCredito;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtidCliente;
    }
}