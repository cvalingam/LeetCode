public class Solution
{
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        DisjointSet ds = new DisjointSet(n);

        foreach (int[] edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            ds.unionBySize(u, v);
        }

        return ds.findUPar(source) == ds.findUPar(destination);
    }
}

class DisjointSet
{
    List<int> parent = new List<int>();
    List<int> size = new List<int>();

    public DisjointSet(int n)
    {
        for (int i = 0; i < n; i++)
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