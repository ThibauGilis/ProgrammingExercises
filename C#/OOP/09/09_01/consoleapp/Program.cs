
int KiesMenu(string[] menu)
{
    Console.WriteLine();
    for (int i = 0; i < menu.Length; i++)
    {
        Console.WriteLine($"{i}. {menu[i]}");
    }
    Console.WriteLine();
    return LeesKeuze("Maak een keuze: ", menu.Length-1);
}
int LeesKeuze(string vraag, int max, int min = 0)
{
    int getal;

    do
    {
        Console.Write(vraag);
    } while (!int.TryParse(Console.ReadLine(), out getal) || getal < min || getal > max);

    return getal;
}
double LeesGraden(string vraag)
{
    double graden;
    do
    {
        Console.Write(vraag);
    } while (!double.TryParse(Console.ReadLine(), out graden));
    return graden;
}

//--------------------------------------------------------------------------------------

string[] Menu = new string[] { "Keukenlicht", "Woonkamer", "Verwarming", "Afsluiten" };
string[] subMenuLicht = new string[] { "Aan", "Uit" };
string[] subMenuVerwarming = new string[] { "Aan", "Uit", "Temperatuur aanpassen" };

Licht keukenLicht = new Licht();
Licht woonkamerLicht = new Licht();
Verwarming verwarming = new Verwarming();
Plc plc = new Plc(keukenLicht, woonkamerLicht, verwarming);

int keuze = KiesMenu(Menu);
while (keuze != 3)
{
    switch (keuze)
    {
        case 0:
            keuze = KiesMenu(subMenuLicht);
            if (keuze == 0)
            {
                plc.DoeKeukenLichtAan();
            }
            else
            {
                plc.DoeKeukenLichtUit();
            }
            break;

        case 1:
            keuze = KiesMenu(subMenuLicht);
            if (keuze == 0)
            {
                plc.DoeWoonkamerLichtAan();
            }
            else
            {
                plc.DoeWoonkamerLichtUit();
            }
            break;

        case 2:
            keuze = KiesMenu(subMenuVerwarming);
            if (keuze == 0)
            {
                plc.ZetVerwarmingAan();
            }
            else if (keuze == 1)
            {
                plc.ZetVerwarmingUit();
            }
            else
            {
                plc.PasTemperatuurAan(LeesGraden("Welke Temp? "));
            }
            break;

        default: 
            break;
    }

    Console.WriteLine();
    Console.WriteLine(plc);

    keuze = KiesMenu(Menu);
}