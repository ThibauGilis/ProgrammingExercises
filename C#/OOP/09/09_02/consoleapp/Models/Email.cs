using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Email
    {
        private Persoon _verzender;
        private Persoon _ontvanger;
        private string _titel;
        private string _bericht;

        public Persoon Verzender
        {
            get { return _verzender; }
            set { _verzender = value; }
        }
        public Persoon Ontvanger
        {
            get { return _ontvanger; }
            set { _ontvanger = value; }
        }
        public string Titel
        {
            get { return _titel; }
            set { _titel = value; }
        }
        public string Bericht
        {
            get { return _bericht; }
            set { _bericht = value; }
        }

        public Email(Persoon verzender, Persoon ontvanger, string titel, string bericht)
        {
            this.Verzender = verzender;
            this.Ontvanger = ontvanger;
            this.Titel = titel;
            this.Bericht = bericht;
        }

        public override string ToString()
        {
            return $"Verzender: {this.Verzender}\nOntvanger: {this.Ontvanger}\nTitel: {this.Titel}\nBericht: {this.Bericht}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Email email)
            {
                return email.GetHashCode() == this.GetHashCode();
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Verzender, this.Ontvanger, this.Titel, this.Bericht);
        }
    }
}
