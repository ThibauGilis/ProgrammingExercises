
using NumberOfBoomerangs;

int CountBoomerangs(List<int> numbers)
{
    int amount = 0;

    for (int i = 0; i < numbers.Count-2; i++)
    {
        if (numbers[i] == numbers[i+2] && numbers[i] != numbers[i+1])
        {
            amount++;
        }
    }

    return amount;
}

Console.WriteLine(CountBoomerangs(FileOperations.ReadFile(FileOperations.FileName)));