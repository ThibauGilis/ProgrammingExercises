using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Product
    {
        private string _naam;
        private double _prijs;

        public string Naam
        {
            get { return _naam; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new LegeTekstueleWaardeException($"_naam");
                }
                _naam = value;
            }
        }
        public double Prijs
        {
            get { return _prijs; }
            set 
            {
                if (value < 0)
                {
                    throw new NumeriekeWaardeOnderNulException("_prijs");
                }
                _prijs = value;
            }
        }

        public Product(string naam, double prijs)
        {
            this.Naam = naam;
            this.Prijs = prijs;
        }

        public string ToonGegevens()
        {
            return $"Naam: {this.Naam}\n" +
                   $"Prijs: {this.Prijs}";
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} {this.Naam} ({this.Prijs})";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Product product)
            {
                return product.Naam == this.Naam;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Naam);
        }
    }
}
