// Approach: Precompute row max and column max; each cell can be increased to min(rowMax[i], colMax[j]) without changing the skyline.
// Time: O(n²) Space: O(n)

public class Solution
{
    public int MaxIncreaseKeepingSkyline(int[][] grid)
    {
        int n = grid.Length;
        int[] row = new int[n];
        int[] col = new int[n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                row[i] = Math.Max(row[i], grid[i][j]);
                col[j] = Math.Max(col[j], grid[i][j]);
            }
        }

        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                ans += Math.Min(row[i], col[j]) - grid[i][j];
        }

        return ans;
    }
}