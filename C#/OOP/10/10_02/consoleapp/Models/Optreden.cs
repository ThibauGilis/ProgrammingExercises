using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Optreden
    {
        private Artiest _artiest;
        private string _dag;

        public Artiest Artiest
        {
            get { return _artiest; }
            set { _artiest = value; }
        }
        public string Dag
        {
            get { return _dag; }
            set { _dag = value; }
        }

        public Optreden(Artiest artiest, string dag)
        {
            this.Artiest = artiest;
            this.Dag = dag;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Optreden optreden)
            {
                /*return this.GetHashCode == optreden.GetHashCode;*/
                return this.Artiest.Naam == optreden.Artiest.Naam && this.Dag == optreden.Dag;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Artiest, this.Dag);
        }
    }
}
