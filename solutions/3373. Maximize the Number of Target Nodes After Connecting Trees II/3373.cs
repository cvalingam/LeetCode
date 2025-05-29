public class Solution
{
    public int[] MaxTargetNodes(int[][] edges1, int[][] edges2)
    {
        int n = edges1.Length + 1;
        int m = edges2.Length + 1;
        List<int>[] graph1 = BuildGraph(edges1, n);
        List<int>[] graph2 = BuildGraph(edges2, m);
        bool[] parity1 = new bool[n];
        bool[] parity2 = new bool[m]; // Placeholder (not used)
        int even1 = Dfs(graph1, 0, -1, parity1, true);
        int even2 = Dfs(graph2, 0, -1, parity2, true);
        int odd1 = n - even1;
        int odd2 = m - even2;
        int[] ans = new int[n];

        for (int i = 0; i < n; i++)
        {
            int tree1 = parity1[i] ? even1 : odd1;
            // Can connect the current node in tree1 to either an even or an odd node
            // in tree2.
            int tree2 = Math.Max(even2, odd2);
            ans[i] = tree1 + tree2;
        }

        return ans;
    }

    // Returns the number of nodes that can be reached from u with even steps.
    private int Dfs(List<int>[] graph, int u, int prev, bool[] parity, bool isEven)
    {
        int res = isEven ? 1 : 0;
        parity[u] = isEven;
        foreach (int v in graph[u])
        {
            if (v != prev)
                res += Dfs(graph, v, u, parity, !isEven);
        }
        return res;
    }

    private List<int>[] BuildGraph(int[][] edges, int n)
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
        
        return graph;
    }
}