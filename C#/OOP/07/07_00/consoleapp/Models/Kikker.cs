using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Kikker : Dier
    {
        public override bool IsZoogdier 
        { 
            get { return false; }
        }

        public override string MaakGeluid()
        {
            return "KWAKKWAK";
        }

        public override string Voeren()
        {
            return "KWAAAAAAAAAAAK";
        }
    }
}
