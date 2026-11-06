namespace AppElyonCXC.Mantenimiento
{
    partial class FrmBuscaUsuario
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
            this.uctrlGridUsuario = new AppElyonCXC.UcGrid();
            this.gpoUsuarios.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpoUsuarios
            // 
            this.gpoUsuarios.Controls.Add(this.uctrlGridUsuario);
            this.gpoUsuarios.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpoUsuarios.Location = new System.Drawing.Point(12, 12);
            this.gpoUsuarios.Name = "gpoUsuarios";
            this.gpoUsuarios.Size = new System.Drawing.Size(510, 459);
            this.gpoUsuarios.TabIndex = 3;
            this.gpoUsuarios.TabStop = false;
            this.gpoUsuarios.Text = "Busqueda de Usuario:";
            // 
            // uctrlGridUsuario
            // 
            this.uctrlGridUsuario.bFiltro = true;
            this.uctrlGridUsuario.DataSource = null;
            this.uctrlGridUsuario.Location = new System.Drawing.Point(13, 21);
            this.uctrlGridUsuario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uctrlGridUsuario.Name = "uctrlGridUsuario";
            this.uctrlGridUsuario.Size = new System.Drawing.Size(482, 423);
            this.uctrlGridUsuario.TabIndex = 9;
            this.uctrlGridUsuario.cell_Datagrid_DoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uctrlGridUsuario_cell_Datagrid_DoubleClick);
            // 
            // FrmBuscaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 483);
            this.Controls.Add(this.gpoUsuarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmBuscaUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmBuscaUsuario";
            this.Load += new System.EventHandler(this.FrmBuscaUsuario_Load);
            this.gpoUsuarios.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpoUsuarios;
        private UcGrid uctrlGridUsuario;
    }
}