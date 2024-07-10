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
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        if (root == null)
            return false;

        if (root.val == targetSum && root.left == null && root.right == null)
            return true;

        bool left = HasPathSum(root.left, targetSum - root.val);
        bool right = HasPathSum(root.right, targetSum - root.val);

        return left || right;
    }
}