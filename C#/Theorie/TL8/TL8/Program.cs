void PasSchermKleurenAan()
{
    Console.BackgroundColor = ConsoleColor.White;
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.Clear();
    Console.Title = "06 whiledo - Oplossing 02";
}

void DrukTitel(string titel = "TEST")
{
    Console.WriteLine($"{titel}");
    Console.WriteLine($"{new string('*', titel.Length)}");
}

string LeesStringInvoer(string tekst)
{
    string invoer;
    do
    {
        Console.Write($"{tekst}: ");
        invoer = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(invoer));

    return invoer;
}

int LeesKeuze(string voornaam, string familienaam)
{
    string invoer;
    int keuze;

    do
    {
        Console.Write($"\nWelke hobby {voornaam.ToLower()} {familienaam.ToUpper()}? ");
        invoer = Console.ReadLine();
    } while (!int.TryParse(invoer, out keuze) || keuze < 1 || 8 < keuze);

    return keuze;
}

string VerwerkKeuze(int keuze)
{
    switch (keuze)
    {
        case 1:
            return "Anna";
        case 2:
            return "Knippie";
        case 3:
            return "VtWonen";
        case 4:
            return "Voetbal International";
        case 5:
            return "Wandelen & Fietsen";
        case 6:
            return "Zoom NL";
        case 7:
            return "Runners";
        default:
            return "";
    }
}


string familienaam, voornaam, suggestie;
string titel = "Opvragen algemene informatie";
int keuze;

PasSchermKleurenAan();

DrukTitel(titel);

familienaam = LeesStringInvoer("Familienaam");
voornaam = LeesStringInvoer("Voornaam");

keuze = LeesKeuze(voornaam, familienaam);

while (keuze != 8)
{
    suggestie = "Wij raden \"";
    suggestie += VerwerkKeuze(keuze) + "\" aan.";
    Console.WriteLine(suggestie);
    keuze = LeesKeuze(voornaam, familienaam);
}

Console.ReadLine();