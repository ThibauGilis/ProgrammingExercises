int start, eind;
string output = "";

Console.Write("Geef de startwaarde: ");
start = int.Parse(Console.ReadLine());
Console.Write("Geef de eindwaarde: ");
eind = int.Parse(Console.ReadLine());

for  (int i = start; i > eind; i--)
{
    output += i + " * ";
}

Console.WriteLine(output+eind);