
int LeesKeuzeUitMenu(string[] menu)
{
    for (int i = 0; i < menu.Length; i++)
    {
        Console.WriteLine($"{i+1}. {menu[i]}");
    }

    int keuze;
    do 
    {
        Console.Write("Geef je keuze: ");
    } while (!int.TryParse(Console.ReadLine(),out keuze) || keuze < 1 || keuze > menu.Length);
    return keuze;
}

//-------------------------------------------------------------------------------------------------

string[] Menu = new string[] { "Overzicht van de studenten tonen", "Gemiddeldes tonen" };

Console.Write("Geef de naam van het bestand: ");
List<Student> studenten = FileOperations.LeesStudenten(Console.ReadLine());
Klas klas = new Klas(1, "1A", studenten);

switch (LeesKeuzeUitMenu(Menu))
{
    case 1:
        Console.WriteLine(klas);
        break;

    case 2:
        Console.WriteLine($"Gemiddelde wiskunde: {klas.BerekenGemiddeldeWiskunde()}");
        Console.WriteLine($"Gemiddelde Nederlands: {klas.BerekenGemiddeldeNederlands()}");
        break;

    default:
        break;
}

