public class Solution
{
    public int MaximumBeauty(int[] nums, int k)
    {
        int ans = 0;

        Array.Sort(nums);

        for (int l = 0, r = 0; r < nums.Length; ++r)
        {
            while (nums[r] - nums[l] > 2 * k)
                ++l;
            ans = Math.Max(ans, r - l + 1);
        }

        return ans;
    }
}