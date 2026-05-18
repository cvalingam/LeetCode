// Approach: BFS where from index i you can reach i±1 or any index with arr[i]==arr[j].
// Build a graph: value -> list of indices with that value.
// Clear each value's list after processing to avoid redundant edge checks.
// Time: O(n) Space: O(n)

public class Solution
{
    public int MinJumps(int[] arr)
    {
        int n = arr.Length;
        // {a: indices}
        var graph = new Dictionary<int, List<int>>();
        var q = new Queue<int>();
        q.Enqueue(0);
        var seen = new bool[n];
        seen[0] = true;

        for (int i = 0; i < n; ++i)
        {
            if (!graph.ContainsKey(arr[i]))
                graph[arr[i]] = new List<int>();

            graph[arr[i]].Add(i);
        }

        for (int step = 0; q.Count > 0; ++step)
        {
            int sz = q.Count;
            for (; sz > 0; --sz)
            {
                int i = q.Dequeue();
                if (i == n - 1)
                    return step;
                seen[i] = true;
                int u = arr[i];
                if (i + 1 < n)
                    graph[u].Add(i + 1);
                if (i - 1 >= 0)
                    graph[u].Add(i - 1);
                foreach (int v in graph[u])
                {
                    if (seen[v])
                        continue;
                    q.Enqueue(v);
                }
                graph[u].Clear();
            }
        }

        throw new ArgumentException();
    }
}