class Solution {
    public int count(int coins[], int sum) {
        int n = coins.length;
        int dp[] = new int[sum + 1];

        // Base Case: One way to make sum 0 (using no coins)
        dp[0] = 1;

        // Process each coin
        for (int coin : coins) {
            for (int j = coin; j <= sum; j++)
                dp[j] += dp[j - coin]; // Include this coin in forming sum j
        }

        return dp[sum];
    }
}