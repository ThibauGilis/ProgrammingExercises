Boek boek = new Boek();

Console.Write("Titel: ");
boek.Titel = Console.ReadLine();
Console.Write("Auteur: ");
boek.Auteur = Console.ReadLine();
Console.Write("Bladzijden: ");
boek.Bladzijden = double.Parse(Console.ReadLine());
Console.Write("Bladzijden per dag: ");
Console.WriteLine(boek.ToonGegevens(int.Parse(Console.ReadLine())));