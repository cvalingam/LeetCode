public class Solution
{
    public int[] ShortestDistanceAfterQueries(int n, int[][] queries)
    {
        int[] ans = new int[queries.Length];
        int[] dist = new int[n];
        List<int>[] graph = new List<int>[n];

        for (int i = 0; i < n; ++i)
        {
            dist[i] = i;
            graph[i] = new List<int>();
        }

        for (int i = 0; i < n - 1; ++i)
            graph[i].Add(i + 1);

        for (int i = 0; i < queries.Length; ++i)
        {
            int u = queries[i][0];
            int v = queries[i][1];
            graph[u].Add(v);
            if (dist[u] + 1 < dist[v])
            {
                dist[v] = dist[u] + 1;
                Bfs(graph, v, dist);
            }
            ans[i] = dist[n - 1];
        }

        return ans;
    }

    private void Bfs(List<int>[] graph, int start, int[] dist)
    {
        Queue<int> q = new Queue<int>();
        q.Enqueue(start);
        while (q.Count > 0)
        {
            int u = q.Dequeue();
            foreach (int v in graph[u])
            {
                if (dist[u] + 1 < dist[v])
                {
                    dist[v] = dist[u] + 1;
                    q.Enqueue(v);
                }
            }
        }
    }
}