// Approach: Count servers per row and per column; a server communicates if its row count > 1 or its column count > 1.
// Time: O(m·n) Space: O(m+n)

public class Solution
{
    public int CountServers(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int ans = 0;
        int[] rows = new int[m];
        int[] cols = new int[n];

        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                if (grid[i][j] == 1)
                {
                    ++rows[i];
                    ++cols[j];
                }
            }
        }

        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                if (grid[i][j] == 1 && (rows[i] > 1 || cols[j] > 1))
                    ++ans;
            }
        }

        return ans;
    }
}