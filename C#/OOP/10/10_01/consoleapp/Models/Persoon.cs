using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Persoon
    {
        private string _voornaam;
        private string _achternaam;

        public string Voornaam
        {
            get { return _voornaam; }
            set { _voornaam = value; }
        }
        public string Achternaam
        {
            get { return _achternaam; }
            set { _achternaam = value; }
        }

        public Persoon(string voornaam, string achternaam)
        {
            this.Voornaam = voornaam;
            this.Achternaam = achternaam;
        }

        public override string ToString()
        {
            return $"{this.Voornaam} {this.Achternaam}";
        }
    }
}
