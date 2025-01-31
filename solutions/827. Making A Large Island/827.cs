public class Solution
{
    public int LargestIsland(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int maxSize = 0;
        // sizes[i] := the size of the i-th connected component (starting from 2)
        List<int> sizes = new List<int> { 0, 0 };

        // For each 1 in the grid, paint all the connected 1s with the next
        // available color (2, 3, and so on). Also, remember the size of the island
        // we just painted with that color.
        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                if (grid[i][j] == 1)
                    sizes.Add(Paint(grid, i, j, sizes.Count)); // Paint 2, 3, ...
            }
        }

        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                if (grid[i][j] == 0)
                {
                    HashSet<int> neighborIds = new HashSet<int> {
                        GetId(grid, i - 1, j), GetId(grid, i + 1, j),
                        GetId(grid, i, j + 1), GetId(grid, i, j - 1)
                    };
                    maxSize = Math.Max(maxSize, 1 + GetSize(grid, neighborIds, sizes));
                }
            }
        }

        return maxSize == 0 ? m * n : maxSize;
    }

    private int Paint(int[][] grid, int i, int j, int id)
    {
        if (i < 0 || i == grid.Length || j < 0 || j == grid[0].Length)
            return 0;
        if (grid[i][j] != 1)
            return 0;
        grid[i][j] = id; // grid[i][j] is part of the id-th connected component.
        return 1 + Paint(grid, i + 1, j, id) + Paint(grid, i - 1, j, id) + Paint(grid, i, j + 1, id) +
            Paint(grid, i, j - 1, id);
    }

    // Gets the id of grid[i][j] and returns 0 if it's out-of-bounds.
    private int GetId(int[][] grid, int i, int j)
    {
        if (i < 0 || i == grid.Length || j < 0 || j == grid[0].Length)
            return 0; // Invalid
        return grid[i][j];
    }

    private int GetSize(int[][] grid, HashSet<int> neighborIds, List<int> sizes)
    {
        int size = 0;
        foreach (int neighborId in neighborIds)
            size += sizes[neighborId];
        return size;
    }
}