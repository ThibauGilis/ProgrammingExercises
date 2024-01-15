using System;

namespace consoleapp.Models
{
    public class Huis : Woning
    {
        private int _aantalKamers;

        public int AantalKamers
        {
            get { return _aantalKamers; }
            set { _aantalKamers = value; }
        }

        public double GemiddeldeKameropervlakte
        {
            get { return this.Oppervlakte / this.AantalKamers; }
        }

        public Huis(string adres, double oppervlakte, int bouwjaar, bool heeftZonnepanelen, int aantalKamers) : base(adres, oppervlakte, bouwjaar, heeftZonnepanelen)
        {
            this.AantalKamers = aantalKamers;
        }

        public double BerekenVerbruik(int aantalPersonen)
        {
            double totaalVerbruik = 100;

            if (this.Bouwjaar < 1970)
            {
                totaalVerbruik += 100;
            }
            if (this.Zonnepanelen)
            {
                totaalVerbruik -= 20;
            }
            return totaalVerbruik + (5 * aantalPersonen);
        }
        public override string ToString()
        {
            return $"{base.ToString()}\nEr zijn {this.AantalKamers} kamers.";
        }
    }
}