using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Paperback: Boek
    {
        private double _bladzijden;
        private double _bladzijdenPerDag;

        public double Bladzijden
        {
            get { return _bladzijden; }
            set { _bladzijden = value; }
        }
        public double BladzijdenPerDag
        {
            get { return _bladzijdenPerDag; }
            set { _bladzijdenPerDag = value; }
        }

        public Paperback(string titel, string auteur, int bladzijden, int bladzijdenPerDag): base(titel, auteur)
        {
            this.Bladzijden = bladzijden;
            this.BladzijdenPerDag = bladzijdenPerDag;
        }

        public override string ToonGegevens()
        {
            return base.ToonGegevens() + $" zou {Math.Ceiling(this.Bladzijden / BladzijdenPerDag)} dagen duren om uit te lezen.";
        }
    }
}
