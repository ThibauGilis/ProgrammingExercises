
//Declaratie
int getal1, aantalafdrukken;

//Scherminstellingen aanpassen
Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.Clear();
Console.Title = "Voorbeeld 1";

//Data inlezen
Console.Write("Geef een getal: ");
getal1 = int.Parse(Console.ReadLine());
Console.Write("Geef gewenst aantal keren afdrukken: ");
aantalafdrukken = int.Parse(Console.ReadLine());

//Bewerking uitvoeren
for (int i = 0; i < aantalafdrukken; i++)
{
    Console.WriteLine("\t{0}",getal1);
}


//Wachten op enter
Console.WriteLine("Druk op enter om verder te gaan!");
Console.ReadLine();

//Declaratie + bewerkingen uitvoeren + resultaat tonen
string overzicht = "\n";

for  (int i = 0;i < aantalafdrukken;i++)
{
    overzicht += "\t" + getal1 + "\n";
}

Console.WriteLine(overzicht);

//Wachten op enter
Console.WriteLine("Druk op enter om verder te gaan!");
Console.ReadLine();