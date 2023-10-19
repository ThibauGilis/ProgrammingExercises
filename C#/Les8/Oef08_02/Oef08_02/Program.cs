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

string ReadSymbol(string compareSymbol)
{
    string invoer;
    do
    {
        invoer = Console.ReadLine();
    } while (!string.IsNullOrWhiteSpace(invoer) || invoer == compareSymbol);
    return invoer;
}