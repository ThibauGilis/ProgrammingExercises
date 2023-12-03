namespace consoleapp.Models;

public static class FileOperations
{
    public static string CursistenBestand = "cursisten.txt";

    public static List<Cursist> LeesCursisten()
    {
        List<Cursist> cursisten = new List<Cursist>();

        if (!File.Exists(CursistenBestand))
        {
            return cursisten;
        }

        using (StreamReader streamReader = new StreamReader(CursistenBestand))
        {
            while (!streamReader.EndOfStream)
            {
                string[] data = streamReader.ReadLine().Split(';');

                int id = int.Parse(data[0]);
                string voornaam = data[1];
                string familienaam = data[2];

                Cursist cursist = new Cursist(id, voornaam, familienaam);
                cursisten.Add(cursist);
            }
        }

        return cursisten;
    }
}
