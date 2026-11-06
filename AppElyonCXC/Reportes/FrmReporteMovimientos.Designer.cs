namespace AppElyonCXC.Reportes
{
    partial class FrmReporteMovimientos
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkGrid = new System.Windows.Forms.CheckBox();
            this.btnBuscaCliente = new System.Windows.Forms.Button();
            this.btngenerar = new System.Windows.Forms.Button();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbMovimiento = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ucGridMov = new AppElyonCXC.UcGrid();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(254, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowCloseButton = false;
            this.crystalReportViewer1.ShowCopyButton = false;
            this.crystalReportViewer1.ShowGotoPageButton = false;
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.ShowLogo = false;
            this.crystalReportViewer1.ShowParameterPanelButton = false;
            this.crystalReportViewer1.ShowRefreshButton = false;
            this.crystalReportViewer1.ShowTextSearchButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(830, 697);
            this.crystalReportViewer1.TabIndex = 7;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkGrid);
            this.panel1.Controls.Add(this.btnBuscaCliente);
            this.panel1.Controls.Add(this.btngenerar);
            this.panel1.Controls.Add(this.txtTipo);
            this.panel1.Controls.Add(this.lblTipo);
            this.panel1.Controls.Add(this.cmbMovimiento);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 697);
            this.panel1.TabIndex = 6;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(9)))));
            this.btnLimpiar.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(129, 474);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(113, 48);
            this.btnLimpiar.TabIndex = 35;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Image = global::AppElyonCXC.Properties.Resources.logo_frutería_1_;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 181);
            this.label1.TabIndex = 34;
            // 
            // chkGrid
            // 
            this.chkGrid.AutoSize = true;
            this.chkGrid.Font = new System.Drawing.Font("Franklin Gothic Book", 12F);
            this.chkGrid.Location = new System.Drawing.Point(15, 341);
            this.chkGrid.Name = "chkGrid";
            this.chkGrid.Size = new System.Drawing.Size(126, 25);
            this.chkGrid.TabIndex = 32;
            this.chkGrid.Text = "Generar a Grid";
            this.chkGrid.UseVisualStyleBackColor = true;
            // 
            // btnBuscaCliente
            // 
            this.btnBuscaCliente.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscaCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscaCliente.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscaCliente.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBuscaCliente.Image = global::AppElyonCXC.Properties.Resources.search_26;
            this.btnBuscaCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscaCliente.Location = new System.Drawing.Point(159, 299);
            this.btnBuscaCliente.Name = "btnBuscaCliente";
            this.btnBuscaCliente.Size = new System.Drawing.Size(41, 32);
            this.btnBuscaCliente.TabIndex = 31;
            this.btnBuscaCliente.UseVisualStyleBackColor = false;
            this.btnBuscaCliente.Click += new System.EventHandler(this.btnBuscaCliente_Click);
            // 
            // btngenerar
            // 
            this.btngenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(103)))), ((int)(((byte)(102)))));
            this.btngenerar.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngenerar.ForeColor = System.Drawing.Color.White;
            this.btngenerar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btngenerar.Location = new System.Drawing.Point(10, 474);
            this.btngenerar.Name = "btngenerar";
            this.btngenerar.Size = new System.Drawing.Size(113, 48);
            this.btngenerar.TabIndex = 9;
            this.btngenerar.Text = "&Generar";
            this.btngenerar.UseVisualStyleBackColor = false;
            this.btngenerar.Click += new System.EventHandler(this.btngenerar_Click);
            // 
            // txtTipo
            // 
            this.txtTipo.Font = new System.Drawing.Font("Franklin Gothic Book", 12F);
            this.txtTipo.Location = new System.Drawing.Point(15, 302);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.ReadOnly = true;
            this.txtTipo.Size = new System.Drawing.Size(138, 26);
            this.txtTipo.TabIndex = 7;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Franklin Gothic Book", 12F);
            this.lblTipo.Location = new System.Drawing.Point(19, 275);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(75, 21);
            this.lblTipo.TabIndex = 3;
            this.lblTipo.Text = "Tipo Mov:";
            // 
            // cmbMovimiento
            // 
            this.cmbMovimiento.Font = new System.Drawing.Font("Franklin Gothic Book", 12F);
            this.cmbMovimiento.FormattingEnabled = true;
            this.cmbMovimiento.Items.AddRange(new object[] {
            "No. Cliente",
            "No. Pedido",
            "No. Nota Remision",
            "No. Pago"});
            this.cmbMovimiento.Location = new System.Drawing.Point(15, 235);
            this.cmbMovimiento.Name = "cmbMovimiento";
            this.cmbMovimiento.Size = new System.Drawing.Size(227, 29);
            this.cmbMovimiento.TabIndex = 4;
            this.cmbMovimiento.SelectedIndexChanged += new System.EventHandler(this.cmbMovimiento_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 21);
            this.label8.TabIndex = 30;
            this.label8.Text = "Tipo Movimiento:";
            // 
            // ucGridMov
            // 
            this.ucGridMov.bFiltro = true;
            this.ucGridMov.DataSource = null;
            this.ucGridMov.Location = new System.Drawing.Point(270, 34);
            this.ucGridMov.Name = "ucGridMov";
            this.ucGridMov.Size = new System.Drawing.Size(796, 531);
            this.ucGridMov.strTitulo = null;
            this.ucGridMov.TabIndex = 33;
            // 
            // FrmReporteMovimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1084, 697);
            this.Controls.Add(this.ucGridMov);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReporteMovimientos";
            this.Text = "FrmReporteMovimientos";
            this.Load += new System.EventHandler(this.FrmReporteMovimientos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btngenerar;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbMovimiento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBuscaCliente;
        private System.Windows.Forms.CheckBox chkGrid;
        private UcGrid ucGridMov;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLimpiar;
    }
}