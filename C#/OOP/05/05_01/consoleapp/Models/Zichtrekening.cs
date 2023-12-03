using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Zichtrekening : Bankrekening
    {
        public Zichtrekening(string ibannummer, double saldo) : base(ibannummer, saldo)
        {
            this.Minimum = -100;
        }

        public override string ToonGegevens()
        {
            return base.ToonGegevens() + $" (minimum {this.Minimum})";
        }
        public override string ToString()
        {
            return $"{base.ToString()}\nHet minimumbedrag bedraagt: {this.Minimum} euro.";
        }
    }
}
