class Solution {
    static int minCostClimbingStairs(int[] cost) {
        int[] dp = new int[cost.length + 1];

        Arrays.fill(dp, -1);

        return solve(cost, 0, dp);
    }

    static int solve(int[] cost, int i, int[] dp) {
        if (dp[i] != -1)
            return dp[i];

        if (i == cost.length - 1)
            return 0;

        if (i == cost.length - 2)
            return Math.min(cost[i + 1], cost[i]);

        int n1 = cost[i] + solve(cost, i + 1, dp);

        int n2 = cost[i + 1] + solve(cost, i + 2, dp);

        dp[i] = Math.min(n1, n2);

        return dp[i];
    }
};