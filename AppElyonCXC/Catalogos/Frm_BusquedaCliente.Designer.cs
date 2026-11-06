namespace AppElyonCXC.Catalogos
{
    partial class Frm_BusquedaCliente
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
            this.dgv_Cliente = new AppElyonCXC.UcGrid();
            this.SuspendLayout();
            // 
            // dgv_Cliente
            // 
            this.dgv_Cliente.bFiltro = true;
            this.dgv_Cliente.DataSource = null;
            this.dgv_Cliente.Location = new System.Drawing.Point(12, 12);
            this.dgv_Cliente.Name = "dgv_Cliente";
            this.dgv_Cliente.Size = new System.Drawing.Size(764, 505);
            this.dgv_Cliente.TabIndex = 0;
            this.dgv_Cliente.cell_Datagrid_ContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Cliente_cell_Datagrid_ContentDoubleClick);
            // 
            // Frm_BusquedaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 529);
            this.Controls.Add(this.dgv_Cliente);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(804, 568);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(804, 568);
            this.Name = "Frm_BusquedaCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda de cliente";
            this.Load += new System.EventHandler(this.Frm_BusquedaCliente_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UcGrid dgv_Cliente;
    }
}