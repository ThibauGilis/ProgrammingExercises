using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using PokémonConsoleGame.Items;
using static System.Net.Mime.MediaTypeNames;

namespace PokémonConsoleGame.GameData
{
    public static class FileOperations
    {
        public static string PokemonDataFile = "GameData\\PokemonData.csv";
        public static string MovesDataFile = "GameData\\MoveData.csv";
        public static string PokemonMoveSetDataFile = "GameData\\PokemonMoveSetData.csv";
        public static string ItemData = "GameData\\ItemData.csv";

        public static void LoadAllPokemon()
        {
            List<Move> moves = Save.AllMoves;
            List<PokemonMoveSet> pokemonMoveSets = Save.AllPokemonMoveSets;
            List<Pokemon> pokemons = new List<Pokemon>();

            StreamReader streamReader = new StreamReader(PokemonDataFile);

            streamReader.ReadLine(); // data explanation/header at top
            /*int debugCounter = 0;*/
            while (!streamReader.EndOfStream)
            {
                /*debugCounter++;
                Console.WriteLine(debugCounter);*/

                string[] data = streamReader.ReadLine().Split(';');

                string name = data[0];

                List<Tuple<Move, int>> unlockableMoves = GetUnlockableMoves(name, moves, pokemonMoveSets);

                string description = data[1];
                string type = data[2];
                int level = int.Parse(data[3]);
                int health = int.Parse(data[4]);
                int attack = int.Parse(data[5]);
                int defense = int.Parse(data[6]);
                int speed = int.Parse(data[7]);
                string evolution = data[8];

                Pokemon pokemon = new Pokemon(name, description, evolution, unlockableMoves, type, level, health, attack, defense, speed);

                pokemons.Add(pokemon);
            }

            Save.AllPokemon = pokemons;
        }

        private static List<Tuple<Move, int>> GetUnlockableMoves(string name, List<Move> moves, List<PokemonMoveSet> pokemonMoveSets)
        {
            List<Tuple<Move, int>> tuples = new List<Tuple<Move, int>>(); // can be optimized if put into LoadAllPokemon bcs each set in pokemonMoveSets can be deleted
            List<int> levelUnlockSet = new List<int>();
            List<string> moveNameSet = new List<string>();
            List<Move> moveSet = new List<Move>();

            foreach(PokemonMoveSet record in pokemonMoveSets)
            {
                if (record.Name == name)
                {
                    levelUnlockSet.Add(record.LevelUnlock);
                    moveNameSet.Add(record.Move);
                }
            }
            for (int j = 0; j < moveNameSet.Count; j++)
            {
                for (int i = 0; i < moves.Count; i++)
                {
                    Move move = moves[i];
                    if (move.Name == moveNameSet[j])
                    {
                        moveSet.Add(move);
                    }

                }
            }
            for (int k = 0; k < moveSet.Count; k++)
            {
                Tuple<Move, int> tuple = new Tuple<Move, int>(moveSet[k], levelUnlockSet[k]);
                tuples.Add(tuple);
            }

            return tuples;
        }

        public static void LoadAllMoves()
        {
            CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture) 
            {
                Delimiter = ";", Encoding = Encoding.UTF8 
            };
            StreamReader streamReader = new StreamReader(MovesDataFile);
            CsvReader csvReader = new CsvReader(streamReader, config);

            Save.AllMoves = csvReader.GetRecords<Move>().ToList();
        }

        public static void LoadAllPokemonMoveSets()
        {
            CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                Encoding = Encoding.UTF8
            };
            StreamReader streamReader = new StreamReader(PokemonMoveSetDataFile);
            CsvReader csvReader = new CsvReader(streamReader, config);

