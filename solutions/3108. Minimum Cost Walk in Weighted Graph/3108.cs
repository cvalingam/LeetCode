public class Solution
{
    public int[] MinimumCost(int n, int[][] edges, int[][] query)
    {
        int[] ans = new int[query.Length];
        UnionFind uf = new UnionFind(n);

        foreach (var edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            int w = edge[2];
            uf.UnionByRank(u, v, w);
        }

        for (int i = 0; i < query.Length; ++i)
        {
            int u = query[i][0];
            int v = query[i][1];
            ans[i] = uf.GetMinCost(u, v);
        }

        return ans;
    }
}

public class UnionFind
{
    private int[] id;
    private int[] rank;
    private int[] weight;

    public UnionFind(int n)
    {
        id = new int[n];
        rank = new int[n];
        weight = new int[n];
        for (int i = 0; i < n; ++i)
            id[i] = i;
        // 2^17 - 1 is the minimum number in the form 2^x - 1 > 10^5.
        Array.Fill(weight, (1 << 17) - 1);
    }

    public void UnionByRank(int u, int v, int w)
    {
        int i = Find(u);
        int j = Find(v);
        int newWeight = weight[i] & weight[j] & w;
        weight[i] = newWeight;
        weight[j] = newWeight;

        if (i == j)
            return;

        if (rank[i] < rank[j])
            id[i] = j;
        else if (rank[i] > rank[j])
            id[j] = i;
        else
        {
            id[i] = j;
            ++rank[j];
        }
    }

    public int GetMinCost(int u, int v)
    {
        if (u == v)
            return 0;

        int i = Find(u);
        int j = Find(v);

        return i == j ? weight[i] : -1;
    }

    private int Find(int u)
    {
        return id[u] == u ? u : (id[u] = Find(id[u]));
    }
}