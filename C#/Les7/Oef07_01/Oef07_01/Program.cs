int AantalPositief = 0, som = 0;
string invoer;
List<int> numbers = new List<int>();

Console.Write("Geef een getal: ");
while (!string.IsNullOrWhiteSpace(invoer = Console.ReadLine()))
{
    if (int.TryParse(invoer, out int getal))
    {
        numbers.Add(getal);
    }
    Console.Write("Geef een getal: ");
}

foreach (int number in numbers)
{
    if (number > 0)
    {
        AantalPositief++;
    }
    else if (number < 0)
    {
        som += number;
    }
}

Console.WriteLine($"Aantal positief: {AantalPositief}\nNegatieve som: {som}");