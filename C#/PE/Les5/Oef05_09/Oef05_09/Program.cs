int g1 = (g1 = int.Parse(Console.ReadLine())) < 0 ? -1 * g1: g1, g2 = (g2 = int.Parse(Console.ReadLine())) < 0 ? -1 * g2: g2;

do
{
    if (g1 > g2)
    {
        g1 -= g2;
    }
    else
    {
        g2 -= g1;
    }
} while (g1 != g2);

Console.WriteLine("GGD is {0}", g1);
