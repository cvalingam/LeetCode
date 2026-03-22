import java.util.*;

class Solution {
    public ArrayList<ArrayList<Integer>> nearest(int[][] grid) {
        int n = grid.length;
        int m = grid[0].length;
        int[][] dist = new int[n][m];
        boolean[][] visited = new boolean[n][m];
        Queue<int[]> q = new LinkedList<>();
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (grid[i][j] == 1) {
                    q.add(new int[] { i, j, 0 });
                    visited[i][j] = true;
                }
            }
        }
        
        int[] dx = { 1, -1, 0, 0 };
        int[] dy = { 0, 0, 1, -1 };
        while (!q.isEmpty()) {
            int[] curr = q.poll();
            int i = curr[0];
            int j = curr[1];
            int d = curr[2];
            dist[i][j] = d;
            for (int k = 0; k < 4; k++) {
                int ni = i + dx[k];
                int nj = j + dy[k];
                if (ni >= 0 && ni < n && nj >= 0 && nj < m && !visited[ni][nj]) {
                    visited[ni][nj] = true;
                    q.add(new int[] { ni, nj, d + 1 });
                }
            }
        }

        ArrayList<ArrayList<Integer>> ans = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            ArrayList<Integer> row = new ArrayList<>();
            for (int j = 0; j < m; j++)
                row.add(dist[i][j]);
            ans.add(row);
        }
        return ans;
    }
}