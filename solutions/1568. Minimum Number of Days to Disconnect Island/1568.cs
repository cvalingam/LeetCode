public class Solution
{
    public int MinDays(int[][] grid)
    {
        if (Disconnected(grid))
            return 0;

        // Try to remove 1 land.
        for (int i = 0; i < grid.Length; ++i)
            for (int j = 0; j < grid[0].Length; ++j)
                if (grid[i][j] == 1)
                {
                    grid[i][j] = 0;
                    if (Disconnected(grid))
                        return 1;
                    grid[i][j] = 1;
                }

        // Remove 2 lands.
        return 2;
    }

    private readonly int[][] dirs = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };

    private bool Disconnected(int[][] grid)
    {
        int islandsCount = 0;
        bool[][] seen = new bool[grid.Length][];
        for (int i = 0; i < grid.Length; i++)
        {
            seen[i] = new bool[grid[0].Length];
        }
        for (int i = 0; i < grid.Length; ++i)
            for (int j = 0; j < grid[0].Length; ++j)
            {
                if (grid[i][j] == 0 || seen[i][j])
                    continue;
                if (++islandsCount > 1)
                    return true;
                Dfs(grid, i, j, seen);
            }

        return islandsCount != 1;
    }

    private void Dfs(int[][] grid, int i, int j, bool[][] seen)
    {
        seen[i][j] = true;
        foreach (var dir in dirs)
        {
            int x = i + dir[0];
            int y = j + dir[1];
            if (x < 0 || x == grid.Length || y < 0 || y == grid[0].Length)
                continue;
            if (grid[x][y] == 0 || seen[x][y])
                continue;
            Dfs(grid, x, y, seen);
        }
    }
}