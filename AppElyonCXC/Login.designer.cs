namespace AppElyonCXC
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.lblVersion = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtcontrasena = new System.Windows.Forms.TextBox();
            this.btnInicio = new System.Windows.Forms.Button();
            this.lnkBtnSalir = new System.Windows.Forms.LinkLabel();
            this.lblerror = new System.Windows.Forms.Label();
            this.lnkEmail = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pbxOjo = new System.Windows.Forms.PictureBox();
            this.lklblWs = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxOjo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVersion
            // 
            this.lblVersion.BackColor = System.Drawing.Color.White;
            this.lblVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblVersion.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(12, 514);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(130, 16);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = "*[Version]*";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(22, 355);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(449, 23);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            // 
            // txtcontrasena
            // 
            this.txtcontrasena.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcontrasena.Location = new System.Drawing.Point(22, 412);
            this.txtcontrasena.Name = "txtcontrasena";
            this.txtcontrasena.Size = new System.Drawing.Size(391, 23);
            this.txtcontrasena.TabIndex = 2;
            this.txtcontrasena.UseSystemPasswordChar = true;
            this.txtcontrasena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcontrasena_KeyPress);
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.Green;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnInicio.Location = new System.Drawing.Point(326, 485);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(149, 40);
            this.btnInicio.TabIndex = 3;
            this.btnInicio.Text = "Ingresar";
            this.toolTip1.SetToolTip(this.btnInicio, "Ingresar al Sistema");
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // lnkBtnSalir
            // 
            this.lnkBtnSalir.ActiveLinkColor = System.Drawing.Color.Black;
            this.lnkBtnSalir.AutoSize = true;
            this.lnkBtnSalir.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkBtnSalir.Location = new System.Drawing.Point(380, 9);
            this.lnkBtnSalir.Name = "lnkBtnSalir";
            this.lnkBtnSalir.Size = new System.Drawing.Size(33, 17);
            this.lnkBtnSalir.TabIndex = 4;
            this.lnkBtnSalir.TabStop = true;
            this.lnkBtnSalir.Text = "Salir";
            this.lnkBtnSalir.Visible = false;
            this.lnkBtnSalir.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBtnSalir_LinkClicked);
            // 
            // lblerror
            // 
            this.lblerror.AutoSize = true;
            this.lblerror.BackColor = System.Drawing.Color.Transparent;
            this.lblerror.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblerror.ForeColor = System.Drawing.Color.Red;
            this.lblerror.Location = new System.Drawing.Point(19, 301);
            this.lblerror.Name = "lblerror";
            this.lblerror.Size = new System.Drawing.Size(249, 16);
            this.lblerror.TabIndex = 5;
            this.lblerror.Text = "Indique su nombre de Usuario o Contraseña.";
            this.lblerror.Visible = false;
            // 
            // lnkEmail
            // 
            this.lnkEmail.BackColor = System.Drawing.Color.White;
            this.lnkEmail.Location = new System.Drawing.Point(235, 447);
            this.lnkEmail.Name = "lnkEmail";
            this.lnkEmail.Size = new System.Drawing.Size(250, 17);
            this.lnkEmail.TabIndex = 25;
            this.lnkEmail.TabStop = true;
            this.lnkEmail.Text = "¿No puedes acceder a tu cuenta?";
            this.lnkEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEmail_LinkClicked);
            // 
            // pbxOjo
            // 
            this.pbxOjo.BackColor = System.Drawing.Color.Transparent;
            this.pbxOjo.Location = new System.Drawing.Point(430, 415);
            this.pbxOjo.Name = "pbxOjo";
            this.pbxOjo.Size = new System.Drawing.Size(44, 24);
            this.pbxOjo.TabIndex = 28;
            this.pbxOjo.TabStop = false;
            this.toolTip1.SetToolTip(this.pbxOjo, "Observar la contraseña");
            this.pbxOjo.MouseLeave += new System.EventHandler(this.pbxOjo_MouseLeave);
            this.pbxOjo.MouseHover += new System.EventHandler(this.pbxOjo_MouseHover);
            // 
            // lklblWs
            // 
            this.lklblWs.BackColor = System.Drawing.Color.White;
            this.lklblWs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lklblWs.LinkColor = System.Drawing.Color.Black;
            this.lklblWs.Location = new System.Drawing.Point(12, 499);
            this.lklblWs.Name = "lklblWs";
            this.lklblWs.Size = new System.Drawing.Size(130, 13);
            this.lklblWs.TabIndex = 29;
            this.lklblWs.TabStop = true;
            this.lklblWs.Text = "Configuracion Ws.";
            this.lklblWs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklblWs_LinkClicked);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Image = global::AppElyonCXC.Properties.Resources.cerrar;
            this.button1.Location = new System.Drawing.Point(452, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 37);
            this.button1.TabIndex = 30;
            this.toolTip1.SetToolTip(this.button1, "Salir del Sistema");
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::AppElyonCXC.Properties.Resources.pantalla_de_ingreso_New;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(497, 549);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lklblWs);
            this.Controls.Add(this.pbxOjo);
            this.Controls.Add(this.lnkEmail);
            this.Controls.Add(this.lblerror);
            this.Controls.Add(this.lnkBtnSalir);
            this.Controls.Add(this.btnInicio);
            this.Controls.Add(this.txtcontrasena);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblVersion);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxOjo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtcontrasena;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.LinkLabel lnkBtnSalir;
        private System.Windows.Forms.Label lblerror;
        private System.Windows.Forms.LinkLabel lnkEmail;
        private System.Windows.Forms.PictureBox pbxOjo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel lklblWs;
        private System.Windows.Forms.Button button1;
    }
}