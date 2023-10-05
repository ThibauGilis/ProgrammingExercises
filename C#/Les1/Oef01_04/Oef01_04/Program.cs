int nationaal, internationaal;

Console.Write("hoeveel nationale oproepen: ");
nationaal = int.Parse(Console.ReadLine());
Console.Write("hoeveel internationale oproepen: ");
internationaal = int.Parse(Console.ReadLine());

double totaal;

totaal = (23 + (nationaal + internationaal) * 0.12) * 1.21;

Console.WriteLine($"Totaal te betalen: {totaal}");