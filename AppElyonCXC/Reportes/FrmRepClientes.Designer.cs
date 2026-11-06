namespace AppElyonCXC.Reportes
{
    partial class FrmRepClientes
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
            this.crvbancos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvbancos
            // 
            this.crvbancos.ActiveViewIndex = -1;
            this.crvbancos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvbancos.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvbancos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvbancos.Location = new System.Drawing.Point(0, 0);
            this.crvbancos.Name = "crvbancos";
            this.crvbancos.ShowCloseButton = false;
            this.crvbancos.ShowCopyButton = false;
            this.crvbancos.ShowGotoPageButton = false;
            this.crvbancos.ShowGroupTreeButton = false;
            this.crvbancos.ShowLogo = false;
            this.crvbancos.ShowParameterPanelButton = false;
            this.crvbancos.ShowTextSearchButton = false;
            this.crvbancos.Size = new System.Drawing.Size(1008, 729);
            this.crvbancos.TabIndex = 1;
            this.crvbancos.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FrmRepClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.crvbancos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmRepClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRepClientes";
            this.Load += new System.EventHandler(this.FrmRepClientes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvbancos;
    }
}