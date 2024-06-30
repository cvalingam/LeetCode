public class Solution
{
    public int MaxNumEdgesToRemove(int n, int[][] edges)
    {
        var alice = new DisjointSet(n);
        var bob = new DisjointSet(n);

        int removedEdges = 0, aliceEdges = 0, bobEdges = 0;
        Array.Sort(edges, (a, b) => b[0] - a[0]);

        foreach (int[] edge in edges)
        {
            int type = edge[0];
            int u = edge[1];
            int v = edge[2];

            if (type == 3)
            {
                if (alice.unionBySize(u, v))
                {
                    bob.unionBySize(u, v);
                    aliceEdges++;
                    bobEdges++;
                }
                else
                    removedEdges++;
            }
            else if (type == 2)
            {
                if (bob.unionBySize(u, v))
                    bobEdges++;
                else
                    removedEdges++;
            }
            else
            {
                if (alice.unionBySize(u, v))
                    aliceEdges++;
                else
                    removedEdges++;
            }
        }

        return (bobEdges == n - 1 && aliceEdges == n - 1) ? removedEdges : -1;
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

    public bool unionBySize(int u, int v)
    {
        int ulp_u = findUPar(u);
        int ulp_v = findUPar(v);

        if (ulp_u == ulp_v)
            return false;

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

        return true;
    }
}