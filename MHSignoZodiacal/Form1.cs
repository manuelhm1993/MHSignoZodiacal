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
            MapMonthDays = new Dictionary<string, int>();
            MapMonthZodiacSigns = new Dictionary<string, string[]>();

            InitializeComponent();

            Reset();
            SetMeses();
        }

        #region Métodos
        private void Reset()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            txtSalida.Text = String.Empty;

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

        private void MapMonthsObject(int typeMap)
        {
            string mesActual = String.Empty;

            for (int mes = 1; mes <= 12; mes++)
            {
                DateTime fecha = new DateTime(DateTime.Now.Year, mes, 1);
                mesActual = fecha.ToString("MMMM");

                switch(typeMap)
                {
                    case 0:
                        MapMonthDays.Add(Capitalize(mesActual), GetDaysOfMonth(DateTime.Now.Year, mes));
                        break;
                    case 1:
                        MapMonthZodiacSigns.Add(Capitalize(mesActual), MapZodiacSigns[Capitalize(mesActual)]);
                        break;
                }
            }
        }

        private void SetMeses()
        {
            MapMonthsObject(0);
            //MapMonthsObject(1);
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
            txtSalida.Text = String.Empty;

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

        private void comboDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSalida.Text = String.Empty;

            bool isDay = (this.comboDia.SelectedIndex != 0);

            btnConsultar.Enabled = isDay;
            btnResetear.Enabled = isDay;
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string mes = this.comboMes.Text;
            int dia = Int32.Parse(this.comboDia.Text);
            string response = String.Empty;

            if (mes.Equals("Enero") && (dia >= 1 && dia <= 19))
            {
                response = "Tu signo es Capricornio";
            }
            else if (mes.Equals("Enero") && (dia >= 20 && dia <= 31))
            {
                response = "Tu signo es Acuario";
            }
            else if (mes.Equals("Febrero") && (dia >= 1 && dia <= 18))
            {
                response = "Tu signo es Acuario";
            }
            else if (mes.Equals("Febrero") && (dia >= 19 && dia <= 29))
            {
                response = "Tu signo es Piscis";
            }
            else if (mes.Equals("Marzo") && (dia >= 1 && dia <= 20))
            {
                response = "Tu signo es Piscis";
            }
            else if (mes.Equals("Marzo") && (dia >= 21 && dia <= 31))
            {
                response = "Tu signo es Aries";
            }
            else if (mes.Equals("Abril") && (dia >= 1 && dia <= 19))
            {
                response = "Tu signo es Aries";
            }
            else if (mes.Equals("Abril") && (dia >= 20 && dia <= 30))
            {
                response = "Tu signo es Tauro";
            }
            else if (mes.Equals("Mayo") && (dia >= 1 && dia <= 20))
            {
                response = "Tu signo es Tauro";
            }
            else if (mes.Equals("Mayo") && (dia >= 21 && dia <= 31))
            {
                response = "Tu signo es Géminis";
            }
            else if (mes.Equals("Junio") && (dia >= 1 && dia <= 20))
            {
                response = "Tu signo es Géminis";
            }
            else if (mes.Equals("Junio") && (dia >= 21 && dia <= 30))
            {
                response = "Tu signo es Cáncer";
            }
            else if (mes.Equals("Julio") && (dia >= 1 && dia <= 22))
            {
                response = "Tu signo es Cáncer";
            }
            else if (mes.Equals("Julio") && (dia >= 23 && dia <= 31))
            {
                response = "Tu signo es Leo";
            }
            else if (mes.Equals("Agosto") && (dia >= 1 && dia <= 22))
            {
                response = "Tu signo es Leo";
            }
            else if (mes.Equals("Agosto") && (dia >= 23 && dia <= 31))
            {
                response = "Tu signo es Virgo";
            }
            else if (mes.Equals("Septiembre") && (dia >= 1 && dia <= 22))
            {
                response = "Tu signo es Virgo";
            }
            else if (mes.Equals("Septiembre") && (dia >= 23 && dia <= 30))
            {
                response = "Tu signo es Libra";
            }
            else if (mes.Equals("Octubre") && (dia >= 1 && dia <= 22))
            {
                response = "Tu signo es Libra";
            }
            else if (mes.Equals("Octubre") && (dia >= 23 && dia <= 31))
            {
                response = "Tu signo es Escorpio";
            }
            else if (mes.Equals("Noviembre") && (dia >= 1 && dia <= 21))
            {
                response = "Tu signo es Escorpio";
            }
            else if (mes.Equals("Noviembre") && (dia >= 22 && dia <= 30))
            {
                response = "Tu signo es Sagitario";
            }
            else if (mes.Equals("Diciembre") && (dia >= 1 && dia <= 21))
            {
                response = "Tu signo es Sagitario";
            }
            else if (mes.Equals("Diciembre") && (dia >= 22 && dia <= 31))
            {
                response = "Tu signo es Capricornio";
            }

            txtSalida.Visible = true;
            txtSalida.Text = response;
        }
        #endregion

        #region Propiedades
        Dictionary<string, int> MapMonthDays;
        Dictionary<string, string[]> MapMonthZodiacSigns;

        Dictionary<string, string[]> MapZodiacSigns = new Dictionary<string, string[]>()
        {
            { "Enero", new string[] { "Capricornio", "Acuario" } },
            { "Febrero", new string[] { "Acuario", "Piscis" } },
            { "Marzo", new string[] { "Piscis", "Aries" } },
            { "Abril", new string[] { "Aries", "Tauro" } },
            { "Mayo", new string[] { "Tauro", "Géminis" } },
            { "Junio", new string[] { "Géminis", "Cáncer" } },
            { "Julio", new string[] { "Cáncer", "Leo" } },
            { "Agosto", new string[] { "Leo", "Virgo" } },
            { "Septiembre", new string[] { "Virgo", "Libra" } },
            { "Octubre", new string[] { "Libra", "Escorpio" } },
            { "Noviembre", new string[] { "Escorpio", "Sagitario" } },
            { "Diciembre", new string[] { "Sagitario", "Capricornio" } }
        };
        #endregion
    }
}
