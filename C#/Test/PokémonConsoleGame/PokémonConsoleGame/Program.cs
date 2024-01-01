// debug shit
//
//  Console.WriteLine(terrain.Level);
//  Console.WriteLine(terrain.IDtoString() + $"\t{Save.TerrainLevelModifierBySize}");
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
// insanity time
using System;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using PokémonConsoleGame.Pokémon;

void ShowMainMenu()
{
    int centerOnheigth = (Console.WindowHeight-3) / 2;
    int centerOnWidth = (Console.WindowWidth-74) / 2;

    Console.SetCursorPosition(centerOnWidth+18, centerOnheigth+10);
    Console.WriteLine("Press Enter To Select | Q & D To Move");

    bool LoadGame = false;
    string newText = "░█▀█░█▀▀░█░█░░░█▀▀░█▀█░█▄█░█▀▀\n" +
                     "░█░█░█▀▀░█▄█░░░█░█░█▀█░█░█░█▀▀\n" +
                     "░▀░▀░▀▀▀░▀░▀░░░▀▀▀░▀░▀░▀░▀░▀▀▀";
    string loadText = "░█░░░█▀█░█▀█░█▀█░░░█▀▀░█▀█░█▄█░█▀▀\n" +
                      "░█░░░█░█░█▀█░█░█░░░█░█░█▀█░█░█░█▀▀\n" +
                      "░▀▀▀░▀▀▀░▀░▀░▀▀░░░░▀▀▀░▀░▀░▀░▀░▀▀▀";

    void ChangeText(bool loadgame)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        if (loadgame)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        Console.SetCursorPosition(centerOnWidth, centerOnheigth);
        foreach (char c in newText)
        {
            if (c == '\n')
            {
                Console.CursorLeft = centerOnWidth;
                Console.CursorTop++;
            }
            else
            {
                Console.Write(c);
            }
        }
        Console.ForegroundColor = ConsoleColor.Gray;
        if (loadgame)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        Console.SetCursorPosition(centerOnWidth+40, centerOnheigth);
        foreach (char c in loadText)
        {
            if (c == '\n')
            {
                Console.CursorLeft = centerOnWidth+40;
                Console.CursorTop++;
            }
            else
            {
                Console.Write(c);
            }
        }
        Console.SetCursorPosition(0, 0);
    }

    ChangeText(LoadGame);
    ConsoleKey key = Console.ReadKey().Key;
    while (key != ConsoleKey.Enter)
    {
        
        switch (key)
        {
            case ConsoleKey.Q:
                LoadGame = false;
                ChangeText(LoadGame);
                break;

            case ConsoleKey.D:
                LoadGame = true;
                ChangeText(LoadGame);
                break;
        }

        key = Console.ReadKey().Key;
    }
    Console.Clear();

    if (LoadGame)
    {
        // Das Veel Werk
    }
    else
    {
        void Settings()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Save.TerrainHeigth = ReadInteger("Terrain Height: ", 10, Console.WindowHeight);
            Save.TerrainWidth = ReadInteger("Terrain Width: ", 10, (Console.WindowWidth - Save.DataLocSize.Length)/2);
            Save.TerrainLevelModifierBySize = Math.Max(1, (int)Math.Pow((Math.Pow(Math.Log10(Save.TerrainWidth * Save.TerrainHeigth), 2) - 2) / 5, 2)); // wa deze calculatie doe? uuhhhmm.... Het werkt
        }
        void ChooseStarterPokemon()
        {
            Console.SetCursorPosition((Console.WindowWidth - 37) / 2, Console.WindowHeight - 1);
            Console.WriteLine("Press Enter To Select | Q & D To Move");

            List<Pokemon> starters = new List<Pokemon>();

            foreach(string name in Save.StarterPokemon)
            {
                foreach(Pokemon pokemon in Save.AllPokemon)
                {
                    if (pokemon.Name == name)
                    {
                        starters.Add(pokemon);
                        break;
                    }
                }
            }

            void ChangePokeball(int choice, Pokemon starter)
            {
                Console.SetCursorPosition(0, 0); // where tf are those PokemonImages
                string clearPokemonArt = "";
                for (int i = 0; i < Console.WindowHeight - 21; i++)
                {
                    clearPokemonArt += new string(' ', Console.WindowWidth);
                    clearPokemonArt += "\n";
                }
                Console.Write(clearPokemonArt);

                int imageMaxWidth = 0;
                foreach (string line in Save.PokeBall)
                {
                    if (imageMaxWidth < line.Length) imageMaxWidth = line.Length;
                }

                int spaceBetween = 15;
                /*SetForegroundColorToType(starter.Type);*/

                Console.CursorTop = Console.WindowHeight / 5;
                foreach (string line in starter.ImageSmall)
                {
                    Console.CursorLeft = (Console.WindowWidth/2-(imageMaxWidth*3/2+spaceBetween) -((Save.PokemonASCIIWidth-imageMaxWidth)/2)) + (choice * (imageMaxWidth + spaceBetween));
                    Console.Write(line.Replace('R', ' '));
                }

                for (int i = 0; i < 3; i++)
                {
                    Console.ForegroundColor = (choice == i ?  ConsoleColor.Yellow: ConsoleColor.Gray);
                    Console.CursorTop = Console.WindowHeight-20;
                    foreach (string line in Save.PokeBall)
                    {
                        Console.CursorLeft = (Console.WindowWidth/2 -(imageMaxWidth*3/2 + spaceBetween)) + (i *(imageMaxWidth + spaceBetween));
                        Console.Write(line);
                    }
                }

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(0, 0);
            }

            int choice = 0;
            ChangePokeball(choice, starters[choice]);

            key = ConsoleKey.Q;
            while (key != ConsoleKey.Enter)
            {

                switch (key)
                {
                    case ConsoleKey.Q:
                        if (choice > 0)
                        {
                            choice--;
                            ChangePokeball(choice, starters[choice]);
                        }
                        break;

                    case ConsoleKey.D:
                        if (choice < 2)
                        {
                            choice++;
                            ChangePokeball(choice, starters[choice]);
                        }
                        break;
                }

                key = Console.ReadKey().Key;
            }

            Save.Player.PokemonTeam[0] = starters[choice];
        }

        Settings(); // bruh letterlijk erachter gezet

        DateTime dateTime = DateTime.Now;
        Save.NewGame();
        Console.WriteLine($"World Creation: {(DateTime.Now - dateTime).TotalMilliseconds} MilliSeconds");

        // Making Player
        Save.Player.Name = ReadString("What Is Thy Name: ");
        ChooseStarterPokemon();
    }

    Console.Clear();
}

