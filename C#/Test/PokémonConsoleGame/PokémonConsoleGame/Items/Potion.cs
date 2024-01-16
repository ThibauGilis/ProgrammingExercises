using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokémonConsoleGame.Items
{
    public class Potion: Item
    {
        readonly int HealFactor; // percentage

        public Potion(string name, string description, string[] icon, string rarity, int amount, int price, int healFactor) : base(name, description, icon, rarity, amount, price)
        {
            HealFactor = healFactor;
        }
    }
}
