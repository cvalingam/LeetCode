import java.util.*;

class Solution {
    public int numberOfPath(int[][] arr, int k) {
        int n = arr.length;
        int m = arr[0].length;

        long[][][] dp = new long[n][m][k + 1];
        for (long[][] matrix : dp) {
            for (long[] row : matrix)
                Arrays.fill(row, -1);
        }

        return (int) helper(n - 1, m - 1, k, arr, dp);
    }

    private long helper(int i, int j, int k, int[][] arr, long[][][] dp) {
        if (i == 0 && j == 0 && k == arr[i][j])
            return 1;
        if (i < 0 || j < 0 || k < 0)
            return 0;

        if (dp[i][j][k] != -1)
            return dp[i][j][k];

        long up = helper(i - 1, j, k - arr[i][j], arr, dp);
        long left = helper(i, j - 1, k - arr[i][j], arr, dp);

        return dp[i][j][k] = up + left;
    }
}