using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokémonConsoleGame.GameData
{
    public static class Save
    {
        // Pokemon & Moves Data
        public static List<Pokemon> AllPokemon;
        public static List<Move> AllMoves;
        public static List<PokemonMoveSet> AllPokemonMoveSets;
        public static string[] StarterPokemon = new string[] { "Bulbasaur", "Charmander", "Squirtle" };

        // Area Settings
        public static string DataLocSize = new string(' ', 24);
        public static int TerrainHeigth;
        public static int TerrainWidth;
        public static int TerrainLevelModifierBySize;
        public static string Border = "##";
        public static string Empty = "  ";
        public static string Tree = "木";
        public static string Grass = "ゞ";
        public static string Person = "웃";

        // Player Settings
        public static Player Player;


        // Program.cs Shit
        public static World World;
        public static Terrain Terrain; // code in Program.cs re-arrangen omdit in World te plaatsen ig
        public static int[] MyYX;
        public static string TileTypeMovedFrom;
        public static int[] CurrentTerrainID;


        // ASCII art data
        public static int PokemonASCIIWidth = 50;
        public static string[] BattlePlatform; //string array prints faster TODO keep the '\n' or no?
        public static string[] PokeBall;

        public static void NewGame()
        {
            FileOperations.LoadAllMoves();
            FileOperations.LoadAllPokemonMoveSets();
            FileOperations.LoadAllPokemon();
            BattlePlatform = FileOperations.LoadOtherAsciiArt("BattlePlatform");
            PokeBall = FileOperations.LoadOtherAsciiArt("PokeBall");


            do
            {
                World = new World();
                Terrain = World.Terrains[0];
            } while (Terrain.SpawnPoint == null);

            MyYX = Terrain.SpawnPoint;
            TileTypeMovedFrom = Terrain.Empty;
            CurrentTerrainID = Terrain.ID;

            Player = new Player(string.Empty, 0, new Pokemon[6], new List<Pokemon>(), new List<Item>());
        }

        public static void Load()
        {
            // TODO Ma wa te hell isdees allemaal, denke die manne dak ik 100 jaar leef ofzo
            // player kan gemaakt worden in FileOperations en dan ook de properties
        }

        public static int CalculateDamage(Pokemon target, Pokemon attacker, Move move)
        {
            int damage = ((attacker.Attack * move.AttackDamage)*100 / (int)Math.Pow(target.Defense, 2))*3 /100;
            return damage;
        }
    }
}
