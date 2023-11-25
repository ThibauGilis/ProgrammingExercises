Console.Title = "r0956399";
Console.BackgroundColor = ConsoleColor.Blue;
Console.ForegroundColor = ConsoleColor.White;
Console.Clear();

string speler, pokemon;
int HP;
bool pokemonKiezen;

do
{
    Console.Write("Wil je een pokemon kiezen? ");
} while (!bool.TryParse(Console.ReadLine(), out pokemonKiezen));

while (pokemonKiezen)
{
    do
    {
        Console.Write("Naam? ");
        speler = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(speler));

    do
    {
        Console.Write("Welke pokemon wil je (charmander, squirtle, bulbasaur)? ");
        pokemon = Console.ReadLine().ToLower();
    } while (pokemon != "charmander" && pokemon != "squirtle" && pokemon != "bulbasaur");

    do
    {
        Console.Write($"Hoeveel HP heeft {pokemon}? ");
    } while (!int.TryParse(Console.ReadLine(), out HP) || (HP < 0 || HP > 100));

    if (HP < 10)
    {
        Console.WriteLine($"{speler} en {pokemon} ({HP}/{HP}) veel success! 1...");
    }
    else if (HP < 70)
    {
        Console.WriteLine($"{speler} en {pokemon} ({HP}/{HP}) veel success! 2...");
    }
    else
    {
        Console.WriteLine($"{speler} en {pokemon} ({HP}/{HP}) veel success! 3...");
    }

    do
    {
        Console.Write("Wil je een pokemon kiezen? ");
    } while (!bool.TryParse(Console.ReadLine(), out pokemonKiezen));
}