string voornaam, naam;
int hobby;

do
{
    Console.Write("Wat is je naam? ");
    naam = Console.ReadLine();
} while (naam == "");

do
{
    Console.Write("Wat is je voornaam? ");
    voornaam = Console.ReadLine();
} while (voornaam == "");

do
{
    Console.Write("Wat is je hobby? ");
} while (!int.TryParse(Console.ReadLine(), out hobby));

if (hobby == 8)
{
    Console.WriteLine($"Wij raden niets aan.");
}
else
{
    do
    {
        switch (hobby)
        {
            case 1:
                Console.WriteLine("Wij raden \"Anna\" aan.");
                break;
            case 2:
                Console.WriteLine("Wij raden \"Knippie\" aan.");
                break;
            case 3:
                Console.WriteLine("Wij raden \"VtWonen\" aan.");
                break;
            case 4:
                Console.WriteLine("Wij raden \"Voetbal International\" aan.");
                break;
            case 5:
                Console.WriteLine("Wij raden \"Wandelen & Fietsen\" aan.");
                break;
            case 6:
                Console.WriteLine("Wij raden \"Zoom NL\" aan.");
                break;
            case 7:
                Console.WriteLine("Wij raden \"Runners\" aan.");
                break;
            default:
                break;
        }

        do
        {
            Console.Write("Wat is je hobby? ");
        } while (!int.TryParse(Console.ReadLine(), out hobby));
    } while (hobby != 8);
}