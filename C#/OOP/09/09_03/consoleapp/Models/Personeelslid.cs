using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Personeelslid
    {
        private string _familienaam;
        private string _voornaam;
        private bool _isStagair;

        public string Familienaam
        {
            get { return _familienaam; }
            set { _familienaam = value; }
        }
        public string Voornaam
        {
            get { return _voornaam; }
            set { _voornaam = value; }
        }
        public bool IsStagair
        {
            get { return _isStagair; }
            set { _isStagair = value; }
        }

        public Personeelslid(string voornaam, string familienaam, bool isStagair) 
        { 
            this.Voornaam = voornaam;
            this.Familienaam = familienaam;
            this.IsStagair = isStagair;
        }

        public override string ToString()
        {
            return $"{this.Voornaam} {this.Familienaam} ({(this.IsStagair?"Stagair":"Vaste medewerker")})";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Personeelslid personeelslid)
            {
                return this.Voornaam == personeelslid.Voornaam && this.Familienaam == personeelslid.Familienaam;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Voornaam, this.Familienaam);
        }
    }
}
