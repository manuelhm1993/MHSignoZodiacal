using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using MHSignoZodiacal.Views;
using MHSignoZodiacal.Models;

namespace MHSignoZodiacal.Controllers
{
    public static class SignoZodiacalController
    {
        public static void SetDescripcionSigno(string mes, int dia)
        {
            // Form._txtSalida.Text = SignoZodiacalCondicional.GetDescripcionSigno(mes, dia);
            FormSignoZodiacal._txtSalida.Text = (new SignoZodiacal()).GetDescripcionSigno(mes, dia);
        }

        public static SignoZodiacalView GetIGUSignoZodiacal() => new SignoZodiacalView();

        public static SignoZodiacalView FormSignoZodiacal { get; set; }
    }
}
