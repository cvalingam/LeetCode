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
    public bool EvaluateTree(TreeNode root)
    {
        return EvaluateBoolean(root);
    }

    private bool EvaluateBoolean(TreeNode root)
    {
        if (root.val < 2)
            return root.val == 1 ? true : false;

        if (root.val == 2)
            return EvaluateBoolean(root.left) | EvaluateBoolean(root.right);

        return EvaluateBoolean(root.left) & EvaluateBoolean(root.right);
    }
}