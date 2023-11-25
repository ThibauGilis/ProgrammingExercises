
int LeesKeuze(string vraag, int min, int max)
{
    int getal;
    do
    {
        Console.Write(vraag);
    } while (!int.TryParse(Console.ReadLine(), out getal) || getal < min || max < getal);
    Console.WriteLine();
    return getal;
}

double LeesGetal(string vraag)
{
    double getal;
    do
    {
        Console.Write(vraag);
    } while (!double.TryParse(Console.ReadLine(), out getal));
    return getal;
}


//------------------------------------------------------------------------------------------------------------------------


string[] MenuOpties = new string[] { "Oppervlakte rechthoek", "Oppervlakte cirkel", "Volume balk", "Volume cilinder" };

Console.WriteLine("Opties\n------");
for  (int i = 0; i < MenuOpties.Length; i++)
{
    Console.WriteLine($"{i}. {MenuOpties[i]}");
}

double resultaat = 0;
switch(LeesKeuze("\nGeef een optie: ", 0, MenuOpties.Length))
{
    case 0:
        resultaat = MeetkundigeFormules.OppervlakteRechthoek(LeesGetal("Geef de lentge: "),LeesGetal("Geef de breedte: "));
        Console.WriteLine($"De oppervlakte van de rechthoek is: {resultaat} cm²");
        break;

    case 1:
        resultaat = MeetkundigeFormules.OppervlakteCirkel(LeesGetal("Geef de straal: "));
        Console.WriteLine($"De oppervlakte van de cirkel is: {resultaat} cm²");
        break;

    case 2:
        resultaat = MeetkundigeFormules.VolumeBalk(LeesGetal("Geef de lentge: "), LeesGetal("Geef de breedte: "), LeesGetal("Geef de hoogte: "));
        Console.WriteLine($"De volume van de balk is: {resultaat} cm3");
        break;

    case 3:
        resultaat = MeetkundigeFormules.VolumeCilinder(LeesGetal("Geef de straal: "), LeesGetal("Geef de hoogte: "));
        Console.WriteLine($"De volume van de cilinder is: {resultaat} cm3");
        break;

    default:
        Console.WriteLine("ERROR");
        break;
}



