public class Solution
{
    public int MaxCollectedFruits(int[][] fruits)
    {
        int n = fruits.Length;
        return GetTopLeft(fruits) + GetTopRight(fruits) + GetBottomLeft(fruits)
            - 2 * fruits[n - 1][n - 1];
    }

    private int GetTopLeft(int[][] fruits)
    {
        int n = fruits.Length;
        int res = 0;
        for (int i = 0; i < n; ++i)
            res += fruits[i][i];

        return res;
    }

    private int GetTopRight(int[][] fruits)
    {
        int n = fruits.Length;
        // dp[i][j] := the number of fruits collected from (0, n - 1) to (i, j)
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++)
            dp[i] = new int[n];

        dp[0][n - 1] = fruits[0][n - 1];
        for (int x = 0; x < n; ++x)
        {
            for (int y = 0; y < n; ++y)
            {
                if (x >= y && !(x == n - 1 && y == n - 1))
                    continue;
                int[][] dirs = new int[][] { new int[] { 1, -1 }, new int[] { 1, 0 }, new int[] { 1, 1 } };
                foreach (int[] dir in dirs)
                {
                    int i = x - dir[0];
                    int j = y - dir[1];
                    if (i < 0 || i == n || j < 0 || j == n)
                        continue;
                    if (i < j && j < n - 1 - i)
                        continue;
                    dp[x][y] = Math.Max(dp[x][y], dp[i][j] + fruits[x][y]);
                }
            }
        }

        return dp[n - 1][n - 1];
    }

    private int GetBottomLeft(int[][] fruits)
    {
        int n = fruits.Length;
        // dp[i][j] := the number of fruits collected from (n - 1, 0) to (i, j)
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++)
            dp[i] = new int[n];

        dp[n - 1][0] = fruits[n - 1][0];
        for (int y = 0; y < n; ++y)
        {
            for (int x = 0; x < n; ++x)
            {
                if (x <= y && !(x == n - 1 && y == n - 1))
                    continue;
                int[][] dirs = new int[][] { new int[] { -1, 1 }, new int[] { 0, 1 }, new int[] { 1, 1 } };
                foreach (int[] dir in dirs)
                {
                    int i = x - dir[0];
                    int j = y - dir[1];
                    if (i < 0 || i == n || j < 0 || j == n)
                        continue;
                    if (j < i && i < n - 1 - j)
                        continue;
                    dp[x][y] = Math.Max(dp[x][y], dp[i][j] + fruits[x][y]);
                }
            }
        }

        return dp[n - 1][n - 1];
    }
}