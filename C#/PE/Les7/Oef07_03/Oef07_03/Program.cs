List<int> numbers = new List<int>();
int number;

Console.Write("welk getal toevoegen? ");
while (int.TryParse(Console.ReadLine(), out number))
{
    numbers.Add(number);
    Console.Write("welk getal toevoegen? ");
}

numbers.Sort();
Console.WriteLine($"Laagste getal: {numbers.First()}\nHoogste getal: {numbers.Last()}");
