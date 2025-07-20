public class Solution
{
    public IList<IList<string>> DeleteDuplicateFolder(IList<IList<string>> paths)
    {
        List<List<string>> ans = new List<List<string>>();
        Dictionary<string, List<TrieNode>> subtreeToNodes = new Dictionary<string, List<TrieNode>>();

        var pathList = paths.Select(p => p.ToList()).ToList();
        pathList.Sort((a, b) =>
        {
            int cmp = a.Count.CompareTo(b.Count);
            if (cmp != 0)
                return cmp;
            for (int i = 0; i < Math.Min(a.Count, b.Count); ++i)
            {
                cmp = string.Compare(a[i], b[i]);
                if (cmp != 0)
                    return cmp;
            }
            return 0;
        });

        foreach (List<string> path in pathList)
        {
            TrieNode node = root;
            foreach (string s in path)
            {
                if (!node.children.ContainsKey(s))
                    node.children[s] = new TrieNode();
                node = node.children[s];
            }
        }

        BuildSubtreeToRoots(root, subtreeToNodes);

        foreach (List<TrieNode> nodes in subtreeToNodes.Values)
        {
            if (nodes.Count > 1)
            {
                foreach (TrieNode node in nodes)
                    node.deleted = true;
            }
        }

        ConstructPath(root, new List<string>(), ans);
        return ans.Cast<IList<string>>().ToList();
    }

    private TrieNode root = new TrieNode();

    private StringBuilder BuildSubtreeToRoots(TrieNode node, Dictionary<string, List<TrieNode>> subtreeToNodes)
    {
        StringBuilder sb = new StringBuilder("(");
        foreach (string s in node.children.Keys)
        {
            TrieNode child = node.children[s];
            sb.Append(s).Append(BuildSubtreeToRoots(child, subtreeToNodes));
        }

        sb.Append(")");
        string subtree = sb.ToString();
        if (subtree != "()")
        {
            if (!subtreeToNodes.ContainsKey(subtree))
                subtreeToNodes[subtree] = new List<TrieNode>();
            subtreeToNodes[subtree].Add(node);
        }
        return sb;
    }

    private void ConstructPath(TrieNode node, List<string> path, List<List<string>> ans)
    {
        foreach (string s in node.children.Keys)
        {
            TrieNode child = node.children[s];
            if (!child.deleted)
            {
                path.Add(s);
                ConstructPath(child, path, ans);
                path.RemoveAt(path.Count - 1);
            }
        }

        if (path.Count > 0)
            ans.Add(new List<string>(path));
    }
}

public class TrieNode
{
    public Dictionary<string, TrieNode> children = new Dictionary<string, TrieNode>();
    public bool deleted = false;
}