public class Solution
{
    public long MaxTaxiEarnings(int n, int[][] rides)
    {
        List<(int end, int earn)>[] startToEndAndEarns = new List<(int, int)>[n];
        // dp[i] := the maximum dollars you can earn starting at i
        long[] dp = new long[n + 1];

        for (int i = 1; i < n; ++i)
            startToEndAndEarns[i] = new List<(int, int)>();

        foreach (var ride in rides)
        {
            int start = ride[0];
            int end = ride[1];
            int tip = ride[2];
            int earn = end - start + tip;
            startToEndAndEarns[start].Add((end, earn));
        }

        for (int i = n - 1; i >= 1; --i)
        {
            dp[i] = dp[i + 1];
            foreach (var (end, earn) in startToEndAndEarns[i])
                dp[i] = Math.Max(dp[i], dp[end] + earn);
        }

        return dp[1];
    }
}