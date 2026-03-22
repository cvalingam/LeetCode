class Solution {
    static int maxProfit(int prices[], int k) {
        int n = prices.length;
        // If K is 0 or array has less than 2 elements, no profit possible
        if (k == 0 || n < 2) {
            return 0;
        }

        // dp[i][j] represents maximum profit using at most i transactions up to day j
        int[][] dp = new int[k + 1][n];

        // For each transaction
        for (int i = 1; i <= k; i++) {
            // maxDiff keeps track of maximum profit we can have if we buy stock on day j
            int maxDiff = -prices[0];

            // For each day
            for (int j = 1; j < n; j++) {
                // Maximum of:
                // 1. Previous day's profit (no transaction today)
                // 2. Selling on current day + maxDiff (complete transaction today)
                dp[i][j] = Math.max(dp[i][j - 1], prices[j] + maxDiff);

                // Update maxDiff if we can get better profit by buying on current day
                maxDiff = Math.max(maxDiff, dp[i - 1][j] - prices[j]);
            }
        }

        return dp[k][n - 1];
    }
}