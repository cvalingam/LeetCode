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
    public TreeNode LcaDeepestLeaves(TreeNode root)
    {
        return Dfs(root).Lca;
    }

    private record T(TreeNode Lca, int Depth);

    private T Dfs(TreeNode root)
    {
        if (root == null)
            return new T(null, 0);

        T left = Dfs(root.left);
        T right = Dfs(root.right);

        if (left.Depth > right.Depth)
            return new T(left.Lca, left.Depth + 1);

        if (left.Depth < right.Depth)
            return new T(right.Lca, right.Depth + 1);

        return new T(root, left.Depth + 1);
    }
}