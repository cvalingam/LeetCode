public class Solution
{
    public int CountPaths(int n, int[][] roads)
    {
        List<List<int[]>> adj = new List<List<int[]>>();

        for (int i = 0; i < n; i++)
            adj.Add(new List<int[]>());

        for (int i = 0; i < roads.Length; i++)
        {
            adj[roads[i][0]].Add(new int[] { roads[i][1], roads[i][2] });
            adj[roads[i][1]].Add(new int[] { roads[i][0], roads[i][2] });
        }

        PriorityQueue<long[], long[]> q = new PriorityQueue<long[], long[]>(Comparer<long[]>.Create((x, y) => (int)(x[0] - y[0])));
        long[] initialArr = new long[] { 0, 0 };
        q.Enqueue(initialArr, initialArr);

        long[] dist = new long[n];
        long[] ways = new long[n];
        Array.Fill(dist, long.MaxValue);
        Array.Fill(ways, 0);
        dist[0] = 0;
        ways[0] = 1;
        int mod = (int)(1e9 + 7);

        while (q.Count > 0)
        {
            long[] it = q.Dequeue();
            long cost = it[0];
            int node = (int)it[1];

            foreach (int[] iter in adj[node])
            {
                int adjNode = iter[0];
                int edW = iter[1];

                if (cost + edW < dist[adjNode])
                {
                    dist[adjNode] = cost + edW;
                    long[] arr = new long[] { dist[adjNode], adjNode };
                    q.Enqueue(arr, arr);
                    ways[adjNode] = ways[node];
                }
                else if (cost + edW == dist[adjNode])
                    ways[adjNode] = (ways[adjNode] + ways[node]) % mod;
            }
        }

        return (int)(ways[n - 1] % mod);
    }
}