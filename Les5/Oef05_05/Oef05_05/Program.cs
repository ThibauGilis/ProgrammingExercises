int score, totaal = 0;

for  (int i = 0; i<3; i++)
{
    do
    {
        do
        {
            Console.Write("Geef een landingsplaats: ");
        } while (!int.TryParse(Console.ReadLine(), out score));
    } while (score < 1 || 4 < score);

    switch (score)
    {
        case 1:
            break;
        case 2:
            totaal += 20;
            break;
        case 3:
            totaal += 50;
            break;
        case 4:
            totaal += 100;
            break;
    }
}

Console.WriteLine($"U hebt {totaal} punten behaald");