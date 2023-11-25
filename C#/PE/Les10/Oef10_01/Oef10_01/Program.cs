
string LeesBestand(string Bestandnaam)
{
    using (StreamReader Bestand = new StreamReader(Bestandnaam))
    {
        if (Bestand.EndOfStream)
        {
            return "Geen vrienden";
        }
        else
        {
            return "Vrienden\n" + Bestand.ReadToEnd();
        }
    }
}


Console.Write("Geef Bestandsnaam: ");
string bestandsnaam = Console.ReadLine();
if (File.Exists(bestandsnaam))
{
    Console.WriteLine(LeesBestand(bestandsnaam));
}
else
{
    Console.Write($"{bestandsnaam} bestaat niet");
}