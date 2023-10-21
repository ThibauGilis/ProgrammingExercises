string cijfers;
int som = 0;

Console.Write("Geef getal: ");
cijfers = Console.ReadLine();

for (int i = 0; i < cijfers.Length; i++)
{
    som += int.Parse(cijfers.Substring(i, 1));
}

Console.WriteLine(som);