using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Licht
    {
        private bool _aanUit;

        public bool AanUit
        {
            get { return _aanUit; }
            set { _aanUit = value; }
        }

        public Licht() 
        {
            this.AanUit = false;
        }
    }
}
