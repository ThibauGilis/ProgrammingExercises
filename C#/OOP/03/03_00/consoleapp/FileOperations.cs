using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp
{
    public static class FileOperations
    {

        // Attr
        public static string BestandStudenten = "studenten.txt";
        public static string BestandScores = "scores.txt";

        //Meth

        public static List<string> StudentenLezen()
        {
            List<string> studenten = new List<string>();

            if (!File.Exists(BestandStudenten))
            {
                return studenten;
            }

            using (StreamReader reader = new StreamReader(BestandStudenten))
            {
                while (!reader.EndOfStream) 
                { 
                    studenten.Add(reader.ReadLine());
                }
            }

            return studenten;
        }

        public static List<int> ScoresLezen()
        {
            List<int> scores = new List<int>();

            if (!File.Exists(BestandScores))
            {
                return scores;
            }

            using (StreamReader reader = new StreamReader(BestandScores))
            {
                while (!reader.EndOfStream)
                {
                    if (int.TryParse(reader.ReadLine(), out int score))
                    {
                        scores.Add(score);
                    }
                }
            }

            return scores;
        }

    }
}
