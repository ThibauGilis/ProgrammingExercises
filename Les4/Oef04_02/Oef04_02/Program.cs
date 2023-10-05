string naam, output = " ";
int geluksgetal;

Console.Write("Wat is uw naam? ");
naam = Console.ReadLine();
Console.Write("Wat is uw geluksgetal? ");
geluksgetal = int.Parse(Console.ReadLine());

for  (int i = 0; i < geluksgetal; i++)
{
    output += naam + " ";
}

Console.Write($"{geluksgetal}{output}");