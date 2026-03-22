import java.util.*;

class Solution {
    public ArrayList<String> findPath(int[][] mat) {
        int n = mat.length;
        ArrayList<String> ans = new ArrayList<String>();
        int[][] vis = new int[n][n];
        if (mat[0][0] == 1)
            find(0, 0, mat, n, ans, "", vis);

        return ans;
    }

    private static void find(int i, int j, int[][] a, int n, ArrayList<String> ans, String move, int[][] vis) {
        if (i == n - 1 && j == n - 1) {
            ans.add(move);
            return;
        }

        // down
        if (i + 1 < n && vis[i + 1][j] == 0 && a[i + 1][j] == 1) {
            vis[i][j] = 1;
            find(i + 1, j, a, n, ans, move + 'D', vis);
            vis[i][j] = 0;
        }

        // left
        if (j - 1 >= 0 && vis[i][j - 1] == 0 && a[i][j - 1] == 1) {
            vis[i][j] = 1;
            find(i, j - 1, a, n, ans, move + 'L', vis);
            vis[i][j] = 0;
        }

        // right
        if (j + 1 < n && vis[i][j + 1] == 0 && a[i][j + 1] == 1) {
            vis[i][j] = 1;
            find(i, j + 1, a, n, ans, move + 'R', vis);
            vis[i][j] = 0;
        }

        // up
        if (i - 1 >= 0 && vis[i - 1][j] == 0 && a[i - 1][j] == 1) {
            vis[i][j] = 1;
            find(i - 1, j, a, n, ans, move + 'U', vis);
            vis[i][j] = 0;
        }
    }
}