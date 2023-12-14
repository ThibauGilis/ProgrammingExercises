using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Auto
    {
        private string _chassisnummer;
        private string _merk;
        private Motor _motor;

        public string Chassisnummer
        {
            get { return _chassisnummer; }
            set { _chassisnummer = value; }
        }
        public string Merk
        {
            get { return _merk; }
            set { _merk = value; }
        }
        public Motor Motor
        {
            get { return _motor; }
            set { _motor = value; }
        }

        public Auto(string chassisnummer, string merk, Motor motor)
        {
            this.Chassisnummer = chassisnummer;
            this.Merk = merk;
            this.Motor = motor;
        }

        public override string ToString()
        {
            return $"De {this.Merk} met chassisnummer {this.Chassisnummer} heeft volgende kenmerken:\n{this.Motor}";
        }
        public override bool Equals(object? obj)
        {
            if (!(obj is Auto auto))
            {
                return false;
            }

            return this.Chassisnummer == auto.Chassisnummer;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Chassisnummer);
        }
    }
}
