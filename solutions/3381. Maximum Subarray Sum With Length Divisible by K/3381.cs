public class Solution
{
    public long MaxSubarraySum(int[] nums, int k)
    {
        long ans = long.MinValue;
        long prefix = 0;
        long[] minPrefix = new long[k];

        for (int i = 0; i < k; i++)
            minPrefix[i] = long.MaxValue / 2;
        minPrefix[k - 1] = 0;

        for (int i = 0; i < nums.Length; ++i)
        {
            prefix += nums[i];
            ans = Math.Max(ans, prefix - minPrefix[i % k]);
            minPrefix[i % k] = Math.Min(minPrefix[i % k], prefix);
        }

        return ans;
    }
}