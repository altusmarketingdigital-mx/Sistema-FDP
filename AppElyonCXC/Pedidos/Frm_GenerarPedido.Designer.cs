namespace AppElyonCXC.Pedidos
{
    partial class Frm_GenerarPedido
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
            this.txt_Folio = new System.Windows.Forms.TextBox();
            this.dtp_Fecha = new System.Windows.Forms.DateTimePicker();
            this.txt_Cajero = new System.Windows.Forms.TextBox();
            this.txt_No_Pedido = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txt_Desc = new System.Windows.Forms.TextBox();
            this.txt_Direccion = new System.Windows.Forms.TextBox();
            this.txt_Cliente = new System.Windows.Forms.TextBox();
            this.txt_ClaveCliente = new System.Windows.Forms.TextBox();
            this.cmb_Metodo_Pago = new System.Windows.Forms.ComboBox();
            this.txt_Comentario = new System.Windows.Forms.TextBox();
            this.txt_Total_Pedido = new System.Windows.Forms.TextBox();
            this.btnGenerarPedido = new System.Windows.Forms.Button();
            this.btnCancelarPedido = new System.Windows.Forms.Button();
            this.dgv_Pedido = new System.Windows.Forms.DataGridView();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.rb_Requiere_Credito = new System.Windows.Forms.RadioButton();
            this.rb_No_Requiere_Credito = new System.Windows.Forms.RadioButton();
            this.txt_ClaveProducto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.pnlTicket = new System.Windows.Forms.Panel();
            this.txtTamañoTicket = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtFuenteTicket = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Pedido)).BeginInit();
            this.pnlTicket.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Folio
            // 
            this.txt_Folio.Enabled = false;
            this.txt_Folio.Location = new System.Drawing.Point(362, 102);
            this.txt_Folio.Multiline = true;
            this.txt_Folio.Name = "txt_Folio";
            this.txt_Folio.Size = new System.Drawing.Size(44, 25);
            this.txt_Folio.TabIndex = 1;
            this.txt_Folio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtp_Fecha
            // 
            this.dtp_Fecha.Enabled = false;
            this.dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Fecha.Location = new System.Drawing.Point(810, 106);
            this.dtp_Fecha.Name = "dtp_Fecha";
            this.dtp_Fecha.Size = new System.Drawing.Size(132, 20);
            this.dtp_Fecha.TabIndex = 1;
            // 
            // txt_Cajero
            // 
            this.txt_Cajero.Enabled = false;
            this.txt_Cajero.Location = new System.Drawing.Point(570, 103);
            this.txt_Cajero.Multiline = true;
            this.txt_Cajero.Name = "txt_Cajero";
            this.txt_Cajero.Size = new System.Drawing.Size(170, 25);
            this.txt_Cajero.TabIndex = 3;
            this.txt_Cajero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_No_Pedido
            // 
            this.txt_No_Pedido.Enabled = false;
            this.txt_No_Pedido.Location = new System.Drawing.Point(408, 102);
            this.txt_No_Pedido.Multiline = true;
            this.txt_No_Pedido.Name = "txt_No_Pedido";
            this.txt_No_Pedido.Size = new System.Drawing.Size(87, 25);
            this.txt_No_Pedido.TabIndex = 2;
            this.txt_No_Pedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Desc
            // 
            this.txt_Desc.Enabled = false;
            this.txt_Desc.Location = new System.Drawing.Point(878, 170);
            this.txt_Desc.Multiline = true;
            this.txt_Desc.Name = "txt_Desc";
            this.txt_Desc.Size = new System.Drawing.Size(64, 25);
            this.txt_Desc.TabIndex = 6;
            // 
            // txt_Direccion
            // 
            this.txt_Direccion.Enabled = false;
            this.txt_Direccion.Location = new System.Drawing.Point(328, 207);
            this.txt_Direccion.Multiline = true;
            this.txt_Direccion.Name = "txt_Direccion";
            this.txt_Direccion.Size = new System.Drawing.Size(614, 24);
            this.txt_Direccion.TabIndex = 7;
            // 
            // txt_Cliente
            // 
            this.txt_Cliente.Enabled = false;
            this.txt_Cliente.Location = new System.Drawing.Point(582, 170);
            this.txt_Cliente.Multiline = true;
            this.txt_Cliente.Name = "txt_Cliente";
            this.txt_Cliente.Size = new System.Drawing.Size(202, 25);
            this.txt_Cliente.TabIndex = 5;
            // 
            // txt_ClaveCliente
            // 
            this.txt_ClaveCliente.Location = new System.Drawing.Point(362, 170);
            this.txt_ClaveCliente.Multiline = true;
            this.txt_ClaveCliente.Name = "txt_ClaveCliente";
            this.txt_ClaveCliente.Size = new System.Drawing.Size(64, 25);
            this.txt_ClaveCliente.TabIndex = 4;
            this.txt_ClaveCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // cmb_Metodo_Pago
            // 
            this.cmb_Metodo_Pago.FormattingEnabled = true;
            this.cmb_Metodo_Pago.Location = new System.Drawing.Point(561, 473);
            this.cmb_Metodo_Pago.Name = "cmb_Metodo_Pago";
            this.cmb_Metodo_Pago.Size = new System.Drawing.Size(228, 21);
            this.cmb_Metodo_Pago.TabIndex = 10;
            // 
            // txt_Comentario
            // 
            this.txt_Comentario.Location = new System.Drawing.Point(436, 524);
            this.txt_Comentario.Multiline = true;
            this.txt_Comentario.Name = "txt_Comentario";
            this.txt_Comentario.Size = new System.Drawing.Size(355, 43);
            this.txt_Comentario.TabIndex = 13;
            // 
            // txt_Total_Pedido
            // 
            this.txt_Total_Pedido.BackColor = System.Drawing.Color.LightGray;
            this.txt_Total_Pedido.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Total_Pedido.Location = new System.Drawing.Point(814, 510);
            this.txt_Total_Pedido.Multiline = true;
            this.txt_Total_Pedido.Name = "txt_Total_Pedido";
            this.txt_Total_Pedido.Size = new System.Drawing.Size(124, 58);
            this.txt_Total_Pedido.TabIndex = 9;
            this.txt_Total_Pedido.Text = "0.00";
            this.txt_Total_Pedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnGenerarPedido
            // 
            this.btnGenerarPedido.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGenerarPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(103)))), ((int)(((byte)(102)))));
            this.btnGenerarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGenerarPedido.ForeColor = System.Drawing.Color.White;
            this.btnGenerarPedido.Location = new System.Drawing.Point(-100, 443);
            this.btnGenerarPedido.Name = "btnGenerarPedido";
            this.btnGenerarPedido.Size = new System.Drawing.Size(160, 53);
            this.btnGenerarPedido.TabIndex = 15;
            this.btnGenerarPedido.Text = "Generar pedido";
            this.btnGenerarPedido.UseVisualStyleBackColor = false;
            this.btnGenerarPedido.Click += new System.EventHandler(this.btnGenerarPedido_Click);
            // 
            // btnCancelarPedido
            // 
            this.btnCancelarPedido.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelarPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(103)))), ((int)(((byte)(102)))));
            this.btnCancelarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCancelarPedido.ForeColor = System.Drawing.Color.White;
            this.btnCancelarPedido.Location = new System.Drawing.Point(-100, 502);
            this.btnCancelarPedido.Name = "btnCancelarPedido";
            this.btnCancelarPedido.Size = new System.Drawing.Size(160, 53);
            this.btnCancelarPedido.TabIndex = 16;
            this.btnCancelarPedido.Text = "Cancelar pedido";
            this.btnCancelarPedido.UseVisualStyleBackColor = false;
            this.btnCancelarPedido.Click += new System.EventHandler(this.btnCancelarPedido_Click);
            // 
            // dgv_Pedido
            // 
            this.dgv_Pedido.AllowUserToAddRows = false;
            this.dgv_Pedido.AllowUserToDeleteRows = false;
            this.dgv_Pedido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Pedido.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_Pedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Pedido.Location = new System.Drawing.Point(249, 282);
            this.dgv_Pedido.MultiSelect = false;
            this.dgv_Pedido.Name = "dgv_Pedido";
            this.dgv_Pedido.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Pedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_Pedido.Size = new System.Drawing.Size(696, 176);
            this.dgv_Pedido.TabIndex = 9;
            this.dgv_Pedido.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Pedido_CellContentDoubleClick);
            this.dgv_Pedido.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_Pedido_DataError);
            this.dgv_Pedido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_Pedido_KeyDown);
            this.dgv_Pedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgv_Pedido_KeyPress);
            this.dgv_Pedido.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgv_Pedido_KeyUp_1);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(9)))));
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(715, 11);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(116, 52);
            this.btnLimpiar.TabIndex = 17;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(103)))), ((int)(((byte)(102)))));
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(-99, 384);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(160, 53);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "Buscar pedido";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // rb_Requiere_Credito
            // 
            this.rb_Requiere_Credito.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb_Requiere_Credito.Location = new System.Drawing.Point(250, 502);
            this.rb_Requiere_Credito.Name = "rb_Requiere_Credito";
            this.rb_Requiere_Credito.Size = new System.Drawing.Size(28, 26);
            this.rb_Requiere_Credito.TabIndex = 11;
            this.rb_Requiere_Credito.UseVisualStyleBackColor = true;
            this.rb_Requiere_Credito.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rb_No_Requiere_Credito
            // 
            this.rb_No_Requiere_Credito.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb_No_Requiere_Credito.Checked = true;
            this.rb_No_Requiere_Credito.Location = new System.Drawing.Point(250, 541);
            this.rb_No_Requiere_Credito.Name = "rb_No_Requiere_Credito";
            this.rb_No_Requiere_Credito.Size = new System.Drawing.Size(28, 26);
            this.rb_No_Requiere_Credito.TabIndex = 12;
            this.rb_No_Requiere_Credito.TabStop = true;
            this.rb_No_Requiere_Credito.UseVisualStyleBackColor = true;
            // 
            // txt_ClaveProducto
            // 
            this.txt_ClaveProducto.Location = new System.Drawing.Point(796, 252);
            this.txt_ClaveProducto.Multiline = true;
            this.txt_ClaveProducto.Name = "txt_ClaveProducto";
            this.txt_ClaveProducto.Size = new System.Drawing.Size(114, 22);
            this.txt_ClaveProducto.TabIndex = 8;
            this.txt_ClaveProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ClaveProducto_KeyDown);
            this.txt_ClaveProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ClaveProducto_KeyPress);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(226)))), ((int)(((byte)(225)))));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(226)))), ((int)(((byte)(225)))));
            this.label1.Location = new System.Drawing.Point(405, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(396, 33);
            this.label1.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(226)))), ((int)(((byte)(225)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(655, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 18);
            this.label2.TabIndex = 30;
            this.label2.Text = "Clave del producto:";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBuscarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(103)))), ((int)(((byte)(102)))));
            this.btnBuscarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnBuscarCliente.ForeColor = System.Drawing.Color.White;
            this.btnBuscarCliente.Location = new System.Drawing.Point(296, 166);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(70, 33);
            this.btnBuscarCliente.TabIndex = 31;
            this.btnBuscarCliente.Text = "Buscar";
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // pnlTicket
            // 
            this.pnlTicket.BackColor = System.Drawing.Color.Transparent;
            this.pnlTicket.Controls.Add(this.txtTamañoTicket);
            this.pnlTicket.Controls.Add(this.label20);
            this.pnlTicket.Controls.Add(this.txtFuenteTicket);
            this.pnlTicket.Controls.Add(this.label19);
            this.pnlTicket.Location = new System.Drawing.Point(12, 597);
            this.pnlTicket.Name = "pnlTicket";
            this.pnlTicket.Size = new System.Drawing.Size(192, 88);
            this.pnlTicket.TabIndex = 39;
            this.pnlTicket.Visible = false;
            // 
            // txtTamañoTicket
            // 
            this.txtTamañoTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTamañoTicket.Location = new System.Drawing.Point(3, 61);
            this.txtTamañoTicket.Name = "txtTamañoTicket";
            this.txtTamañoTicket.Size = new System.Drawing.Size(186, 24);
            this.txtTamañoTicket.TabIndex = 3;
            this.txtTamañoTicket.Text = "11";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(13, 45);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 13);
            this.label20.TabIndex = 2;
            this.label20.Text = "Tamaño:";
            // 
            // txtFuenteTicket
            // 
            this.txtFuenteTicket.Location = new System.Drawing.Point(3, 20);
            this.txtFuenteTicket.Name = "txtFuenteTicket";
            this.txtFuenteTicket.Size = new System.Drawing.Size(186, 20);
            this.txtFuenteTicket.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(13, 5);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Fuente:";
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscarProducto.BackgroundImage = global::AppElyonCXC.Properties.Resources.lupa__1_;
            this.btnBuscarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnBuscarProducto.ForeColor = System.Drawing.Color.White;
            this.btnBuscarProducto.Location = new System.Drawing.Point(916, 248);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(30, 29);
            this.btnBuscarProducto.TabIndex = 40;
            this.btnBuscarProducto.UseVisualStyleBackColor = false;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // Frm_GenerarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::AppElyonCXC.Properties.Resources.Datos_del_pedido___final_1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(807, 575);
            this.Controls.Add(this.btnBuscarProducto);
            this.Controls.Add(this.pnlTicket);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_ClaveProducto);
            this.Controls.Add(this.rb_No_Requiere_Credito);
            this.Controls.Add(this.rb_Requiere_Credito);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.cmb_Metodo_Pago);
            this.Controls.Add(this.dgv_Pedido);
            this.Controls.Add(this.dtp_Fecha);
            this.Controls.Add(this.txt_Comentario);
            this.Controls.Add(this.txt_Desc);
            this.Controls.Add(this.txt_Total_Pedido);
            this.Controls.Add(this.txt_Folio);
            this.Controls.Add(this.btnCancelarPedido);
            this.Controls.Add(this.txt_Direccion);
            this.Controls.Add(this.btnGenerarPedido);
            this.Controls.Add(this.txt_Cajero);
            this.Controls.Add(this.txt_Cliente);
            this.Controls.Add(this.txt_ClaveCliente);
            this.Controls.Add(this.txt_No_Pedido);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "Frm_GenerarPedido";
            this.Text = "Frm_GenerarPedido";
            this.Load += new System.EventHandler(this.Frm_GenerarPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Pedido)).EndInit();
            this.pnlTicket.ResumeLayout(false);
            this.pnlTicket.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txt_No_Pedido;
        private System.Windows.Forms.TextBox txt_Cajero;
        private System.Windows.Forms.DateTimePicker dtp_Fecha;
        private System.Windows.Forms.TextBox txt_Cliente;
        private System.Windows.Forms.TextBox txt_ClaveCliente;
        private System.Windows.Forms.TextBox txt_Direccion;
        private System.Windows.Forms.TextBox txt_Desc;
        private System.Windows.Forms.ComboBox cmb_Metodo_Pago;
        private System.Windows.Forms.TextBox txt_Comentario;
        private System.Windows.Forms.TextBox txt_Total_Pedido;
        private System.Windows.Forms.Button btnGenerarPedido;
        private System.Windows.Forms.Button btnCancelarPedido;
        private System.Windows.Forms.TextBox txt_Folio;
        private System.Windows.Forms.DataGridView dgv_Pedido;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txt_ClaveProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscarCliente;
        public System.Windows.Forms.RadioButton rb_Requiere_Credito;
        public System.Windows.Forms.RadioButton rb_No_Requiere_Credito;
        private System.Windows.Forms.Panel pnlTicket;
        private System.Windows.Forms.TextBox txtTamañoTicket;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtFuenteTicket;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnBuscarProducto;
    }
}