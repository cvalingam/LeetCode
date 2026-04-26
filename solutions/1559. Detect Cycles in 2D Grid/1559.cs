public class Solution
{
    // Approach: DFS on same-character components with parent tracking; revisiting a
    // previously seen non-parent neighbor implies a cycle.
    // Time: O(m*n) Space: O(m*n)
    private static readonly int[][] DIRS = new int[][] {
        new int[] {0, 1},
        new int[] {1, 0},
        new int[] {0, -1},
        new int[] {-1, 0}
    };

    public bool ContainsCycle(char[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        bool[][] seen = new bool[m][];
        for (int i = 0; i < m; i++)
            seen[i] = new bool[n];

        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                if (seen[i][j])
                    continue;
                if (Dfs(grid, i, j, -1, -1, grid[i][j], seen))
                    return true;
            }
        }

        return false;
    }

    private bool Dfs(char[][] grid, int i, int j, int prevI, int prevJ, char c, bool[][] seen)
    {
        seen[i][j] = true;

        foreach (var dir in DIRS)
        {
            int x = i + dir[0];
            int y = j + dir[1];
            if (x < 0 || x == grid.Length || y < 0 || y == grid[0].Length)
                continue;
            if (x == prevI && y == prevJ)
                continue;
            if (grid[x][y] != c)
                continue;
            if (seen[x][y])
                return true;
            if (Dfs(grid, x, y, i, j, c, seen))
                return true;
        }

        return false;
    }
}