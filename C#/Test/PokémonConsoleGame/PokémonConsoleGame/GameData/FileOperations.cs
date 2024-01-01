using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace PokémonConsoleGame.GameData
{
    public static class FileOperations
    {
        public static string PokemonDataFile = "GameData\\PokemonData.csv";
        public static string MovesDataFile = "GameData\\MoveData.csv";
        public static string PokemonMoveSetDataFile = "GameData\\PokemonMoveSetData.csv";

        public static void LoadAllPokemon()
        {
            List<Move> moves = Save.AllMoves;
            List<PokemonMoveSet> pokemonMoveSets = Save.AllPokemonMoveSets;
            List<Pokemon> pokemons = new List<Pokemon>();

            StreamReader streamReader = new StreamReader(PokemonDataFile);

            streamReader.ReadLine(); // data explanation/header at top
            while (!streamReader.EndOfStream)
            {
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

        public static string[] LoadOtherAsciiArt(string item)
        {
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

        private static string ReverseDarkAndLight(string image, string size)
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
    }
}
