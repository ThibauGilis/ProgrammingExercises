using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Pokemon
{
    public class Pokemon
    {
        private string _name;
        private string _description;
        private PokemonStats _stats;
        private Moves[] _moves;
        private List<Moves> _possibleMoves;

        public string Name { get { return _name; } set { _name = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public PokemonStats Stats { get { return _stats; } set { _stats = value; } }
        public Moves[] Moves { get { return _moves; } set { _moves = value; } }
        public List<Moves> PossibleMoves { get { return _possibleMoves; } set { _possibleMoves = value; } }

        public Pokemon(string name, string description, int level, PokemonStats stats/*, Moves[] moves*/, List<Moves> possibleMoves)
        {
            this.Name = name;
            this.Description = description;
            this.Stats = stats;
            /*this.Moves = moves;*/
            this.PossibleMoves = possibleMoves;
        }
    }
}
