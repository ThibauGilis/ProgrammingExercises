using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Donut: Zoetigheid
    {
        private string _glazuur;
        private string _vulling;

        public string Glazuur
        {
            get { return _glazuur; }
            set { _glazuur = value; }
        }
        public string Vulling
        { 
            get { return _vulling; } 
            set { _vulling = value; }
        }

        public Donut(string siroop, string topping, string glazuur, string vulling): base(siroop, topping)
        {
            this.Glazuur = glazuur;
            this.Vulling = vulling;
        }

        public override double BerekenPrijs()
        {
            double euro = 2;

            if (this.Glazuur != "Geen") 
            {
                euro += 0.5;
            }
            if (this.Vulling != "Geen")
            {
                euro += 0.5;
            }

            return base.BerekenPrijs() + euro;
        }
        public override string ToonOverzicht()
        {
            return $"Type: {this.GetType().Name}\n{base.ToonOverzicht()}\nGlazuur: {this.Glazuur}\nVulling: {this.Vulling}\nPrijs: {this}";
        }
        public override string ToString()
        {
            return this.BerekenPrijs().ToString("0.00") + " euro";
        }
    }
}
