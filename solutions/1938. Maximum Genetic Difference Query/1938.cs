public class Solution
{
    public int[] MaxGeneticDifference(int[] parents, int[][] queries)
    {
        int n = parents.Length;
        int[] ans = new int[queries.Length];
        int rootVal = -1;
        List<int>[] tree = new List<int>[n];

        for (int i = 0; i < n; ++i)
            tree[i] = new List<int>();

        // {node: (index, val)}
        Dictionary<int, List<(int, int)>> nodeToQueries = new Dictionary<int, List<(int, int)>>();
        Trie trie = new Trie();

        for (int i = 0; i < parents.Length; ++i)
        {
            if (parents[i] == -1)
                rootVal = i;
            else
                tree[parents[i]].Add(i);
        }

        for (int i = 0; i < queries.Length; ++i)
        {
            int node = queries[i][0];
            int val = queries[i][1];
            if (!nodeToQueries.ContainsKey(node))
                nodeToQueries[node] = new List<(int, int)>();
            nodeToQueries[node].Add((i, val));
        }

        Dfs(rootVal, trie, tree, nodeToQueries, ans);
        return ans;
    }

    private void Dfs(int node, Trie trie, List<int>[] tree,
                     Dictionary<int, List<(int, int)>> nodeToQueries, int[] ans)
    {
        trie.Update(node, 1);

        if (nodeToQueries.ContainsKey(node))
            foreach (var query in nodeToQueries[node])
            {
                int i = query.Item1;
                int val = query.Item2;
                ans[i] = trie.Query(val);
            }

        foreach (int child in tree[node])
            Dfs(child, trie, tree, nodeToQueries, ans);

        trie.Update(node, -1);
    }
}

public class TrieNode
{
    public TrieNode[] children = new TrieNode[2];
    public int count = 0;
}

public class Trie
{
    private static readonly int kHeight = 17;
    private TrieNode root = new TrieNode();

    public void Update(int num, int val)
    {
        TrieNode node = root;
        for (int i = kHeight; i >= 0; --i)
        {
            int bit = (num >> i) & 1;
            if (node.children[bit] == null)
                node.children[bit] = new TrieNode();
            node = node.children[bit];
            node.count += val;
        }
    }

    public int Query(int num)
    {
        int ans = 0;
        TrieNode node = root;
        for (int i = kHeight; i >= 0; --i)
        {
            int bit = (num >> i) & 1;
            int targetBit = bit ^ 1;
            if (node.children[targetBit] != null && node.children[targetBit].count > 0)
            {
                ans += 1 << i;
                node = node.children[targetBit];
            }
            else
                node = node.children[targetBit ^ 1];
        }
        return ans;
    }
}