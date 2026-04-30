// Approach: Top-down DFS with memoization. Recurse backwards from (m-1,n-1) to (0,0).
// State Dfs(i,j,k) = max score reachable with k positive-cell budget remaining.
// Decrement k only when stepping on a positive cell. Take max of up/left predecessors.
// Sentinel -inf marks impossible paths; return -1 if final answer < 0.
// Time: O(m*n*k) Space: O(m*n*k)
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