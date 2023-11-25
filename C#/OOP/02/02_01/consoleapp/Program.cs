Vierkant Vierkant = new Vierkant();
Vierkant.Zijde = int.Parse(Console.ReadLine());

Console.WriteLine("Teken:");
Console.WriteLine(Vierkant.Teken());
Console.WriteLine();
Console.WriteLine($"Omtrek: {Vierkant.Omtrek()}");
Console.WriteLine($"Oppervlakte: {Vierkant.Oppervlakte()}");
Console.WriteLine($"Diagonaal: {Vierkant.Diagonaal()}");
