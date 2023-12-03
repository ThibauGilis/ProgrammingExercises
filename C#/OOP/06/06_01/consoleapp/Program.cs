
int LeesInvoer(string[] kanalen)
{
    string invoer;
    do
    {
        Console.Write("Van welk kanaal wil je het nummer tonen? ");
        invoer = Console.ReadLine().ToLower();
    } while (!kanalen.Contains(invoer));
    return Array.IndexOf(kanalen, invoer);
}

//--------------------------------------------------------------------------------

string[] Kanalen = new string[] { "Een", "Canvas", "VTM", "2BE", "Vier" };

List<TvKanaal> tvKanaals = new List<TvKanaal>();
for (int i = 0; i < Kanalen.Length; i++)
{
    Console.WriteLine(Kanalen[i]);
    Kanalen[i] = Kanalen[i].ToLower();
    tvKanaals.Add(new TvKanaal(i+1, Kanalen[i]));
}
Console.WriteLine();

Console.WriteLine(tvKanaals[LeesInvoer(Kanalen)]);


