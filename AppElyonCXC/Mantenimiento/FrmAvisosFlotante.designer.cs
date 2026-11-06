namespace AppElyonCXC.Mantenimiento
{
    partial class FrmAvisosFlotante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAvisosFlotante));
            this.gpoNotificaciones = new System.Windows.Forms.GroupBox();
            this.rtxtMensaje = new System.Windows.Forms.RichTextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tlNotCerrar = new System.Windows.Forms.ToolStripButton();
            this.TlsBorrar = new System.Windows.Forms.ToolStripButton();
            this.gpoNotificaciones.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpoNotificaciones
            // 
            this.gpoNotificaciones.Controls.Add(this.rtxtMensaje);
            this.gpoNotificaciones.Controls.Add(this.toolStrip2);
            this.gpoNotificaciones.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.gpoNotificaciones.Location = new System.Drawing.Point(1, -5);
            this.gpoNotificaciones.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gpoNotificaciones.Name = "gpoNotificaciones";
            this.gpoNotificaciones.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gpoNotificaciones.Size = new System.Drawing.Size(451, 457);
            this.gpoNotificaciones.TabIndex = 18;
            this.gpoNotificaciones.TabStop = false;
            // 
            // rtxtMensaje
            // 
            this.rtxtMensaje.Location = new System.Drawing.Point(7, 58);
            this.rtxtMensaje.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxtMensaje.Name = "rtxtMensaje";
            this.rtxtMensaje.Size = new System.Drawing.Size(437, 352);
            this.rtxtMensaje.TabIndex = 25;
            this.rtxtMensaje.Text = "";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.LightBlue;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlNotCerrar,
            this.TlsBorrar,
            this.toolStripLabel1});
            this.toolStrip2.Location = new System.Drawing.Point(3, 20);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(445, 25);
            this.toolStrip2.TabIndex = 24;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(100, 22);
            this.toolStripLabel1.Text = "NOTIFICACIONES";
            // 
            // tlNotCerrar
            // 
            this.tlNotCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tlNotCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tlNotCerrar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tlNotCerrar.Image = ((System.Drawing.Image)(resources.GetObject("tlNotCerrar.Image")));
            this.tlNotCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlNotCerrar.Name = "tlNotCerrar";
            this.tlNotCerrar.Size = new System.Drawing.Size(43, 22);
            this.tlNotCerrar.Text = "Cerrar";
            this.tlNotCerrar.Click += new System.EventHandler(this.tlNotCerrar_Click);
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
            // FrmAvisosFlotante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 464);
            this.ControlBox = false;
            this.Controls.Add(this.gpoNotificaciones);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmAvisosFlotante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notificaciones";
            this.Load += new System.EventHandler(this.FrmAvisosFlotante_Load);
            this.gpoNotificaciones.ResumeLayout(false);
            this.gpoNotificaciones.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpoNotificaciones;
        private System.Windows.Forms.RichTextBox rtxtMensaje;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tlNotCerrar;
        private System.Windows.Forms.ToolStripButton TlsBorrar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}