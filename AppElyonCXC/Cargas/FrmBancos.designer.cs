namespace AppElyonCXC.Cargas
{
    partial class FrmBancos
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
            this.gpoaltasecuencia = new System.Windows.Forms.GroupBox();
            this.txtComisionChDev = new System.Windows.Forms.TextBox();
            this.lblComisionChDev = new System.Windows.Forms.Label();
            this.txtComisionDeb = new System.Windows.Forms.TextBox();
            this.lblComisionDeb = new System.Windows.Forms.Label();
            this.txtnombreCorto = new System.Windows.Forms.TextBox();
            this.lblnombrecorto = new System.Windows.Forms.Label();
            this.txtComisionCred = new System.Windows.Forms.TextBox();
            this.lblclave = new System.Windows.Forms.Label();
            this.txtclavebanco = new System.Windows.Forms.TextBox();
            this.lblComisionCred = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.chkEstatus = new System.Windows.Forms.CheckBox();
            this.lbldescripcion = new System.Windows.Forms.Label();
            this.ucGBanco = new AppElyonCXC.UcGrid();
            this.gpoConsulta = new System.Windows.Forms.GroupBox();
            this.btnReporte = new System.Windows.Forms.Button();
            this.bnCargar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.gpoaltasecuencia.SuspendLayout();
            this.gpoConsulta.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpoaltasecuencia
            // 
            this.gpoaltasecuencia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpoaltasecuencia.Controls.Add(this.txtComisionChDev);
            this.gpoaltasecuencia.Controls.Add(this.lblComisionChDev);
            this.gpoaltasecuencia.Controls.Add(this.txtComisionDeb);
            this.gpoaltasecuencia.Controls.Add(this.lblComisionDeb);
            this.gpoaltasecuencia.Controls.Add(this.txtnombreCorto);
            this.gpoaltasecuencia.Controls.Add(this.lblnombrecorto);
            this.gpoaltasecuencia.Controls.Add(this.txtComisionCred);
            this.gpoaltasecuencia.Controls.Add(this.lblclave);
            this.gpoaltasecuencia.Controls.Add(this.txtclavebanco);
            this.gpoaltasecuencia.Controls.Add(this.lblComisionCred);
            this.gpoaltasecuencia.Controls.Add(this.btnAgregar);
            this.gpoaltasecuencia.Controls.Add(this.btnEliminar);
            this.gpoaltasecuencia.Controls.Add(this.txtdescripcion);
            this.gpoaltasecuencia.Controls.Add(this.chkEstatus);
            this.gpoaltasecuencia.Controls.Add(this.lbldescripcion);
            this.gpoaltasecuencia.Location = new System.Drawing.Point(523, 108);
            this.gpoaltasecuencia.Name = "gpoaltasecuencia";
            this.gpoaltasecuencia.Size = new System.Drawing.Size(391, 503);
            this.gpoaltasecuencia.TabIndex = 4;
            this.gpoaltasecuencia.TabStop = false;
            this.gpoaltasecuencia.Text = "Alta concepto:";
            // 
            // txtComisionChDev
            // 
            this.txtComisionChDev.Location = new System.Drawing.Point(207, 273);
            this.txtComisionChDev.Name = "txtComisionChDev";
            this.txtComisionChDev.Size = new System.Drawing.Size(63, 20);
            this.txtComisionChDev.TabIndex = 11;
            // 
            // lblComisionChDev
            // 
            this.lblComisionChDev.AutoSize = true;
            this.lblComisionChDev.Font = new System.Drawing.Font("Avenir Book", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComisionChDev.Location = new System.Drawing.Point(22, 276);
            this.lblComisionChDev.Name = "lblComisionChDev";
            this.lblComisionChDev.Size = new System.Drawing.Size(179, 17);
            this.lblComisionChDev.TabIndex = 80;
            this.lblComisionChDev.Text = "Comision Cheque Devuelto:";
            // 
            // txtComisionDeb
            // 
            this.txtComisionDeb.Location = new System.Drawing.Point(141, 240);
            this.txtComisionDeb.Name = "txtComisionDeb";
            this.txtComisionDeb.Size = new System.Drawing.Size(63, 20);
            this.txtComisionDeb.TabIndex = 10;
            // 
            // lblComisionDeb
            // 
            this.lblComisionDeb.AutoSize = true;
            this.lblComisionDeb.Font = new System.Drawing.Font("Avenir Book", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComisionDeb.Location = new System.Drawing.Point(22, 240);
            this.lblComisionDeb.Name = "lblComisionDeb";
            this.lblComisionDeb.Size = new System.Drawing.Size(113, 17);
            this.lblComisionDeb.TabIndex = 78;
            this.lblComisionDeb.Text = "Comision Debito:";
            // 
            // txtnombreCorto
            // 
            this.txtnombreCorto.Location = new System.Drawing.Point(123, 71);
            this.txtnombreCorto.Name = "txtnombreCorto";
            this.txtnombreCorto.Size = new System.Drawing.Size(131, 20);
            this.txtnombreCorto.TabIndex = 6;
            // 
            // lblnombrecorto
            // 
            this.lblnombrecorto.AutoSize = true;
            this.lblnombrecorto.Font = new System.Drawing.Font("Avenir Book", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombrecorto.Location = new System.Drawing.Point(22, 71);
            this.lblnombrecorto.Name = "lblnombrecorto";
            this.lblnombrecorto.Size = new System.Drawing.Size(98, 17);
            this.lblnombrecorto.TabIndex = 76;
            this.lblnombrecorto.Text = "Nombre Corto:";
            // 
            // txtComisionCred
            // 
            this.txtComisionCred.Location = new System.Drawing.Point(141, 205);
            this.txtComisionCred.Name = "txtComisionCred";
            this.txtComisionCred.Size = new System.Drawing.Size(63, 20);
            this.txtComisionCred.TabIndex = 9;
            // 
            // lblclave
            // 
            this.lblclave.AutoSize = true;
            this.lblclave.Font = new System.Drawing.Font("Avenir Book", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblclave.Location = new System.Drawing.Point(22, 37);
            this.lblclave.Name = "lblclave";
            this.lblclave.Size = new System.Drawing.Size(87, 17);
            this.lblclave.TabIndex = 74;
            this.lblclave.Text = "Clave Banco:";
            // 
            // txtclavebanco
            // 
            this.txtclavebanco.Location = new System.Drawing.Point(123, 37);
            this.txtclavebanco.Name = "txtclavebanco";
            this.txtclavebanco.Size = new System.Drawing.Size(113, 20);
            this.txtclavebanco.TabIndex = 5;
            this.txtclavebanco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtclavebanco_KeyPress);
            this.txtclavebanco.Validated += new System.EventHandler(this.txtclavebanco_Validated);
            // 
            // lblComisionCred
            // 
            this.lblComisionCred.AutoSize = true;
            this.lblComisionCred.Font = new System.Drawing.Font("Avenir Book", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComisionCred.Location = new System.Drawing.Point(22, 205);
            this.lblComisionCred.Name = "lblComisionCred";
            this.lblComisionCred.Size = new System.Drawing.Size(117, 17);
            this.lblComisionCred.TabIndex = 72;
            this.lblComisionCred.Text = "Comision Credito:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(109)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(51, 325);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 39);
            this.btnAgregar.TabIndex = 12;
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
            this.btnEliminar.Location = new System.Drawing.Point(207, 325);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 39);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Location = new System.Drawing.Point(123, 107);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(241, 20);
            this.txtdescripcion.TabIndex = 7;
            // 
            // chkEstatus
            // 
            this.chkEstatus.AutoSize = true;
            this.chkEstatus.Location = new System.Drawing.Point(25, 148);
            this.chkEstatus.Name = "chkEstatus";
            this.chkEstatus.Size = new System.Drawing.Size(59, 17);
            this.chkEstatus.TabIndex = 8;
            this.chkEstatus.Text = "Estado";
            this.chkEstatus.UseVisualStyleBackColor = true;
            // 
            // lbldescripcion
            // 
            this.lbldescripcion.AutoSize = true;
            this.lbldescripcion.Font = new System.Drawing.Font("Avenir Book", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldescripcion.Location = new System.Drawing.Point(22, 107);
            this.lbldescripcion.Name = "lbldescripcion";
            this.lbldescripcion.Size = new System.Drawing.Size(83, 17);
            this.lbldescripcion.TabIndex = 0;
            this.lbldescripcion.Text = "Descripcion:";
            // 
            // ucGBanco
            // 
            this.ucGBanco.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ucGBanco.bFiltro = true;
            this.ucGBanco.DataSource = null;
            this.ucGBanco.Location = new System.Drawing.Point(10, 21);
            this.ucGBanco.Name = "ucGBanco";
            this.ucGBanco.Size = new System.Drawing.Size(507, 590);
            this.ucGBanco.TabIndex = 14;
            this.ucGBanco.cell_Datagrid_DoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ucGUsuario_cell_Datagrid_DoubleClick);
            // 
            // gpoConsulta
            // 
            this.gpoConsulta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpoConsulta.Controls.Add(this.btnReporte);
            this.gpoConsulta.Controls.Add(this.bnCargar);
            this.gpoConsulta.Controls.Add(this.btnLimpiar);
            this.gpoConsulta.Location = new System.Drawing.Point(523, 21);
            this.gpoConsulta.Name = "gpoConsulta";
            this.gpoConsulta.Size = new System.Drawing.Size(391, 69);
            this.gpoConsulta.TabIndex = 0;
            this.gpoConsulta.TabStop = false;
            this.gpoConsulta.Text = "Seleccionar:";
            // 
            // btnReporte
            // 
            this.btnReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(109)))));
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte.ForeColor = System.Drawing.Color.White;
            this.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReporte.Location = new System.Drawing.Point(152, 19);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(100, 39);
            this.btnReporte.TabIndex = 2;
            this.btnReporte.Text = "&Imprimir";
            this.btnReporte.UseVisualStyleBackColor = false;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // bnCargar
            // 
            this.bnCargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(109)))));
            this.bnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnCargar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnCargar.ForeColor = System.Drawing.Color.White;
            this.bnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bnCargar.Location = new System.Drawing.Point(24, 19);
            this.bnCargar.Name = "bnCargar";
            this.bnCargar.Size = new System.Drawing.Size(100, 39);
            this.bnCargar.TabIndex = 1;
            this.bnCargar.Text = "&Cargar";
            this.bnCargar.UseVisualStyleBackColor = false;
            this.bnCargar.Click += new System.EventHandler(this.bnCargar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(109)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(273, 19);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 39);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // FrmBancos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(987, 621);
            this.Controls.Add(this.gpoaltasecuencia);
            this.Controls.Add(this.ucGBanco);
            this.Controls.Add(this.gpoConsulta);
            this.Name = "FrmBancos";
            this.Text = "FrmBancos";
            this.Load += new System.EventHandler(this.FrmBancos_Load);
            this.gpoaltasecuencia.ResumeLayout(false);
            this.gpoaltasecuencia.PerformLayout();
            this.gpoConsulta.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpoaltasecuencia;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox txtdescripcion;
        private System.Windows.Forms.CheckBox chkEstatus;
        private System.Windows.Forms.Label lbldescripcion;
        private UcGrid ucGBanco;
        private System.Windows.Forms.GroupBox gpoConsulta;
        private System.Windows.Forms.Button bnCargar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtnombreCorto;
        private System.Windows.Forms.Label lblnombrecorto;
        private System.Windows.Forms.TextBox txtComisionCred;
        private System.Windows.Forms.Label lblclave;
        private System.Windows.Forms.TextBox txtclavebanco;
        private System.Windows.Forms.Label lblComisionCred;
        private System.Windows.Forms.TextBox txtComisionChDev;
        private System.Windows.Forms.Label lblComisionChDev;
        private System.Windows.Forms.TextBox txtComisionDeb;
        private System.Windows.Forms.Label lblComisionDeb;
        private System.Windows.Forms.Button btnReporte;
    }
}