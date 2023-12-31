Console.BackgroundColor = ConsoleColor.Gray;
Console.ForegroundColor = ConsoleColor.DarkMagenta;
Console.Clear();
Console.Title = "Memory";

List<int> numbers = new List<int>();
Random random = new Random();
int guess, i;

do
{
    Console.WriteLine("\n");
    numbers.Add(random.Next(1, 10));
    foreach (int number in numbers)
    {
        Console.WriteLine(number);
    }
    Console.Write("\n\npress enter to continue: ");
    Console.ReadLine();
    Console.Clear();

    i = 0;
    do
    {
        do
        {
            Console.Write($"numbers {i + 1}: ");
        } while (!int.TryParse(Console.ReadLine(), out guess));
        i++;
    } while (guess == numbers[i-1] && i < numbers.Count());
    Console.Clear();
} while (guess == numbers[i-1] && i == numbers.Count());

Console.WriteLine("\n\t\tGAME OVER");