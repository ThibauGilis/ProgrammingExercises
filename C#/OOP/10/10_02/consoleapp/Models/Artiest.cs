using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Artiest
    {
        private string _naam;
        private string _genre;
        private double _prijs;

        public string Naam
        {
            get { return _naam; }
            set { _naam = value; }
        }
        public string Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }
        public double Prijs
        {
            get { return _prijs; }
            set { _prijs = value; }
        }

        public Artiest(string naam, string genre, double prijs)
        {
            this.Naam = naam;
            this.Genre = genre;
            this.Prijs = prijs;
        }

        public override string ToString()
        {
            return $"{this.Naam} ({this.Genre})";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Artiest artiest)
            {
                return this.GetHashCode() == artiest.GetHashCode();
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Naam);
        }
    }
}
