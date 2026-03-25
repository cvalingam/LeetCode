// Approach: Build XOR prefix; for each query XOR prefix with (2^maximumBit - 1) to flip all bits.
// Time: O(n) Space: O(n)

public class Solution
{
    public int[] GetMaximumXor(int[] nums, int maximumBit)
    {
        int n = nums.Length;
        int mx = (1 << maximumBit) - 1;
        int[] ans = new int[n];
        int xors = 0;

        for (int i = 0; i < n; ++i)
        {
            xors ^= nums[i];
            ans[n - 1 - i] = xors ^ mx;
        }

        return ans;
    }
}