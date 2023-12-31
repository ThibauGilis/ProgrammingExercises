// debug shit
//
//
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
// insanity time
using System;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;

void Settings()
{
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    AreaSettings.TerrainHeigth = 14;
    AreaSettings.TerrainWidth = 14;
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
    Console.SetCursorPosition(0, 0);
}

void AddColorsPrintArea(string areaType, string areaData)
{
    if (areaType == "Terrain")
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        int i = 0;
        int lowIndex = 0, index;
        char tileType;
        char[] tileTypes = new char[] {
            AreaSettings.Empty[0],
            AreaSettings.Border[0],
            AreaSettings.Tree[0],
            AreaSettings.Grass[0],
            AreaSettings.Person[0] };
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
}

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
    else if (y == terrain.BoxHeigth-1 && vector[0] == 1)
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
        x = terrain.BoxWidth-1;
        terrain.Box[y][x] = terrain.Person;
    }
    else if (x ==  terrain.BoxWidth-1 && vector[1] == 1)
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
            Console.SetCursorPosition(x * 2 + 8, y); //+8 for a \t
            if (tileTypeMovedFrom == AreaSettings.Grass)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.Write(tileTypeMovedFrom);
            terrain.Box[y][x] = tileTypeMovedFrom;
            y += vector[0];
            x += vector[1];
            tileTypeMovedFrom = terrain.Box[y][x];
            Console.SetCursorPosition(x * 2 + 8, y); //+8 for a \t
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(terrain.Person);
            terrain.Box[y][x] = terrain.Person;
        }
    }
    Console.SetCursorPosition(0, 0);
    return new string[] { terrain.IDtoString(), $"{y}", $"{x}", tileTypeMovedFrom };
}



//----------------------- MAIN --------------------------

//--- Setup
DateTime dateTime = DateTime.Now;

Settings();

World world = null;
Terrain terrain = null;
do
{
    world = new World();
    terrain = world.Terrains[0];
} while (terrain.SpawnPoint == null);
AddColorsPrintArea("Terrain", terrain.ShowArea());

int[] up = new int[] { -1, 0 };
int[] down = new int[] { 1, 0 };
int[] left = new int[] { 0, -1 };
int[] right = new int[] { 0, 1 };
int[] MyYX = terrain.SpawnPoint;
string tileTypeMovedFrom = terrain.Empty;
string[] moveData = new string[] { terrain.IDtoString(), $"{MyYX[0]}", $"{MyYX[1]}", tileTypeMovedFrom};
int[] currentTerrainID = terrain.ID;
int[] nextTerrainID = currentTerrainID;

Console.WriteLine($"Startup: {(DateTime.Now - dateTime).TotalMilliseconds} MilliSeconds");
//---

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
            break;
    }
    nextTerrainID = terrain.IDtoIntArray(moveData[0]);
    if (nextTerrainID[0] != currentTerrainID[0] || nextTerrainID[1] != currentTerrainID[1])
    {
        terrain = world.Terrains[world.GetIndexOfID(nextTerrainID)];
        currentTerrainID = nextTerrainID;
        Console.Clear();
        AddColorsPrintArea("Terrain" ,terrain.ShowArea());
        Console.SetCursorPosition(0, 0);
    }
    MyYX[0] = int.Parse(moveData[1]);
    MyYX[1] = int.Parse(moveData[2]);
    tileTypeMovedFrom = moveData[3];

    key = Console.ReadKey().Key;
}