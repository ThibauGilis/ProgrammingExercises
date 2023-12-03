using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    internal class Papegaai: Dier
    {
        public override string Gegevens
        {
            get { return $"{base.Gegevens} Krahh, Krahh! Wipo!"; }
        }

        public Papegaai(string naam) : base(naam)
        {

        }

        public override string Praten(string zin)
        {
            return $"Krahh! {zin}";
        }
        public override string Strelen()
        {
            return "Koko! koko! kokoooohh!";
        }
    }
}