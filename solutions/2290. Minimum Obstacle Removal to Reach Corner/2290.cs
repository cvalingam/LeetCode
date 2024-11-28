public class Solution
{
    public int MinimumObstacles(int[][] grid)
    {
        int[][] dirs = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
        int m = grid.Length;
        int n = grid[0].Length;
        PriorityQueue<int[], int> minHeap = new PriorityQueue<int[], int>(Comparer<int>.Create((a, b) => a.CompareTo(b)));
        minHeap.Enqueue(new int[] { grid[0][0], 0, 0 }, grid[0][0]); // (d, i, j)
        int[][] dist = new int[m][];
        for (int i = 0; i < m; i++)
        {
            dist[i] = new int[n];
            Array.Fill(dist[i], int.MaxValue);
        }
        dist[0][0] = grid[0][0];

        while (minHeap.Count > 0)
        {
            int[] current = minHeap.Dequeue();
            int d = current[0];
            int i = current[1];
            int j = current[2];
            if (i == m - 1 && j == n - 1)
                return d;
            foreach (int[] dir in dirs)
            {
                int x = i + dir[0];
                int y = j + dir[1];
                if (x < 0 || x == m || y < 0 || y == n)
                    continue;
                int newDist = d + grid[i][j];
                if (newDist < dist[x][y])
                {
                    dist[x][y] = newDist;
                    minHeap.Enqueue(new int[] { newDist, x, y }, newDist);
                }
            }
        }

        return dist[m - 1][n - 1];
    }
}