public class Solution
{
    private const int MOD = 1_000_000_007;

    public int NumberOfPaths(int[][] grid, int k)
    {
        int m = grid.Length, n = grid[0].Length;
        int?[][][] mem = new int?[m][][];
        for (int i = 0; i < m; i++)
        {
            mem[i] = new int?[n][];
            for (int j = 0; j < n; j++)
                mem[i][j] = new int?[k];
        }

        return NumberOfPaths(grid, 0, 0, 0, k, mem);
    }

    private int NumberOfPaths(int[][] grid, int i, int j, int sum, int k, int?[][][] mem)
    {
        int m = grid.Length, n = grid[0].Length;
        if (i == m || j == n)
            return 0;

        if (i == m - 1 && j == n - 1)
            return ((sum + grid[i][j]) % k == 0) ? 1 : 0;

        if (mem[i][j][sum].HasValue)
            return mem[i][j][sum].Value;

        int newSum = (sum + grid[i][j]) % k;
        int result = (NumberOfPaths(grid, i + 1, j, newSum, k, mem) +
                      NumberOfPaths(grid, i, j + 1, newSum, k, mem)) % MOD;
        mem[i][j][sum] = result;
        
        return result;
    }
}