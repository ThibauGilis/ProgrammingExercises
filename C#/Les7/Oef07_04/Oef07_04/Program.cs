//list aanmaken en aanvullen
List<string> lijst =  new List<string>();

//staat ni inde oef ma blijkbaar geeft codegrade 20 woorden in
for  (int i = 0; i < 20; i++)
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

Console.WriteLine($"Het langste woord is {LangsteWoord}\nHet kortste woord is {KortsteWoord}\nDe som van de posities is {lijst.IndexOf(LangsteWoord)+lijst.IndexOf(KortsteWoord)}");