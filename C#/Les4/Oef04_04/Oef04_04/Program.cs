string stijl1, stijl2, output = "";
int breedte, lengte;

Console.Write("Geef Symbool1: ");
stijl1 = Console.ReadLine();
Console.Write("Geef Symbool2: ");
stijl2 = Console.ReadLine();
Console.Write("Geef de lengte: ");
lengte = int.Parse(Console.ReadLine());
Console.Write("Geef de breedte: ");
breedte = int.Parse(Console.ReadLine());


for  (int i = 0; i < lengte; i++)
{
    for (int j = 0; j < breedte; j++)
    {
        if (i % 2 == 0)
        {
            output += stijl1;
        }
        else
        {
            output += stijl2;
        }
    }
    output += "\n";
}

Console.WriteLine(output);