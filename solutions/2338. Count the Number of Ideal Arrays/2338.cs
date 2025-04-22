public class Solution
{
    private const int kMod = 1_000_000_007;

    public int IdealArrays(int n, int maxValue)
    {
        // Since 2^14 > 10^4, the longest strictly increasing array is [1, 2, 4,
        // ..., 2^13]
        int maxLength = Math.Min(14, n);
        var factors = GetFactors(maxValue);
        // dp[i][j] := the number of strictly increasing ideal arrays of length i
        // ending in j
        // dp[i][j] := sum(dp[i - 1][k]), where j % k == 0
        // dp[i][0] := sum(dp[i][j]) where 1 <= j <= maxValue
        var dp = new long[maxLength + 1][];
        for (int i = 0; i <= maxLength; i++)
            dp[i] = new long[maxValue + 1];

        var mem = new long[n][];
        for (int i = 0; i < n; i++)
        {
            mem[i] = new long[maxLength];
            Array.Fill(mem[i], -1);
        }
        long ans = 0;

        for (int j = 1; j <= maxValue; ++j)
            dp[1][j] = 1;

        for (int i = 2; i <= maxLength; ++i)
        {
            for (int j = 1; j <= maxValue; ++j)
            {
                foreach (int k in factors[j])
                {
                    dp[i][j] += dp[i - 1][k];
                    dp[i][j] %= kMod;
                }
            }
        }

        for (int i = 1; i <= maxLength; ++i)
        {
            for (int j = 1; j <= maxValue; ++j)
            {
                dp[i][0] += dp[i][j];
                dp[i][0] %= kMod;
            }
        }

        for (int i = 1; i <= maxLength; ++i)
        {
            // nCk(n - 1, i - 1) := the number of ways to create an ideal array of
            // length n from a strictly increasing array of length i
            ans += dp[i][0] * NCk(n - 1, i - 1, mem);
            ans %= kMod;
        }

        return (int)ans;
    }

    private List<List<int>> GetFactors(int maxValue)
    {
        var factors = new List<List<int>>(maxValue + 1);
        for (int i = 0; i <= maxValue; i++)
            factors.Add(new List<int>());

        for (int i = 1; i <= maxValue; ++i)
        {
            // Start from i * 2 because of strictly increasing.
            for (int j = i * 2; j <= maxValue; j += i)
                factors[j].Add(i);
        }

        return factors;
    }

    private long NCk(int n, int k, long[][] mem)
    {
        if (k == 0)
            return 1;
        if (n == k)
            return 1;
        if (mem[n][k] != -1)
            return mem[n][k];
            
        return mem[n][k] = (NCk(n - 1, k, mem) + NCk(n - 1, k - 1, mem)) % kMod;
    }
}