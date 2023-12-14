
int KiesMenu(string[] menu)
{
    for (int i = 0; i < menu.Length; i++)
    {
        Console.WriteLine($"{i+1}. {menu[i]}");
    }
    Console.WriteLine();
    return LeesKeuze("Maak een keuze: ", menu.Length);
}
int LeesKeuze(string vraag, int max, int min = 1)
{
    int getal;

    do
    {
        Console.Write(vraag);
    } while (!int.TryParse(Console.ReadLine(), out getal) || getal < min || getal > max);

    return getal;
}
string LeesInvoer(string vraag)
{
    string invoer;
    do
    {
        Console.Write(vraag);
        invoer = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(invoer));
    return invoer;
}

//-------------------------------------------------------------------------------------

string[] menu = new string[] { "Auto toevoegen", "Auto verwijderen", "Afsluiten" };
int keuze = KiesMenu(menu);
List<Auto> autos = new List<Auto>();

while(keuze != 3)
{
    string chassisnummer;
    switch (keuze)
    {
        case 1:
            chassisnummer = LeesInvoer("Geef het chassisnummer: ");
            string merk = LeesInvoer("Geef het merk: ");
            int cilinderinhoud = LeesKeuze("Geef het cilinderinhoud: ", int.MaxValue, 0);
            int pk = LeesKeuze("Geef het pk: ", int.MaxValue, 0);
            Motor motor = new Motor(cilinderinhoud, pk);
            Auto auto = new Auto(chassisnummer, merk, motor);

            if (!autos.Contains(auto))
            {
                autos.Add(auto);
            }
            break;

        case 2:
            chassisnummer = LeesInvoer("Geef het chassisnummer: ");

            foreach (Auto autoI in autos)
            {
                if (autoI.Chassisnummer == chassisnummer)
                {
                    autos.Remove(autoI);
                    break;
                }
            }

            break;

        default: 
            break;
    }

    foreach (Auto auto in autos) 
    {
        Console.WriteLine(auto);
    }

    keuze = KiesMenu(menu);
}