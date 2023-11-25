using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Audioboek: Boek
    {
        private string _verteller;
        private double _speelminuten;
        private double _speelminutenPerDag;

        public string Verteller
        {
            get { return _verteller; }
            set { _verteller = value; }
        }
        public double Speelminuten
        {
            get { return _speelminuten; }
            set { _speelminuten = value; }
        }
        public double SpeelminutenPerDag
        {
            get { return _speelminutenPerDag; }
            set { _speelminutenPerDag = value; }
        }

        public Audioboek(string titel, string auteur, string verteller, double speelminuten, double speelminutenPerDag) : base(titel, auteur)
        {
            this.Verteller = verteller;
            this.Speelminuten = speelminuten;
            this.SpeelminutenPerDag = speelminutenPerDag;
        }

        public override string ToonGegevens()
        {
            return base.ToonGegevens() + $", verteld door {this.Verteller} zou {Math.Ceiling(this.Speelminuten / this.SpeelminutenPerDag)} dagen duren om uit te lezen.";
        }
    }
}
