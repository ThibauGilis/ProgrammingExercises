using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Trainer : Persoon
    {
        private double _salaris;

        public double Salaris
        {
            get { return _salaris; }
            set { _salaris = value; }
        }

        public Trainer(string voornaam, string achternaam, double salaris) : base(voornaam, achternaam)
        {
            this.Salaris = salaris;
        }

        public override string ToString()
        {
            return $"{base.ToString()} verdient {this.Salaris} euro";
        }
    }
}
