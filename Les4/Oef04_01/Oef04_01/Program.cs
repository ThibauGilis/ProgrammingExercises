int getal, som = 0, aantal = 10;

for (int i = 0; i<aantal; i++)
{
    Console.Write($"Geef getal {i + 1}");
    getal = int.Parse(Console.ReadLine());
    som += getal;
}

Console.Write($"Som: {som}");