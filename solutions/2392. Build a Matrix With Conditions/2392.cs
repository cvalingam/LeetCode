public class Solution
{
    public int[][] BuildMatrix(int k, int[][] rowConditions, int[][] colConditions)
    {
        List<List<int>> rowGr = BuildGraph(k, rowConditions);
        List<List<int>> colGr = BuildGraph(k, colConditions);

        List<int> rowTopo = TopologicalOrder(k, rowGr);
        List<int> colTopo = TopologicalOrder(k, colGr);

        if (rowTopo.Count == 0 || colTopo.Count == 0)
            return new int[][] { };

        int[][] ans = new int[k][];
        for (int i = 0; i < k; i++)
        {
            ans[i] = new int[k];
        }

        int[] nodeToRowIndex = new int[k + 1];

        for (int i = 0; i < k; ++i)
            nodeToRowIndex[rowTopo[i]] = i;

        for (int j = 0; j < k; ++j)
        {
            int node = colTopo[j];
            int i = nodeToRowIndex[node];
            ans[i][j] = node;
        }

        return ans;

    }

    private List<int> TopologicalOrder(int k, List<List<int>> graph)
    {
        int[] inDegree = new int[k + 1];

        for (int node = 1; node <= k; node++)
        {
            foreach (int child in graph[node])
                inDegree[child]++;
        }

        var q = new Queue<int>();
        int[] vis = new int[k + 1];

        for (int node = 1; node <= k; node++)
        {
            if (inDegree[node] == 0)
                q.Enqueue(node);
        }

        var topoSort = new List<int>();
        while (q.Count > 0)
        {
            int sz = q.Count;
            while (sz-- > 0)
            {
                int node = q.Dequeue();
                vis[node] = 1;
                topoSort.Add(node);

                foreach (int child in graph[node])
                {
                    if (vis[child] == 0)
                    {
                        --inDegree[child];
                        if (inDegree[child] == 0)
                            q.Enqueue(child);
                    }
                }
            }
        }

        return topoSort.Count == k ? topoSort : new List<int>();
    }

    private List<List<int>> BuildGraph(int k, int[][] conditions)
    {
        List<List<int>> graph = new List<List<int>>();

        for (int i = 0; i < k + 1; i++)
            graph.Add(new List<int>());

        foreach (int[] cond in conditions)
        {
            int u = cond[0];
            int v = cond[1];
            graph[u].Add(v);
        }

        return graph;
    }
}