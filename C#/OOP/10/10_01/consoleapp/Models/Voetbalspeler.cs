using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Voetbalspeler : Persoon
    {
        private string _positie;

        public string Positie
        {
            get { return _positie; }
            set { _positie = value; }
        }

        public Voetbalspeler(string voornaam, string achternaam, string positie) : base(voornaam, achternaam)
        {
            this.Positie = positie;
        }

        public override string ToString()
        {
            return $"{base.ToString()} speelt op positie {this.Positie}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Voetbalspeler voetbalspeler)
            {
                return voetbalspeler.GetHashCode() == this.GetHashCode();
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Voornaam, this.Achternaam, this.Positie);
        }
    }
}
