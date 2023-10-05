
int g1, g2, g3;
string letter;

Console.Write("Geef getal1: ");
g1 = int.Parse(Console.ReadLine());
Console.Write("Geef getal2: ");
g2 = int.Parse(Console.ReadLine());
Console.Write("Geef getal3: ");
g3 = int.Parse(Console.ReadLine());

Console.Write("Geef letter: ");
letter = Console.ReadLine().ToLower();

switch(letter)
{
    case "a":
        Console.WriteLine($"Uitkomst: {g1 + g2 + g3}");
        break;
    case "b":
        Console.WriteLine($"Uitkomst: {g1 * g3}");
        break; 
    case "c":
        Console.WriteLine($"Uitkomst: {g3 - g2}");
        break; 
    case "d":
        if (g1 < 0)
        {
            Console.WriteLine("Foutieve invoer.");
        }
        else 
        { 
            Console.WriteLine($"Uitkomst: {Math.Sqrt(g1)}"); 
        }
        break;
    default: 
        if (g1 <= g3 && g2 <= g3)
        {
            Console.WriteLine($"Uitkomst: {g3}");
        }
        else if (g1 <= g2 && g3 <= g2)
        {
            Console.WriteLine($"Uitkomst: {g2}");
        }
        else 
        {
            Console.WriteLine($"Uitkomst: {g1}");
        }
        break;
}

