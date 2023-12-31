
int FindMaxValueOfEquation(int[][] points, int k)
{
    int MaxVal = int.MinValue;

    for (int i = 0; i < points.Length; i++)
    {
        for (int j = i + 1; j < points.Length; j++)
        {
            if (Math.Abs(points[i][0] - points[j][0]) <= k)
            {
                MaxVal = Math.Max(MaxVal, points[i][1] + points[j][1] + Math.Abs(points[i][0] - points[j][0]));
            }
        }
    }

    return MaxVal;
}

int[][] points = new int[][] { new int[] { 1, 3 }, new int[] { 2, 0 }, new int[] { 5, 10 }, new int[] { 6, -10 } };
int k = 4;
Console.WriteLine(FindMaxValueOfEquation(points, k));