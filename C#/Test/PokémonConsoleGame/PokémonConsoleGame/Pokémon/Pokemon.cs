using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokémonConsoleGame.Pokémon
{
    public class Pokemon
    {

        // Pokemon ------------
        private string _name;
        private string _description;
        private string _evolution;
        private Move[] _moves;
        private List<Tuple<Move,int>> _unlockableMoves;
        //TODO ADD CATCH RATE
        // TODO ADD SPAWN RATE

        public string Name { get { return _name; } set { _name = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public string Evolution { get { return _evolution; } set { _evolution = value; } }
        public Move[] Moves { get { return _moves; } set { _moves = value; } }
        public List<Tuple<Move, int>> UnlockableMoves { get { return _unlockableMoves; } set { _unlockableMoves = value; } }

        public readonly string[] ImageSmall;
        public readonly string[] ImageLarge;
        //---------------------

        // Pokemon Stats ------
        private string _type;
        private int _level;
        private int _xp;
        private int _xpLevelUp;
        private int _health;
        private int _attack;
        private int _defense;
        private int _speed;
        private int _accuracy;

        public string Type { get { return _type; } set { _type = value; } }
        public int Level { get { return _level; } set { _level = value; } }
        public int XP { get { return _xp; } set { _xp = value; } }
        public int XPLevelUp { get { return _xpLevelUp; } set { _xpLevelUp = value; } }
        public int Health { get { return _health; } set { if (value < 0) { _health = 0; } else _health = value; } }
        public int Attack { get { return _attack; } set { _attack = value; } }
        public int Defense { get { return _defense; } set { _defense = value; } }
        public int Speed { get { return _speed; } set { _speed = value; } }
        public int Accuracy { get { return _accuracy; } set { _accuracy = value; } }
        //---------------------

        public Pokemon( string name, string description, string evolution, List<Tuple<Move, int>> unlockableMoves, 
                        string type, int level, int health, int attack, int defense, int speed   )
        {
            this.Name = name;
            this.Description = description;
            this.Evolution = evolution;
            this.Type = type;
            this.Level = level;
            this.XP = 0;
            this.XPLevelUp = 10;
            this.Health = health + (level-1)*2;
            this.Attack = attack + (level-1);
            this.Defense = defense + (level-1);
            this.Speed = speed;
            this.Accuracy = 100;
            this.UnlockableMoves = unlockableMoves;
            InitializeStartingMoves(unlockableMoves);
            this.ImageSmall = FileOperations.LoadPokemonAsciiArt(name, "Small");
            this.ImageLarge = FileOperations.LoadPokemonAsciiArt(name, "Large");
        }

        private void InitializeStartingMoves(List<Tuple<Move, int>> unlockableMoves)
        {
            Random rnd = new Random();
            Move[] moves = new Move[4];

            int Index = 0;
            foreach (Tuple<Move, int> move in unlockableMoves)
            {
                if (Level >= move.Item2)
                {
                    for (int i = 0; i < moves.Length; i++)
                    {
                        if (rnd.Next(0, 2) == 1 || moves[Index] == null)
                        {
                            moves[Index] = move.Item1;
                            break;
                        }

                        Index++;
                        if (Index == 4)
                        {
                            Index = 0;
                        }
                    }
                }
            }

            Moves = moves;
        }

        public override string ToString()
        {
            string Info = $"{ImageSmall}\n" +
                          $"Name: {Name}\n" +
                          $"Description: {Description}\n\n" +
                          $"Base Stats:{new string('-', 49)}\n" +
                          $"Type: {Type}\t" +
                          $"Level: {Level}\n" +
                          $"Health: {Health}\t" +
                          $"Attack: {Attack}\t" +
                          $"Defense: {Defense}\t" +
                          $"Speed: {Speed}\n" +
                          $"{new string('-', 60)}\n";
            for (int i = 0; i < UnlockableMoves.Count; i++)
            {
                Info += $"{UnlockableMoves[i].Item1}\n" +
                        $"Unlocked at level {UnlockableMoves[i].Item2}\n" +
                        $"{new string('-', 60)}\n";
            }

            return Info;
        }

    }
}
