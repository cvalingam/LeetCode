// Approach: Generate all n*(n+1)/2 subarray sums, sort them, return sum of indices [left-1..right-1] mod 10^9+7.
// Time: O(n² log n) Space: O(n²)

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