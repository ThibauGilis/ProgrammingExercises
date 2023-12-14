
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

//--------------------------------------------------------------------------------------------------------------------------------------

string[] Opties = new string[] { "Berekenen stroomsterkte", "Berekenen spanning", "Berekenen weerstand", "Berekenen vermogen" };
for  (int i = 0; i < Opties.Length; i++)
{
    Console.WriteLine($"{i}. {Opties[i]}");
}
Console.WriteLine();

int spanning, weerstand, stroomsterkte;

switch (LeesGetal("Kies een optie: ", Opties.Length))
{
    case 0:
        spanning = LeesGetal("Geef de spanning: ");
        weerstand = LeesGetal("Geef de weerstand");
        Console.WriteLine($"Stroomsterkte is {FileOperations.BerekenStroomsterkte(spanning, weerstand)}");
        break;

    case 1:
        stroomsterkte = LeesGetal("Geef de stroomsterkte: ");
        weerstand = LeesGetal("Geef de weerstand");
        Console.WriteLine($"Spanning is {FileOperations.BerekenSpanning(stroomsterkte, weerstand)}");
        break;

    case 2:
        spanning = LeesGetal("Geef de spanning: ");
        stroomsterkte = LeesGetal("Geef de stroomsterkte: ");
        Console.WriteLine($"Weerstand is {FileOperations.BerekenWeerstand(spanning, stroomsterkte)}");
        break;

    case 3:
        spanning = LeesGetal("Geef de spanning: ");
        stroomsterkte = LeesGetal("Geef de stroomsterkte: ");
        Console.WriteLine($"Vermogen is {FileOperations.BerekenVermogen(spanning, stroomsterkte)}");
        break;

    default:
        break;
}