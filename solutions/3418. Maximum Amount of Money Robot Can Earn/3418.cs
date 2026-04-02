// Approach: 3D DP where dp[i][j][k] = max coins at cell (i,j) with k neutralizations remaining.
// At each cell, either collect the coin value normally or use a neutralization (skip negative cells).
// Transition from top and left neighbours. Answer is max over all k at bottom-right cell.
// Time: O(m * n) Space: O(m * n)
public class Solution
{
    public int MaximumAmount(int[][] coins)
    {
        int m = coins.Length;
        int n = coins[0].Length;
        // dp[i][j][k] := the maximum profit at position (i, j) with k remaining neutralizations
        int[,,] dp = new int[m, n, 4];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < 4; k++)
                    dp[i, j, k] = int.MinValue / 2;
            }
        }

        // Base case: the robot starts at the top-left corner.
        dp[0, 0, 2] = coins[0][0];
        if (coins[0][0] < 0)
            dp[0, 0, 1] = 0; // Neutralize the robber.

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (i > 0)
                        dp[i, j, k] = Math.Max(dp[i, j, k], Math.Max(dp[i - 1, j, k] + coins[i][j], dp[i - 1, j, k + 1]));
                    if (j > 0)
                        dp[i, j, k] = Math.Max(dp[i, j, k], Math.Max(dp[i, j - 1, k] + coins[i][j], dp[i, j - 1, k + 1]));
                }
            }
        }

        int max = int.MinValue;
        for (int k = 0; k < 4; k++)
            max = Math.Max(max, dp[m - 1, n - 1, k]);

        return max;
    }
}