import java.util.*;

class Solution {
    public int minOperations(String str1, String str2) {
        int m = str1.length();
        int n = str2.length();

        int[][] dp = new int[m + 1][n + 1];
        for (int[] row : dp)
            Arrays.fill(row, -1);

        int lcs = topDown(m, n, str1, str2, dp);

        return (m - lcs) + (n - lcs);
    }

    private int topDown(int i, int j, String text1, String text2, int[][] dp) {
        if (i == 0 || j == 0)
            return 0;

        if (dp[i][j] != -1)
            return dp[i][j];

        if (text1.charAt(i - 1) == text2.charAt(j - 1))
            return dp[i][j] = 1 + topDown(i - 1, j - 1, text1, text2, dp);

        return dp[i][j] = Math.max(topDown(i - 1, j, text1, text2, dp), topDown(i, j - 1, text1, text2, dp));
    }
}