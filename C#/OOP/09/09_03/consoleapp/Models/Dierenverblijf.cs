using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Dierenverblijf
    {
        private Personeelslid _hoofdverzorger;
        private Personeelslid _hulpverzorger;
        private Dier _mannetjesdier;
        private Dier _vrouwtjesdier;

        public Personeelslid Hoofdverzorger
        {
            get { return _hoofdverzorger; }
            set { _hoofdverzorger = value; }
        }
        public Personeelslid Hulpverzorger
        {
            get { return _hulpverzorger; }
            set { _hulpverzorger = value; }
        }
        public Dier Mannetjesdier
        {
            get { return _mannetjesdier; }
            set { _mannetjesdier = value; }
        }
        public Dier Vrouwtjesdier
        {
            get { return _vrouwtjesdier; }
            set { _vrouwtjesdier = value; }
        }

        public bool MeldHoofdverzorgerAan(Personeelslid verzorger)
        {
            if (this.Mannetjesdier == null && this.Vrouwtjesdier == null)
            {
                return false;
            }

            if (verzorger.IsStagair)
            {
                if (this.Mannetjesdier.IsGevaarlijk || this.Vrouwtjesdier.IsGevaarlijk)
                {
                    return false;
                } 
            }

            this.Hoofdverzorger = verzorger;
            return true;
        }
        public bool MeldHulpverzorgerAan(Personeelslid verzorger)
        {
            if (this.Mannetjesdier == null && this.Vrouwtjesdier == null)
            {
                if (this.Hoofdverzorger == null)
                {
                    return false;
                }
            }

            this.Hulpverzorger = verzorger;
            return true;
        }
        public bool VoegMannetjeToe(Dier dier)
        {
            if (this.Vrouwtjesdier != null)
            {
                if (this.Vrouwtjesdier.Diersoort != dier.Diersoort)
                {
                    return false;
                }
            }

            this.Mannetjesdier = dier;
            return true;
        }
        public bool VoegVrouwtjeToe(Dier dier)
        {
            if (this.Mannetjesdier != null)
            {
                if (this.Mannetjesdier.Diersoort != dier.Diersoort)
                {
                    return false;
                }
            }

            this.Vrouwtjesdier = dier;
            return true;
        }
        public void DierenVoeren(DateTime moment)
        {
            this.Mannetjesdier.Eten(moment);
            this.Vrouwtjesdier.Eten(moment);
        }
        public override string ToString()
        {
            return $"Verzorgers\n==========" +
                   $"\nHoofdverzorger: {this.Hoofdverzorger}" +
                   $"\nHulpverzorger: {this.Hulpverzorger}" +
                   $"\n\nDieren\n======" +
                   $"\nMannetjesdier: {this.Mannetjesdier} (Laatst gevoerd: {this.Mannetjesdier.LaatstGevoerd.ToString("HH:mm")})" +
                   $"\nVrouwtjesdier: {this.Vrouwtjesdier} (Laatst gevoerd: {this.Vrouwtjesdier.LaatstGevoerd.ToString("HH:mm")})";
        }
    }
}
