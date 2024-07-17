public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
    {
        var ans = new List<TreeNode>();
        var set = new HashSet<int>(to_delete);
        DFS(root, set, true, ans);
        return ans;
    }

    private TreeNode DFS(TreeNode root, HashSet<int> set, bool isRoot, List<TreeNode> ans)
    {
        if (root == null)
            return null;

        bool deleted = set.Contains(root.val);
        if (isRoot && !deleted)
            ans.Add(root);

        root.left = DFS(root.left, set, deleted, ans);
        root.right = DFS(root.right, set, deleted, ans);
        return deleted ? null : root;
    }
}