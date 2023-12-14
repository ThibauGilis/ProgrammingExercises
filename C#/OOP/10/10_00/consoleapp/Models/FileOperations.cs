namespace consoleapp.Models;

public static class FileOperations
{
    public static List<Student> LeesStudenten(string bestandsnaam)
    {
        List<Student> studenten = new List<Student>();

        if (File.Exists(bestandsnaam))
        {
            using(StreamReader sr = new StreamReader(bestandsnaam))
            {
                string[] data = sr.ReadLine().Split(';');

                int.TryParse(data[0], out int id);
                string naam = data[1];
                string voornaam = data[2];
                int.TryParse(data[3], out int puntWiskunde);
                int.TryParse(data[4], out int puntNederlands);

                Student student = new Student(id, naam, voornaam, puntWiskunde, puntNederlands);

                studenten.Add(student);
            }
        }

        return studenten;
    }
}
