public class Solution
{
    public long MaxPoints(int[][] points)
    {
        int n = points[0].Length;

        long[] dp = new long[n];

        foreach (var row in points)
        {
            long[] leftToRight = new long[n];
            long runningMax = 0;

            for (int j = 0; j < n; ++j)
            {
                runningMax = Math.Max(runningMax - 1, dp[j]);
                leftToRight[j] = runningMax;
            }

            long[] rightToLeft = new long[n];
            runningMax = 0;

            for (int j = n - 1; j >= 0; --j)
            {
                runningMax = Math.Max(runningMax - 1, dp[j]);
                rightToLeft[j] = runningMax;
            }

            for (int j = 0; j < n; ++j)
                dp[j] = Math.Max(leftToRight[j], rightToLeft[j]) + row[j];
        }

        return dp.Max();
    }
}