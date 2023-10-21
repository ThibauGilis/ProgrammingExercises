
using System.Reflection;

string rekening;

Console.Write("Geef rekening: ");
rekening = Console.ReadLine();

if ((Convert.ToInt64(rekening.Substring(0, 3) + rekening.Substring(4, 7)) % 97) == Convert.ToInt32(rekening.Substring(12, 2)))
{
    Console.WriteLine("is geldig");
}
else
{
    Console.WriteLine("is niet geldig");
}