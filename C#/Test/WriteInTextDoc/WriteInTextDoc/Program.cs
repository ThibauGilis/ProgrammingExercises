
string BestandPath = "C:\\Users\\thiba\\source\\repos\\Test\\WriteInTextDoc\\WriteInTextDoc";
string BestandNaam = "RandomGetallen.txt";
Random random = new Random();

if (File.Exists(BestandNaam))
{
    File.WriteAllText(Path.Combine(BestandPath, BestandNaam), "");

    Console.WriteLine("Exist");

    using (StreamWriter sWriter = new StreamWriter(Path.Combine(BestandPath, BestandNaam), true))
    {
        for (int i = 0; i < 100; i++)
        {
            int getal = random.Next(0, 101);
            Console.WriteLine(getal);
            sWriter.WriteLine(getal);
        }
    }
}