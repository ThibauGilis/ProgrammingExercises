namespace consoleapp.Models;

public static class FileOperations
{
    private static string BestandContacten = "contacten.txt";

    public static List<Persoon> LeesContacten()
    {
        List<Persoon> Contacten = new List<Persoon>();

        if (File.Exists(BestandContacten))
        {
            using (StreamReader sr = new StreamReader(BestandContacten))
            {
                while (!sr.EndOfStream)
                {
                    string[] data = sr.ReadLine().Split(';');
                    Persoon persoon = new Persoon(data[0], data[1], data[2]);

                    if (!Contacten.Contains(persoon))
                    {
                        Contacten.Add(persoon);
                    }
                }
            }
        }

        return Contacten;
    }
}
