using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHSignoZodiacal.Models
{
    public static class SignoZodiacalCondicional
    {
        #region Métodos
        public static string GetDescripcionSigno(string mesTexto, int dia)
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
        #endregion

        #region Propiedades
        private static Dictionary<string, string> MapZodiacSigns = new Dictionary<string, string>()
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
