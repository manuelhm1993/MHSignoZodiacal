using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
            string response = "Tu signo es ";

            if (mes.Equals("Enero") && (dia >= 1 && dia <= 19))
            {
                response += $"Capricornio: {MapZodiacSigns["Capricornio"]}";
            }
            else if (mes.Equals("Enero") && (dia >= 20 && dia <= 31))
            {
                response += $"Acuario: {MapZodiacSigns["Acuario"]}";
            }
            else if (mes.Equals("Febrero") && (dia >= 1 && dia <= 18))
            {
                response += $"Acuario: {MapZodiacSigns["Acuario"]}";
            }
            else if (mes.Equals("Febrero") && (dia >= 19 && dia <= 29))
            {
                response += $"Piscis: {MapZodiacSigns["Piscis"]}";
            }
            else if (mes.Equals("Marzo") && (dia >= 1 && dia <= 20))
            {
                response += $"Piscis: {MapZodiacSigns["Piscis"]}";
            }
            else if (mes.Equals("Marzo") && (dia >= 21 && dia <= 31))
            {
                response += $"Aries: {MapZodiacSigns["Aries"]}";
            }
            else if (mes.Equals("Abril") && (dia >= 1 && dia <= 19))
            {
                response += $"Aries: {MapZodiacSigns["Aries"]}";
            }
            else if (mes.Equals("Abril") && (dia >= 20 && dia <= 30))
            {
                response += $"Tauro: {MapZodiacSigns["Tauro"]}";
            }
            else if (mes.Equals("Mayo") && (dia >= 1 && dia <= 20))
            {
                response += $"Tauro: {MapZodiacSigns["Tauro"]}";
            }
            else if (mes.Equals("Mayo") && (dia >= 21 && dia <= 31))
            {
                response += $"Géminis: {MapZodiacSigns["Géminis"]}";
            }
            else if (mes.Equals("Junio") && (dia >= 1 && dia <= 20))
            {
                response += $"Géminis: {MapZodiacSigns["Géminis"]}";
            }
            else if (mes.Equals("Junio") && (dia >= 21 && dia <= 30))
            {
                response += $"Cáncer: {MapZodiacSigns["Cáncer"]}";
            }
            else if (mes.Equals("Julio") && (dia >= 1 && dia <= 22))
            {
                response += $"Cáncer: {MapZodiacSigns["Cáncer"]}";
            }
            else if (mes.Equals("Julio") && (dia >= 23 && dia <= 31))
            {
                response += $"Leo: {MapZodiacSigns["Leo"]}";
            }
            else if (mes.Equals("Agosto") && (dia >= 1 && dia <= 22))
            {
                response += $"Leo: {MapZodiacSigns["Leo"]}";
            }
            else if (mes.Equals("Agosto") && (dia >= 23 && dia <= 31))
            {
                response += $"Virgo: {MapZodiacSigns["Virgo"]}";
            }
            else if (mes.Equals("Septiembre") && (dia >= 1 && dia <= 22))
            {
                response += $"Virgo: {MapZodiacSigns["Virgo"]}";
            }
            else if (mes.Equals("Septiembre") && (dia >= 23 && dia <= 30))
            {
                response += $"Libra: {MapZodiacSigns["Libra"]}";
            }
            else if (mes.Equals("Octubre") && (dia >= 1 && dia <= 22))
            {
                response += $"Libra: {MapZodiacSigns["Libra"]}";
            }
            else if (mes.Equals("Octubre") && (dia >= 23 && dia <= 31))
            {
                response += $"Escorpio: {MapZodiacSigns["Escorpio"]}";
            }
            else if (mes.Equals("Noviembre") && (dia >= 1 && dia <= 21))
            {
                response += $"Escorpio: {MapZodiacSigns["Escorpio"]}";
            }
            else if (mes.Equals("Noviembre") && (dia >= 22 && dia <= 30))
            {
                response += $"Sagitario: {MapZodiacSigns["Sagitario"]}";
            }
            else if (mes.Equals("Diciembre") && (dia >= 1 && dia <= 21))
            {
                response += $"Sagitario: {MapZodiacSigns["Sagitario"]}";
            }
            else if (mes.Equals("Diciembre") && (dia >= 22 && dia <= 31))
            {
                response += $"Capricornio: {MapZodiacSigns["Capricornio"]}";
            }

            txtSalida.Visible = true;
            txtSalida.Text = response;
        }
        #endregion

        #region Propiedades
        Dictionary<string, int> MapMonthDays;

        Dictionary<string, string> MapZodiacSigns = new Dictionary<string, string>()
        {
            { "Capricornio", " un signo de tierra regido por Saturno, se caracteriza por su disciplina, ambición y responsabilidad." },
            { "Acuario", " un signo de aire y se caracteriza por su naturaleza independiente, intelectual y humanitaria." },
            { "Piscis", " un signo de agua y el último del zodiaco, se caracteriza por su profunda sensibilidad, empatía y creatividad." },
            { "Aries", " el primer signo del zodiaco, un signo de fuego, se caracteriza por ser enérgico, apasionado y líder." },
            { "Tauro", " se caracteriza por su naturaleza terrestre, lo que le otorga cualidades de estabilidad, persistencia y un enfoque práctico en la vida." },
            { "Géminis", " un signo de aire y regido por Mercurio, se caracterizan por su naturaleza dual, comunicativa, curiosa y adaptable." },
            { "Cáncer", " un signo de agua, lo que le otorga una naturaleza emocional, intuitiva y sensible." },
            { "Leo", " un signo de fuego, regidos por el Sol, son conocidos por su naturaleza cálida, extrovertida y generosa." },
            { "Virgo", " un signo de tierra y mutable, caracterizado por su naturaleza analítica, metódica y práctica." },
            { "Libra", " un signo de aire, lo que significa que sus características incluyen inteligencia, capacidad de comunicación, adaptabilidad y un fuerte sentido de la justicia y la armonía." },
            { "Escorpio", " un signo zodiacal de agua, conocido por su intensidad emocional, pasión y profundidad." },
            { "Sagitario", " un signo zodiacal de fuego, representado por un centauro con flecha, que simboliza la búsqueda de la verdad y la libertad." }
        };
        #endregion
    }
}
