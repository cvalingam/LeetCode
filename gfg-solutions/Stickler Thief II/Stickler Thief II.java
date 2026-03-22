import java.util.*;

class Solution {
    int maxValue(int[] arr) {
        int n = arr.length;
        int[] dp = new int[n];
        dp[0] = arr[0];
        dp[1] = Math.max(arr[0], arr[1]);

        for (int i = 2; i < n - 1; i++)
            dp[i] = Math.max(dp[i - 1], dp[i - 2] + arr[i]);

        int ans1 = dp[n - 2];
        Arrays.fill(dp, 0);
        dp[1] = arr[1];
        for (int i = 2; i < n; i++)
            dp[i] = Math.max(dp[i - 1], dp[i - 2] + arr[i]);

        int ans2 = dp[n - 1];
        return Math.max(ans1, ans2);
    }
}