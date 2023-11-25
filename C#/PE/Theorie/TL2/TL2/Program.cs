
int getal;

Console.Write("Geef een getal: ");
getal = int.Parse(Console.ReadLine());

if (getal < 0)
{
    Console.WriteLine("Het getal is negatief.");
}
else
{
    Console.WriteLine("Het getal is positief.");
}