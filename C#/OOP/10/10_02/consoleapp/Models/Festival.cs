using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Festival
    {
        private string _naam;
        private double _budget;

        public string Naam
        {
            get { return _naam; }
            set { _naam = value; }
        }
        public double Budget
        {
            get { return _budget; }
            set { _budget = value; }
        }
        public readonly List<Optreden> Optredens;

        public Festival(string naam, double budget)
        {
            this.Naam = naam;
            this.Budget = budget;
            this.Optredens = FileOperations.LeesOptredensPerFestival(naam);
        }

        public void VoegOptredenToe(Optreden optreden)
        {
            if (!this.Optredens.Contains(optreden))
            {
                if (BerekenTotaleKost() + optreden.Artiest.Prijs <= this.Budget)
                {
                    this.Optredens.Add(optreden);
                }
            }
        }
        public void VerwijderOptreden(Optreden optreden)
        {
            this.Optredens.Remove(optreden);
        }
        public double BerekenTotaleKost()
        {
            double totaal = 0;
            this.Optredens.ForEach(item => totaal += item.Artiest.Prijs);
            return totaal;
        }
        public string ToonOptredenVanDag(string dag)
        {
            string tekst = $"Op {dag} komen volgende artiesten:";

            foreach (Optreden optreden in this.Optredens)
            {
                if (optreden.Dag == dag)
                {
                    tekst += $"\n{optreden.Artiest}";
                }
            }

            return tekst;
        }
        public override string ToString()
        {
            return $"OVERZICHT FESTIVAL {this.Naam.ToUpper()}\n" +
                   $"----------------------------\n" +
                   $"{this.ToonOptredenVanDag("vrijdag")}\n"+
                   $"{this.ToonOptredenVanDag("zaterdag")}\n" +
                   $"{this.ToonOptredenVanDag("zondag")}\n" +
                   $"In totaal werd er {this.BerekenTotaleKost()} euro besteed aan artiesten.\n" +
                   $"Het budget bedraagt {this.Budget} euro.";
        }
    }
}
