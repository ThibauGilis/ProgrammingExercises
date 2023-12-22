using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class OngeldigBtwNummerException : Exception
    {
        public OngeldigBtwNummerException() : base("Het BTW-nummer moet beginnen met BE.")
        {

        }
    }
}
