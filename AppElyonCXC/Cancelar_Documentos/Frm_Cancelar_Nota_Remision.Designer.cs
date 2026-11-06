namespace AppElyonCXC.Cancelar_Documentos
{
    partial class Frm_Cancelar_Nota_Remision
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
            this.dtp_Fecha_Pedido = new System.Windows.Forms.DateTimePicker();
            this.txt_Forma_Pago = new System.Windows.Forms.TextBox();
            this.dtp_Fecha_Timbrado = new System.Windows.Forms.DateTimePicker();
            this.txt_No_Pago = new System.Windows.Forms.TextBox();
            this.txt_Estado_Nota_Remision = new System.Windows.Forms.TextBox();
            this.txt_No_Pedido = new System.Windows.Forms.TextBox();
            this.txt_Cajero = new System.Windows.Forms.TextBox();
            this.dtp_Fecha_Nota_Remision = new System.Windows.Forms.DateTimePicker();
            this.txt_No_Nota_Remision = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txt_RFC_Cliente = new System.Windows.Forms.TextBox();
            this.txt_Nombre_Cliente = new System.Windows.Forms.TextBox();
            this.txt_No_Cliente = new System.Windows.Forms.TextBox();
            this.btnCancelarDocumento = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgv_Detalle_Pedido = new System.Windows.Forms.DataGridView();
            this.btnBuscarDocumento = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Detalle_Pedido)).BeginInit();
            this.SuspendLayout();
            // 
            // dtp_Fecha_Pedido
            // 
            this.dtp_Fecha_Pedido.Enabled = false;
            this.dtp_Fecha_Pedido.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Fecha_Pedido.Location = new System.Drawing.Point(557, 180);
            this.dtp_Fecha_Pedido.Name = "dtp_Fecha_Pedido";
            this.dtp_Fecha_Pedido.Size = new System.Drawing.Size(103, 20);
            this.dtp_Fecha_Pedido.TabIndex = 18;
            // 
            // txt_Forma_Pago
            // 
            this.txt_Forma_Pago.Enabled = false;
            this.txt_Forma_Pago.Location = new System.Drawing.Point(784, 219);
            this.txt_Forma_Pago.Multiline = true;
            this.txt_Forma_Pago.Name = "txt_Forma_Pago";
            this.txt_Forma_Pago.Size = new System.Drawing.Size(159, 20);
            this.txt_Forma_Pago.TabIndex = 17;
            // 
            // dtp_Fecha_Timbrado
            // 
            this.dtp_Fecha_Timbrado.Enabled = false;
            this.dtp_Fecha_Timbrado.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Fecha_Timbrado.Location = new System.Drawing.Point(559, 214);
            this.dtp_Fecha_Timbrado.Name = "dtp_Fecha_Timbrado";
            this.dtp_Fecha_Timbrado.Size = new System.Drawing.Size(102, 20);
            this.dtp_Fecha_Timbrado.TabIndex = 15;
            // 
            // txt_No_Pago
            // 
            this.txt_No_Pago.Enabled = false;
            this.txt_No_Pago.Location = new System.Drawing.Point(346, 209);
            this.txt_No_Pago.Multiline = true;
            this.txt_No_Pago.Name = "txt_No_Pago";
            this.txt_No_Pago.Size = new System.Drawing.Size(69, 25);
            this.txt_No_Pago.TabIndex = 13;
            // 
            // txt_Estado_Nota_Remision
            // 
            this.txt_Estado_Nota_Remision.Enabled = false;
            this.txt_Estado_Nota_Remision.Location = new System.Drawing.Point(860, 180);
            this.txt_Estado_Nota_Remision.Multiline = true;
            this.txt_Estado_Nota_Remision.Name = "txt_Estado_Nota_Remision";
            this.txt_Estado_Nota_Remision.Size = new System.Drawing.Size(83, 25);
            this.txt_Estado_Nota_Remision.TabIndex = 11;
            // 
            // txt_No_Pedido
            // 
            this.txt_No_Pedido.Enabled = false;
            this.txt_No_Pedido.Location = new System.Drawing.Point(355, 176);
            this.txt_No_Pedido.Multiline = true;
            this.txt_No_Pedido.Name = "txt_No_Pedido";
            this.txt_No_Pedido.Size = new System.Drawing.Size(68, 24);
            this.txt_No_Pedido.TabIndex = 7;
            // 
            // txt_Cajero
            // 
            this.txt_Cajero.Enabled = false;
            this.txt_Cajero.Location = new System.Drawing.Point(827, 144);
            this.txt_Cajero.Multiline = true;
            this.txt_Cajero.Name = "txt_Cajero";
            this.txt_Cajero.Size = new System.Drawing.Size(116, 24);
            this.txt_Cajero.TabIndex = 5;
            // 
            // dtp_Fecha_Nota_Remision
            // 
            this.dtp_Fecha_Nota_Remision.Enabled = false;
            this.dtp_Fecha_Nota_Remision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Fecha_Nota_Remision.Location = new System.Drawing.Point(652, 146);
            this.dtp_Fecha_Nota_Remision.Name = "dtp_Fecha_Nota_Remision";
            this.dtp_Fecha_Nota_Remision.Size = new System.Drawing.Size(104, 20);
            this.dtp_Fecha_Nota_Remision.TabIndex = 3;
            // 
            // txt_No_Nota_Remision
            // 
            this.txt_No_Nota_Remision.Location = new System.Drawing.Point(419, 144);
            this.txt_No_Nota_Remision.Multiline = true;
            this.txt_No_Nota_Remision.Name = "txt_No_Nota_Remision";
            this.txt_No_Nota_Remision.Size = new System.Drawing.Size(91, 23);
            this.txt_No_Nota_Remision.TabIndex = 1;
            this.txt_No_Nota_Remision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_No_Nota_Remision_KeyPress);
            // 
            // txt_RFC_Cliente
            // 
            this.txt_RFC_Cliente.Enabled = false;
            this.txt_RFC_Cliente.Location = new System.Drawing.Point(820, 297);
            this.txt_RFC_Cliente.Multiline = true;
            this.txt_RFC_Cliente.Name = "txt_RFC_Cliente";
            this.txt_RFC_Cliente.Size = new System.Drawing.Size(123, 25);
            this.txt_RFC_Cliente.TabIndex = 12;
            // 
            // txt_Nombre_Cliente
            // 
            this.txt_Nombre_Cliente.Enabled = false;
            this.txt_Nombre_Cliente.Location = new System.Drawing.Point(534, 298);
            this.txt_Nombre_Cliente.Multiline = true;
            this.txt_Nombre_Cliente.Name = "txt_Nombre_Cliente";
            this.txt_Nombre_Cliente.Size = new System.Drawing.Size(235, 24);
            this.txt_Nombre_Cliente.TabIndex = 3;
            // 
            // txt_No_Cliente
            // 
            this.txt_No_Cliente.Enabled = false;
            this.txt_No_Cliente.Location = new System.Drawing.Point(358, 298);
            this.txt_No_Cliente.Multiline = true;
            this.txt_No_Cliente.Name = "txt_No_Cliente";
            this.txt_No_Cliente.Size = new System.Drawing.Size(100, 24);
            this.txt_No_Cliente.TabIndex = 1;
            // 
            // btnCancelarDocumento
            // 
            this.btnCancelarDocumento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.btnCancelarDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCancelarDocumento.ForeColor = System.Drawing.Color.White;
            this.btnCancelarDocumento.Location = new System.Drawing.Point(37, 503);
            this.btnCancelarDocumento.Name = "btnCancelarDocumento";
            this.btnCancelarDocumento.Size = new System.Drawing.Size(157, 52);
            this.btnCancelarDocumento.TabIndex = 20;
            this.btnCancelarDocumento.Text = "Cancelar documento";
            this.btnCancelarDocumento.UseVisualStyleBackColor = false;
            this.btnCancelarDocumento.Click += new System.EventHandler(this.btnCancelarDocumento_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(9)))));
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(855, 11);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(111, 53);
            this.btnLimpiar.TabIndex = 19;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dgv_Detalle_Pedido
            // 
            this.dgv_Detalle_Pedido.AllowUserToAddRows = false;
            this.dgv_Detalle_Pedido.AllowUserToDeleteRows = false;
            this.dgv_Detalle_Pedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Detalle_Pedido.Location = new System.Drawing.Point(249, 332);
            this.dgv_Detalle_Pedido.Name = "dgv_Detalle_Pedido";
            this.dgv_Detalle_Pedido.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Detalle_Pedido.Size = new System.Drawing.Size(698, 243);
            this.dgv_Detalle_Pedido.TabIndex = 21;
            // 
            // btnBuscarDocumento
            // 
            this.btnBuscarDocumento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.btnBuscarDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnBuscarDocumento.ForeColor = System.Drawing.Color.White;
            this.btnBuscarDocumento.Location = new System.Drawing.Point(37, 441);
            this.btnBuscarDocumento.Name = "btnBuscarDocumento";
            this.btnBuscarDocumento.Size = new System.Drawing.Size(157, 52);
            this.btnBuscarDocumento.TabIndex = 22;
            this.btnBuscarDocumento.Text = "Buscar documento";
            this.btnBuscarDocumento.UseVisualStyleBackColor = false;
            this.btnBuscarDocumento.Click += new System.EventHandler(this.btnBuscarDocumento_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(510, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(456, 37);
            this.label1.TabIndex = 23;
            // 
            // Frm_Cancelar_Nota_Remision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::AppElyonCXC.Properties.Resources.Cancelar_nota_remisión;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1084, 697);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscarDocumento);
            this.Controls.Add(this.dtp_Fecha_Pedido);
            this.Controls.Add(this.txt_RFC_Cliente);
            this.Controls.Add(this.txt_Forma_Pago);
            this.Controls.Add(this.dtp_Fecha_Timbrado);
            this.Controls.Add(this.txt_No_Pago);
            this.Controls.Add(this.txt_No_Pedido);
            this.Controls.Add(this.txt_Cajero);
            this.Controls.Add(this.dtp_Fecha_Nota_Remision);
            this.Controls.Add(this.txt_No_Nota_Remision);
            this.Controls.Add(this.txt_Estado_Nota_Remision);
            this.Controls.Add(this.txt_Nombre_Cliente);
            this.Controls.Add(this.txt_No_Cliente);
            this.Controls.Add(this.dgv_Detalle_Pedido);
            this.Controls.Add(this.btnCancelarDocumento);
            this.Controls.Add(this.btnLimpiar);
            this.Name = "Frm_Cancelar_Nota_Remision";
            this.Text = "Frm_Cancelar_Nota_Remision";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Detalle_Pedido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txt_No_Nota_Remision;
        private System.Windows.Forms.DateTimePicker dtp_Fecha_Nota_Remision;
        private System.Windows.Forms.TextBox txt_Cajero;
        private System.Windows.Forms.TextBox txt_No_Pedido;
        private System.Windows.Forms.TextBox txt_Estado_Nota_Remision;
        private System.Windows.Forms.TextBox txt_RFC_Cliente;
        private System.Windows.Forms.TextBox txt_Nombre_Cliente;
        private System.Windows.Forms.TextBox txt_No_Cliente;
        private System.Windows.Forms.TextBox txt_No_Pago;
        private System.Windows.Forms.DateTimePicker dtp_Fecha_Timbrado;
        private System.Windows.Forms.TextBox txt_Forma_Pago;
        private System.Windows.Forms.Button btnCancelarDocumento;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgv_Detalle_Pedido;
        private System.Windows.Forms.DateTimePicker dtp_Fecha_Pedido;
        private System.Windows.Forms.Button btnBuscarDocumento;
        private System.Windows.Forms.Label label1;
    }
}