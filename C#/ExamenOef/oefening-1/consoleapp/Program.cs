string ploegnaam, invoer;
int wins = 0, gelijk = 0;

Console.Write("Geef de naam van de ploeg: ");
ploegnaam = Console.ReadLine();

for  (int i = 1; i<=5; i++)
{
    do
    {
        Console.Write($"Uitslag voor wedstrijd {i}: (W,V,G) ");
        invoer = Console.ReadLine().ToUpper();
    } while (invoer != "W" && invoer != "V" && invoer != "G");

    switch (invoer)
    {
        case "W":
            wins++;
            break;
        case "G":
            gelijk++;
            break;
        default:
            break;
    }
}

Console.WriteLine($"{ploegnaam} won {wins} keer, verloor {5-wins-gelijk} keer " +
    $"en speelde {gelijk} keer gelijk.\nDit levert {wins*3 + (gelijk)} punten op");