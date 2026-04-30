/*
 * 3742. Maximum Path Score in a Grid
 *
 * APPROACH — Top-Down DFS with Memoization
 * -----------------------------------------
 * Move from (m-1, n-1) back to (0, 0) only going up or left (reverse of right/down).
 * State: Dfs(i, j, k) = max score from (i,j) to destination with k positive-cell budget left.
 * - If grid[i][j] > 0, decrement k before exploring predecessors.
 * - Score = grid[i][j] + max(Dfs(i-1,j,nk), Dfs(i,j-1,nk)).
 * - Cache in f[i,j,k] to avoid recomputation.
 * - Sentinel -inf propagates through Math.Max to mark impossible paths.
 * - If final result < 0, return -1 (no valid path exists).
 *
 * Why recurse backwards? Lets us define "score from here to end" cleanly;
 * both predecessor directions (up/left) map naturally from destination.
 *
 * COMPLEXITY
 * ----------
 * Time:  O(m × n × k)  — each state (i,j,k) computed once
 * Space: O(m × n × k)  — memo table; recursion stack O(m + n)
 */
public class Solution
{
    private int[][] grid;
    private int?[,,] f;
    private readonly int inf = 1 << 30;

    public int MaxPathScore(int[][] grid, int k)
    {
        this.grid = grid;
        int m = grid.Length;
        int n = grid[0].Length;
        f = new int?[m, n, k + 1];
        int ans = Dfs(m - 1, n - 1, k);
        return ans < 0 ? -1 : ans;
    }

    private int Dfs(int i, int j, int k)
    {
        if (i < 0 || j < 0 || k < 0)
            return -inf;

        if (i == 0 && j == 0)
            return 0;

        if (f[i, j, k].HasValue)
            return f[i, j, k].Value;

        int res = grid[i][j];
        int nk = k;
        if (grid[i][j] > 0)
            --nk;

        int a = Dfs(i - 1, j, nk);
        int b = Dfs(i, j - 1, nk);
        res += Math.Max(a, b);
        f[i, j, k] = res;
        return res;
    }
}