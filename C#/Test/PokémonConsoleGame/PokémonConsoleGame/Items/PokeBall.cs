using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokémonConsoleGame.Items
{
    public class PokeBall: Item
    {
        readonly int CatchRate;

        public PokeBall(string name, string description, string[] icon, string rarity, int amount, int price, int catchRate) : base(name, description, icon, rarity, amount, price)
        {
            this.CatchRate = catchRate;
        }
    }
}
