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

        #region Métodos
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
            MapMonthDays = new Dictionary<string, int>();

            for (int mes = 1; mes <= 12; mes++)
            {
                DateTime fecha = new DateTime(DateTime.Now.Year, mes, 1);
                mesActual = fecha.ToString("MMMM");
                MapMonthDays.Add(Capitalize(mesActual), GetDaysOfMonth(DateTime.Now.Year, mes));
            }

            this.comboMes.Items.AddRange(MapMonthDays.Keys.ToArray());
        }

        private void SetDias(string month)
        {
            string firstItem = this.comboDia.Items[0].ToString();
            
            this.comboDia.Items.Clear();
            
            this.comboDia.Items.Add(firstItem);
            this.comboDia.Items.AddRange(GetRange(MapMonthDays[month]));

            this.comboDia.SelectedIndex = 0;
        }

        private string Capitalize(string word) => char.ToUpper(word[0]) + word.Substring(1);

        private int GetDaysOfMonth(int year, int month) => DateTime.DaysInMonth(year, month);

        private Object[] GetRange(int range)
        {
            Object[] days = new Object[range];
            
            for(int i = 1; i <= range; i++)
            {
                days[i - 1] = i;
            }

            return days;
        }
        #endregion

        #region Eventos
        private void comboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.comboMes.SelectedIndex != 0)
            {
                this.comboDia.Enabled = true;

                SetDias(this.comboMes.Text);
            }
            else
            {
                this.comboDia.Enabled = false;
                this.comboDia.SelectedIndex = 0;
            }
        }
        #endregion

        #region Propiedades
        Dictionary<string, int> MapMonthDays;
        #endregion
    }
}
