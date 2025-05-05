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
        public SignoZodiacal() 
        {
            Emojis = new Dictionary<string, string>()
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

            MapZodiacSigns = new Dictionary<string, string>()
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
        }

        private string GetEmoji(string signo) => Emojis[signo];

        public string GetDescripcionSigno(string mesTexto, int dia, List<SignoZodiacal> Signos)
        {
            int mes = DateTime.ParseExact(mesTexto, "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month;

            SignoZodiacal signo = Signos.FirstOrDefault(r => (r.InicioMes == mes && dia >= r.InicioDia) || (r.FinMes == mes && dia <= r.FinDia));

            return signo != null ? $"Tu signo es: {signo.Nombre} {GetEmoji(signo.Nombre)}: {MapZodiacSigns[signo.Nombre]}" : "Fecha inválida.";
        }
        #endregion

        #region Propiedades
        public string Nombre { get; set; }
        public int InicioMes { get; set; }
        public int InicioDia { get; set; }
        public int FinMes { get; set; }
        public int FinDia { get; set; }
        public Dictionary<string, string> MapZodiacSigns { get; }
        public Dictionary<string, string> Emojis { get; }
        public List<SignoZodiacal> Signos { get; }
        #endregion
    }
}
