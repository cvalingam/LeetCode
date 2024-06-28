public class Solution
{
    public int[] FindColumnWidth(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        int[] ans = new int[n];
        for (int j = 0; j < n; j++)
        {
            for (int i = 0; i < m; i++)
            {
                ans[j] = Math.Max(ans[j], grid[i][j].ToString().Length);
            }
        }

        return ans;
    }
}