using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Vliegtuig
    {
        private string _code;
        private string _type;
        private int _zitplaatsen;

        public string Code { get { return _code; } set { _code = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public int Zitplaatsen { get {  return _zitplaatsen; } set { _zitplaatsen = value; } }

        public Vliegtuig(string id, string name, int zitplaatsen) 
        { 
            this.Code = id;
            this.Type = name;
            this.Zitplaatsen = zitplaatsen;
        }

        public override string ToString()
        {
            return $"Vliegtuig: {this.Code} ({this.Type}) met {this.Zitplaatsen} zitplaatsen";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Vliegtuig vliegtuig)
            {
                return vliegtuig.GetHashCode == this.GetHashCode;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Code, this.Type);
        }
    }
}