int ReadInteger(string question, int min, int max)
{
    Console.CursorVisible = true;
    int integer;
    do
    {
        Console.Write(question + $"({min}-{max}) ");
    } while (!int.TryParse(Console.ReadLine(), out integer) || integer < min || integer > max);
    Console.CursorVisible = false;
    return integer;
}

string ReadString(string question, int minLength = 3, int maxLength = 9)
{
    Console.CursorVisible = true;
    string input;
    do
    {
        Console.Write(question + $"({minLength}-{maxLength} char) ");
        input = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(input) || input.Length < minLength || input.Length > maxLength);
    Console.CursorVisible = false;
    return input;
}

void GameInfoDebugging()
{
    DateTime dateTime = DateTime.Now;

    Console.BackgroundColor = ConsoleColor.Black;
    Console.Clear();
    Console.WriteLine("Info:");
    Console.WriteLine(new string('|', 100) + "\n");
    foreach (Pokemon pokemon in Save.AllPokemon)
    {
        switch (pokemon.Type)
        {
            case "Fire":
                Console.ForegroundColor = ConsoleColor.Red;
                break;

            case "Rock":
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;

            case "Grass":
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                break;

            case "Water":
                Console.ForegroundColor = ConsoleColor.Blue;
                break;

            case "Air":
                Console.ForegroundColor = ConsoleColor.White;
                break;

            case "Normal":
                Console.ForegroundColor = ConsoleColor.Gray;
                break;
        }
        Console.WriteLine(pokemon);
        Console.WriteLine(new string('|', 100) + "\n");
    }

    Console.WriteLine($"Show Info: {(DateTime.Now - dateTime).TotalMilliseconds} MilliSeconds");

    ConsoleKey key;
    do
    {
        key = Console.ReadKey().Key;
        Console.SetCursorPosition(0, 0);
    } while (key != ConsoleKey.I);
    Console.ForegroundColor = ConsoleColor.White;
    Console.Clear();
}

