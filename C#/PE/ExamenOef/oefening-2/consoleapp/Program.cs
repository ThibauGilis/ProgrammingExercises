string stad;
int verdieping, bedrag;
Console.WriteLine("HUURCALCULATOR\n--------------");

do
{
    Console.Write("Voor welke stad wil je de huur berekenen? " +
        "(Antwerpen - A, Gent - G, Brugge - B, Leuven - L) (\"stop\" om te stoppen): ");
    stad = Console.ReadLine().ToUpper();
} while (stad != "A" && stad != "G" && stad != "B" && stad != "L" && stad != "STOP");

while (stad != "STOP")
{
    do
    {
        Console.Write("Op welke verdieping wil je huren (0-10): ");
    } while (!int.TryParse(Console.ReadLine(), out verdieping) || verdieping < 0 || 10 < verdieping);

    bedrag = 500;

    switch (stad)
    {
        case "A":
            bedrag += 300;
            stad = "Antwerpen";
            break;
        case "G":
            bedrag += 400;
            stad = "Gent";
            break;
        case "B":
            bedrag += 400;
            stad = "Brugge";
            break;
        case "L":
            bedrag += 500;
            stad = "Leuven";
            break;
        default:
            bedrag = 0;
            stad = "";
            break;
    }

    if (verdieping == 10)
    {
        bedrag += 200;
    }
    else if (7 <= verdieping && verdieping <= 9)
    {
        bedrag += 100;
    }
    else if (4 <= verdieping && verdieping <= 6)
    {
        bedrag += 75;
    }
    else if (1 <= verdieping && verdieping <= 3)
    {
        bedrag += 50;
    }

    Console.WriteLine($"De maandelijkse huur voor {stad} op de {verdieping}e bedraagt {bedrag} euro.\n");

    do
    {
        Console.Write("Voor welke stad wil je de huur berekenen? " +
            "(Antwerpen - A, Gent - G, Brugge - B, Leuven - L) (\"stop\" om te stoppen): ");
        stad = Console.ReadLine().ToUpper();
    } while (stad != "A" && stad != "G" && stad != "B" && stad != "L" && stad != "STOP");
}
Console.WriteLine("Bedankt om de applicatie te gebruiken! ");