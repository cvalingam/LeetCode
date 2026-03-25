// Approach: Scan all length-3 windows; check if middle == (left + right) / 2.
// Time: O(n) Space: O(1)

public class Solution
{
    public int CountSubarrays(int[] nums)
    {
        int ans = 0;

        for (int i = 1; i + 1 < nums.Length; ++i)
        {
            if (nums[i] == (nums[i - 1] + nums[i + 1]) * 2)
                ++ans;
        }

        return ans;
    }
}