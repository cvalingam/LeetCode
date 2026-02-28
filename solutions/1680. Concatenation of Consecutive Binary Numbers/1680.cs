public class Solution
{
    public int ConcatenatedBinary(int n)
    {
        const int MOD = 1_000_000_007;
        long ans = 0;
        int numberOfBits = 0;

        for (int i = 1; i <= n; ++i)
        {
            if (BitOperations.PopCount((uint)i) == 1)
                ++numberOfBits;
            ans = ((ans << numberOfBits) % MOD + i) % MOD;
        }

        return (int)ans;
    }
}