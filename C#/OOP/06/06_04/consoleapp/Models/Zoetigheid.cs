using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Zoetigheid
    {
        private string _siroop;
        private string _topping;

        public string Siroop
        {
            get { return _siroop; }
            set { _siroop = value; }
        }
        public string Topping 
        { 
            get { return _topping; } 
            set { _topping = value; } 
        }

        protected Zoetigheid(string siroop, string topping)
        {
            this.Siroop = siroop;
            this.Topping = topping;
        }

        public virtual double BerekenPrijs()
        {
            double euro = 0;

            if (this.Siroop != "Geen")
            {
                euro += 1;
            }
            if (this.Topping != "Geen")
            {
                euro += 1.5;
            }

            return euro;
        }
        public virtual string ToonOverzicht()
        {
            return $"Topping: {this.Topping}\nSiroop: {this.Siroop}";
        }
    }
}
