public class Solution
{
    public int[] FindMissingAndRepeatedValues(int[][] grid)
    {
        int n = grid.Length;
        int nSquared = n * n;
        int[] count = new int[nSquared + 1];

        foreach (int[] row in grid)
        {
            foreach (int num in row)
                ++count[num];
        }

        int repeated = -1;
        int missing = -1;

        for (int i = 1; i <= nSquared; ++i)
        {
            if (count[i] == 2)
                repeated = i;
            if (count[i] == 0)
                missing = i;
        }

        return new int[] { repeated, missing };
    }
}