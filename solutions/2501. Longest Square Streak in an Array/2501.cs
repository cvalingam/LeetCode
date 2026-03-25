// Approach: Sort; HashSet for O(1) lookup; dp[x] = dp[x*x] + 1 if x*x exists.
// Time: O(n log n) Space: O(n)

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