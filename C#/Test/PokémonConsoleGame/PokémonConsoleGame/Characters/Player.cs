using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
