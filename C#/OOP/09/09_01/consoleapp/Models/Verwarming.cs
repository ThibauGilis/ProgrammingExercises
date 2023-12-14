using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Verwarming
    {
        private double _graden;
        private bool _aanUit;

        public double Graden
        {
            get { return _graden; }
            set { _graden = value; }
        }
        public bool AanUit
        {
            get { return _aanUit; }
            set { _aanUit = value; }
        }

        public Verwarming()
        {
            this.Graden = 0;
            this.AanUit = false;
        }
    }
}
