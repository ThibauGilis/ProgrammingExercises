//declaratie
string naam = "Jef Klabas";
string letter = "B";
string voorwerp = "potlood   ";

//schermkleuren aanpassen
Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.Clear();
Console.Title = "Voorbeeld 3";

Console.WriteLine("\n\tnaam bevat {0} karakters nl. '{1}'", naam.Length, naam);
Console.WriteLine("\tletter bevat {0} karakters nl. '{1}'", letter.Length, letter);
Console.WriteLine("\tvoorwerp bevat {0} karakters nl. '{1}'\n", voorwerp.Length, voorwerp);

Console.WriteLine("\t"+ new string('*', naam.Length));
Console.WriteLine("\t" + new string('-', letter.Length));
Console.WriteLine("\t" + new string('=', voorwerp.Length));

