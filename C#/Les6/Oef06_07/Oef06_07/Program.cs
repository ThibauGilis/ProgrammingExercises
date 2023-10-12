string naam, invoer;
int bedrag;

Console.Write("Geef naam: ");
naam = Console.ReadLine();

while (!string.IsNullOrWhiteSpace(naam))
{
    bedrag = 0;

    Console.Write("Koffie of Donut (\"\" = stop): ");
    while ((invoer = Console.ReadLine().ToLower()) != "")
    {
        if (invoer == "koffie")
        {
            bedrag += 3;
        }
        else if (invoer == "donut")
        {
            bedrag += 2;
        }
        Console.Write("Koffie of Donut (\"\" = stop): ");
    }

    Console.WriteLine($"Rekening {naam}\n{new string('*', naam.Length + 9)}\nTotaal: {bedrag} euro");

    Console.Write("Geef naam: ");
    naam = Console.ReadLine();
}