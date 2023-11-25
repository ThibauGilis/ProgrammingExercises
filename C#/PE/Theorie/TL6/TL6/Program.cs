// declaratie
string naam, adres;

int aantalEtiketten;

// scherminstellingen
Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.Clear();
Console.Title = "Voorbeeld 1";

//-------------------------------
// PR 1: inlezen kritieke waarde-
//-------------------------------

Console.Write("Hoeveel etiketten wenst u dadelijk te drukken (0= stop)? ");
aantalEtiketten = int.Parse(Console.ReadLine());

//-------------------------------
// PR 2: inlezen kritieke waarde-
//-------------------------------

while (aantalEtiketten != 0)
{
    //-------------------------------
    // PR 3: inlezen kritieke waarde-
    //-------------------------------
    // inlezen andere inputvelden
    Console.Write("\nGeef de gewenste voor- en familienaam op: ");
    naam = Console.ReadLine();

    Console.Write("\nGeef het adres op van {0}: ", naam.ToUpper());
    adres = Console.ReadLine();

    Console.Clear();

    //afdrukken gevraagde adresetiketten

    for (int i = 0; i < aantalEtiketten; i++)
    {
        Console.WriteLine("\n{0}", new string('-', 30));
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(naam);
        Console.WriteLine(adres);
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("{0}", new string('-', 30));
    }
    //-------------------------------
    // PR 3: inlezen kritieke waarde-
    //-------------------------------

    Console.Write("\nHoeveel etiketten wenst u nog te drukken (0 = stop)? ");
    aantalEtiketten = Convert.ToInt32(Console.ReadLine());
}