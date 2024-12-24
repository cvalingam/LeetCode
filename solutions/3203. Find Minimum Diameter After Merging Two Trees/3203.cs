public class Solution
{
    public int MinimumDiameterAfterMerge(int[][] edges1, int[][] edges2)
    {
        int diameter1 = GetDiameter(edges1);
        int diameter2 = GetDiameter(edges2);
        int combinedDiameter = (diameter1 + 1) / 2 + (diameter2 + 1) / 2 + 1;
        return Math.Max(Math.Max(diameter1, diameter2), combinedDiameter);
    }

    private int GetDiameter(int[][] edges)
    {
        int n = edges.Length + 1;
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

        int[] maxDiameter = new int[1];
        MaxDepth(graph, 0, -1, maxDiameter);
        return maxDiameter[0];
    }

    private int MaxDepth(List<int>[] graph, int u, int prev, int[] maxDiameter)
    {
        int maxSubDepth1 = 0;
        int maxSubDepth2 = 0;
        foreach (int v in graph[u])
        {
            if (v == prev)
                continue;
            int maxSubDepth = MaxDepth(graph, v, u, maxDiameter);
            if (maxSubDepth > maxSubDepth1)
            {
                maxSubDepth2 = maxSubDepth1;
                maxSubDepth1 = maxSubDepth;
            }
            else if (maxSubDepth > maxSubDepth2)
                maxSubDepth2 = maxSubDepth;
        }

        maxDiameter[0] = Math.Max(maxDiameter[0], maxSubDepth1 + maxSubDepth2);
        return 1 + maxSubDepth1;
    }
}