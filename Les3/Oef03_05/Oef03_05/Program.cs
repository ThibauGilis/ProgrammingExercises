int x, y;

Console.Write("Geef de x coördinaat: ");
x = int.Parse(Console.ReadLine());
Console.Write("Geef de y coördinaat: ");
y = int.Parse(Console.ReadLine());

if (x >= 0)
{
    if (y >= 0)
    {
        if (x == 0 && y == 0)
        {
            Console.WriteLine("Punt ligt in de oorsprong.");
        }
        else
        {
            Console.WriteLine("Punt ligt in het eerste kwadrant.");
        }
    }
    else 
    {
        Console.WriteLine("Punt ligt in het vierde kwadrant.");
    }
}
else
{
    if (y >= 0)
    {
        Console.WriteLine("Punt ligt in het tweede kwadrant.");
    }
    else
    {
        Console.WriteLine("Punt ligt in het derde kwadrant.");
    }
}
