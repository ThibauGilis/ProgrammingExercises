namespace consoleapp.Models;

public static class FileOperations
{
    private static string BestandDieren = "dieren.txt";
    private static string BestandPersoneel = "personeel.txt";

    public static List<Dier> LeesDieren()
    {
        List<Dier> dieren = new List<Dier>();

        if (File.Exists(BestandDieren))
        {
            using (StreamReader sr = new StreamReader(BestandDieren))
            {
                while (!sr.EndOfStream)
                {
                    string[] data = sr.ReadLine().Split(';');

                    bool.TryParse(data[2], out bool gevaarlijk);

                    Dier dier = new Dier(data[0], data[1], gevaarlijk);

                    dieren.Add(dier);
                }
            }
        }

        return dieren;
    }
    public static List<Personeelslid> LeesPersoneel()
    {
        List<Personeelslid> personeel = new List<Personeelslid>();

        if (File.Exists(BestandPersoneel))
        {
            using (StreamReader sr = new StreamReader(BestandPersoneel))
            {
                while (!sr.EndOfStream)
                {
                    string[] data = sr.ReadLine().Split(';');

                    bool.TryParse(data[2], out bool gevaarlijk);

                    Personeelslid personeelslid = new Personeelslid(data[0], data[1], gevaarlijk);

                    personeel.Add(personeelslid);
                }
            }
        }

        return personeel;
    }
}
