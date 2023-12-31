using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Pokemon
{
    public class Moves
    {
        private string _name;
        private string _description;
        private int _levelUnlocked;
        private MoveStats _moveStats;

        public string Name { get { return _name; } set { _name = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public int LevelUnlocked { get { return _levelUnlocked; } set { _levelUnlocked = value; } }
        public MoveStats MoveStats { get { return _moveStats; } set { _moveStats = value; } }

        public Moves(string name, string description, int levelUnlocked, MoveStats moveStats) 
        {
            this.Name = name;
            this.Description = description;
            this.LevelUnlocked = levelUnlocked;
            this.MoveStats = moveStats;
        }
    }
}
