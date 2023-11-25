
//declaratie
string naam, geslacht, aanspreektitel;
int leeftijd;
//scherminstellingen wijzigen
Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.Clear();
Console.Title = "Voorbeeld 1";

//Data inlezen
Console.Write("Geef uw naam: ");
naam = Console.ReadLine();

Console.Write("{0}, wat is uw lijftijd? ", naam.ToUpper());
leeftijd = Convert.ToInt32(Console.ReadLine());

Console.Write("\n" + naam.ToLower() + ", bent u een man of een vrouw? (Vul \"m\",\"M\",\"v\" of \"V\" in): ");
geslacht = Console.ReadLine();


//Bewerkingen uitvoeren
if (leeftijd < 25)
{
    if (geslacht == "M" || geslacht == "m")
    {
        aanspreektitel = "jongeheer";
    }
    else
    {
        aanspreektitel = "juffrouw";
    }
}
else
{
    if (geslacht == "M" ||  geslacht == "m")
    {
        aanspreektitel = "meneer";
    }
    else
    {
        aanspreektitel = "mevrouw";
    }
}

//Resultaat
Console.WriteLine("\n\tDag {0} {1}", aanspreektitel, naam);

//Wachten op enter
Console.WriteLine();
Console.Write("Druk op enter om verder te gaan!");
Console.ReadLine();