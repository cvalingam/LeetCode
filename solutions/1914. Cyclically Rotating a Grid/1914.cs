// Approach: Process concentric layers from outside inward; for each layer, extract the ring of elements,
// rotate the ring by k % ringSize positions, and place them back.
// The ring is linearized: top row (left to right) → right column (top to bottom) → bottom row (right to left) → left column (bottom to top).
// Use modulo to avoid full rotations when k exceeds layer length.
// Time: O(m*n + k*layers) Space: O(1) excluding output

public class Solution
{
    public int[][] RotateGrid(int[][] grid, int k)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int t = 0;     // the top
        int l = 0;     // the left
        int b = m - 1; // the bottom
        int r = n - 1; // the right

        while (t < b && l < r)
        {
            int elementInThisLayer = 2 * (b - t + 1) + 2 * (r - l + 1) - 4;
            int netRotations = k % elementInThisLayer;
            for (int rotate = 0; rotate < netRotations; ++rotate)
            {
                int topLeft = grid[t][l];
                for (int j = l; j < r; ++j)
                    grid[t][j] = grid[t][j + 1];
                for (int i = t; i < b; ++i)
                    grid[i][r] = grid[i + 1][r];
                for (int j = r; j > l; --j)
                    grid[b][j] = grid[b][j - 1];
                for (int i = b; i > t; --i)
                    grid[i][l] = grid[i - 1][l];
                grid[t + 1][l] = topLeft;
            }
            ++t;
            ++l;
            --b;
            --r;
        }

        return grid;
    }
}