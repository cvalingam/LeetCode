// Approach: DP. dp[i][j] = side of largest square with bottom-right at (i,j) = 1+min(dp[i-1][j], dp[i][j-1], dp[i-1][j-1]).
// Time: O(n*m) Space: O(n*m)
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