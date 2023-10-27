
int LeesGetal(int min, int max)
{
    int getal;

    do
    {
        Console.Write($"Maak een keuze tussen {min} en {max}: ");
    } while (!int.TryParse(Console.ReadLine(), out getal) || getal < min || max < getal);

    return getal;
}

List<int> LeesBestand(string bestandnaam)
{
    List<int> Punten = new List<int>();
    using (StreamReader Bestand = new StreamReader(bestandnaam))
    {
        while (!Bestand.EndOfStream)
        {
            if (int.TryParse(Bestand.ReadLine(), out int punt))
            {
                Punten.Add(punt);
            }
        }
    }

    return Punten;
}

//---------------------------------------------------------------------

Console.Write("Welke bewerking: ");
int OperatieKeuze = LeesGetal(1, 3);
int BestandNummer = LeesGetal(1, 6);
string BestandNaam = $"studenten-{BestandNummer}.txt";

switch (OperatieKeuze)
{
    case 1:
        Console.WriteLine($"Het gemiddelde is {LeesBestand(BestandNaam).Average()}");
        break;

    case 2:
        Console.WriteLine($"De hoogste score is {LeesBestand(BestandNaam).Max()}");
        break;

    case 3:
        Console.WriteLine($"De laagste score is {LeesBestand(BestandNaam).Min()}");
        break;

    default:
        Console.WriteLine("ERROR");
        break;
}
