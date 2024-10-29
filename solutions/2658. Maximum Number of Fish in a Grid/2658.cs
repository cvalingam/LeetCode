public class Solution
{
    public int FindMaxFish(int[][] grid)
    {
        int ans = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] > 0)
                    ans = Math.Max(ans, dfs(i, j, grid));
            }
        }

        return ans;
    }

    private int dfs(int i, int j, int[][] grid)
    {
        if (i < 0 || i == grid.Length || j < 0 || j == grid[0].Length)
            return 0;

        if (grid[i][j] == 0)
            return 0;

        int fish = grid[i][j];
        grid[i][j] = 0;

        int sum = 0;
        sum += fish;
        sum += dfs(i, j + 1, grid);
        sum += dfs(i, j - 1, grid);
        sum += dfs(i + 1, j, grid);
        sum += dfs(i - 1, j, grid);

        return sum;
    }
}