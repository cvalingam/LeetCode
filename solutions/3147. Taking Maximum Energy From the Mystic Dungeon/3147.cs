// Approach: Scan from end; for each chain anchor collect every k-th element's energy backward.
// Time: O(n) Space: O(1)

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