// Approach: DP. dp[n] = min perfect squares summing to n. dp[i] = min(dp[i - j*j] + 1) for all j*j <= i.
// Time: O(n * sqrt(n)) Space: O(n)
class Solution {
    public int minSquares(int n) {
        int[] dp = new int[n + 1];
        for (int i = 1; i <= n; i++)
            dp[i] = i;

        for (int i = 1; i <= n; i++) {
            for (int j = 1; j * j <= i; j++) {
                int sq = j * j;
                dp[i] = Math.min(dp[i], 1 + dp[i - sq]);
            }
        }

        return dp[n];
    }
}