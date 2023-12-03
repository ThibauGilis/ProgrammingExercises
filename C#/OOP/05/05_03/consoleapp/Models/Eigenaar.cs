using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Eigenaar: Winkel
    {
        private double _vastInkomen;

        public double VastInkomen
        {
            get { return _vastInkomen; }
            set {  _vastInkomen = value; }
        }

        public Eigenaar(string voornaam, string familienaam, double uurloon, double vastInkomen) : base(voornaam, familienaam, uurloon)
        {
            this.VastInkomen = vastInkomen;
        }

        public override double Loon()
        {
            return base.Loon() + this.VastInkomen;
        }
        public override string ToString()
        {
            return base.ToString() + $" Dit is ook de eigenaar en daarom is het loon hoger.";
        }
    }
}
