
int score = 0;
Console.Write("Welk bestand: ");
string bestandsnaam = Console.ReadLine();

if (File.Exists(bestandsnaam))
{
    using(StreamReader Bestand = new StreamReader(bestandsnaam))
    {
        while(!Bestand.EndOfStream)
        {
            string[] Lijn = Bestand.ReadLine().Split(';');
            string resultaat = "";
            char symbool = char.Parse(Lijn[0]);
            int g1 = int.Parse(Lijn[1]), g2 = int.Parse(Lijn[2]);

            switch (symbool)
            {
                case '+':
                    resultaat += g1 + g2;
                    Console.Write($"{g1} + {g2} = ");
                    break;

                case '-':
                    resultaat += g1 - g2;
                    Console.Write($"{g1} - {g2} = ");
                    break;

                case '*':
                    resultaat += g1 * g2;
                    Console.Write($"{g1} * {g2} = ");
                    break;

                case '/':
                    resultaat += g1 / g2;
                    Console.Write($"{g1} / {g2} = ");
                    break;

                default:
                    Console.WriteLine("Error");
                    break;

            }

            if (Console.ReadLine() == resultaat)
            {
                score++;
            }
        }
        Console.WriteLine($"Je scoorde {score} op 10");
    }
}
else
{
    Console.WriteLine($"{bestandsnaam} bestaat niet");
}