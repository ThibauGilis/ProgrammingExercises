//----------------------------------------------------
// Met .Replace Methode ------------------------------
//----------------------------------------------------

/*string woord = Console.ReadLine();

woord = woord.Replace('o', 'x');

Console.WriteLine(woord);
*/



//----------------------------------------------------
// Zonder .Replace() Methode -------------------------
//----------------------------------------------------


// nieuwe variable | orginele woord bijhouden

/*string woord = Console.ReadLine(), wxxrd = "";

for  (int i = 0; i < woord.Length; i++)
{
    if (woord[i] == 'o')
    {
        wxxrd += 'x';
    }
    else
    {
        wxxrd += woord[i];
    }
}

Console.WriteLine(wxxrd);*/


// string methodes | orginele woord veranderen

string woord = Console.ReadLine();

for (int i = 0; i<woord.Length; i++)
{
    if (woord[i] == 'o')
    {
        woord = woord.Remove(i, 1);
        woord = woord.Insert(i, "x");
    }
}

Console.WriteLine(woord);