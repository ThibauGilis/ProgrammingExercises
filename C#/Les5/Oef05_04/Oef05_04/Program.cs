int i = 0;

Console.WriteLine("Op de stoel ligt een zonnehoed en peperkoek\n");
do
{
    i++;
} while (Console.ReadLine() != "Op de stoel ligt een zonnehoed en peperkoek");

switch (i)
{
    case 1:
        Console.WriteLine("Je had 1 poging nodig!");
        break;
    default:
        Console.WriteLine($"Je had {i} pogingen nodig!");
        break;
}