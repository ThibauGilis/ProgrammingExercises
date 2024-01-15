
using consoleapp.Models;

void PrintMenu(string[] menuOpties)
{
    for (int i = 0; i < menuOpties.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {menuOpties[i]}");
    }
    Console.WriteLine();
}
int LeesKeuze(string vraag, int min, int max)
{
    int getal;
    do
    {
        Console.Write(vraag);
    } while (!int.TryParse(Console.ReadLine(), out getal) || getal < min || getal > max);
    Console.WriteLine();
    return getal;
}


//----------------------------------------------------------------------------------------------


string[] huisOpties = new string[] { "Info over de woning", "Info over het verbuik" };
string[] appartementOpties = new string[] { "Info over de woning", "Info over de huurprijs" };
List<Woning> woningen = FileOperations.LeesWoningen();

Console.WriteLine("Overzicht van de woningen:");
for (int i = 0; i < woningen.Count; i++)
{
    Console.WriteLine($"{i + 1}. {woningen[i].Info}");
}
Console.WriteLine();


int keuzeWoning, keuzeOptie, aantalPersonen;

keuzeWoning = LeesKeuze($"Welke woning wil je bekijken?  (1-{woningen.Count}): ", 1, woningen.Count) - 1; // -1 want index start bij 0

Console.WriteLine("Met hoeveel personen woon je in deze woning?");
aantalPersonen = LeesKeuze("Aantal personen (1-10): ", 1, 10);

Woning woning = woningen[keuzeWoning];

if (woning is Huis huis)
{
    PrintMenu(huisOpties);
    keuzeOptie = LeesKeuze($"Maak een keuze:  (1-{huisOpties.Length}): ", 1, huisOpties.Length);

    if (keuzeOptie == 1)
    {
        Console.WriteLine(huis);
    }
    else
    {
        Console.WriteLine($"Het verbruik van deze woning is {huis.BerekenVerbruik(aantalPersonen)} kWh.");
    }
}
else if (woning is Appartement appartement)
{
    PrintMenu(appartementOpties);
    keuzeOptie = LeesKeuze($"Maak een keuze:  (1-{appartementOpties.Length}): ", 1, appartementOpties.Length);

    if (keuzeOptie == 1)
    {
        Console.WriteLine(appartement);
    }
    else
    {
        Console.WriteLine($"De huurprijs van deze woning is {appartement.BerekenHuurprijs(aantalPersonen)} euro.");
    }
}