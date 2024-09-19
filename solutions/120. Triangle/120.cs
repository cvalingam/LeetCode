public class Solution
{
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        int n = triangle.Count;
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            int m = triangle[i].Count;
            int[] arr = new int[m];
            Array.Fill(arr, -1);
            dp[i] = arr;
        }
        // return topDown(0, 0, triangle, dp);
        return tabulation(n, triangle, dp);
    }

    private int topDown(int r, int c, IList<IList<int>> triangle, int[][] dp)
    {
        if (r == (triangle.Count - 1))
            return triangle[r][c];

        if (dp[r][c] != -1)
            return dp[r][c];

        int down = triangle[r][c] + topDown(r + 1, c, triangle, dp);

        int cross = triangle[r][c] + topDown(r + 1, c + 1, triangle, dp);

        return dp[r][c] = Math.Min(down, cross);
    }

    private int tabulation(int r, IList<IList<int>> triangle, int[][] dp)
    {
        int[] front = new int[r];
        for (int j = 0; j < r; j++)
            front[j] = triangle[r - 1][j];

        for (int i = r - 2; i >= 0; i--)
        {
            int[] curr = new int[r];
            for (int j = i; j >= 0; j--)
            {
                int down = triangle[i][j];
                int cross = triangle[i][j];
                down += front[j];

                cross += front[j + 1];

                curr[j] = Math.Min(down, cross);
            }
            front = curr;
        }

        return front[0];
    }
}