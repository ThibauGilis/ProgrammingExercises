
Dier printDieren(List<Dier> dieren, string vraag)
{
    for (int i = 0; i < dieren.Count; i++)
    {
        Console.WriteLine($"{i}. {dieren[i]}");
    }

    int keuze;
    do
    {
        Console.Write(vraag);
    } while (!int.TryParse(Console.ReadLine(), out keuze) || keuze < 0 || keuze > dieren.Count-1);
    Console.WriteLine();

    return dieren[keuze];
}
Personeelslid printPersoneel(List<Personeelslid> personeel, string vraag)
{
    for (int i = 0; i < personeel.Count; i++)
    {
        Console.WriteLine($"{i}. {personeel[i]}");
    }

    int keuze;
    do
    {
        Console.Write(vraag);
    } while (!int.TryParse(Console.ReadLine(), out keuze) || keuze < 0 || keuze > personeel.Count - 1);
    Console.WriteLine();

    return personeel[keuze];
}
DateTime wanneerVoeren()
{
    DateTime Tijd = DateTime.Today;
    int getal;
    do
    {
        Console.Write("Om hoelaat wil je de dieren voeren (hh)? ");
    } while (!int.TryParse(Console.ReadLine(), out getal) || getal < 0 || getal > 23);
    Console.WriteLine();

    Tijd = Tijd.AddHours(getal);
    return Tijd;
}

//------------------------------------------------------------------------------------------------

List<Personeelslid> personeel = FileOperations.LeesPersoneel();
List<Dier> dieren = FileOperations.LeesDieren();

Dierenverblijf Zoo = new Dierenverblijf();

do
{
    Zoo.VoegMannetjeToe(printDieren(dieren, "Welk mannetjesdier wil je toevoegen? "));
} while (Zoo.Mannetjesdier == null);
do
{
    Zoo.VoegVrouwtjeToe(printDieren(dieren, "Welk vrouwtjesdier wil je toevoegen? "));
} while (Zoo.Vrouwtjesdier == null);
do
{
    Zoo.MeldHoofdverzorgerAan(printPersoneel(personeel, "Welk personeelslid wil je aanmelden als hoofdverzorger? "));
} while (Zoo.Hoofdverzorger == null);
do
{
    Zoo.MeldHulpverzorgerAan(printPersoneel(personeel, "Welk personeelslid wil je aanmelden als hulpverzorger? "));
} while (Zoo.Hulpverzorger == null);

Zoo.DierenVoeren(wanneerVoeren());

Console.WriteLine(Zoo);

