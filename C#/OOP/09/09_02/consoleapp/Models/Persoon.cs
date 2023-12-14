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
        private string _familienaam;
        private string _email;

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
        public string Email 
        { 
            get { return _email; } 
            set { _email = value; }
        }

        public Persoon(string voornaam, string familienaam, string email)
        {
            this.Voornaam = voornaam;
            this.Familienaam = familienaam;
            this.Email = email;
        }

        public override string ToString()
        {
            return $"{this.Voornaam} {this.Familienaam} ({this.Email})";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Persoon persoon)
            {
                return persoon.Email == this.Email;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Email);
        }
    }
}
