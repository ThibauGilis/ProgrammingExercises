using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public interface IVeelhoek
    {
        double Breedte { get; set; }
        double Hoogte { get; set; }

        double BerekenOppervlakte();
    
    }
}
