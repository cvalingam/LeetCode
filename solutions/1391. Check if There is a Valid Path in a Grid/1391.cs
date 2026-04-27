public class Solution
{
    // Approach: Expand each cell to a 3x3 mini-grid that encodes street connectivity,
    // then DFS from start to destination on expanded walkable pixels.
    // Time: O(m*n) Space: O(m*n)
    public bool HasValidPath(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        bool[,] g = new bool[m * 3, n * 3];

        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                switch (grid[i][j])
                {
                    case 1:
                        g[i * 3 + 1, j * 3 + 0] = true;
                        g[i * 3 + 1, j * 3 + 1] = true;
                        g[i * 3 + 1, j * 3 + 2] = true;
                        break;
                    case 2:
                        g[i * 3 + 0, j * 3 + 1] = true;
                        g[i * 3 + 1, j * 3 + 1] = true;
                        g[i * 3 + 2, j * 3 + 1] = true;
                        break;
                    case 3:
                        g[i * 3 + 1, j * 3 + 0] = true;
                        g[i * 3 + 1, j * 3 + 1] = true;
                        g[i * 3 + 2, j * 3 + 1] = true;
                        break;
                    case 4:
                        g[i * 3 + 1, j * 3 + 1] = true;
                        g[i * 3 + 1, j * 3 + 2] = true;
                        g[i * 3 + 2, j * 3 + 1] = true;
                        break;
                    case 5:
                        g[i * 3 + 0, j * 3 + 1] = true;
                        g[i * 3 + 1, j * 3 + 0] = true;
                        g[i * 3 + 1, j * 3 + 1] = true;
                        break;
                    case 6:
                        g[i * 3 + 0, j * 3 + 1] = true;
                        g[i * 3 + 1, j * 3 + 1] = true;
                        g[i * 3 + 1, j * 3 + 2] = true;
                        break;
                }
            }
        }

        return Dfs(g, 1, 1);
    }

    private bool Dfs(bool[,] g, int i, int j)
    {
        if (i < 0 || i == g.GetLength(0) || j < 0 || j == g.GetLength(1))
            return false;
        if (!g[i, j]) // There's no path here.
            return false;
        if (i == g.GetLength(0) - 2 && j == g.GetLength(1) - 2)
            return true;

        g[i, j] = false; // Mark as visited.
        return Dfs(g, i + 1, j) || Dfs(g, i - 1, j) || Dfs(g, i, j + 1) || Dfs(g, i, j - 1);
    }
}