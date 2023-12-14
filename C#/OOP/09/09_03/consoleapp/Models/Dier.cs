using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Dier
    {
        private string _naam;
        private string _diersoort;
        private DateTime _laatstGevoerd;
        private bool _isGevaarlijk;

        public string Naam
        {
            get { return _naam; }
            set { _naam = value; }
        }
        public string Diersoort
        {
            get { return _diersoort; }
            set { _diersoort = value; }
        }
        public DateTime LaatstGevoerd
        {
            get { return _laatstGevoerd; }
            set { _laatstGevoerd = value; }
        }
        public bool IsGevaarlijk
        {
            get { return _isGevaarlijk; }
            set { _isGevaarlijk = value; }
        }

        public Dier(string naam, string diersoort, bool isGevaarlijk)
        {
            this.Naam = naam;
            this.Diersoort = diersoort;
            this.IsGevaarlijk = isGevaarlijk;
        }

        public override string ToString()
        {
            return $"{this.Naam} ({this.Diersoort})";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Dier dier)
            {
                return dier.Naam == this.Naam && dier.Diersoort == this.Diersoort;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Naam, this.Diersoort);
        }

        public void Eten(DateTime moment)
        {
            this.LaatstGevoerd = moment;
        }
    }
}
