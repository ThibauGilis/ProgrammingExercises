using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    internal class Koffie: Zoetigheid
    {
        private string _smaak;
        private bool _metSlagroom;

        public string Smaak
        {
            get { return _smaak; }
            set { _smaak = value; }
        }
        public bool MetSlagroom
        {
            get { return _metSlagroom; }
            set { _metSlagroom = value; }
        }

        public Koffie(string siroop, string topping, string smaak, bool metSlagroom) : base(siroop, topping)
        {
            this.Smaak = smaak;
            this.MetSlagroom = metSlagroom;
        }

        public override double BerekenPrijs()
        {
            double euro = 3.5;

            if (this.MetSlagroom == true)
            {
                euro += 0.5;
            }

            return (base.BerekenPrijs() + euro);
        }
        public override string ToonOverzicht()
        {
            return $"Type: {this.GetType().Name}\n{base.ToonOverzicht()}\nSmaak: {this.Smaak}\nMetSlagroom: {this.MetSlagroom}\nPrijs: {this}";
        }
        public override string ToString()
        {
            return this.BerekenPrijs().ToString("0.00") + " euro";
        }
    }
}