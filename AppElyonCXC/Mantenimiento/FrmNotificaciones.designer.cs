namespace AppElyonCXC.Mantenimiento
{
    partial class FrmNotificaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNotificaciones));
            this.rbtntodos = new System.Windows.Forms.RadioButton();
            this.rbtnUsuario = new System.Windows.Forms.RadioButton();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.gpoSeleccinar = new System.Windows.Forms.GroupBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblmensaje = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.gpoNotificaciones = new System.Windows.Forms.GroupBox();
            this.rtxtMensaje = new System.Windows.Forms.RichTextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.TlsBorrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnActualiza = new System.Windows.Forms.ToolStripButton();
            this.ucgUsuariosLog = new AppElyonCXC.UcGrid();
            this.gpoSeleccinar.SuspendLayout();
            this.gpoNotificaciones.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtntodos
            // 
            this.rbtntodos.AutoSize = true;
            this.rbtntodos.Location = new System.Drawing.Point(129, 19);
            this.rbtntodos.Name = "rbtntodos";
            this.rbtntodos.Size = new System.Drawing.Size(55, 17);
            this.rbtntodos.TabIndex = 1;
            this.rbtntodos.TabStop = true;
            this.rbtntodos.Text = "Todos";
            this.rbtntodos.UseVisualStyleBackColor = true;
            this.rbtntodos.CheckedChanged += new System.EventHandler(this.rbtntodos_CheckedChanged);
            // 
            // rbtnUsuario
            // 
            this.rbtnUsuario.AutoSize = true;
            this.rbtnUsuario.Location = new System.Drawing.Point(15, 19);
            this.rbtnUsuario.Name = "rbtnUsuario";
            this.rbtnUsuario.Size = new System.Drawing.Size(61, 17);
            this.rbtnUsuario.TabIndex = 0;
            this.rbtnUsuario.TabStop = true;
            this.rbtnUsuario.Text = "Usuario";
            this.rbtnUsuario.UseVisualStyleBackColor = true;
            this.rbtnUsuario.CheckedChanged += new System.EventHandler(this.rbtnUsuario_CheckedChanged);
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(65, 68);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(282, 20);
            this.txtMensaje.TabIndex = 21;
            // 
            // gpoSeleccinar
            // 
            this.gpoSeleccinar.Controls.Add(this.lblUsuario);
            this.gpoSeleccinar.Controls.Add(this.txtUsuario);
            this.gpoSeleccinar.Controls.Add(this.lblmensaje);
            this.gpoSeleccinar.Controls.Add(this.rbtntodos);
            this.gpoSeleccinar.Controls.Add(this.rbtnUsuario);
            this.gpoSeleccinar.Controls.Add(this.txtMensaje);
            this.gpoSeleccinar.Controls.Add(this.btnEnviar);
            this.gpoSeleccinar.Location = new System.Drawing.Point(490, 365);
            this.gpoSeleccinar.Name = "gpoSeleccinar";
            this.gpoSeleccinar.Size = new System.Drawing.Size(384, 138);
            this.gpoSeleccinar.TabIndex = 29;
            this.gpoSeleccinar.TabStop = false;
            this.gpoSeleccinar.Text = "Seleccionar:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(12, 45);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 30;
            this.lblUsuario.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(65, 42);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(282, 20);
            this.txtUsuario.TabIndex = 29;
            // 
            // lblmensaje
            // 
            this.lblmensaje.AutoSize = true;
            this.lblmensaje.Location = new System.Drawing.Point(12, 71);
            this.lblmensaje.Name = "lblmensaje";
            this.lblmensaje.Size = new System.Drawing.Size(50, 13);
            this.lblmensaje.TabIndex = 28;
            this.lblmensaje.Text = "Mensaje:";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Image = global::AppElyonCXC.Properties.Resources.paper_plane_32;
            this.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviar.Location = new System.Drawing.Point(242, 92);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(105, 41);
            this.btnEnviar.TabIndex = 27;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // gpoNotificaciones
            // 
            this.gpoNotificaciones.Controls.Add(this.rtxtMensaje);
            this.gpoNotificaciones.Controls.Add(this.toolStrip2);
            this.gpoNotificaciones.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpoNotificaciones.Location = new System.Drawing.Point(487, 12);
            this.gpoNotificaciones.Name = "gpoNotificaciones";
            this.gpoNotificaciones.Size = new System.Drawing.Size(387, 347);
            this.gpoNotificaciones.TabIndex = 30;
            this.gpoNotificaciones.TabStop = false;
            this.gpoNotificaciones.Text = "Notificaciones:";
            // 
            // rtxtMensaje
            // 
            this.rtxtMensaje.Location = new System.Drawing.Point(6, 47);
            this.rtxtMensaje.Name = "rtxtMensaje";
            this.rtxtMensaje.Size = new System.Drawing.Size(375, 287);
            this.rtxtMensaje.TabIndex = 25;
            this.rtxtMensaje.Text = "";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.LightBlue;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TlsBorrar,
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.tsbtnActualiza});
            this.toolStrip2.Location = new System.Drawing.Point(3, 19);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(381, 25);
            this.toolStrip2.TabIndex = 24;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // TlsBorrar
            // 
            this.TlsBorrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TlsBorrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TlsBorrar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TlsBorrar.Image = ((System.Drawing.Image)(resources.GetObject("TlsBorrar.Image")));
            this.TlsBorrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TlsBorrar.Name = "TlsBorrar";
            this.TlsBorrar.Size = new System.Drawing.Size(43, 22);
            this.TlsBorrar.Text = "Borrar";
            this.TlsBorrar.Click += new System.EventHandler(this.TlsBorrar_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(100, 22);
            this.toolStripLabel1.Text = "NOTIFICACIONES";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnActualiza
            // 
            this.tsbtnActualiza.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnActualiza.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnActualiza.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnActualiza.Image")));
            this.tsbtnActualiza.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnActualiza.Name = "tsbtnActualiza";
            this.tsbtnActualiza.Size = new System.Drawing.Size(63, 22);
            this.tsbtnActualiza.Text = "Actualizar";
            this.tsbtnActualiza.Click += new System.EventHandler(this.tsbtnActualiza_Click);
            // 
            // ucgUsuariosLog
            // 
            this.ucgUsuariosLog.bFiltro = true;
            this.ucgUsuariosLog.DataSource = null;
            this.ucgUsuariosLog.Location = new System.Drawing.Point(11, 16);
            this.ucgUsuariosLog.Name = "ucgUsuariosLog";
            this.ucgUsuariosLog.Size = new System.Drawing.Size(470, 487);
            this.ucgUsuariosLog.TabIndex = 31;
            this.ucgUsuariosLog.cell_Datagrid_DoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ucgUsuariosLog_cell_Datagrid_DoubleClick);
            // 
            // FrmNotificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 552);
            this.Controls.Add(this.ucgUsuariosLog);
            this.Controls.Add(this.gpoNotificaciones);
            this.Controls.Add(this.gpoSeleccinar);
            this.Name = "FrmNotificaciones";
            this.Text = "FrmNotificaciones";
            this.Load += new System.EventHandler(this.FrmNotificaciones_Load);
            this.gpoSeleccinar.ResumeLayout(false);
            this.gpoSeleccinar.PerformLayout();
            this.gpoNotificaciones.ResumeLayout(false);
            this.gpoNotificaciones.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton rbtntodos;
        private System.Windows.Forms.RadioButton rbtnUsuario;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.GroupBox gpoSeleccinar;
        private System.Windows.Forms.GroupBox gpoNotificaciones;
        private System.Windows.Forms.RichTextBox rtxtMensaje;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton TlsBorrar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Label lblmensaje;
        private UcGrid ucgUsuariosLog;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnActualiza;
    }
}