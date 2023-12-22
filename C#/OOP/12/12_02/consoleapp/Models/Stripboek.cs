using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Stripboek: Product
    {
        private string _auteur;
        private int _aantalPaginas;

        public string Auteur
        {
            get { return _auteur; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new LegeTekstueleWaardeException($"_auteur");
                }
                _auteur = value;
            }
        }
        public int AantalPaginas
        {
            get { return _aantalPaginas; }
            set 
            {
                if (value < 0)
                {
                    throw new NumeriekeWaardeOnderNulException("_aantalPaginas");
                }
                _aantalPaginas = value;
            }
        }

        public Stripboek(string naam, double prijs, string auteur, int aantalPaginas) : base(naam, prijs)
        {
            this.Auteur = auteur;
            this.AantalPaginas = aantalPaginas;
        }

        public string ToonGegevens()
        {
            return $"{base.ToonGegevens()}" +
                   $"Auteur: {this.Auteur}\n" +
                   $"Aantal paginas: {this.AantalPaginas}\n";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Stripboek stripboek)
            {
                return stripboek.GetHashCode() == this.GetHashCode();
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Naam, this.Prijs, this.Auteur, this.AantalPaginas);
        }
    }
}
