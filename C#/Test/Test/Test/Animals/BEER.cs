using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Animals;

namespace Test.Animals
{
    public class BEER : DouButsu
    {
        private int _winterSlaap;

        public int WinterSlaap
        {
            get { return _winterSlaap; } 
            set { _winterSlaap = value; }
        }

        public BEER(string naam, int gewicht, int hongerNiveau, int winterSlaap) : base(naam, gewicht, hongerNiveau)
        {
            this.WinterSlaap = winterSlaap;
        }

        public override string Gegevens()
        {
            return $"DE {this.GetType().Name} weegt {this.Gewicht}, heeft {this.HongerNiveau}/10 honger en slaapt voor {this.WinterSlaap} dagen tijdens de winter.";
        }
    }
}