void WorldMap(World world, Terrain terrain)
{
    DateTime dateTime = DateTime.Now;

    Console.Clear();
    Console.WriteLine("\tMap:");
    Console.SetCursorPosition(8, 2);
    Console.WriteLine(world.ShowMap(terrain.ID));

    Console.WriteLine($"Show Map: {(DateTime.Now - dateTime).TotalMilliseconds} MilliSeconds");

    ConsoleKey key;
    do
    {
        key = Console.ReadKey().Key;
        Console.SetCursorPosition(0, 0);
    } while (key != ConsoleKey.M);
    Console.Clear();
    AddColorsPrintArea("Terrain", terrain.ShowArea());
}

void AddColorsPrintArea(string areaType, string areaData)
{
    if (areaType == "Terrain")
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        int i = 0;
        int lowIndex, index;
        char tileType;
        char[] tileTypes = new char[] {
            Save.Empty[0],
            Save.Border[0],
            Save.Tree[0],
            Save.Grass[0],
            Save.Person[0] };
        List<char> otherTileTypes = tileTypes.ToList();

        while (i < areaData.Length - 1)
        {
            lowIndex = int.MaxValue;
            for (int j = 0; j < otherTileTypes.Count; j++)
            {
                index = areaData.IndexOf(otherTileTypes[j], i);
                if (index < lowIndex && index != -1)
                {
                    lowIndex = index;
                }
            }

            if (lowIndex == int.MaxValue)
            {
                lowIndex = areaData.Length - 1;
            }
            Console.Write(areaData.Substring(i, lowIndex - i));
            i = lowIndex;

            tileType = areaData[lowIndex];
            otherTileTypes = tileTypes.ToList();
            if (tileType == tileTypes[0])
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                otherTileTypes.Remove(tileTypes[0]);
                otherTileTypes.Remove(tileTypes[1]);
            }
            else if (tileType == tileTypes[1])
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                otherTileTypes.Remove(tileTypes[0]);
                otherTileTypes.Remove(tileTypes[1]);
            }
            else if (tileType == tileTypes[2])
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                otherTileTypes.Remove(tileTypes[2]);
            }
            else if (tileType == tileTypes[3])
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                otherTileTypes.Remove(tileTypes[3]);
            }
            else if (tileType == tileTypes[4])
            {
                Console.ForegroundColor = ConsoleColor.White;
                otherTileTypes.Remove(tileTypes[4]);
            }
        }
    }
    Console.ForegroundColor = ConsoleColor.White;
    Console.SetCursorPosition(0, 0);
}

void SetForegroundColorToType(string type)
{
    switch (type)
    {
        case "Grass":
            Console.ForegroundColor = ConsoleColor.Green;
            break;

        case "Fire":
            Console.ForegroundColor = ConsoleColor.Red;
            break;

        case "Water":
            Console.ForegroundColor = ConsoleColor.Blue;
            break;

        case "Rock":
            Console.ForegroundColor = ConsoleColor.Yellow;
            break;

        case "Air":
            Console.ForegroundColor = ConsoleColor.White;
            break;

        default:
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
    }
}
void SetBackgroundColorToType(string type)
{
    switch (type)
    {
        case "Grass":
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            break;

        case "Fire":
            Console.BackgroundColor = ConsoleColor.Red;
            break;

        case "Water":
            Console.BackgroundColor = ConsoleColor.Blue;
            break;

        case "Rock":
            Console.BackgroundColor = ConsoleColor.Yellow;
            break;

        case "Air":
            Console.BackgroundColor = ConsoleColor.White;
            break;

        default:
            Console.BackgroundColor = ConsoleColor.Gray;
            break;
    }
}

