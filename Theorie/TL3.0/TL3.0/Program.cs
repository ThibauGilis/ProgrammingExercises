//Declaratie
string letter, uitvoer;

//Scherminstellingen wijzigen
Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.Clear();
Console.Title = "Voorbeeld 2";

//Data opvragen
Console.Write("Geef een letter in: ");
letter = Console.ReadLine();

//Bewerkingen uitvoeren
switch (letter.ToLower())
{
    case "a":
        uitvoer = "klinker";
        break;
    case "e":
        uitvoer = "klinker";
        break;
    case "i":
        uitvoer = "klinker";
        break;
    case "o":
        uitvoer = "klinker";
        break;
    case "u":
        uitvoer = "klinker";
        break;
    default:
        uitvoer = "medeklinker";
        break;
}

//Resultaat tonen
Console.WriteLine("\n{0} is een {1}", letter, uitvoer);

//Wachten op enter
Console.WriteLine();
Console.Write("Druk op enter om verder te gaan!");
Console.ReadLine();