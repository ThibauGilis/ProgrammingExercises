
int PrintMenuFestival(List<Festival> Menu)
{
    for (int i = 0; i < Menu.Count; i++)
    {
        Console.WriteLine($"{i+1}. {Menu[i].Naam}");
    }

    return LeesKeuze("Welk festival kiest u? ", Menu.Count);
}
int PrintMenuOpties(string[] Menu)
{
    for (int i = 0; i < Menu.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {Menu[i]}");
    }

    return LeesKeuze("Wat wil u doen? ", Menu.Length);
}
int LeesKeuze(string vraag, int max, int min = 1)
{
    int keuze;
    do
    {
        Console.Write(vraag);
    } while (!int.TryParse(Console.ReadLine(), out keuze) || keuze < min || keuze > max);
    Console.WriteLine();
    return keuze;
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
double LeesDouble(string vraag)
{
    double d;
    do
    {
    } while (!double.TryParse(LeesInvoer(vraag), out d) || d < 0);
    return d;
}

//-----------------------------------------------------------

//----
Optreden optreden = null;
Artiest artiest = null;
string genre, naam, dag;
int keuze;
double budget, prijs;

string[] menuOpties = new string[] { "Toon overzicht", "Voeg optreden toe", "Verwijder optreden" };
List<Festival> festivallen = FileOperations.LeesFestivals();
//----

keuze = PrintMenuFestival(festivallen) -1;
naam = festivallen[keuze].Naam;
budget = festivallen[keuze].Budget;
Festival festival = new Festival(naam,budget);

switch (PrintMenuOpties(menuOpties))
{
    case 1:

        break;

    case 2:
        dag = LeesInvoer("Op welke dag is het optreden? ");
        naam = LeesInvoer("Welke artiest zal optreden? ");
        genre = LeesInvoer("Welk genre speelt deze artiest? ");
        prijs = LeesDouble("Hoeveel kost dit optreden? ");

        artiest = new Artiest(naam, genre, prijs);
        optreden = new Optreden(artiest, dag);

        festival.VoegOptredenToe(optreden);

        break;

    case 3:
        dag = LeesInvoer("Op welke dag is het optreden? ");
        naam = LeesInvoer("Welke artiest zal optreden? ");

        optreden = festival.Optredens.Find(item => item.Artiest.Naam == naam && item.Dag == dag);

        festival.VerwijderOptreden(optreden);
        break;

    default:
        Console.WriteLine("ERROR");
        break;
}

Console.WriteLine(festival);
