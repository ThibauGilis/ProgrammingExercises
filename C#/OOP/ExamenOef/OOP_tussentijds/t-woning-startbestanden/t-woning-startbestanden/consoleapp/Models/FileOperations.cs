using System;

namespace consoleapp.Models
{


    public static class FileOperations
    {
        public static string BestandWoningen = "woningen.txt";

        public static List<Woning> LeesWoningen() 
        {
            List<Woning> woningen = new List<Woning>();

            if (!File.Exists(BestandWoningen))
            {
                return woningen;
            }

            using (StreamReader TeLezenBestand =  new StreamReader(BestandWoningen))
            {
                while (!TeLezenBestand.EndOfStream)
                {
                    Woning woning = null;

                    string[] data = TeLezenBestand.ReadLine().Split(';');

                    string typeWoning = data[0].ToLower();

                    string adres = data[1];
                    double.TryParse(data[2], out double oppervlakte);
                    int.TryParse(data[3], out int bouwjaar);
                    bool.TryParse(data[4], out bool zonnepanelen);

                    if (typeWoning == "huis")
                    {
                        int.TryParse(data[5], out int aantalKamers);

                        woning = new Huis(adres, oppervlakte, bouwjaar, zonnepanelen, aantalKamers);
                    }
                    else
                    {
                        int.TryParse(data[5], out int verdieping);
                        double.TryParse(data[6], out double vasteKosten);

                        woning = new Appartement(adres, oppervlakte, bouwjaar, zonnepanelen, verdieping, vasteKosten);
                    }
                    
                    if (!woningen.Contains(woning))
                    {
                        woningen.Add(woning);
                    }
                }
            }

            return woningen;
        }
    }
}