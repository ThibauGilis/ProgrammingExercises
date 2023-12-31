Console.BackgroundColor = ConsoleColor.Gray;
Console.ForegroundColor = ConsoleColor.DarkMagenta;
Console.Clear();
Console.Title = "Memory";

List<int> numbers = new List<int>();
Random random = new Random();
int guess, i, score = -1;

do
{
    Console.WriteLine("\n");
    score++;
    numbers.Add(random.Next(1, 10));
    Console.WriteLine($"Memorise the list: ");
    foreach (int number in numbers)
    {
        Console.WriteLine($"\t{number}");
    }
    Console.Write("\n\npress enter to continue: ");
    Console.ReadLine();
    Console.Clear();

    i = 0;
    Console.WriteLine($"\n");
    do
    {
        do
        {
            Console.Write($"number {i + 1}: ");
        } while (!int.TryParse(Console.ReadLine(), out guess));
        i++;
    } while (guess == numbers[i - 1] && i < numbers.Count());
    Console.Clear();
} while (guess == numbers[i - 1] && i == numbers.Count());

Console.WriteLine($"\n\t\t GAME OVER\n\t\t-----------\n\t\t Score: {score}");