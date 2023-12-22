using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class KlantNietGevondenException : Exception
    {
        public KlantNietGevondenException(int klantnummer) : base($"Klant met nummer {klantnummer} bestaat niet.")
        {
            
        }
    }
}
