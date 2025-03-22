public class Solution
{
    public int CountCompleteComponents(int n, int[][] edges)
    {
        var adjList = new List<List<int>>();

        for (int i = 0; i < n; i++)
            adjList.Add(new List<int>());

        foreach (int[] edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            adjList[u].Add(v);
            adjList[v].Add(u);
        }

        int[] vis = new int[n];
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            if (vis[i] == 0)
            {
                var temp = new List<int>();
                int e = 0;
                DFS(i, adjList, vis, temp, ref e);
                int v = temp.Count;

                if (v * (v - 1) == e)
                    ans++;
            }
        }

        return ans;
    }

    private void DFS(int node, List<List<int>> adjList, int[] vis, List<int> temp, ref int edges)
    {
        vis[node] = 1;
        edges += adjList[node].Count;
        temp.Add(node);

        foreach (int adjNode in adjList[node])
        {
            if (vis[adjNode] == 0)
                DFS(adjNode, adjList, vis, temp, ref edges);
        }
    }
}