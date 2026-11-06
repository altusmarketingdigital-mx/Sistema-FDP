namespace AppElyonCXC.Inventario
{
    partial class FrmRegistroInventarioProducto
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
            this.txt_Importe = new System.Windows.Forms.TextBox();
            this.txt_UnidadVenta_Calculado = new System.Windows.Forms.TextBox();
            this.txt_UnidadVenta = new System.Windows.Forms.TextBox();
            this.txt_UnidadCompra = new System.Windows.Forms.TextBox();
            this.txt_PrecioCompra = new System.Windows.Forms.TextBox();
            this.chb_Decimales = new System.Windows.Forms.CheckBox();
            this.txt_Contenido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txt_ClaveProducto = new System.Windows.Forms.TextBox();
            this.dgv_Inventario_Inicial = new AppElyonCXC.UcGrid();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_Importe
            // 
            this.txt_Importe.Location = new System.Drawing.Point(760, 298);
            this.txt_Importe.Multiline = true;
            this.txt_Importe.Name = "txt_Importe";
            this.txt_Importe.Size = new System.Drawing.Size(184, 25);
            this.txt_Importe.TabIndex = 45;
            // 
            // txt_UnidadVenta_Calculado
            // 
            this.txt_UnidadVenta_Calculado.Location = new System.Drawing.Point(386, 298);
            this.txt_UnidadVenta_Calculado.Multiline = true;
            this.txt_UnidadVenta_Calculado.Name = "txt_UnidadVenta_Calculado";
            this.txt_UnidadVenta_Calculado.Size = new System.Drawing.Size(188, 25);
            this.txt_UnidadVenta_Calculado.TabIndex = 43;
            // 
            // txt_UnidadVenta
            // 
            this.txt_UnidadVenta.Location = new System.Drawing.Point(760, 225);
            this.txt_UnidadVenta.Multiline = true;
            this.txt_UnidadVenta.Name = "txt_UnidadVenta";
            this.txt_UnidadVenta.Size = new System.Drawing.Size(184, 24);
            this.txt_UnidadVenta.TabIndex = 45;
            // 
            // txt_UnidadCompra
            // 
            this.txt_UnidadCompra.Location = new System.Drawing.Point(405, 227);
            this.txt_UnidadCompra.Multiline = true;
            this.txt_UnidadCompra.Name = "txt_UnidadCompra";
            this.txt_UnidadCompra.Size = new System.Drawing.Size(188, 25);
            this.txt_UnidadCompra.TabIndex = 43;
            // 
            // txt_PrecioCompra
            // 
            this.txt_PrecioCompra.Enabled = false;
            this.txt_PrecioCompra.Location = new System.Drawing.Point(557, 156);
            this.txt_PrecioCompra.Multiline = true;
            this.txt_PrecioCompra.Name = "txt_PrecioCompra";
            this.txt_PrecioCompra.Size = new System.Drawing.Size(141, 24);
            this.txt_PrecioCompra.TabIndex = 40;
            // 
            // chb_Decimales
            // 
            this.chb_Decimales.AutoSize = true;
            this.chb_Decimales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(226)))), ((int)(((byte)(225)))));
            this.chb_Decimales.Enabled = false;
            this.chb_Decimales.Location = new System.Drawing.Point(728, 158);
            this.chb_Decimales.Name = "chb_Decimales";
            this.chb_Decimales.Size = new System.Drawing.Size(126, 17);
            this.chb_Decimales.TabIndex = 38;
            this.chb_Decimales.Text = "Opera con decimales";
            this.chb_Decimales.UseVisualStyleBackColor = false;
            // 
            // txt_Contenido
            // 
            this.txt_Contenido.Enabled = false;
            this.txt_Contenido.Location = new System.Drawing.Point(339, 157);
            this.txt_Contenido.Multiline = true;
            this.txt_Contenido.Name = "txt_Contenido";
            this.txt_Contenido.Size = new System.Drawing.Size(139, 24);
            this.txt_Contenido.TabIndex = 37;
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(422, 119);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(522, 25);
            this.txtNombre.TabIndex = 35;
            // 
            // txt_ClaveProducto
            // 
            this.txt_ClaveProducto.Location = new System.Drawing.Point(693, 73);
            this.txt_ClaveProducto.Multiline = true;
            this.txt_ClaveProducto.Name = "txt_ClaveProducto";
            this.txt_ClaveProducto.Size = new System.Drawing.Size(265, 23);
            this.txt_ClaveProducto.TabIndex = 33;
            this.txt_ClaveProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ClaveProducto_KeyPress);
            // 
            // dgv_Inventario_Inicial
            // 
            this.dgv_Inventario_Inicial.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgv_Inventario_Inicial.bFiltro = true;
            this.dgv_Inventario_Inicial.DataSource = null;
            this.dgv_Inventario_Inicial.Location = new System.Drawing.Point(251, 330);
            this.dgv_Inventario_Inicial.Name = "dgv_Inventario_Inicial";
            this.dgv_Inventario_Inicial.Size = new System.Drawing.Size(695, 244);
            this.dgv_Inventario_Inicial.strTitulo = null;
            this.dgv_Inventario_Inicial.TabIndex = 73;
            this.dgv_Inventario_Inicial.cell_Datagrid_ContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Inventario_Inicial_cell_Datagrid_ContentDoubleClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(41, 504);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(152, 48);
            this.btnEliminar.TabIndex = 96;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorial.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorial.ForeColor = System.Drawing.Color.White;
            this.btnHistorial.Location = new System.Drawing.Point(41, 446);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(152, 48);
            this.btnHistorial.TabIndex = 95;
            this.btnHistorial.Text = "Historial";
            this.btnHistorial.UseVisualStyleBackColor = false;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(41, 390);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(152, 48);
            this.btnActualizar.TabIndex = 94;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(41, 331);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(152, 48);
            this.btnAgregar.TabIndex = 93;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(41, 273);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(152, 48);
            this.btnBuscar.TabIndex = 92;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(64)))), ((int)(((byte)(9)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(857, 12);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(109, 50);
            this.btnLimpiar.TabIndex = 97;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(226)))), ((int)(((byte)(225)))));
            this.label1.Location = new System.Drawing.Point(725, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 30);
            this.label1.TabIndex = 98;
            // 
            // FrmRegistroInventarioProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::AppElyonCXC.Properties.Resources.Inventario_inicial_1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1084, 697);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txt_UnidadCompra);
            this.Controls.Add(this.txt_UnidadVenta);
            this.Controls.Add(this.txt_PrecioCompra);
            this.Controls.Add(this.chb_Decimales);
            this.Controls.Add(this.txt_UnidadVenta_Calculado);
            this.Controls.Add(this.txt_Importe);
            this.Controls.Add(this.dgv_Inventario_Inicial);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txt_Contenido);
            this.Controls.Add(this.txt_ClaveProducto);
            this.Controls.Add(this.label1);
            this.Name = "FrmRegistroInventarioProducto";
            this.Text = "FrmRegistroInventarioProducto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UcGrid dgv_Inventario_Inicial;
        private System.Windows.Forms.TextBox txt_Contenido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txt_ClaveProducto;
        private System.Windows.Forms.CheckBox chb_Decimales;
        private System.Windows.Forms.TextBox txt_PrecioCompra;
        private System.Windows.Forms.TextBox txt_UnidadVenta;
        private System.Windows.Forms.TextBox txt_UnidadCompra;
        private System.Windows.Forms.TextBox txt_Importe;
        private System.Windows.Forms.TextBox txt_UnidadVenta_Calculado;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label1;
    }
}