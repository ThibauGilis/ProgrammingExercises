
string PrintMenu(string vraag, List<string> Opties)
{
    for (int i = 0; i < Opties.Count; i++)
    {
        Console.WriteLine($"{i}. {Opties[i]}");
    }
    Console.WriteLine();

    return Opties[LeesGetal(vraag, 0, Opties.Count - 1)];
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
bool Slagroom(string vraag)
{
    string invoer;
    do
    {
        Console.Write(vraag);
        invoer = Console.ReadLine();
    } while (invoer != "ja" && invoer != "nee");

    return invoer == "ja"? true: false;
}

// ----------------------------------------------------------

List<string> Nagerecht = new List<string>() { "Donut", "Koffie" };
List<string> Siropen = FileOperations.LeesOpties(FileOperations.BestandSiropen);
List<string> Toppingen = FileOperations.LeesOpties(FileOperations.BestandToppings);

switch (PrintMenu("Geef een optie op: ", Nagerecht))
{
    case "Donut":
        List<string> Glazuren = FileOperations.LeesOpties(FileOperations.BestandGlazuren);
        List<string> Vullingen = FileOperations.LeesOpties(FileOperations.BestandVullingen);
        Donut donut = new Donut(PrintMenu("Kies een siroop: ", Siropen), PrintMenu("Kies een topping: ", Toppingen), PrintMenu("Kies een glazuur: ", Glazuren), PrintMenu("Kies een vulling: ", Vullingen));
        Console.WriteLine($"Bedankt voor uw bestelling!\n\nUw bestelling:\n\n{donut.ToonOverzicht()}");
        break;

    case "Koffie":
        List<string> Smaken = FileOperations.LeesOpties(FileOperations.BestandSmaken);
        Koffie koffie = new Koffie(PrintMenu("Kies een siroop: ", Siropen), PrintMenu("Kies een topping: ", Toppingen), PrintMenu("Kies een smaak: ", Smaken), Slagroom("Wenst u slagroom: "));
        Console.WriteLine($"Bedankt voor uw bestelling!\n\nUw bestelling:\n\n{koffie.ToonOverzicht()}");
        break;

    default:
        Console.WriteLine("ERROR");
        break;
}