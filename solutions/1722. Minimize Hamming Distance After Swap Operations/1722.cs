public class Solution
{
    public int MinimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps)
    {
        int n = source.Length;
        int ans = 0;
        UnionFind uf = new UnionFind(n);
        Dictionary<int, int>[] groupIdToCount = new Dictionary<int, int>[n];

        for (int i = 0; i < n; ++i)
            groupIdToCount[i] = new Dictionary<int, int>();

        foreach (var allowedSwap in allowedSwaps)
        {
            int a = allowedSwap[0];
            int b = allowedSwap[1];
            uf.UnionByRank(a, b);
        }

        for (int i = 0; i < n; ++i)
        {
            int groupId = uf.Find(i);
            if (!groupIdToCount[groupId].ContainsKey(source[i]))
                groupIdToCount[groupId][source[i]] = 0;
            groupIdToCount[groupId][source[i]]++;
        }

        for (int i = 0; i < n; ++i)
        {
            int groupId = uf.Find(i);
            var count = groupIdToCount[groupId];
            if (!count.ContainsKey(target[i]))
                ans++;
            else
            {
                count[target[i]]--;
                if (count[target[i]] == 0)
                    count.Remove(target[i]);
            }
        }

        return ans;
    }
}

class UnionFind
{
    private int[] id;
    private int[] rank;

    public UnionFind(int n)
    {
        id = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; ++i)
            id[i] = i;
    }

    public void UnionByRank(int u, int v)
    {
        int i = Find(u);
        int j = Find(v);
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

    public int Find(int u)
    {
        if (id[u] == u) 
            return u;
        return id[u] = Find(id[u]);
    }
}