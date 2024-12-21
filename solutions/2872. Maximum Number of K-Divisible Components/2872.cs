public class Solution
{
    public int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k)
    {
        List<int>[] graph = new List<int>[n];

        for (int i = 0; i < n; i++)
            graph[i] = new List<int>();

        foreach (int[] edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            graph[u].Add(v);
            graph[v].Add(u);
        }

        Dfs(graph, 0, -1, values, k);
        return ans;
    }

    private int ans = 0;

    private long Dfs(List<int>[] graph, int u, int prev, int[] values, int k)
    {
        long treeSum = values[u];

        foreach (int v in graph[u])
        {
            if (v != prev)
                treeSum += Dfs(graph, v, u, values, k);
        }

        if (treeSum % k == 0)
            ++ans;
            
        return treeSum;
    }
}