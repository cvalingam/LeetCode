public class Solution
{
    public int CountSquares(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;
        int cnt = 0;
        int[][] dp = new int[m][];
        for (int i = 0; i < m; i++)
        {
            dp[i] = new int[n];
            dp[i][0] = matrix[i][0];
        }

        for (int j = 0; j < n; j++)
            dp[0][j] = matrix[0][j];

        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                if (matrix[i][j] == 1)
                    dp[i][j] = 1 + Math.Min(dp[i - 1][j], Math.Min(dp[i - 1][j - 1], dp[i][j - 1]));
                else
                    dp[i][j] = 0;
            }
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
                cnt += dp[i][j];
        }

        return cnt;
    }
}