
int PrintOptions()
{
    int getal;
    do
    {
        Console.Write("Maak een keuze: ");
    } while (!int.TryParse(Console.ReadLine(), out getal) || getal < 0 || 1 < getal);
    Console.WriteLine();

    return getal;
}

void AddCursist(List<Cursist> cursisten)
{
    int nextID = cursisten.Count() + 1;

    Console.WriteLine("Geef de voornaam van de nieuwe cursist:");
    string voornaam = Console.ReadLine();
    Console.WriteLine("Geef de familienaam van de nieuwe cursist:");
    string familienaam = Console.ReadLine();

    Cursist cursist = new Cursist(nextID, voornaam, familienaam);
    cursisten.Add(cursist);
}

void DeleteCursist(List<Cursist> cursisten)
{
    int keuze;
    do
    {
        Console.Write("Geef de cursistId van de cursist die je wil verwijderen: ");
    } while (!int.TryParse(Console.ReadLine(), out keuze) || keuze < 1 || cursisten.Count() < keuze);
    Console.WriteLine();

    do
    {
        for (int i = 0; i < cursisten.Count(); i++)
        {
            if (i + 1 == keuze)
            {
                cursisten.RemoveAt(i);

                for (int j = i; j < cursisten.Count(); j++)
                {
                    cursisten[j].CursistID -= 1;
                }

                break;
            }
        }
    } while (false);
}

void PrintCursisten(List<Cursist> cursisten)
{
    foreach (Cursist cursist in cursisten)
    {
        Console.WriteLine(cursist);
    }
    Console.WriteLine();
}

//------------------------------------------------------

List<Cursist> Cursisten = FileOperations.LeesCursisten();

Console.WriteLine("Cursisten\n---------\n");
PrintCursisten(Cursisten);

Console.WriteLine("Wat wil je doen?\n");
Console.WriteLine("0. Toevoegen\n1. Verwijderen\n");

switch (PrintOptions())
{
    case 0:
        AddCursist(Cursisten);
        break;

    case 1:
        DeleteCursist(Cursisten);
        break;

    default:
        Console.WriteLine("ERROR");
        break;
}

Console.WriteLine("Nieuwe lijst van cursisten\n--------------------------\n");
PrintCursisten(Cursisten);

Console.WriteLine("Druk op Enter om verder te gaan.");
Console.ReadLine();