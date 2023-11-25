
/*
string woord = "boom";

for (int i = 0; i < woord.Length; i++)
{
    string letter = woord.Substring(i, 1);
    Console.WriteLine("Letter: " + letter);
}

Console.WriteLine();
for (int i = 0; i < woord.Length; i++)
{
    string letter = woord.Substring(i);
    Console.WriteLine($"Vanaf pos {i}: {letter}");
}

Console.WriteLine();
//-------------------------------------------------

for (int i = 0; i < woord.Length; i++)
{
    string letter = woord.Insert(i, "|");
    Console.WriteLine($"Vanaf pos {i}: {letter}");
}

Console.WriteLine();
//-------------------------------------------------

Console.WriteLine(woord.Replace("o", "a"));

Console.WriteLine();
//-------------------------------------------------

for (int i = 0;i < woord.Length; i++)
{
    int pos = woord.IndexOf("o", i);
    Console.WriteLine($"startpos {i}: pos {pos}");
}

Console.WriteLine();
//-------------------------------------------------
*/

string zin;
int aantal = 0;

Console.WriteLine("Geef een zin: ");
zin = Console.ReadLine();

for  (int i = 0; i< zin.Length; i++)
{
    string letter = zin.Substring(i, 1).ToLower();
    switch(letter)
    {
        case "a":
        case "e":
        case "i":
        case "o":
        case "u":
            aantal++;
            break;
        default:
            break;

    }
}

Console.WriteLine($"Aantal klinkers: {aantal}");