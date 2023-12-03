
int LeesMenu(string[] menu, string vraag)
{
    for (int i = 0; i < menu.Length; i++)
    {
        Console.WriteLine($"{i}. {menu[i]}");
    }
    Console.WriteLine();

    return LeesGetal(vraag, 0, menu.Length-1);
}
int LeesGetal(string vraag, int min, int max)
{
    int getal;
    do
    {
        Console.Write(vraag);
    } while (!int.TryParse(Console.ReadLine(), out getal) || getal < min || max < getal);
    Console.WriteLine();

    return getal;
}
double LeesGetalDouble(string vraag)
{
    double getal;
    do
    {
        Console.Write(vraag);
    } while (!double.TryParse(Console.ReadLine(), out getal));
    Console.WriteLine();

    return getal;
}

//---------------------------------------------------------------------

Audi audi = new Audi("1-lvn-568", 25000, 7500,25);
Volkswagen volkswagen = new Volkswagen("1-sej-454", 100000, 5500, 10);
Bmw bmw = new Bmw("1-hbj-298", 500, 12500, 44);
Auto auto = null;

string[] Menu = new string[] { "Stoppen", "Audi (1-lvn-568)", "Volkswagen (1-sej-454)", "Bmw (1-hbj-298)" };
int keuze = LeesMenu(Menu, "Kies een auto: ");

while (keuze != 0)
{
    switch (keuze)
    {
        case 1:
            auto = audi;
            break;

        case 2:
            auto = volkswagen;
            break;

        case 3:
            auto = bmw;
            break;

        default:
            Console.WriteLine("ERROR");
            break;
    }

    string[] submenu = new string[] { "Testrit maken", "Details tonen" };
    int subKeuze = LeesMenu(submenu, "Kies een actie: ");

    switch (subKeuze)
    {
        case 0:
            double aantalKM = LeesGetalDouble("Geef aantal kilometer: ");
            auto.Rijden(aantalKM);
            break;

        case 1:
            Console.WriteLine(auto + "\n");
            break;

        default:
            Console.WriteLine("ERROR");
            break;
    }

    keuze = LeesMenu(Menu, "Kies een auto: ");
}
