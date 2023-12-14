namespace consoleapp.Models;

public static class FileOperations
{
    public static string BestandSiropen = "siropen.txt";
    public static string BestandToppings = "toppings.txt";
    public static string BestandGlazuren = "glazuren.txt";
    public static string BestandVullingen = "vullingen.txt";
    public static string BestandSmaken = "smaken.txt";

    public static List<string> LeesOpties(string bestandsnaam)
    {
        List<string> Opties = new List<string>() { "Geen" };

        if (File.Exists(bestandsnaam)) 
        {
            StreamReader sr = new StreamReader(bestandsnaam);

            while (!sr.EndOfStream)
            {
                string optie = sr.ReadLine();
                if (!string.IsNullOrWhiteSpace(optie)) 
                {
                    Opties.Add(optie);
                }
            }
        }

        return Opties;
    }
}