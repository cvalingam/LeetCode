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
    public int SumRootToLeaf(TreeNode root)
    {
        DFS(root, 0);
        return ans;
    }

    private int ans = 0;

    private void DFS(TreeNode root, int val)
    {
        if (root == null)
            return;

        val = val * 2 + root.val;
        if (root.left == null && root.right == null)
            ans += val;

        DFS(root.left, val);
        DFS(root.right, val);
    }
}