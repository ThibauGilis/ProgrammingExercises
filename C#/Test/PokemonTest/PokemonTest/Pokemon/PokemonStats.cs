using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Pokemon
{
    public class PokemonStats
    {
        private string _type1;
        private string _type2;
        private int _level;
        private int _health;
        private int _attack;
        private int _defense;
        private int _speed;

        public string Type1 { get { return _type1; } set { _type1 = value; } }
        public string Type2 { get { return _type2; } set { _type2 = value; } }
        public int Level { get { return _level; } set { _level = value; } }
        public int Health { get { return _health; } set { _health = value; } }
        public int Attack { get { return _attack; } set { _attack = value; } }
        public int Defense { get { return _defense; } set { _defense = value; } }
        public int Speed { get { return _speed; } set { _speed = value; } }

        public PokemonStats(string type1, string type2, int level, int health, int attack, int defense, int speed) 
        {
            this.Type1 = type1;
            this.Type2 = type2;
            this.Level = level;
            this.Health = health;
            this.Attack = attack;
            this.Defense = defense;
            this.Speed = speed;
        }
    }
}
