using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
        private Tuple<Move, int>[] _moves;
        private List<Tuple<Move,int>> _unlockableMoves;
        //TODO ADD CATCH RATE
        // TODO ADD SPAWN RATE

        public string Name { get { return _name; } set { _name = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public string Evolution { get { return _evolution; } set { _evolution = value; } }
        public Tuple<Move, int>[] Moves { get { return _moves; } set { _moves = value; } }
        public List<Tuple<Move, int>> UnlockableMoves { get { return _unlockableMoves; } set { _unlockableMoves = value; } }

        public readonly string[] ImageSmall;
        public readonly string[] ImageSmallWhosThatPokemon;
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
            this.XPLevelUp = (int)(10*Math.Pow(1.2, this.Level-1));
            this.Health = health + (level-1)*2;  // example level 1 = 10
            this.Attack = attack + (level-1);
            this.Defense = defense + (level-1);
            this.Speed = speed;
            this.Accuracy = 100;
            this.UnlockableMoves = unlockableMoves;
            InitializeStartingMoves(unlockableMoves);
            this.ImageSmall = FileOperations.LoadPokemonAsciiArt(name, "Small");
            this.ImageSmallWhosThatPokemon = FileOperations.CreatePokemonSilhouette(ImageSmall);
            this.ImageLarge = FileOperations.LoadPokemonAsciiArt(name, "Large");
        }

        public Pokemon(string name, string description, string evolution, List<Tuple<Move, int>> unlockableMoves, Tuple<Move, int>[] moves,
                       string type, int xp, int xpLevelUp, int level, int health, int attack, int defense, int accuracy, int speed,
                       string[] imageSmall, string[] imageSmallWhosThatPokemon, string[] imageLarge)
        {
            this.Name = name;
            this.Description = description;
            this.Evolution = evolution;
            this.Type = type;
            this.Level = level;
            this.XP = xp;
            this.XPLevelUp = xpLevelUp;
            this.Health = health + (level - 1)*2;
            this.Attack = attack + (level - 1);
            this.Defense = defense + (level - 1);
            this.Speed = speed;
            this.Accuracy = accuracy;
            this.UnlockableMoves = unlockableMoves;
            this.Moves = moves;
            this.ImageSmall = imageSmall;
            this.ImageSmallWhosThatPokemon = imageSmallWhosThatPokemon;
            this.ImageLarge = imageLarge;
        }



        private void InitializeStartingMoves(List<Tuple<Move, int>> unlockableMoves)
        {
            Random rnd = new Random();
            Tuple<Move, int>[] moves = new Tuple<Move, int>[4];

            int amountMoves = 0;
            int Index = -1;
            foreach (Tuple<Move, int> move in unlockableMoves)
            {
                if (Level >= move.Item2)
                {
                    for (int i = 0; i < moves.Length; i++)
                    {
                        Index++;
                        if (Index == 4)
                        {
                            Index = 0;
                        }

                        if (rnd.Next(0, 2) == 1 || amountMoves < 4)
                        {
                            amountMoves++;
                            moves[Index] = new Tuple<Move, int>(move.Item1, move.Item1.PowerPoints);
                            break;
                        }
                    }
                }
            }

            Moves = moves;
        }

        public override string ToString()
        {
            string Info = "";
            foreach (string line in ImageSmall)
            {
                Info += line.Replace('R', ' ');
            }

            Info += $"Name: {Name}\n" +
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

        public Pokemon CreateDuplicatePokemon()
        {
            return new Pokemon(this.Name, this.Description, this.Evolution, this.UnlockableMoves, this.Moves,
                               this.Type, this.XP, this.XPLevelUp, this.Level, this.Health, this.Attack, this.Defense, this.Accuracy, this.Speed,
                               this.ImageSmall, this.ImageSmallWhosThatPokemon, this.ImageLarge);
        }

        public void ResetPokemonStats()
        {
            foreach (Pokemon pokemon in Save.AllPokemon)
            {
                if (pokemon.Name == this.Name)
                {
                    this.Health = pokemon.Health + (this.Level - 1) * 2;
                    this.Attack = pokemon.Attack + (this.Level - 1);
                    this.Defense = pokemon.Defense + (this.Level - 1);
                    this.Speed = pokemon.Speed + (this.Level -1);
                    this.Accuracy = pokemon.Accuracy;

                    for (int i = 0; i < 4; i++)
                    {
                        if (this.Moves[i] == null) break;

                        this.Moves[i] = new Tuple<Move, int>(this.Moves[i].Item1, this.Moves[i].Item1.PowerPoints);
                    }

                    break;
                }
            }
        }

        public void LevelUp()
        {
            while (this.XP >= this.XPLevelUp)
            {
                this.XP = this.XP - this.XPLevelUp;
                this.XPLevelUp = (int)(this.XPLevelUp * 1.2);
                this.Level++;
                this.Health += 2;
                this.Defense++;
                this.Attack++;
                // TODO check for new moves
                // TODO check for evolution
            }
        }

    }
}
