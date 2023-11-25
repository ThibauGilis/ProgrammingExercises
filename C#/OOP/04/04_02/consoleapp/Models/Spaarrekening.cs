using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Spaarrekening: Bankrekening
    {
        private double _percentage;

        public double Percentage 
        { 
            get { return _percentage; } 
            set { _percentage = value; }
        }

        public Spaarrekening(string ibanNummer): base(ibanNummer, 0)
        {
            this.IbanNummer = ibanNummer;
            this.Percentage = 5;
        }

        public void SchrijfRentebij()
        {
            this.Saldo *= 1 + this.Percentage/100;
        }
        public override string ToonGegevens()
        {
            return base.ToonGegevens() + $" (percentage {this.Percentage})";
        }

    }
}
