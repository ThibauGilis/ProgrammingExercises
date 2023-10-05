int getal;
string output="";

do
{
    Console.Write("Van welk getal wil je de maaltafel? ");
} while (!int.TryParse(Console.ReadLine(), out getal));

while (getal != 0)
{
    for (int i = 1; i <= 10; i++)
    {
        output += i + " x " + getal + " = " + (i*getal) +"\n";
    }


    do
    {
        Console.Write("Van welk getal wil je nog de maaltafel? ");
    } while (!int.TryParse(Console.ReadLine(), out getal));
}

Console.WriteLine(output);