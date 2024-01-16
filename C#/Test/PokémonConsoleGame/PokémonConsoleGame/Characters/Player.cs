using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokémonConsoleGame.Items;

namespace PokémonConsoleGame.Characters
{
    public class Player: Trainer
    {
        private List<Pokemon> _pokemonStored;
        private List<Item> _items;

        public List<Item> Items {  get { return _items; } set { _items = value; } }
        public List<Pokemon> PokemonStored { get { return _pokemonStored; } set { _pokemonStored = value; } }

        public Player(string name, int level, Pokemon[] pokemonTeam, List<Pokemon> pokemonStored, List<Item> items) : base(name, level, pokemonTeam)
        {
            this.PokemonStored = pokemonStored;
            this.Items = items;
        }

        public string ShowStatsinWorld()
        {
            string Info = $"Trainer: {Name}\n" +
                          $"Level: {Level}\n\n" +
                          $"PokemonTeam:────┐";
            foreach(Pokemon pokemon in PokemonTeam) 
            {
                string name = " " + (pokemon == null ? "" : pokemon.Name);
                Info += $"\n│{name}{new string(' ',15-name.Length)}│";
            }
            Info += "\n└───────────────┘";

            return Info;
        }

        public string[] ShowBag()
        {
            string[] Bag = new string[Save.PlayerBag.Length];
            Array.Copy(Save.PlayerBag, Bag, Save.PlayerBag.Length);

            int x = 8; int y = 4;
            foreach (Pokemon pokemon in this.PokemonTeam)
            {
                if (pokemon == null) break;

                Bag[y] = Bag[y].Remove(x, $"{pokemon.Name} {pokemon.Health}/{pokemon.MaxHealth}".Length);
                Bag[y] = Bag[y].Insert(x, $"{pokemon.Name} {pokemon.Health}/{pokemon.MaxHealth}");
                y += 2;
            }


            x = 48; y = 3;
            foreach (Item item in this.Items)
            {
                Bag[y] = Bag[y].Remove(x, $"{item.Name} {item.Amount}x".Length);
                Bag[y] = Bag[y].Insert(x, $"{item.Name} {item.Amount}x");
                y += 2;
            }

            return Bag;
        }
    }
}
