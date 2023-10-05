int score, som = 0, i = 0;
string naam, overzicht = "";

Console.Write("Geef naam: ");
naam = Console.ReadLine();
while (naam != "")
{
    do
    {
        Console.Write($"Wat is de score van {naam}? ");
    } while (!int.TryParse(Console.ReadLine(), out score));

    overzicht += naam + $" ({score})\n";
    som += score;
    i++;

    Console.Write("Geef naam: ");
    naam = Console.ReadLine();
}

Console.WriteLine(overzicht + "Gemiddelde: " + (som/i));