int jaar;

Console.Write("Geef een jaartal: ");
jaar = int.Parse(Console.ReadLine());

if (jaar < 1582)
{
    if (jaar % 4 == 0)
    {
        Console.WriteLine($"{jaar} is een schrikkeljaar");
    }
    else
    {
        Console.WriteLine($"{jaar} is geen schrikkeljaar");
    }
}
else
{
    if (jaar % 4000 == 0)
    {
        Console.WriteLine($"{jaar} is geen schrikkeljaar");
    }
    else if (jaar % 400 == 0)
    {
        Console.WriteLine($"{jaar} is een schrikkeljaar");
    }
    else if (jaar % 100 == 0)
    {
        Console.WriteLine($"{jaar} is geen schrikkeljaar");
    }
    else if (jaar % 4 == 0)
    {
        Console.WriteLine($"{jaar} is een schrikkeljaar");
    }
    else
    {
        Console.WriteLine($"{jaar} is geen schrikkeljaar");
    }
}