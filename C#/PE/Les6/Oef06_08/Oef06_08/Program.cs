string figuur;

Console.Write("Driehoek, rechthoek of cirkel? (\"\" = stop) ");
while (!string.IsNullOrWhiteSpace(figuur = Console.ReadLine().ToLower()))
{
    switch(figuur) 
    {
        case "driehoek":
            Console.Write("Geef zijde 1: ");
            int zijde1 = int.Parse(Console.ReadLine());
            Console.Write("Geef zijde 2: ");
            int zijde2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"De oppervlakte van de {figuur} = {zijde1 * zijde2 / 2}");
            break;
        case "rechthoek":
            Console.Write("Geef zijde 1: ");
            zijde1 = int.Parse(Console.ReadLine());
            Console.Write("Geef zijde 2: ");
            zijde2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"De oppervlakte van de {figuur} = {zijde1 * zijde2}");
            break;
        case "cirkel":
            Console.Write("Geef de straal: ");
            Console.WriteLine($"De oppervlakte van de {figuur} = {Math.Floor(Math.PI * Math.Pow(int.Parse(Console.ReadLine()),2))}");
            break;
        default:
            break;
    }
    Console.Write("Driehoek, rechthoek of cirkel? (\"\" = stop) ");
}

