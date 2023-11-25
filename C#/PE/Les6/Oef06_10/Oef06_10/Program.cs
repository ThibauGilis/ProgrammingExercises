string naam, geslacht;
int liter;

Console.Write("Naam van klant: ");
while (!string.IsNullOrWhiteSpace(naam = Console.ReadLine()))
{
    do
    {
        Console.Write("Hoeveelheid liters getankt: ");
    } while (!int.TryParse(Console.ReadLine(), out liter));

    do
    {
        Console.Write("Geslacht van klant: ");
    } while ((geslacht = Console.ReadLine().ToLower()) != "man" && geslacht != "vrouw");


    if (liter > 25 && geslacht == "man")
    {
        Console.WriteLine($"{naam} krijgt een sleutelhanger en moet {liter*2} euro betalen!");
    }
    else if (liter > 25)
    {
        Console.WriteLine($"{naam} krijgt een bloem en moet {liter * 2} euro betalen!");
    }
    else
    {
        Console.WriteLine($"{naam} krijgt geen kado en moet {liter * 2} euro betalen!");
    }


    Console.Write("\nNaam van volgende klant: ");
}