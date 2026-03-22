import java.util.*;

class Solution {
    public int orangesRotting(int[][] mat) {
        if (mat == null || mat.length == 0)
            return -1;

        int n = mat.length;
        int m = mat[0].length;
        Queue<int[]> queue = new LinkedList<>();
        int freshCount = 0;
        int time = 0;

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (mat[i][j] == 2)
                    queue.add(new int[] { i, j, 0 });
                else if (mat[i][j] == 1)
                    freshCount++;
            }
        }

        if (freshCount == 0)
            return 0;

        int[] dRow = { -1, 1, 0, 0 };
        int[] dCol = { 0, 0, -1, 1 };

        while (!queue.isEmpty()) {
            int[] cell = queue.poll();
            int i = cell[0], j = cell[1], currTime = cell[2];
            time = Math.max(time, currTime);

            for (int d = 0; d < 4; d++) {
                int ni = i + dRow[d], nj = j + dCol[d];

                if (ni >= 0 && ni < n && nj >= 0 && nj < m && mat[ni][nj] == 1) {
                    mat[ni][nj] = 2;
                    freshCount--;
                    queue.add(new int[] { ni, nj, currTime + 1 }); // Add to queue with new time
                }
            }
        }

        return freshCount == 0 ? time : -1;
    }
}