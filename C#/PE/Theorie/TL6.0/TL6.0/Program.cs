int getal, totaal = 0;

do
{
    do
    {
        Console.WriteLine("Geef een negatief getal: ");
    } while (!int.TryParse(Console.ReadLine(), out getal));
    if (getal >= 0)
    {
        totaal += getal;
    }
} while (getal > 0);

Console.WriteLine($"Totaal: {totaal}");



