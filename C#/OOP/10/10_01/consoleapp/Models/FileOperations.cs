namespace consoleapp.Models;

public static class FileOperations
{
    private static string BestandPersonen = "voetbal.txt";

    public static List<Persoon> LeesPersonen()
    {
        List<Persoon> Personen = new List<Persoon>();

        if (File.Exists(BestandPersonen))
        {
            using (StreamReader sr = new StreamReader(BestandPersonen))
            {
                while (!sr.EndOfStream)
                {
                    string[] data = sr.ReadLine().Split(';');

                    Persoon persoon = null;
                    if (data[0] == "Speler")
                    {
                        persoon = new Voetbalspeler(data[1], data[2], data[3]);
                    }
                    else if (data[0] == "Trainer")
                    {
                        double.TryParse(data[3], out double salaris);
                        persoon = new Trainer(data[1], data[2], salaris);
                    }

                    Personen.Add(persoon);
                }
            }
        }

        return Personen;
    }
    public static List<Trainer> LeesTrainers()
    {
        List<Trainer> trainers = new List<Trainer>();
        
        foreach (Persoon persoon in LeesPersonen())
        {
            if (persoon is Trainer trainer)
            {
                trainers.Add(trainer);
            }
        }

        return trainers;
    }
    public static List<Voetbalspeler> LeesSpelers()
    {
        List<Voetbalspeler> spelers = new List<Voetbalspeler>();

        foreach (Persoon persoon in LeesPersonen())
        {
            if (persoon is Voetbalspeler speler)
            {
                spelers.Add(speler);
            }
        }

        return spelers;
    }
}
