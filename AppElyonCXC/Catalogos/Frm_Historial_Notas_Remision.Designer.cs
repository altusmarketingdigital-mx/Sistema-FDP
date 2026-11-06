namespace AppElyonCXC.Catalogos
{
    partial class Frm_Historial_Notas_Remision
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
            this.dgv_Nota_Remision = new AppElyonCXC.UcGrid();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(911, 47);
            this.label1.TabIndex = 5;
            this.label1.Text = "NOTAS DE REMISIÓN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_Nota_Remision
            // 
            this.dgv_Nota_Remision.bFiltro = true;
            this.dgv_Nota_Remision.DataSource = null;
            this.dgv_Nota_Remision.Location = new System.Drawing.Point(13, 73);
            this.dgv_Nota_Remision.Name = "dgv_Nota_Remision";
            this.dgv_Nota_Remision.Size = new System.Drawing.Size(911, 473);
            this.dgv_Nota_Remision.strTitulo = null;
            this.dgv_Nota_Remision.TabIndex = 4;
            this.dgv_Nota_Remision.cell_Datagrid_ContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Nota_Remision_cell_Datagrid_ContentDoubleClick);
            // 
            // Frm_Historial_Notas_Remision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AppElyonCXC.Properties.Resources.Fondo;
            this.ClientSize = new System.Drawing.Size(937, 556);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_Nota_Remision);
            this.MaximumSize = new System.Drawing.Size(953, 595);
            this.MinimumSize = new System.Drawing.Size(953, 595);
            this.Name = "Frm_Historial_Notas_Remision";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Historial_Notas_Remision";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UcGrid dgv_Nota_Remision;
    }
}