using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace AppElyonCXC.Mantenimiento
{
    public partial class FrmProgresBar : Form
    {
        private Thread _subProceso;
        public FrmProgresBar(int segundos, Thread t)
        {
            InitializeComponent();

            timer1.Interval = segundos * 1000;	// pasamos de segundos a milisegundos
            _subProceso = t;

            if (!timer1.Enabled)
                timer1.Enabled = true;	// Activamos el Timer si no esta Enabled (activado)
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();				// Se para el timer.

            if (_subProceso.IsAlive)
            {
                // Una vez transcurrido el tiempo inicialmente establecido
                // establezco un intervalo de un segundo para mirar si el proceso ha terminado.

                if (timer1.Interval != 1000)
                    timer1.Interval = 1000;

                timer1.Start();
            }
            else
                this.Close();			// Si se ha terminado cerramos.
        }
    }
}
