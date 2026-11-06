namespace AppElyonCXC.Administracion
{
    partial class FrmEmpresas
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
            this.gpoAlta = new System.Windows.Forms.GroupBox();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCp = new System.Windows.Forms.TextBox();
            this.txtColonia = new System.Windows.Forms.TextBox();
            this.txtNoExterior = new System.Windows.Forms.TextBox();
            this.txtnoInterior = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtrazonSocial = new System.Windows.Forms.TextBox();
            this.txtRfc = new System.Windows.Forms.TextBox();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.cmbciudad = new System.Windows.Forms.ComboBox();
            this.cmbestado = new System.Windows.Forms.ComboBox();
            this.chkEstatus = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ucGEmpresa = new AppElyonCXC.UcGrid();
            this.btnReporte = new System.Windows.Forms.Button();
            this.gpoAlta.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpoAlta
            // 
            this.gpoAlta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpoAlta.Controls.Add(this.btnReporte);
            this.gpoAlta.Controls.Add(this.txtContacto);
            this.gpoAlta.Controls.Add(this.btnLimpiar);
            this.gpoAlta.Controls.Add(this.btnAgregar);
            this.gpoAlta.Controls.Add(this.btnEliminar);
            this.gpoAlta.Controls.Add(this.txtTelefono);
            this.gpoAlta.Controls.Add(this.txtEmail);
            this.gpoAlta.Controls.Add(this.txtCp);
            this.gpoAlta.Controls.Add(this.txtColonia);
            this.gpoAlta.Controls.Add(this.txtNoExterior);
            this.gpoAlta.Controls.Add(this.txtnoInterior);
            this.gpoAlta.Controls.Add(this.txtNombre);
            this.gpoAlta.Controls.Add(this.txtrazonSocial);
            this.gpoAlta.Controls.Add(this.txtRfc);
            this.gpoAlta.Controls.Add(this.txtDomicilio);
            this.gpoAlta.Controls.Add(this.txtCodigo);
            this.gpoAlta.Controls.Add(this.cmbciudad);
            this.gpoAlta.Controls.Add(this.cmbestado);
            this.gpoAlta.Controls.Add(this.chkEstatus);
            this.gpoAlta.Controls.Add(this.label16);
            this.gpoAlta.Controls.Add(this.label14);
            this.gpoAlta.Controls.Add(this.label13);
            this.gpoAlta.Controls.Add(this.label12);
            this.gpoAlta.Controls.Add(this.label11);
            this.gpoAlta.Controls.Add(this.label10);
            this.gpoAlta.Controls.Add(this.label9);
            this.gpoAlta.Controls.Add(this.label8);
            this.gpoAlta.Controls.Add(this.label7);
            this.gpoAlta.Controls.Add(this.label6);
            this.gpoAlta.Controls.Add(this.label4);
            this.gpoAlta.Controls.Add(this.label3);
            this.gpoAlta.Controls.Add(this.label2);
            this.gpoAlta.Controls.Add(this.label1);
            this.gpoAlta.Location = new System.Drawing.Point(488, 12);
            this.gpoAlta.Name = "gpoAlta";
            this.gpoAlta.Size = new System.Drawing.Size(317, 502);
            this.gpoAlta.TabIndex = 3;
            this.gpoAlta.TabStop = false;
            this.gpoAlta.Text = "Alta Empresas:";
            // 
            // txtContacto
            // 
            this.txtContacto.Location = new System.Drawing.Point(111, 353);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(200, 20);
            this.txtContacto.TabIndex = 20;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(109)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(228, 448);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(83, 39);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(109)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(108, 398);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(83, 39);
            this.btnAgregar.TabIndex = 18;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(109)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(228, 398);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(83, 39);
            this.btnEliminar.TabIndex = 19;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(111, 327);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(200, 20);
            this.txtTelefono.TabIndex = 14;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(111, 299);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 13;
            // 
            // txtCp
            // 
            this.txtCp.Location = new System.Drawing.Point(111, 220);
            this.txtCp.Name = "txtCp";
            this.txtCp.Size = new System.Drawing.Size(80, 20);
            this.txtCp.TabIndex = 10;
            // 
            // txtColonia
            // 
            this.txtColonia.Location = new System.Drawing.Point(111, 195);
            this.txtColonia.Name = "txtColonia";
            this.txtColonia.Size = new System.Drawing.Size(200, 20);
            this.txtColonia.TabIndex = 9;
            // 
            // txtNoExterior
            // 
            this.txtNoExterior.Location = new System.Drawing.Point(251, 169);
            this.txtNoExterior.Name = "txtNoExterior";
            this.txtNoExterior.Size = new System.Drawing.Size(54, 20);
            this.txtNoExterior.TabIndex = 8;
            // 
            // txtnoInterior
            // 
            this.txtnoInterior.Location = new System.Drawing.Point(81, 169);
            this.txtnoInterior.Name = "txtnoInterior";
            this.txtnoInterior.Size = new System.Drawing.Size(54, 20);
            this.txtnoInterior.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(111, 44);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // txtrazonSocial
            // 
            this.txtrazonSocial.Location = new System.Drawing.Point(111, 70);
            this.txtrazonSocial.Name = "txtrazonSocial";
            this.txtrazonSocial.Size = new System.Drawing.Size(200, 20);
            this.txtrazonSocial.TabIndex = 3;
            // 
            // txtRfc
            // 
            this.txtRfc.Location = new System.Drawing.Point(111, 94);
            this.txtRfc.Name = "txtRfc";
            this.txtRfc.Size = new System.Drawing.Size(200, 20);
            this.txtRfc.TabIndex = 4;
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Location = new System.Drawing.Point(74, 145);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(237, 20);
            this.txtDomicilio.TabIndex = 6;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(111, 19);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // cmbciudad
            // 
            this.cmbciudad.FormattingEnabled = true;
            this.cmbciudad.Location = new System.Drawing.Point(111, 271);
            this.cmbciudad.Name = "cmbciudad";
            this.cmbciudad.Size = new System.Drawing.Size(200, 21);
            this.cmbciudad.TabIndex = 12;
            // 
            // cmbestado
            // 
            this.cmbestado.FormattingEnabled = true;
            this.cmbestado.Location = new System.Drawing.Point(111, 245);
            this.cmbestado.Name = "cmbestado";
            this.cmbestado.Size = new System.Drawing.Size(200, 21);
            this.cmbestado.TabIndex = 11;
            this.cmbestado.SelectedIndexChanged += new System.EventHandler(this.cmbestado_SelectedIndexChanged);
            // 
            // chkEstatus
            // 
            this.chkEstatus.AutoSize = true;
            this.chkEstatus.Location = new System.Drawing.Point(19, 410);
            this.chkEstatus.Name = "chkEstatus";
            this.chkEstatus.Size = new System.Drawing.Size(61, 17);
            this.chkEstatus.TabIndex = 17;
            this.chkEstatus.Text = "Estatus";
            this.chkEstatus.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 356);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "Contacto:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 331);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Telefono:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 302);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Email:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 276);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Ciudad:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 248);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Estado:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 220);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Codigo postal:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Colonia:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(180, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "No. Exterior:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Domicilio:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "No. Interior:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "RFC:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Razon Social:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clave:";
            // 
            // ucGEmpresa
            // 
            this.ucGEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ucGEmpresa.bFiltro = true;
            this.ucGEmpresa.DataSource = null;
            this.ucGEmpresa.Location = new System.Drawing.Point(12, 12);
            this.ucGEmpresa.Name = "ucGEmpresa";
            this.ucGEmpresa.Size = new System.Drawing.Size(470, 502);
            this.ucGEmpresa.TabIndex = 4;
            this.ucGEmpresa.cell_Datagrid_DoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ucGEmpresa_cell_Datagrid_DoubleClick);
            // 
            // btnReporte
            // 
            this.btnReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(109)))));
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte.ForeColor = System.Drawing.Color.White;
            this.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReporte.Location = new System.Drawing.Point(108, 448);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(83, 39);
            this.btnReporte.TabIndex = 84;
            this.btnReporte.Text = "&Imprimir";
            this.btnReporte.UseVisualStyleBackColor = false;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // FrmEmpresas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(822, 530);
            this.Controls.Add(this.gpoAlta);
            this.Controls.Add(this.ucGEmpresa);
            this.Name = "FrmEmpresas";
            this.Text = "FrmEmpresas";
            this.Load += new System.EventHandler(this.FrmEmpresas_Load);
            this.gpoAlta.ResumeLayout(false);
            this.gpoAlta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpoAlta;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtCp;
        private System.Windows.Forms.TextBox txtColonia;
        private System.Windows.Forms.TextBox txtNoExterior;
        private System.Windows.Forms.TextBox txtnoInterior;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtrazonSocial;
        private System.Windows.Forms.TextBox txtRfc;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.ComboBox cmbciudad;
        private System.Windows.Forms.ComboBox cmbestado;
        private System.Windows.Forms.CheckBox chkEstatus;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private UcGrid ucGEmpresa;
        private System.Windows.Forms.Button btnReporte;
    }
}