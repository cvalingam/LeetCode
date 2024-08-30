public class Solution
{
    public int[][] ModifiedGraphEdges(int n, int[][] edges, int source, int destination, int target)
    {
        const int kMax = 2_000_000_000;
        List<int[]>[] graph = new List<int[]>[n];

        for (int i = 0; i < n; i++)
            graph[i] = new List<int[]>();

        foreach (int[] edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            int w = edge[2];
            if (w == -1)
                continue;
            graph[u].Add(new int[] { v, w });
            graph[v].Add(new int[] { u, w });
        }

        int distToDestination = Dijkstra(graph, source, destination);
        if (distToDestination < target)
            return new int[0][];
        if (distToDestination == target)
        {
            // Change the weights of negative edges to an impossible value.
            foreach (int[] edge in edges)
                if (edge[2] == -1)
                    edge[2] = kMax;
            return edges;
        }

        for (int i = 0; i < edges.Length; ++i)
        {
            int u = edges[i][0];
            int v = edges[i][1];
            int w = edges[i][2];
            if (w != -1)
                continue;
            edges[i][2] = 1;
            graph[u].Add(new int[] { v, 1 });
            graph[v].Add(new int[] { u, 1 });
            distToDestination = Dijkstra(graph, source, destination);
            if (distToDestination <= target)
            {
                edges[i][2] += target - distToDestination;
                // Change the weights of negative edges to an impossible value.
                for (int j = i + 1; j < edges.Length; ++j)
                {
                    if (edges[j][2] == -1)
                        edges[j][2] = kMax;
                }
                return edges;
            }
        }

        return new int[0][];
    }

    private int Dijkstra(List<int[]>[] graph, int src, int dst)
    {
        int[] dist = new int[graph.Length];
        Array.Fill(dist, int.MaxValue);
        // (d, u)
        SortedSet<int[]> minHeap = new SortedSet<int[]>(Comparer<int[]>.Create((a, b) =>
        {
            int cmp = a[0].CompareTo(b[0]);
            return cmp != 0 ? cmp : a[1].CompareTo(b[1]);
        }));

        dist[src] = 0;
        minHeap.Add(new int[] { dist[src], src });

        while (minHeap.Count > 0)
        {
            var min = minHeap.Min;
            int d = min[0];
            int u = min[1];
            minHeap.Remove(min);
            if (d > dist[u])
                continue;
            foreach (int[] pair in graph[u])
            {
                int v = pair[0];
                int w = pair[1];
                if (d + w < dist[v])
                {
                    dist[v] = d + w;
                    minHeap.Add(new int[] { dist[v], v });
                }
            }
        }

        return dist[dst];
    }
}

