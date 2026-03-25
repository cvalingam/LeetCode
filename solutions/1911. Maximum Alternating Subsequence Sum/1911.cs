// Approach: DP with two states (even/odd position sums); greedily add or skip each element.
// Time: O(n) Space: O(1)

public class Solution
{
    public long MaxAlternatingSum(int[] nums)
    {
        long even = 0; // the maximum alternating sum ending in an even index
        long odd = 0;  // the maximum alternating sum ending in an odd index

        foreach (var num in nums)
        {
            even = Math.Max(even, odd + num);
            odd = even - num;
        }

        return even;
    }
}