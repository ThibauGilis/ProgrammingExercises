int C, F;

Console.Write("Geef het aantal graden celcius: ");
C = int.Parse(Console.ReadLine());

F = C * 9 / 5 + 32;

Console.WriteLine($"Fahrenheit: {F}");