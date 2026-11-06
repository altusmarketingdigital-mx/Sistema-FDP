namespace AppElyonCXC.Administracion
{
    partial class FrmUsuariosPermisos
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
            this.btnBuscaUsuario = new System.Windows.Forms.Button();
            this.lblCveUsuario = new System.Windows.Forms.Label();
            this.txtCveUsuario = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvAccesos = new System.Windows.Forms.DataGridView();
            this.btnCargarUsuarios = new System.Windows.Forms.Button();
            this.ucgUsuarios = new AppElyonCXC.UcGrid();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccesos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.btnCargarUsuarios);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnBuscaUsuario);
            this.groupBox1.Controls.Add(this.lblCveUsuario);
            this.groupBox1.Controls.Add(this.txtCveUsuario);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(844, 72);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar Usuario:";
            // 
            // btnBuscaUsuario
            // 
            this.btnBuscaUsuario.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscaUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscaUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscaUsuario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBuscaUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscaUsuario.Location = new System.Drawing.Point(284, 23);
            this.btnBuscaUsuario.Name = "btnBuscaUsuario";
            this.btnBuscaUsuario.Size = new System.Drawing.Size(121, 30);
            this.btnBuscaUsuario.TabIndex = 2;
            this.btnBuscaUsuario.Text = "&Buscar Usuario";
            this.btnBuscaUsuario.UseVisualStyleBackColor = false;
            this.btnBuscaUsuario.Click += new System.EventHandler(this.btnBuscaUsuario_Click);
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
            // txtCveUsuario
            // 
            this.txtCveUsuario.Location = new System.Drawing.Point(125, 29);
            this.txtCveUsuario.Name = "txtCveUsuario";
            this.txtCveUsuario.ReadOnly = true;
            this.txtCveUsuario.Size = new System.Drawing.Size(140, 20);
            this.txtCveUsuario.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
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
            this.groupBox2.Location = new System.Drawing.Point(488, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 279);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Permisos Validacion:";
            // 
            // chkAbreCajon
            // 
            this.chkAbreCajon.AutoSize = true;
            this.chkAbreCajon.Enabled = false;
            this.chkAbreCajon.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAbreCajon.Location = new System.Drawing.Point(18, 245);
            this.chkAbreCajon.Name = "chkAbreCajon";
            this.chkAbreCajon.Size = new System.Drawing.Size(126, 20);
            this.chkAbreCajon.TabIndex = 21;
            this.chkAbreCajon.Text = "Abrir cajon de dinero";
            this.chkAbreCajon.UseVisualStyleBackColor = true;
            // 
            // chkSoloParidadMoneda
            // 
            this.chkSoloParidadMoneda.AutoSize = true;
            this.chkSoloParidadMoneda.Enabled = false;
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
            this.chkModSoloDtoCrediito.Enabled = false;
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
            this.chkSoloDescArticulo.Enabled = false;
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
            this.chkModSoloCantVenta.Enabled = false;
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
            this.chkSoloPrecVenta.Enabled = false;
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
            this.chkModSoloPrecio.Enabled = false;
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
            this.chkSoloOtorgaDesc.Enabled = false;
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
            this.chkCancelaVenta.Enabled = false;
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
            this.chkSoloCancelaVenta.Enabled = false;
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
            this.chkDescArticulo.Enabled = false;
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
            this.chkModDtoCrediito.Enabled = false;
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
            this.chkModCantVenta.Enabled = false;
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
            this.chkOtorgaDesc.Enabled = false;
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
            this.chkModPrecio.Enabled = false;
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
            this.chkParidadMoneda.Enabled = false;
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
            this.chkPrecVenta.Enabled = false;
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
            this.chkCajeroventa.Enabled = false;
            this.chkCajeroventa.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCajeroventa.Location = new System.Drawing.Point(18, 33);
            this.chkCajeroventa.Name = "chkCajeroventa";
            this.chkCajeroventa.Size = new System.Drawing.Size(186, 20);
            this.chkCajeroventa.TabIndex = 4;
            this.chkCajeroventa.Text = "Autorizado como cajero en ventas";
            this.chkCajeroventa.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox3.Controls.Add(this.dgvAccesos);
            this.groupBox3.Location = new System.Drawing.Point(488, 375);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(368, 232);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Permisos Menus y Botones:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Transparent;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(708, 19);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(121, 30);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dgvAccesos
            // 
            this.dgvAccesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccesos.Location = new System.Drawing.Point(6, 16);
            this.dgvAccesos.Name = "dgvAccesos";
            this.dgvAccesos.Size = new System.Drawing.Size(356, 203);
            this.dgvAccesos.TabIndex = 23;
            // 
            // btnCargarUsuarios
            // 
            this.btnCargarUsuarios.BackColor = System.Drawing.Color.Transparent;
            this.btnCargarUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarUsuarios.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarUsuarios.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCargarUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargarUsuarios.Location = new System.Drawing.Point(571, 19);
            this.btnCargarUsuarios.Name = "btnCargarUsuarios";
            this.btnCargarUsuarios.Size = new System.Drawing.Size(121, 30);
            this.btnCargarUsuarios.TabIndex = 9;
            this.btnCargarUsuarios.Text = "&Cargar Usuarios";
            this.btnCargarUsuarios.UseVisualStyleBackColor = false;
            this.btnCargarUsuarios.Click += new System.EventHandler(this.btnCargarUsuarios_Click);
            // 
            // ucgUsuarios
            // 
            this.ucgUsuarios.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ucgUsuarios.bFiltro = true;
            this.ucgUsuarios.DataSource = null;
            this.ucgUsuarios.Location = new System.Drawing.Point(12, 90);
            this.ucgUsuarios.Name = "ucgUsuarios";
            this.ucgUsuarios.Size = new System.Drawing.Size(470, 517);
            this.ucgUsuarios.TabIndex = 9;
            this.ucgUsuarios.cell_Datagrid_DoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ucgUsuarios_cell_Datagrid_DoubleClick);
            // 
            // FrmUsuariosPermisos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(870, 613);
            this.Controls.Add(this.ucgUsuarios);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmUsuariosPermisos";
            this.Text = "FrmUsuariosPermisos";
            this.Load += new System.EventHandler(this.FrmUsuariosPermisos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccesos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscaUsuario;
        private System.Windows.Forms.Label lblCveUsuario;
        private System.Windows.Forms.TextBox txtCveUsuario;
        private System.Windows.Forms.Button btnLimpiar;
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvAccesos;
        private System.Windows.Forms.Button btnCargarUsuarios;
        private UcGrid ucgUsuarios;
    }
}