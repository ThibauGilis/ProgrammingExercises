using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class ZakelijkeKlant : Klant
    {
        private string _btwNummer;

        public string BtwNummer
        {
            get { return _btwNummer; }
            set 
            {
                if (value.Substring(0,2) == "BE") _btwNummer = value;
                else throw new OngeldigBtwNummerException();
            }
        }

        public ZakelijkeKlant(int klantennummer, string naam, string adres, string gemeente, string postcode, string btwNummer) : base(klantennummer, naam, adres, gemeente, postcode)
        {
            BtwNummer = btwNummer;
        }
    }
}
