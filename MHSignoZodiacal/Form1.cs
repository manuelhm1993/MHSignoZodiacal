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

            Reset();
            SetMeses();
        }

        private void Reset()
        {
            // Establecer los valores por defecto de los combos
            this.comboMes.SelectedIndex = 0;
            this.comboDia.SelectedIndex = 0;

            // Desactivar componentes
            this.txtSalida.Enabled = false;
            this.btnConsultar.Enabled = false;
            this.btnResetear.Enabled = false;
            this.comboDia.Enabled = false;

            // Ocultar componentes
            this.txtSalida.Visible = false;
        }

        private void SetMeses()
        {
            string mesActual = String.Empty;

            for (int mes = 1; mes <= 12; mes++)
            {
                DateTime fecha = new DateTime(DateTime.Now.Year, mes, 1);
                mesActual = fecha.ToString("MMMM");

                this.comboMes.Items.Add(Capitalize(mesActual));
            }
        }

        private string Capitalize(string word) => char.ToUpper(word[0]) + word.Substring(1);
    }
}
