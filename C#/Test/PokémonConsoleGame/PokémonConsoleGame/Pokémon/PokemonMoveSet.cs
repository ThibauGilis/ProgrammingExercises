using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PokémonConsoleGame.Pokémon
{
    public class PokemonMoveSet
    {
        private string _pokemonName;
        private string _moveName;
        private int _levelUnlock;

        public string Name {  get { return _pokemonName; } set { _pokemonName = value; } }
        public string Move { get { return _moveName; } set { _moveName = value; } }
        public int LevelUnlock { get { return _levelUnlock; } set { _levelUnlock = value; } }

        public PokemonMoveSet(string Name, string Move, int LevelUnlock) 
        {
            this.Name = Name;
            this.Move = Move;
            this.LevelUnlock = LevelUnlock;
        }
    }
}
