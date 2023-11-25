using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Klant: Persoon
    {
        private string _klantenCode;

        private string KlantenCode
        {
            get { return _klantenCode; } 
            set { _klantenCode = value;}
        }

        public Klant(string voornaam, string achternaam): base(voornaam, achternaam)
        {
            this.KlantenCode = MaakRandomKlantenCode();
        }

        public string MaakRandomKlantenCode()
        {
            Random random = new Random();
            int getal = random.Next(0,1001);

            return $"{this.Voornaam.Substring(0, 1)}{this.Achternaam.Substring(0, 1)}{getal.ToString("0000")}";
        }
        public override string ToonGegevens()
        {
            return base.ToonGegevens() + $"mijn klanten code: {this.KlantenCode}";
        }
    }
}
