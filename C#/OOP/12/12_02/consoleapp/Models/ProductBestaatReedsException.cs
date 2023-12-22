using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class ProductBestaatReedsException: Exception
    {
        public ProductBestaatReedsException() : base("Product bestaat reeds!")
        {

        }
    }
}
