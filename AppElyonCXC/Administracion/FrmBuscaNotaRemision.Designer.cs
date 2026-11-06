namespace AppElyonCXC.Administracion
{
    partial class FrmBuscaNotaRemision
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
            this.uctrlGridNotas = new AppElyonCXC.UcGrid();
            this.gpoUsuarios.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpoUsuarios
            // 
            this.gpoUsuarios.Controls.Add(this.uctrlGridNotas);
            this.gpoUsuarios.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpoUsuarios.Location = new System.Drawing.Point(14, 12);
            this.gpoUsuarios.Name = "gpoUsuarios";
            this.gpoUsuarios.Size = new System.Drawing.Size(510, 459);
            this.gpoUsuarios.TabIndex = 6;
            this.gpoUsuarios.TabStop = false;
            this.gpoUsuarios.Text = "Busqueda Notas de Remision:";
            // 
            // uctrlGridNotas
            // 
            this.uctrlGridNotas.bFiltro = true;
            this.uctrlGridNotas.DataSource = null;
            this.uctrlGridNotas.Location = new System.Drawing.Point(13, 21);
            this.uctrlGridNotas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uctrlGridNotas.Name = "uctrlGridNotas";
            this.uctrlGridNotas.Size = new System.Drawing.Size(482, 423);
            this.uctrlGridNotas.strTitulo = null;
            this.uctrlGridNotas.TabIndex = 9;
            this.uctrlGridNotas.cell_Datagrid_DoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uctrlGridNotas_cell_Datagrid_DoubleClick);
            // 
            // FrmBuscaNotaRemision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 482);
            this.Controls.Add(this.gpoUsuarios);
            this.Name = "FrmBuscaNotaRemision";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBuscaNotaRemision";
            this.Load += new System.EventHandler(this.FrmBuscaNotaRemision_Load);
            this.gpoUsuarios.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpoUsuarios;
        private UcGrid uctrlGridNotas;
    }
}