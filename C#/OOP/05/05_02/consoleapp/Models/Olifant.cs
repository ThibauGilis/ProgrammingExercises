using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Olifant: Dier
    {
        public override string Gegevens
        {
            get { return $"{base.Gegevens} Pfwww! STOMP!"; }
        }

        public Olifant(string naam) : base(naam)
        {

        }

        public override string Praten(string zin)
        {
            return $"Pfwwwwwww!";
        }
        public override string Strelen()
        {
            return "STOMP! STOMP! STOMP!";
        }
    }
}

