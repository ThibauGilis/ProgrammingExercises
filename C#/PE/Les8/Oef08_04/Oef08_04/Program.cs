
string ReadName(string promt)
{
    string invoer;
    do
    {
        Console.Write(promt);
        invoer = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(invoer));
    
    return invoer;
}

int ReadHobby(int min, int max)
{
    int getal;

    do
    {
        Console.Write($"Geef getal ({min}-{max}): ");
    } while (!int.TryParse(Console.ReadLine(), out getal) || (getal < min || max < getal));

    return getal;
}

void RecommendBooks(List<int> hobbies)
{
    if (hobbies.Last() == 1)
    {
        Console.WriteLine("Wij raden \"Anna\" aan.");
    }
    else if (hobbies.Last() == 2)
    {
        Console.WriteLine("Wij raden \"Knippie\" aan.");
    }
    else if (hobbies.Last() == 3)
    {
        Console.WriteLine("Wij raden \"VtWonen\" aan.");
    }
    else if (hobbies.Last() == 4)
    {
        Console.WriteLine("Wij raden \"Voetbal international\" aan.");
    }
    else if (hobbies.Last() == 5)
    {
        Console.WriteLine("Wij raden \"Wandelen & fietsen\" aan.");
    }
    else if (hobbies.Last() == 6)
    {
        Console.WriteLine("Wij raden \"Zoom NL\" aan.");
    }
    else if (hobbies.Last() == 7)
    {
        Console.WriteLine("Wij raden \"Runners\" aan.");
    }
}


string voornaam, naam;
List<int> hobbies = new List<int>();

voornaam = ReadName("Geef voornaam: ");
voornaam = ReadName("Geef naam: ");

hobbies.Add(ReadHobby(1, 8));

while (hobbies.Last() != 8)
{
    RecommendBooks(hobbies);
    hobbies.Add(ReadHobby(1, 8));
}

if (hobbies.Count == 1)
{
    Console.WriteLine("Wij raden niets aan.");
}