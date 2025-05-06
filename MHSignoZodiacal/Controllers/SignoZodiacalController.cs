using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using MHSignoZodiacal.Views;
using MHSignoZodiacal.Models;
using MHSignoZodiacal.Utilitarios;

namespace MHSignoZodiacal.Controllers
{
    public static class SignoZodiacalController
    {
        #region Métodos
        public static void SetDescripcionSigno(string mes, int dia)
        {
            // FormSignoZodiacal._txtSalida.Text = SignoZodiacalCondicional.GetDescripcionSigno(mes, dia);
            FormSignoZodiacal._txtSalida.Text = SignoZodiacal.GetDescripcionSigno(mes, dia);
        }

        public static void SetMeses()
        {
            string mesActual = String.Empty;

            for (int mes = 1; mes <= 12; mes++)
            {
                DateTime fecha = new DateTime(DateTime.Now.Year, mes, 1);

                mesActual = fecha.ToString("MMMM");

                MapMonthDays.Add(Common.Capitalize(mesActual), Common.GetDaysOfMonth(DateTime.Now.Year, mes));
            }

            FormSignoZodiacal._comboMes.Items.AddRange(MapMonthDays.Keys.ToArray());
        }

        public static void SetDias(string month)
        {
            string firstItem = FormSignoZodiacal._comboDia.Items[0].ToString();

            FormSignoZodiacal._comboDia.Items.Clear();

            FormSignoZodiacal._comboDia.Items.Add(firstItem);
            FormSignoZodiacal._comboDia.Items.AddRange(Common.GetRange(MapMonthDays[month]));

            FormSignoZodiacal._comboDia.SelectedIndex = 0;
        }

        public static SignoZodiacalView GetIGUSignoZodiacal() => new SignoZodiacalView();
        #endregion

        #region Propiedades
        private static readonly Dictionary<string, int> MapMonthDays = new Dictionary<string, int>();
        public static SignoZodiacalView FormSignoZodiacal { get; set; }
        #endregion
    }
}
