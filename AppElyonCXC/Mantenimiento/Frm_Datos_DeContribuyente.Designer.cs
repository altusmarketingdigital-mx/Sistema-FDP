namespace AppElyonCXC.Mantenimiento
{
    partial class Frm_Datos_DeContribuyente
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
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_RazonSocial = new System.Windows.Forms.TextBox();
            this.txt_RFC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Pais = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Estado = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Ciudad = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_No_Ext = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Calle = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_No_Int = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_Codigo_Postal = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_Colonia = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_Telefono = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnGuadar = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgv_Contribuyente = new AppElyonCXC.UcGrid();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Image = global::AppElyonCXC.Properties.Resources.logo_frutería_1_;
            this.label1.Location = new System.Drawing.Point(47, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 125);
            this.label1.TabIndex = 0;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(64)))), ((int)(((byte)(9)))));
            this.btnLimpiar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(826, 20);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(110, 50);
            this.btnLimpiar.TabIndex = 78;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(111)))), ((int)(((byte)(112)))));
            this.label3.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(287, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(519, 44);
            this.label3.TabIndex = 83;
            this.label3.Text = "DATOS DEL CONTRIBUYENTE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(226)))), ((int)(((byte)(225)))));
            this.label2.Location = new System.Drawing.Point(287, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(731, 497);
            this.label2.TabIndex = 86;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(226)))), ((int)(((byte)(225)))));
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(304, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 16);
            this.label4.TabIndex = 87;
            this.label4.Text = "Razón Social:";
            // 
            // txt_RazonSocial
            // 
            this.txt_RazonSocial.Location = new System.Drawing.Point(404, 98);
            this.txt_RazonSocial.Multiline = true;
            this.txt_RazonSocial.Name = "txt_RazonSocial";
            this.txt_RazonSocial.Size = new System.Drawing.Size(308, 24);
            this.txt_RazonSocial.TabIndex = 88;
            this.txt_RazonSocial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_RFC
            // 
            this.txt_RFC.Location = new System.Drawing.Point(760, 98);
            this.txt_RFC.Multiline = true;
            this.txt_RFC.Name = "txt_RFC";
            this.txt_RFC.Size = new System.Drawing.Size(244, 24);
            this.txt_RFC.TabIndex = 90;
            this.txt_RFC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(226)))), ((int)(((byte)(225)))));
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(718, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 89;
            this.label5.Text = "RFC:";
            // 
            // txt_Pais
            // 
            this.txt_Pais.Location = new System.Drawing.Point(347, 135);
            this.txt_Pais.Multiline = true;
            this.txt_Pais.Name = "txt_Pais";
            this.txt_Pais.Size = new System.Drawing.Size(165, 24);
            this.txt_Pais.TabIndex = 92;
            this.txt_Pais.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(226)))), ((int)(((byte)(225)))));
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(304, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 16);
            this.label6.TabIndex = 91;
            this.label6.Text = "Pais:";
            // 
            // txt_Estado
            // 
            this.txt_Estado.Location = new System.Drawing.Point(578, 135);
            this.txt_Estado.Multiline = true;
            this.txt_Estado.Name = "txt_Estado";
            this.txt_Estado.Size = new System.Drawing.Size(176, 24);
            this.txt_Estado.TabIndex = 94;
            this.txt_Estado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(226)))), ((int)(((byte)(225)))));
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(518, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 93;
            this.label7.Text = "Estado:";
            // 
            // txt_Ciudad
            // 
            this.txt_Ciudad.Location = new System.Drawing.Point(835, 135);
            this.txt_Ciudad.Multiline = true;
            this.txt_Ciudad.Name = "txt_Ciudad";
            this.txt_Ciudad.Size = new System.Drawing.Size(169, 24);
            this.txt_Ciudad.TabIndex = 96;
            this.txt_Ciudad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(226)))), ((int)(((byte)(225)))));
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(768, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 16);
            this.label8.TabIndex = 95;
            this.label8.Text = "Ciudad:";
            // 
            // txt_No_Ext
            // 
            this.txt_No_Ext.Location = new System.Drawing.Point(733, 172);
            this.txt_No_Ext.Multiline = true;
            this.txt_No_Ext.Name = "txt_No_Ext";
            this.txt_No_Ext.Size = new System.Drawing.Size(88, 24);
            this.txt_No_Ext.TabIndex = 100;
            this.txt_No_Ext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(226)))), ((int)(((byte)(225)))));
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(673, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 99;
            this.label9.Text = "No. Ext:";
            // 
            // txt_Calle
            // 
            this.txt_Calle.Location = new System.Drawing.Point(357, 172);
            this.txt_Calle.Multiline = true;
            this.txt_Calle.Name = "txt_Calle";
            this.txt_Calle.Size = new System.Drawing.Size(303, 24);
            this.txt_Calle.TabIndex = 98;
            this.txt_Calle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(226)))), ((int)(((byte)(225)))));
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(304, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 16);
            this.label10.TabIndex = 97;
            this.label10.Text = "Calle:";
            // 
            // txt_No_Int
            // 
            this.txt_No_Int.Location = new System.Drawing.Point(895, 172);
            this.txt_No_Int.Multiline = true;
            this.txt_No_Int.Name = "txt_No_Int";
            this.txt_No_Int.Size = new System.Drawing.Size(88, 24);
            this.txt_No_Int.TabIndex = 102;
            this.txt_No_Int.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(226)))), ((int)(((byte)(225)))));
            this.label11.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(835, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 16);
            this.label11.TabIndex = 101;
            this.label11.Text = "No. Int:";
            // 
            // txt_Codigo_Postal
            // 
            this.txt_Codigo_Postal.Location = new System.Drawing.Point(871, 209);
            this.txt_Codigo_Postal.Multiline = true;
            this.txt_Codigo_Postal.Name = "txt_Codigo_Postal";
            this.txt_Codigo_Postal.Size = new System.Drawing.Size(88, 24);
            this.txt_Codigo_Postal.TabIndex = 106;
            this.txt_Codigo_Postal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(226)))), ((int)(((byte)(225)))));
            this.label12.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(764, 212);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 16);
            this.label12.TabIndex = 105;
            this.label12.Text = "Codigo Postal:";
            // 
            // txt_Colonia
            // 
            this.txt_Colonia.Location = new System.Drawing.Point(373, 209);
            this.txt_Colonia.Multiline = true;
            this.txt_Colonia.Name = "txt_Colonia";
            this.txt_Colonia.Size = new System.Drawing.Size(381, 24);
            this.txt_Colonia.TabIndex = 104;
            this.txt_Colonia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(226)))), ((int)(((byte)(225)))));
            this.label13.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(304, 212);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 16);
            this.label13.TabIndex = 103;
            this.label13.Text = "Colonia:";
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(628, 246);
            this.txt_Email.Multiline = true;
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(376, 24);
            this.txt_Email.TabIndex = 110;
            this.txt_Email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(226)))), ((int)(((byte)(225)))));
            this.label14.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(574, 249);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 16);
            this.label14.TabIndex = 109;
            this.label14.Text = "Email:";
            // 
            // txt_Telefono
            // 
            this.txt_Telefono.Location = new System.Drawing.Point(376, 246);
            this.txt_Telefono.Multiline = true;
            this.txt_Telefono.Name = "txt_Telefono";
            this.txt_Telefono.Size = new System.Drawing.Size(192, 24);
            this.txt_Telefono.TabIndex = 108;
            this.txt_Telefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(226)))), ((int)(((byte)(225)))));
            this.label15.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(304, 249);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 16);
            this.label15.TabIndex = 107;
            this.label15.Text = "Telefono:";
            // 
            // btnGuadar
            // 
            this.btnGuadar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGuadar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.btnGuadar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnGuadar.ForeColor = System.Drawing.Color.White;
            this.btnGuadar.Location = new System.Drawing.Point(47, 221);
            this.btnGuadar.Name = "btnGuadar";
            this.btnGuadar.Size = new System.Drawing.Size(162, 48);
            this.btnGuadar.TabIndex = 114;
            this.btnGuadar.Text = "Guadar";
            this.btnGuadar.UseVisualStyleBackColor = false;
            this.btnGuadar.Click += new System.EventHandler(this.btnGuadar_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.btnHistorial.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnHistorial.ForeColor = System.Drawing.Color.White;
            this.btnHistorial.Location = new System.Drawing.Point(48, 345);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(162, 49);
            this.btnHistorial.TabIndex = 111;
            this.btnHistorial.Text = "Historial";
            this.btnHistorial.UseVisualStyleBackColor = false;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.btnBuscar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(48, 283);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(162, 48);
            this.btnBuscar.TabIndex = 115;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgv_Contribuyente
            // 
            this.dgv_Contribuyente.bFiltro = true;
            this.dgv_Contribuyente.DataSource = null;
            this.dgv_Contribuyente.Location = new System.Drawing.Point(296, 291);
            this.dgv_Contribuyente.Name = "dgv_Contribuyente";
            this.dgv_Contribuyente.Size = new System.Drawing.Size(710, 278);
            this.dgv_Contribuyente.strTitulo = null;
            this.dgv_Contribuyente.TabIndex = 116;
            this.dgv_Contribuyente.cell_Datagrid_ContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Contribuyente_cell_Datagrid_ContentDoubleClick);
            // 
            // Frm_Datos_DeContribuyente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AppElyonCXC.Properties.Resources.Fondo;
            this.ClientSize = new System.Drawing.Size(1084, 697);
            this.Controls.Add(this.dgv_Contribuyente);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnGuadar);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txt_Telefono);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txt_Codigo_Postal);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt_Colonia);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txt_No_Int);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_No_Ext);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_Calle);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_Ciudad);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_Estado);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_Pais);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_RFC);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_RazonSocial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.label1);
            this.Name = "Frm_Datos_DeContribuyente";
            this.Text = "s";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_RazonSocial;
        private System.Windows.Forms.TextBox txt_RFC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Pais;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Estado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Ciudad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_No_Ext;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_Calle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_No_Int;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_Codigo_Postal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_Colonia;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_Telefono;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnGuadar;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Button btnBuscar;
        private UcGrid dgv_Contribuyente;
    }
}