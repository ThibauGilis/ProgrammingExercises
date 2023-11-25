namespace consoleapp.Models;

static public class Geldigheid
{
    static public string Rijkregisternummer(string rijkregisternummer)
    {
        if (Int64.TryParse(rijkregisternummer, out Int64 nummer) && rijkregisternummer.Length == 11)
        {
            switch (int.Parse(rijkregisternummer.Substring(0, 2)) % 2)
            {
                case 0:
                    // 97 - rest van eerste 9 getalen gedeeld door 97 == laatste 2 getallen
                    if (97 -( Int64.Parse(rijkregisternummer.Substring(0, 9)) % 97) == int.Parse(rijkregisternummer.Substring(9, 2)))
                    {
                        return "(geldig)";
                    }
                    break;

                case 1:
                    // de rest van 2 vastgeplakt aan 3 getallen gedeeld door 20 == laatste 2 getallen
                    if (Int64.Parse("2" + rijkregisternummer.Substring(6, 3)) % 20 == int.Parse(rijkregisternummer.Substring(9, 2))) 
                    {
                        return "(geldig)";
                    }
                    break;

                default:
                    Console.WriteLine("ERROR");
                    break;
            }
        }

        return "(ongeldig)";
    }

    static public string Ibannummer(string ibannummer)
    {
        if (Int64.TryParse(ibannummer, out Int64 nummer) && ibannummer.Length == 12)
        {
            if (Int64.Parse(ibannummer.Substring(0, 10)) % 97 == int.Parse(ibannummer.Substring(10,2)))
            {
                return "(geldig)";
            }
        }
        return "(ongeldig)";
    }
}
