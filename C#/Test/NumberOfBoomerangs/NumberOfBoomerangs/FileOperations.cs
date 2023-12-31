using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfBoomerangs
{
    public static class FileOperations
    {
        public static string FileName = "Numbers.txt";

        public static List<int> ReadFile(string fileName)
        {
            List<int> numbers = new List<int>();

            if (!File.Exists(fileName)) 
            {
                return numbers;
            }

            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    int.TryParse(sr.ReadLine(), out int number);

                    numbers.Add(number);
                }
            }

            return numbers;
        }
    }
}
