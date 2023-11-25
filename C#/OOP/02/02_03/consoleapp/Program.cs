int LeesGetal(string vraag, int min = int.MinValue, int max = int.MaxValue)
{
    int getal;

    do
    {
        Console.Write(vraag);
    } while (!int.TryParse(Console.ReadLine(), out getal) || getal < min || max < getal);

    return getal;
}


//------------------------------------------------------------------------

Auto auto = new Auto();
auto.Brandstof = LeesGetal("Geef hoeveelheid brandstof: ");
auto.HuidigStand = LeesGetal("Geef huidige kilometerstand: ");
auto.KilometerStand = LeesGetal("Geef kilometerstand laatste onderhoud: ");

string[] Opties = new string[] { "Voeg 25 kilometer toe", "Voeg 100 kilometer toe", "Voeg 1000 kilometer toe", "Vul brandstof aan", "Voer onderhoud uit" };

Console.WriteLine("\nOpties\n-----------------");
for (int i = 0; i < Opties.Length; i++)
{
    Console.WriteLine($"{i+1}. {Opties[i]}");
}


int keuze = LeesGetal("\nGeef een keuze: ", 1, Opties.Length);

switch(keuze)
{
    case 1:
        auto.HuidigStand += 25;
        auto.Brandstof -= 1.25;
        break;

    case 2:
        auto.HuidigStand += 100;
        auto.Brandstof -= 5;
        break;

    case 3:
        auto.HuidigStand += 1000;
        auto.Brandstof -= 50;
        break;

    case 4:
        auto.Brandstof += LeesGetal("Geef de hoeveelheid brandstof: ");
        break;

    case 5:
        auto.KilometerStand = auto.HuidigStand;
        break;

    default:
        Console.WriteLine("ERROR");
        break;
}

auto.ToonGegevens();

