class Solution {
    static int maxSquare(int n, int m, int mat[][]) {
        int[][] dp = new int[n][m];

        int maxSize = 0;

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (mat[i][j] == 1) {
                    if (i == 0 || j == 0)
                        dp[i][j] = 1;
                    else {
                        dp[i][j] = 1 + Math.min(dp[i - 1][j - 1],
                                Math.min(dp[i - 1][j], dp[i][j - 1]));
                    }

                    maxSize = Math.max(maxSize, dp[i][j]);
                }
            }
        }

        return maxSize;
    }
}