namespace AppElyonCXC.Mantenimiento
{
    partial class FrmAccesos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnImprime = new System.Windows.Forms.Button();
            this.gpoPermisos = new System.Windows.Forms.GroupBox();
            this.cmbApps = new System.Windows.Forms.ComboBox();
            this.lblAplicaciones = new System.Windows.Forms.Label();
            this.btnAgregaGpo = new System.Windows.Forms.Button();
            this.btnBuscaGpo2 = new System.Windows.Forms.Button();
            this.txtCveUsu2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscaGpo1 = new System.Windows.Forms.Button();
            this.txtCveUsu1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.gpoAlta = new System.Windows.Forms.GroupBox();
            this.chkvisible = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvBotones = new System.Windows.Forms.DataGridView();
            this.btnPermisos = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnBuscaUsuario = new System.Windows.Forms.Button();
            this.txtCveUsuario = new System.Windows.Forms.TextBox();
            this.txtNomMenu = new System.Windows.Forms.TextBox();
            this.lblCveUsuario = new System.Windows.Forms.Label();
            this.cmbPermisos = new System.Windows.Forms.ComboBox();
            this.lblPermiso = new System.Windows.Forms.Label();
            this.lblNombreMenu = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvPlantel = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbAplicacion = new System.Windows.Forms.ComboBox();
            this.lblAplica = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLImpiar = new System.Windows.Forms.Button();
            this.gpoPermisos.SuspendLayout();
            this.gpoAlta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBotones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlantel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(969, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnImprime
            // 
            this.btnImprime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnImprime.BackColor = System.Drawing.Color.Transparent;
            this.btnImprime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprime.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnImprime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprime.Location = new System.Drawing.Point(851, 113);
            this.btnImprime.Name = "btnImprime";
            this.btnImprime.Size = new System.Drawing.Size(106, 39);
            this.btnImprime.TabIndex = 77;
            this.btnImprime.Text = "&Imprimir";
            this.btnImprime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprime.UseVisualStyleBackColor = false;
            this.btnImprime.Click += new System.EventHandler(this.btnImprime_Click);
            // 
            // gpoPermisos
            // 
            this.gpoPermisos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpoPermisos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gpoPermisos.Controls.Add(this.cmbApps);
            this.gpoPermisos.Controls.Add(this.lblAplicaciones);
            this.gpoPermisos.Controls.Add(this.btnAgregaGpo);
            this.gpoPermisos.Controls.Add(this.btnBuscaGpo2);
            this.gpoPermisos.Controls.Add(this.txtCveUsu2);
            this.gpoPermisos.Controls.Add(this.label4);
            this.gpoPermisos.Controls.Add(this.label3);
            this.gpoPermisos.Controls.Add(this.label2);
            this.gpoPermisos.Controls.Add(this.btnBuscaGpo1);
            this.gpoPermisos.Controls.Add(this.txtCveUsu1);
            this.gpoPermisos.Controls.Add(this.label1);
            this.gpoPermisos.Location = new System.Drawing.Point(26, 393);
            this.gpoPermisos.Name = "gpoPermisos";
            this.gpoPermisos.Size = new System.Drawing.Size(802, 130);
            this.gpoPermisos.TabIndex = 76;
            this.gpoPermisos.TabStop = false;
            this.gpoPermisos.Text = "Alta por grupo:";
            // 
            // cmbApps
            // 
            this.cmbApps.FormattingEnabled = true;
            this.cmbApps.Location = new System.Drawing.Point(503, 32);
            this.cmbApps.Name = "cmbApps";
            this.cmbApps.Size = new System.Drawing.Size(204, 21);
            this.cmbApps.TabIndex = 16;
            // 
            // lblAplicaciones
            // 
            this.lblAplicaciones.AutoSize = true;
            this.lblAplicaciones.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAplicaciones.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAplicaciones.Location = new System.Drawing.Point(416, 36);
            this.lblAplicaciones.Name = "lblAplicaciones";
            this.lblAplicaciones.Size = new System.Drawing.Size(81, 17);
            this.lblAplicaciones.TabIndex = 15;
            this.lblAplicaciones.Text = "Aplicación:";
            // 
            // btnAgregaGpo
            // 
            this.btnAgregaGpo.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregaGpo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregaGpo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregaGpo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAgregaGpo.Image = global::AppElyonCXC.Properties.Resources.add_file_26;
            this.btnAgregaGpo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregaGpo.Location = new System.Drawing.Point(607, 68);
            this.btnAgregaGpo.Name = "btnAgregaGpo";
            this.btnAgregaGpo.Size = new System.Drawing.Size(100, 39);
            this.btnAgregaGpo.TabIndex = 14;
            this.btnAgregaGpo.Text = "&Agregar";
            this.btnAgregaGpo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregaGpo.UseVisualStyleBackColor = false;
            this.btnAgregaGpo.Click += new System.EventHandler(this.btnAgregaGpo_Click);
            // 
            // btnBuscaGpo2
            // 
            this.btnBuscaGpo2.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscaGpo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscaGpo2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscaGpo2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBuscaGpo2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscaGpo2.Location = new System.Drawing.Point(273, 77);
            this.btnBuscaGpo2.Name = "btnBuscaGpo2";
            this.btnBuscaGpo2.Size = new System.Drawing.Size(121, 30);
            this.btnBuscaGpo2.TabIndex = 12;
            this.btnBuscaGpo2.Text = "Buscar Usuario";
            this.btnBuscaGpo2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscaGpo2.UseVisualStyleBackColor = false;
            this.btnBuscaGpo2.Click += new System.EventHandler(this.btnBuscaGpo2_Click);
            // 
            // txtCveUsu2
            // 
            this.txtCveUsu2.Location = new System.Drawing.Point(113, 87);
            this.txtCveUsu2.Name = "txtCveUsu2";
            this.txtCveUsu2.ReadOnly = true;
            this.txtCveUsu2.Size = new System.Drawing.Size(140, 20);
            this.txtCveUsu2.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Clave Usuario:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Selecciona el usuario destino.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Selecciona el usuario a copiar.";
            // 
            // btnBuscaGpo1
            // 
            this.btnBuscaGpo1.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscaGpo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscaGpo1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscaGpo1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBuscaGpo1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscaGpo1.Location = new System.Drawing.Point(273, 29);
            this.btnBuscaGpo1.Name = "btnBuscaGpo1";
            this.btnBuscaGpo1.Size = new System.Drawing.Size(121, 30);
            this.btnBuscaGpo1.TabIndex = 7;
            this.btnBuscaGpo1.Text = "Buscar Usuario";
            this.btnBuscaGpo1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscaGpo1.UseVisualStyleBackColor = false;
            this.btnBuscaGpo1.Click += new System.EventHandler(this.btnBuscaGpo1_Click);
            // 
            // txtCveUsu1
            // 
            this.txtCveUsu1.Location = new System.Drawing.Point(113, 38);
            this.txtCveUsu1.Name = "txtCveUsu1";
            this.txtCveUsu1.ReadOnly = true;
            this.txtCveUsu1.Size = new System.Drawing.Size(140, 20);
            this.txtCveUsu1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Clave Usuario:";
            // 
            // lblMensaje
            // 
            this.lblMensaje.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(22, 38);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(456, 23);
            this.lblMensaje.TabIndex = 75;
            this.lblMensaje.Text = "Selecciona del menu el acceso que se necesite.";
            // 
            // gpoAlta
            // 
            this.gpoAlta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpoAlta.Controls.Add(this.chkvisible);
            this.gpoAlta.Controls.Add(this.label6);
            this.gpoAlta.Controls.Add(this.dgvBotones);
            this.gpoAlta.Controls.Add(this.btnPermisos);
            this.gpoAlta.Controls.Add(this.btnEliminar);
            this.gpoAlta.Controls.Add(this.btnAgregar);
            this.gpoAlta.Controls.Add(this.btnBuscaUsuario);
            this.gpoAlta.Controls.Add(this.txtCveUsuario);
            this.gpoAlta.Controls.Add(this.txtNomMenu);
            this.gpoAlta.Controls.Add(this.lblCveUsuario);
            this.gpoAlta.Controls.Add(this.cmbPermisos);
            this.gpoAlta.Controls.Add(this.lblPermiso);
            this.gpoAlta.Controls.Add(this.lblNombreMenu);
            this.gpoAlta.Location = new System.Drawing.Point(12, 65);
            this.gpoAlta.Name = "gpoAlta";
            this.gpoAlta.Size = new System.Drawing.Size(816, 322);
            this.gpoAlta.TabIndex = 74;
            this.gpoAlta.TabStop = false;
            this.gpoAlta.Text = "Agregar Registro:";
            // 
            // chkvisible
            // 
            this.chkvisible.AutoSize = true;
            this.chkvisible.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkvisible.Location = new System.Drawing.Point(16, 92);
            this.chkvisible.Name = "chkvisible";
            this.chkvisible.Size = new System.Drawing.Size(343, 21);
            this.chkvisible.TabIndex = 52;
            this.chkvisible.Text = "Es Visible en Menu Principal para el usuario :True/False";
            this.chkvisible.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 17);
            this.label6.TabIndex = 51;
            this.label6.Text = "Permisos Botones Aplicacion:";
            // 
            // dgvBotones
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SkyBlue;
            this.dgvBotones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBotones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBotones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvBotones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBotones.Location = new System.Drawing.Point(24, 172);
            this.dgvBotones.Name = "dgvBotones";
            this.dgvBotones.Size = new System.Drawing.Size(403, 135);
            this.dgvBotones.TabIndex = 50;
            // 
            // btnPermisos
            // 
            this.btnPermisos.BackColor = System.Drawing.Color.Transparent;
            this.btnPermisos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPermisos.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnPermisos.Image = global::AppElyonCXC.Properties.Resources.add_list_26;
            this.btnPermisos.Location = new System.Drawing.Point(453, 13);
            this.btnPermisos.Name = "btnPermisos";
            this.btnPermisos.Size = new System.Drawing.Size(35, 34);
            this.btnPermisos.TabIndex = 49;
            this.btnPermisos.UseVisualStyleBackColor = false;
            this.btnPermisos.Click += new System.EventHandler(this.btnPermisos_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEliminar.Image = global::AppElyonCXC.Properties.Resources.delete_file_26;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(508, 56);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 39);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAgregar.Image = global::AppElyonCXC.Properties.Resources.add_file_26;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(508, 11);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 39);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnBuscaUsuario
            // 
            this.btnBuscaUsuario.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscaUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscaUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscaUsuario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBuscaUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscaUsuario.Location = new System.Drawing.Point(275, 56);
            this.btnBuscaUsuario.Name = "btnBuscaUsuario";
            this.btnBuscaUsuario.Size = new System.Drawing.Size(121, 30);
            this.btnBuscaUsuario.TabIndex = 3;
            this.btnBuscaUsuario.Text = "Buscar Usuario";
            this.btnBuscaUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscaUsuario.UseVisualStyleBackColor = false;
            this.btnBuscaUsuario.Click += new System.EventHandler(this.btnBuscaUsuario_Click);
            // 
            // txtCveUsuario
            // 
            this.txtCveUsuario.Location = new System.Drawing.Point(115, 62);
            this.txtCveUsuario.Name = "txtCveUsuario";
            this.txtCveUsuario.ReadOnly = true;
            this.txtCveUsuario.Size = new System.Drawing.Size(140, 20);
            this.txtCveUsuario.TabIndex = 5;
            // 
            // txtNomMenu
            // 
            this.txtNomMenu.Location = new System.Drawing.Point(113, 19);
            this.txtNomMenu.Name = "txtNomMenu";
            this.txtNomMenu.Size = new System.Drawing.Size(140, 20);
            this.txtNomMenu.TabIndex = 1;
            // 
            // lblCveUsuario
            // 
            this.lblCveUsuario.AutoSize = true;
            this.lblCveUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCveUsuario.Location = new System.Drawing.Point(13, 63);
            this.lblCveUsuario.Name = "lblCveUsuario";
            this.lblCveUsuario.Size = new System.Drawing.Size(101, 17);
            this.lblCveUsuario.TabIndex = 3;
            this.lblCveUsuario.Text = "Clave Usuario:";
            // 
            // cmbPermisos
            // 
            this.cmbPermisos.FormattingEnabled = true;
            this.cmbPermisos.Location = new System.Drawing.Point(328, 19);
            this.cmbPermisos.Name = "cmbPermisos";
            this.cmbPermisos.Size = new System.Drawing.Size(121, 21);
            this.cmbPermisos.TabIndex = 2;
            // 
            // lblPermiso
            // 
            this.lblPermiso.AutoSize = true;
            this.lblPermiso.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPermiso.Location = new System.Drawing.Point(255, 22);
            this.lblPermiso.Name = "lblPermiso";
            this.lblPermiso.Size = new System.Drawing.Size(67, 17);
            this.lblPermiso.TabIndex = 1;
            this.lblPermiso.Text = "Permisos:";
            // 
            // lblNombreMenu
            // 
            this.lblNombreMenu.AutoSize = true;
            this.lblNombreMenu.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreMenu.Location = new System.Drawing.Point(11, 22);
            this.lblNombreMenu.Name = "lblNombreMenu";
            this.lblNombreMenu.Size = new System.Drawing.Size(104, 17);
            this.lblNombreMenu.TabIndex = 0;
            this.lblNombreMenu.Text = "Nombre Menu:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(251, 539);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(290, 13);
            this.label5.TabIndex = 79;
            this.label5.Text = "Te direcciona al mantenimiento para agregar nuevo registro.";
            // 
            // dgvPlantel
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SkyBlue;
            this.dgvPlantel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPlantel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPlantel.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPlantel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlantel.Location = new System.Drawing.Point(445, 237);
            this.dgvPlantel.Name = "dgvPlantel";
            this.dgvPlantel.Size = new System.Drawing.Size(361, 135);
            this.dgvPlantel.TabIndex = 73;
            this.dgvPlantel.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(442, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 17);
            this.label7.TabIndex = 72;
            this.label7.Text = "Selecciona Planteles:";
            this.label7.Visible = false;
            // 
            // cmbAplicacion
            // 
            this.cmbAplicacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbAplicacion.FormattingEnabled = true;
            this.cmbAplicacion.Location = new System.Drawing.Point(613, 38);
            this.cmbAplicacion.Name = "cmbAplicacion";
            this.cmbAplicacion.Size = new System.Drawing.Size(204, 21);
            this.cmbAplicacion.TabIndex = 81;
            this.cmbAplicacion.SelectedIndexChanged += new System.EventHandler(this.cmbAplicacion_SelectedIndexChanged);
            // 
            // lblAplica
            // 
            this.lblAplica.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAplica.AutoSize = true;
            this.lblAplica.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAplica.Location = new System.Drawing.Point(526, 42);
            this.lblAplica.Name = "lblAplica";
            this.lblAplica.Size = new System.Drawing.Size(81, 17);
            this.lblAplica.TabIndex = 80;
            this.lblAplica.Text = "Aplicación:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::AppElyonCXC.Properties.Resources.add_list_26;
            this.pictureBox1.Location = new System.Drawing.Point(213, 529);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 78;
            this.pictureBox1.TabStop = false;
            // 
            // btnLImpiar
            // 
            this.btnLImpiar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLImpiar.BackColor = System.Drawing.Color.Transparent;
            this.btnLImpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLImpiar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLImpiar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLImpiar.Image = global::AppElyonCXC.Properties.Resources.sinchronize_26;
            this.btnLImpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLImpiar.Location = new System.Drawing.Point(851, 66);
            this.btnLImpiar.Name = "btnLImpiar";
            this.btnLImpiar.Size = new System.Drawing.Size(106, 39);
            this.btnLImpiar.TabIndex = 72;
            this.btnLImpiar.Text = "&Limpiar";
            this.btnLImpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLImpiar.UseVisualStyleBackColor = false;
            this.btnLImpiar.Click += new System.EventHandler(this.btnLImpiar_Click);
            // 
            // FrmAccesos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 561);
            this.Controls.Add(this.cmbAplicacion);
            this.Controls.Add(this.lblAplica);
            this.Controls.Add(this.dgvPlantel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnImprime);
            this.Controls.Add(this.gpoPermisos);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnLImpiar);
            this.Controls.Add(this.gpoAlta);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmAccesos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAccesos";
            this.Load += new System.EventHandler(this.FrmAccesos_Load);
            this.gpoPermisos.ResumeLayout(false);
            this.gpoPermisos.PerformLayout();
            this.gpoAlta.ResumeLayout(false);
            this.gpoAlta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBotones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlantel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnImprime;
        private System.Windows.Forms.GroupBox gpoPermisos;
        private System.Windows.Forms.Button btnAgregaGpo;
        private System.Windows.Forms.Button btnBuscaGpo2;
        private System.Windows.Forms.TextBox txtCveUsu2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscaGpo1;
        private System.Windows.Forms.TextBox txtCveUsu1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnLImpiar;
        private System.Windows.Forms.GroupBox gpoAlta;
        private System.Windows.Forms.Button btnPermisos;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnBuscaUsuario;
        private System.Windows.Forms.TextBox txtCveUsuario;
        private System.Windows.Forms.TextBox txtNomMenu;
        private System.Windows.Forms.Label lblCveUsuario;
        private System.Windows.Forms.ComboBox cmbPermisos;
        private System.Windows.Forms.Label lblPermiso;
        private System.Windows.Forms.Label lblNombreMenu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvBotones;
        private System.Windows.Forms.DataGridView dgvPlantel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbApps;
        private System.Windows.Forms.Label lblAplicaciones;
        private System.Windows.Forms.ComboBox cmbAplicacion;
        private System.Windows.Forms.Label lblAplica;
        private System.Windows.Forms.CheckBox chkvisible;
    }
}