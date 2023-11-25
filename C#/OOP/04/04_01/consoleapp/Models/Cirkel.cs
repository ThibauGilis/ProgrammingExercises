using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Cirkel: Punt
    {
        private double _r;
        private string _omschrijving;

        public double R 
        {
            get { return _r; }
            set { _r = value; }
        }
        public new string Omschrijving
        {
            get { return _omschrijving; }
            set { _omschrijving = value; }
        }


        public Cirkel(): base()
        {
            this.R = 0;
            Omschrijving = $"{base.Omschrijving} straal {this.R}";
        }
        public Cirkel(double x, double y, double r): base(x,y)
        {
            this.R = r;
            Omschrijving = $"{base.Omschrijving} straal {this.R}";
        }

        public double Omtrek()
        {
            return Math.Round(2 * Math.PI * this.R, 2);
        }
        public double Oppervlakte()
        {
            return Math.Round(Math.PI * Math.Pow(this.R, 2), 2);
        }
        public override string ToonGegevens()
        {
            return $"{this.Omschrijving}\nOppervlakte: {Oppervlakte()}\nOmtrek: {Omtrek()}";
        }
    }
}
