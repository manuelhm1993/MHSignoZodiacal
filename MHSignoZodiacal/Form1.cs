using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MHSignoZodiacal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.comboMes.SelectedIndex = 0;
            this.comboDia.SelectedIndex = 0;

            SetMeses();
        }

        private void SetMeses()
        {
            string mesActual = String.Empty;

            for (int mes = 1; mes <= 12; mes++)
            {
                DateTime fecha = new DateTime(2025, mes, 1);
                mesActual = fecha.ToString("MMMM");

                this.comboMes.Items.Add(mesActual);
            }
        }
    }
}
