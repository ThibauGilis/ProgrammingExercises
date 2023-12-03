
int LeesGetal(int min = 0, int max = int.MaxValue)
{
    int getal;
    do
    {
    } while (!int.TryParse(Console.ReadLine(), out getal) || getal < min || max < getal);
    return getal;
}
double LeesDouble(string vraag, int min = 0, int max = int.MaxValue)
{
    double getal;
    do
    {
        Console.Write(vraag);
    } while (!double.TryParse(Console.ReadLine(), out getal) || getal < min || max < getal);
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


//---------------------------------------------------------------

Winkel persoon = null;

string[] Menu = new string[] { "Medewerker", "Eigenaar"};
Console.WriteLine("Kies een medewerker: ");
for (int i = 0; i < Menu.Length; i++)
{
    Console.WriteLine($"{i+1}. {Menu[i]}");
}

switch (LeesGetal(1, Menu.Length))
{
    case 1:
        persoon = new Medewerker(LeesInvoer("Geef de voornaam: "), LeesInvoer("Geef de familienaam: "), LeesDouble("Geef het uurloon: "));
        break; 

    case 2:
        persoon = new Eigenaar(LeesInvoer("Geef de voornaam: "), LeesInvoer("Geef de familienaam: "), LeesDouble("Geef het uurloon: "), LeesDouble("Geef het vast inkomen: "));
        break;

    default:
        Console.WriteLine("ERROR");
        break;
}

Console.WriteLine(persoon);
