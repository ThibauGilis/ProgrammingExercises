using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Klas
    {
        private int _id;
        private string _naam;
        private List<Student> _studenten;

        public int Id 
        { 
            get { return _id; } 
            set { _id = value; } 
        }
        public string Naam
        {
            get { return _naam; }
            set { _naam = value; }
        }
        public List<Student> Studenten
        {
            get { return _studenten; }
            set { _studenten = value; }
        }

        public Klas(int id, string naam, List<Student> students)
        {
            this.Id = id;
            this.Naam = naam;
            this.Studenten = students;
        }

        public double BerekenGemiddeldeWiskunde()
        {
            double som = 0;
            foreach (Student student in this.Studenten)
            {
                som += student.PuntWiskunde;
            }
            return som/this.Studenten.Count;
        }
        public double BerekenGemiddeldeNederlands()
        {
            double som = 0;
            foreach (Student student in this.Studenten)
            {
                som += student.PuntNederlands;
            }
            return som/this.Studenten.Count;
        }
        public override string ToString()
        {
            string tekst = $"Klas {this.Id} - {this.Naam}";
            
            foreach(Student student in this.Studenten)
            {
                tekst += $"\n{student.Id} - {student}";
            }

            return tekst;
        }
    }
}
