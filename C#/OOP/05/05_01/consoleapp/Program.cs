
int LeesMenu(string[] menu, string vraag)
{
    for (int i = 0; i < menu.Length; i++)
    {
        Console.WriteLine($"{i+1}. {menu[i]}");
    }
    Console.WriteLine();

    return LeesGetal(vraag, 1, menu.Length);
}
int LeesGetal(string vraag, int min = 0, int max = int.MaxValue)
{
    int getal;
    do
    {
        Console.Write(vraag);
    } while (!int.TryParse(Console.ReadLine(), out getal) || getal < min || max < getal);
    Console.WriteLine();

    return getal;
}

//-----------------------------------------------------------------------------

Bankrekening bankrekening = null;
Spaarrekening spaarrekening = new Spaarrekening("BE12 3456 7890 1234");
Zichtrekening zichtrekening = new Zichtrekening("BE12 3456 7890 1234", 0);

string[] Menu = new string[] { "Spaarrekening", "Zichtrekening" };
string[] subMenu = new string[] { "Afhalen", "Storten", "Schijf rente bij", "Informatie" };

int keuze = LeesMenu(Menu, "Kies een rekening: ");
switch (keuze)
{
    case 1:
        bankrekening = spaarrekening;
        break;

    case 2:
        bankrekening = zichtrekening;
        break;

    default:
        Console.WriteLine("ERROR");
        break;
}

do
{
    keuze = LeesMenu(subMenu, "Kies een actie: ");

    switch (keuze)
    {
        case 1:
            int bedrag = LeesGetal("Hoeveel wil je afhalen? ");
            if (bankrekening.Saldo - bedrag < bankrekening.Minimum)
            {
                Console.WriteLine("Je hebt niet genoeg saldo om deze opdracht te verwerken...\n");
            }
            else
            {
                bankrekening.Afhalen(bedrag);
            }
            break;

        case 2:
            bankrekening.Storten(LeesGetal("Hoeveel wil je storten? "));
            break;

        case 3:
            if (bankrekening.Equals(spaarrekening))
            {
                spaarrekening.SchrijfRentebij();
            }
            else
            {
                Console.WriteLine("Deze optie is alleen beschikbaar bij een spaarrekening...");
            }
            break;

        case 4:
            Console.WriteLine(bankrekening);
            break;

        default:
            break;
    }
} while (keuze != 4);