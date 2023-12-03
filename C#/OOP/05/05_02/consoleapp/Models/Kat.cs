using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Kat: Dier
    {
        public override string Gegevens
        {
            get { return $"{base.Gegevens} Miauw! Miauw!"; }
        }

        public Kat(string naam): base(naam)
        {

        }

        public override string Praten(string zin)
        {
            return $"MAAAUWWW!";
        }
        public override string Strelen()
        {
            return "RRR! RRRR! RRRRRRRR!";
        }
    }
}
