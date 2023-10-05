string naam, voornaam;
int hobby;

Console.Write("Wat is je voornaam? ");
voornaam = Console.ReadLine().ToLower();
Console.Write("Wat is he naam?" );
naam = Console.ReadLine().ToUpper();
Console.Write("Wat is je hobby? ");
hobby = int.Parse(Console.ReadLine());

switch (hobby)
{
    case 1:
        Console.WriteLine($"{voornaam} {naam}, tijdschrift: \"Anna\"");
        break;
    case 2:
        Console.WriteLine($"{voornaam} {naam}, tijdschrift: \"Knippie\"");
        break;
    case 3:
        Console.WriteLine($"{voornaam} {naam}, tijdschrift: \"VtWonen\"");
        break;
    case 4:
        Console.WriteLine($"{voornaam} {naam}, tijdschrift: \"Voetbal International\"");
        break;
    case 5:
        Console.WriteLine($"{voornaam} {naam}, tijdschrift: \"Wandelen & Fietsen\"");
        break;
    case 6:
        Console.WriteLine($"{voornaam} {naam}, tijdschrift: \"Zoom NL\"");
        break;
    case 7:
        Console.WriteLine($"{voornaam} {naam}, tijdschrift: \"Runners\"");
        break;
     default:
        Console.WriteLine($"{voornaam} {naam}, tijdschrift: -");
        break;
}
