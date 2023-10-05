using System.ComponentModel.Design;
using System.Runtime.Serialization;

int getal1, getal2;

Console.Write("geef een getal: ");
getal1 = int.Parse(Console.ReadLine());
Console.Write("geef een getal: ");
getal2 = int.Parse(Console.ReadLine());

int verschil;

if (getal1 > getal2)
{
    Console.WriteLine($"{getal1} - {getal2} = {getal1 - getal2}");
}
else
{
    Console.WriteLine($"{getal2} - {getal1} = {getal2 - getal1}");
}




