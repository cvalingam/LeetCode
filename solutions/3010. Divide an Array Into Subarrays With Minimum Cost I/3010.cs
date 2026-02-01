public class Solution
{
    public int MinimumCost(int[] nums)
    {
        const int MAX = 50;
        int min1 = MAX;
        int min2 = MAX;

        for (int i = 1; i < nums.Length; ++i)
        {
            if (nums[i] < min1)
            {
                min2 = min1;
                min1 = nums[i];
            }
            else if (nums[i] < min2)
                min2 = nums[i];
        }

        return nums[0] + min1 + min2;
    }
}