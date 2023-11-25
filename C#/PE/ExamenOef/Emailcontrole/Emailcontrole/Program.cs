void PasSchermkleurenAan()
{
    Console.BackgroundColor = ConsoleColor.White;
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.Clear();
    Console.Title = "r0956399 Thibau Gilis - Emailcontrole";
}

bool ControleerRecord(string record)
{
    return (record.Contains('@') && record.Substring(record.IndexOf("@")).Contains('.'));
}

int TelCorrecte(List<string> emails)
{
    int i = 0;
    foreach (string email in emails)
    {
        if (ControleerRecord(email))
        {
            i++;
        }
    }
    return i;
}

int TelIncorrecte(List<string> emails)
{
    int i = 0;
    foreach (string email in emails)
    {
        if (!ControleerRecord(email))
        {
            i++;
        }
    }
    return i;
}

void ControleerBestand(string bestandsnaam)
{
    if (File.Exists(bestandsnaam))
    {
        List<string> Emails = new List<string>();
        using (StreamReader Bestand =  new StreamReader(bestandsnaam))
        {
            while (!Bestand.EndOfStream)
            {
                Emails.Add(Bestand.ReadLine());
            }
        }

        int correct = TelCorrecte(Emails), incorrect = TelIncorrecte(Emails);
        Console.WriteLine($"Correcte: {correct}");
        Console.WriteLine($"Incorrecte: {incorrect}");
        Console.WriteLine($"Totaal: {correct+incorrect}");
    }
    else
    {
        Console.WriteLine($"{bestandsnaam} bestaat niet");
    }
}

//------------------------------------------------------------------
//--------------- PROGRAM ------------------------------------------
//------------------------------------------------------------------

PasSchermkleurenAan();
Console.Write("Bestandsnaam: ");
ControleerBestand(Console.ReadLine());
