public class Solution
{
    public long CountFairPairs(int[] nums, int lower, int upper)
    {
        Array.Sort(nums);
        return CountLess(nums, upper) - CountLess(nums, lower - 1);
    }

    private long CountLess(int[] nums, int sum)
    {
        long res = 0;
        for (int i = 0, j = nums.Length - 1; i < j; ++i)
        {
            while (i < j && nums[i] + nums[j] > sum)
                --j;
            res += j - i;
        }
        return res;
    }
}