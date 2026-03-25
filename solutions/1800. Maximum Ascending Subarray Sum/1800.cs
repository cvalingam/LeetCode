// Approach: Linear scan maintaining running sum of current ascending subarray; reset on non-increase.
// Time: O(n) Space: O(1)

public class Solution
{
    public int MaxAscendingSum(int[] nums)
    {
        int maxSum = 0;
        int sum = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
                sum += nums[i];
            else
            {
                maxSum = Math.Max(maxSum, sum);
                sum = nums[i];
            }
        }

        return Math.Max(maxSum, sum);
    }
}