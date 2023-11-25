
int LeesGetal()
{
    int getal;
    do
    {
        Console.Write("Maak een keuze: ");
    } while (!int.TryParse(Console.ReadLine(), out getal));
    return getal;
}

//------------------------------------------------

int keuze = LeesGetal();
Televisie televisie = new Televisie();

while (keuze != 5)
{
    switch(keuze)
    {
        case 1:
            televisie.VermeerderKanaal();
            break;
        case 2:
            televisie.VerminderKanaal();
            break;
        case 3:
            televisie.VermeerderVolume();
            break;
        case 4:
            televisie.VerminderVolume();
            break;
        default:
            Console.WriteLine("ERROR");
            break;
    }
    keuze = LeesGetal();
}

Console.WriteLine(televisie.ToonGegevens());