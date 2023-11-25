string Voornaam, Familienaam, Rijkregisternummer, Ibannummer;

Console.Write("Geef een voornaam: ");
Voornaam = Console.ReadLine();
Console.Write("Geef een familienaam: ");
Familienaam = Console.ReadLine();

Console.Write("Geef een rijkregisternummer: ");
Rijkregisternummer = Console.ReadLine();
Console.Write("Geef een Iban: ");
Ibannummer = Console.ReadLine();

Console.WriteLine("PersoonsGegevens\n------\n");
Console.WriteLine($"Volledige naam: {Voornaam} {Familienaam}\nRijkregisternummer: {Rijkregisternummer} {Geldigheid.Rijkregisternummer(Rijkregisternummer.Replace(".", "").Replace("-", ""))}\nIBAN: {Ibannummer} {Geldigheid.Ibannummer(Ibannummer.Replace("-", ""))}");