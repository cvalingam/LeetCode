import java.util.*;

class Solution {
    int minCost(int[] height) {
        int n = height.length;
        int[] dp = new int[n];
        Arrays.fill(dp, -1);

        return memo(height, dp, 0, n);
    }

    private int memo(int[] height, int[] dp, int st, int n) {
        if (dp[st] != -1)
            return dp[st];
        if (st >= n - 2)
            return dp[st] = Math.abs(height[st] - height[n - 1]);

        int one = memo(height, dp, st + 1, n) + Math.abs(height[st] - height[st + 1]);
        int two = memo(height, dp, st + 2, n) + Math.abs(height[st] - height[st + 2]);

        return dp[st] = Math.min(one, two);
    }
}