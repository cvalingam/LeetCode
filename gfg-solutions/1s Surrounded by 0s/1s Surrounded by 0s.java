
// Approach: Run DFS from every border cell containing 1 and mark all border-connected 1s as visited.
// Any 1 not reached by this border flood-fill is fully surrounded by 0s, so count those cells.
// Time: O(n * m) Space: O(n * m)

class Solution {

    int cntOnes(int[][] grid) {
        int n = grid.length;
        int m = grid[0].length;
        boolean[][] visited = new boolean[n][m];

        for (int i = 0; i < n; i++) {
            if (grid[i][0] == 1 && !visited[i][0]) {
                dfs(grid, visited, i, 0);
            }
            if (grid[i][m - 1] == 1 && !visited[i][m - 1]) {
                dfs(grid, visited, i, m - 1);
            }
        }
        for (int j = 0; j < m; j++) {
            if (grid[0][j] == 1 && !visited[0][j]) {
                dfs(grid, visited, 0, j);
            }
            if (grid[n - 1][j] == 1 && !visited[n - 1][j]) {
                dfs(grid, visited, n - 1, j);
            }
        }

        int count = 0;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (grid[i][j] == 1 && !visited[i][j]) {
                    count++;
                }
            }
        }
        return count;
    }

    void dfs(int[][] grid, boolean[][] visited, int x, int y) {
        if (x < 0 || x >= grid.length || y < 0 || y >= grid[0].length || grid[x][y] == 0 || visited[x][y]) {
            return;
        }
        visited[x][y] = true;
        dfs(grid, visited, x + 1, y);
        dfs(grid, visited, x - 1, y);
        dfs(grid, visited, x, y + 1);
        dfs(grid, visited, x, y - 1);
    }
};
