string naam, leeftijd;
DateTime geboortedatum;
Boolean binnen;

Console.Write("Naam van kat? ");
while (!string.IsNullOrWhiteSpace(naam = Console.ReadLine()))
{
    do
    {
        Console.Write("Wanneer is de kat geboren? (*/*/*) ");
    } while (!DateTime.TryParse(Console.ReadLine(), out geboortedatum));

    do
    {
        Console.Write("Is het een binnen kat? (True/False) ");
    } while (!Boolean.TryParse(Console.ReadLine(), out binnen));

    Console.WriteLine($"{naam} is een {((DateTime.Now - geboortedatum).Days < 365 ? "kitten" : "volwassen kat")} die {(binnen ? "binnen": "buiten")} vertoeft!");
    Console.Write("Naam van volgende kat? ");
}
