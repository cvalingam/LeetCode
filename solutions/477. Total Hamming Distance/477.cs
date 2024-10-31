public class Solution
{
    public int TotalHammingDistance(int[] nums)
    {
        const int kMaxBit = 30;
        int ans = 0;

        for (int i = 0; i < kMaxBit; ++i)
        {
            int mask = 1 << i;
            int ones = nums.Count(num => (num & mask) > 0);
            int zeros = nums.Length - ones;
            ans += ones * zeros;
        }

        return ans;
    }
}