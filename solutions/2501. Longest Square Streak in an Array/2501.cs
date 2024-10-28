public class Solution
{
    public int LongestSquareStreak(int[] nums)
    {
        Array.Sort(nums, (a, b) => b.CompareTo(a));

        int maxNum = nums.Max();
        // dp[i] := the longest square streak starts with i
        int[] dp = new int[maxNum + 1];

        foreach (int num in nums)
        {
            dp[num] = 1;
            long squaredNum = (long)num * num;
            if (squaredNum <= maxNum)
                dp[num] += dp[squaredNum];
        }

        int ans = dp.Max();
        return ans < 2 ? -1 : ans;
    }
}