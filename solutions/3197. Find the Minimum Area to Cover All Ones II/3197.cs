public class Solution
{
    public int MinimumSum(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int ans = m * n;

        for (int i = 0; i < m; ++i)
        {
            int top = MinimumArea(grid, 0, i, 0, n - 1);
            for (int j = 0; j < n; ++j)
                ans = Math.Min(ans, top + /*left*/ MinimumArea(grid, i + 1, m - 1, 0, j) +
                                    /*right*/ MinimumArea(grid, i + 1, m - 1, j + 1, n - 1));
        }

        for (int i = 0; i < m; ++i)
        {
            int bottom = MinimumArea(grid, i, m - 1, 0, n - 1);
            for (int j = 0; j < n; ++j)
                ans = Math.Min(ans, bottom + /*left*/ MinimumArea(grid, 0, i - 1, 0, j) +
                                    /*right*/ MinimumArea(grid, 0, i - 1, j + 1, n - 1));
        }

        for (int j = 0; j < n; ++j)
        {
            int left = MinimumArea(grid, 0, m - 1, 0, j);
            for (int i = 0; i < m; ++i)
                ans = Math.Min(ans, left + /*top*/ MinimumArea(grid, 0, i, j + 1, n - 1) +
                                    /*bottom*/ MinimumArea(grid, i + 1, m - 1, j + 1, n - 1));
        }

        for (int j = 0; j < n; ++j)
        {
            int right = MinimumArea(grid, 0, m - 1, j, n - 1);
            for (int i = 0; i < m; ++i)
                ans = Math.Min(ans, right + /*top*/ MinimumArea(grid, 0, i, 0, j - 1) +
                                    /*bottom*/ MinimumArea(grid, i + 1, m - 1, 0, j - 1));
        }

        for (int i1 = 0; i1 < m; ++i1)
        {
            for (int i2 = i1 + 1; i2 < m; ++i2)
                ans = Math.Min(ans, /*top*/ MinimumArea(grid, 0, i1, 0, n - 1) +
                                    /*middle*/ MinimumArea(grid, i1 + 1, i2, 0, n - 1) +
                                    /*bottom*/ MinimumArea(grid, i2 + 1, m - 1, 0, n - 1));
        }

        for (int j1 = 0; j1 < n; ++j1)
            {
                for (int j2 = j1 + 1; j2 < n; ++j2)
                    ans = Math.Min(ans, /*left*/ MinimumArea(grid, 0, m - 1, 0, j1) +
                                        /*middle*/ MinimumArea(grid, 0, m - 1, j1 + 1, j2) +
                                        /*right*/ MinimumArea(grid, 0, m - 1, j2 + 1, n - 1));
            }

        return ans;
    }

    private int MinimumArea(int[][] grid, int si, int ei, int sj, int ej)
    {
        int x1 = int.MaxValue;
        int y1 = int.MaxValue;
        int x2 = 0;
        int y2 = 0;
        for (int i = si; i <= ei; ++i)
        {
            for (int j = sj; j <= ej; ++j)
            {
                if (grid[i][j] == 1)
                {
                    x1 = Math.Min(x1, i);
                    y1 = Math.Min(y1, j);
                    x2 = Math.Max(x2, i);
                    y2 = Math.Max(y2, j);
                }
            }
        }

        return x1 == int.MaxValue ? 0 : (x2 - x1 + 1) * (y2 - y1 + 1);
    }
}