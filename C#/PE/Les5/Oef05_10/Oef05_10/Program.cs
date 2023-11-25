string tekst = "", invoer;

do
{
    invoer = Console.ReadLine();
    tekst = invoer + "\n" + tekst; 
} while (invoer != "stop");

Console.Clear();
Console.WriteLine(tekst);