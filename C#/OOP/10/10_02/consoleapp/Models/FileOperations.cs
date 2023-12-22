namespace consoleapp.Models;

public static class FileOperations
{
    public static string BestandPersonen = "festivals.txt";

    public static List<Festival> LeesFestivals()
    {
        List<Festival> festivallen = new List<Festival>();

        if (File.Exists(BestandPersonen))
        {
            using (StreamReader streamReader = new StreamReader(BestandPersonen))
            {
                while (!streamReader.EndOfStream)
                {
                    string[] data = streamReader.ReadLine().Split(';');
                    double.TryParse(data[1], out double budget);

                    Festival festival = new Festival(data[0], budget);
                    festivallen.Add(festival);
                }
            }
        }
        return festivallen;
    }

    public static List<Optreden> LeesOptredensPerFestival(string festival)
    {
        List<Optreden> Optredens = new List<Optreden>();
        string Bestandsnaam = $"{festival}.txt";

        if (File.Exists(Bestandsnaam))
        {
            using (StreamReader streamReader = new StreamReader(Bestandsnaam))
            {
                while (!streamReader.EndOfStream)
                {
                    string[] data = streamReader.ReadLine().Split(';');
                    
                    double.TryParse(data[3], out double prijs);

                    Artiest artiest = new Artiest(data[1], data[2], prijs);
                    Optreden optreden = new Optreden(artiest ,data[0]);

                    Optredens.Add(optreden);
                }
            }
        }
        return Optredens;
    }
}
