public class Solution
{
    public int RemoveStones(int[][] stones)
    {
        int maxRow = 0;
        int maxCol = 0;
        int n = stones.Length;
        foreach (int[] stone in stones)
        {
            maxRow = Math.Max(maxRow, stone[0]);
            maxCol = Math.Max(maxCol, stone[1]);
        }

        DisjointSet ds = new DisjointSet(maxRow + maxCol + 1);
        Dictionary<int, int> map = new Dictionary<int, int>();
        foreach (int[] stone in stones)
        {
            int nodeRow = stone[0];
            int nodeCol = stone[1] + maxRow + 1;
            ds.unionBySize(nodeRow, nodeCol);
            map[nodeRow] = 1;
            map[nodeCol] = 1;
        }

        int cnt = 0;
        foreach (KeyValuePair<int, int> kvp in map)
        {
            if (ds.findUPar(kvp.Key) == kvp.Key)
                cnt++;
        }

        return n - cnt;
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