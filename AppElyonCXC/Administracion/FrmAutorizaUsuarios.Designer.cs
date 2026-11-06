namespace AppElyonCXC.Administracion
{
    partial class FrmAutorizaUsuarios
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
            this.btnBuscaUsuario = new System.Windows.Forms.Button();
            this.txtCveUsuario = new System.Windows.Forms.TextBox();
            this.lblCveUsuario = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.chkAbreCajon = new System.Windows.Forms.CheckBox();
            this.chkSoloParidadMoneda = new System.Windows.Forms.CheckBox();
            this.chkModSoloDtoCrediito = new System.Windows.Forms.CheckBox();
            this.chkSoloDescArticulo = new System.Windows.Forms.CheckBox();
            this.chkModSoloCantVenta = new System.Windows.Forms.CheckBox();
            this.chkSoloPrecVenta = new System.Windows.Forms.CheckBox();
            this.chkModSoloPrecio = new System.Windows.Forms.CheckBox();
            this.chkSoloOtorgaDesc = new System.Windows.Forms.CheckBox();
            this.chkCancelaVenta = new System.Windows.Forms.CheckBox();
            this.chkSoloCancelaVenta = new System.Windows.Forms.CheckBox();
            this.chkDescArticulo = new System.Windows.Forms.CheckBox();
            this.chkModDtoCrediito = new System.Windows.Forms.CheckBox();
            this.chkModCantVenta = new System.Windows.Forms.CheckBox();
            this.chkOtorgaDesc = new System.Windows.Forms.CheckBox();
            this.chkModPrecio = new System.Windows.Forms.CheckBox();
            this.chkParidadMoneda = new System.Windows.Forms.CheckBox();
            this.chkPrecVenta = new System.Windows.Forms.CheckBox();
            this.chkCajeroventa = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscaUsuario
            // 
            this.btnBuscaUsuario.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscaUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscaUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscaUsuario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBuscaUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscaUsuario.Location = new System.Drawing.Point(285, 23);
            this.btnBuscaUsuario.Name = "btnBuscaUsuario";
            this.btnBuscaUsuario.Size = new System.Drawing.Size(121, 30);
            this.btnBuscaUsuario.TabIndex = 2;
            this.btnBuscaUsuario.Text = "&Buscar Usuario";
            this.btnBuscaUsuario.UseVisualStyleBackColor = false;
            this.btnBuscaUsuario.Click += new System.EventHandler(this.btnBuscaUsuario_Click);
            // 
            // txtCveUsuario
            // 
            this.txtCveUsuario.Location = new System.Drawing.Point(125, 29);
            this.txtCveUsuario.Name = "txtCveUsuario";
            this.txtCveUsuario.ReadOnly = true;
            this.txtCveUsuario.Size = new System.Drawing.Size(140, 20);
            this.txtCveUsuario.TabIndex = 1;
            // 
            // lblCveUsuario
            // 
            this.lblCveUsuario.AutoSize = true;
            this.lblCveUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCveUsuario.Location = new System.Drawing.Point(23, 30);
            this.lblCveUsuario.Name = "lblCveUsuario";
            this.lblCveUsuario.Size = new System.Drawing.Size(101, 17);
            this.lblCveUsuario.TabIndex = 7;
            this.lblCveUsuario.Text = "Clave Usuario:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.btnBuscaUsuario);
            this.groupBox1.Controls.Add(this.lblCveUsuario);
            this.groupBox1.Controls.Add(this.txtCveUsuario);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar Usuario:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.btnLimpiar);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Controls.Add(this.chkAbreCajon);
            this.groupBox2.Controls.Add(this.chkSoloParidadMoneda);
            this.groupBox2.Controls.Add(this.chkModSoloDtoCrediito);
            this.groupBox2.Controls.Add(this.chkSoloDescArticulo);
            this.groupBox2.Controls.Add(this.chkModSoloCantVenta);
            this.groupBox2.Controls.Add(this.chkSoloPrecVenta);
            this.groupBox2.Controls.Add(this.chkModSoloPrecio);
            this.groupBox2.Controls.Add(this.chkSoloOtorgaDesc);
            this.groupBox2.Controls.Add(this.chkCancelaVenta);
            this.groupBox2.Controls.Add(this.chkSoloCancelaVenta);
            this.groupBox2.Controls.Add(this.chkDescArticulo);
            this.groupBox2.Controls.Add(this.chkModDtoCrediito);
            this.groupBox2.Controls.Add(this.chkModCantVenta);
            this.groupBox2.Controls.Add(this.chkOtorgaDesc);
            this.groupBox2.Controls.Add(this.chkModPrecio);
            this.groupBox2.Controls.Add(this.chkParidadMoneda);
            this.groupBox2.Controls.Add(this.chkPrecVenta);
            this.groupBox2.Controls.Add(this.chkCajeroventa);
            this.groupBox2.Location = new System.Drawing.Point(12, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(449, 403);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccionar permisos:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Transparent;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(304, 337);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(121, 30);
            this.btnLimpiar.TabIndex = 24;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(164, 337);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(121, 30);
            this.btnEliminar.TabIndex = 23;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(18, 337);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(121, 30);
            this.btnAgregar.TabIndex = 22;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // chkAbreCajon
            // 
            this.chkAbreCajon.AutoSize = true;
            this.chkAbreCajon.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAbreCajon.Location = new System.Drawing.Point(18, 273);
            this.chkAbreCajon.Name = "chkAbreCajon";
            this.chkAbreCajon.Size = new System.Drawing.Size(126, 20);
            this.chkAbreCajon.TabIndex = 21;
            this.chkAbreCajon.Text = "Abrir cajon de dinero";
            this.chkAbreCajon.UseVisualStyleBackColor = true;
            // 
            // chkSoloParidadMoneda
            // 
            this.chkSoloParidadMoneda.AutoSize = true;
            this.chkSoloParidadMoneda.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSoloParidadMoneda.Location = new System.Drawing.Point(232, 219);
            this.chkSoloParidadMoneda.Name = "chkSoloParidadMoneda";
            this.chkSoloParidadMoneda.Size = new System.Drawing.Size(127, 20);
            this.chkSoloParidadMoneda.TabIndex = 20;
            this.chkSoloParidadMoneda.Text = "Solo con autorizacion";
            this.chkSoloParidadMoneda.UseVisualStyleBackColor = true;
            // 
            // chkModSoloDtoCrediito
            // 
            this.chkModSoloDtoCrediito.AutoSize = true;
            this.chkModSoloDtoCrediito.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkModSoloDtoCrediito.Location = new System.Drawing.Point(233, 196);
            this.chkModSoloDtoCrediito.Name = "chkModSoloDtoCrediito";
            this.chkModSoloDtoCrediito.Size = new System.Drawing.Size(127, 20);
            this.chkModSoloDtoCrediito.TabIndex = 18;
            this.chkModSoloDtoCrediito.Text = "Solo con autorizacion";
            this.chkModSoloDtoCrediito.UseVisualStyleBackColor = true;
            // 
            // chkSoloDescArticulo
            // 
            this.chkSoloDescArticulo.AutoSize = true;
            this.chkSoloDescArticulo.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSoloDescArticulo.Location = new System.Drawing.Point(232, 79);
            this.chkSoloDescArticulo.Name = "chkSoloDescArticulo";
            this.chkSoloDescArticulo.Size = new System.Drawing.Size(127, 20);
            this.chkSoloDescArticulo.TabIndex = 8;
            this.chkSoloDescArticulo.Text = "Solo con autorizacion";
            this.chkSoloDescArticulo.UseVisualStyleBackColor = true;
            // 
            // chkModSoloCantVenta
            // 
            this.chkModSoloCantVenta.AutoSize = true;
            this.chkModSoloCantVenta.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkModSoloCantVenta.Location = new System.Drawing.Point(232, 102);
            this.chkModSoloCantVenta.Name = "chkModSoloCantVenta";
            this.chkModSoloCantVenta.Size = new System.Drawing.Size(127, 20);
            this.chkModSoloCantVenta.TabIndex = 10;
            this.chkModSoloCantVenta.Text = "Solo con autorizacion";
            this.chkModSoloCantVenta.UseVisualStyleBackColor = true;
            // 
            // chkSoloPrecVenta
            // 
            this.chkSoloPrecVenta.AutoSize = true;
            this.chkSoloPrecVenta.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSoloPrecVenta.Location = new System.Drawing.Point(232, 148);
            this.chkSoloPrecVenta.Name = "chkSoloPrecVenta";
            this.chkSoloPrecVenta.Size = new System.Drawing.Size(127, 20);
            this.chkSoloPrecVenta.TabIndex = 14;
            this.chkSoloPrecVenta.Text = "Solo con autorizacion";
            this.chkSoloPrecVenta.UseVisualStyleBackColor = true;
            // 
            // chkModSoloPrecio
            // 
            this.chkModSoloPrecio.AutoSize = true;
            this.chkModSoloPrecio.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkModSoloPrecio.Location = new System.Drawing.Point(232, 125);
            this.chkModSoloPrecio.Name = "chkModSoloPrecio";
            this.chkModSoloPrecio.Size = new System.Drawing.Size(127, 20);
            this.chkModSoloPrecio.TabIndex = 12;
            this.chkModSoloPrecio.Text = "Solo con autorizacion";
            this.chkModSoloPrecio.UseVisualStyleBackColor = true;
            // 
            // chkSoloOtorgaDesc
            // 
            this.chkSoloOtorgaDesc.AutoSize = true;
            this.chkSoloOtorgaDesc.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSoloOtorgaDesc.Location = new System.Drawing.Point(232, 171);
            this.chkSoloOtorgaDesc.Name = "chkSoloOtorgaDesc";
            this.chkSoloOtorgaDesc.Size = new System.Drawing.Size(127, 20);
            this.chkSoloOtorgaDesc.TabIndex = 16;
            this.chkSoloOtorgaDesc.Text = "Solo con autorizacion";
            this.chkSoloOtorgaDesc.UseVisualStyleBackColor = true;
            // 
            // chkCancelaVenta
            // 
            this.chkCancelaVenta.AutoSize = true;
            this.chkCancelaVenta.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCancelaVenta.Location = new System.Drawing.Point(18, 56);
            this.chkCancelaVenta.Name = "chkCancelaVenta";
            this.chkCancelaVenta.Size = new System.Drawing.Size(105, 20);
            this.chkCancelaVenta.TabIndex = 5;
            this.chkCancelaVenta.Text = "Cancelar Ventas";
            this.chkCancelaVenta.UseVisualStyleBackColor = true;
            // 
            // chkSoloCancelaVenta
            // 
            this.chkSoloCancelaVenta.AutoSize = true;
            this.chkSoloCancelaVenta.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSoloCancelaVenta.Location = new System.Drawing.Point(232, 56);
            this.chkSoloCancelaVenta.Name = "chkSoloCancelaVenta";
            this.chkSoloCancelaVenta.Size = new System.Drawing.Size(127, 20);
            this.chkSoloCancelaVenta.TabIndex = 6;
            this.chkSoloCancelaVenta.Text = "Solo con autorizacion";
            this.chkSoloCancelaVenta.UseVisualStyleBackColor = true;
            // 
            // chkDescArticulo
            // 
            this.chkDescArticulo.AutoSize = true;
            this.chkDescArticulo.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDescArticulo.Location = new System.Drawing.Point(18, 79);
            this.chkDescArticulo.Name = "chkDescArticulo";
            this.chkDescArticulo.Size = new System.Drawing.Size(157, 20);
            this.chkDescArticulo.TabIndex = 7;
            this.chkDescArticulo.Text = "Modifica descripcion articulo";
            this.chkDescArticulo.UseVisualStyleBackColor = true;
            // 
            // chkModDtoCrediito
            // 
            this.chkModDtoCrediito.AutoSize = true;
            this.chkModDtoCrediito.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkModDtoCrediito.Location = new System.Drawing.Point(18, 196);
            this.chkModDtoCrediito.Name = "chkModDtoCrediito";
            this.chkModDtoCrediito.Size = new System.Drawing.Size(146, 20);
            this.chkModDtoCrediito.TabIndex = 17;
            this.chkModDtoCrediito.Text = "Modificar datos de credito";
            this.chkModDtoCrediito.UseVisualStyleBackColor = true;
            // 
            // chkModCantVenta
            // 
            this.chkModCantVenta.AutoSize = true;
            this.chkModCantVenta.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkModCantVenta.Location = new System.Drawing.Point(18, 102);
            this.chkModCantVenta.Name = "chkModCantVenta";
            this.chkModCantVenta.Size = new System.Drawing.Size(151, 20);
            this.chkModCantVenta.TabIndex = 9;
            this.chkModCantVenta.Text = "Modifica cantidad de venta";
            this.chkModCantVenta.UseVisualStyleBackColor = true;
            // 
            // chkOtorgaDesc
            // 
            this.chkOtorgaDesc.AutoSize = true;
            this.chkOtorgaDesc.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOtorgaDesc.Location = new System.Drawing.Point(18, 171);
            this.chkOtorgaDesc.Name = "chkOtorgaDesc";
            this.chkOtorgaDesc.Size = new System.Drawing.Size(119, 20);
            this.chkOtorgaDesc.TabIndex = 15;
            this.chkOtorgaDesc.Text = "Otorgar descuentos";
            this.chkOtorgaDesc.UseVisualStyleBackColor = true;
            // 
            // chkModPrecio
            // 
            this.chkModPrecio.AutoSize = true;
            this.chkModPrecio.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkModPrecio.Location = new System.Drawing.Point(18, 125);
            this.chkModPrecio.Name = "chkModPrecio";
            this.chkModPrecio.Size = new System.Drawing.Size(129, 20);
            this.chkModPrecio.TabIndex = 11;
            this.chkModPrecio.Text = "Modifica No de precio";
            this.chkModPrecio.UseVisualStyleBackColor = true;
            // 
            // chkParidadMoneda
            // 
            this.chkParidadMoneda.AutoSize = true;
            this.chkParidadMoneda.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkParidadMoneda.Location = new System.Drawing.Point(18, 219);
            this.chkParidadMoneda.Name = "chkParidadMoneda";
            this.chkParidadMoneda.Size = new System.Drawing.Size(149, 20);
            this.chkParidadMoneda.TabIndex = 19;
            this.chkParidadMoneda.Text = "Modificar paridad moneda";
            this.chkParidadMoneda.UseVisualStyleBackColor = true;
            // 
            // chkPrecVenta
            // 
            this.chkPrecVenta.AutoSize = true;
            this.chkPrecVenta.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrecVenta.Location = new System.Drawing.Point(18, 148);
            this.chkPrecVenta.Name = "chkPrecVenta";
            this.chkPrecVenta.Size = new System.Drawing.Size(150, 20);
            this.chkPrecVenta.TabIndex = 13;
            this.chkPrecVenta.Text = "Modificar precios de venta";
            this.chkPrecVenta.UseVisualStyleBackColor = true;
            // 
            // chkCajeroventa
            // 
            this.chkCajeroventa.AutoSize = true;
            this.chkCajeroventa.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCajeroventa.Location = new System.Drawing.Point(18, 33);
            this.chkCajeroventa.Name = "chkCajeroventa";
            this.chkCajeroventa.Size = new System.Drawing.Size(186, 20);
            this.chkCajeroventa.TabIndex = 4;
            this.chkCajeroventa.Text = "Autorizado como cajero en ventas";
            this.chkCajeroventa.UseVisualStyleBackColor = true;
            // 
            // FrmAutorizaUsuarios
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(480, 560);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmAutorizaUsuarios";
            this.Text = "FrmAutorizaUsuarios";
            this.Load += new System.EventHandler(this.FrmAutorizaUsuarios_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBuscaUsuario;
        private System.Windows.Forms.TextBox txtCveUsuario;
        private System.Windows.Forms.Label lblCveUsuario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAbreCajon;
        private System.Windows.Forms.CheckBox chkSoloParidadMoneda;
        private System.Windows.Forms.CheckBox chkModSoloDtoCrediito;
        private System.Windows.Forms.CheckBox chkSoloDescArticulo;
        private System.Windows.Forms.CheckBox chkModSoloCantVenta;
        private System.Windows.Forms.CheckBox chkSoloPrecVenta;
        private System.Windows.Forms.CheckBox chkModSoloPrecio;
        private System.Windows.Forms.CheckBox chkSoloOtorgaDesc;
        private System.Windows.Forms.CheckBox chkCancelaVenta;
        private System.Windows.Forms.CheckBox chkSoloCancelaVenta;
        private System.Windows.Forms.CheckBox chkDescArticulo;
        private System.Windows.Forms.CheckBox chkModDtoCrediito;
        private System.Windows.Forms.CheckBox chkModCantVenta;
        private System.Windows.Forms.CheckBox chkOtorgaDesc;
        private System.Windows.Forms.CheckBox chkModPrecio;
        private System.Windows.Forms.CheckBox chkParidadMoneda;
        private System.Windows.Forms.CheckBox chkPrecVenta;
        private System.Windows.Forms.CheckBox chkCajeroventa;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnLimpiar;
    }
}