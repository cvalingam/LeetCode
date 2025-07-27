public class Solution
{
    public int CountHillValley(int[] nums)
    {
        int ans = 0;
        int left = nums[0];

        for (int i = 1; i + 1 < nums.Length; ++i)
        {
            if ((left < nums[i] && nums[i] > nums[i + 1]) || // the hill
                (left > nums[i] && nums[i] < nums[i + 1]))
            { // the valley
                ++ans;
                left = nums[i];
            }
        }

        return ans;
    }
}