//----------------------------------------------------------------------------------------------
// ipv het '-' te verwijderen uit de string, twee verschillende substrings optellen ------------
//----------------------------------------------------------------------------------------------

/*string rekening;

Console.Write("Geef rekening: ");
rekening = Console.ReadLine();

if ((Convert.ToInt64(rekening.Substring(0, 3) + rekening.Substring(4, 7)) % 97) == Convert.ToInt32(rekening.Substring(12, 2)))
{
    Console.WriteLine("is geldig");
}
else
{
    Console.WriteLine("is niet geldig");
}*/

//--------------------------------------------------------------------------
// Convert.ToInt64 == long.Parse | Convert.ToInt64 == int.Parse ------------
//--------------------------------------------------------------------------

string rekening;

Console.Write("Geef rekening: ");
rekening = Console.ReadLine();
rekening = rekening.Remove(rekening.IndexOf('-'), 1);

// long = 64 bit integer | int = 32 bit integer
if ((long.Parse(rekening.Substring(0, 10)) % 97) == int.Parse(rekening.Substring(11, 2)))
{
    Console.WriteLine("is geldig");
}
else
{
    Console.WriteLine("is niet geldig");
}


