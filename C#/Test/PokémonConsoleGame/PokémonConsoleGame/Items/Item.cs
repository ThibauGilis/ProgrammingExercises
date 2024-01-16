using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokémonConsoleGame.Items
{
    public class Item
    {
        private string _name;
        private string _description;
        private string[] _icon; //maybe
        private string _rarity; // common, rare, epic, legendary
        private int _amount;
        private int _price;

        public string Name { get { return _name; } set { _name = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public string[] Icon { get { return _icon; } set { _icon = value; } }
        public string Rarity { get { return _rarity; } set { _rarity = value; } }
        public int Amount { get { return _amount; } set { _amount = value; } }
        public int Price { get { return _price; } set { _price = value; } }

        public Item(string name, string description, string[] icon, string rarity, int amount, int price)
        {
            Name = name;
            Description = description;
            Icon = icon;
            Rarity = rarity;
            Amount = amount;
            Price = price;
        }
    }
}
