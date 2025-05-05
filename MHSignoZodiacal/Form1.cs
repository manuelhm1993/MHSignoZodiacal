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

            Signos = new List<SignoZodiacal>()
            {
                new SignoZodiacal { Nombre = "Capricornio", InicioMes = 12, InicioDia = 22, FinMes = 1, FinDia = 19 },
                new SignoZodiacal { Nombre = "Acuario",     InicioMes = 1,  InicioDia = 20, FinMes = 2, FinDia = 18 },
                new SignoZodiacal { Nombre = "Piscis", InicioMes = 2, InicioDia = 19, FinMes = 3, FinDia = 20 },
                new SignoZodiacal { Nombre = "Aries", InicioMes = 3, InicioDia = 21, FinMes = 4, FinDia = 19 },
                new SignoZodiacal { Nombre = "Tauro", InicioMes = 4, InicioDia = 20, FinMes = 5, FinDia = 20 },
                new SignoZodiacal { Nombre = "Géminis", InicioMes = 5, InicioDia = 21, FinMes = 6, FinDia = 20 },
                new SignoZodiacal { Nombre = "Cáncer", InicioMes = 6, InicioDia = 21, FinMes = 7, FinDia = 22 },
                new SignoZodiacal { Nombre = "Leo", InicioMes = 7, InicioDia = 23, FinMes = 8, FinDia = 22 },
                new SignoZodiacal { Nombre = "Virgo", InicioMes = 8, InicioDia = 23, FinMes = 9, FinDia = 22 },
                new SignoZodiacal { Nombre = "Libra", InicioMes = 9, InicioDia = 23, FinMes = 10, FinDia = 22 },
                new SignoZodiacal { Nombre = "Escorpio", InicioMes = 10, InicioDia = 23, FinMes = 11, FinDia = 21 },
                new SignoZodiacal { Nombre = "Sagitario", InicioMes = 11, InicioDia = 22, FinMes = 12, FinDia = 21 }
            };

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

        private void PrintOutput()
        {
            if(this.comboDia.SelectedIndex != 0)
            {
                string mes = this.comboMes.Text;
                int dia = Int32.Parse(this.comboDia.Text);

                txtSalida.Visible = true;
                // txtSalida.Text = SignoZodiacalCondicional.GetDescripcionSigno(mes, dia);
                txtSalida.Text = (new SignoZodiacal()).GetDescripcionSigno(mes, dia, Signos);
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
        private Dictionary<string, int> MapMonthDays;
        List<SignoZodiacal> Signos;
        #endregion
    }
}
