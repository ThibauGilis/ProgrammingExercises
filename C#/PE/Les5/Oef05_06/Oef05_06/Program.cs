int number, guess, aantal=0;

do
{
    Console.Write("Geef het te raden getal: ");
} while (!int.TryParse(Console.ReadLine(), out number) || 100 < number);

do
{
    do
    {
        aantal++;
        Console.Write($"Gok het getal tussen {number-5} en {number+5}: ");
    } while (!int.TryParse(Console.ReadLine(), out guess) || guess < number-5 || number + 5 < guess);

} while (guess != number);

Console.WriteLine($"Je hebt {aantal} keer geraden!");

