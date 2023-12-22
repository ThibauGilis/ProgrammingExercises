using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Luchthaven
    {
        private string _name;
        private List<Vliegtuig> _vliegtuigen;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public List<Vliegtuig > Vliegtuigen 
        { 
            get {  return _vliegtuigen; } 
            set { _vliegtuigen = value; }
        }

        public Luchthaven(string name, List<Vliegtuig> vliegtuigen)
        {
            this.Name = name;
            this.Vliegtuigen = vliegtuigen;
        }

        public override string ToString()
        {
            string tekst = $"Luchthaven: {this.Name} ({this.Vliegtuigen.Count} toestellen)";
            foreach (Vliegtuig vliegtuig in this.Vliegtuigen)
            {
                tekst += $"\n{vliegtuig}";
            }
            return tekst;
        }
    }
}