            Save.AllPokemonMoveSets = csvReader.GetRecords<PokemonMoveSet>().ToList();
        }

        public static string[] LoadPokemonAsciiArt(string pokemonName, string size)
        {
            if (!File.Exists($"GameData\\PokemonASCII_Art\\{pokemonName}{size}.txt")) return new string[] { "IMAGE NOT FOUND" };

            StreamReader streamReader = new StreamReader($"GameData\\PokemonASCII_Art\\{pokemonName}{size}.txt");
            string image = streamReader.ReadToEnd();
            image = image.Replace("\r", string.Empty);
            image = ReverseDarkAndLight(image, size);

            List<string> imageLines = new List<string>();
            string line = "";

            for (int i = 0; i < image.Length; i++)
            {
                char c = image[i];

                if (c == '\n')
                {
                    line += c;
                    imageLines.Add(line);
                    line = "";
                }
                else line += c;
            }
            imageLines.Add(line);

            return imageLines.ToArray();
        }

        public static string[] CreatePokemonSilhouette(string[] OGimage)
        {
            // y x
            int[] up = new int[] { -1, 0 };
            int[] down = new int[] { 1, 0 };
            int[] left = new int[] { 0, -1 };
            int[] right = new int[] { 0, 1 };

            OGimage[OGimage.Length-1] += "\n";

            string[] borderedImage = new string[OGimage.Length + 2];
            borderedImage[0] = new string('R', OGimage[0].Length + 1) + "\n";
            for (int i = 1; i < OGimage.Length + 1; i++)
            {
                string line = OGimage[i - 1].Replace('\n', 'R');
                borderedImage[i] = "R" + line + "\n";
            }
            borderedImage[borderedImage.Length - 1] = new string('R', OGimage[OGimage.Length - 1].Length + 1);

            string[] CheckCheckChickettyCheck(int y, int x, int[] vector, string[] OGimage, string[] borderedImage, string[] silhouette)
            {
                for (int j = y; j < OGimage.Length + y; j++)
                {
                    for (int i = x; i < OGimage[y].Length + x; i++)
                    {
                        if (borderedImage[j].ElementAt(i) != 'R') continue;

                        if (borderedImage[j+vector[0]].ElementAt(i+vector[1]) != 'R')
                        {
                            silhouette[j] = silhouette[j].Remove(i, 1).Insert(i, " ");
                        }
                    }
                }

                return silhouette;
            }

            string[] silhouette = new string[OGimage.Length + 2];
            borderedImage.CopyTo(silhouette, 0);

            silhouette = CheckCheckChickettyCheck(0, 1, down, OGimage, borderedImage, silhouette);
            silhouette = CheckCheckChickettyCheck(2, 1, up, OGimage, borderedImage, silhouette);
            silhouette = CheckCheckChickettyCheck(1, 0, right, OGimage, borderedImage, silhouette);
            silhouette = CheckCheckChickettyCheck(1, 2, left, OGimage, borderedImage, silhouette);

            return silhouette;
        }

        public static string[] LoadOtherAsciiArt(string item)
        {
            if (!File.Exists($"GameData\\OtherASCII_Art\\{item}.txt")) return new string[] { "IMAGE NOT FOUND" };

            StreamReader streamReader = new StreamReader($"GameData\\OtherASCII_Art\\{item}.txt");
            string image = streamReader.ReadToEnd();
            image = image.Replace("\r", string.Empty);

            List<string> imageLines = new List<string>();
            string line = "";

            for (int i = 0; i < image.Length; i++)
            {
                char c = image[i];

                if (c == '\n')
                {
                    line += c;
                    imageLines.Add(line);
                    line = "";
                }
                else line += c;
            }
            imageLines.Add(line);

            return imageLines.ToArray();
        }

        public static string ReverseDarkAndLight(string image, string size)
        {
            if (size == "Small")
            {   // " ░▒▓█" - switcheroo | middle one stays the same
                image = image.Replace(' ', 'P'); // P = placeholder
                image = image.Replace('█', ' ');
                image = image.Replace('P', '█');
                image = image.Replace('░', 'P');
                image = image.Replace('▓', '░');
                image = image.Replace('P', '▓');
                /*image = image.Replace('R', ' '); // R = emptySpaces*/
            }

            return image;
        }

        public static void LoadAllItems()
        {
            List<Item> items = new List<Item>();
            StreamReader streamReader = new StreamReader(ItemData);

            streamReader.ReadLine(); //headers
            while (!streamReader.EndOfStream)
            {
                Item item;
                string[] data = streamReader.ReadLine().Split(';');

                string type = data[0];
                string name = data[1];
                string descirption = data[2];
                string[] icon = LoadItemAsciiArt(name);
                string rarity = data[3];
                int price = int.Parse(data[4]);

                switch (rarity)
                {
                    case "common":
                        Save.SummedWeigths[0] += Save.RarityWeigths[0];
                        break;

                    case "rare":
                        Save.SummedWeigths[1] += Save.RarityWeigths[1];
                        break;

                    case "epic":
                        Save.SummedWeigths[2] += Save.RarityWeigths[2];
                        break;

                    case "legendary":
                        Save.SummedWeigths[3] += Save.RarityWeigths[3];
                        break;
                }

                switch (type)
                {
                    case "PokeBall":
                        int catchRate = int.Parse(data[5]);
                        item = new PokeBall(name, descirption, icon, rarity, 0, price, catchRate);
                        break;

                    case "Potion":
                        int healFactor = int.Parse(data[6]);
                        item = new Potion(name, descirption, icon, rarity, 0, price, healFactor);
                        break;

                    case "Stone":
                        string effectsType = data[7];
                        item = new Stone(name, descirption, icon, rarity, 0, price, effectsType);
                        break;

                    default:
                        continue;
                }
                items.Add(item);
            }

            Save.AllItems = items;
        }

        public static string[] LoadItemAsciiArt(string name)
        {
            if (!File.Exists($"GameData\\ItemASCII_Art\\{name}.txt")) return new string[] { "IMAGE NOT FOUND" };

            StreamReader streamReader = new StreamReader($"GameData\\ItemASCII_Art\\{name}.txt");
            string image = streamReader.ReadToEnd();
            image = image.Replace("\r", string.Empty);

            List<string> imageLines = new List<string>();
            string line = "";

            for (int i = 0; i < image.Length; i++)
            {
                char c = image[i];

                if (c == '\n')
                {
                    line += c;
                    imageLines.Add(line);
                    line = "";
                }
                else line += c;
            }
            imageLines.Add(line);

            return imageLines.ToArray();
        }

    }
}
