// Approach: Track running max; score[i] = nums[i] + max(nums[0..i]); accumulate as prefix sums.
// Time: O(n) Space: O(n)

public class Solution
{
    public long[] FindPrefixScore(int[] nums)
    {
        int n = nums.Length;
        long[] ans = new long[n];
        int max = 0;
        long prefix = 0;

        for (int i = 0; i < n; i++)
        {
            max = Math.Max(max, nums[i]);
            prefix += nums[i] + max;
            ans[i] = prefix;
        }

        return ans;
    }
}