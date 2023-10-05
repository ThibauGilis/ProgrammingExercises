int teller, noemer, deling;

Console.Write("geef de teller: ");
teller = int.Parse(Console.ReadLine());
Console.Write("geef de noemer: ");
noemer = int.Parse(Console.ReadLine());

if (noemer != 0)
{
    Console.WriteLine($"{teller} / {noemer} = {teller / noemer}");
}
else
{
    Console.WriteLine($"{teller} is niet deelbaar door 0.");
}