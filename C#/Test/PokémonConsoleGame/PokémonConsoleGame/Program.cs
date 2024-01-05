// debug shit
//
//  Console.WriteLine(terrain.Level);
//  Console.WriteLine(terrain.IDtoString() + $"\t{Save.TerrainLevelModifierBySize}");
// 
// 
//
//
//
// 100% van deze code is gescreven ergens tusse 1 en 5 AM - trust the process
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
            default:
                Console.SetCursorPosition(0, 0);
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
    Console.BufferHeight = 2000;
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
    Console.BufferHeight = Console.LargestWindowHeight;
    Console.Clear();
} //TODO shit brokey

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
} // deze shit is op een brakke manier gedaan

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
            Console.ForegroundColor = ConsoleColor.White;
            break;

        case "Fire":
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            break;

        case "Water":
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            break;

        case "Rock":
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            break;

        case "Air":
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            break;

        default:
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
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
    Pokemon GenerateWildPokemon(Pokemon p, Terrain terrain)
    {   // ඞ
        Random rnd = new Random();

        // die level shit man, howly
        int level = Math.Max((p.Level + rnd.Next(0, 3 + (p.Level / 3))), Math.Min(terrain.Level, p.Level+rnd.Next(10,15))); 

        Pokemon enemy = new Pokemon( p.Name, p.Description, p.Evolution, p.UnlockableMoves, p.Type, level,
                                     p.Health-((p.Level-1)*2), p.Attack-(p.Level-1), p.Defense-(p.Level-1), p.Speed );
        return enemy;
    } // dont look inside

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
            //teken le pokemones TODO position die met hun art hoogte in mind
            SetForegroundColorToType(myPokemon.Type);
            x = (Console.WindowWidth * 5 / 100) + ((imageMaxWidth-Save.PokemonASCIIWidth)/2);
            PrintArtWithoutWhiteSpace(myPokemon.ImageSmallWhosThatPokemon, new int[] {x, (Console.WindowHeight*40/100)-1});

            SetForegroundColorToType(enemy.Type);
            x = Console.WindowWidth - (imageMaxWidth - 1 + x) + ((imageMaxWidth - Save.PokemonASCIIWidth));
            PrintArtWithoutWhiteSpace(enemy.ImageSmallWhosThatPokemon, new int[] { x, Console.WindowHeight*20/100});

            // teken le health card thingy

            void DrawPokemonHealthCard(int xBoxPos, int yBoxPos, Pokemon pokemon)
            {
                int width = 60;
                Console.SetCursorPosition(xBoxPos, yBoxPos);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(new string('▓', width));
                for (int i = 0; i < 5; i++)
                {
                    Console.CursorLeft = xBoxPos;
                    Console.WriteLine("▓▓" + new string('█', width - 4) + "▓▓");
                }
                Console.CursorLeft = xBoxPos;
                Console.Write(new string('▓', width));

                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(xBoxPos + 4, yBoxPos + 2);
                Console.Write(pokemon.Name);

                SetBackgroundColorToType(pokemon.Type);
                Console.CursorLeft += 4;
                Console.Write($" {pokemon.Type} ");

                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(width + xBoxPos - 10, yBoxPos + 2);
                Console.WriteLine($"Lv: {pokemon.Level}");

                Console.BackgroundColor = ConsoleColor.DarkGray;

                Console.SetCursorPosition(xBoxPos + 4, yBoxPos + 4);
                Console.Write(" HP:" + new string(' ', width - 20));

                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(xBoxPos + 9, yBoxPos + 4);
                Console.Write(new string('▬', width - 22));

                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;

                Console.CursorLeft += 3;
                Console.Write($"{pokemon.Health}/{pokemon.Health}");

                Console.BackgroundColor = ConsoleColor.Black;
            }

            DrawPokemonHealthCard(8, Console.WindowHeight * 25 / 100, myPokemon);
            DrawPokemonHealthCard(Console.WindowWidth-68, Console.WindowHeight * 5 / 100, enemy);
        }
        void UpdateBattleScreen(Pokemon myPokemon, int myPokeMaxHealth ,Pokemon enemy, int enemyMaxHealth)
        {
            int width = 60;
            int xBoxPos = 8;
            int yBoxPos = Console.WindowHeight* 25/100;

            Console.BackgroundColor = ConsoleColor.DarkGray;

            Console.SetCursorPosition(xBoxPos + 4, yBoxPos + 4);
            Console.Write(" HP:" + new string(' ', width - 20));
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write(new string(' ', 8));
            Console.BackgroundColor = ConsoleColor.DarkGray;

            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(xBoxPos + 9, yBoxPos + 4);
            Console.Write(new string('▬', ((width - 22) * ((myPokemon.Health * 100)/myPokeMaxHealth)) / 100));

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(xBoxPos + 50, yBoxPos + 4);
            Console.Write($"{myPokemon.Health}/{myPokeMaxHealth}");


            xBoxPos = Console.WindowWidth - (width+8);
            yBoxPos = Console.WindowHeight* 5/100;

            Console.BackgroundColor = ConsoleColor.DarkGray;

            Console.SetCursorPosition(xBoxPos + 4, yBoxPos + 4);
            Console.Write(" HP:" + new string(' ', width - 20));
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write(new string(' ', 8));
            Console.BackgroundColor = ConsoleColor.DarkGray;

            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(xBoxPos + 9, yBoxPos + 4);
            Console.Write(new string('▬', ((width - 22)*((enemy.Health*100)/enemyMaxHealth))/100 ));

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(xBoxPos + 50, yBoxPos + 4);
            Console.Write($"{enemy.Health}/{enemyMaxHealth}");

            Console.BackgroundColor = ConsoleColor.Black;
        }

        Tuple<Player,Pokemon> BattleRound(Player player, Pokemon enemy, int enemyMaxHealth)
        {
            void DrawBattleMainOptionsCard(Pokemon pokemon)
            {
                // BOX
                int width = Console.WindowWidth;
                int height = 10;
                Console.SetCursorPosition(0, Console.WindowHeight - height);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(new string('▓', width));
                for (int i = 0; i < height - 2; i++)
                {
                    Console.CursorLeft = 0;
                    Console.WriteLine("▓▓" + new string('█', 20) + "▓▓" + new string('█', (width - 4) - 2 - 20) + "▓▓");
                }
                Console.CursorLeft = 0;
                Console.Write(new string('▓', width));

                //ELEMENTS 
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;

                int x = 6, y = (Console.WindowHeight - height + 3);

                Console.SetCursorPosition(x, y);
                Console.Write("FIGHT");
                Console.SetCursorPosition(x + 8, y);
                Console.Write("PKMN");
                Console.SetCursorPosition(x, y + 3);
                Console.Write("BAG");
                Console.SetCursorPosition(x + 8, y + 3);
                Console.Write("RUN");
            }

            Tuple<Player, Pokemon> DoShitByChoice(Player player, Pokemon enemy, int enemyMaxHealth)
            {
                Pokemon currentPokemon = enemy.CreateDuplicatePokemon(player.PokemonTeam[0]); // enemy omda ik gwn de pokemon ding moet kunnen oproepen is confusing ma foeny
                currentPokemon.Health -= 1;
                Move[] playerMoves = new Move[4];
                for (int i = 0; i < 4; i++)
                {
                    if (currentPokemon.Moves[i] == null) continue;
                    playerMoves[i] = currentPokemon.Moves[i].Item1;
                }

                int width = Console.WindowWidth;
                int height = 10;
                int[] selectorPos = new int[] { 4, (Console.WindowHeight - height + 3) };
                Console.SetCursorPosition(selectorPos[0], selectorPos[1]);
                Console.Write("►");

                int[] OldPos = new int[] { selectorPos[0], selectorPos[1] };

                string[] catagory = { "FIGHT", "PKMN", "BAG", "RUN" };
                int catagoryID = 0;
                int optionID = 0;
                int turn = 0;
                while (optionID != -2)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.SetCursorPosition(24, Console.WindowHeight - height + 1);
                    for (int i = 0; i < height - 2; i++)
                    {
                        Console.WriteLine(new string('█', (width - 4) - 2 - 20));
                        Console.CursorLeft = 24;
                    }
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(0, 0);
                    ConsoleKey key = Console.ReadKey().Key;
                    Console.SetCursorPosition(OldPos[0], OldPos[1]);

                    Move EnemyMove(Pokemon myPKMN, Pokemon enemy, int turn)  // wtf
                    {
                        int CalculateMoveValue(Pokemon target, Pokemon attacker, Move move)
                        {
                            int damageValue = Save.CalculateDamage(target, attacker, move); // TODO add Type and Effect
                            int debuffValue = ( // TODO balance this shit
                                move.AttackDecrease*(target.Attack*10/100) +
                                move.DefenseDecrease*(target.Defense*10/100) + 
                                move.SpeedDecrease*(target.Speed == attacker.Speed? 15: ((int)Math.Pow((10 / Math.Abs(target.Speed - attacker.Speed)), 2))) +
                                move.AccuracyDecrease*(target.Accuracy*5/100) +
                                move.AttackIncrease*(attacker.Attack*10/100) +
                                move.DefenseIncrease*(attacker.Defense*10/100) +
                                move.SpeedIncrease*(target.Speed == attacker.Speed? 15: ((int)Math.Pow((10 / Math.Abs(target.Speed - attacker.Speed)), 2))) +
                                move.AccuracyIncrease*(attacker.Accuracy >= 95? 0: attacker.Accuracy*5/100)
                                );

                            return damageValue + debuffValue;
                        }

                        Random rnd = new Random();

                        Move enemyMove = enemy.Moves[0].Item1;
                        int moveValue = int.MinValue, checkValue;

                        foreach (Tuple<Move, int> move in enemy.Moves)
                        {
                            if (move == null) break;

                            checkValue = CalculateMoveValue(myPKMN, enemy, move.Item1);
                            if (checkValue > moveValue && rnd.Next(0, rnd.Next(0, 2)) == 0)
                            {
                                moveValue = checkValue;
                                enemyMove = move.Item1;
                            }
                        }

                        int[] fuckGoBack = new int[] { Console.CursorLeft, Console.CursorTop };
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine(enemyMove);
                        Console.SetCursorPosition(fuckGoBack[0], fuckGoBack[1]);

                        return enemyMove;
                    }

                    turn++;
                    Move enemyMove = EnemyMove(currentPokemon, enemy, turn);

                    if (currentPokemon.Health <= 0)
                    {
                        key = ConsoleKey.Enter;
                        catagoryID = 1;
                    }

                    while (key != ConsoleKey.Enter)
                    {
                        switch (key)
                        {
                            case ConsoleKey.Z:
                                if (Console.GetCursorPosition().Top != selectorPos[1])
                                {
                                    catagoryID -= 2;
                                    Console.Write(" ");
                                    Console.CursorLeft--;
                                    Console.CursorTop -= 3;
                                }
                                break;

                            case ConsoleKey.S:
                                if (Console.GetCursorPosition().Top == selectorPos[1])
                                {
                                    catagoryID += 2;
                                    Console.Write(" ");
                                    Console.CursorLeft--;
                                    Console.CursorTop += 3;
                                }
                                break;

                            case ConsoleKey.Q:
                                if (Console.GetCursorPosition().Left != selectorPos[0])
                                {
                                    catagoryID -= 1;
                                    Console.Write(" ");
                                    Console.CursorLeft--;
                                    Console.CursorLeft -= 8;
                                }
                                break;

                            case ConsoleKey.D:
                                if (Console.GetCursorPosition().Left == selectorPos[0])
                                {
                                    catagoryID += 1;
                                    Console.Write(" ");
                                    Console.CursorLeft--;
                                    Console.CursorLeft += 8;
                                }
                                break;
                        }
                        OldPos[0] = Console.CursorLeft;
                        OldPos[1] = Console.CursorTop;
                        Console.Write("►");

                        Console.SetCursorPosition(0, 0);
                        key = Console.ReadKey().Key;
                        Console.SetCursorPosition(OldPos[0], OldPos[1]);
                    }

                    switch (catagory[catagoryID])
                    {
                        case "FIGHT":
                            optionID = DrawBattleFightOptions(currentPokemon, 29, selectorPos[1]);

                            if(optionID != -1)
                            {
                                Move playerMove = playerMoves[optionID];
                                // check priorityMove, if equal check pokemonspedd.   player moves first
                                if (playerMove.Priority > enemyMove.Priority || (playerMove.Priority == enemyMove.Priority && currentPokemon.Speed >= enemy.Speed))
                                {
                                    int[] fuckGoBack = new int[] { Console.CursorLeft, Console.CursorTop };
                                    Console.SetCursorPosition(0, 2);
                                    Console.WriteLine($"turn {turn}");
                                    Console.WriteLine($"ehyo criticale hit broer: {Save.CalculateDamage(enemy, currentPokemon, playerMove)}");
                                    Console.SetCursorPosition(fuckGoBack[0], fuckGoBack[1]);

                                    enemy.Health -= Save.CalculateDamage(enemy, currentPokemon, playerMove);
                                    if (enemy.Health <= 0)
                                    {
                                        UpdateBattleScreen(currentPokemon, player.PokemonTeam[0].Health, enemy, enemyMaxHealth);
                                        return new Tuple<Player, Pokemon>(player, enemy);
                                    }

                                    fuckGoBack = new int[] { Console.CursorLeft, Console.CursorTop };
                                    Console.SetCursorPosition(0, 4);
                                    Console.WriteLine($"ehyo criticale hit broer: {Save.CalculateDamage(currentPokemon, enemy, enemyMove)}");
                                    Console.SetCursorPosition(fuckGoBack[0], fuckGoBack[1]);

                                    currentPokemon.Health -= Save.CalculateDamage(currentPokemon, enemy, enemyMove);
                                    if (currentPokemon.Health <= 0)
                                    {
                                        UpdateBattleScreen(currentPokemon, player.PokemonTeam[0].Health, enemy, enemyMaxHealth);
                                        player.PokemonTeam[0] = currentPokemon;
                                        return new Tuple<Player, Pokemon>(player, enemy);
                                    }
                                }
                                else // enemy moves first
                                {
                                    currentPokemon.Health -= Save.CalculateDamage(currentPokemon, enemy, enemyMove);
                                    if (currentPokemon.Health <= 0)
                                    {
                                        player.PokemonTeam[0] = currentPokemon;
                                        return new Tuple<Player, Pokemon>(player, enemy);
                                    }

                                    enemy.Health -= Save.CalculateDamage(enemy, currentPokemon, playerMove);
                                    if (enemy.Health <= 0)
                                    {
                                        return new Tuple<Player, Pokemon>(player, enemy);
                                    }
                                }
                            }

                            break;

                        case "PKMN":
                            // set new pokemon on index 0

                            break;

                        case "BAG":


                            break;

                        case "RUN":


                            break;

                    }

                    UpdateBattleScreen(currentPokemon, player.PokemonTeam[0].Health, enemy, enemyMaxHealth);
                }

                return new Tuple<Player, Pokemon>(player, enemy);
            }
            int DrawBattleFightOptions(Pokemon pokemon, int x, int y)
            {
                // draw options
                Console.SetCursorPosition(x, y);
                int index;
                for (index = 0; index < pokemon.Moves.Length; index++)
                {
                    if (pokemon.Moves[index] == null) break;

                    string moveName = pokemon.Moves[index].Item1.Name;
                    int currentPP = pokemon.Moves[index].Item2;
                    int maxPP = pokemon.Moves[index].Item1.PowerPoints;

                    Console.Write($"{moveName} {currentPP}/{maxPP}");

                    if (index == 1)
                    {
                        Console.SetCursorPosition(x, y + 3);
                    }
                    else
                    {
                        Console.CursorLeft = x + 20;
                    }
                }

                Console.SetCursorPosition(x - 2, y);
                Console.Write("►");

                // select cursor
                int[] OldPos = new int[] { x - 2, y };
                Console.SetCursorPosition(0, 0);
                ConsoleKey key = Console.ReadKey().Key;
                Console.SetCursorPosition(OldPos[0], OldPos[1]);

                int choiceID = 0;
                while (key != ConsoleKey.Enter && key != ConsoleKey.Escape)
                {
                    switch (key)
                    {
                        case ConsoleKey.Z:
                            if (Console.GetCursorPosition().Top != y)
                            {
                                choiceID -= 2;
                                Console.Write(" ");
                                Console.CursorLeft--;
                                Console.CursorTop -= 3;
                            }
                            break;

                        case ConsoleKey.S:
                            if (Console.GetCursorPosition().Top == y && choiceID + 2 < index)
                            {
                                choiceID += 2;
                                Console.Write(" ");
                                Console.CursorLeft--;
                                Console.CursorTop += 3;
                            }
                            else if (Console.GetCursorPosition().Top == y && choiceID == 1 && index == 3)
                            {
                                choiceID += 1;
                                Console.Write(" ");
                                Console.CursorLeft--;
                                Console.CursorTop += 3;
                                Console.CursorLeft -= 20;
                            }
                            break;

                        case ConsoleKey.Q:
                            if (Console.GetCursorPosition().Left != x - 2)
                            {
                                choiceID -= 1;
                                Console.Write(" ");
                                Console.CursorLeft--;
                                Console.CursorLeft -= 20;
                            }
                            break;

                        case ConsoleKey.D:
                            if (Console.GetCursorPosition().Left == x - 2 && choiceID + 1 < index)
                            {
                                choiceID += 1;
                                Console.Write(" ");
                                Console.CursorLeft--;
                                Console.CursorLeft += 20;
                            }
                            else if (Console.GetCursorPosition().Left == x - 2 && choiceID == 2 && index == 3)
                            {
                                choiceID -= 1;
                                Console.Write(" ");
                                Console.CursorLeft--;
                                Console.CursorTop -= 3;
                                Console.CursorLeft += 20;
                            }
                            break;
                    }
                    OldPos[0] = Console.CursorLeft;
                    OldPos[1] = Console.CursorTop;
                    Console.Write("►");

                    Console.SetCursorPosition(0, 0);
                    key = Console.ReadKey().Key;
                    Console.SetCursorPosition(OldPos[0], OldPos[1]);

                    if (key == ConsoleKey.Enter && pokemon.Moves[choiceID].Item2 == 0) // TODO add struggle bcs it only works when no PP
                    {
                        key = ConsoleKey.N; // n stands for NOPE CANT DO THAT JIMMY
                    }
                }
                if (key == ConsoleKey.Escape) choiceID = -1;

                return choiceID;
            }

            Tuple<Player, Pokemon> battleData;
            while (true)
            {
                DrawBattleMainOptionsCard(player.PokemonTeam[0]);
                battleData = DoShitByChoice(player, enemy, enemyMaxHealth);
                Thread.Sleep(100);
                if (battleData.Item2.Health <= 0)
                {
                    return battleData;
                }
                else if (battleData.Item1.PokemonTeam[0].Health <= 0)
                {
                    return battleData;
                }
            }
        }

        // transition
        string line = new string(' ', Save.TerrainWidth * 2 + Save.DataLocSize.Length) + "\n" +
                      new string(' ', Save.TerrainWidth * 2 + Save.DataLocSize.Length) + "\n" +
                      new string(' ', Save.TerrainWidth * 2 + Save.DataLocSize.Length) + "\n";
        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < (Save.TerrainHeigth + 10); i += 3)
        {
            Thread.Sleep(25); // task delay also a thing but is used when multiple threads ig, idk im noob
            Console.Write(line);
        }
        Console.Clear();
        Thread.Sleep(1000);

        // fight start

        int pokemonIndex = 0;
        ShowBattleScreen(player.PokemonTeam[pokemonIndex], enemy);
        int enemyMaxHealth = enemy.Health;
        Tuple<Player, Pokemon> battleData;

        while (true) // damn eindelijk werken aan de combat, ik zie er zeker naar uit...    maar ik doe het morge wel...  100% ik zweer
        {
            Thread.Sleep(1000);

            battleData = BattleRound(player, enemy, enemyMaxHealth);
            player = battleData.Item1;
            enemy = battleData.Item2;

            // check if player has non dead pokemon left & end battle check
            bool anotherPokemon = false;
            foreach (Pokemon pokemon in player.PokemonTeam)
            {
                if (pokemon == null) break;

                if (pokemon.Health > 0)
                {
                    anotherPokemon = true;
                    // TODO a switcherooo (rhymes for all times)
                    break;
                }
            }
            if (anotherPokemon == false || enemy.Health <= 0)
            {
                break;
            }
        }

        Console.Clear();
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
            if (player.PokemonTeam[0].Health <= 0)
            {
                return player;
            }
            Pokemon pokemon;
            do // TODO normaal gezien moet dit ni want da gebeurt al inde fucking terrain constructor, ma voor nu, is ok he.
            {
                int randomPokemonId = rnd.Next(0, terrain.WildPokemon.Count);
                pokemon = terrain.WildPokemon[randomPokemonId];
            } while (pokemon.Level > terrain.Level);

            player = FightWildPokemon(player, GenerateWildPokemon(pokemon, terrain));
        }
    }


    return player;
}

//----------------------- MAIN --------------------------

//--- Setup ---
Console.BackgroundColor = ConsoleColor.Black;
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
            Console.CursorVisible = false;
            break;
    }
    nextTerrainID = terrain.IDtoIntArray(moveData[0]);
    if (nextTerrainID[0] != currentTerrainID[0] || nextTerrainID[1] != currentTerrainID[1])
    {
        terrain = world.Terrains[world.GetIndexOfID(nextTerrainID)];
        currentTerrainID = nextTerrainID;
        Console.Clear();
        AddColorsPrintArea("Terrain", terrain.ShowArea());
        Console.SetCursorPosition(0,4);
        Console.WriteLine(player.ShowStatsinWorld());
    } // move to next terrain

    MyYX[0] = int.Parse(moveData[1]);
    MyYX[1] = int.Parse(moveData[2]);
    tileTypeMovedFrom = moveData[3];

    player = TileEvent(tileTypeMovedFrom, player, terrain);  // a player goes to an event and comes back like a different man - stay sober kids

    Console.SetCursorPosition(0, 0);
    key = Console.ReadKey().Key;
}
// ------------