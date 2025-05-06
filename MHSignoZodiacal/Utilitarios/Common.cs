using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHSignoZodiacal.Utilitarios
{
    public static class Common
    {
        public static Object[] GetRange(int range)
        {
            Object[] days = new Object[range];

            for (int i = 1; i <= range; i++)
            {
                days[i - 1] = i;
            }

            return days;
        }

        public static string Capitalize(string word) => char.ToUpper(word[0]) + word.Substring(1);

        public static int GetDaysOfMonth(int year, int month) => DateTime.DaysInMonth(year, month);
    }
}
