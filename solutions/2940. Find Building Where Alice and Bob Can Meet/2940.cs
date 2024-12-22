public class Solution
{
    public int[] LeftmostBuildingQueries(int[] heights, int[][] queries)
    {
        IndexedQuery[] indexedQueries = GetIndexedQueries(queries);
        int[] ans = new int[queries.Length];
        Array.Fill(ans, -1);
        // Store indices (heightsIndex) of heights with heights[heightsIndex] in
        // descending order.
        List<int> stack = new List<int>();

        // Iterate through queries and heights simultaneously.
        int heightsIndex = heights.Length - 1;
        foreach (IndexedQuery indexedQuery in indexedQueries)
        {
            int queryIndex = indexedQuery.QueryIndex;
            int a = indexedQuery.A;
            int b = indexedQuery.B;
            if (a == b || heights[a] < heights[b])
            {
                // 1. Alice and Bob are already in the same index (a == b) or
                // 2. Alice can jump from a -> b (heights[a] < heights[b]).
                ans[queryIndex] = b;
            }
            else
            {
                // Now, a < b and heights[a] >= heights[b].
                // Gradually add heights with an index > b to the monotonic stack.
                while (heightsIndex > b)
                {
                    // heights[heightsIndex] is a better candidate, given that
                    // heightsIndex is smaller than the indices in the stack and
                    // heights[heightsIndex] is larger or equal to the heights mapped in
                    // the stack.
                    while (stack.Count > 0 && heights[stack[stack.Count - 1]] <= heights[heightsIndex])
                        stack.RemoveAt(stack.Count - 1);
                    stack.Add(heightsIndex--);
                }
                // Binary search to find the smallest index j such that j > b and
                // heights[j] > heights[a], thereby ensuring heights[t] > heights[b].
                int j = LastGreater(stack, a, heights);
                if (j != -1)
                    ans[queryIndex] = stack[j];
            }
        }

        return ans;
    }

    private record IndexedQuery(int QueryIndex, int A, int B);

    // Returns the last index i in A s.t. heights[A[i]] is > heights[target].
    private int LastGreater(List<int> A, int target, int[] heights)
    {
        int l = -1;
        int r = A.Count - 1;
        while (l < r)
        {
            int m = (l + r + 1) / 2;
            if (heights[A[m]] > heights[target])
                l = m;
            else
                r = m - 1;
        }
        return l;
    }

    private IndexedQuery[] GetIndexedQueries(int[][] queries)
    {
        IndexedQuery[] indexedQueries = new IndexedQuery[queries.Length];
        for (int i = 0; i < queries.Length; ++i)
        {
            // Make sure that a <= b.
            int a = Math.Min(queries[i][0], queries[i][1]);
            int b = Math.Max(queries[i][0], queries[i][1]);
            indexedQueries[i] = new IndexedQuery(i, a, b);
        }
        Array.Sort(indexedQueries, (a, b) => b.B.CompareTo(a.B));
        return indexedQueries;
    }
}