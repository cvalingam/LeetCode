public class Solution
{
    public int MaxMoves(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        int[][] dp = new int[m][];
        for (int i = 0; i < m; i++)
        {
            int[] arr = new int[n];
            Array.Fill(arr, -1);
            dp[i] = arr;
        }

        int maxMoves = 0;
        for (int i = 0; i < m; i++)
            maxMoves = Math.Max(maxMoves, topDown(i, 0, grid, dp));

        return maxMoves - 1;
    }

    int topDown(int i, int j, int[][] grid, int[][] dp)
    {
        if (dp[i][j] != -1)
            return dp[i][j];

        int moves = 0;

        if (isValid(i + 1, j + 1, grid, grid[i][j]))
            moves = Math.Max(moves, topDown(i + 1, j + 1, grid, dp));

        if (isValid(i - 1, j + 1, grid, grid[i][j]))
            moves = Math.Max(moves, topDown(i - 1, j + 1, grid, dp));

        if (isValid(i, j + 1, grid, grid[i][j]))
            moves = Math.Max(moves, topDown(i, j + 1, grid, dp));

        return dp[i][j] = moves + 1;
    }

    bool isValid(int r, int c, int[][] grid, int curr)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        if (r < 0 || c < 0 || r >= m || c >= n || grid[r][c] <= curr)
            return false;
        return true;
    }
}