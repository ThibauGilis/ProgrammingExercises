﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Volkswagen: Auto
    {
        public Volkswagen(string nummerplaat, double aantalKilometers, double kostPrijs, double literBrandstof): base(nummerplaat, aantalKilometers, kostPrijs, literBrandstof)
        {

        }

        public override void Rijden(double aantalKilometer)
        {
            this.AantalKilometers += aantalKilometer;
            this.LiterBrandstof -= aantalKilometer / 25;
        }
    }
}
