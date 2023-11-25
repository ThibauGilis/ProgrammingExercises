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

string ReadSymbol(string compareSymbol = "")
{
    string invoer;
    do
    {
        Console.Write("geef symbool: ");
        invoer = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(invoer) || invoer == compareSymbol);
    return invoer;
}

string MakeLine(string symbol, int width)
{
    string lijn = "";
    for (int i = 0; i < width; i++)
    {
        lijn += symbol;
    }

    return lijn;
}

string CreateScarf(string Line1, string Line2, int length)
{
    string sjaal = ""; 
    for (int i = 0; i < length; i++)
    {
        sjaal += "\n" + (i % 2 == 0 ? Line1 : Line2);
    }
    return sjaal;
}

//------------------------------------------------------------------------------------------------

int lengte, breedte;
string type1, type2;

type1 = ReadSymbol();
type2 = ReadSymbol(type1);
lengte = ReadNumber();
breedte = ReadNumber();

Console.WriteLine(CreateScarf(MakeLine(type1, breedte),MakeLine(type2, breedte), lengte));