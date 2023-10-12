int getal, invoer, score=0;

do
{
    Console.Write("Geef een getal: ");
} while (!int.TryParse(Console.ReadLine(), out getal) || getal < 1 || 10 < getal);

for  (int i = 1; i <= 10; i++)
{
    do
    {
        Console.Write($"{i} * {getal} = ");
    } while (!int.TryParse(Console.ReadLine(), out invoer));

    if (invoer == i*getal)
    {
        score++;
    }
}

Console.WriteLine($"U heeft {score}/10 behaald!");