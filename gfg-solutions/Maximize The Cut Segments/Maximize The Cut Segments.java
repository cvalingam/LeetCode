import java.util.*;

class Solution {
    // Function to find the maximum number of cuts.
    public int maximizeCuts(int n, int x, int y, int z) {
        int[] dp = new int[n + 1];
        Arrays.fill(dp, -1);

        return Math.max(0, topDown(n, x, y, z, dp));
    }

    int topDown(int n, int x, int y, int z, int[] dp) {
        if (n == 0)
            return 0;

        if (n < 0)
            return Integer.MIN_VALUE;

        if (dp[n] != -1)
            return dp[n];

        int xpath = topDown(n - x, x, y, z, dp);
        int ypath = topDown(n - y, x, y, z, dp);
        int zpath = topDown(n - z, x, y, z, dp);

        return dp[n] = 1 + Math.max(xpath, Math.max(ypath, zpath));
    }
}
