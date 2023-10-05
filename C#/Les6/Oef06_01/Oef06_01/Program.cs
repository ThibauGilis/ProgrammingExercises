using System.Linq.Expressions;

string evenement = "", lijst= "", invoer;

do
{
    Console.Write("Wat is de naam van het evenement: ");
    evenement = Console.ReadLine();
} while (evenement == "");

do
{
    Console.Write("Wilt u een naam invoeren? ");
    invoer = Console.ReadLine();
} while (invoer != "ja" && invoer != "nee");

while (invoer == "ja")
{
    Console.Write("Welke naam wilt u toevoegen? ");
    lijst += "\n" + Console.ReadLine();

    Console.Write("Wilt u nog een naam invoeren? ");
    invoer = Console.ReadLine();
}

if (lijst == "")
{
    Console.Write($"Er zijn geen aanwezigen voor {evenement}!");
}
else
{
    Console.Write($"Aanwezigen voor {evenement}:{lijst}");
}
