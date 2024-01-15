using System;

namespace consoleapp.Models
{
    public class Appartement : Woning
    {
        private int _verdieping;
        private double _vastekosten;

        public int Verdieping
        {
            get { return _verdieping; }
            set { _verdieping = value; }
        }
        public double Vastekosten
        {
            get { return _vastekosten; }
            set { _vastekosten = value; }
        }

        public Appartement(string adres, double oppervlakte, int bouwjaar, bool heeftZonnepanelen, int verdieping, double vastekosten) : base(adres, oppervlakte, bouwjaar, heeftZonnepanelen)
        {
            Verdieping = verdieping;
            Vastekosten = vastekosten;
        }

        public double BerekenHuurprijs(int aantalPersonen)
        {
            double totaalPrijs = this.Vastekosten;

            totaalPrijs += 50 * this.Verdieping;
            totaalPrijs += 30 * aantalPersonen;

            return totaalPrijs;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nDe vaste kosten voor dit appartement zijn {this.Vastekosten} euro.";
        }
    }
}