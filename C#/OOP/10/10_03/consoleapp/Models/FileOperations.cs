using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace consoleapp.Models;

public static class FileOperations
{
    public static string BestandVliegtuigen = "vliegtuigen.txt";
    public static string BestandLuchthavens = "luchthavens.txt";

    public static List<Vliegtuig> LeesVliegtuigen()
    {
        List<Vliegtuig> vliegtuigen = new List<Vliegtuig>();

        if (File.Exists(BestandVliegtuigen))
        {
            using (StreamReader sr = new StreamReader(BestandVliegtuigen))
            {
                while (!sr.EndOfStream)
                {
                    string[] data = sr.ReadLine().Split(';');
                    string code = data[0];
                    string type = data[1];
                    int.TryParse(data[2], out int zitplaatsen);

                    Vliegtuig vliegtuig = new Vliegtuig(code, type, zitplaatsen);
                    vliegtuigen.Add(vliegtuig);
                }
            }
        }
        return vliegtuigen;
    }

    public static List<Luchthaven> LeesLuchthavens()
    {
        List<Luchthaven> luchthavens = new List<Luchthaven>();
        List<Vliegtuig> vliegtuigen = LeesVliegtuigen();

        if (File.Exists(BestandLuchthavens))
        {
            using (StreamReader sr = new StreamReader(BestandLuchthavens))
            {
                while (!sr.EndOfStream)
                {
                    string[] data = sr.ReadLine().Split(';');
                    string name = data[0];

                    string[] vliegtuigCodes = new string[data.Length-1];
                    for (int i = 0; i < data.Length-1; i++)
                    {
                        vliegtuigCodes[i] = data[i+1];
                    }
                    

                    List<Vliegtuig> vliegtuigenVanLuchthaven = new List<Vliegtuig>();
                    foreach (string code in  vliegtuigCodes)
                    {
                        vliegtuigenVanLuchthaven.Add(vliegtuigen.Find(vliegtuig => vliegtuig.Code == code));
                    }

                    Luchthaven luchthaven = new Luchthaven(name, vliegtuigenVanLuchthaven);
                    luchthavens.Add(luchthaven);
                }
            }
        }
        return luchthavens;
    }
}
