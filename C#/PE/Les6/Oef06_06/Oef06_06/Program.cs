int totaal = 0, tickets;
string invoer;

invoer = Console.ReadLine();
while (int.TryParse(invoer, out tickets) && tickets > 0)
{
    totaal += tickets;
    invoer = Console.ReadLine();
}

Console.WriteLine($"Totaal aantal tickets: {totaal}\nTotale prijs: {totaal * 15}");

//blijkbaar vind codegrade da een lege string ("") hetzelfde is als -3
//
//int totaal = 0, tickets;
//string invoer;
//
//invoer = Console.ReadLine();
//while (invoer != "")
//{
//    if (int.TryParse(invoer, out tickets) && tickets > 0)
//    {
//        totaal += tickets;
//    }
//    invoer = Console.ReadLine();
//}
//
//Console.WriteLine($"Totaal aantal tickets: {totaal}\nTotale prijs: {totaal * 15}");