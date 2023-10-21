
int ReadNumber(int min, int max)
{
    int getal;

    do
    {
        Console.Write($"Geef getal ({min}-{max}): ");
    } while (!int.TryParse(Console.ReadLine(), out getal) || ( getal < min || max < getal ));

    return getal;
}

int CalculateScore(List<int> throws)
{
    int score = 0;

    foreach (int x in throws)
    {
        switch (x)
        {
            case 2: 
                score += 20;
                break;
            case 3: 
                score += 50;
                break;
            case 4: 
                score += 100;
                break;
            default: 
                break;
        }
    }

    return score;
}

void ShowScore(int score)
{
    Console.WriteLine($"U hebt {score} punten behaald!");
}




List<int> throws = new List<int>();

throws.Add(ReadNumber(1, 4));
throws.Add(ReadNumber(1, 4));
throws.Add(ReadNumber(1, 4));

ShowScore(CalculateScore(throws));
