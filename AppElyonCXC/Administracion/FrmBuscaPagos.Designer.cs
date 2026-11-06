namespace AppElyonCXC.Administracion
{
    partial class FrmBuscaPagos
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
            this.gpoUsuarios = new System.Windows.Forms.GroupBox();
            this.uctrlGridPagos = new AppElyonCXC.UcGrid();
            this.gpoUsuarios.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpoUsuarios
            // 
            this.gpoUsuarios.Controls.Add(this.uctrlGridPagos);
            this.gpoUsuarios.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpoUsuarios.Location = new System.Drawing.Point(14, 12);
            this.gpoUsuarios.Name = "gpoUsuarios";
            this.gpoUsuarios.Size = new System.Drawing.Size(510, 459);
            this.gpoUsuarios.TabIndex = 6;
            this.gpoUsuarios.TabStop = false;
            this.gpoUsuarios.Text = "Busqueda de Pagos:";
            // 
            // uctrlGridPagos
            // 
            this.uctrlGridPagos.bFiltro = true;
            this.uctrlGridPagos.DataSource = null;
            this.uctrlGridPagos.Location = new System.Drawing.Point(13, 21);
            this.uctrlGridPagos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uctrlGridPagos.Name = "uctrlGridPagos";
            this.uctrlGridPagos.Size = new System.Drawing.Size(482, 423);
            this.uctrlGridPagos.strTitulo = null;
            this.uctrlGridPagos.TabIndex = 9;
            this.uctrlGridPagos.cell_Datagrid_DoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uctrlGridPagos_cell_Datagrid_DoubleClick);
            // 
            // FrmBuscaPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 482);
            this.Controls.Add(this.gpoUsuarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmBuscaPagos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBuscaPagos";
            this.Load += new System.EventHandler(this.FrmBuscaPagos_Load);
            this.gpoUsuarios.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpoUsuarios;
        private UcGrid uctrlGridPagos;
    }
}