public class Solution
{
    public int LongestMonotonicSubarray(int[] nums)
    {
        int ans = 1;
        int increasing = 1;
        int decreasing = 1;

        for (int i = 1; i < nums.Length; ++i)
        {
            if (nums[i] > nums[i - 1])
            {
                increasing += 1;
                decreasing = 1;
            }
            else if (nums[i] < nums[i - 1])
            {
                decreasing += 1;
                increasing = 1;
            }
            else
            {
                increasing = 1;
                decreasing = 1;
            }
            ans = Math.Max(ans, Math.Max(increasing, decreasing));
        }

        return ans;
    }
}