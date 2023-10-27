
string bestandsnaam;
int som;

// Inlezen van bestandsnaam

bestandsnaam = LeesStringNietLeeg("Geef een bestandsnaam: ");

// Lees Bestand en bereken som

if (GeldigBestand(bestandsnaam))
{
    som = LeesBestand(bestandsnaam);
}

/*Console.Write("Geef bestandsnaam: ");
bestandsnaam = Console.ReadLine();

if (File.Exists(bestandsnaam))
{
    using (StreamReader Bestand = new StreamReader(bestandsnaam))

        while (!Bestand.EndOfStream)
        {
            string record = Bestand.ReadLine();
            if (int.TryParse(record, out int getal))
            {
                som += getal;
            }
        }
    Console.WriteLine($"Som van de getallen is: {som}");
}
else
{
    Console.WriteLine($"{bestandsnaam} bestaat niet");
}*/


int LeesBestand(string bestandsnaam)
{
    int som = 0;
    using (StreamReader Bestand = new StreamReader(bestandsnaam))
    {
        while (!Bestand.EndOfStream)
        {
            string record = Bestand.ReadLine();
            if (int.TryParse(record, out int getal))
            {
                som += getal;
            }
        }
        Console.WriteLine($"Som van de getallen is: {som}");
    }
    return som;
}

bool GeldigBestand(string bestandsnaam)
{
    return File.Exists(bestandsnaam);
}

string LeesStringNietLeeg(string vraag)
{
    string invoer;
    do
    {
        Console.Write(vraag);
        invoer = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(invoer));

    return invoer;
}