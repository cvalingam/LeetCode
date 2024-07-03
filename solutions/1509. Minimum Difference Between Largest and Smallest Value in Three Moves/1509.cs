public class Solution
{
    public int MinDifference(int[] nums)
    {
        int n = nums.Length;

        if (n < 5)
            return 0;

        int ans = Int32.MaxValue;

        Array.Sort(nums);

        for (int i = 0; i < 4; i++)
            ans = Math.Min(ans, nums[n - 4 + i] - nums[i]);

        return ans;
    }
}