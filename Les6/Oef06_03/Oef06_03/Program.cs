string stijl1, stijl2, ploeg, output = "";
int breedte, lengte;

do
{
    Console.Write("Welke ploeg: ");
    ploeg = Console.ReadLine();
} while (ploeg.Length < 5);

while (ploeg != "*****")
{
    Console.Write("Geef Symbool1: ");
    stijl1 = Console.ReadLine();
    Console.Write("Geef Symbool2: ");
    stijl2 = Console.ReadLine();
    do
    {
        Console.Write("Geef lengte: ");
        lengte = int.Parse(Console.ReadLine());
    } while (lengte < 4);
    do
    {
        Console.Write("Geef breedte: ");
        breedte = int.Parse(Console.ReadLine());
    } while (breedte < lengte/2);

    output += ploeg + "\n";
    for (int i = 0; i < lengte; i++)
    {
        for (int j = 0; j < breedte; j++)
            if (i % 2 == 0)
            {
                output += stijl1;
            }
            else
            {
                output += stijl2;
            }
        output += "\n";
    }

    do
    {
        Console.Write("Welke ploeg: ");
        ploeg = Console.ReadLine();
    } while (ploeg.Length < 5);
}

Console.WriteLine(output);