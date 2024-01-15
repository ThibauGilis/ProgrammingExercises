using System;

namespace consoleapp.Models
{
    public class Woning
    {
        private string _adres;
        private double _oppervlakte;
        private int _bouwjaar;
        private bool _zonnepanelen;

        public string Adres
        {
            get { return _adres; } 
            set { _adres = value; }
        }
        public double Oppervlakte
        {
            get { return _oppervlakte; }
            set { _oppervlakte = value; }
        }
        public int Bouwjaar
        {
            get { return _bouwjaar; }
            set { _bouwjaar = value; }
        }
        public bool Zonnepanelen
        {
            get { return _zonnepanelen; }
            set { _zonnepanelen = value; }
        }
        public string Info
        {
            get { return $"{this.GetType().Name} - {this.Adres}"; }
        }

        public Woning(string adres, double oppervlakte, int bouwjaar, bool heeftZonnepanelen)
        {
            this.Adres = adres;
            this.Oppervlakte = oppervlakte;
            this.Bouwjaar = bouwjaar;
            this.Zonnepanelen = heeftZonnepanelen;
        }

        public override string ToString()
        {
            return $"De woning gelegen te {this.Adres} heeft een oppervlakte van {this.Oppervlakte} vierkante meter en is gebouwd in {this.Bouwjaar}.\r\nZonnepanelen zijn {(this.Zonnepanelen?"al":"nog niet")} aanwezig.\r";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Woning woning)
            {
                return woning.Adres == this.Adres;
            }

            return false;
        }
    }
}