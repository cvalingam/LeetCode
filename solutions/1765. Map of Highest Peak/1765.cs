public class Solution
{
    public int[][] HighestPeak(int[][] isWater)
    {
        int[][] dirs = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
        int m = isWater.Length;
        int n = isWater[0].Length;
        int[][] ans = new int[m][];
        for (int i = 0; i < m; i++)
        {
            ans[i] = new int[n];
            Array.Fill(ans[i], -1);
        }
        Queue<(int, int)> q = new Queue<(int, int)>();

        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                if (isWater[i][j] == 1)
                {
                    q.Enqueue((i, j));
                    ans[i][j] = 0;
                }
            }
        }

        while (q.Count > 0)
        {
            var (i, j) = q.Dequeue();
            foreach (var dir in dirs)
            {
                int x = i + dir[0];
                int y = j + dir[1];
                if (x < 0 || x == m || y < 0 || y == n)
                    continue;
                if (ans[x][y] != -1)
                    continue;
                ans[x][y] = ans[i][j] + 1;
                q.Enqueue((x, y));
            }
        }

        return ans;
    }
}