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

public class FindElements
{
    private HashSet<int> vals = new HashSet<int>();

    public FindElements(TreeNode root)
    {
        Dfs(root, 0);
    }

    public bool Find(int target)
    {
        return vals.Contains(target);
    }

    private void Dfs(TreeNode root, int val)
    {
        if (root == null)
            return;

        root.val = val;
        vals.Add(val);
        Dfs(root.left, val * 2 + 1);
        Dfs(root.right, val * 2 + 2);
    }
}