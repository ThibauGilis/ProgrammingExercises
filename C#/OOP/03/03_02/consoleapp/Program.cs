
using consoleapp.Models;
using Microsoft.VisualBasic;

double LeesCelsius(string vraag)
{
    double getal;
    do
    {
        Console.Write(vraag);
    } while (!double.TryParse(Console.ReadLine(), out getal));
    return getal;
}

//------------------------------------------------------------------------


double Celsius = LeesCelsius("Geef aantal graden Celsius: ");
double Fahrenheit;
DateTime Tijdstip;

string invoer;
do
{
    Console.Write("Geef aantal graden Fahrenheit: ");
    invoer = Console.ReadLine();
} while (!double.TryParse(invoer, out Fahrenheit) && invoer != "");

if (invoer == "")
{
    do
    {
        Console.Write("Geef een tijdstip: ");
        invoer = Console.ReadLine();
    } while (!DateTime.TryParse(invoer, out Tijdstip) && invoer != "");


    if (invoer == "")
    {
        Meting meting = new Meting(Celsius);
        Console.WriteLine(meting.ToonGegevens());
    }
    else
    {
        Meting meting = new Meting(Tijdstip, Celsius);
        Console.WriteLine(meting.ToonGegevens());
    }
}
else
{
    do
    {
        Console.Write("Geef een tijdstip: ");
        invoer = Console.ReadLine();
    } while (!DateTime.TryParse(invoer, out Tijdstip));

    Meting meting = new Meting(Tijdstip, Fahrenheit, Celsius);
    Console.WriteLine(meting.ToonGegevens());
}
