using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Pokemon
{
    public class MoveStats
    {
        private string _type;
        private string _effect;
        private int _healthRecovery;
        private int _attackDamage;
        private int _attackIncrease;
        private int _defenseIncrease;
        private int _speedIncrease;

        public string Type { get { return _type; } set { _type = value; } }
        public string Effect { get { return _effect; } set { _effect = value; } }
        public int HealthRecovery { get { return _healthRecovery; } set { _healthRecovery = value; } }
        public int AttackDamage { get { return _attackDamage; } set { _attackDamage = value; } }
        public int AttackIncrease { get { return _attackIncrease; } set { _attackIncrease = value; } }
        public int DefenseIncrease { get { return _defenseIncrease; } set { _defenseIncrease = value; } }
        public int SpeedIncrease { get { return _speedIncrease; } set { _speedIncrease = value; } }

        public MoveStats(string type, string effect, int healthRecovery, int attackDamage, int attackIncrease, int DamageIncrease, int defenseIncrease, int speedIncrease) 
        {
            this.Type = type;
            this.Effect = effect;
            this.HealthRecovery = healthRecovery;
            this.AttackDamage = attackDamage;
            this.AttackIncrease = attackIncrease;
            this.DefenseIncrease = defenseIncrease;
            this.SpeedIncrease = speedIncrease;
        }
    }
}
