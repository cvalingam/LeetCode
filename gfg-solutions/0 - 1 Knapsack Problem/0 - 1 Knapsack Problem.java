import java.util.*;

class Solution {
    // Function to return max value that can be put in knapsack of capacity W.
    static int knapSack(int W, int wt[], int val[]) {
        int n = val.length;
        int[][] dp = new int[n][W + 1];

        for (int[] row : dp)
            Arrays.fill(row, -1);

        return topDown(0, W, wt, val, n, dp);
    }

    static int topDown(int i, int W, int[] wt, int[] val, int n, int[][] dp) {
        if (i >= n || W <= 0)
            return 0;

        if (dp[i][W] != -1)
            return dp[i][W];

        int nottake = topDown(i + 1, W, wt, val, n, dp);

        int take = 0;
        if (W - wt[i] >= 0)
            take = val[i] + topDown(i + 1, W - wt[i], wt, val, n, dp);

        return dp[i][W] = Math.max(take, nottake);
    }
}
