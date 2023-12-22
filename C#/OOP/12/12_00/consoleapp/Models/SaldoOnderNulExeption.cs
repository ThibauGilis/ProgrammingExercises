using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class SaldoOnderNulExeption : Exception
    {
        public SaldoOnderNulExeption(): base("Saldo mag niet onder 0")
        {

        }
        public SaldoOnderNulExeption(string message) : base(message)
        {

        }
        public SaldoOnderNulExeption(double saldo, double min) : base($"Je saldo {saldo} mag niet onder {min}.")
        {

        }
    }
}
