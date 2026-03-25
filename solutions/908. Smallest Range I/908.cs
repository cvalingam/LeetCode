// Approach: Range only narrows if the gap between max and min exceeds 2k; answer is max(0, max - min - 2k).
// Time: O(n) Space: O(1)

public class Solution
{
    public int SmallestRangeI(int[] nums, int k)
    {
        int mx = nums.Max();
        int mn = nums.Min();
        return Math.Max(0, mx - mn - 2 * k);
    }
}