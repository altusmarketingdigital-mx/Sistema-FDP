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
    public partial class UcSplashScreen : Form
    {
        public UcSplashScreen(string titulo, string mensaje)
        {
            InitializeComponent();
            label1.Text = mensaje;
            this.Text = titulo;
        }

        public void fn_Close()
        {
            this.Close();
        }
    }
}
