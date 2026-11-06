namespace AppElyonCXC.Administracion
{
    partial class FrmBuscarPedidos
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
            this.uctrlGridPedidos = new AppElyonCXC.UcGrid();
            this.gpoUsuarios.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpoUsuarios
            // 
            this.gpoUsuarios.Controls.Add(this.uctrlGridPedidos);
            this.gpoUsuarios.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpoUsuarios.Location = new System.Drawing.Point(14, 12);
            this.gpoUsuarios.Name = "gpoUsuarios";
            this.gpoUsuarios.Size = new System.Drawing.Size(510, 459);
            this.gpoUsuarios.TabIndex = 5;
            this.gpoUsuarios.TabStop = false;
            this.gpoUsuarios.Text = "Busqueda de Pedidos:";
            // 
            // uctrlGridPedidos
            // 
            this.uctrlGridPedidos.bFiltro = true;
            this.uctrlGridPedidos.DataSource = null;
            this.uctrlGridPedidos.Location = new System.Drawing.Point(13, 21);
            this.uctrlGridPedidos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uctrlGridPedidos.Name = "uctrlGridPedidos";
            this.uctrlGridPedidos.Size = new System.Drawing.Size(482, 423);
            this.uctrlGridPedidos.strTitulo = null;
            this.uctrlGridPedidos.TabIndex = 9;
            this.uctrlGridPedidos.cell_Datagrid_DoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uctrlGridPedidos_cell_Datagrid_DoubleClick);
            // 
            // FrmBuscarPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 482);
            this.Controls.Add(this.gpoUsuarios);
            this.Name = "FrmBuscarPedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBuscarPedidos";
            this.Load += new System.EventHandler(this.FrmBuscarPedidos_Load);
            this.gpoUsuarios.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpoUsuarios;
        private UcGrid uctrlGridPedidos;
    }
}