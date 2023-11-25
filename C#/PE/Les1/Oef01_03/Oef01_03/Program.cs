
int volwassen, kind;


Console.Write("Aantal volwassenen: ");
volwassen = int.Parse(Console.ReadLine());
Console.Write("Aantal Kinderen: ");
kind = int.Parse(Console.ReadLine());

double prijs;

prijs = Math.Floor(10 * volwassen + 7.50 * kind);

Console.WriteLine($"Totaal te betalen: {prijs}");