using consoleapp.Models;

int LeesGetal()
{
    int getal;
    do
    {
        Console.Write("Geef ene getal ");
    } while (!int.TryParse(Console.ReadLine(), out getal));
    return getal;
}

string LeesStringNietLeeg(string vraag)
{
    string invoer;
    do
    {
        Console.Write(vraag);
    } while (string.IsNullOrWhiteSpace(invoer = Console.ReadLine()));
    return invoer ;
}

//-------------------------------------------------------------------------

int nummer = LeesGetal();
string voornaam = LeesStringNietLeeg("Geef uw voornaam: ");
string familienaam = LeesStringNietLeeg("Geef uw familienaam: ");

Gebruiker gebruiker = new Gebruiker();

gebruiker.Nummer = nummer;
gebruiker.Voornaam = voornaam;
gebruiker.Familienaam = familienaam;

Console.WriteLine(gebruiker.ToonGegevens());
