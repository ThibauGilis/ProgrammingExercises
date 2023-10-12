string klant, invoer;
Console.Title = "06 dowhile - Oplossing 07";
Console.Write("Naam klant: ");
klant = Console.ReadLine();

while (klant != "")
{
    int totaal = 0;

    Console.Write("Donut of koffie? ");
    invoer = Console.ReadLine();

    while (invoer != "")
    {
        if (invoer.ToLower() == "koffie")
        {
            totaal += 3;
        }
        else if (invoer.ToLower() == "donut")
        {
            totaal += 2;
        }

        Console.Write("Donut of koffie? ");
        invoer = Console.ReadLine();
    }
    string rekeningTitel = $"Rekening {klant}";
    Console.WriteLine($"{rekeningTitel}\n{new string('*', rekeningTitel.Length)}\nTotaal: {totaal} euro");

    Console.Write("Naam klant: ");
    klant = Console.ReadLine();
}

Console.ReadLine();