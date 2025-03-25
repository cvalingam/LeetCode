public class Solution
{
    public int MinimumOperations(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int[][] count = new int[n][];
        for (int i = 0; i < n; i++)
            count[i] = new int[10];

        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
                ++count[j][grid[i][j]];
        }

        int?[][] mem = new int?[n][];
        for (int i = 0; i < n; i++)
            mem[i] = new int?[10];

        return MinimumOperations(count, 0, 0, m, mem);
    }

    // Returns the number of minimum operations needed to make grid[:][j..n)
    // satisfy the conditions, where the (j - 1)-th column is filled with `prev`.
    private int MinimumOperations(int[][] count, int j, int prev, int m, int?[][] mem)
    {
        if (j == count.Length)
            return 0;

        if (mem[j][prev] != null)
            return mem[j][prev].Value;

        int res = int.MaxValue;

        for (int num = 0; num < 10; ++num)
        {
            if (j == 0 || num != prev)
                res = Math.Min(res, m - count[j][num] + MinimumOperations(count, j + 1, num, m, mem));
        }

        return (mem[j][prev] = res).Value;
    }
}