using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Student
    {
        private int _id;
        private string _naam;
        private string _voornaam;
        private int _puntWiskunde;
        private int _puntNederlands;

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
        public string Voornaam
        {
            get { return _voornaam; }
            set { _voornaam = value; }
        }
        public int PuntWiskunde
        {
            get { return _puntWiskunde; }
            set { _puntWiskunde = value; }
        }
        public int PuntNederlands
        {
            get { return _puntNederlands; }
            set { _puntNederlands = value; }
        }

        public Student(int id, string naam, string voornaam, int puntWiskunde, int puntNederlands)
        {
            this.Id = id;
            this.Naam = naam;
            this.Voornaam = voornaam;
            this.PuntWiskunde = puntWiskunde;
            this.PuntNederlands = puntNederlands;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Student student)
            {
                return this.Id == student.Id && this.Naam == student.Naam; 
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id, this.Naam);
        }
        public override string ToString()
        {
            return $"{this.Voornaam} {this.Naam} - Punt wiskunde: {this.PuntWiskunde} - Punt nederlands: {this.PuntNederlands}";
        }
    }
}
