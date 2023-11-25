
int LeesGetal(string vraag, int min, int max)
{
    int getal;
    do
    {
        Console.Write(vraag);
    } while (!int.TryParse(Console.ReadLine(), out getal) || getal < min || max < getal);
    return getal;
}

//------------------------------------------------------------------------

string[] Opties = new string[] { "Punt", "Cirkel", "Cilinder" };

for (int i = 0; i < Opties.Length; i++)
{
    Console.WriteLine($"{i}. {Opties[i]}");
}


switch (LeesGetal("Maak uw keuze: ", 0, Opties.Length))
{
    case 0:
        Punt punt = new Punt(LeesGetal("Geef een getal groter dan 0 voor X: ", 0, int.MaxValue), LeesGetal("Geef een getal groter dan 0 voor Y: ", 0, int.MaxValue));
        Console.WriteLine(punt.ToonGegevens());
        break;

    case 1:
        Cirkel cirkel = new Cirkel(LeesGetal("Geef een getal groter dan 0 voor X: ", 0, int.MaxValue), LeesGetal("Geef een getal groter dan 0 voor Y: ", 0, int.MaxValue), LeesGetal("Geef een getal groter dan 0 voor R: ", 0, int.MaxValue));
        Console.WriteLine(cirkel.ToonGegevens());
        break;

    case 2:
        Cilinder cilinder = new Cilinder(LeesGetal("Geef een getal groter dan 0 voor X: ", 0, int.MaxValue), LeesGetal("Geef een getal groter dan 0 voor Y: ", 0, int.MaxValue), LeesGetal("Geef een getal groter dan 0 voor R: ", 0, int.MaxValue), LeesGetal("Geef een getal groter dan 0 voor H: ", 0, int.MaxValue));
        Console.WriteLine(cilinder.ToonGegevens());
        break;

    default:
        Console.WriteLine("ERROR");
        break;
}
