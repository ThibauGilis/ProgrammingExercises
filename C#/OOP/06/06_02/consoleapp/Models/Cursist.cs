using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Cursist
    {
        private int _cursistID;
        private string _voornaam;
        private string _familienaam;
        private string _naam;

        public int CursistID
        {
            get { return _cursistID; }
            set { _cursistID = value; }
        }
        public string Voornaam
        {
            get { return _voornaam; }
            set { _voornaam = value; }
        }
        public string Familienaam
        {
            get { return _familienaam; }
            set { _familienaam = value; }
        }
        public string Naam
        {
            get { return _naam; }
            set { _naam = value; }
        }

        public Cursist(int cursistID, string voornaam, string familienaam)
        {
            this.CursistID = cursistID;
            this.Voornaam = voornaam;
            this.Familienaam= familienaam;
            this.Naam = voornaam + " " + familienaam;
        }

        public override string ToString()
        {
            return $"{this.CursistID}. " + this.Naam;
        }
        public override bool Equals(object? obj)
        {
            if (obj is Cursist cursist)
            {
                return true;
            }

            return false;
        }
    }
}
