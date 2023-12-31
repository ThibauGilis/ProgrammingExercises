// 40 mensen speelde 3 games 
//toon de lijst van spelers en laat de gebruiker er 1 uitkiezen (zet ze per 8 op een rij, 5 rijen)
//vraag de gebruiker in welke game de punten worden ingelezen
//laat zien of deze speler lager of hoger scored dan het gemiddelde
//laat zien op welke positie deze speler stond in de ranks

string ToonEnKiesSpelers()
{
    string[] Data = new string[2];
    string name, output = "";
    int i = 0;

    using (StreamReader Bestand = new StreamReader("Spelers.txt"))
    {
        while(!Bestand.EndOfStream)
        {
            i++;
            output += $" {Bestand.ReadLine()},";
            if (i % 8 == 0)
            {
                output += "\n";
            }
        }
    }

    do
    {
        Console.Clear();
        Console.WriteLine($"\tTournament Spelers\n{new string('-', 34)}\n{output}");
        Console.Write("Kies een speler: ");
        name = Console.ReadLine().ToLower();
    } while (string.IsNullOrWhiteSpace(name) || !output.ToLower().Contains($"{name}"));

    return name;
}

string KiesBestand()
{
    string invoer;
    do
    {
        Console.Write("Welke game? Kies tussen Tetris, DonkeyKong of Pacman: ");
        invoer = Console.ReadLine().ToLower();
    } while (invoer != "tetris" && invoer != "donkeykong" && invoer != "pacman");
    return invoer;
}





int TelPunten()
{
    int punten = 0;

    return punten;
}


//--------------------------------------------------------------

Console.WriteLine(ToonEnKiesSpelers());
