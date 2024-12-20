
//Definition for a binary tree node.
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
    public TreeNode ReverseOddLevels(TreeNode root)
    {
        Dfs(root.left, root.right, true);
        return root;
    }

    private void Dfs(TreeNode left, TreeNode right, bool isOddLevel)
    {
        if (left == null)
            return;
        if (isOddLevel)
        {
            int val = left.val;
            left.val = right.val;
            right.val = val;
        }
        Dfs(left.left, right.right, !isOddLevel);
        Dfs(left.right, right.left, !isOddLevel);
    }
}