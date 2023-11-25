using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Cilinder: Cirkel
    {
        private double _h;
        private string _omschrijving;

        public double H
        {
            get { return _h; }
            set { _h = value; }
        }
        public new string Omschrijving 
        { 
            get {  return _omschrijving; } 
            set {  _omschrijving = value; } 
        }

        public Cilinder(): base()
        {
            this.H = 0;
            this.Omschrijving = $"{base.Omschrijving}, hoogte {this.H}";
        }
        public Cilinder(double x, double y, double r, double h) : base(x, y, r)
        {
            this.H = h;
            this.Omschrijving = $"{base.Omschrijving}, hoogte {this.H}";
        }

        public double Volume()
        {
            return base.Oppervlakte() * this.H;
        }
        public double Oppervlakte()
        {
            return 2 * base.Oppervlakte() + base.Omtrek() * this.H;
        }
        public override string ToonGegevens()
        {
            return $"{this.Omschrijving}\nOppervlakte: {Oppervlakte()}\nVolume: {Volume()}";
        }
    }
}
