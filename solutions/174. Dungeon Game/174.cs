// Approach: Reverse DP from the bottom-right princess cell back to the top-left starting cell.
// dp[i][j] = minimum health the knight needs when entering cell (i,j) to survive to the end.
// From cell (i,j): the knight can go right or down, so dp[i][j] = min(dp[i+1][j], dp[i][j+1]) - dungeon[i][j].
// Clamp dp[i][j] to at least 1 (the knight must always have at least 1 HP).
// Forward DP does not work here because minimum health depends on future choices, not past ones.
// Time: O(m x n) Space: O(m x n); reducible to O(n) with a rolling row.

public class Solution
{
    public int CalculateMinimumHP(int[][] dungeon)
    {
        int m = dungeon.Length;
        int n = dungeon[0].Length;
        int[,] dp = new int[m + 1, n + 1];

        for (int i = 0; i <= m; i++)
        {
            for (int j = 0; j <= n; j++)
                dp[i, j] = int.MaxValue;
        }

        dp[m, n - 1] = 1;
        dp[m - 1, n] = 1;

        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                dp[i, j] = Math.Min(dp[i + 1, j], dp[i, j + 1]) - dungeon[i][j];
                dp[i, j] = Math.Max(dp[i, j], 1);
            }
        }

        return dp[0, 0];
    }
}