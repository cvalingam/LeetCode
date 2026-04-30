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