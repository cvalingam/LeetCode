import java.util.*;

class Solution {
    static int countMin(String str) {
        String temp = "";
        int n = str.length();

        int[][] dp = new int[n][n];

        for (int[] row : dp)
            Arrays.fill(row, -1);

        for (int i = n - 1; i >= 0; i--)
            temp += str.charAt(i) + "";

        return n - lcs(n - 1, n - 1, str, temp, dp);
    }

    static int lcs(int i, int j, String str1, String str2, int[][] dp) {
        if (i < 0 || j < 0)
            return 0;

        if (dp[i][j] != -1)
            return dp[i][j];

        if (str1.charAt(i) == str2.charAt(j))
            return dp[i][j] = 1 + lcs(i - 1, j - 1, str1, str2, dp);
        else
            return dp[i][j] = Math.max(lcs(i - 1, j, str1, str2, dp), lcs(i, j - 1, str1, str2, dp));
    }
}