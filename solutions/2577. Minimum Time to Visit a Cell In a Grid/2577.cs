public class Solution
{
    public int MinimumTime(int[][] grid)
    {
        if (grid[0][1] > 1 && grid[1][0] > 1)
            return -1;

        int[][] dirs = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
        int m = grid.Length;
        int n = grid[0].Length;
        var minHeap = new PriorityQueue<int[], int[]>(Comparer<int[]>.Create((a, b) => a[0].CompareTo(b[0])));
        int[] first = new int[] { 0, 0, 0 };
        minHeap.Enqueue(first, first); // (time, i, j)
        bool[,] seen = new bool[m, n];
        seen[0, 0] = true;

        while (minHeap.Count > 0)
        {
            int time = minHeap.Peek()[0];
            int i = minHeap.Peek()[1];
            int j = minHeap.Peek()[2];
            minHeap.Dequeue();

            if (i == m - 1 && j == n - 1)
                return time;

            foreach (var dir in dirs)
            {
                int x = i + dir[0];
                int y = j + dir[1];

                if (x < 0 || x == m || y < 0 || y == n)
                    continue;

                if (seen[x, y])
                    continue;
                    
                int extraWait = (grid[x][y] - time) % 2 == 0 ? 1 : 0;
                int nextTime = Math.Max(time + 1, grid[x][y] + extraWait);
                int[] nextVal = new int[] { nextTime, x, y };
                minHeap.Enqueue(nextVal, nextVal);
                seen[x, y] = true;
            }
        }

        throw new ArgumentException();
    }
}