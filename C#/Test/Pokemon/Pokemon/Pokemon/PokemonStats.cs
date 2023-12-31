using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Pokemon
{
    public class PokemonStats
    {
        private string _type;
        private int _health;
        private int _attack;
        private int _defense;
        private int _speed;

        public string Type { get { return _type; } set { _type = value; } }
        public int Health { get { return _health; } set { _health = value; } }
        public int Attack { get { return _attack; } set { _attack = value; } }
        public int Defense { get { return _defense; } set { _defense = value; } }
        public int Speed { get { return _speed; } set { _speed = value; } }

        public PokemonStats(string type, int health, int attack, int defense, int speed) 
        {
            this.Type = type;
            this.Health = health;
            this.Attack = attack;
            this.Defense = defense;
            this.Speed = speed;
        }
    }
}
