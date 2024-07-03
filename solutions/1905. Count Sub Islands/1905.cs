public class Solution
{
    public int CountSubIslands(int[][] grid1, int[][] grid2)
    {
        int ans = 0;

        for (int i = 0; i < grid2.Length; i++)
        {
            for (int j = 0; j < grid2[i].Length; j++)
            {
                if (grid2[i][j] == 1)
                {
                    int flag = 1;
                    dfs(grid1, grid2, i, j, ref flag);
                    if (flag == 1)
                        ans++;
                }
            }
        }

        return ans;
    }

    private void dfs(int[][] grid1, int[][] grid2, int i, int j, ref int flag)
    {
        if (i < 0 || i >= grid2.Length || j < 0 || j >= grid2[0].Length)
            return;

        if (grid2[i][j] != 1)
            return;

        if (grid2[i][j] == 1)
        {
            if (grid1[i][j] == 0)
            {
                flag = 0;
                return;
            }
            grid2[i][j] = 2;
        }

        dfs(grid1, grid2, i + 1, j, ref flag);
        dfs(grid1, grid2, i - 1, j, ref flag);
        dfs(grid1, grid2, i, j + 1, ref flag);
        dfs(grid1, grid2, i, j - 1, ref flag);
    }
}