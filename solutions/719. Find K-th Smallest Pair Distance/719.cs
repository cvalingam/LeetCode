public class Solution
{
    public int SmallestDistancePair(int[] nums, int k)
    {
        Array.Sort(nums);

        int l = 0;
        int r = nums[nums.Length - 1] - nums[0];

        while (l < r)
        {
            int m = (l + r) / 2;
            if (numPairDistancesNoGreater(nums, m) >= k)
                r = m;
            else
                l = m + 1;
        }

        return l;
    }

    private int numPairDistancesNoGreater(int[] nums, int m)
    {
        int count = 0;
        int j = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            while (j < nums.Length && nums[j] <= nums[i] + m)
                ++j;
            count += j - i - 1;
        }

        return count;
    }
}