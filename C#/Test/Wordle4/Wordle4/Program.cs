
void Instellingen()
{
    Console.Title = "4 letter Wordle";
    Console.ForegroundColor = ConsoleColor.White;
}

string RandomWoord(List<string> Woorden)
{
    Random rnd = new Random();
    string woord;
    do
    {
        woord = Woorden[rnd.Next(0, Woorden.Count)];
    } while (woord.Length != 4);

    return woord;
}

string LeesInvoer(string vraag)
{
    string invoer;
    do
    {
        Console.Write(vraag);
        invoer = Console.ReadLine().ToLower();
    } while (invoer.Length != 4);
    return invoer;
}

string[,] CheckKleuren(string woord, string invoer)
{
    string[,] Output = new string[4, 2];
    string check = "";

    for (int i = 0; i < woord.Length; i++)
    {
        if (woord[i] == invoer[i])
        {
            Output[i, 0] = invoer[i].ToString();
            Output[i, 1] = "Green";
            check += "?";
        }
        else
        {
            check += woord[i];
        }
    }

    for (int i = 0; i < woord.Length; i++)
    {
        if (check.Contains(invoer[i]))
        {
            Output[i, 1] = "Red";
            check.Replace(invoer[i], '?');
        }
        else
        {
            Output[i, 1] = "Gray";
        }
        Output[i, 0] = invoer[i].ToString();
    }

    return Output;
}

void PrintKleuren(string[,] Output)
{
    Console.Write("\t");
    for (int i = 0; i < Output.Length/2; i++)
    {
        switch (Output[i,1])
        {
            case "Green":
                Console.ForegroundColor = ConsoleColor.Green;
                break;

            case "Red":
                Console.ForegroundColor = ConsoleColor.Red;
                break;

            case "Gray":
                Console.ForegroundColor = ConsoleColor.Gray;
                break;

            default:
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("ERROR");
                break;
        }
        Console.Write(Output[i,0]);
    }
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine();
}



//------------------------------------------------------

Instellingen();
List<string> Woorden = FileOperations.ListOfWords();
string woord = RandomWoord(Woorden);

Console.WriteLine(woord);

string invoer = LeesInvoer("Zoek het 4 letter woord: ");
while (woord != invoer)
{
    PrintKleuren(CheckKleuren(woord, invoer));

    invoer = LeesInvoer("Zoek het 4 letter woord: ");
}
