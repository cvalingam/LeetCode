public class Solution
{
    public int RangeSum(int[] nums, int n, int left, int right)
    {
        int MOD = 1000000007;

        List<int> subsums = new List<int>();

        for (int i = 0; i < n; ++i)
        {
            int cursum = nums[i];
            subsums.Add(cursum);
            for (int j = i + 1; j < n; ++j)
            {
                cursum += nums[j];
                subsums.Add(cursum);
            }
        }

        subsums.Sort();

        return subsums.Skip(left - 1).Take(right - left + 1).Aggregate(0, (a, b) => (int)((a + b) % MOD));
    }
}