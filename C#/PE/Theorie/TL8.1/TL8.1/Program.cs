
// VB: 1
/*
int LeesGetal(string vraag)
{
    int getal;
    do
    {
        Console.Write(vraag);
    } while (!int.TryParse(Console.ReadLine(), out getal));
    return getal;
}

int LeesGetalMinMax(string vraag, int min, int max)
{
    int getal;
    do
    {
        getal = LeesGetal(vraag);
    } while (getal < min || max < getal);
    return getal;
}

Console.WriteLine($"Getal = {LeesGetalMinMax("Geef een getal (0-5): ", 0, 5)}");
*/
//--------------------------------------------------------------------------------------------------

// VB: 2
/*
int LeesGetalMin(string vraag, int min)
{
    int getal;
    return LeesGetalMinMax(vraag, min, int.MaxValue);
}

Console.WriteLine($"Getal = {LeesGetalMin("Geef een getal groter dan -1: ", 0)}");
*/
//--------------------------------------------------------------------------------------------------

// VB: 3
void PrintMenu(string[] menuOpties)
{
    int i = 0;
    foreach (string optie in menuOpties)
    {
        i++;
        Console.WriteLine($"{i}: {optie}");
    }
}

string KiesMenu(string[] menuOpties)
{
    string invoer;
    do
    {
        PrintMenu(menuOpties);
        Console.Write("\nKies een optie: ");
        invoer = Console.ReadLine().ToLower();
    } while (!menuOpties.Contains(invoer));
    return invoer;
}



string[] menu = new string[] { "eten", "drinken", "niks" };
Console.WriteLine("Je hebt " + KiesMenu(menu) + " gekozen.");