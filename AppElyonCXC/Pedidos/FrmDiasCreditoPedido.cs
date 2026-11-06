using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppElyonCXC.Pedidos
{
    public partial class FrmDiasCreditoPedido : Form
    {
        public FrmDiasCreditoPedido()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

            Frm_GenerarPedido pedido = new Frm_GenerarPedido();
            pedido.rb_No_Requiere_Credito.Checked = true;
            pedido.rb_Requiere_Credito.Checked = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Frm_GenerarPedido._intDiasCredito = Convert.ToInt32(txt_Dias_Credito.Text.ToString());
            Frm_GenerarPedido._dtp_FechaVencimientoCredito = dtp_Fecha_Vencimiento.Value;
            this.Close();
        }

        private void dtp_Fecha_Vencimiento_ValueChanged(object sender, EventArgs e)
        {
            DateTime oldDate = DateTime.Now;
            DateTime newDate = dtp_Fecha_Vencimiento.Value;

            // Difference in days, hours, and minutes.
            TimeSpan ts = newDate - oldDate;

            // Difference in days.
            int differenceInDays = ts.Days;

            differenceInDays = differenceInDays + 1; 
            txt_Dias_Credito.Text = differenceInDays.ToString();
        }

        private void txt_Dias_Credito_SelectedValueChanged(object sender, EventArgs e)
        {
            DateTime nuevaFecha = DateTime.Now;
            int dias = Convert.ToInt32(txt_Dias_Credito.Text.ToString());
            nuevaFecha = nuevaFecha.AddDays(dias);

            dtp_Fecha_Vencimiento.Value = nuevaFecha;
        }
    }
}
