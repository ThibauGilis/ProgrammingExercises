string voornaam, achternaam;
int leeftijd;

Console.Write("voornaam: ");
voornaam = Console.ReadLine();
Console.Write("achternaam: ");
achternaam = Console.ReadLine();
Console.Write("leeftijd: ");
leeftijd = int.Parse(Console.ReadLine());

if (leeftijd < 18)
{
    Console.Write($"{voornaam} {achternaam}: Jeugd");
}
if (leeftijd >= 18)
{
    Console.Write($"{voornaam} {achternaam}: Volwassenen");
}
