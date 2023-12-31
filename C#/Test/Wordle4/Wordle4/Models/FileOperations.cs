
namespace Wordle4.Models
{
    public static class FileOperations
    {
        public static string BestandWoorden = "Woorden.txt";

        public static List<string> ListOfWords()
        {
            List<string> Woorden = new List<string>();

            if (File.Exists(BestandWoorden))
            {
                using (StreamReader Bestand = new StreamReader(BestandWoorden))
                {
                    while (!Bestand.EndOfStream)
                    {
                        string woord = Bestand.ReadLine().ToLower();

                        if (!Woorden.Contains(woord))
                        {
                            Woorden.Add(woord);
                        }
                    }
                }
            }

            return Woorden;
        }
    }
}
