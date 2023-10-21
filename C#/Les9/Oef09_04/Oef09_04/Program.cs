//----------------------------------------------------
// Met .Replace Methode ------------------------------
//----------------------------------------------------

string woord = Console.ReadLine();

woord = woord.Replace('o', 'x');

Console.WriteLine(woord);




//----------------------------------------------------
// Zonder .Replace() Methode -------------------------
//----------------------------------------------------

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