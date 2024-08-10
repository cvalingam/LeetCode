public class Solution
{
    public int RegionsBySlashes(string[] grid)
    {
        int n = grid.Length;
        // G := upscaled grid
        int[,] g = new int[n * 3, n * 3];

        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                if (grid[i][j] == '/')
                {
                    g[i * 3, j * 3 + 2] = 1;
                    g[i * 3 + 1, j * 3 + 1] = 1;
                    g[i * 3 + 2, j * 3] = 1;
                }
                else if (grid[i][j] == '\\')
                {
                    g[i * 3, j * 3] = 1;
                    g[i * 3 + 1, j * 3 + 1] = 1;
                    g[i * 3 + 2, j * 3 + 2] = 1;
                }
            }
        }

        int ans = 0;

        for (int i = 0; i < n * 3; ++i)
        {
            for (int j = 0; j < n * 3; ++j)
            {
                if (g[i, j] == 0)
                {
                    DFS(g, i, j);
                    ++ans;
                }
            }
        }

        return ans;
    }

    private void DFS(int[,] g, int i, int j)
    {
        if (i < 0 || i == g.GetLength(0) || j < 0 || j == g.GetLength(1))
            return;
        if (g[i, j] != 0)
            return;

        g[i, j] = 2; // Mark 2 as visited.
        Dfs(g, i + 1, j);
        Dfs(g, i - 1, j);
        Dfs(g, i, j + 1);
        Dfs(g, i, j - 1);
    }
}