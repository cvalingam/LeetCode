public class Solution
{
    public int MagnificentSets(int n, int[][] edges)
    {
        var graph = new List<List<int>>();

        for (int i = 0; i < n; i++)
            graph.Add(new List<int>());

        var ds = new DisjointSet(n);

        var rootToGroupSize = new Dictionary<int, int>();

        foreach (var edge in edges)
        {
            int u = edge[0] - 1;
            int v = edge[1] - 1;
            graph[u].Add(v);
            graph[v].Add(u);
            ds.unionBySize(u, v);
        }

        for (int i = 0; i < n; i++)
        {
            int newGroupSize = Bfs(graph, i);
            if (newGroupSize == -1)
                return -1;

            int root = ds.findUPar(i);
            if (!rootToGroupSize.ContainsKey(root))
                rootToGroupSize[root] = 0;

            rootToGroupSize[root] = Math.Max(rootToGroupSize[root], newGroupSize);
        }

        int ans = 0;
        foreach (var groupSize in rootToGroupSize.Values)
            ans += groupSize;

        return ans;
    }

    private int Bfs(List<List<int>> graph, int u)
    {
        int step = 0;
        var q = new Queue<int>();
        q.Enqueue(u);
        var nodeToStep = new Dictionary<int, int> { { u, 1 } };

        while (q.Count > 0)
        {
            step++;
            int sz = q.Count;
            for (int i = 0; i < sz; i++)
            {
                int current = q.Dequeue();
                foreach (int v in graph[current])
                {
                    if (!nodeToStep.ContainsKey(v))
                    {
                        q.Enqueue(v);
                        nodeToStep[v] = step + 1;
                    }
                    else if (nodeToStep[v] == step)
                        // There is an odd number of edges in the cycle.
                        return -1;
                }
            }
        }

        return step;
    }
}

class DisjointSet
{
    public List<int> parent = new List<int>();
    public List<int> size = new List<int>();
    public DisjointSet(int n)
    {
        for (int i = 0; i <= n; i++)
        {
            parent.Add(i);
            size.Add(1);
        }
    }

    public int findUPar(int node)
    {
        if (node == parent[node])
            return node;

        return parent[node] = findUPar(parent[node]);
    }

    public void unionBySize(int u, int v)
    {
        int ulp_u = findUPar(u);
        int ulp_v = findUPar(v);

        if (ulp_u == ulp_v)
            return;

        if (size[ulp_u] < size[ulp_v])
        {
            parent[ulp_u] = ulp_v;
            size[ulp_v] += size[ulp_u];
        }
        else
        {
            parent[ulp_v] = ulp_u;
            size[ulp_u] += size[ulp_v];
        }
    }
}