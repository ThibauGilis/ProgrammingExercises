
int LeesMenu(string[] menu, string vraag)
{
    for (int i = 0; i < menu.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {menu[i]}");
    }
    return LeesGetal(vraag, 1, menu.Length);
}
int LeesGetal(string vraag, int min = 0, int max = int.MaxValue)
{
    int getal;
    do
    {
        Console.Write(vraag);
    } while (!int.TryParse(Console.ReadLine(), out getal) || getal < min || max < getal);
    return getal;
}

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

//----------------------------------------------------------------

Dier dier = null;

string[] Menu = new string[] { "Kat", "Olifant", "Papegaai"};
string[] subMenu = new string[] { "Gegevens", "Strelen", "Praten" };

int keuze = LeesMenu(Menu, "Geef een getal tussen 1 en 3: ");
string naam = LeesInvoer("Geef een naam: ");

switch (keuze)
{
    case 1:
        dier = new Kat(naam);
        break;

    case 2:
        dier = new Olifant(naam);
        break;

    case 3:
        dier = new Papegaai(naam);
        break;

    default:
        Console.WriteLine("ERROR");
        break;
}

switch (LeesMenu(subMenu, "Geef een getal tussen 1 en 3: "))
{
    case 1:
        Console.WriteLine(dier);
        break;

    case 2:
        string zin = LeesInvoer("Wat wil je tegen het dier zeggen? ");
        Console.WriteLine(dier.Praten(zin));
        break;

    case 3:
        Console.WriteLine(dier.Strelen());
        break;

    default:
        Console.WriteLine("ERROR");
        break;
}