using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class NumeriekeWaardeOnderNulException: Exception
    {
        public NumeriekeWaardeOnderNulException(string attribuut) : base($"{attribuut} mag geen waarde onder nul bevatten!")
        {

        }
    }
}
