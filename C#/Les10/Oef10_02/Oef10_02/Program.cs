
void SjaalMaken(string[] Record)
{
    string berg = Record[0];
    char symbool1 = char.Parse(Record[1]) , symbool2 = char.Parse(Record[2]);
    int lengte = int.Parse(Record[3]), Breedte = int.Parse(Record[4]);

    string output = "Sjaal " + berg;
    output += "\n" + new string('*', output.Length);

    for (int i = 0; i < lengte; i++)
    {
        output += "\n" + ((i % 2 == 0) ? new string(symbool2, Breedte): new string(symbool1, Breedte));
    }

    Console.WriteLine(output);
}



Console.Write("Geef bestandnaam: ");
string Bestandsnaam = Console.ReadLine();

if (File.Exists(Bestandsnaam))
{
    string[] Record;
    using (StreamReader Bestand = new StreamReader(Bestandsnaam))
    {
        while (!Bestand.EndOfStream)
        {
            Record = Bestand.ReadLine().Split(';');
            SjaalMaken(Record);
        }
    }
}
else
{
    Console.WriteLine($"{Bestandsnaam} bestaat niet");
}