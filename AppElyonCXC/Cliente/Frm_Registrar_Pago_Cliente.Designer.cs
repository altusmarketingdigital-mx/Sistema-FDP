namespace AppElyonCXC.Cliente
{
    partial class Frm_Registrar_Pago_Cliente
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
            this.txt_Dias_Credito = new System.Windows.Forms.TextBox();
            this.txt_RFC_Cliente = new System.Windows.Forms.TextBox();
            this.txt_Nombre_Cliente = new System.Windows.Forms.TextBox();
            this.txt_No_Cliente = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txt_UUID = new System.Windows.Forms.TextBox();
            this.txt_Intereses = new System.Windows.Forms.TextBox();
            this.txt_Estatus_Documento = new System.Windows.Forms.TextBox();
            this.txt_Adeudo = new System.Windows.Forms.TextBox();
            this.dtp_Fecha_Ultimo_Pago = new System.Windows.Forms.DateTimePicker();
            this.txt_Dias_Vencidos = new System.Windows.Forms.TextBox();
            this.txt_Plazo_Pago = new System.Windows.Forms.TextBox();
            this.dtp_Fecha_Vencimientos = new System.Windows.Forms.DateTimePicker();
            this.dtp_Fecha_Generacion = new System.Windows.Forms.DateTimePicker();
            this.txt_No_Remision = new System.Windows.Forms.TextBox();
            this.txt_No_Pago_Anterior = new System.Windows.Forms.TextBox();
            this.dtp_Fecha_Timbrado = new System.Windows.Forms.DateTimePicker();
            this.txt_Saldo_Nuevo = new System.Windows.Forms.TextBox();
            this.txt_Importe_A_Pagar = new System.Windows.Forms.TextBox();
            this.txt_Saldo_Favor = new System.Windows.Forms.TextBox();
            this.txt_Cantidad_Interes = new System.Windows.Forms.TextBox();
            this.txt_Saldo_Anterio = new System.Windows.Forms.TextBox();
            this.txt_Comentario_Pago = new System.Windows.Forms.TextBox();
            this.txt_Cambio = new System.Windows.Forms.TextBox();
            this.txt_Total_Pagado = new System.Windows.Forms.TextBox();
            this.cmb_Tipo_Pago = new System.Windows.Forms.ComboBox();
            this.txt_Importe_Pago = new System.Windows.Forms.TextBox();
            this.btnHistorialPago = new System.Windows.Forms.Button();
            this.btnCancelarPago = new System.Windows.Forms.Button();
            this.btnGenerarPago = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscarRemision = new System.Windows.Forms.Button();
            this.pnlTicket = new System.Windows.Forms.Panel();
            this.txtTamañoTicket = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtFuenteTicket = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.pnlTicket.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Dias_Credito
            // 
            this.txt_Dias_Credito.Enabled = false;
            this.txt_Dias_Credito.Location = new System.Drawing.Point(640, 137);
            this.txt_Dias_Credito.Multiline = true;
            this.txt_Dias_Credito.Name = "txt_Dias_Credito";
            this.txt_Dias_Credito.Size = new System.Drawing.Size(134, 24);
            this.txt_Dias_Credito.TabIndex = 3;
            this.txt_Dias_Credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_RFC_Cliente
            // 
            this.txt_RFC_Cliente.Enabled = false;
            this.txt_RFC_Cliente.Location = new System.Drawing.Point(288, 137);
            this.txt_RFC_Cliente.Multiline = true;
            this.txt_RFC_Cliente.Name = "txt_RFC_Cliente";
            this.txt_RFC_Cliente.Size = new System.Drawing.Size(229, 24);
            this.txt_RFC_Cliente.TabIndex = 3;
            this.txt_RFC_Cliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Nombre_Cliente
            // 
            this.txt_Nombre_Cliente.Enabled = false;
            this.txt_Nombre_Cliente.Location = new System.Drawing.Point(498, 104);
            this.txt_Nombre_Cliente.Multiline = true;
            this.txt_Nombre_Cliente.Name = "txt_Nombre_Cliente";
            this.txt_Nombre_Cliente.Size = new System.Drawing.Size(442, 24);
            this.txt_Nombre_Cliente.TabIndex = 3;
            this.txt_Nombre_Cliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_No_Cliente
            // 
            this.txt_No_Cliente.Location = new System.Drawing.Point(359, 104);
            this.txt_No_Cliente.Multiline = true;
            this.txt_No_Cliente.Name = "txt_No_Cliente";
            this.txt_No_Cliente.Size = new System.Drawing.Size(64, 24);
            this.txt_No_Cliente.TabIndex = 1;
            this.txt_No_Cliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_No_Cliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_No_Cliente_KeyPress);
            // 
            // txt_UUID
            // 
            this.txt_UUID.Enabled = false;
            this.txt_UUID.Location = new System.Drawing.Point(298, 311);
            this.txt_UUID.Multiline = true;
            this.txt_UUID.Name = "txt_UUID";
            this.txt_UUID.Size = new System.Drawing.Size(319, 24);
            this.txt_UUID.TabIndex = 15;
            this.txt_UUID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Intereses
            // 
            this.txt_Intereses.Enabled = false;
            this.txt_Intereses.Location = new System.Drawing.Point(810, 276);
            this.txt_Intereses.Multiline = true;
            this.txt_Intereses.Name = "txt_Intereses";
            this.txt_Intereses.Size = new System.Drawing.Size(131, 23);
            this.txt_Intereses.TabIndex = 7;
            this.txt_Intereses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Estatus_Documento
            // 
            this.txt_Estatus_Documento.Enabled = false;
            this.txt_Estatus_Documento.Location = new System.Drawing.Point(581, 276);
            this.txt_Estatus_Documento.Multiline = true;
            this.txt_Estatus_Documento.Name = "txt_Estatus_Documento";
            this.txt_Estatus_Documento.Size = new System.Drawing.Size(132, 25);
            this.txt_Estatus_Documento.TabIndex = 7;
            this.txt_Estatus_Documento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Adeudo
            // 
            this.txt_Adeudo.Enabled = false;
            this.txt_Adeudo.Location = new System.Drawing.Point(314, 276);
            this.txt_Adeudo.Multiline = true;
            this.txt_Adeudo.Name = "txt_Adeudo";
            this.txt_Adeudo.Size = new System.Drawing.Size(96, 24);
            this.txt_Adeudo.TabIndex = 13;
            this.txt_Adeudo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtp_Fecha_Ultimo_Pago
            // 
            this.dtp_Fecha_Ultimo_Pago.Enabled = false;
            this.dtp_Fecha_Ultimo_Pago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Fecha_Ultimo_Pago.Location = new System.Drawing.Point(844, 242);
            this.dtp_Fecha_Ultimo_Pago.Name = "dtp_Fecha_Ultimo_Pago";
            this.dtp_Fecha_Ultimo_Pago.Size = new System.Drawing.Size(97, 20);
            this.dtp_Fecha_Ultimo_Pago.TabIndex = 11;
            // 
            // txt_Dias_Vencidos
            // 
            this.txt_Dias_Vencidos.Enabled = false;
            this.txt_Dias_Vencidos.Location = new System.Drawing.Point(580, 241);
            this.txt_Dias_Vencidos.Multiline = true;
            this.txt_Dias_Vencidos.Name = "txt_Dias_Vencidos";
            this.txt_Dias_Vencidos.Size = new System.Drawing.Size(94, 24);
            this.txt_Dias_Vencidos.TabIndex = 5;
            this.txt_Dias_Vencidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Plazo_Pago
            // 
            this.txt_Plazo_Pago.Enabled = false;
            this.txt_Plazo_Pago.Location = new System.Drawing.Point(361, 241);
            this.txt_Plazo_Pago.Multiline = true;
            this.txt_Plazo_Pago.Name = "txt_Plazo_Pago";
            this.txt_Plazo_Pago.Size = new System.Drawing.Size(97, 24);
            this.txt_Plazo_Pago.TabIndex = 5;
            this.txt_Plazo_Pago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Plazo_Pago.TextChanged += new System.EventHandler(this.txt_Plazo_Pago_TextChanged);
            // 
            // dtp_Fecha_Vencimientos
            // 
            this.dtp_Fecha_Vencimientos.Enabled = false;
            this.dtp_Fecha_Vencimientos.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Fecha_Vencimientos.Location = new System.Drawing.Point(849, 206);
            this.dtp_Fecha_Vencimientos.Name = "dtp_Fecha_Vencimientos";
            this.dtp_Fecha_Vencimientos.Size = new System.Drawing.Size(93, 20);
            this.dtp_Fecha_Vencimientos.TabIndex = 9;
            // 
            // dtp_Fecha_Generacion
            // 
            this.dtp_Fecha_Generacion.Enabled = false;
            this.dtp_Fecha_Generacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Fecha_Generacion.Location = new System.Drawing.Point(589, 207);
            this.dtp_Fecha_Generacion.Name = "dtp_Fecha_Generacion";
            this.dtp_Fecha_Generacion.Size = new System.Drawing.Size(97, 20);
            this.dtp_Fecha_Generacion.TabIndex = 7;
            // 
            // txt_No_Remision
            // 
            this.txt_No_Remision.Location = new System.Drawing.Point(369, 207);
            this.txt_No_Remision.Multiline = true;
            this.txt_No_Remision.Name = "txt_No_Remision";
            this.txt_No_Remision.Size = new System.Drawing.Size(58, 23);
            this.txt_No_Remision.TabIndex = 5;
            this.txt_No_Remision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_No_Remision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_No_Remision_KeyPress);
            // 
            // txt_No_Pago_Anterior
            // 
            this.txt_No_Pago_Anterior.Enabled = false;
            this.txt_No_Pago_Anterior.Location = new System.Drawing.Point(790, 311);
            this.txt_No_Pago_Anterior.Multiline = true;
            this.txt_No_Pago_Anterior.Name = "txt_No_Pago_Anterior";
            this.txt_No_Pago_Anterior.Size = new System.Drawing.Size(150, 23);
            this.txt_No_Pago_Anterior.TabIndex = 17;
            this.txt_No_Pago_Anterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtp_Fecha_Timbrado
            // 
            this.dtp_Fecha_Timbrado.Enabled = false;
            this.dtp_Fecha_Timbrado.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Fecha_Timbrado.Location = new System.Drawing.Point(837, 414);
            this.dtp_Fecha_Timbrado.Name = "dtp_Fecha_Timbrado";
            this.dtp_Fecha_Timbrado.Size = new System.Drawing.Size(103, 20);
            this.dtp_Fecha_Timbrado.TabIndex = 18;
            // 
            // txt_Saldo_Nuevo
            // 
            this.txt_Saldo_Nuevo.Enabled = false;
            this.txt_Saldo_Nuevo.Location = new System.Drawing.Point(587, 412);
            this.txt_Saldo_Nuevo.Multiline = true;
            this.txt_Saldo_Nuevo.Name = "txt_Saldo_Nuevo";
            this.txt_Saldo_Nuevo.Size = new System.Drawing.Size(99, 24);
            this.txt_Saldo_Nuevo.TabIndex = 27;
            this.txt_Saldo_Nuevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Importe_A_Pagar
            // 
            this.txt_Importe_A_Pagar.Enabled = false;
            this.txt_Importe_A_Pagar.Location = new System.Drawing.Point(369, 411);
            this.txt_Importe_A_Pagar.Multiline = true;
            this.txt_Importe_A_Pagar.Name = "txt_Importe_A_Pagar";
            this.txt_Importe_A_Pagar.Size = new System.Drawing.Size(113, 23);
            this.txt_Importe_A_Pagar.TabIndex = 25;
            this.txt_Importe_A_Pagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Saldo_Favor
            // 
            this.txt_Saldo_Favor.Enabled = false;
            this.txt_Saldo_Favor.Location = new System.Drawing.Point(815, 379);
            this.txt_Saldo_Favor.Multiline = true;
            this.txt_Saldo_Favor.Name = "txt_Saldo_Favor";
            this.txt_Saldo_Favor.Size = new System.Drawing.Size(125, 23);
            this.txt_Saldo_Favor.TabIndex = 23;
            this.txt_Saldo_Favor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Cantidad_Interes
            // 
            this.txt_Cantidad_Interes.Enabled = false;
            this.txt_Cantidad_Interes.Location = new System.Drawing.Point(592, 379);
            this.txt_Cantidad_Interes.Multiline = true;
            this.txt_Cantidad_Interes.Name = "txt_Cantidad_Interes";
            this.txt_Cantidad_Interes.Size = new System.Drawing.Size(110, 23);
            this.txt_Cantidad_Interes.TabIndex = 21;
            this.txt_Cantidad_Interes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Saldo_Anterio
            // 
            this.txt_Saldo_Anterio.Enabled = false;
            this.txt_Saldo_Anterio.Location = new System.Drawing.Point(355, 377);
            this.txt_Saldo_Anterio.Multiline = true;
            this.txt_Saldo_Anterio.Name = "txt_Saldo_Anterio";
            this.txt_Saldo_Anterio.Size = new System.Drawing.Size(129, 23);
            this.txt_Saldo_Anterio.TabIndex = 19;
            this.txt_Saldo_Anterio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Comentario_Pago
            // 
            this.txt_Comentario_Pago.Location = new System.Drawing.Point(344, 445);
            this.txt_Comentario_Pago.Multiline = true;
            this.txt_Comentario_Pago.Name = "txt_Comentario_Pago";
            this.txt_Comentario_Pago.Size = new System.Drawing.Size(596, 24);
            this.txt_Comentario_Pago.TabIndex = 31;
            this.txt_Comentario_Pago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Cambio
            // 
            this.txt_Cambio.Enabled = false;
            this.txt_Cambio.Location = new System.Drawing.Point(578, 539);
            this.txt_Cambio.Multiline = true;
            this.txt_Cambio.Name = "txt_Cambio";
            this.txt_Cambio.Size = new System.Drawing.Size(156, 24);
            this.txt_Cambio.TabIndex = 37;
            this.txt_Cambio.Text = "0.00";
            this.txt_Cambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Total_Pagado
            // 
            this.txt_Total_Pagado.Location = new System.Drawing.Point(347, 540);
            this.txt_Total_Pagado.Multiline = true;
            this.txt_Total_Pagado.Name = "txt_Total_Pagado";
            this.txt_Total_Pagado.Size = new System.Drawing.Size(156, 24);
            this.txt_Total_Pagado.TabIndex = 35;
            this.txt_Total_Pagado.Text = "0.00";
            this.txt_Total_Pagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Total_Pagado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Total_Pagado_KeyPress);
            // 
            // cmb_Tipo_Pago
            // 
            this.cmb_Tipo_Pago.FormattingEnabled = true;
            this.cmb_Tipo_Pago.Location = new System.Drawing.Point(347, 506);
            this.cmb_Tipo_Pago.Name = "cmb_Tipo_Pago";
            this.cmb_Tipo_Pago.Size = new System.Drawing.Size(156, 21);
            this.cmb_Tipo_Pago.TabIndex = 34;
            // 
            // txt_Importe_Pago
            // 
            this.txt_Importe_Pago.Location = new System.Drawing.Point(640, 504);
            this.txt_Importe_Pago.Multiline = true;
            this.txt_Importe_Pago.Name = "txt_Importe_Pago";
            this.txt_Importe_Pago.Size = new System.Drawing.Size(156, 24);
            this.txt_Importe_Pago.TabIndex = 29;
            this.txt_Importe_Pago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnHistorialPago
            // 
            this.btnHistorialPago.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnHistorialPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.btnHistorialPago.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnHistorialPago.ForeColor = System.Drawing.Color.White;
            this.btnHistorialPago.Location = new System.Drawing.Point(37, 504);
            this.btnHistorialPago.Name = "btnHistorialPago";
            this.btnHistorialPago.Size = new System.Drawing.Size(162, 48);
            this.btnHistorialPago.TabIndex = 17;
            this.btnHistorialPago.Text = "Historial pago";
            this.btnHistorialPago.UseVisualStyleBackColor = false;
            // 
            // btnCancelarPago
            // 
            this.btnCancelarPago.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelarPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.btnCancelarPago.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancelarPago.ForeColor = System.Drawing.Color.White;
            this.btnCancelarPago.Location = new System.Drawing.Point(37, 390);
            this.btnCancelarPago.Name = "btnCancelarPago";
            this.btnCancelarPago.Size = new System.Drawing.Size(162, 49);
            this.btnCancelarPago.TabIndex = 16;
            this.btnCancelarPago.Text = "Cancelar pago";
            this.btnCancelarPago.UseVisualStyleBackColor = false;
            this.btnCancelarPago.Click += new System.EventHandler(this.btnCancelarPago_Click);
            // 
            // btnGenerarPago
            // 
            this.btnGenerarPago.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGenerarPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.btnGenerarPago.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnGenerarPago.ForeColor = System.Drawing.Color.White;
            this.btnGenerarPago.Location = new System.Drawing.Point(37, 445);
            this.btnGenerarPago.Name = "btnGenerarPago";
            this.btnGenerarPago.Size = new System.Drawing.Size(162, 48);
            this.btnGenerarPago.TabIndex = 18;
            this.btnGenerarPago.Text = "Generar pago";
            this.btnGenerarPago.UseVisualStyleBackColor = false;
            this.btnGenerarPago.Click += new System.EventHandler(this.btnGenerarPago_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(878, 170);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(63, 24);
            this.textBox1.TabIndex = 38;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(64)))), ((int)(((byte)(9)))));
            this.btnLimpiar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(857, 12);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(110, 50);
            this.btnLimpiar.TabIndex = 77;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBuscarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.btnBuscarCliente.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnBuscarCliente.ForeColor = System.Drawing.Color.White;
            this.btnBuscarCliente.Location = new System.Drawing.Point(37, 276);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(162, 48);
            this.btnBuscarCliente.TabIndex = 78;
            this.btnBuscarCliente.Text = "Buscar cliente";
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(226)))));
            this.label1.Location = new System.Drawing.Point(454, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 79;
            // 
            // btnBuscarRemision
            // 
            this.btnBuscarRemision.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBuscarRemision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.btnBuscarRemision.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnBuscarRemision.ForeColor = System.Drawing.Color.White;
            this.btnBuscarRemision.Location = new System.Drawing.Point(37, 333);
            this.btnBuscarRemision.Name = "btnBuscarRemision";
            this.btnBuscarRemision.Size = new System.Drawing.Size(162, 48);
            this.btnBuscarRemision.TabIndex = 80;
            this.btnBuscarRemision.Text = "Buscar remisión";
            this.btnBuscarRemision.UseVisualStyleBackColor = false;
            this.btnBuscarRemision.Click += new System.EventHandler(this.btnBuscarRemision_Click);
            // 
            // pnlTicket
            // 
            this.pnlTicket.BackColor = System.Drawing.Color.Transparent;
            this.pnlTicket.Controls.Add(this.txtTamañoTicket);
            this.pnlTicket.Controls.Add(this.label20);
            this.pnlTicket.Controls.Add(this.txtFuenteTicket);
            this.pnlTicket.Controls.Add(this.label19);
            this.pnlTicket.Location = new System.Drawing.Point(12, 575);
            this.pnlTicket.Name = "pnlTicket";
            this.pnlTicket.Size = new System.Drawing.Size(192, 88);
            this.pnlTicket.TabIndex = 81;
            this.pnlTicket.Visible = false;
            // 
            // txtTamañoTicket
            // 
            this.txtTamañoTicket.Location = new System.Drawing.Point(3, 61);
            this.txtTamañoTicket.Name = "txtTamañoTicket";
            this.txtTamañoTicket.Size = new System.Drawing.Size(186, 20);
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
            // Frm_Registrar_Pago_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::AppElyonCXC.Properties.Resources.Registro_de_pago;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1084, 697);
            this.Controls.Add(this.pnlTicket);
            this.Controls.Add(this.btnBuscarRemision);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.txt_RFC_Cliente);
            this.Controls.Add(this.txt_Dias_Credito);
            this.Controls.Add(this.txt_Nombre_Cliente);
            this.Controls.Add(this.txt_No_Cliente);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txt_UUID);
            this.Controls.Add(this.txt_No_Pago_Anterior);
            this.Controls.Add(this.txt_Estatus_Documento);
            this.Controls.Add(this.txt_Adeudo);
            this.Controls.Add(this.txt_Intereses);
            this.Controls.Add(this.dtp_Fecha_Ultimo_Pago);
            this.Controls.Add(this.txt_Plazo_Pago);
            this.Controls.Add(this.txt_Dias_Vencidos);
            this.Controls.Add(this.dtp_Fecha_Vencimientos);
            this.Controls.Add(this.dtp_Fecha_Generacion);
            this.Controls.Add(this.txt_No_Remision);
            this.Controls.Add(this.btnGenerarPago);
            this.Controls.Add(this.dtp_Fecha_Timbrado);
            this.Controls.Add(this.txt_Saldo_Nuevo);
            this.Controls.Add(this.txt_Importe_A_Pagar);
            this.Controls.Add(this.txt_Saldo_Favor);
            this.Controls.Add(this.txt_Cantidad_Interes);
            this.Controls.Add(this.txt_Saldo_Anterio);
            this.Controls.Add(this.txt_Comentario_Pago);
            this.Controls.Add(this.txt_Cambio);
            this.Controls.Add(this.cmb_Tipo_Pago);
            this.Controls.Add(this.txt_Total_Pagado);
            this.Controls.Add(this.btnHistorialPago);
            this.Controls.Add(this.btnCancelarPago);
            this.Controls.Add(this.txt_Importe_Pago);
            this.Name = "Frm_Registrar_Pago_Cliente";
            this.Text = "Frm_Registrar_Pago_Cliente";
            this.pnlTicket.ResumeLayout(false);
            this.pnlTicket.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txt_No_Cliente;
        private System.Windows.Forms.TextBox txt_Dias_Credito;
        private System.Windows.Forms.TextBox txt_RFC_Cliente;
        private System.Windows.Forms.TextBox txt_Nombre_Cliente;
        private System.Windows.Forms.TextBox txt_No_Remision;
        private System.Windows.Forms.DateTimePicker dtp_Fecha_Generacion;
        private System.Windows.Forms.DateTimePicker dtp_Fecha_Vencimientos;
        private System.Windows.Forms.TextBox txt_Dias_Vencidos;
        private System.Windows.Forms.TextBox txt_Plazo_Pago;
        private System.Windows.Forms.DateTimePicker dtp_Fecha_Ultimo_Pago;
        private System.Windows.Forms.TextBox txt_Adeudo;
        private System.Windows.Forms.TextBox txt_Intereses;
        private System.Windows.Forms.TextBox txt_Estatus_Documento;
        private System.Windows.Forms.TextBox txt_UUID;
        private System.Windows.Forms.TextBox txt_No_Pago_Anterior;
        private System.Windows.Forms.TextBox txt_Saldo_Anterio;
        private System.Windows.Forms.TextBox txt_Cantidad_Interes;
        private System.Windows.Forms.TextBox txt_Importe_A_Pagar;
        private System.Windows.Forms.TextBox txt_Saldo_Favor;
        private System.Windows.Forms.TextBox txt_Importe_Pago;
        private System.Windows.Forms.TextBox txt_Saldo_Nuevo;
        private System.Windows.Forms.DateTimePicker dtp_Fecha_Timbrado;
        private System.Windows.Forms.TextBox txt_Comentario_Pago;
        private System.Windows.Forms.ComboBox cmb_Tipo_Pago;
        private System.Windows.Forms.TextBox txt_Total_Pagado;
        private System.Windows.Forms.TextBox txt_Cambio;
        private System.Windows.Forms.Button btnHistorialPago;
        private System.Windows.Forms.Button btnCancelarPago;
        private System.Windows.Forms.Button btnGenerarPago;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscarRemision;
        private System.Windows.Forms.Panel pnlTicket;
        private System.Windows.Forms.TextBox txtTamañoTicket;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtFuenteTicket;
        private System.Windows.Forms.Label label19;
    }
}