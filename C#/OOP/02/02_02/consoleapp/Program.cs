Bmi Bmi = new Bmi();

Bmi.Naam = Console.ReadLine();
Bmi.Gewicht = double.Parse(Console.ReadLine());
Bmi.Lengte = double.Parse(Console.ReadLine());

Console.WriteLine(Bmi.ToonGegevens());