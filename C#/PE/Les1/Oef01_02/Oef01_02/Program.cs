int btw;
double prijs, totaal;

Console.Write("geef orginele prijs: ");
prijs = double.Parse(Console.ReadLine());
Console.Write("geef btw: ");
btw = int.Parse(Console.ReadLine());

totaal = prijs * (100 + btw) / 100;

Console.Write($"Prijs inclusief BTW: {totaal}");