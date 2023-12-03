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
            this.Percentage = 15;
        }

        public void SchrijfRentebij()
        {
            this.Saldo = Math.Round(this.Saldo * (1 + this.Percentage / 100), 2);
        }
        public override string ToonGegevens()
        {
            return base.ToonGegevens() + $" (percentage {this.Percentage})";
        }
        public override string ToString()
        {
            return $"{base.ToString()}\nDe rentevoet bedraagt: {this.Percentage}%.";
        }

    }
}
