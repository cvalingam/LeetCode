public class Solution
{
    private static readonly int[][] DIRS = { new[] { -1, 1 }, new[] { 1, 1 }, new[] { 1, -1 }, new[] { -1, -1 } };
    public int LenOfVDiagonal(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int[,,,,] mem = new int[m, n, 2, 2, 4];

        int ans = 0;

        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                if (grid[i][j] == 1)
                {
                    for (int d = 0; d < 4; ++d)
                    {
                        int dx = DIRS[d][0];
                        int dy = DIRS[d][1];
                        ans = Math.Max(ans, 1 + DFS(grid, i + dx, j + dy, /*turned=*/false, 2, d, mem));
                    }
                }
            }
        }

        return ans;
    }

    private int DFS(int[][] grid, int i, int j, bool turned, int num, int dir,
                    int[,,,,] mem)
    {
        if (i < 0 || i == grid.Length || j < 0 || j == grid[0].Length)
            return 0;
        if (grid[i][j] != num)
            return 0;

        int hashNum = Math.Max(0, num - 1);
        if (mem[i, j, turned ? 1 : 0, hashNum, dir] != 0)  // Assuming 0 means uninitialized; adjust if needed
            return mem[i, j, turned ? 1 : 0, hashNum, dir];

        int nextNum = num == 2 ? 0 : 2;
        int dx = DIRS[dir][0], dy = DIRS[dir][1];
        int res = 1 + DFS(grid, i + dx, j + dy, turned, nextNum, dir, mem);

        if (!turned)
        {
            int nextDir = (dir + 1) % 4;
            int nextDx = DIRS[nextDir][0], nextDy = DIRS[nextDir][1];
            res = Math.Max(res,
                           1 + DFS(grid, i + nextDx, j + nextDy, /*turned=*/true, nextNum, nextDir, mem));
        }

        return mem[i, j, turned ? 1 : 0, hashNum, dir] = res;
    }
}