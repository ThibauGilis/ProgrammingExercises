using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace PokémonConsoleGame.Pokémon
{
    public class Move
    {

        // Move ---------
        private string _name;
        private string _description;

        public string Name { get { return _name; } set { _name = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        // --------------

        // Move Stats ---
        private string _type;
        private int _powerPoints;
        private string _effect;
        private string _pokemonLocation;
        private string _moveLocation;
        private int _priority;
        private int _healthRecovery;
        private int _attackDamage;
        private int _accuracy;

        private int _attackIncrease;
        private int _accuracyIncrease;
        private int _defenseIncrease;
        private int _speedIncrease;

        private int _attackDecrease;
        private int _accuracyDecrease;
        private int _defenseDecrease;
        private int _speedDecrease;

        public string Type { get { return _type; } set { _type = value; } }
        public int PowerPoints { get { return _powerPoints; } set { _powerPoints = value; } }
        public string Effect { get { return _effect; } set { _effect = value; } }
        public string PokemonLocation { get { return _pokemonLocation; } set { _pokemonLocation = value; } }
        public string MoveLocation { get { return _moveLocation; } set { _moveLocation = value; } }
        public int Priority { get { return _priority; } set { _priority = value; } }
        public int HealthRecovery { get { return _healthRecovery; } set { _healthRecovery = value; } }
        public int AttackDamage { get { return _attackDamage; } set { _attackDamage = value; } }
        public int Accuracy { get { return _accuracy; } set { _accuracy = value; } }

        public int AttackIncrease { get { return _attackIncrease; } set { _attackIncrease = value; } }
        public int AccuracyIncrease { get { return _accuracyIncrease; } set { _accuracyIncrease = value; } }
        public int DefenseIncrease { get { return _defenseIncrease; } set { _defenseIncrease = value; } }
        public int SpeedIncrease { get { return _speedIncrease; } set { _speedIncrease = value; } }

        public int AttackDecrease { get { return _attackDecrease; } set { _attackDecrease = value; } }
        public int AccuracyDecrease { get { return _accuracyDecrease; } set { _accuracyDecrease = value; } }
        public int DefenseDecrease { get { return _defenseDecrease; } set { _defenseDecrease = value; } }
        public int SpeedDecrease { get { return _speedDecrease; } set { _speedDecrease = value; } }
        // --------------


        public Move(    string Name, string Description, string Type, int PowerPoints, string Effect,
            string PokemonLocation, string MoveLocation,
            int Priority, int HealthRecovery, int AttackDamage, int Accuracy,
            int AttackIncrease, int AccuracyIncrease, int DefenseIncrease, int SpeedIncrease,
            int AttackDecrease, int AccuracyDecrease, int DefenseDecrease, int SpeedDecrease    ) 
        {
            this.Name = Name;
            this.Description = Description;

            this.Type = Type;
            this.PowerPoints = PowerPoints;
            this.Effect = Effect;
            this.PokemonLocation = PokemonLocation;
            this.MoveLocation = MoveLocation;
            this.Priority = Priority;
            this.HealthRecovery = HealthRecovery;
            this.AttackDamage = AttackDamage;
            this.Accuracy = Accuracy;

            this.AttackIncrease = AttackIncrease;
            this.AccuracyIncrease = AccuracyIncrease;
            this.DefenseIncrease = DefenseIncrease;
            this.SpeedIncrease = SpeedIncrease;

            this.AttackDecrease = AttackDecrease;
            this.AccuracyDecrease = AccuracyDecrease;
            this.DefenseDecrease = DefenseDecrease;
            this.SpeedDecrease = SpeedDecrease;
        }

        public override string ToString()
        {
            return $"{Name}:    {Type} type    {PowerPoints} PP\n" +
                   $"Effect: {Effect}   Hits {MoveLocation} Enemies";
        }
    }
}
