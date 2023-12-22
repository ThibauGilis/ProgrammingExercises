namespace consoleapp.Models

{
    public class Klant
    {
        private string _adres;
        private string _naam;
        private string _postcode;
        private string _gemeente;
        private int _klantennummer;

        public string Adres
        {
            get { return _adres; }
            set { _adres = value; }
        }
        public string Naam
        {
            get { return _naam; }
            set { _naam = value; }
        }
        public string Postcode
        { 
            get { return _postcode; }
            set { _postcode = value; }
        }
        public string Gemeente
        {
            get { return _gemeente; }
            set { _gemeente = value; }
        }
        public int Klantennummer
        {
            get { return _klantennummer; }
            set { _klantennummer = value; }
        }

        public Klant(int klantennummer, string naam, string adres, string gemeente, string postcode)
        {
            this.Klantennummer = klantennummer;
            this.Naam = naam;
            this.Adres = adres;
            this.Gemeente = gemeente;
            this.Postcode = postcode;
        }

        public override string ToString()
        {
            return $"{this.Klantennummer}\n" +
                   $"{this.Naam}\n" +
                   $"{this.Adres}\n" +
                   $"{this.Postcode} {this.Gemeente}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Klant klant)
            {
                return klant.GetHashCode() == this.GetHashCode();
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Klantennummer);
        }
    }
}
