// Approach: DP where dp[j] = max jumps to reach index j from index 0.
// For each j, scan all i < j: if dp[i] != -1 and |nums[j] - nums[i]| <= target, update dp[j] = max(dp[j], dp[i] + 1).
// dp[0] = 0 (start); unreachable indices stay -1. Answer is dp[n-1].
// Time: O(n²) Space: O(n)

public class Solution
{
    public int MaximumJumps(int[] nums, int target)
    {
        int n = nums.Length;
        // dp[i] := the maximum number of jumps to reach i from 0
        int[] dp = new int[n];
        Array.Fill(dp, -1);
        dp[0] = 0;

        for (int j = 1; j < n; ++j)
        {
            for (int i = 0; i < j; ++i)
            {
                if (dp[i] != -1 && Math.Abs(nums[j] - nums[i]) <= target)
                    dp[j] = Math.Max(dp[j], dp[i] + 1);
            }
        }

        return dp[n - 1];
    }
}