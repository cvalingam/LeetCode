public class Solution
{
    private record T(int i, int j, int val);
    private static readonly int[][] DIRS = { new[] { 0, 1 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { -1, 0 } };

    public int[] MaxPoints(int[][] grid, int[] queries)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int[] ans = new int[queries.Length];
        PriorityQueue<T, int> minHeap = new();
        bool[,] seen = new bool[m, n];

        minHeap.Enqueue(new T(0, 0, grid[0][0]), grid[0][0]);
        seen[0, 0] = true;
        int accumulate = 0;

        foreach (var indexedQuery in GetIndexedQueries(queries))
        {
            int queryIndex = indexedQuery.queryIndex;
            int query = indexedQuery.query;
            while (minHeap.Count > 0)
            {
                int i = minHeap.Peek().i;
                int j = minHeap.Peek().j;
                int val = minHeap.Dequeue().val;
                if (val >= query)
                {
                    // The smallest neighbor is still larger than `query`, so no need to
                    // keep exploring. Re-push (i, j, grid[i][j]) back to the `minHeap`.
                    minHeap.Enqueue(new T(i, j, val), val);
                    break;
                }
                ++accumulate;
                foreach (var dir in DIRS)
                {
                    int x = i + dir[0];
                    int y = j + dir[1];
                    if (x < 0 || x == m || y < 0 || y == n)
                        continue;
                    if (seen[x, y])
                        continue;
                    minHeap.Enqueue(new T(x, y, grid[x][y]), grid[x][y]);
                    seen[x, y] = true;
                }
            }
            ans[queryIndex] = accumulate;
        }

        return ans;
    }

    private record IndexedQuery(int queryIndex, int query);

    private IndexedQuery[] GetIndexedQueries(int[] queries)
    {
        IndexedQuery[] indexedQueries = new IndexedQuery[queries.Length];
        for (int i = 0; i < queries.Length; ++i)
            indexedQueries[i] = new IndexedQuery(i, queries[i]);
            
        Array.Sort(indexedQueries, Comparer<IndexedQuery>.Create((a, b) => a.query.CompareTo(b.query)));
        return indexedQueries;
    }
}