// debug shit
//
// Console.WriteLine($"Grass: {GenerateArea.AmountTiles[0]}\nTree {GenerateArea.AmountTiles[1]}");
//
// 
// 
//
//
//
//
//
//-------------------------------------------------------
//-----------------  PROGRAM POKEMON  -------------------
//-------------------------------------------------------

//--------------------- METHODES ------------------------





//----------------------- MAIN --------------------------

//--- Setup
DateTime dateTime = DateTime.Now;

Console.WriteLine($"Startup: {(DateTime.Now - dateTime).TotalSeconds} seconds");
//----

ConsoleKey key = ConsoleKey.S;

key = Console.ReadKey().Key;
while (key != ConsoleKey.Escape)
{
    switch (key)
    {
        case ConsoleKey.Z:

            break;

        case ConsoleKey.S:

            break;

        case ConsoleKey.Q:

            break;

        case ConsoleKey.D:

            break;
    }

    key = Console.ReadKey().Key;
}