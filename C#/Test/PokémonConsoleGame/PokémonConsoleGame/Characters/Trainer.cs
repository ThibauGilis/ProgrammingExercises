using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokémonConsoleGame.Characters
{
    public class Trainer
    {
        private string _name;
        private int _level;
        private Pokemon[] _pokemonTeam;

        public string Name {  get { return _name; } set { _name = value; } }
        public int Level { get { return _level; } set { _level = value; } }
        public Pokemon[] PokemonTeam { get { return  _pokemonTeam; } set {  _pokemonTeam = value; } }

        // MOVE THIS SHIT TO WORLD YA FUCKING DUMBASS

/*        public Trainer(string name, string[] teamPokemon, int[] pokemonLevels, List<Pokemon> AllPokemon ) 
        {
            this.Name = name;
            this.PokemonTeam = new Pokemon[Math.Min(teamPokemon.Length, 6)]; //max 6
            for (int i = 0; i < teamPokemon.Length; i++) 
            {
                foreach (Pokemon p in AllPokemon)
                {
                    if (p.Name == teamPokemon[i])
                    {
                        Pokemon newPokemon = new Pokemon(   p.Name, p.Description, p.Evolution, p.UnlockableMoves, p.Type, pokemonLevels[i],
                                                            p.Health-((p.Level-1)*2), p.Attack-(p.Level-1), p.Defense-(p.Level-1), p.Speed   );
                        PokemonTeam[i] = newPokemon;
                    }
                }
            }
            this.Level = (int)pokemonLevels.Average(); // double casting to int
        }*/

        public Trainer(string name, int level, Pokemon[] pokemonTeam) 
        {
            this.Name= name;
            this.Level = level;
            this.PokemonTeam = pokemonTeam;
        }

    }
}
