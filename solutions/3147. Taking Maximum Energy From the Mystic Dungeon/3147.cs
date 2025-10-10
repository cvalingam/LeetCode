public class Solution
{
    public int MaximumEnergy(int[] energy, int k)
    {
        int[] dp = (int[])energy.Clone();
        for (int i = energy.Length - 1 - k; i >= 0; --i)
            dp[i] += dp[i + k];
        return dp.Max();
    }
}