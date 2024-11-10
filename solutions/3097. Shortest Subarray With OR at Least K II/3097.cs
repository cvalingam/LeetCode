public class Solution
{
    public int MinimumSubarrayLength(int[] nums, int k)
    {
        const int kMax = 50;
        int n = nums.Length;
        int ans = n + 1;
        int ors = 0;
        int[] count = new int[kMax + 1];

        for (int l = 0, r = 0; r < n; ++r)
        {
            ors = OrNum(ors, nums[r], count);
            while (ors >= k && l <= r)
            {
                ans = Math.Min(ans, r - l + 1);
                ors = UndoOrNum(ors, nums[l], count);
                ++l;
            }
        }

        return (ans == n + 1) ? -1 : ans;
    }

    private const int kMaxBit = 30;

    private int OrNum(int ors, int num, int[] count)
    {
        for (int i = 0; i < kMaxBit; ++i)
        {
            if ((num >> i & 1) == 1 && ++count[i] == 1)
                ors += 1 << i;
        }

        return ors;
    }

    private int UndoOrNum(int ors, int num, int[] count)
    {
        for (int i = 0; i < kMaxBit; ++i)
        {
            if ((num >> i & 1) == 1 && --count[i] == 0)
                ors -= 1 << i;
        }

        return ors;
    }
}