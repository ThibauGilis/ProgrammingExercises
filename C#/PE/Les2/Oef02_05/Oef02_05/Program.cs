int landingsplaats;

Console.Write("waar is de pijl gelanden: ");
landingsplaats = int.Parse(Console.ReadLine());


if (landingsplaats == 1)
{
    Console.Write("0 punten.");
}
else if (landingsplaats == 2)
{
    Console.Write("20 punten.");
}
else if (landingsplaats == 3)
{
    Console.Write("50 punten.");
}
else
{
    Console.Write("100 punten.");
}