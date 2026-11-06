namespace AppElyonCXC.Pedidos
{
    partial class Frm_Convertir_Remision_Pedido
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
            this.dtp_Fecha_Remison = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Usuario = new System.Windows.Forms.TextBox();
            this.txt_Nota_Remision = new System.Windows.Forms.TextBox();
            this.txt_Total_Pedido = new System.Windows.Forms.TextBox();
            this.txt_Metodo_Pago = new System.Windows.Forms.TextBox();
            this.txt_Forma_Pago = new System.Windows.Forms.TextBox();
            this.dgv_Pedido = new System.Windows.Forms.DataGridView();
            this.txt_Folio_Pedido = new System.Windows.Forms.TextBox();
            this.txt_Cliente = new System.Windows.Forms.TextBox();
            this.dtp_FechaPedido = new System.Windows.Forms.DateTimePicker();
            this.txt_UsuarioPedido = new System.Windows.Forms.TextBox();
            this.btnCancelarPedido = new System.Windows.Forms.Button();
            this.btnGenerarPedido = new System.Windows.Forms.Button();
            this.btnBuscarPedido = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtNoCliente = new System.Windows.Forms.TextBox();
            this.txtNoPedido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Pedido)).BeginInit();
            this.SuspendLayout();
            // 
            // dtp_Fecha_Remison
            // 
            this.dtp_Fecha_Remison.Enabled = false;
            this.dtp_Fecha_Remison.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Fecha_Remison.Location = new System.Drawing.Point(964, 266);
            this.dtp_Fecha_Remison.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dtp_Fecha_Remison.Name = "dtp_Fecha_Remison";
            this.dtp_Fecha_Remison.Size = new System.Drawing.Size(184, 29);
            this.dtp_Fecha_Remison.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(959, 122);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(820, 70);
            this.label4.TabIndex = 6;
            // 
            // txt_Usuario
            // 
            this.txt_Usuario.Enabled = false;
            this.txt_Usuario.Location = new System.Drawing.Point(1296, 264);
            this.txt_Usuario.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_Usuario.Multiline = true;
            this.txt_Usuario.Name = "txt_Usuario";
            this.txt_Usuario.Size = new System.Drawing.Size(290, 41);
            this.txt_Usuario.TabIndex = 5;
            this.txt_Usuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Nota_Remision
            // 
            this.txt_Nota_Remision.Enabled = false;
            this.txt_Nota_Remision.Location = new System.Drawing.Point(669, 260);
            this.txt_Nota_Remision.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_Nota_Remision.Multiline = true;
            this.txt_Nota_Remision.Name = "txt_Nota_Remision";
            this.txt_Nota_Remision.Size = new System.Drawing.Size(164, 41);
            this.txt_Nota_Remision.TabIndex = 3;
            this.txt_Nota_Remision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Total_Pedido
            // 
            this.txt_Total_Pedido.Enabled = false;
            this.txt_Total_Pedido.Location = new System.Drawing.Point(1535, 550);
            this.txt_Total_Pedido.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_Total_Pedido.Multiline = true;
            this.txt_Total_Pedido.Name = "txt_Total_Pedido";
            this.txt_Total_Pedido.Size = new System.Drawing.Size(187, 41);
            this.txt_Total_Pedido.TabIndex = 17;
            this.txt_Total_Pedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Metodo_Pago
            // 
            this.txt_Metodo_Pago.Enabled = false;
            this.txt_Metodo_Pago.Location = new System.Drawing.Point(1093, 546);
            this.txt_Metodo_Pago.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_Metodo_Pago.Multiline = true;
            this.txt_Metodo_Pago.Name = "txt_Metodo_Pago";
            this.txt_Metodo_Pago.Size = new System.Drawing.Size(193, 69);
            this.txt_Metodo_Pago.TabIndex = 15;
            this.txt_Metodo_Pago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Forma_Pago
            // 
            this.txt_Forma_Pago.Enabled = false;
            this.txt_Forma_Pago.Location = new System.Drawing.Point(662, 550);
            this.txt_Forma_Pago.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_Forma_Pago.Multiline = true;
            this.txt_Forma_Pago.Name = "txt_Forma_Pago";
            this.txt_Forma_Pago.Size = new System.Drawing.Size(180, 41);
            this.txt_Forma_Pago.TabIndex = 8;
            this.txt_Forma_Pago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgv_Pedido
            // 
            this.dgv_Pedido.AllowUserToAddRows = false;
            this.dgv_Pedido.AllowUserToDeleteRows = false;
            this.dgv_Pedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Pedido.Enabled = false;
            this.dgv_Pedido.Location = new System.Drawing.Point(457, 683);
            this.dgv_Pedido.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgv_Pedido.Name = "dgv_Pedido";
            this.dgv_Pedido.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Pedido.Size = new System.Drawing.Size(1280, 377);
            this.dgv_Pedido.TabIndex = 1;
            // 
            // txt_Folio_Pedido
            // 
            this.txt_Folio_Pedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txt_Folio_Pedido.Location = new System.Drawing.Point(656, 408);
            this.txt_Folio_Pedido.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_Folio_Pedido.Name = "txt_Folio_Pedido";
            this.txt_Folio_Pedido.Size = new System.Drawing.Size(70, 29);
            this.txt_Folio_Pedido.TabIndex = 18;
            this.txt_Folio_Pedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Cliente
            // 
            this.txt_Cliente.Enabled = false;
            this.txt_Cliente.Location = new System.Drawing.Point(979, 476);
            this.txt_Cliente.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_Cliente.Multiline = true;
            this.txt_Cliente.Name = "txt_Cliente";
            this.txt_Cliente.Size = new System.Drawing.Size(428, 45);
            this.txt_Cliente.TabIndex = 8;
            this.txt_Cliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtp_FechaPedido
            // 
            this.dtp_FechaPedido.Enabled = false;
            this.dtp_FechaPedido.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_FechaPedido.Location = new System.Drawing.Point(1540, 406);
            this.dtp_FechaPedido.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dtp_FechaPedido.Name = "dtp_FechaPedido";
            this.dtp_FechaPedido.Size = new System.Drawing.Size(184, 29);
            this.dtp_FechaPedido.TabIndex = 2;
            // 
            // txt_UsuarioPedido
            // 
            this.txt_UsuarioPedido.Enabled = false;
            this.txt_UsuarioPedido.Location = new System.Drawing.Point(1029, 402);
            this.txt_UsuarioPedido.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_UsuarioPedido.Multiline = true;
            this.txt_UsuarioPedido.Name = "txt_UsuarioPedido";
            this.txt_UsuarioPedido.Size = new System.Drawing.Size(257, 41);
            this.txt_UsuarioPedido.TabIndex = 5;
            this.txt_UsuarioPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCancelarPedido
            // 
            this.btnCancelarPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.btnCancelarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCancelarPedido.ForeColor = System.Drawing.Color.White;
            this.btnCancelarPedido.Location = new System.Drawing.Point(70, 930);
            this.btnCancelarPedido.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCancelarPedido.Name = "btnCancelarPedido";
            this.btnCancelarPedido.Size = new System.Drawing.Size(290, 94);
            this.btnCancelarPedido.TabIndex = 15;
            this.btnCancelarPedido.Text = "Cancelar nota remisión";
            this.btnCancelarPedido.UseVisualStyleBackColor = false;
            this.btnCancelarPedido.Click += new System.EventHandler(this.btnCancelarPedido_Click);
            // 
            // btnGenerarPedido
            // 
            this.btnGenerarPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.btnGenerarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGenerarPedido.ForeColor = System.Drawing.Color.White;
            this.btnGenerarPedido.Location = new System.Drawing.Point(70, 816);
            this.btnGenerarPedido.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnGenerarPedido.Name = "btnGenerarPedido";
            this.btnGenerarPedido.Size = new System.Drawing.Size(290, 94);
            this.btnGenerarPedido.TabIndex = 14;
            this.btnGenerarPedido.Text = "Generar nota remisión";
            this.btnGenerarPedido.UseVisualStyleBackColor = false;
            this.btnGenerarPedido.Click += new System.EventHandler(this.btnGenerarPedido_Click);
            // 
            // btnBuscarPedido
            // 
            this.btnBuscarPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.btnBuscarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnBuscarPedido.ForeColor = System.Drawing.Color.White;
            this.btnBuscarPedido.Location = new System.Drawing.Point(70, 700);
            this.btnBuscarPedido.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnBuscarPedido.Name = "btnBuscarPedido";
            this.btnBuscarPedido.Size = new System.Drawing.Size(290, 94);
            this.btnBuscarPedido.TabIndex = 27;
            this.btnBuscarPedido.Text = "Buscar pedido";
            this.btnBuscarPedido.UseVisualStyleBackColor = false;
            this.btnBuscarPedido.Click += new System.EventHandler(this.btnBuscarPedido_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(9)))));
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(1514, 22);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(213, 96);
            this.btnLimpiar.TabIndex = 28;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtNoCliente
            // 
            this.txtNoCliente.Enabled = false;
            this.txtNoCliente.Location = new System.Drawing.Point(656, 476);
            this.txtNoCliente.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtNoCliente.Multiline = true;
            this.txtNoCliente.Name = "txtNoCliente";
            this.txtNoCliente.Size = new System.Drawing.Size(180, 41);
            this.txtNoCliente.TabIndex = 29;
            this.txtNoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNoPedido
            // 
            this.txtNoPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtNoPedido.Location = new System.Drawing.Point(739, 408);
            this.txtNoPedido.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtNoPedido.Name = "txtNoPedido";
            this.txtNoPedido.Size = new System.Drawing.Size(142, 29);
            this.txtNoPedido.TabIndex = 30;
            this.txtNoPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNoPedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox5_KeyPress);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(651, 401);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 52);
            this.label1.TabIndex = 31;
            // 
            // Frm_Convertir_Remision_Pedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::AppElyonCXC.Properties.Resources.Generar_Remisión;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1885, 1287);
            this.Controls.Add(this.txtNoPedido);
            this.Controls.Add(this.txtNoCliente);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtp_Fecha_Remison);
            this.Controls.Add(this.txt_Usuario);
            this.Controls.Add(this.txt_Nota_Remision);
            this.Controls.Add(this.txt_Folio_Pedido);
            this.Controls.Add(this.btnBuscarPedido);
            this.Controls.Add(this.dgv_Pedido);
            this.Controls.Add(this.txt_Cliente);
            this.Controls.Add(this.txt_Total_Pedido);
            this.Controls.Add(this.dtp_FechaPedido);
            this.Controls.Add(this.btnCancelarPedido);
            this.Controls.Add(this.btnGenerarPedido);
            this.Controls.Add(this.txt_UsuarioPedido);
            this.Controls.Add(this.txt_Metodo_Pago);
            this.Controls.Add(this.txt_Forma_Pago);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximumSize = new System.Drawing.Size(1909, 1351);
            this.MinimumSize = new System.Drawing.Size(1909, 1351);
            this.Name = "Frm_Convertir_Remision_Pedido";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Pedido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_Nota_Remision;
        private System.Windows.Forms.DateTimePicker dtp_Fecha_Remison;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Usuario;
        private System.Windows.Forms.TextBox txt_Cliente;
        private System.Windows.Forms.DateTimePicker dtp_FechaPedido;
        private System.Windows.Forms.TextBox txt_UsuarioPedido;
        private System.Windows.Forms.DataGridView dgv_Pedido;
        private System.Windows.Forms.TextBox txt_Forma_Pago;
        private System.Windows.Forms.TextBox txt_Metodo_Pago;
        private System.Windows.Forms.TextBox txt_Total_Pedido;
        private System.Windows.Forms.Button btnCancelarPedido;
        private System.Windows.Forms.Button btnGenerarPedido;
        private System.Windows.Forms.TextBox txt_Folio_Pedido;
        private System.Windows.Forms.Button btnBuscarPedido;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtNoCliente;
        private System.Windows.Forms.TextBox txtNoPedido;
        private System.Windows.Forms.Label label1;
    }
}