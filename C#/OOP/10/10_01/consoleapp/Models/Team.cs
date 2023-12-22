using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Team
    {
        private Trainer _trainer;
        private List<Voetbalspeler> _spelers;

        public Trainer Trainer 
        { 
            get { return _trainer; } 
            set { _trainer = value; }
        }
        public List<Voetbalspeler> Spelers
        {
            get { return _spelers; }
            set { _spelers = value; }
        }

        public int AantalSpelers
        {
            get {  return this.Spelers.Count; }
        }
        public int AantalVerdedigers
        {
            get { return GetAantalOpPositie("Verdediger"); }
        }
        public int AantalMiddenvelders
        {
            get { return GetAantalOpPositie("Middenvelder"); }
        }
        public int AantalAanvallers
        {
            get { return GetAantalOpPositie("Aanvaller"); }
        }
        public int AantalKeeppers
        {
            get { return GetAantalOpPositie("Keeper"); }
        }

        public Team(Trainer trainer, List<Voetbalspeler> voetbalspelers)
        {
            this.Trainer = trainer;
            this.Spelers = voetbalspelers;
        }

        public void VoegSpelerToe(Voetbalspeler speler)
        {
            if (!Spelers.Contains(speler))
            {
                this.Spelers.Add(speler);
            }
        }

        public override string ToString()
        {
            return $"Trainer: {this.Trainer}\n" +
                   $"Aantal spelers: {this.AantalSpelers}\n" +
                   $"Aantal verdedigers: {this.AantalVerdedigers}\n" +
                   $"Aantal aanvallers: {this.AantalAanvallers}\n" +
                   $"Aantal middenvelders: {this.AantalMiddenvelders}\n" +
                   $"Aantal keepers: {this.AantalKeeppers}";
        }
        private int GetAantalOpPositie(string positie)
        {
            return this.Spelers.FindAll(speler => speler.Positie == positie).Count;

/*            int aantal = 0;
            foreach (Voetbalspeler speler in this.Spelers)
            {
                if (speler.Positie == positie)
                {
                    aantal++;
                }
            }
            return aantal;*/
        }
    }
}
