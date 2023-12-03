using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class FileOperations
    {
        public List<Kaart> LeesFile(string BestandNaam)
        {
            List<Kaart> kaarten = new List<Kaart>();

            if (!File.Exists(BestandNaam))
            {
                return kaarten;
            }

            using (StreamReader reader = new StreamReader(BestandNaam))
            {
                while (!reader.EndOfStream)
                {
                    string[] data = reader.ReadLine().Split(';');

                    int.TryParse(data[0], out int nummer);
                    string soort = data[1];
                    string kleur = data[2];

                    Kaart kaart = new Kaart(nummer, soort, kleur);
                    kaarten.Add(kaart);
                }
            }

            return kaarten;
        }
    }
}
