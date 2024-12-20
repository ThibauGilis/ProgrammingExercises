﻿using System;
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

        // Items
        public static List<Item> AllItems;

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
        public static string Item = "㋰";

        // Player Settings
        public static Player Player;
        public static int[] RarityWeigths = { 125, 25, 5, 1};
        public static int[] SummedWeigths = { 0, 0, 0, 0};

        // Program.cs Shit
        public static World World;
        public static Terrain Terrain; // code in Program.cs re-arrangen omdit in World te plaatsen ig
        public static int[] MyYX;
        public static string TileTypeMovedFrom;
        public static int[] CurrentTerrainID;


        // ASCII art data
        public static int PokemonASCIIWidth = 50;
        public static string[] BattlePlatform; //string array prints faster TODO keep the '\n' or no?
        public static string[] PlayerBag;
        public static string[] PokeBall;

        public static void NewGame()
        {
            FileOperations.LoadAllMoves();
            FileOperations.LoadAllPokemonMoveSets();
            FileOperations.LoadAllPokemon();
            FileOperations.LoadAllItems();
            BattlePlatform = FileOperations.LoadOtherAsciiArt("BattlePlatform");
            PokeBall = FileOperations.LoadOtherAsciiArt("PokeBall");
            PlayerBag = FileOperations.LoadOtherAsciiArt("Bag");


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

        public static int CalculateDamage(Pokemon attacker, Move move, Pokemon target)
        {
            double damage;

            double A = attacker.Attack;
            double L = attacker.Level;

            double a = move.AttackDamage;

            double d = target.Defense;
            double l = target.Level;

            damage = (1 + (A - d) * 2 / 100) * a * 0.15 * (L / l * 0.5) * L / 6 /** Math.Abs(L-l)/20*/; // kdenk dat dit goe is idk

            return (int)Math.Ceiling(damage);
        }
    }
}
