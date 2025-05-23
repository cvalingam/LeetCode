public class Solution
{
    public long MaximumValueSum(int[] nums, int k, int[][] edges)
    {
        long sum = 0, cnt = 0, minChangedDiff = Int32.MaxValue;

        foreach (int el in nums)
        {
            sum += Math.Max(el, el ^ k);
            cnt += ((el ^ k) > el) ? 1 : 0;
            minChangedDiff = Math.Min(minChangedDiff, Math.Abs(el - (el ^ k)));
        }

        if (cnt % 2 == 0)
            return sum;

        return sum - minChangedDiff;
    }
}