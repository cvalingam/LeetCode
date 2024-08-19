public class Solution
{
    public int MinSteps(int n)
    {
        int[] dp = new int[1005];
        dp[0] = 0;
        dp[1] = 0;
        dp[2] = 2;
        dp[3] = 3;

        for (int i = 4; i <= n; i++)
        {
            dp[i] = i;
            for (int j = 2; j < i; j++)
            {
                if (i % j == 0)
                    dp[i] = Math.Min(dp[i], dp[i / j] + j);
            }
        }
        return dp[n];
    }
}