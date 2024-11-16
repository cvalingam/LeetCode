public class Solution
{
    public int MinimumSum(int[] nums)
    {
        int n = nums.Length;
        int ans = int.MaxValue;
        int[] minPrefix = new int[n];
        int[] minSuffix = new int[n];

        minPrefix[0] = nums[0];
        minSuffix[n - 1] = nums[n - 1];

        for (int i = 1; i < n; ++i)
            minPrefix[i] = Math.Min(minPrefix[i - 1], nums[i]);

        for (int i = n - 2; i >= 0; --i)
            minSuffix[i] = Math.Min(minSuffix[i + 1], nums[i]);

        for (int i = 0; i < n; ++i)
        {
            if (nums[i] > minPrefix[i] && nums[i] > minSuffix[i])
                ans = Math.Min(ans, nums[i] + minPrefix[i] + minSuffix[i]);
        }

        return ans == int.MaxValue ? -1 : ans;
    }
}