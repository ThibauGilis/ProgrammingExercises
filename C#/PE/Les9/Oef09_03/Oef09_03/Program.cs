//----------------------------------------------------------------
//Zonder string methodes -----------------------------------------
//----------------------------------------------------------------

/*string woord, droow = "";

Console.Write("Geef woord: ");
woord = Console.ReadLine();

foreach (char letter in woord)
{
    droow = letter + droow;
}

if (woord == droow)
{
    Console.WriteLine($"{woord} is een palindroom");
}
else
{
    Console.WriteLine($"{woord} is geen palindroom");
}*/



//----------------------------------------------------------------
//Gebruik maken van .Reverse() -----------------------------------
//----------------------------------------------------------------


Console.Write("Geef woord: ");
string woord = Console.ReadLine();

// string.Reverse geeft een IEnumerable<char> en kan niet zomaar omgezet worden in een string dus vormen we het eerst om in een array
// new string() andere parameters dan gwn ('char', aantal herhalingen). hier pakken we een deel van de "char array" en maken we een string
// new string( char[], Startwaarde, Lengte ) | 1. moet een array zijn? 2. begin index (0 tot karakters.length-1) 3. hoeveelheid characters
switch (woord == new string(woord.Reverse().ToArray()))   
{
    case true: Console.WriteLine($"{woord} is een palindroom"); break;

    default: Console.WriteLine($"{woord} is geen palindroom"); break;
}


