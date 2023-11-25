using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Werknemer : Persoon
    {
        private double _loon;

        public double Loon 
        { 
            get { return _loon; }
            set { _loon = value; }
        }

        public Werknemer(string voornaam, string achternaam): base (voornaam, achternaam)
        {
            this.Loon = 10.20;
        }

        public override string ToonGegevens()
        {
            return base.ToonGegevens() + $"en ik verdien {this.Loon} euro per uur.";
        }
    }
}
