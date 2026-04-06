// Approach: DP. dp[i] = dp[i-1] + dp[i-2] (can take 1 or 2 steps). Base: dp[0]=dp[1]=1.
// Time: O(n) Space: O(1)
class Solution {
    int countWays(int n) {
        int dp[] = new int[n + 1];
        
        dp[0] = 1;
        for (int i = 1; i <= n; i++) {
            dp[i] += dp[i - 1];
            if (i > 1)
                dp[i] += dp[i - 2];
        }

        return dp[n];
    }
}
