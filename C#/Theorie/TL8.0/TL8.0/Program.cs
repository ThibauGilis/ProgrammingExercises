
using System.Runtime.Serialization;

bool IsNegative(int number)
{
    return number <= 0; 
}

int ReadNumber()
{
    int getal;
    do
    {
        Console.Write("Geef een getal: ");
    } while (!int.TryParse(Console.ReadLine(), out getal));
    return getal;
}

int sum = 0, number = ReadNumber();

while (!IsNegative(number))
{
    sum += number;
    number = ReadNumber();
}

Console.WriteLine($"Totaal: {sum}");