using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokémonConsoleGame.Area
{
    public class Terrain : Area
    {

        private int[] _id;
        private int[][] _gateLocations;
        private int[][] _AdjacentGateLocations;
        private int _level;
        private List<Pokemon> _wildPokemon;

        public int[] ID { get { return _id; } set { _id = value; } }
        public int[][] GateLocations { get { return _gateLocations; } set { _gateLocations = value; } }
        public int[][] AdjacentGateLocations { get { return _AdjacentGateLocations; } set { _AdjacentGateLocations = value; } }
        public int Level { get { return _level; } set { _level = value; } }
        public List<Pokemon> WildPokemon { get { return _wildPokemon; } set { _wildPokemon = value; } }

        public Terrain(int[] id, int boxWidth, int boxHeight, int[][] gateLocations) : base(boxWidth, boxHeight)
        { 
            this.ID = id;
            this.GateLocations = new int[4][];
            this.AdjacentGateLocations = gateLocations;
            this.Level = (Math.Abs(id[0]) + Math.Abs(id[1])) * Save.TerrainLevelModifierBySize;
            this.WildPokemon = Save.AllPokemon; // TODO each terrain(type) gets his own set of pokemon
            GenerateTerrain();
        }

        private string[][] GenerateTerrain() 
        {
            Box = GenerateArea();

            GenerateTrees();
            GenerateGrass();
            GenerateItems();
            GenerateGates();

            int[] centerTerrainID = new int[] {0,0};
            if (ID[0] == centerTerrainID[0] && ID[1] == centerTerrainID[1]) FindSpawn();

            return Box;
        }

        // ToString-Shit

        public string IDtoString()
        {
            return $"{ID[0]};{ID[1]}";
        }
        public int[] IDtoIntArray(string id)
        {
            string[] data = id.Split(';');
            int[] result = new int[] {int.Parse(data[0]), int.Parse(data[1])};
            return result;
        }

        // Tile SHIT
        private int CheckAdjacentTiles(string checkType, int y, int x)
        {
            int amountFound = 0;
            if (Box[y-1][x] == checkType) amountFound++;
            if (Box[y+1][x] == checkType) amountFound++;
            if (Box[y][x-1] == checkType) amountFound++;
            if (Box[y][x+1] == checkType) amountFound++;
            return amountFound;
        }
        private void DeleteLoneTileType(string tileType, int min)
        {
            for (int y = 1; y < BoxHeigth - 1; y++)
            {
                for (int x = 1; x < BoxWidth - 1; x++)
                {
                    if (Box[y][x] == tileType)
                    {
                        int amount = CheckAdjacentTiles(tileType, y, x);
                        if (amount < min) Box[y][x] = Empty;
                    }
                }
            }
        }
        private void SpreadToSurroundingTiles(int staleChance, string type, int y, int x)
        {
            Random rnd = new Random();
            staleChance += rnd.Next(rnd.Next(1, 3), 3); // + 1: 25% | + 2: 75%
            if (Box[y][x] == type)
            {
                if (Box[y-1][x] == Empty) Box[y-1][x] = (rnd.Next(0, staleChance) == 0 ? type : Empty);
                if (Box[y+1][x] == Empty) Box[y+1][x] = (rnd.Next(0, staleChance) == 0 ? type : Empty);
                if (Box[y][x-1] == Empty) Box[y][x-1] = (rnd.Next(0, staleChance) == 0 ? type : Empty);
                if (Box[y][x+1] == Empty) Box[y][x+1] = (rnd.Next(0, staleChance) == 0 ? type : Empty);
            }
        }

        // TREE SHIT -- idk what im doing, but hey i be coding
        private void GenerateTrees()
        {
            Random rnd = new Random();
            int tenPercentOfTotal = ((BoxWidth - 2) * (BoxHeigth - 2)) / 10;

            for (int i = 0; i < tenPercentOfTotal; i++)
            {
                int x = rnd.Next(1, BoxWidth-1);
                int y = rnd.Next(1, BoxHeigth-1);
                Box[y][x] = Tree;
            }

            // Refine Trees
            for (int y = 1; y < BoxHeigth - 1; y++)
            {
                for (int x = 1; x < BoxWidth - 1; x++)
                {
                    if (Box[y][x] == Empty)
                    {
                        int spawnTree = 1;
                        int amount = 3-CheckAdjacentTiles(Tree, y, x);
                        for (int i = 0; i < amount; i++)
                        {
                            spawnTree = rnd.Next(0, spawnTree+1);
                            spawnTree = rnd.Next(0, spawnTree+1);
                        }
                        if (spawnTree == 1)
                        {
                            Box[y][x] = Tree;
                        }
                    }
                }
            }

            DeleteLoneTileType(Tree,1);
        }
        private void GenerateGrass()
        {
            Random rnd = new Random();
            int fivePercentOfTotal = ((BoxWidth - 2) * (BoxHeigth - 2)) / 20;

            for (int i = 0; i < fivePercentOfTotal; i++)
            {
                int x = rnd.Next(3, BoxWidth - 3);
                int y = rnd.Next(3, BoxHeigth - 3);
                if (Box[y][x] == Empty)
                {
                    Box[y][x] = Grass;
                }
            }

            // Refine Grass
            for (int i = 1; i < 3; i++)
            {
                for (int y = 1; y < BoxHeigth - 1; y++)
                {
                    for (int x = 1; x < BoxWidth - 1; x++)
                    {
                        if (Box[y][x] == Grass)
                        {
                            SpreadToSurroundingTiles(i, Grass, y, x);
                        }
                    }
                }
            }

            for (int i = 0;i < 3;i++) // uhm idk random number ig ma het werkt tot nu toe
            {
                DeleteLoneTileType(Grass, 2);
            }
        }

        // Add gates to move to the next terrain or smtn
        private void GenerateGates()
        {
            int[] up = AdjacentGateLocations[0];
            int[] down = AdjacentGateLocations[1];
            int[] left = AdjacentGateLocations[2];
            int[] right = AdjacentGateLocations[3];

            if (down != null) // when entering new terrain going up generate gate at Bottom
            {
                GateLocations[1] = down;
                for (int i = down[0]; i < down[1]; i++)
                {
                    Box[BoxHeigth-1][i] = Empty;
                }
            }
            else
            {
                CreateGate(1, BoxWidth);
                for (int i = GateLocations[1][0]; i < GateLocations[1][1]; i++)
                {
                    Box[BoxHeigth-1][i] = Empty;
                }
            }

            if (up != null) // Top
            {
                GateLocations[0] = up;
                for (int i = up[0]; i < up[1]; i++)
                {
                    Box[0][i] = Empty;
                }
            }
            else
            {
                CreateGate(0, BoxWidth);
                for (int i = GateLocations[0][0]; i < GateLocations[0][1]; i++)
                {
                    Box[0][i] = Empty;
                }
            }

            if (right != null) // Right
            {
                GateLocations[3] = right;
                for (int i = right[0]; i < right[1]; i++)
                {
                    Box[i][BoxWidth-1] = Empty;
                }
            }
            else
            {
                CreateGate(3, BoxHeigth);
                for (int i = GateLocations[3][0]; i < GateLocations[3][1]; i++)
                {
                    Box[i][BoxWidth-1] = Empty;
                }
            }
            
            if (left != null) // Left
            {
                GateLocations[2] = left;
                for (int i = left[0]; i < left[1]; i++)
                {
                    Box[i][0] = Empty;
                }
            }
            else
            {
                CreateGate(2, BoxHeigth);
                for (int i = GateLocations[2][0]; i < GateLocations[2][1]; i++)
                {
                    Box[i][0] = Empty;
                }
            }
        }
        private void CreateGate(int gateIndex, int boxSideLength)
        {
            Random rnd = new Random();

            int min = (boxSideLength / 10)+1;
            int max = boxSideLength - min;
            int maxLength = boxSideLength / 2;
            int gateLength = rnd.Next(min + 1, rnd.Next(min + 1, maxLength + 1) + 1);

            if (rnd.Next(0, 2) == 1)
            {
                int startIndex = rnd.Next(min, max - gateLength + 1);
                int endIndex = startIndex + gateLength;
                GateLocations[gateIndex] = new int[] { startIndex, endIndex };
            }
            else
            {
                GateLocations[gateIndex] = new int[] { 0, 0 };
            }
        }

        // add like random items to be found in terrain
        private bool CheckSurroundingTiles(int y, int x)
        {
            bool spotFound = true;
            for (int k = y - 1; k < y + 2; k++)
            {
                for (int z = x - 1; z < x + 2; z++)
                {
                    if (Box[k][z] == Empty)
                    {
                        spotFound = false;
                        break;
                    }
                }
            }
            return spotFound;
        }
        private void GenerateItems()
        {
            Random rnd = new Random();
            bool validSpot;
            for (int y = 1; y < BoxHeigth - 1; y++)
            {
                for (int x = 1; x < BoxWidth - 1; x++)
                {
                    if (Box[y][x] != Grass) continue;
                    validSpot = CheckSurroundingTiles(y, x);
                    if (validSpot && rnd.Next(0,10+(BoxWidth*BoxHeigth/64)) == 0)
                    {
                        Box[y][x] = Item;
                    }
                }
            }
        }


        // Some player movement
        public override bool CheckValidPostition(int y, int x)
        {
            string TileType = Box[y][x];
            if (TileType == Border || TileType == Tree)
            {
                return false;
            }
            return true;
        }

        

        //end
    }
}
