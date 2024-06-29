public class Solution
{
    public int MakeConnected(int n, int[][] connections)
    {
        DisjointSet ds = new DisjointSet(n);
        int cntExtras = 0;

        foreach (int[] connection in connections)
        {
            int u = connection[0];
            int v = connection[1];
            if (ds.findUPar(u) == ds.findUPar(v))
                cntExtras++;
            else
                ds.unionBySize(u, v);
        }

        int cntC = 0;
        for (int i = 0; i < n; i++)
        {
            if (ds.parent[i] == i)
                cntC++;
        }

        int ans = cntC - 1;
        if (cntExtras >= ans)
            return ans;

        return -1;
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