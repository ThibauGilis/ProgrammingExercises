
int LeesGetal()
{
    int getal;
    do
    {
        Console.Write("Maak een keuze: ");
    } while (!int.TryParse(Console.ReadLine(), out getal));
    return getal;
}

//------------------------------------------------------

int invoer = LeesGetal();
Teller teller = new Teller();

while (invoer != 0)
{
    switch (invoer)
    {
        case 1:
            teller.Verhoog();
            break;
        case 2:
            teller.Verlaag();
            break;
        default:
            teller.Resetten();
            break;
    }

    invoer = LeesGetal();
}

Console.WriteLine(teller.ToonGegevens());