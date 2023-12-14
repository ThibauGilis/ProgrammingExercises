
double LeesDouble(string vraag)
{
    double getal;
	do
	{
        Console.Write(vraag);
    } while (!double.TryParse(Console.ReadLine(), out getal));
	return getal;
}

//-----------------------------------------------------------------------

Zwembad zwembad = new Zwembad(LeesDouble("Geef de breedte: "), LeesDouble("Geef de lengte: "), LeesDouble("Geef de diepte: "), LeesDouble("Geef de randafstand: "));

Console.WriteLine(zwembad.ToonGegevens());