void PrintArtWithoutWhiteSpace(string[] lines, int[] cursorposition) // whitespace detirmend by 'R'
{
    char check = ' ';
    List<string> subLines = new List<string>();
    foreach (string line in lines)
    {
        int index = 0, nextIndex = 0;
        while (true)
        {
            if (check != 'R')
            {
                int i = line.IndexOf(' ', index);
                nextIndex = i == -1? line.Length: i;
                i = line.IndexOf('░', index);
                nextIndex = Math.Min((i == -1 ? nextIndex : i), nextIndex);
                i = line.IndexOf('▒', index);
                nextIndex = Math.Min((i == -1 ? nextIndex: i), nextIndex);
                i = line.IndexOf('▓', index);
                nextIndex = Math.Min((i == -1 ? nextIndex : i), nextIndex);
                i = line.IndexOf('█', index);
                nextIndex = Math.Min((i == -1 ? nextIndex : i), nextIndex);
                i = line.IndexOf('\n');
                nextIndex = Math.Min((i == -1 ? nextIndex : i), nextIndex);

                if (nextIndex == line.IndexOf('\n'))
                {
                    subLines.Add("\n");
                    break;
                }

                subLines.Add(line.Substring(index, nextIndex - index));
                check = 'R';
            }
            else
            {
                check = ' ';
                nextIndex = line.IndexOf('R', index);
                if (nextIndex == -1)
                {
                    string subLine = line.Substring(index, line.Length - index);
                    subLine = (subLine.Contains("\n") ? subLine.Remove(subLine.Length-1): subLine);
                    subLines.Add(subLine);
                    subLines.Add("\n");
                    break;
                }

                subLines.Add(line.Substring(index, nextIndex - index));
            }
            index = nextIndex;
        }
    }

    Console.SetCursorPosition(cursorposition[0], cursorposition[1]);
    foreach (string line in subLines)
    {
        if (line.Contains('\n'))
        {
            Console.CursorTop++;
            Console.CursorLeft = cursorposition[0];
        }
        else if (line.Contains('R'))
        {
            Console.CursorLeft += line.Length;
        }
        else
        {
            Console.Write(line);
        }
    }
} // ik weet ni wrm ma het werkt

