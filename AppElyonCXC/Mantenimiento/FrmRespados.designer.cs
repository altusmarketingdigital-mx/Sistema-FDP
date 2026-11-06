namespace AppElyonCXC.Mantenimiento
{
    partial class FrmRespados
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btncargaSql = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnRespaldar = new System.Windows.Forms.Button();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboBD = new System.Windows.Forms.ComboBox();
            this.cboServidor = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btncargaSql);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnRestore);
            this.groupBox2.Controls.Add(this.btnRespaldar);
            this.groupBox2.Controls.Add(this.btnExaminar);
            this.groupBox2.Controls.Add(this.txtDestino);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboBD);
            this.groupBox2.Controls.Add(this.cboServidor);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 203);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opciones:";
            // 
            // btncargaSql
            // 
            this.btncargaSql.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btncargaSql.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncargaSql.Location = new System.Drawing.Point(359, 22);
            this.btncargaSql.Name = "btncargaSql";
            this.btncargaSql.Size = new System.Drawing.Size(93, 30);
            this.btncargaSql.TabIndex = 16;
            this.btncargaSql.Text = "Cargar SQL";
            this.btncargaSql.UseVisualStyleBackColor = true;
            //this.btncargaSql.Click += new System.EventHandler(this.btncargaSql_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "NOTA: Respaldar siempre en otra unidad que no sea C:\\";
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestore.Location = new System.Drawing.Point(120, 153);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(93, 30);
            this.btnRestore.TabIndex = 14;
            this.btnRestore.Text = "Restaurar";
            this.btnRestore.UseVisualStyleBackColor = true;
            //this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnRespaldar
            // 
            this.btnRespaldar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRespaldar.Location = new System.Drawing.Point(274, 153);
            this.btnRespaldar.Name = "btnRespaldar";
            this.btnRespaldar.Size = new System.Drawing.Size(93, 30);
            this.btnRespaldar.TabIndex = 11;
            this.btnRespaldar.Text = "Respaldar";
            this.btnRespaldar.UseVisualStyleBackColor = true;
            //this.btnRespaldar.Click += new System.EventHandler(this.btnRespaldar_Click);
            // 
            // btnExaminar
            // 
            this.btnExaminar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExaminar.Location = new System.Drawing.Point(20, 91);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(75, 23);
            this.btnExaminar.TabIndex = 10;
            this.btnExaminar.Text = "Destino:";
            this.btnExaminar.UseVisualStyleBackColor = true;
            //this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // txtDestino
            // 
            this.txtDestino.Location = new System.Drawing.Point(101, 93);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(266, 20);
            this.txtDestino.TabIndex = 9;
            this.txtDestino.Text = "C:\\Program Files\\Microsoft SQL Server\\MSSQL13.JORGE\\MSSQL\\Backup\\Jorge\\";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Base Datos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Servidor SQL:";
            // 
            // cboBD
            // 
            this.cboBD.FormattingEnabled = true;
            this.cboBD.Location = new System.Drawing.Point(113, 57);
            this.cboBD.Name = "cboBD";
            this.cboBD.Size = new System.Drawing.Size(231, 21);
            this.cboBD.TabIndex = 1;
            // 
            // cboServidor
            // 
            this.cboServidor.FormattingEnabled = true;
            this.cboServidor.Location = new System.Drawing.Point(113, 28);
            this.cboServidor.Name = "cboServidor";
            this.cboServidor.Size = new System.Drawing.Size(231, 21);
            this.cboServidor.TabIndex = 0;
            this.cboServidor.Text = "Acteon\\jorge";
            //this.cboServidor.SelectedIndexChanged += new System.EventHandler(this.cboServidor_SelectedIndexChanged);
            //this.cboServidor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboServidor_KeyPress);
            // 
            // FrmRespados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 256);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmRespados";
            this.Text = "FrmRespados";
            //this.Load += new System.EventHandler(this.FrmRespados_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnRespaldar;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboBD;
        private System.Windows.Forms.ComboBox cboServidor;
        private System.Windows.Forms.Button btncargaSql;
    }
}