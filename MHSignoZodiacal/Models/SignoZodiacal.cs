using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHSignoZodiacal.Models
{
    public class SignoZodiacal
    {
        #region Métodos
        private static string GetEmoji(string signo) => Emojis[signo];

        public static string GetDescripcionSigno(string mesTexto, int dia)
        {
            int mes = DateTime.ParseExact(mesTexto, "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month;

            SignoZodiacal signo = Signos.FirstOrDefault(r => (r.InicioMes == mes && dia >= r.InicioDia) || (r.FinMes == mes && dia <= r.FinDia));

            return signo != null ? $"Tu signo es: {signo.Nombre} {GetEmoji(signo.Nombre)}: {MapDescripcionSignos[signo.Nombre]}" : "Fecha inválida.";
        }
        #endregion

        #region Propiedades static
        private static readonly List<SignoZodiacal> Signos = new List<SignoZodiacal>()
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

        private static readonly Dictionary<string, string> MapDescripcionSignos = new Dictionary<string, string>()
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

        private static readonly Dictionary<string, string> Emojis = new Dictionary<string, string>()
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


        #region Propiedades de instancia
        public string Nombre { get; set; }
        public int InicioMes { get; set; }
        public int InicioDia { get; set; }
        public int FinMes { get; set; }
        public int FinDia { get; set; }
        #endregion
    }
}
