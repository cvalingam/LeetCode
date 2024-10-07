public class Solution
{
    public int MinimumScore(int[] nums, int[][] edges)
    {
        int n = nums.Length;
        int xors = GetXors(nums);
        int[] subXors = (int[])nums.Clone();
        List<int>[] tree = new List<int>[n];
        HashSet<int>[] children = new HashSet<int>[n];

        for (int i = 0; i < n; ++i)
            tree[i] = new List<int>();

        for (int i = 0; i < n; ++i)
            children[i] = new HashSet<int>(new[] { i });

        foreach (int[] edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            tree[u].Add(v);
            tree[v].Add(u);
        }

        Dfs(tree, 0, -1, subXors, children);

        int ans = int.MaxValue;

        for (int i = 0; i < edges.Length; ++i)
        {
            int a = edges[i][0];
            int b = edges[i][1];
            if (children[a].Contains(b))
            {
                int temp = a;
                a = b;
                b = temp;
            }
            for (int j = 0; j < i; ++j)
            {
                int c = edges[j][0];
                int d = edges[j][1];
                if (children[c].Contains(d))
                {
                    int temp = c;
                    c = d;
                    d = temp;
                }
                int[] cands;
                if (a != c && children[a].Contains(c))
                    cands = new int[] { subXors[c], subXors[a] ^ subXors[c], xors ^ subXors[a] };
                else if (a != c && children[c].Contains(a))
                    cands = new int[] { subXors[a], subXors[c] ^ subXors[a], xors ^ subXors[c] };
                else
                    cands = new int[] { subXors[a], subXors[c], xors ^ subXors[a] ^ subXors[c] };
                ans = Math.Min(ans, cands.Max() - cands.Min());
            }
        }

        return ans;
    }

    private (int, HashSet<int>) Dfs(List<int>[] tree, int u, int prev, int[] subXors, HashSet<int>[] children)
    {
        for (int v = 0; v < tree[u].Count; v++)
        {
            if (tree[u][v] == prev)
                continue;
            var pair = Dfs(tree, tree[u][v], u, subXors, children);
            int vXor = pair.Item1;
            HashSet<int> vChildren = pair.Item2;
            subXors[u] ^= vXor;
            foreach (int child in vChildren)
                children[u].Add(child);
        }
        return (subXors[u], children[u]);
    }

    private int GetXors(int[] nums)
    {
        int xors = 0;
        foreach (int num in nums)
            xors ^= num;
        return xors;
    }
}