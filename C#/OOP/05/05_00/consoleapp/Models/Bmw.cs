using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Bmw: Auto
    {
        public Bmw(string nummerplaat, double aantalKilometers, double kostPrijs, double literBrandstof) : base(nummerplaat, aantalKilometers, kostPrijs, literBrandstof)
        {

        }

        public override void Rijden(double aantalKilometer)
        {
            base.Rijden(aantalKilometer);
        }
    }
}
