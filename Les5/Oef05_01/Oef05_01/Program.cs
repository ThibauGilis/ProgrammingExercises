int g1, g2;

do
{
    Console.Write("Geef getal1: ");
} while (int.TryParse(Console.ReadLine(), out g1) == false);

do
{
    Console.Write("Geef getal2: ");
} while (int.TryParse(Console.ReadLine(), out g2) == false);


if (g1 < g2)
{
    Console.WriteLine($"{g2} - {g1} = {g2 - g1}");
}
else
{
    Console.WriteLine($"{g1} - {g2} = {g1 - g2}");
}

