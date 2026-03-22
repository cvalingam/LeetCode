class Solution {

    public int minCoins(int coins[], int sum) {
        // Tabulation
        int n = coins.length;
        int[][] dp = new int[n][sum + 1];

        for (int i = 0; i <= sum; i++) {
            if (i % coins[0] == 0)
                dp[0][i] = i / coins[0];
            else
                dp[0][i] = (int) (1e9);
        }

        for (int ind = 1; ind < n; ind++) {
            for (int target = 0; target <= sum; target++) {
                int notTake = dp[ind - 1][target];
                int take = Integer.MAX_VALUE;

                if (coins[ind] <= target)
                    take = 1 + dp[ind][target - coins[ind]];

                dp[ind][target] = Math.min(take, notTake);
            }
        }
        
        return dp[n - 1][sum] >= (int) (1e9) ? -1 : dp[n - 1][sum];
    }
}