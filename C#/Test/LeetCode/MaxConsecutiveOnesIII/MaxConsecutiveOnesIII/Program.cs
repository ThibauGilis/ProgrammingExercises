
int LongestOnes(int[] nums, int k)
{
    int StartIndex = 0, CurrentIndex, Amount1s = 0, Max1s = 0, Free1s = k;

    while (StartIndex < nums.Length && StartIndex > -1)
    {
        CurrentIndex = StartIndex;
        while (CurrentIndex < nums.Length && (Free1s > 0 || nums[CurrentIndex] != 0))
        {
            if (nums[CurrentIndex] == 0)
            {
                Free1s--;
            }
            Amount1s++;

            CurrentIndex++;
        }

        Max1s = Math.Max(Max1s, Amount1s + Free1s);

        int FirstZero = Array.IndexOf(nums, 0, StartIndex);
        if (FirstZero == -1)
        {
            break;
        }

        Amount1s = 0;
        Free1s = k;
        StartIndex = Array.IndexOf(nums, 1, FirstZero);
    }

    return Math.Min(Max1s, nums.Length);
}

//--------------------------------------------------------------

Console.WriteLine(LongestOnes(new int[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 }, 2)); // 6
Console.WriteLine(LongestOnes(new int[] { 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1 }, 3)); // 10
Console.WriteLine(LongestOnes(new int[] { 1, 0, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 1 }, 8)); //25