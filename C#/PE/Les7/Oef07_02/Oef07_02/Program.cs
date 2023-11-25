List<int> numbers = new List<int>();

Console.Write("wilt u een getal toevoegen? ");
while (Console.ReadLine() == "ja")
{
    Console.Write("welk getal? ");
    numbers.Add(int.Parse(Console.ReadLine()));
    Console.Write("wilt u nog een getal toevoegen? ");
}

//hier zou eig nog een "if" (lege lijst) moete staan ma omda codegrade da ni checked ben ik er te lui voor
Console.WriteLine($"Laagste cijfer: {numbers.Min()}\nHoogste cijfer: {numbers.Max()}\nGemiddelde: {numbers.Average()}");