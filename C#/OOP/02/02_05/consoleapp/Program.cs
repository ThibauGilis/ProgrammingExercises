
int LeesGetal(string vraag, int max = int.MaxValue, int min = 0)
{
    int getal;
    do
    {
        Console.Write(vraag);
    } while (!int.TryParse(Console.ReadLine(), out getal) || getal < min || getal > max);
    Console.WriteLine();
    return getal;
}
string LeesInvoer(string vraag)
{
    string invoer;
    do
    {
        Console.WriteLine(vraag);
        invoer = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(invoer));
    return invoer;
}

//-------------------------------------------------

string[] Opties = new string[] { "LiefKozen", "Straffen", "Eten", "Gegevens" };
for  (int i = 0; i < Opties.Length; i++)
{
    Console.WriteLine($"{i+1}. {Opties[i]}");
}
Console.WriteLine();

string naam = LeesInvoer("Wat is de naam: ");
int eenHonger = LeesGetal($"Hoeveel honger heeft {naam}: ");
int eenGevoel = LeesGetal($"Hoe voelt {naam} zich: ");

Tamagotchi tamagotchi = new Tamagotchi(naam, eenHonger, eenGevoel);

switch (LeesGetal("Wat wilt u doen: "))
{
    case 1:

        break;

    case 2:

        break;

    case 3:

        break;

    case 4:
        Console.WriteLine();
        break;

    default:
        break;
}