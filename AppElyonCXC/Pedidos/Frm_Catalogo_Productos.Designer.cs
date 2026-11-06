namespace AppElyonCXC.Pedidos
{
    partial class Frm_Catalogo_Productos
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Productos = new AppElyonCXC.UcGrid();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(911, 47);
            this.label1.TabIndex = 3;
            this.label1.Text = "PRODUCTOS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_Productos
            // 
            this.dgv_Productos.bFiltro = true;
            this.dgv_Productos.DataSource = null;
            this.dgv_Productos.Location = new System.Drawing.Point(13, 73);
            this.dgv_Productos.Name = "dgv_Productos";
            this.dgv_Productos.Size = new System.Drawing.Size(911, 473);
            this.dgv_Productos.strTitulo = null;
            this.dgv_Productos.TabIndex = 2;
            this.dgv_Productos.cell_Datagrid_ContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Productos_cell_Datagrid_ContentDoubleClick);
            // 
            // Frm_Catalogo_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AppElyonCXC.Properties.Resources.Fondo;
            this.ClientSize = new System.Drawing.Size(937, 556);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_Productos);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(953, 595);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(953, 595);
            this.Name = "Frm_Catalogo_Productos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Catalogo_Productos";
            this.Load += new System.EventHandler(this.Frm_Catalogo_Productos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UcGrid dgv_Productos;
    }
}