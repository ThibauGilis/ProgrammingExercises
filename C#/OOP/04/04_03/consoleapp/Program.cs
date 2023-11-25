int Leesgetal(string vraag, int min = int.MinValue, int max = int.MaxValue)
{
    int getal;
    do
    {
        Console.Write(vraag);
    } while (!int.TryParse(Console.ReadLine(), out getal) || getal < min || max < getal);
    Console.WriteLine();
    return getal;
}

string LeesString(string vraag)
{
    string invoer;
    do
    {
        Console.Write(vraag);
    } while (string.IsNullOrWhiteSpace(invoer = Console.ReadLine()));
    return invoer;
}

//------------------------------------------------------------------------

string[] Menu = new string[] { "Paperback", "Audioboek" };
for  (int i = 0; i < Menu.Length; i++)
{
    Console.WriteLine($"{i+1}. {Menu[i]}");
}

switch (Leesgetal("Maak een keuze: ", 1, Menu.Length))
{
    case 1:
        Paperback paperback = new Paperback(
            LeesString("Titel: "),
            LeesString("Auteur: "),
            Leesgetal("Bladzijden: "),
            Leesgetal("Bladzijden per dag: ")
            );

        Console.WriteLine(paperback.ToonGegevens());
        break;

    case 2:
        Audioboek audioboek = new Audioboek(
            LeesString("Titel: "),
            LeesString("Auteur: "),
            LeesString("Verteller: "),
            Leesgetal("Bladzijden: "),
            Leesgetal("Bladzijden per dag: ")
            );

        Console.WriteLine(audioboek.ToonGegevens());
        break;

    case 3:
        Console.WriteLine("ERROR");
        break;
}

