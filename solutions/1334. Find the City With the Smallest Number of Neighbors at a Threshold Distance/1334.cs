public class Solution
{
    public int FindTheCity(int n, int[][] edges, int distanceThreshold)
    {

        int[][] dist = new int[n][];

        for (int i = 0; i < n; i++)
        {
            int[] arr = new int[n];
            Array.Fill(arr, Int32.MaxValue);
            dist[i] = arr;
        }

        foreach (int[] edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            int wt = edge[2];
            dist[u][v] = wt;
            dist[v][u] = wt;
            dist[u][u] = 0;
            dist[v][v] = 0;
        }

        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (dist[i][k] != Int32.MaxValue && dist[k][j] != Int32.MaxValue)
                        dist[i][j] = Math.Min(dist[i][j], dist[i][k] + dist[k][j]);
                }
            }
        }

        int cntCity = n;
        int cityNo = -1;
        for (int city = 0; city < n; city++)
        {
            int cnt = 0;
            for (int adjCity = 0; adjCity < n; adjCity++)
            {
                if (dist[city][adjCity] <= distanceThreshold)
                    cnt++;
            }

            if (cnt <= cntCity)
            {
                cntCity = cnt;
                cityNo = city;
            }
        }

        return cityNo;
    }
}