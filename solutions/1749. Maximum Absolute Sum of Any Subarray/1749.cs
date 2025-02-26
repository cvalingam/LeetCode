public class Solution
{
    public int MaxAbsoluteSum(int[] nums)
    {
        int ans = int.MinValue;
        int maxSum = 0;
        int minSum = 0;

        foreach (int num in nums)
        {
            maxSum = Math.Max(num, maxSum + num);
            minSum = Math.Min(num, minSum + num);
            ans = Math.Max(ans, Math.Max(maxSum, -minSum));
        }

        return ans;
    }
}