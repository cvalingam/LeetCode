public class Solution
{
    public int MinCost(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int[][] mem = new int[m][];
        for (int i = 0; i < m; i++)
        {
            mem[i] = new int[n];
            Array.Fill(mem[i], -1);
        }
        Queue<(int, int)> q = new Queue<(int, int)>();

        Dfs(grid, 0, 0, 0, q, mem);

        for (int cost = 1; q.Count > 0; cost++)
        {
            int sz = q.Count;
            for (int i = 0; i < sz; i++)
            {
                var pair = q.Dequeue();
                int x = pair.Item1;
                int y = pair.Item2;
                foreach (var dir in dirs)
                    Dfs(grid, x + dir[0], y + dir[1], cost, q, mem);
            }
        }

        return mem[m - 1][n - 1];
    }

    private static readonly int[][] dirs = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

    private void Dfs(int[][] grid, int i, int j, int cost, Queue<(int, int)> q, int[][] mem)
    {
        if (i < 0 || i == grid.Length || j < 0 || j == grid[0].Length)
            return;
        if (mem[i][j] != -1)
            return;

        mem[i][j] = cost;
        q.Enqueue((i, j));
        int[] dir = dirs[grid[i][j] - 1];
        Dfs(grid, i + dir[0], j + dir[1], cost, q, mem);
    }
}