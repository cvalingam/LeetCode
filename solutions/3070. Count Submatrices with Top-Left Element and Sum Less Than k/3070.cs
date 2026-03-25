// Approach: 2D prefix sum from top-left; count cells where prefix sum ≤ k.
// Time: O(mn) Space: O(mn)

public class Solution
{
    public int CountSubmatrices(int[][] grid, int k)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int ans = 0;
        int[,] prefix = new int[m + 1, n + 1];

        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                prefix[i + 1, j + 1] = grid[i][j] + prefix[i, j + 1] + prefix[i + 1, j] - prefix[i, j];
                if (prefix[i + 1, j + 1] <= k)
                    ++ans;
            }
        }

        return ans;
    }
}