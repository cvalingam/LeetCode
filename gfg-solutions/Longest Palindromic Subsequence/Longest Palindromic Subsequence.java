class Solution {
    public int longestPalinSubseq(String s) {
        int n = s.length();
        int[][] dp = new int[n][n];

        // Initialize diagonal elements (single characters)
        for (int i = 0; i < n; i++)
            dp[i][i] = 1;

        // Fill the dp table
        for (int len = 2; len <= n; len++) {
            for (int i = 0; i < n - len + 1; i++) {
                int j = i + len - 1;

                if (s.charAt(i) == s.charAt(j) && len == 2)
                    dp[i][j] = 2;
                else if (s.charAt(i) == s.charAt(j))
                    dp[i][j] = dp[i + 1][j - 1] + 2;
                else
                    dp[i][j] = Math.max(dp[i + 1][j], dp[i][j - 1]);
            }
        }

        return dp[0][n - 1];
    }
}