
List<Student> studenten = FileOperations.LeesStudenten();

foreach (Student student in studenten)
{
    Console.WriteLine(student);
}