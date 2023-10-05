int getal;
string output = "";

Console.Write("Geef een getal: ");
getal = int.Parse(Console.ReadLine());

for  (int i = getal; 0 < i; i--)
{
    output += "\n" + i * i;
}

Console.WriteLine(output);