public class Solution
{
    public int SmallestRangeI(int[] nums, int k)
    {
        int mx = nums.Max();
        int mn = nums.Min();
        return Math.Max(0, mx - mn - 2 * k);
    }
}