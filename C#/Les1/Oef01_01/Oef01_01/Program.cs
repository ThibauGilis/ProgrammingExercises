int getal1, getal2, getal3, getal4;

Console.Write("geef getal 1: ");
getal1 = int.Parse(Console.ReadLine());
Console.Write("geef getal 2: ");
getal2 = int.Parse(Console.ReadLine());
Console.Write("geef getal 3: ");
getal3 = int.Parse(Console.ReadLine());
Console.Write("geef getal 4: ");
getal4 = int.Parse(Console.ReadLine());

int som, product;

som = getal1 + getal3;
product = getal2 + getal4;

Console.Write($"som: {som}");
Console.Write($"product: {product}");