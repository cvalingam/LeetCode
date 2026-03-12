public class Solution
{
    int n;
    int[][] edges;
    int k;

    private bool Check(int lim)
    {
        UnionFind uf = new UnionFind(n);

        foreach (var e in edges)
        {
            int u = e[0], v = e[1], s = e[2];
            if (s >= lim)
                uf.Union(u, v);
        }

        int rem = k;
        foreach (var e in edges)
        {
            int u = e[0], v = e[1], s = e[2];
            if (s * 2 >= lim && rem > 0)
            {
                if (uf.Union(u, v))
                    rem--;
            }
        }

        return uf.cnt == 1;
    }

    public int MaxStability(int n, int[][] edges, int k)
    {
        this.n = n;
        this.edges = edges;
        this.k = k;

        UnionFind uf = new UnionFind(n);
        int mn = (int)1e6;

        foreach (var e in edges)
        {
            int u = e[0], v = e[1], s = e[2], must = e[3];
            if (must == 1)
            {
                mn = Math.Min(mn, s);
                if (!uf.Union(u, v))
                    return -1;
            }
        }

        foreach (var e in edges)
            uf.Union(e[0], e[1]);

        if (uf.cnt > 1)
            return -1;

        int l = 1, r = mn;
        while (l < r)
        {
            int mid = (l + r + 1) >> 1;
            if (Check(mid))
                l = mid;
            else
                r = mid - 1;
        }

        return l;
    }
}

class UnionFind
{
    int[] p, size;
    public int cnt;

    public UnionFind(int n)
    {
        p = new int[n];
        size = new int[n];
        cnt = n;
        for (int i = 0; i < n; i++)
        {
            p[i] = i;
            size[i] = 1;
        }
    }

    public int Find(int x)
    {
        if (p[x] != x)
            p[x] = Find(p[x]);
        return p[x];
    }

    public bool Union(int a, int b)
    {
        int pa = Find(a), pb = Find(b);
        if (pa == pb) return false;
        if (size[pa] > size[pb])
        {
            p[pb] = pa;
            size[pa] += size[pb];
        }
        else
        {
            p[pa] = pb;
            size[pb] += size[pa];
        }
        cnt--;
        return true;
    }
}