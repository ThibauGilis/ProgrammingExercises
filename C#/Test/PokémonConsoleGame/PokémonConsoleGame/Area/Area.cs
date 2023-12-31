using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PokémonConsoleGame.Area
{
    public class Area
    {
        private int _boxWidth;
        private int _boxHeight;
        private string[][] _box;
        private int[] _spawnPoint;

        public int BoxWidth { get { return _boxWidth; } set { _boxWidth = value; } }
        public int BoxHeigth { get { return _boxHeight; } set { _boxHeight = value; } }
        public string[][] Box { get { return _box; } set { _box = value; } }
        public int[] SpawnPoint { get { return _spawnPoint; } set { _spawnPoint = value; } }

        // TileTypes
        public readonly string Border = Save.Border;
        public readonly string Empty = Save.Empty;
        public readonly string Tree = Save.Tree;
        public readonly string Grass = Save.Grass;
        public readonly string Person = Save.Person;

        public Area(int boxWidth, int boxHeigth)
        {
            this.BoxWidth = boxWidth;
            this.BoxHeigth = boxHeigth;
        }

        public string ShowArea()
        {
            string terrain = "";
            foreach (string[] row in Box)
            {
                terrain += Save.DataLocSize;
                foreach (string tile in row)
                {
                    terrain += tile;
                }
                terrain += "\n";
            }
            return terrain;
        }

        public string[][] GenerateArea()
        {
            string[][] area = new string[BoxHeigth][];

            area[0] = GenerateTopBottomBorder();
            area[BoxHeigth - 1] = GenerateTopBottomBorder();

            for (int i = 1; i < BoxHeigth - 1; i++)
            {
                string[] row = new string[BoxWidth];
                row[0] = Border; row[BoxWidth - 1] = Border;  // left/right-side border

                for (int j = 1; j < BoxWidth - 1; j++)
                {
                    row[j] = Empty;
                }
                area[i] = row;
            }

            return area;
        }
        private string[] GenerateTopBottomBorder()
        {
            string[] row = new string[BoxWidth];
            for (int i = 0; i < BoxWidth; i++)
            {
                row[i] = Border;
            }
            return row;
        }

        internal void FindSpawn()
        {
            bool SpawnFound;
            for (int y = 3; y < BoxHeigth - 3; y++)
            {
                for (int x = 3; x < BoxWidth - 3; x++)
                {
                    SpawnFound = CheckSurroundingTiles(y, x);
                    if (SpawnFound)
                    {
                        SpawnPoint = new int[] { y, x };
                        Box[y][x] = Person;
                        return;
                    }
                }
            }
            SpawnPoint = null;
        }
        private bool CheckSurroundingTiles(int y, int x)
        {
            bool SpawnFound = true;
            for (int k = y - 2; k < y + 3; k++)
            {
                for (int z = x - 2; z < x + 3; z++)
                {
                    if (Box[k][z] == Tree || Box[k][z] == Grass)
                    {
                        SpawnFound = false;
                        break;
                    }
                }
            }
            return SpawnFound;
        }

        public virtual bool CheckValidPostition(int y, int x)
        {
            if (Box[y][x] == Border)
            {
                return false;
            }
            return true;
        }
    }
}