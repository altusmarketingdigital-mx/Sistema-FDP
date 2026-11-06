namespace AppElyonCXC
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPuesto = new System.Windows.Forms.Label();
            this.lblPuestoini = new System.Windows.Forms.Label();
            this.pbAltaFoto = new System.Windows.Forms.PictureBox();
            this.lbldepto = new System.Windows.Forms.Label();
            this.lblNomVersionIni = new System.Windows.Forms.Label();
            this.lblNombreUsuIni = new System.Windows.Forms.Label();
            this.lblUsuarioIni = new System.Windows.Forms.Label();
            this.lblVersionIni = new System.Windows.Forms.Label();
            this.lbldeptoIni = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMnuHijo = new System.Windows.Forms.Label();
            this.pnlHijo = new System.Windows.Forms.Panel();
            this.pnlMenuPadre = new System.Windows.Forms.Panel();
            this.lblver2 = new System.Windows.Forms.Label();
            this.lblversion2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tsslblNombre = new System.Windows.Forms.ToolStripLabel();
            this.tlspNotificacion1 = new System.Windows.Forms.ToolStripButton();
            this.lblNotificaciones2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnSalir = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.cambioDeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizaMenusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tlsbtnAccesos = new System.Windows.Forms.ToolStripDropDownButton();
            this.MnuTsbtnAccesos = new System.Windows.Forms.ToolStripMenuItem();
            this.AccesosTsbtnAccesos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPortales = new System.Windows.Forms.ToolStripDropDownButton();
            this.portalFacturaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAltaFoto)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlMenuPadre.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1084, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1084, 634);
            this.tabControl1.TabIndex = 13;
            this.tabControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BackgroundImage = global::AppElyonCXC.Properties.Resources.WhatsApp_Image_2021_11_11_at_7_33_33_PM;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1076, 608);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "INICIO";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.lblPuesto);
            this.groupBox1.Controls.Add(this.lblPuestoini);
            this.groupBox1.Controls.Add(this.pbAltaFoto);
            this.groupBox1.Controls.Add(this.lbldepto);
            this.groupBox1.Controls.Add(this.lblNomVersionIni);
            this.groupBox1.Controls.Add(this.lblNombreUsuIni);
            this.groupBox1.Controls.Add(this.lblUsuarioIni);
            this.groupBox1.Controls.Add(this.lblVersionIni);
            this.groupBox1.Controls.Add(this.lbldeptoIni);
            this.groupBox1.Location = new System.Drawing.Point(721, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 579);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // lblPuesto
            // 
            this.lblPuesto.AutoSize = true;
            this.lblPuesto.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuesto.Location = new System.Drawing.Point(106, 250);
            this.lblPuesto.Name = "lblPuesto";
            this.lblPuesto.Size = new System.Drawing.Size(62, 21);
            this.lblPuesto.TabIndex = 16;
            this.lblPuesto.Text = "Puesto";
            // 
            // lblPuestoini
            // 
            this.lblPuestoini.AutoSize = true;
            this.lblPuestoini.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuestoini.Location = new System.Drawing.Point(28, 250);
            this.lblPuestoini.Name = "lblPuestoini";
            this.lblPuestoini.Size = new System.Drawing.Size(75, 23);
            this.lblPuestoini.TabIndex = 15;
            this.lblPuestoini.Text = "Puesto:";
            // 
            // pbAltaFoto
            // 
            this.pbAltaFoto.Location = new System.Drawing.Point(118, 15);
            this.pbAltaFoto.Name = "pbAltaFoto";
            this.pbAltaFoto.Size = new System.Drawing.Size(135, 142);
            this.pbAltaFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAltaFoto.TabIndex = 14;
            this.pbAltaFoto.TabStop = false;
            this.pbAltaFoto.Click += new System.EventHandler(this.pbAltaFoto_Click);
            this.pbAltaFoto.MouseLeave += new System.EventHandler(this.pbAltaFoto_MouseLeave);
            this.pbAltaFoto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbAltaFoto_MouseMove);
            // 
            // lbldepto
            // 
            this.lbldepto.AutoSize = true;
            this.lbldepto.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldepto.Location = new System.Drawing.Point(181, 217);
            this.lbldepto.Name = "lbldepto";
            this.lbldepto.Size = new System.Drawing.Size(59, 21);
            this.lbldepto.TabIndex = 7;
            this.lbldepto.Text = "depto";
            // 
            // lblNomVersionIni
            // 
            this.lblNomVersionIni.AutoSize = true;
            this.lblNomVersionIni.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomVersionIni.Location = new System.Drawing.Point(113, 287);
            this.lblNomVersionIni.Name = "lblNomVersionIni";
            this.lblNomVersionIni.Size = new System.Drawing.Size(97, 21);
            this.lblNomVersionIni.TabIndex = 6;
            this.lblNomVersionIni.Text = "Compilado";
            // 
            // lblNombreUsuIni
            // 
            this.lblNombreUsuIni.AutoSize = true;
            this.lblNombreUsuIni.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuIni.Location = new System.Drawing.Point(114, 186);
            this.lblNombreUsuIni.Name = "lblNombreUsuIni";
            this.lblNombreUsuIni.Size = new System.Drawing.Size(73, 21);
            this.lblNombreUsuIni.TabIndex = 5;
            this.lblNombreUsuIni.Text = "Nombre";
            // 
            // lblUsuarioIni
            // 
            this.lblUsuarioIni.AutoSize = true;
            this.lblUsuarioIni.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioIni.Location = new System.Drawing.Point(28, 186);
            this.lblUsuarioIni.Name = "lblUsuarioIni";
            this.lblUsuarioIni.Size = new System.Drawing.Size(83, 23);
            this.lblUsuarioIni.TabIndex = 1;
            this.lblUsuarioIni.Text = "Usuario:";
            // 
            // lblVersionIni
            // 
            this.lblVersionIni.AutoSize = true;
            this.lblVersionIni.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersionIni.Location = new System.Drawing.Point(28, 285);
            this.lblVersionIni.Name = "lblVersionIni";
            this.lblVersionIni.Size = new System.Drawing.Size(82, 23);
            this.lblVersionIni.TabIndex = 4;
            this.lblVersionIni.Text = "Version:";
            // 
            // lbldeptoIni
            // 
            this.lbldeptoIni.AutoSize = true;
            this.lbldeptoIni.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldeptoIni.Location = new System.Drawing.Point(28, 217);
            this.lbldeptoIni.Name = "lbldeptoIni";
            this.lbldeptoIni.Size = new System.Drawing.Size(150, 23);
            this.lbldeptoIni.TabIndex = 2;
            this.lbldeptoIni.Text = "Departamento:";
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BackgroundImage = global::AppElyonCXC.Properties.Resources.WhatsApp_Image_2021_11_09_at_9_05_31_PM;
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Controls.Add(this.pnlMenuPadre);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1076, 608);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "MENU";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblMnuHijo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlHijo, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(261, 11);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.826955F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 96.17304F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(731, 601);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // lblMnuHijo
            // 
            this.lblMnuHijo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMnuHijo.Location = new System.Drawing.Point(3, 0);
            this.lblMnuHijo.Name = "lblMnuHijo";
            this.lblMnuHijo.Size = new System.Drawing.Size(725, 19);
            this.lblMnuHijo.TabIndex = 12;
            this.lblMnuHijo.Text = "MENU";
            this.lblMnuHijo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMnuHijo.Visible = false;
            // 
            // pnlHijo
            // 
            this.pnlHijo.AutoScroll = true;
            this.pnlHijo.BackColor = System.Drawing.Color.Transparent;
            this.pnlHijo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlHijo.Location = new System.Drawing.Point(3, 26);
            this.pnlHijo.Name = "pnlHijo";
            this.pnlHijo.Size = new System.Drawing.Size(725, 551);
            this.pnlHijo.TabIndex = 12;
            this.pnlHijo.Visible = false;
            // 
            // pnlMenuPadre
            // 
            this.pnlMenuPadre.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenuPadre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMenuPadre.Controls.Add(this.lblver2);
            this.pnlMenuPadre.Controls.Add(this.lblversion2);
            this.pnlMenuPadre.Controls.Add(this.label2);
            this.pnlMenuPadre.Location = new System.Drawing.Point(8, 11);
            this.pnlMenuPadre.Name = "pnlMenuPadre";
            this.pnlMenuPadre.Size = new System.Drawing.Size(247, 577);
            this.pnlMenuPadre.TabIndex = 5;
            this.pnlMenuPadre.Click += new System.EventHandler(this.pnlMenuPadre_Click);
            // 
            // lblver2
            // 
            this.lblver2.AutoSize = true;
            this.lblver2.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.lblver2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblver2.Location = new System.Drawing.Point(109, 31);
            this.lblver2.Name = "lblver2";
            this.lblver2.Size = new System.Drawing.Size(69, 16);
            this.lblver2.TabIndex = 15;
            this.lblver2.Text = "Compilado";
            // 
            // lblversion2
            // 
            this.lblversion2.AutoSize = true;
            this.lblversion2.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.lblversion2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblversion2.Location = new System.Drawing.Point(56, 31);
            this.lblversion2.Name = "lblversion2";
            this.lblversion2.Size = new System.Drawing.Size(48, 16);
            this.lblversion2.TabIndex = 14;
            this.lblversion2.Text = "Version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(91, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "MENU";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblNombre,
            this.tlspNotificacion1,
            this.lblNotificaciones2});
            this.toolStrip3.Location = new System.Drawing.Point(0, 672);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(1084, 25);
            this.toolStrip3.TabIndex = 14;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // tsslblNombre
            // 
            this.tsslblNombre.Name = "tsslblNombre";
            this.tsslblNombre.Size = new System.Drawing.Size(86, 22);
            this.tsslblNombre.Text = "toolStripLabel2";
            // 
            // tlspNotificacion1
            // 
            this.tlspNotificacion1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tlspNotificacion1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlspNotificacion1.Image = global::AppElyonCXC.Properties.Resources.NotificacionBlack1;
            this.tlspNotificacion1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlspNotificacion1.Name = "tlspNotificacion1";
            this.tlspNotificacion1.Size = new System.Drawing.Size(23, 22);
            this.tlspNotificacion1.Text = "toolStripButton2";
            this.tlspNotificacion1.Click += new System.EventHandler(this.tlspNotificacion1_Click);
            // 
            // lblNotificaciones2
            // 
            this.lblNotificaciones2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblNotificaciones2.ForeColor = System.Drawing.Color.Red;
            this.lblNotificaciones2.Name = "lblNotificaciones2";
            this.lblNotificaciones2.Size = new System.Drawing.Size(86, 22);
            this.lblNotificaciones2.Text = "toolStripLabel2";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Silver;
            this.toolStrip1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnSalir,
            this.toolStripDropDownButton1,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.tlsbtnAccesos,
            this.tsPortales});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1084, 39);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnSalir
            // 
            this.tsbtnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSalir.Image = global::AppElyonCXC.Properties.Resources.shutdown_32;
            this.tsbtnSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSalir.Name = "tsbtnSalir";
            this.tsbtnSalir.Size = new System.Drawing.Size(36, 36);
            this.tsbtnSalir.Text = "Salir del Sistema";
            this.tsbtnSalir.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambioDeUsuarioToolStripMenuItem,
            this.actualizaMenusToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.toolStripDropDownButton1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDropDownButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(127, 36);
            this.toolStripDropDownButton1.Tag = "";
            this.toolStripDropDownButton1.Text = "Configuraciones";
            // 
            // cambioDeUsuarioToolStripMenuItem
            // 
            this.cambioDeUsuarioToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cambioDeUsuarioToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cambioDeUsuarioToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cambioDeUsuarioToolStripMenuItem.Name = "cambioDeUsuarioToolStripMenuItem";
            this.cambioDeUsuarioToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.cambioDeUsuarioToolStripMenuItem.Text = "Cambio de Usuario";
            this.cambioDeUsuarioToolStripMenuItem.Click += new System.EventHandler(this.cambioDeUsuarioToolStripMenuItem_Click);
            // 
            // actualizaMenusToolStripMenuItem
            // 
            this.actualizaMenusToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actualizaMenusToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.actualizaMenusToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.actualizaMenusToolStripMenuItem.Name = "actualizaMenusToolStripMenuItem";
            this.actualizaMenusToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.actualizaMenusToolStripMenuItem.Text = "Actualiza Menus";
            this.actualizaMenusToolStripMenuItem.Click += new System.EventHandler(this.actualizaMenusToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(185, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::AppElyonCXC.Properties.Resources.minimize_window_32;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // tlsbtnAccesos
            // 
            this.tlsbtnAccesos.BackColor = System.Drawing.SystemColors.Control;
            this.tlsbtnAccesos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuTsbtnAccesos,
            this.AccesosTsbtnAccesos});
            this.tlsbtnAccesos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tlsbtnAccesos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tlsbtnAccesos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsbtnAccesos.Name = "tlsbtnAccesos";
            this.tlsbtnAccesos.Size = new System.Drawing.Size(107, 36);
            this.tlsbtnAccesos.Text = "Accesos Inicio";
            this.tlsbtnAccesos.Visible = false;
            // 
            // MnuTsbtnAccesos
            // 
            this.MnuTsbtnAccesos.Name = "MnuTsbtnAccesos";
            this.MnuTsbtnAccesos.Size = new System.Drawing.Size(127, 22);
            this.MnuTsbtnAccesos.Text = "Menus";
            this.MnuTsbtnAccesos.Click += new System.EventHandler(this.MnuTsbtnAccesos_Click);
            // 
            // AccesosTsbtnAccesos
            // 
            this.AccesosTsbtnAccesos.Name = "AccesosTsbtnAccesos";
            this.AccesosTsbtnAccesos.Size = new System.Drawing.Size(127, 22);
            this.AccesosTsbtnAccesos.Text = "Accesos";
            this.AccesosTsbtnAccesos.Click += new System.EventHandler(this.AccesosTsbtnAccesos_Click);
            // 
            // tsPortales
            // 
            this.tsPortales.BackColor = System.Drawing.SystemColors.Control;
            this.tsPortales.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portalFacturaciónToolStripMenuItem});
            this.tsPortales.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tsPortales.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsPortales.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPortales.Name = "tsPortales";
            this.tsPortales.Size = new System.Drawing.Size(69, 36);
            this.tsPortales.Text = "Portales";
            // 
            // portalFacturaciónToolStripMenuItem
            // 
            this.portalFacturaciónToolStripMenuItem.Name = "portalFacturaciónToolStripMenuItem";
            this.portalFacturaciónToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.portalFacturaciónToolStripMenuItem.Text = "S,A,T";
            this.portalFacturaciónToolStripMenuItem.Click += new System.EventHandler(this.portalFacturaciónToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 697);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1100, 736);
            this.MinimumSize = new System.Drawing.Size(1100, 726);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tss - Inventario";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAltaFoto)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlMenuPadre.ResumeLayout(false);
            this.pnlMenuPadre.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnSalir;
        private System.Windows.Forms.Panel pnlMenuPadre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlHijo;
        private System.Windows.Forms.Label lblMnuHijo;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblUsuarioIni;
        private System.Windows.Forms.Label lblVersionIni;
        private System.Windows.Forms.Label lbldeptoIni;
        private System.Windows.Forms.Label lblNomVersionIni;
        private System.Windows.Forms.Label lblNombreUsuIni;
        private System.Windows.Forms.Label lbldepto;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem cambioDeUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizaMenusToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbAltaFoto;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblPuesto;
        private System.Windows.Forms.Label lblPuestoini;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripDropDownButton tlsbtnAccesos;
        private System.Windows.Forms.ToolStripMenuItem MnuTsbtnAccesos;
        private System.Windows.Forms.ToolStripMenuItem AccesosTsbtnAccesos;
        private System.Windows.Forms.Label lblver2;
        private System.Windows.Forms.Label lblversion2;
        private System.Windows.Forms.ToolStripDropDownButton tsPortales;
        private System.Windows.Forms.ToolStripMenuItem portalFacturaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel tsslblNombre;
        private System.Windows.Forms.ToolStripButton tlspNotificacion1;
        private System.Windows.Forms.ToolStripLabel lblNotificaciones2;
        
    }
}