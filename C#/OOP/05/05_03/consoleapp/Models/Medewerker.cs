using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Medewerker: Winkel
    {
        public Medewerker(string voornaam, string familienaam, double uurloon) : base(voornaam, familienaam, uurloon)
        {

        }
    }
}
