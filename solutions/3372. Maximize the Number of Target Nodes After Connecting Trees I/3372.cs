public class Solution
{
    public int[] MaxTargetNodes(int[][] edges1, int[][] edges2, int k)
    {
        int[] ans = new int[edges1.Length + 1];
        List<int>[] graph1 = BuildGraph(edges1);
        List<int>[] graph2 = BuildGraph(edges2);
        int maxReachableInGraph2 = 0;

        if (k > 0)
        {
            for (int i = 0; i < edges2.Length + 1; ++i)
                maxReachableInGraph2 = Math.Max(maxReachableInGraph2, Dfs(graph2, i, -1, k - 1));
        }

        for (int i = 0; i < edges1.Length + 1; ++i)
            ans[i] = maxReachableInGraph2 + Dfs(graph1, i, -1, k);

        return ans;
    }

    // Returns the number of nodes that can be reached from u with k steps.
    private int Dfs(List<int>[] graph, int u, int prev, int k)
    {
        if (k == 0)
            return 1;
            
        int res = 0;
        foreach (var v in graph[u])
        {
            if (v != prev)
                res += Dfs(graph, v, u, k - 1);
        }

        return 1 + res;
    }

    private List<int>[] BuildGraph(int[][] edges)
    {
        List<int>[] graph = new List<int>[edges.Length + 1];
        for (int i = 0; i < edges.Length + 1; ++i)
            graph[i] = new List<int>();

        foreach (var edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            graph[u].Add(v);
            graph[v].Add(u);
        }

        return graph;
    }
}