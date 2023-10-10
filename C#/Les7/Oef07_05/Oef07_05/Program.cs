List<int> numbers = new List<int>();

do
{
    Console.Write("Geef een Getal: ");
    numbers.Add(int.Parse(Console.ReadLine()));
} while (numbers.Last() != 0);

numbers.Sort();
numbers.Remove(0);

Console.WriteLine($"Statistieken:\nHoogste cijfer: {numbers.Max()}\nLaagste cijfer: {numbers.Min()}\nGemiddelde: {Math.Floor(numbers.Average())}");