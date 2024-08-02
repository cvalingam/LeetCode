public class Solution
{
    public int MinSwaps(int[] nums)
    {
        int n = nums.Length;
        int k = nums.Where(x => x == 1).Count();
        int ones = 0, maxOnes = 0;

        for (int i = 0; i < n * 2; i++)
        {
            if (i >= k && nums[(i - k) % n] == 1)
                --ones;
            if (nums[i % n] == 1)
                ++ones;
            maxOnes = Math.Max(maxOnes, ones);
        }

        return k - maxOnes;
    }
}