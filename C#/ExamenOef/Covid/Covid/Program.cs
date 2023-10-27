using System.Runtime.Serialization;

void DrukOpEnter()
{
    Console.WriteLine("Druk op enter");
    Console.ReadLine();
    Console.Clear();
}

int LeesGetal(int min, int max)
{
    int getal;

    do
    {
        Console.Write($"Maak een keuze tussen {min} en {max}: ");
    } while (!int.TryParse(Console.ReadLine(), out getal) || getal < min || max < getal);

    return getal;
}

int BehandelBestand(int subkeuze, int maand)
{
    string BestandsNaam = $"{maand}.txt";

    if (!File.Exists(BestandsNaam))
    {
        return 0;
    }

    using(StreamReader Bestand =  new StreamReader(BestandsNaam))
    {
        int getal, som = 0;

        while (!Bestand.EndOfStream)
        {
            string[] data = Bestand.ReadLine().Split(';');
            som += int.TryParse(data[subkeuze], out getal)? getal: 0;
        }

        return som;
    }
}

void DrukResultaat(int subkeuze, int waarde)
{
    Console.WriteLine($"\nTotaal aantal {(subkeuze == 0? "besmettingen": "sterfgevallen")} {waarde}");
}

void PrintMenu(string soort, string[] Opties)
{
    Console.WriteLine(soort);
    for (int i = 0; i < Opties.Length; i++)
    {
        Console.WriteLine($"{i}: {Opties[i]}");
    }
}

//-------------------------------------------------------------
// PROGRAM ----------------------------------------------------
//-------------------------------------------------------------

string[] Menu = new string[] {"stoppen", "Maandtotaal opvragen", "Jaartotaal opvragen"};
string[] SubMenu = new string[] { "Aantal besmettingen", "Aantal sterfgevallen"};
int keuze, periode;

PrintMenu("\nMenu:", Menu);
keuze = LeesGetal(0, Menu.Length - 1);

while (keuze != 0)
{
    switch(keuze)
    {
        case 1:
            Console.WriteLine("\nSelecteer een maand:");
            periode = LeesGetal(1, 12);

            PrintMenu("\nSubMenu:", SubMenu);
            keuze = LeesGetal(0, SubMenu.Length - 1);

            DrukResultaat(keuze, BehandelBestand(keuze, periode));
            DrukOpEnter();
            break;

        case 2:
            PrintMenu("\nSubMenu:", SubMenu);
            keuze = LeesGetal(0, SubMenu.Length - 1);

            int resultaat = 0;
            for (int i = 1; i <= 12; i++)
            {
                resultaat += BehandelBestand(keuze, i);
            }

            DrukResultaat(keuze, resultaat);
            DrukOpEnter();
            break;

        default:
            break;
    }

    PrintMenu("\nMenu:", Menu);
    keuze = LeesGetal(0, Menu.Length - 1);
}

DrukOpEnter();
