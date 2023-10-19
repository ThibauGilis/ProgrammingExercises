
int ReadNumber()
{
    string invoer;
    int getal;
    do
    {
        Console.Write("geef getal: ");
        invoer = Console.ReadLine();
    } while (!int.TryParse(invoer, out getal));

    return getal;
}

string ReadLetter()
{
    string invoer;
    do
    {
        Console.Write("Geef letter: ");
        invoer = Console.ReadLine().ToUpper();
    } while (string.IsNullOrWhiteSpace(invoer) || (invoer != "A" && invoer != "B"));

    return invoer;
}

int Sum(int x, int y)
{
    return x + y;
}

int Subtract(int x, int y)
{
    return x - y;
}

void PrintResult(int n1, int n2, string operation, int result)
{
    Console.WriteLine($"{n1} {operation} {n2} = {result}");
}

int g1, g2, g3;
string lettercode, cijfercode;

g1 = ReadNumber();
g2 = ReadNumber();
g3 = ReadNumber();

lettercode = ReadLetter();
cijfercode = ReadNumber().ToString();

switch (lettercode + cijfercode)
{
    case "A1":
        PrintResult(g1, g2, "+", Sum(g1, g2));
        break;
    case "A2":
        PrintResult(g2, g3, "+", Sum(g2, g3));
        break;
    case "A3":
        PrintResult(g1, g3, "+", Sum(g1, g3));
        break;
    case "B1":
        PrintResult(g1, g2, "-", Subtract(g1, g2));
        break;
    case "B2":
        PrintResult(g2, g3, "-", Subtract(g2, g3));
        break;
    case "B3":
        PrintResult(g1, g3, "-", Subtract(g1, g3));
        break;
    default:
        break;
}


/*

int x = 0, y = 0, result = 0;
string operation = "";

switch (lettercode + cijfercode)
{
    case "A1":
        x = g1;
        y = g2;
        operation = "+";
        result = Sum(x, y);
        break;
    case "A2":
        x = g2;
        y = g3;
        operation = "+";
        result = Sum(x, y);
        break;
    case "A3":
        x = g1;
        y = g3;
        operation = "+";
        result = Sum(x, y);
        break;
    case "B1":
        x = g1;
        y = g2;
        operation = "-";
        result = Subtract(x, y);
        break;
    case "B2":
        x = g2;
        y = g3;
        operation = "-";
        result = Subtract(x, y);
        break;
    case "B3":
        x = g1;
        y = g3;
        operation = "-";
        result = Subtract(x, y);
        break;
    default:
        break;
}

PrintResult(x, y, operation, result);

*/


