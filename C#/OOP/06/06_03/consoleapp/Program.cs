
string LeesInvoer(string vraag)
{
    string invoer;
    do
    {
        Console.Write(vraag);
        invoer = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(invoer));

    return invoer;
}
int LeesGetal(string vraag)
{
    int getal;
    do
    {
        Console.Write(vraag);
    } while (!int.TryParse(Console.ReadLine(), out getal));

    return getal;
}

//--------------------------------------------------------------------------------

List<Kaart> kaarten = new FileOperations().LeesFile(LeesInvoer("Kies een spel: "));

int ComputerPunten = 0;
int SpelerPunten = 0;

for (int i = 0; i < kaarten.Count; i++)
{
    Kaart kaart = kaarten[i];

    bool gelijk = kaart.Equals(new Kaart(LeesGetal("Geef een waarde: "), LeesInvoer("Geef een soort: "), LeesInvoer("Geef een kleur: ")));
    Console.WriteLine();

    if (gelijk)
    {
        SpelerPunten++;
        Console.WriteLine($"U heeft goed gegokt! {kaart}");
    }
    else
    {
        ComputerPunten++;
        Console.WriteLine($"U heeft niet goed gegokt! {kaart}");
    }
    Console.WriteLine();

    Console.WriteLine($"Computer: {ComputerPunten} - Speler: {SpelerPunten}");

    if (SpelerPunten == 3)
    {
        Console.WriteLine("Einde spel. De speler is de winnaar!");
        break;
    }
    else if (ComputerPunten == 3)
    {
        Console.WriteLine("Einde spel. De computer is de winnaar!");
        break;
    }
}



