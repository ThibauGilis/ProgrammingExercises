//did zou ni Indy approved zijn, wa is deze saus

int g1, g2;
string output = "";

Console.Write("Geef getal 1: ");
g1 = (g1 = int.Parse(Console.ReadLine())) % 2 == 0 ? g1 : g1 - 1;
Console.Write("Geef getal 2: ");
g2 = (g2 = int.Parse(Console.ReadLine())) % 2 == 0 ? g2 : g2 + 1;

for (int i = g1; i > g2; i -= 2)
{
    output += i + " * ";
}
output += g2;

Console.WriteLine(output);

// normale manier

//  Console.Write("Geef getal 1: ");
//  g1 = int.Parse(Console.ReadLine());
//  if  (g1 % 2 != 0)
//  {
//    g1 -= 1;
//  }
//
//  Console.Write("Geef getal 2: ");
//  g2 = int.Parse(Console.ReadLine());
//  if (g2 % 2 != 0)
//  {
//      g2 += 1;
//  }
