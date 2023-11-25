int LeesGetal()
{
    int getal;

    do
    {
        Console.Write($"Maak een keuze: ");
    } while (!int.TryParse(Console.ReadLine(), out getal));

    Console.WriteLine("\n");
    return getal;
}

void ToonMenu(string[] Menu)
{
    Console.WriteLine("\n");
    for (int i = 0; i < Menu.Length; i++)
    {
        Console.WriteLine($"{i}: {Menu[i]}");
    }
}

void DrukEnter()
{
    Console.WriteLine("Druk op enter om af te sluiten");
    Console.ReadLine();
}

//----------------------------------------------------------------


string[] menu = new string[] {"stoppen", "patat", "klas", "deuntje", "oma", "sorry", "schrijven", "vriendschap", "mensen", "vrienden"};

ToonMenu(menu);
int invoer = LeesGetal();
while (invoer != 0)
{
    string bestandsnaam = $"gedicht-{invoer}.txt";
    if (File.Exists(bestandsnaam))
    {
        using(StreamReader gedicht = new StreamReader(bestandsnaam))
        {
            Console.WriteLine($"Gedicht {invoer}\n{new string('=', $"Gedicht {invoer}".Length)}\n" + gedicht.ReadToEnd());
        }
    }
    else
    {
        Console.WriteLine($"Bestand {bestandsnaam} bestaat niet");
    }

    ToonMenu(menu);
    invoer = LeesGetal();
}

DrukEnter();