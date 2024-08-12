public class Solution
{
    public int ClimbStairs(int n)
    {
        // int[] dp = new int[n + 1];
        // Array.Fill(dp, -1);
        // return topDown(n, dp);
        // return tabulation(n);
        return tabulationoptimized(n);
    }

    private int topDown(int ind, int[] dp)
    {
        if (ind < 0)
            return 0;

        if (ind == 0)
            return 1;

        if (dp[ind] != -1)
            return dp[ind];

        return dp[ind] = topDown(ind - 1, dp) + topDown(ind - 2, dp);
    }

    private int tabulation(int n)
    {
        int[] dp = new int[n + 1];
        dp[0] = 1;

        for (int ind = 1; ind <= n; ind++)
        {
            int firstStep = dp[ind - 1];
            int secondStep = 0;
            if (ind - 2 >= 0)
                secondStep = dp[ind - 2];

            dp[ind] = firstStep + secondStep;
        }

        return dp[n];
    }

    private int tabulationoptimized(int n)
    {
        int prev1 = 2;
        int prev0 = 1;
        int curr = 0;

        if (n <= 2)
            return Math.Max(1, n);

        for (int ind = 2; ind < n; ind++)
        {
            curr = prev1 + prev0;
            prev0 = prev1;
            prev1 = curr;
        }

        return curr;
    }
}