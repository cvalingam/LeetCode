import java.util.*;

class Solution {
    public int wildCard(String pattern, String str) {
        int n = pattern.length();
        int m = str.length();

        int[][] dp = new int[n + 1][m + 1];
        for (int i = 0; i <= n; i++) {
            Arrays.fill(dp[i], -1);
        }

        return topDown(n, m, pattern, str, dp);
    }

    private int topDown(int i, int j, String p, String s, int[][] dp) {
        if (i == 0 && j == 0)
            return 1;
        if (i == 0 && j > 0)
            return 0;
        if (i > 0 && j == 0) {
            for (int k = 1; k <= i; k++) {
                if (p.charAt(k - 1) != '*')
                    return 0;
            }
            return 1;
        }

        if (dp[i][j] != -1)
            return dp[i][j];

        if (p.charAt(i - 1) == s.charAt(j - 1) || p.charAt(i - 1) == '?')
            return dp[i][j] = topDown(i - 1, j - 1, p, s, dp);

        if (p.charAt(i - 1) == '*')
            return dp[i][j] = topDown(i - 1, j, p, s, dp) | topDown(i, j - 1, p, s, dp);

        dp[i][j] = 0;
        return dp[i][j];
    }
}

// Solution using Bottom-Up DP
class Solution1 {
    public boolean wildCard(String txt, String pat) {
        int n = txt.length();
        int m = pat.length();

        boolean[][] dp = new boolean[m + 1][n + 1];
        dp[0][0] = true;

        for (int i = 1; i <= m; i++) {
            if (pat.charAt(i - 1) == '*')
                dp[i][0] = dp[i - 1][0];
            else
                dp[i][0] = false;
        }

        for (int i = 1; i <= m; i++) {
            for (int j = 1; j <= n; j++) {
                char pChar = pat.charAt(i - 1);
                char tChar = txt.charAt(j - 1);
                if (pChar == '?')
                    dp[i][j] = dp[i - 1][j - 1];
                else if (pChar == '*')
                    dp[i][j] = dp[i - 1][j] || dp[i][j - 1];
                else {
                    if (pChar == tChar)
                        dp[i][j] = dp[i - 1][j - 1];
                    else
                        dp[i][j] = false;
                }
            }
        }
        return dp[m][n];
    }
}