string[] PlayerMove(World world, Terrain terrain, int[] currentTerrainID, int[] yx, int[] vector, string tileTypeMovedFrom)
{
    int y = yx[0];
    int x = yx[1];
    if (y == 0 && vector[0] == -1)
    {
        terrain.Box[y][x] = terrain.Empty;
        terrain = world.MoveToNextTerrain(vector, currentTerrainID);
        y = terrain.BoxHeigth - 1;
        terrain.Box[y][x] = terrain.Person;
    }
    else if (y == terrain.BoxHeigth - 1 && vector[0] == 1)
    {
        terrain.Box[y][x] = terrain.Empty;
        terrain = world.MoveToNextTerrain(vector, currentTerrainID);
        y = 0;
        terrain.Box[y][x] = terrain.Person;
    }
    else if (x == 0 && vector[1] == -1)
    {
        terrain.Box[y][x] = terrain.Empty;
        terrain = world.MoveToNextTerrain(vector, currentTerrainID);
        x = terrain.BoxWidth - 1;
        terrain.Box[y][x] = terrain.Person;
    }
    else if (x == terrain.BoxWidth - 1 && vector[1] == 1)
    {
        terrain.Box[y][x] = terrain.Empty;
        terrain = world.MoveToNextTerrain(vector, currentTerrainID);
        x = 0;
        terrain.Box[y][x] = terrain.Person;
    }
    else
    {
        if (terrain.CheckValidPostition(y + vector[0], x + vector[1]))
        {
            Console.SetCursorPosition(x * 2 + Save.DataLocSize.Length, y); // dont question the dataLocSize and why its a string
            if (tileTypeMovedFrom == Save.Grass)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.Write(tileTypeMovedFrom);
            terrain.Box[y][x] = tileTypeMovedFrom;
            y += vector[0];
            x += vector[1];
            tileTypeMovedFrom = terrain.Box[y][x];
            Console.SetCursorPosition(x * 2 + Save.DataLocSize.Length, y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(terrain.Person);
            terrain.Box[y][x] = terrain.Person;
        }
    }
    Console.SetCursorPosition(0, 0);
    return new string[] { terrain.IDtoString(), $"{y}", $"{x}", tileTypeMovedFrom };
}

Player TileEvent(string tile, Player player, Terrain terrain)
{
    Pokemon GenerateWildPokemon(Pokemon p)
    {
        Random rnd = new Random();
        Pokemon enemy = new Pokemon( p.Name, p.Description, p.Evolution, p.UnlockableMoves,
                                     p.Type, (p.Level + rnd.Next(0,3+(p.Level/3))), p.Health, p.Attack, p.Defense, p.Speed );
        return enemy;
    }

    Player FightWildPokemon(Player player, Pokemon enemy)
    {
        void ShowBattleScreen(Pokemon myPokemon, Pokemon enemy)
        {
            // teken platformpjes
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            int x = Console.WindowWidth * 5 / 100;
            int imageMaxWidth = 0, imageMaxHeigth = 0;
            Console.SetCursorPosition(x,Console.WindowHeight*70/100);
            foreach (string line in Save.BattlePlatform)
            {
                if (imageMaxWidth < line.Length) imageMaxWidth = line.Length;

                imageMaxHeigth++;
                Console.Write(line);
                Console.CursorLeft = x;
            }
            x = Console.WindowWidth - (imageMaxWidth-1+x); // ik denk dat die -1 moet omda \n erin staat
            Console.SetCursorPosition(x, Console.WindowHeight*50/100);
            foreach (string line in Save.BattlePlatform)
            {
                Console.Write(line);
                Console.CursorLeft = x;
            }

            /*Console.ForegroundColor = ConsoleColor.Gray;*/
            //teken le pokemones
            SetForegroundColorToType(myPokemon.Type);
            x = (Console.WindowWidth * 5 / 100) + ((imageMaxWidth-Save.PokemonASCIIWidth)/2);
            PrintArtWithoutWhiteSpace(myPokemon.ImageSmall, new int[] {x, Console.WindowHeight*40/100});

            SetForegroundColorToType(enemy.Type);
            x = Console.WindowWidth - (imageMaxWidth - 1 + x) + ((imageMaxWidth - Save.PokemonASCIIWidth));
            PrintArtWithoutWhiteSpace(enemy.ImageSmall, new int[] { x, Console.WindowHeight*20/100});

            // teken le health card thingy

            int xBoxPos = 4;
            int yBoxPos = Console.WindowHeight*25/100;
            Console.SetCursorPosition(xBoxPos, yBoxPos);
            Console.ForegroundColor = ConsoleColor.Gray;
            int size = 60;
            Console.WriteLine(new string('▓', size));
            for (int i = 0; i < 5; i++)
            {
                Console.CursorLeft = xBoxPos;
                Console.WriteLine("▓▓" + new string('█', size - 4) + "▓▓");
            }
            Console.CursorLeft = xBoxPos;
            Console.Write(new string('▓', size));

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(xBoxPos+4, yBoxPos+2);
            Console.Write(myPokemon.Name);

            SetBackgroundColorToType(myPokemon.Type);
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft += 4;
            Console.Write($" {myPokemon.Type} ");

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(size+xBoxPos-10, yBoxPos+2);
            Console.WriteLine($"Lv: {myPokemon.Level}");

            Console.BackgroundColor = ConsoleColor.DarkGray;

            Console.SetCursorPosition(xBoxPos+4, yBoxPos+4);
            Console.Write(" HP:" + new string(' ', size-20));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(xBoxPos+9, yBoxPos+4);
            Console.Write(new string('▬', size-22));

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.CursorLeft += 3;
            Console.Write($"{myPokemon.Health}/{myPokemon.Health}");

            Console.BackgroundColor = ConsoleColor.Black;
        }

        string line = new string(' ', Save.TerrainWidth*2 + Save.DataLocSize.Length) + "\n" +
                      new string(' ', Save.TerrainWidth*2 + Save.DataLocSize.Length) + "\n" +
                      new string(' ', Save.TerrainWidth*2 + Save.DataLocSize.Length) + "\n";
        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < (Save.TerrainHeigth+10); i += 3)
        {
            Thread.Sleep(25); // task delay also a thing but is used when multiple threads ig, idk im noob
            Console.Write(line);
        }
        Thread.Sleep(1000);
        // fight start

        ShowBattleScreen(player.PokemonTeam[0], enemy);

        while (true)
        {
            Thread.Sleep(15000);
            break;
        }

        // fight end
        Console.SetCursorPosition(0, 0);
        AddColorsPrintArea("Terrain", terrain.ShowArea());
        Console.SetCursorPosition(0, 4);
        Console.WriteLine(player.ShowStatsinWorld());
        return player;
    }

    Random rnd = new Random();

    // TODO water shit ig
    if (terrain.Level == 0)  // NONONONONONNo no battles
    {
        return player;
    }

    if (tile == Save.Grass)
    {
        if (rnd.Next(0, 10) == 0)  // TODO check if fougth very recently
        {
            Pokemon pokemon;
            do // TODO normaal gezien moet dit ni want da gebeurt al inde fucking terrain constructor, ma voor nu, is ok he.
            {
                int randomPokemonId = rnd.Next(0, terrain.WildPokemon.Count);
                pokemon = terrain.WildPokemon[randomPokemonId];
            } while (pokemon.Level > terrain.Level);

            player = FightWildPokemon(player, GenerateWildPokemon(pokemon));
        }
    }


    return player;
}

