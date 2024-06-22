public class Solution
{
    public int NumberOfSubarrays(int[] nums, int k)
    {
        return NumberOfSubarraysAtMost(nums, k) - NumberOfSubarraysAtMost(nums, k - 1);
    }

    private int NumberOfSubarraysAtMost(int[] nums, int k)
    {
        int ans = 0;

        for (int l = 0, r = 0; r <= nums.Length;)
            if (k >= 0)
            {
                ans += r - l;
                if (r == nums.Length)
                    break;
                if (nums[r] % 2 == 1)
                    --k;
                ++r;
            }
            else
            {
                if (nums[l] % 2 == 1)
                    ++k;
                ++l;
            }

        return ans;
    }
}