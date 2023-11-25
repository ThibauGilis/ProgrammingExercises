

int g1, g2, g3;
string lettercode, cijfercode;

Console.Write("geef getal1: ");
g1 = int.Parse(Console.ReadLine());
Console.Write("geef getal2: ");
g2 = int.Parse(Console.ReadLine());
Console.Write("geef getal3: ");
g3 = int.Parse(Console.ReadLine());
Console.Write("geef lettercode: ");
lettercode = Console.ReadLine().ToUpper();
Console.Write("geef cijfercode: ");
cijfercode = Console.ReadLine();

switch (lettercode+cijfercode)
{
    case "A1":
        Console.WriteLine($"{g1} + {g2} = {g1 + g2}");
        break;
    case "A2":
        Console.WriteLine($"{g2} + {g3} = {g2 + g3}");
        break;
    case "A3":
        Console.WriteLine($"{g1} + {g3} = {g1 + g3}");
        break;
    case "B1":
        Console.WriteLine($"{g1} - {g2} = {g1 - g2}");
        break;
    case "B2":
        Console.WriteLine($"{g2} - {g3} = {g2 - g3}");
        break;
    case "B3":
        Console.WriteLine($"{g1} - {g3} = {g1 - g3}");
        break;
    default:
        break;
}

