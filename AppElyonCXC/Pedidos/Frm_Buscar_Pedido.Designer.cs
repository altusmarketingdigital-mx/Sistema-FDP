namespace AppElyonCXC.Pedidos
{
    partial class Frm_Buscar_Pedido
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
            this.dgv_Historial_Pedido = new AppElyonCXC.UcGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dgv_Historial_Pedido
            // 
            this.dgv_Historial_Pedido.bFiltro = true;
            this.dgv_Historial_Pedido.DataSource = null;
            this.dgv_Historial_Pedido.Location = new System.Drawing.Point(12, 71);
            this.dgv_Historial_Pedido.Name = "dgv_Historial_Pedido";
            this.dgv_Historial_Pedido.Size = new System.Drawing.Size(911, 473);
            this.dgv_Historial_Pedido.strTitulo = null;
            this.dgv_Historial_Pedido.TabIndex = 0;
            this.dgv_Historial_Pedido.cell_Datagrid_ContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Historial_Pedido_cell_Datagrid_ContentDoubleClick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(911, 47);
            this.label1.TabIndex = 4;
            this.label1.Text = "PEDIDOS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_Buscar_Pedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AppElyonCXC.Properties.Resources.Fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(937, 556);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_Historial_Pedido);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(953, 595);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(953, 595);
            this.Name = "Frm_Buscar_Pedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial pedidos";
            this.ResumeLayout(false);

        }

        #endregion

        private UcGrid dgv_Historial_Pedido;
        private System.Windows.Forms.Label label1;
    }
}