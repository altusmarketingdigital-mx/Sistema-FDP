namespace AppElyonCXC.Mantenimiento
{
    partial class FrmParametros
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
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.gpodatos = new System.Windows.Forms.GroupBox();
            this.txtrutaimagen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblnota = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtfolio = new System.Windows.Forms.TextBox();
            this.cmbVigente = new System.Windows.Forms.ComboBox();
            this.lblVigente = new System.Windows.Forms.Label();
            this.lblfolio = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.gpoEmail = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsuServ = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCveServ = new System.Windows.Forms.Label();
            this.txtUsuServ = new System.Windows.Forms.TextBox();
            this.lblpuertoSalida = new System.Windows.Forms.Label();
            this.lblServSalida = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCveServ = new System.Windows.Forms.TextBox();
            this.txtPuertoSalida = new System.Windows.Forms.TextBox();
            this.txtServSalida = new System.Windows.Forms.TextBox();
            this.gpoSelecciona = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Datos = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabPage7.SuspendLayout();
            this.gpodatos.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.gpoEmail.SuspendLayout();
            this.gpoSelecciona.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.Control;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLimpiar.Image = global::AppElyonCXC.Properties.Resources.sinchronize_26;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(527, 28);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 39);
            this.btnLimpiar.TabIndex = 31;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.gpodatos);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(478, 370);
            this.tabPage7.TabIndex = 3;
            this.tabPage7.Text = "Seleccion Datos";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // gpodatos
            // 
            this.gpodatos.Controls.Add(this.txtrutaimagen);
            this.gpodatos.Controls.Add(this.label2);
            this.gpodatos.Controls.Add(this.lblnota);
            this.gpodatos.Controls.Add(this.button1);
            this.gpodatos.Controls.Add(this.txtfolio);
            this.gpodatos.Controls.Add(this.cmbVigente);
            this.gpodatos.Controls.Add(this.lblVigente);
            this.gpodatos.Controls.Add(this.lblfolio);
            this.gpodatos.Location = new System.Drawing.Point(21, 23);
            this.gpodatos.Name = "gpodatos";
            this.gpodatos.Size = new System.Drawing.Size(438, 179);
            this.gpodatos.TabIndex = 5;
            this.gpodatos.TabStop = false;
            this.gpodatos.Text = "Selecciona Datos:";
            // 
            // txtrutaimagen
            // 
            this.txtrutaimagen.Location = new System.Drawing.Point(87, 86);
            this.txtrutaimagen.Name = "txtrutaimagen";
            this.txtrutaimagen.Size = new System.Drawing.Size(162, 20);
            this.txtrutaimagen.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Ruta Imagen:";
            // 
            // lblnota
            // 
            this.lblnota.AutoSize = true;
            this.lblnota.ForeColor = System.Drawing.Color.Maroon;
            this.lblnota.Location = new System.Drawing.Point(247, 38);
            this.lblnota.Name = "lblnota";
            this.lblnota.Size = new System.Drawing.Size(150, 13);
            this.lblnota.TabIndex = 4;
            this.lblnota.Text = "NOTA: 0= Inactivo, 1= Activo.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(261, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Examinar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtfolio
            // 
            this.txtfolio.Location = new System.Drawing.Point(66, 19);
            this.txtfolio.Name = "txtfolio";
            this.txtfolio.Size = new System.Drawing.Size(100, 20);
            this.txtfolio.TabIndex = 6;
            // 
            // cmbVigente
            // 
            this.cmbVigente.FormattingEnabled = true;
            this.cmbVigente.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cmbVigente.Location = new System.Drawing.Point(274, 14);
            this.cmbVigente.Name = "cmbVigente";
            this.cmbVigente.Size = new System.Drawing.Size(51, 21);
            this.cmbVigente.TabIndex = 7;
            // 
            // lblVigente
            // 
            this.lblVigente.AutoSize = true;
            this.lblVigente.Location = new System.Drawing.Point(222, 19);
            this.lblVigente.Name = "lblVigente";
            this.lblVigente.Size = new System.Drawing.Size(46, 13);
            this.lblVigente.TabIndex = 1;
            this.lblVigente.Text = "Vigente:";
            // 
            // lblfolio
            // 
            this.lblfolio.AutoSize = true;
            this.lblfolio.Location = new System.Drawing.Point(9, 22);
            this.lblfolio.Name = "lblfolio";
            this.lblfolio.Size = new System.Drawing.Size(52, 13);
            this.lblfolio.TabIndex = 0;
            this.lblfolio.Text = "No. Folio:";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(12, 142);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(486, 396);
            this.tabControl2.TabIndex = 48;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.gpoEmail);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(478, 370);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Datos Email";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // gpoEmail
            // 
            this.gpoEmail.Controls.Add(this.label1);
            this.gpoEmail.Controls.Add(this.lblUsuServ);
            this.gpoEmail.Controls.Add(this.label4);
            this.gpoEmail.Controls.Add(this.lblCveServ);
            this.gpoEmail.Controls.Add(this.txtUsuServ);
            this.gpoEmail.Controls.Add(this.lblpuertoSalida);
            this.gpoEmail.Controls.Add(this.lblServSalida);
            this.gpoEmail.Controls.Add(this.label6);
            this.gpoEmail.Controls.Add(this.txtCveServ);
            this.gpoEmail.Controls.Add(this.txtPuertoSalida);
            this.gpoEmail.Controls.Add(this.txtServSalida);
            this.gpoEmail.Location = new System.Drawing.Point(7, 21);
            this.gpoEmail.Name = "gpoEmail";
            this.gpoEmail.Size = new System.Drawing.Size(441, 146);
            this.gpoEmail.TabIndex = 7;
            this.gpoEmail.TabStop = false;
            this.gpoEmail.Text = "Almacena datos Email:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Univa: smtp.office365.com  puerto:587";
            // 
            // lblUsuServ
            // 
            this.lblUsuServ.AutoSize = true;
            this.lblUsuServ.Location = new System.Drawing.Point(14, 54);
            this.lblUsuServ.Name = "lblUsuServ";
            this.lblUsuServ.Size = new System.Drawing.Size(88, 13);
            this.lblUsuServ.TabIndex = 7;
            this.lblUsuServ.Text = "Usuario Servidor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Hotmail: smtp.live.com  puerto:587";
            // 
            // lblCveServ
            // 
            this.lblCveServ.AutoSize = true;
            this.lblCveServ.Location = new System.Drawing.Point(233, 50);
            this.lblCveServ.Name = "lblCveServ";
            this.lblCveServ.Size = new System.Drawing.Size(79, 13);
            this.lblCveServ.TabIndex = 6;
            this.lblCveServ.Text = "Clave Servidor:";
            // 
            // txtUsuServ
            // 
            this.txtUsuServ.Location = new System.Drawing.Point(127, 50);
            this.txtUsuServ.Name = "txtUsuServ";
            this.txtUsuServ.Size = new System.Drawing.Size(100, 20);
            this.txtUsuServ.TabIndex = 11;
            // 
            // lblpuertoSalida
            // 
            this.lblpuertoSalida.AutoSize = true;
            this.lblpuertoSalida.Location = new System.Drawing.Point(233, 27);
            this.lblpuertoSalida.Name = "lblpuertoSalida";
            this.lblpuertoSalida.Size = new System.Drawing.Size(86, 13);
            this.lblpuertoSalida.TabIndex = 1;
            this.lblpuertoSalida.Text = "Puerto de salida:";
            // 
            // lblServSalida
            // 
            this.lblServSalida.AutoSize = true;
            this.lblServSalida.Location = new System.Drawing.Point(14, 27);
            this.lblServSalida.Name = "lblServSalida";
            this.lblServSalida.Size = new System.Drawing.Size(94, 13);
            this.lblServSalida.TabIndex = 0;
            this.lblServSalida.Text = "Servidor de salida:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Gmail:  smtp.gmail.com  puerto:587";
            // 
            // txtCveServ
            // 
            this.txtCveServ.Location = new System.Drawing.Point(320, 47);
            this.txtCveServ.Name = "txtCveServ";
            this.txtCveServ.Size = new System.Drawing.Size(100, 20);
            this.txtCveServ.TabIndex = 12;
            // 
            // txtPuertoSalida
            // 
            this.txtPuertoSalida.Location = new System.Drawing.Point(321, 24);
            this.txtPuertoSalida.Name = "txtPuertoSalida";
            this.txtPuertoSalida.Size = new System.Drawing.Size(100, 20);
            this.txtPuertoSalida.TabIndex = 10;
            // 
            // txtServSalida
            // 
            this.txtServSalida.Location = new System.Drawing.Point(127, 24);
            this.txtServSalida.Name = "txtServSalida";
            this.txtServSalida.Size = new System.Drawing.Size(100, 20);
            this.txtServSalida.TabIndex = 9;
            // 
            // gpoSelecciona
            // 
            this.gpoSelecciona.Controls.Add(this.dataGridView1);
            this.gpoSelecciona.Location = new System.Drawing.Point(12, 12);
            this.gpoSelecciona.Name = "gpoSelecciona";
            this.gpoSelecciona.Size = new System.Drawing.Size(482, 124);
            this.gpoSelecciona.TabIndex = 45;
            this.gpoSelecciona.TabStop = false;
            this.gpoSelecciona.Text = "Selecciona:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Datos});
            this.dataGridView1.DataMember = "Parametrokey";
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(473, 102);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Datos
            // 
            this.Datos.HeaderText = "Datos";
            this.Datos.Name = "Datos";
            this.Datos.ReadOnly = true;
            this.Datos.Text = "Selecciona";
            this.Datos.UseColumnTextForButtonValue = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAgregar.Image = global::AppElyonCXC.Properties.Resources.add_list_32;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(527, 73);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 39);
            this.btnAgregar.TabIndex = 49;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.SystemColors.Control;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEliminar.Image = global::AppElyonCXC.Properties.Resources.delete_file_26;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(527, 118);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 39);
            this.btnEliminar.TabIndex = 50;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // FrmParametros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 553);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.gpoSelecciona);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.btnLimpiar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmParametros";
            this.Text = "FrmParametros";
            this.Load += new System.EventHandler(this.FrmParametros_Load);
            this.tabPage7.ResumeLayout(false);
            this.gpodatos.ResumeLayout(false);
            this.gpodatos.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.gpoEmail.ResumeLayout(false);
            this.gpoEmail.PerformLayout();
            this.gpoSelecciona.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.GroupBox gpodatos;
        private System.Windows.Forms.TextBox txtrutaimagen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblnota;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtfolio;
        private System.Windows.Forms.ComboBox cmbVigente;
        private System.Windows.Forms.Label lblVigente;
        private System.Windows.Forms.Label lblfolio;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox gpoEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsuServ;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCveServ;
        private System.Windows.Forms.TextBox txtUsuServ;
        private System.Windows.Forms.Label lblpuertoSalida;
        private System.Windows.Forms.Label lblServSalida;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCveServ;
        private System.Windows.Forms.TextBox txtPuertoSalida;
        private System.Windows.Forms.TextBox txtServSalida;
        private System.Windows.Forms.GroupBox gpoSelecciona;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn Datos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}