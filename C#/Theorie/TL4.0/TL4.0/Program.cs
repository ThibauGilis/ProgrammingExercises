int getal;
string overzicht = "\n";

Console.Write("Geef een getal: ");
getal = int.Parse(Console.ReadLine());

for (int i = 0; i < 10; i++)
{
    getal++;
    overzicht += "\t" + getal + "\n";
}

Console.WriteLine(overzicht);
Console.WriteLine("Druk op enter om verder te gaan!");
Console.ReadLine();


//TEST
Console.WriteLine("\n");
overzicht = "\n";

for (int i = getal+1; getal <= i+10; getal++)
{
    overzicht += "\t" + getal + "\n";
}

Console.WriteLine(overzicht);
Console.WriteLine("Druk op enter om verder te gaan!");
Console.ReadLine();
