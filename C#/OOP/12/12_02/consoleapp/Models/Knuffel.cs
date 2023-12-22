using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Knuffel: Product
    {
        private double _lengte;
        private double _breedte;
        private double _hoogte;

        public double Lengte
        {
            get { return _lengte; }
            set 
            {
                if (value < 0)
                {
                    throw new NumeriekeWaardeOnderNulException("_lengte");
                }
                _lengte = value; 
            }
        }
        public double Breedte
        {
            get { return _breedte; }
            set 
            {
                if (value < 0)
                {
                    throw new NumeriekeWaardeOnderNulException("_breedte");
                }
                _breedte = value; 
            }
        }
        public double Hoogte
        {
            get { return _hoogte; }
            set 
            {
                if (value < 0)
                {
                    throw new NumeriekeWaardeOnderNulException("_hoogte");
                }
                _hoogte = value; 
            }
        }

        public Knuffel(string naam, double prijs, double lengte, double breedte, double hoogte) : base(naam, prijs)
        {
            this.Lengte = lengte;
            this.Breedte = breedte;
            this.Hoogte = hoogte;
        }

        public string ToonGegevens()
        {
            return $"{base.ToonGegevens()}\n" +
                   $"Lengte: {this.Lengte}\n" +
                   $"Breedte: {this.Breedte}\n" +
                   $"Hoogte: {this.Hoogte}\n";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Knuffel knuffel)
            {
                return knuffel.GetHashCode() == this.GetHashCode();
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Naam, this.Prijs, this.Lengte, this.Breedte, this.Hoogte);
        }
    }
}
