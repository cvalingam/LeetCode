public class Solution
{
    public int NumTilings(int n)
    {
        int MOD = 1_000_000_007;
        long[] dp = new long[1001];

        if (n >= 1)
            dp[1] = 1;
        if (n >= 2)
            dp[2] = 2;
        if (n >= 3)
            dp[3] = 5;

        for (int i = 4; i <= n; ++i)
            dp[i] = (2 * dp[i - 1] + dp[i - 3]) % MOD;

        return (int)dp[n];
    }
}