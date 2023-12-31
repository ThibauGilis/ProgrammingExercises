using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Animals;

namespace Test.Animals
{
    public class DouButsu
    {
        private int _gewicht;
        private int _hongerNiveau;
        private string _name;

        public int Gewicht
        {
            get { return _gewicht; }
            set { _gewicht = value; }
        }
        public int HongerNiveau
        {
            get { return _hongerNiveau; }
            set { _hongerNiveau = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public DouButsu(string naam, int gewicht, int hongerNiveau) 
        {
            this.Name = naam;
            this.Gewicht = gewicht;
            this.HongerNiveau = hongerNiveau;
        }

        public virtual string Gegevens()
        {
            return "";
        }
    }
}
