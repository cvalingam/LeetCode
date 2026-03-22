import java.util.*;

class Solution {
    private int[][] keyPad = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 },
            { -1, 0, -1 }
    };

    private int[] dirX = { 0, 0, 1, -1 };
    private int[] dirY = { 1, -1, 0, 0 };

    public long getCount(int n) {
        long[][] dp = new long[10][n + 1];

        for (long[] row : dp)
            Arrays.fill(row, -1);

        long ans = 0;

        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 3; j++) {
                if (keyPad[i][j] != -1)
                    ans += topDown(i, j, n, dp);
            }
        }

        return ans;
    }

    private long topDown(int i, int j, int N, long[][] dp) {
        if (N == 1)
            return 1;

        if (dp[keyPad[i][j]][N] != -1)
            return dp[keyPad[i][j]][N];

        long ans = 0;

        ans += topDown(i, j, N - 1, dp);

        for (int k = 0; k < 4; k++) {
            int newI = i + dirX[k];
            int newJ = j + dirY[k];

            if (newI >= 0 && newJ >= 0 && newI < 4 && newJ < 3 && keyPad[newI][newJ] != -1)
                ans += topDown(newI, newJ, N - 1, dp);
        }

        return dp[keyPad[i][j]][N] = ans;
    }
}