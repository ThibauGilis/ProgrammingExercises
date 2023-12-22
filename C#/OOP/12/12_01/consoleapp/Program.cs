


//----------------------------------------------------------------------

string[] options = new string[] { "Alle klanten", "Klant zoeken" };

for (int i = 0; i < options.Length; i++)
{
    Console.WriteLine($"{i}. {options[i]}");
}

Console.Write("\nKeuze: ");
int keuze = int.Parse(Console.ReadLine());

switch (keuze)
{
    case 0:
        List<Klant> klanten = FileOps.KlantenInlezen("klanten.txt");
        foreach (Klant persoon in klanten)
        {
            Console.WriteLine(persoon);
        }
        break;

    case 1:
        Console.Write("\nGeef de klantennummer: ");
        int klantennummer = int.Parse(Console.ReadLine());
        try
        {
            Klant klant = FileOps.ZoekKlantViaNummer(klantennummer);
            Console.WriteLine(klant);
            Console.WriteLine("yeeeeh");
        }
        catch (KlantNietGevondenException)
        {
            Console.WriteLine(new KlantNietGevondenException(klantennummer));
        }
        break;

    default: 
        Console.WriteLine("Foute Invoer"); 
        break;
}