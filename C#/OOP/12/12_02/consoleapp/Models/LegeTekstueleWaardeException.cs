using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class LegeTekstueleWaardeException: Exception
    {
        public LegeTekstueleWaardeException(string attribuut) : base($"{attribuut} mag geen lege waarde bevatten!")
        {

        }
    }
}
