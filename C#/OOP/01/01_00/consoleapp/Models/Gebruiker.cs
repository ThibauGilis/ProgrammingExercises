using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Gebruiker
    {
        // atribuutjes
        private int _nummer;
        private string _voornaam;
        private string _familienaam;

        // proppertietjes
        public int Nummer
        {
            get { return _nummer; }
            set { _nummer = value; }
        }
        public string Voornaam
        {
            get { return _voornaam; }
            set { _voornaam = value; }
        }
        public string Familienaam
        {
            get { return _familienaam;}
            set { _familienaam = value;}
        }

        // constructortje
        public Gebruiker()
        {
            this.Nummer = 0;
            this.Voornaam = "";
            this.Familienaam = "";
        }

        // methootje
        public void Wissen()
        {
            this.Nummer = 0;
            this.Voornaam = "";
            this.Familienaam = "";
        }
        public string ToonGegevens()
        {
            return $"{this.Nummer} - {this.Voornaam} {this.Familienaam}";
        }
    }
}
