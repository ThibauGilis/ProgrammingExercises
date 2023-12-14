
using consoleapp.Models;

string LeesInvoer(string vraag)
{
    string invoer;
	do
	{
        Console.Write(vraag);
        invoer = Console.ReadLine();
	} while (string.IsNullOrWhiteSpace(invoer));
	return invoer;
}
int Leeskeuze(List<Persoon> contacten)
{
    int keuze;
    for (int i = 0; i < contacten.Count; i++)
    {
        Console.WriteLine($"{i+1}. {contacten[i]}");
    }

    do
    {
        Console.Write("Kies ontvanger: ");
    } while (!int.TryParse(Console.ReadLine(), out keuze) || keuze < 1 || keuze > contacten.Count);
    return keuze-1;
}

// ------------------------------------------------------------------------------------------------

List<Persoon> Contacten = FileOperations.LeesContacten();

string voornaam = LeesInvoer("Geef voornaam: ");
string familienaam = LeesInvoer("Geef familienaam: ");
string emailadres = LeesInvoer("Geef emailadres: ");
Persoon verzender = new Persoon(voornaam, familienaam, emailadres);

int keuze = Leeskeuze(Contacten);

string titel = LeesInvoer("Geef titel: ");
string bericht = LeesInvoer("Geef bericht: ");

Email email = new Email(verzender, Contacten[keuze], titel, bericht);
Console.WriteLine($"\nVolgende email wordt verstuurd:\n{email}");


