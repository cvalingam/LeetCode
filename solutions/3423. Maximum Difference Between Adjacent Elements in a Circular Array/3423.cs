public class Solution
{
    public int MaxAdjacentDistance(int[] nums)
    {
        int ans = Math.Abs(nums[0] - nums[nums.Length - 1]);

        for (int i = 0; i + 1 < nums.Length; ++i)
            ans = Math.Max(ans, Math.Abs(nums[i] - nums[i + 1]));

        return ans;
    }
}