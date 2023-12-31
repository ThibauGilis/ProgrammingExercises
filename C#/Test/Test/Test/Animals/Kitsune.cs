using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Animals;

namespace Test.Animals
{
    public class Kitsune : DouButsu
    {
        private string _kleur;

        public string Kleur
        {
            get { return _kleur; }
            set { _kleur = value; }
        }

        public Kitsune(string naam, int gewicht, int hongerNiveau, string kleur) : base(naam, gewicht, hongerNiveau)
        {
            this.Kleur = kleur;
        }

        public override string Gegevens()
        {
            return $"DE {this.Kleur} {this.GetType().Name} weegt {this.Gewicht} en heeft {this.HongerNiveau}/10 honger.";
        }
    }
}