//----------------------- MAIN --------------------------

//--- Setup ---
Console.BufferHeight = Console.LargestWindowHeight;
Console.BufferWidth = Console.LargestWindowWidth;
Console.WindowHeight = Console.LargestWindowHeight;
Console.WindowWidth = Console.LargestWindowWidth;
Console.CursorVisible = false;

ShowMainMenu();

World world = Save.World;
Terrain terrain = Save.Terrain;
int[] MyYX = Save.MyYX;
string tileTypeMovedFrom = terrain.Empty;

Player player = Save.Player;

int[] nextTerrainID;
int[] currentTerrainID = terrain.ID;
int[] up = new int[] { -1, 0 };
int[] down = new int[] { 1, 0 };
int[] left = new int[] { 0, -1 };
int[] right = new int[] { 0, 1 };
string[] moveData = new string[] { terrain.IDtoString(), $"{MyYX[0]}", $"{MyYX[1]}", tileTypeMovedFrom };
AddColorsPrintArea("Terrain", terrain.ShowArea());
Console.SetCursorPosition(0, 4);
Console.WriteLine(player.ShowStatsinWorld());

//-------------





// --- GAME ---
Console.SetCursorPosition(0, 0);
ConsoleKey key = Console.ReadKey().Key;
while (key != ConsoleKey.Escape)
{
    switch (key)
    {
        case ConsoleKey.Z:
            moveData = PlayerMove(world, terrain, currentTerrainID, MyYX, up, tileTypeMovedFrom);
            break;

        case ConsoleKey.S:
            moveData = PlayerMove(world, terrain, currentTerrainID, MyYX, down, tileTypeMovedFrom);
            break;

        case ConsoleKey.Q:
            moveData = PlayerMove(world, terrain, currentTerrainID, MyYX, left, tileTypeMovedFrom);
            break;

        case ConsoleKey.D:
            moveData = PlayerMove(world, terrain, currentTerrainID, MyYX, right, tileTypeMovedFrom);
            break;

        case ConsoleKey.M:
            WorldMap(world, terrain);
            Console.SetCursorPosition(0, 4);
            Console.WriteLine(player.ShowStatsinWorld());
            Console.WriteLine(terrain.Level);
            break;

        case ConsoleKey.I:
            GameInfoDebugging();
            AddColorsPrintArea("Terrain", terrain.ShowArea());
            Console.SetCursorPosition(0, 4);
            Console.WriteLine(player.ShowStatsinWorld());
            Console.WriteLine(terrain.Level);
            break;
        default:
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            break;
    }
    nextTerrainID = terrain.IDtoIntArray(moveData[0]);
    if (nextTerrainID[0] != currentTerrainID[0] || nextTerrainID[1] != currentTerrainID[1]) // move to next terrain
    {
        terrain = world.Terrains[world.GetIndexOfID(nextTerrainID)];
        currentTerrainID = nextTerrainID;
        Console.Clear();
        AddColorsPrintArea("Terrain", terrain.ShowArea());
        Console.SetCursorPosition(0,4);
        Console.WriteLine(player.ShowStatsinWorld());
    }

    MyYX[0] = int.Parse(moveData[1]);
    MyYX[1] = int.Parse(moveData[2]);
    tileTypeMovedFrom = moveData[3];

    player = TileEvent(tileTypeMovedFrom, player, terrain);  // a player goes to an event and comes back like a different man

    Console.SetCursorPosition(0, 0);
    key = Console.ReadKey().Key;
}
// ------------