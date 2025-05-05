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

using MHSignoZodiacal.Models;

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

        private string GetEmoji(string signo) => emojis[signo];

        private string GetDescripcionSigno(string mesTexto, int dia)
        {
            int mes = DateTime.ParseExact(mesTexto, "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month;

            RangoZodiacal signo = rangos.FirstOrDefault(r => (r.InicioMes == mes && dia >= r.InicioDia) || (r.FinMes == mes && dia <= r.FinDia));

            return signo != null ? $"Tu signo es: {signo.Nombre} {GetEmoji(signo.Nombre)}: {MapZodiacSigns[signo.Nombre]}" : "Fecha inválida.";
        }

        private string GetDescripcionSignoCondicional(string mesTexto, int dia)
        {
            string response = "Tu signo es ";
            int mes = DateTime.ParseExact(mesTexto, "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month;

            if (((mes == 12) && (dia >= 22 && dia <= 31)) || ((mes == 1) && (dia >= 1 && dia <= 19)))
            {
                response += $"Capricornio ♑: {MapZodiacSigns["Capricornio"]}";
            }
            else if (((mes == 1) && (dia >= 20 && dia <= 31)) || ((mes == 2) && (dia >= 1 && dia <= 18)))
            {
                response += $"Acuario ♒: {MapZodiacSigns["Acuario"]}";
            }
            else if (((mes == 2) && (dia >= 19 && dia <= 29)) || ((mes == 3) && (dia >= 1 && dia <= 20)))
            {
                response += $"Piscis ♓: {MapZodiacSigns["Piscis"]}";
            }
            else if (((mes == 3) && (dia >= 21 && dia <= 31)) || ((mes == 4) && (dia >= 1 && dia <= 19)))
            {
                response += $"Aries ♈: {MapZodiacSigns["Aries"]}";
            }
            else if (((mes == 4) && (dia >= 20 && dia <= 30)) || ((mes == 5) && (dia >= 1 && dia <= 20)))
            {
                response += $"Tauro ♉: {MapZodiacSigns["Tauro"]}";
            }
            else if (((mes == 5) && (dia >= 21 && dia <= 31)) || ((mes == 6) && (dia >= 1 && dia <= 20)))
            {
                response += $"Géminis ♊: {MapZodiacSigns["Géminis"]}";
            }
            else if (((mes == 6) && (dia >= 21 && dia <= 30)) || ((mes == 7) && (dia >= 1 && dia <= 22)))
            {
                response += $"Cáncer ♋: {MapZodiacSigns["Cáncer"]}";
            }
            else if (((mes == 7) && (dia >= 23 && dia <= 31)) || ((mes == 8) && (dia >= 1 && dia <= 22)))
            {
                response += $"Leo ♌: {MapZodiacSigns["Leo"]}";
            }
            else if (((mes == 8) && (dia >= 23 && dia <= 31)) || ((mes == 9) && (dia >= 1 && dia <= 22)))
            {
                response += $"Virgo ♍: {MapZodiacSigns["Virgo"]}";
            }
            else if (((mes == 9) && (dia >= 23 && dia <= 30)) || ((mes == 10) && (dia >= 1 && dia <= 22)))
            {
                response += $"Libra ♎: {MapZodiacSigns["Libra"]}";
            }
            else if (((mes == 10) && (dia >= 23 && dia <= 31)) || ((mes == 11) && (dia >= 1 && dia <= 21)))
            {
                response += $"Escorpio ♏: {MapZodiacSigns["Escorpio"]}";
            }
            else if (((mes == 11) && (dia >= 22 && dia <= 30)) || ((mes == 12) && (dia >= 1 && dia <= 21)))
            {
                response += $"Sagitario ♐: {MapZodiacSigns["Sagitario"]}";
            }

            return response;
        }

        private void PrintOutput()
        {
            if(this.comboDia.SelectedIndex != 0)
            {
                string mes = this.comboMes.Text;
                int dia = Int32.Parse(this.comboDia.Text);

                txtSalida.Visible = true;
                //txtSalida.Text = GetDescripcionSigno(mes, dia);
                txtSalida.Text = GetDescripcionSignoCondicional(mes, dia);
            }
            else
            {
                txtSalida.Visible = false;
                txtSalida.Text = String.Empty;
            }
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

            if(btnConsultar.Enabled)
            {
                PrintOutput();
            }
            else
            {
                bool isDay = (this.comboDia.SelectedIndex != 0);

                btnConsultar.Enabled = isDay;
                btnResetear.Enabled = isDay;
            }
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            PrintOutput();
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

        List<RangoZodiacal> rangos = new List<RangoZodiacal>()
        {
            new RangoZodiacal { Nombre = "Capricornio", InicioMes = 12, InicioDia = 22, FinMes = 1, FinDia = 19 },
            new RangoZodiacal { Nombre = "Acuario",     InicioMes = 1,  InicioDia = 20, FinMes = 2, FinDia = 18 },
            new RangoZodiacal { Nombre = "Piscis",      InicioMes = 2,  InicioDia = 19, FinMes = 3, FinDia = 20 },
            new RangoZodiacal { Nombre = "Aries",       InicioMes = 3,  InicioDia = 21, FinMes = 4, FinDia = 19 },
            new RangoZodiacal { Nombre = "Tauro",       InicioMes = 4,  InicioDia = 20, FinMes = 5, FinDia = 20 },
            new RangoZodiacal { Nombre = "Géminis",     InicioMes = 5,  InicioDia = 21, FinMes = 6, FinDia = 20 },
            new RangoZodiacal { Nombre = "Cáncer",      InicioMes = 6,  InicioDia = 21, FinMes = 7, FinDia = 22 },
            new RangoZodiacal { Nombre = "Leo",         InicioMes = 7,  InicioDia = 23, FinMes = 8, FinDia = 22 },
            new RangoZodiacal { Nombre = "Virgo",       InicioMes = 8,  InicioDia = 23, FinMes = 9, FinDia = 22 },
            new RangoZodiacal { Nombre = "Libra",       InicioMes = 9,  InicioDia = 23, FinMes = 10, FinDia = 22 },
            new RangoZodiacal { Nombre = "Escorpio",    InicioMes = 10, InicioDia = 23, FinMes = 11, FinDia = 21 },
            new RangoZodiacal { Nombre = "Sagitario",   InicioMes = 11, InicioDia = 22, FinMes = 12, FinDia = 21 }
        };

        Dictionary<string, string> emojis = new Dictionary<string, string>()
        {
            { "Capricornio", "♑" },
            { "Acuario", "♒" },
            { "Piscis", "♓" },
            { "Aries", "♈" },
            { "Tauro", "♉" },
            { "Géminis", "♊" },
            { "Cáncer", "♋" },
            { "Leo", "♌" },
            { "Virgo", "♍" },
            { "Libra", "♎" },
            { "Escorpio", "♏" },
            { "Sagitario", "♐" }
        };
        #endregion
    }
}
