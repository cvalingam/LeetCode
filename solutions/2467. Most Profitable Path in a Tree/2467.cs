public class Solution
{
    public int MostProfitablePath(int[][] edges, int bob, int[] amount)
    {
        int n = amount.Length;
        List<int>[] tree = new List<int>[n];
        int[] parent = new int[n];
        int[] aliceDist = new int[n];
        Array.Fill(aliceDist, -1);

        for (int i = 0; i < n; ++i)
            tree[i] = new List<int>();

        foreach (int[] edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            tree[u].Add(v);
            tree[v].Add(u);
        }

        Dfs(tree, 0, -1, 0, parent, aliceDist);

        // Modify the amount along the path from node Bob to node 0.
        // For each node,
        //   1. If Bob reaches earlier than Alice does, change the amount to 0.
        //   2. If Bob and Alice reach simultaneously, divide the amount by 2.
        for (int u = bob, bobDist = 0; u != 0; u = parent[u], ++bobDist)
        {
            if (bobDist < aliceDist[u])
                amount[u] = 0;
            else if (bobDist == aliceDist[u])
                amount[u] /= 2;
        }

        return GetMoney(tree, 0, -1, amount);
    }

    // Fills `parent` and `dist`.
    private void Dfs(List<int>[] tree, int u, int prev, int d, int[] parent, int[] dist)
    {
        parent[u] = prev;
        dist[u] = d;
        foreach (int v in tree[u])
        {
            if (dist[v] == -1)
                Dfs(tree, v, u, d + 1, parent, dist);
        }
    }

    private int GetMoney(List<int>[] tree, int u, int prev, int[] amount)
    {
        // a leaf node
        if (tree[u].Count == 1 && tree[u][0] == prev)
            return amount[u];

        int maxPath = int.MinValue;
        foreach (int v in tree[u])
        {
            if (v != prev)
                maxPath = Math.Max(maxPath, GetMoney(tree, v, u, amount));
        }

        return amount[u] + maxPath;
    }
}