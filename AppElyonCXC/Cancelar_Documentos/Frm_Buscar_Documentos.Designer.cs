namespace AppElyonCXC.Cancelar_Documentos
{
    partial class Frm_Buscar_Documentos
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
            this.dgv_Documentos = new AppElyonCXC.UcGrid();
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
            this.label1.Text = "DOCUMENTOS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_Documentos
            // 
            this.dgv_Documentos.bFiltro = true;
            this.dgv_Documentos.DataSource = null;
            this.dgv_Documentos.Location = new System.Drawing.Point(13, 73);
            this.dgv_Documentos.Name = "dgv_Documentos";
            this.dgv_Documentos.Size = new System.Drawing.Size(911, 473);
            this.dgv_Documentos.strTitulo = null;
            this.dgv_Documentos.TabIndex = 4;
            this.dgv_Documentos.cell_Datagrid_ContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Documentos_cell_Datagrid_ContentDoubleClick);
            // 
            // Frm_Buscar_Documentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AppElyonCXC.Properties.Resources.Fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(937, 556);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_Documentos);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(953, 595);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(953, 595);
            this.Name = "Frm_Buscar_Documentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Buscar_Documentos";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UcGrid dgv_Documentos;
    }
}