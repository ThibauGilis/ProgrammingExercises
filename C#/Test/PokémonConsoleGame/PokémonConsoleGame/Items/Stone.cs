using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokémonConsoleGame.Items
{
    public class Stone: Item
    {
        readonly string EffectsType;

        public Stone(string name, string description, string[] icon, string rarity, int amount, int price, string effectsType) : base(name, description, icon, rarity, amount, price)
        {
            this.EffectsType = effectsType;
        }
    }
}
