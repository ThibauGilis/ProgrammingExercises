
using consoleapp;

int MaakKeuze(string[] menuOpties)
{
    Console.WriteLine("Opties\n" + new string('-', "Opties".Length) + "\n");
    for (int i = 0; i < menuOpties.Length; i++)
    {
        Console.WriteLine($"{i}. {menuOpties[i]}");
    }

    int keuze = LeesGetalMinMax("\nKies een optie: ", 0, menuOpties.Length-1);
    return keuze;
}

int LeesGetalMinMax(string vraag, int min, int max)
{
    int getal;
    do
    {
        getal = LeesGetal(vraag);
    } while (getal < min || getal > max);
    return getal;
}
int LeesGetal(string vraag)
{
    int getal;
    do
    {
        Console.Write(vraag);
    } while (!int.TryParse(Console.ReadLine(), out getal));
    return getal;
}

void PrintStringLijst(List<string> opties)
{
    foreach (string item in opties)
    {
        Console.WriteLine(item);
    }
}

void PrintIntLijst(List<int> opties)
{
    foreach (int item in opties)
    {
        Console.WriteLine(item);
    }
}

void PrintCombiLijst(List<string> opties, List<int> opties2)
{
    for (int i = 0; i < opties.Count; i++)
    {
        Console.WriteLine($"{opties[i]} ({opties2[i]})");
    }
}


//-----------------------------------------------------------------------------------------------------


string[] menuOpties = new string[] { "Studenten", "Scores", "Studenten met Scores" };
int keuze = MaakKeuze(menuOpties);

List<string> studenten = FileOperations.StudentenLezen();
List<int> scores = FileOperations.ScoresLezen();

switch (keuze)
{
    case 0:
        PrintStringLijst(studenten);
        break;

    case 1:
        PrintIntLijst(scores);
        break;

    case 2:
        PrintCombiLijst(studenten, scores);
        break;

    default: 
        break;
}

