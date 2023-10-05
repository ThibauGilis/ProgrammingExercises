int som = 0, lid;

for (int i = 0; i<5; i++)
{
    Console.Write($"Geef getal{i}: ");
    som += int.Parse(Console.ReadLine());
}

do
{
    Console.Write("Hoelang lid? ");
    lid = int.Parse(Console.ReadLine());
} while (lid > 5);

switch(lid)
{
    case 1:
        Console.Write($"Totaalprijs: {som - 5} euro");
        break;
    case 2:
        Console.Write($"Totaalprijs: {som - 10} euro");
        break;
    case 3:
        Console.Write($"Totaalprijs: {som - 20} euro");
        break;
    case 4:
        Console.Write($"Totaalprijs: {som - 30} euro");
        break;
    case 5:
        Console.Write($"Totaalprijs: {som - 50} euro");
        break;
}


