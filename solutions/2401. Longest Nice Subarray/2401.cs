public class Solution
{
    public int LongestNiceSubarray(int[] nums)
    {
        int ans = 0;
        int used = 0;

        for (int l = 0, r = 0; r < nums.Length; ++r)
        {
            while ((used & nums[r]) > 0)
                used ^= nums[l++];
            used |= nums[r];
            ans = Math.Max(ans, r - l + 1);
        }

        return ans;
    }
}