namespace AppElyonCXC
{
    partial class UcGrid
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtGrid = new System.Windows.Forms.TextBox();
            this.gvGrid = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pgb = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotRegistros = new System.Windows.Forms.Label();
            this.lbltotReg = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesTSMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EETSMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EPTSMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrDebounce = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtGrid
            // 
            this.txtGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGrid.Location = new System.Drawing.Point(3, 3);
            this.txtGrid.Name = "txtGrid";
            this.txtGrid.Size = new System.Drawing.Size(464, 20);
            this.txtGrid.TabIndex = 6;
            this.txtGrid.TextChanged += new System.EventHandler(this.txtGrid_TextChanged);
            // 
            // gvGrid
            // 
            this.gvGrid.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gvGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gvGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvGrid.Location = new System.Drawing.Point(3, 23);
            this.gvGrid.Name = "gvGrid";
            this.gvGrid.ReadOnly = true;
            this.gvGrid.RowHeadersVisible = false;
            this.gvGrid.Size = new System.Drawing.Size(464, 421);
            this.gvGrid.TabIndex = 5;
            this.gvGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvGrid_CellContentClick);
            this.gvGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvGrid_CellContentDoubleClick);
            this.gvGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvGrid_CellDoubleClick);
            this.gvGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvGrid_CellEndEdit);
            this.gvGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvGrid_CellValueChanged);
            this.gvGrid.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.gvGrid_CellValueNeeded);
            this.gvGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvGrid_ColumnHeaderMouseClick);
            this.gvGrid.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvGrid_ColumnHeaderMouseDoubleClick);
            this.gvGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.gvGrid_CurrentCellDirtyStateChanged);
            this.gvGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gvGrid_DataError);
            this.gvGrid.SelectionChanged += new System.EventHandler(this.gvGrid_SelectionChanged);
            this.gvGrid.DoubleClick += new System.EventHandler(this.gvGrid_DoubleClick);
            this.gvGrid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gvGrid_KeyPress);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gvGrid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtGrid, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(470, 487);
            this.tableLayoutPanel1.TabIndex = 23;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 450);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 34);
            this.panel1.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pgb);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(208, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(168, 34);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            // 
            // pgb
            // 
            this.pgb.Dock = System.Windows.Forms.DockStyle.Top;
            this.pgb.Location = new System.Drawing.Point(3, 16);
            this.pgb.Name = "pgb";
            this.pgb.Size = new System.Drawing.Size(162, 10);
            this.pgb.Step = 1;
            this.pgb.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgb.TabIndex = 25;
            this.pgb.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotRegistros);
            this.groupBox1.Controls.Add(this.lbltotReg);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 34);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // lblTotRegistros
            // 
            this.lblTotRegistros.AutoSize = true;
            this.lblTotRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotRegistros.Location = new System.Drawing.Point(6, 9);
            this.lblTotRegistros.Name = "lblTotRegistros";
            this.lblTotRegistros.Size = new System.Drawing.Size(103, 16);
            this.lblTotRegistros.TabIndex = 7;
            this.lblTotRegistros.Text = "Total Registros:";
            this.lblTotRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbltotReg
            // 
            this.lbltotReg.AutoSize = true;
            this.lbltotReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotReg.Location = new System.Drawing.Point(110, 10);
            this.lbltotReg.Name = "lbltotReg";
            this.lbltotReg.Size = new System.Drawing.Size(15, 16);
            this.lbltotReg.TabIndex = 8;
            this.lbltotReg.Text = "0";
            this.lbltotReg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesTSMItem});
            this.menuStrip1.Location = new System.Drawing.Point(376, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(88, 34);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesTSMItem
            // 
            this.opcionesTSMItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EETSMenu,
            this.EPTSMenu});
            this.opcionesTSMItem.Image = global::AppElyonCXC.Properties.Resources.export_26;
            this.opcionesTSMItem.Name = "opcionesTSMItem";
            this.opcionesTSMItem.Size = new System.Drawing.Size(81, 20);
            this.opcionesTSMItem.Text = "Exportar";
            this.opcionesTSMItem.Click += new System.EventHandler(this.opcionesTSMItem_Click);
            // 
            // EETSMenu
            // 
            this.EETSMenu.Image = global::AppElyonCXC.Properties.Resources.excel_26;
            this.EETSMenu.Name = "EETSMenu";
            this.EETSMenu.Size = new System.Drawing.Size(112, 22);
            this.EETSMenu.Text = "Excell";
            this.EETSMenu.Click += new System.EventHandler(this.EETSMenu_Click);
            // 
            // EPTSMenu
            // 
            this.EPTSMenu.Image = global::AppElyonCXC.Properties.Resources.pdf_26;
            this.EPTSMenu.Name = "EPTSMenu";
            this.EPTSMenu.Size = new System.Drawing.Size(112, 22);
            this.EPTSMenu.Text = "PDF";
            this.EPTSMenu.Click += new System.EventHandler(this.EPTSMenu_Click);
            // 
            // tmrDebounce
            // 
            this.tmrDebounce.Tick += new System.EventHandler(this.tmrDebounce_Tick);
            // 
            // UcGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UcGrid";
            this.Size = new System.Drawing.Size(470, 487);
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtGrid;
        public System.Windows.Forms.DataGridView gvGrid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar pgb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTotRegistros;
        private System.Windows.Forms.Label lbltotReg;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesTSMItem;
        private System.Windows.Forms.ToolStripMenuItem EETSMenu;
        private System.Windows.Forms.ToolStripMenuItem EPTSMenu;
        private System.Windows.Forms.Timer tmrDebounce;
    }
}
