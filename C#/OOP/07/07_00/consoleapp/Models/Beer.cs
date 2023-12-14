using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Beer : Dier
    {
        public override bool IsZoogdier
        {
            get { return true; }
        }

        public override string MaakGeluid()
        {
            return "blubblub";
        }

        public override string Voeren()
        {
            return "GROM!";
        }
    }
}
