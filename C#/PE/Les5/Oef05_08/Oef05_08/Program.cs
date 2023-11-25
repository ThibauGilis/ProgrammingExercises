int getal, som=0, i=0;

do
{
    Console.Write("Geef een getal: ");
} while (!int.TryParse(Console.ReadLine(), out getal));

do
{
    i++;
    som += i;
} while (som < getal);

Console.WriteLine($"Er zijn {i} getallen nodig.");

