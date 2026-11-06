using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppElyonCXC.Mantenimiento
{
    public partial class FrmZoomAvisos : Form
    {
        public FrmZoomAvisos()
        {
            InitializeComponent();
        }
        public FrmZoomAvisos(PictureBox px)
        {
            InitializeComponent();
            pictureBox1.Image = px.Image;
        }
        private void FrmZoomAvisos_Load(object sender, EventArgs e)
        {
            this.Text = "ZOOM";
        }
    }
}
