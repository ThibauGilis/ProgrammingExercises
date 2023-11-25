List<string> names = new List<string>();

//Codegrade checkt niet foute invoer | anders dummy checken
Console.Write("naam toevoegen? (ja/nee) ");
while ((Console.ReadLine()) == "ja")
{
    Console.Write("welke naam? ");
    names.Add(Console.ReadLine());
    Console.Write("nog een naam toevoegen? (ja/nee) ");
}

Console.Clear();
if (names.Count > 0)
{
    Console.WriteLine("Namen:");
    foreach (string name in names)
    {
        Console.WriteLine(name);
    }
}
else
{
    Console.WriteLine("Er zijn geen aanw.");
}