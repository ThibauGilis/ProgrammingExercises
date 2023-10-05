int getal;

Console.Write("geef een getal: ");
getal = int.Parse(Console.ReadLine());

if (getal % 5 == 0 && getal % 11 == 0)
{
    Console.WriteLine("Deelbaar");
}
else
{
    Console.WriteLine("Niet deelbaar");
}

