
int ReadNumber()
{
    int getal;
    do
    {
        Console.Write("Geef getal: ");
    } while (!int.TryParse(Console.ReadLine(), out getal));
    return getal;
}

bool IsEven(int number)
{
    return number % 2 == 0;
}

List<int> GetEvenNumbersBetween(int n1, int n2)
{
    List<int> result = new List<int>();
    for (int i = n1; i >= n2; i--)
    {
        if (IsEven(i))
        {
        result.Add(i);
        }
    }
    return result;
}

void PrintResult(List<int> evenNumbers)
{
    string output = "";
    for (int i = 0; i < evenNumbers.Count-1; i++)
    {
        output += $"{evenNumbers[i]} * ";
    }
    Console.WriteLine(output + $"{evenNumbers.Last()}");
}

PrintResult(GetEvenNumbersBetween(ReadNumber(), ReadNumber()));

