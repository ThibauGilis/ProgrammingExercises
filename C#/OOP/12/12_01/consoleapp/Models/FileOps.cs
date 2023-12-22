using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public static class FileOps
    {   
        public static void FoutLoggen(Exception fout)
        {
            StreamWriter sWriter = new StreamWriter("foutenbestand.txt", true);
            sWriter.WriteLine($"{fout.GetType()}\n{fout.Message}\n{fout.StackTrace}");
        }

        public static List<Klant> KlantenInlezen(string bestand)
        {
            List<Klant> klanten = new List<Klant>();

            try
            {
                StreamReader sReader = new StreamReader(bestand);

                while (!sReader.EndOfStream)
                {
                    try
                    {
                        string[] data = sReader.ReadLine().Split(';');

                        int klantennummer = int.Parse(data[0]);
                        string naam = data[1];
                        string adres = data[2];
                        string gemeente = data[3];
                        string postcode = data[4];

                        Klant klant = new Klant(klantennummer, naam, adres, gemeente, postcode);
                        klanten.Add(klant);
                    }
                    catch (Exception ex)
                    {
                        FoutLoggen(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                FoutLoggen(ex);
                return null;
            }

            return klanten;
        }

        public static Klant ZoekKlantViaNummer(int klantnummer)
        {
            List<Klant> klanten = KlantenInlezen("klanten.txt");

            foreach (Klant klant in klanten)
            {
                if (klant.Klantennummer == klantnummer)
                {
                    return klant;
                }
            }
            throw new KlantNietGevondenException(klantnummer);
        }
    }
}
