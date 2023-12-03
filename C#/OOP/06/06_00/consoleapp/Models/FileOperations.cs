using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public static class FileOperations
    {
        public static string BestandStudenten = "StudentEnPunt.txt";

        public static List<Student> LeesStudenten()
        {
            List<Student> studenten = new List<Student>();

            if (!File.Exists(BestandStudenten))
            {
                return studenten;
            }

            using (StreamReader reader = new StreamReader(BestandStudenten))
            {
                while (!reader.EndOfStream)
                {
                    string record = reader.ReadLine();
                    string[] data = record.Split(';');

                    double score = 0;
                    double.TryParse(data[1], out score);
                    string naam = data[0];

                    Student student = new Student(naam, score);
                    studenten.Add(student);
                }
            }

            return studenten;
        }
    }
}
