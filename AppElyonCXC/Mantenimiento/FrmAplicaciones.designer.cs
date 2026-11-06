namespace AppElyonCXC.Mantenimiento
{
    partial class FrmAplicaciones
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
            this.gpoSeleApp = new System.Windows.Forms.GroupBox();
            this.ucGridApp = new AppElyonCXC.UcGrid();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gpoAltaApp = new System.Windows.Forms.GroupBox();
            this.txtNombrelargo = new System.Windows.Forms.TextBox();
            this.txtNombrecorto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNombreCortoApp = new System.Windows.Forms.Label();
            this.chkEstatus = new System.Windows.Forms.CheckBox();
            this.gpoSeleApp.SuspendLayout();
            this.gpoAltaApp.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpoSeleApp
            // 
            this.gpoSeleApp.Controls.Add(this.ucGridApp);
            this.gpoSeleApp.Location = new System.Drawing.Point(12, 12);
            this.gpoSeleApp.Name = "gpoSeleApp";
            this.gpoSeleApp.Size = new System.Drawing.Size(494, 405);
            this.gpoSeleApp.TabIndex = 0;
            this.gpoSeleApp.TabStop = false;
            this.gpoSeleApp.Text = "Seleccionar Aplicacion";
            // 
            // ucGridApp
            // 
            this.ucGridApp.bFiltro = true;
            this.ucGridApp.DataSource = null;
            this.ucGridApp.Location = new System.Drawing.Point(6, 19);
            this.ucGridApp.Name = "ucGridApp";
            this.ucGridApp.Size = new System.Drawing.Size(470, 379);
            this.ucGridApp.TabIndex = 0;
            this.ucGridApp.cell_Datagrid_DoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ucGridApp_cell_Datagrid_DoubleClick);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.Control;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLimpiar.Image = global::AppElyonCXC.Properties.Resources.sinchronize_26;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(512, 31);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(102, 30);
            this.btnLimpiar.TabIndex = 63;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.SystemColors.Control;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEliminar.Image = global::AppElyonCXC.Properties.Resources.delete_file_26;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(512, 469);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(102, 30);
            this.btnEliminar.TabIndex = 62;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAgregar.Image = global::AppElyonCXC.Properties.Resources.edit_file_26;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(512, 433);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(102, 30);
            this.btnAgregar.TabIndex = 61;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // gpoAltaApp
            // 
            this.gpoAltaApp.Controls.Add(this.txtNombrelargo);
            this.gpoAltaApp.Controls.Add(this.txtNombrecorto);
            this.gpoAltaApp.Controls.Add(this.label2);
            this.gpoAltaApp.Controls.Add(this.lblNombreCortoApp);
            this.gpoAltaApp.Controls.Add(this.chkEstatus);
            this.gpoAltaApp.Location = new System.Drawing.Point(12, 423);
            this.gpoAltaApp.Name = "gpoAltaApp";
            this.gpoAltaApp.Size = new System.Drawing.Size(494, 100);
            this.gpoAltaApp.TabIndex = 64;
            this.gpoAltaApp.TabStop = false;
            this.gpoAltaApp.Text = "Agregar Aplicacion:";
            // 
            // txtNombrelargo
            // 
            this.txtNombrelargo.Location = new System.Drawing.Point(151, 47);
            this.txtNombrelargo.Name = "txtNombrelargo";
            this.txtNombrelargo.Size = new System.Drawing.Size(325, 20);
            this.txtNombrelargo.TabIndex = 4;
            // 
            // txtNombrecorto
            // 
            this.txtNombrecorto.Location = new System.Drawing.Point(151, 24);
            this.txtNombrecorto.MaxLength = 100;
            this.txtNombrecorto.Name = "txtNombrecorto";
            this.txtNombrecorto.Size = new System.Drawing.Size(325, 20);
            this.txtNombrecorto.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre largo Aplicacion:";
            // 
            // lblNombreCortoApp
            // 
            this.lblNombreCortoApp.AutoSize = true;
            this.lblNombreCortoApp.Location = new System.Drawing.Point(19, 27);
            this.lblNombreCortoApp.Name = "lblNombreCortoApp";
            this.lblNombreCortoApp.Size = new System.Drawing.Size(126, 13);
            this.lblNombreCortoApp.TabIndex = 1;
            this.lblNombreCortoApp.Text = "Nombre corto Aplicacion:";
            // 
            // chkEstatus
            // 
            this.chkEstatus.AutoSize = true;
            this.chkEstatus.Location = new System.Drawing.Point(151, 73);
            this.chkEstatus.Name = "chkEstatus";
            this.chkEstatus.Size = new System.Drawing.Size(61, 17);
            this.chkEstatus.TabIndex = 0;
            this.chkEstatus.Text = "Estatus";
            this.chkEstatus.UseVisualStyleBackColor = true;
            // 
            // FrmAplicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 537);
            this.Controls.Add(this.gpoAltaApp);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.gpoSeleApp);
            this.Name = "FrmAplicaciones";
            this.Text = "FrmAplicaciones";
            this.Load += new System.EventHandler(this.FrmAplicaciones_Load);
            this.gpoSeleApp.ResumeLayout(false);
            this.gpoAltaApp.ResumeLayout(false);
            this.gpoAltaApp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpoSeleApp;
        private UcGrid ucGridApp;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.GroupBox gpoAltaApp;
        private System.Windows.Forms.TextBox txtNombrelargo;
        private System.Windows.Forms.TextBox txtNombrecorto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNombreCortoApp;
        private System.Windows.Forms.CheckBox chkEstatus;
    }
}