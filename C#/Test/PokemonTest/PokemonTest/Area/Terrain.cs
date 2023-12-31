using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Area
{
    public static class Terrain
    {
        public static int BoxSize = 10;
        /*public static int BoxWidth = 0;
        public static int BoxHeigth = 0;*/
        /*public static int[] AmountTiles = new int[2];*/

        public static string ShowTerrain(string[][] area)
        {
            string terrain = "\t";
            foreach (string[] row in area)
            {
                foreach (string tile in row)
                {
                    terrain += tile;
                }
                terrain += "\n\t";
            }
            return terrain;
        }
        public static int[] CalculateSpawn(string[][] area)
        {
            for (int i = 3; i < BoxSize-3; i++)
            {
                bool SpawnFound = true;
                for (int j = 3; j < BoxSize-3; j++)
                {
                    for (int k = i-2; k < i+3; k++)
                    {
                        for (int z = j-2; z < j+3; z++) 
                        {
                            if (area[k][z] == "#" || area[k][z] == "^")
                            {
                                SpawnFound = false;
                                break;
                            }
                        }
                    }
                    if (SpawnFound)
                    {
                        return new int[] {i,j};
                    }
                }
            }
            return null;
        }

        //----------- TERRAIN GENERATOR -----------
        public static string[][] GenerateTerrain()
        {
            string[][] area = new string[BoxSize][];
            
            area[0] = GenerateTopBottomBorder();
            area[BoxSize-1] = GenerateTopBottomBorder();

            for (int i = 1; i < BoxSize-1; i++)
            {
                string[] row = new string[BoxSize];
                row[0] = "#"; row[BoxSize-1] = "#";  // left/right-side border

                for (int j = 1; j < BoxSize-1; j++)
                {
                    row[j] = GenerateRandomAreaTile();
                }
                area[i] = row;
            }

            area = RefineTerrain(area);
            return GenerateGrassPatches(area);
        }
        private static string[] GenerateTopBottomBorder() 
        {
            string[] row = new string[BoxSize];
            for (int i = 0; i < BoxSize; i++)
            {
                row[i] = "#";
            }
            return row;
        }
        private static string GenerateRandomAreaTile()
        {
            string tile;
            int tileID;
            Random random = new Random();

            tileID = random.Next(0, 2);
            tileID = random.Next(0, tileID + 1);
            tileID = random.Next(0, tileID + 1);
            tileID = random.Next(0, tileID + 1);

            switch (tileID)
            {
                case 0:
                    tile = " ";
                    /*AmountTiles[0]++;*/
                    break;

                case 1:
                    tile = "#";
                    /*AmountTiles[1]++;*/
                    break;

                default:
                    tile = " ";
                    break;
            }

            return tile;
        }
        private static string[][] RefineTerrain(string[][] terrain)
        {
            Random random = new Random();

            for (int i = 1; i < BoxSize-1; i++)
            {
                for (int j = 1; j < BoxSize-1; j++)
                {
                    int tileID = 1;
                    int amountEmpty = 3;
                    if (terrain[i][j] == " ")
                    {
                        if (terrain[i-1][j] == "#") amountEmpty--;
                        if (terrain[i+1][j] == "#") amountEmpty--;
                        if (terrain[i][j-1] == "#") amountEmpty--;
                        if (terrain[i][j+1] == "#") amountEmpty--;

                        for (int k = 0; k < amountEmpty; k++)
                        {
                            tileID = random.Next(0,tileID+1);
                            tileID = random.Next(0, tileID+1);
                        }
                        if (tileID == 1) terrain[i][j] = "#";
                    }
                }
            }
            for (int i = 1; i < BoxSize - 1; i++)
            {
                for (int j = 1; j < BoxSize - 1; j++)
                {
                    int amountTrees = 4;
                    if (terrain[i][j] == "#")
                    {
                        if (terrain[i-1][j] == " ") amountTrees--;
                        if (terrain[i+1][j] == " ") amountTrees--;
                        if (terrain[i][j-1] == " ") amountTrees--;
                        if (terrain[i][j+1] == " ") amountTrees--;

                        if (amountTrees == 0) terrain[i][j] = " ";
                    }
                }
            }

            return terrain;
        }
        private static string[][] GenerateGrassPatches(string[][] terrain)
        {
            Random random = new Random();
            for(int i = 0; i < 5; i++)
            {
                int y = random.Next(3, BoxSize-3);
                int x = random.Next(3, BoxSize - 3);
                if (terrain[y][x] == " ")
                {
                    terrain[y][x] = "^";
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int y = 1; y < BoxSize - 1; y++)
                {
                    for (int x = 1; x < BoxSize - 1; x++)
                    {
                        if (terrain[y][x] == "^")
                        {
                            if (terrain[y-1][x] == " ") terrain[y-1][x] = (random.Next(0,i+2) == 0? "^": " ");
                            if (terrain[y+1][x] == " ") terrain[y+1][x] = (random.Next(0,i+2) == 0? "^": " ");
                            if (terrain[y][x-1] == " ") terrain[y][x-1] = (random.Next(0,i+2) == 0? "^": " ");
                            if (terrain[y][x+1] == " ") terrain[y][x+1] = (random.Next(0,i+2) == 0? "^": " ");
                        }
                    }
                }
            }

            return terrain;
        }
    }
}