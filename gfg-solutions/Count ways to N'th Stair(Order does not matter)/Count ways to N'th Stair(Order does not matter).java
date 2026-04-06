// Approach: DP equivalent to partition into 1s and 2s. dp[i] = dp[i-1] (use 1) + dp[i-2]/some partition formula.
// Time: O(n) Space: O(n)
class Solution {
    public long nthStair(int n) {
        int[] dp = new int[n + 1];

        dp[0] = 1;
        dp[1] = 1;

        for (int i = 2; i <= n; i++)
            dp[i] = 1 + Math.min(dp[i - 1], dp[i - 2]);

        return dp[n];
    }
}