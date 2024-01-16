using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokémonConsoleGame.Area
{
    public class World
    {
        private List<Terrain> _terrains;
        private List<int[]> _terrainIDs;
        private List<string> _map;

        public List<Terrain> Terrains { get { return _terrains; } set { _terrains = value; } }
        public List<int[]> TerrainIDs { get { return _terrainIDs; } set { _terrainIDs = value; } }
        public List<string> Map { get { return _map; } set { _map = value; } }

        public World()
        {
            this.Terrains = new List<Terrain>();
            this.TerrainIDs = new List<int[]>();
            int[] startID = new int[] {0,0};
            int[][] gateLocations = new int[][] {null,null,null,null};
            Terrain terrainStart = new Terrain(startID, Save.TerrainWidth, Save.TerrainHeigth, gateLocations);
            Terrains.Add(terrainStart);
            TerrainIDs.Add(startID);
        }

        // domme kut arrays werke ni mee
        private bool CheckTwoIntArraysEqual(int[] One, int[] Two)
        {
            if (One.Length != Two.Length) return false;
            for (int i = 0; i < One.Length; i++)
            {
                if (One[i] != Two[i]) return false;
            }
            return true;
        }
        public int GetIndexOfID(int[] ID)
        {
            for (int i = 0; i < TerrainIDs.Count; i++)
            {
                if (CheckTwoIntArraysEqual(TerrainIDs[i], ID)) return i;
            }
            return -1;
        }
        //-----------

        public Terrain MoveToNextTerrain(int[] vector, int[] currentTerrainID)
        {
            int[] nextTerrainID = new int[] { currentTerrainID[0] + vector[0], currentTerrainID[1] + vector[1] };
            int index = GetIndexOfID(nextTerrainID);
            if (index == -1) // not found
            {
                int[][] adjacentGateLocations = FindAdjacentGates(nextTerrainID);

                Terrain terrain = new Terrain(nextTerrainID, Save.TerrainWidth, Save.TerrainHeigth, adjacentGateLocations);
                TerrainIDs.Add(nextTerrainID);
                Terrains.Add(terrain);
                return terrain;
            }
            return Terrains[index];
        }
        private int[][] FindAdjacentGates(int[] middleTerrainID)
        {
            int[][] adjacentGateLocations = new int[4][];
            int index;

            //terrains
            int[] up = new int[] { middleTerrainID[0]-1, middleTerrainID[1] };
            int[] down = new int[] { middleTerrainID[0]+1, middleTerrainID[1] };
            int[] left = new int[] { middleTerrainID[0], middleTerrainID[1]-1 };
            int[] right = new int[] { middleTerrainID[0], middleTerrainID[1]+1 };

            index = GetIndexOfID(up);
            if (index != -1)
            {
                adjacentGateLocations[0] = Terrains[index].GateLocations[1];
            }
            else adjacentGateLocations[0] = null;

            index = GetIndexOfID(down);
            if (index != -1)
            {
                adjacentGateLocations[1] = Terrains[index].GateLocations[0];
            }
            else adjacentGateLocations[1] = null;

            index = GetIndexOfID(left);
            if (index != -1)
            {
                adjacentGateLocations[2] = Terrains[index].GateLocations[3];
            }
            else adjacentGateLocations[2] = null;

            index = GetIndexOfID(right);
            if (index != -1)
            {
                adjacentGateLocations[3] = Terrains[index].GateLocations[2];
            }
            else adjacentGateLocations[3] = null;

            return adjacentGateLocations;
        }

        //SHOW MAP OF WORLD
        public string ShowMap(int[] playerLocation)
        {
            this.Map = new List<string>();
            UpdateMap(playerLocation);
            string FullMap = "";
            int height = 0;
            foreach(string str in Map)
            {
                if (str == "separator") height++;
            }
            int width = (Map.Count - height) / height;

            for (int i = 0; i < Map.Count; i += width+1)
            {
                for (int l = 0; l < 3; l++)
                {
                    for (int k = i; k < i+width; k++)
                    {
                        FullMap += Map[k].Substring(l*6, 5); // dont question it (bassicly size of map square)
                    }
                    FullMap += "\n\t";
                }
            }
            FullMap = FullMap.Remove(FullMap.IndexOf(Save.Person) + 1, 1);
            return FullMap;
        }
        private void UpdateMap(int[] playerLocation)
        {
            List<int[]> MapIDs1 = TerrainIDs.OrderBy(id => id[0]).ThenBy(id => id[1]).ToList(); // sorted heigth first then width
            int top = MapIDs1[0][0];
            int bottom = MapIDs1[MapIDs1.Count-1][0]+1;
            List<int[]> MapIDs2 = MapIDs1.OrderBy(id => id[1]).ToList(); // sorted width || .ThenBy(id => id[0]) not needed
            int left = MapIDs2[0][1];
            int right = MapIDs2[MapIDs1.Count-1][1]+1;

            int[] zeroZero = new int[] {0,0};

            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    string mapPiece;
                    int id = GetIndexOfID(new int[] { y, x });
                    if (id != -1)
                    {   // ┌ ┐└ ┘ ─ │  map icons
                        mapPiece = $"┌{(CheckTwoIntArraysEqual(Terrains[id].GateLocations[0], zeroZero) ? "───" : "   ")}┐\n";
                        mapPiece += $"{(CheckTwoIntArraysEqual(Terrains[id].GateLocations[2], zeroZero) ? "│" : " ")}{((y == playerLocation[0] && x == playerLocation[1]) ? $" {Save.Person} ": "   ")}{(CheckTwoIntArraysEqual(Terrains[id].GateLocations[3], zeroZero) ? "│" : " ")}\n";
                        mapPiece += $"└{(CheckTwoIntArraysEqual(Terrains[id].GateLocations[1], zeroZero) ? "───" : "   ")}┘";
                    }
                    else
                    {
                        mapPiece = "     \n" +
                                   "     \n" +
                                   "     ";
                    }
                    Map.Add(mapPiece);
                }
                Map.Add("separator");
            }
        }

        // end
    }
}
