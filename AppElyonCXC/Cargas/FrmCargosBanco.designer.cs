namespace AppElyonCXC.Cargas
{
    partial class FrmCargosBanco
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnprocesa = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dtgCarga = new AppElyonCXC.UcGrid();
            this.gpoBanamex = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.gpoBanamex.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnprocesa);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.btnCargar);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Font = new System.Drawing.Font("Avenir Book", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(609, 73);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar:";
            // 
            // btnprocesa
            // 
            this.btnprocesa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(109)))));
            this.btnprocesa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprocesa.Font = new System.Drawing.Font("Avenir Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprocesa.ForeColor = System.Drawing.Color.White;
            this.btnprocesa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprocesa.Location = new System.Drawing.Point(490, 21);
            this.btnprocesa.Name = "btnprocesa";
            this.btnprocesa.Size = new System.Drawing.Size(100, 39);
            this.btnprocesa.TabIndex = 9;
            this.btnprocesa.Text = "&Procesar";
            this.btnprocesa.UseVisualStyleBackColor = false;
            this.btnprocesa.Click += new System.EventHandler(this.btnprocesa_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(164, 24);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(203, 25);
            this.txtNombre.TabIndex = 6;
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(109)))));
            this.btnCargar.Font = new System.Drawing.Font("Avenir Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.ForeColor = System.Drawing.Color.White;
            this.btnCargar.Location = new System.Drawing.Point(382, 21);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(75, 34);
            this.btnCargar.TabIndex = 7;
            this.btnCargar.Text = "&Cargar";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Avenir Book", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(16, 25);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(132, 17);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre del Archivo:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(109)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Avenir Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(525, 534);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 39);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dtgCarga
            // 
            this.dtgCarga.bFiltro = true;
            this.dtgCarga.DataSource = null;
            this.dtgCarga.Location = new System.Drawing.Point(16, 98);
            this.dtgCarga.Name = "dtgCarga";
            this.dtgCarga.Size = new System.Drawing.Size(609, 430);
            this.dtgCarga.TabIndex = 1;
            // 
            // gpoBanamex
            // 
            this.gpoBanamex.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpoBanamex.BackColor = System.Drawing.Color.White;
            this.gpoBanamex.Controls.Add(this.groupBox1);
            this.gpoBanamex.Controls.Add(this.btnLimpiar);
            this.gpoBanamex.Controls.Add(this.dtgCarga);
            this.gpoBanamex.Location = new System.Drawing.Point(12, 12);
            this.gpoBanamex.Name = "gpoBanamex";
            this.gpoBanamex.Size = new System.Drawing.Size(636, 587);
            this.gpoBanamex.TabIndex = 9;
            this.gpoBanamex.TabStop = false;
            this.gpoBanamex.Text = "Cargos:";
            // 
            // FrmCargosBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 609);
            this.Controls.Add(this.gpoBanamex);
            this.Name = "FrmCargosBanco";
            this.Text = "FrmPagosBanamex";
            this.Load += new System.EventHandler(this.FrmPagosBanamex_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpoBanamex.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private UcGrid dtgCarga;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnprocesa;
        private System.Windows.Forms.GroupBox gpoBanamex;
    }
}