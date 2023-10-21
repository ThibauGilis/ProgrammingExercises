//list aanmaken en aanvullen
List<string> lijst = new List<string>();

//staat ni inde oef ma blijkbaar geeft codegrade 20 woorden in
for (int i = 0; i < 20; i++)
{
    lijst.Add(Console.ReadLine());
}

//bepalen van het langste en kortste woord 
string LangsteWoord = "", KortsteWoord = lijst[0];

foreach (string s in lijst)
{
    if (s.Count() > LangsteWoord.Count())
    {
        LangsteWoord = s;
    }
    else if (s.Count() < KortsteWoord.Count())
    {
        KortsteWoord = s;
    }
}

Console.WriteLine($"Het langste woord is {LangsteWoord}\nHet kortste woord is {KortsteWoord}\nDe som van de posities is {lijst.IndexOf(LangsteWoord) + lijst.IndexOf(KortsteWoord)}");




//--------------------------------------------------------------------------------
// met ARRAY ipv list ------------------------------------------------------------
//--------------------------------------------------------------------------------


/*//  array van lengte 20 aanmaken
string[] lijst = new string[20];

//  omdat codegrade een vast aantal inputs geeft kunnen we een array gebruiken
for (int i = 0; i < lijst.Length; i++)
{
    lijst[i] = Console.ReadLine();
}

//  bepalen van het langste en kortste woord 
string LangsteWoord = "", KortsteWoord = lijst[0];

foreach (string s in lijst)
{
    if (s.Length > LangsteWoord.Length)
    {
        LangsteWoord = s;
    }
    else if (s.Length < KortsteWoord.Length)
    {
        KortsteWoord = s;
    }
}

Console.WriteLine($"Het langste woord is {LangsteWoord}\nHet kortste woord is {KortsteWoord}\nDe som van de posities is {Array.IndexOf(lijst, LangsteWoord) + Array.IndexOf(lijst, KortsteWoord)}");*/