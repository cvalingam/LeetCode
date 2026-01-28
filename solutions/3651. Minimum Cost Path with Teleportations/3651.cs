public class Solution
{
    public int MinCost(int[][] grid, int k)
    {
        int m = grid.Length, n = grid[0].Length;
        int inf = int.MaxValue / 2;

        int[,,] f = new int[k + 1, m, n];
        for (int t = 0; t <= k; t++)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    f[t, i, j] = inf;
            }
        }

        f[0, 0, 0] = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i > 0)
                    f[0, i, j] = Math.Min(f[0, i, j], f[0, i - 1, j] + grid[i][j]);
                if (j > 0)
                    f[0, i, j] = Math.Min(f[0, i, j], f[0, i, j - 1] + grid[i][j]);
            }
        }

        var g = new Dictionary<int, List<(int, int)>>();
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int x = grid[i][j];
                if (!g.ContainsKey(x))
                    g[x] = new List<(int, int)>();
                g[x].Add((i, j));
            }
        }

        var keys = g.Keys.ToList();
        keys.Sort((a, b) => b.CompareTo(a)); // reverse order

        for (int t = 1; t <= k; t++)
        {
            int mn = inf;
            foreach (int key in keys)
            {
                var pos = g[key];
                foreach (var p in pos)
                    mn = Math.Min(mn, f[t - 1, p.Item1, p.Item2]);
                foreach (var p in pos)
                    f[t, p.Item1, p.Item2] = mn;
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i > 0)
                        f[t, i, j] = Math.Min(f[t, i, j], f[t, i - 1, j] + grid[i][j]);
                    if (j > 0)
                        f[t, i, j] = Math.Min(f[t, i, j], f[t, i, j - 1] + grid[i][j]);
                }
            }
        }

        int ans = inf;
        for (int t = 0; t <= k; t++)
            ans = Math.Min(ans, f[t, m - 1, n - 1]);

        return ans;
    }
}