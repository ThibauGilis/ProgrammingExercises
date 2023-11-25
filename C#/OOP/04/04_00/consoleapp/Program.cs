string LeesStringNietLeeg(string vraag)
{
    string invoer;
    do
    {
        Console.Write(vraag);
        invoer = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(invoer));
    return invoer;
}

Werknemer werknemer = new Werknemer(LeesStringNietLeeg("Geef je voornaam: "), LeesStringNietLeeg("Geef je achternaam: "));
Console.WriteLine(werknemer.ToonGegevens());

Klant klant = new Klant(LeesStringNietLeeg("Geef je voornaam: "), LeesStringNietLeeg("Geef je achternaam: "));
Console.WriteLine(klant.ToonGegevens());