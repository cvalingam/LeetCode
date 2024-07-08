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
    public int CountNodes(TreeNode root)
    {
        //return PreOrderCount(root);
        //return PostOrderCount(root);
        return InOrderCount(root);
    }

    private int PreOrderCount(TreeNode root)
    {
        if (root == null)
            return 0;

        int ans = 0;
        ans += 1;
        ans += PreOrderCount(root.left);
        ans += PreOrderCount(root.right);
        return ans;
    }

    private int PostOrderCount(TreeNode root)
    {
        if (root == null)
            return 0;

        int ans = 0;
        ans += PostOrderCount(root.left);
        ans += PostOrderCount(root.right);
        ans += 1;
        return ans;
    }

    private int InOrderCount(TreeNode root)
    {
        if (root == null)
            return 0;

        int ans = 0;
        ans += InOrderCount(root.left);
        ans += 1;
        ans += InOrderCount(root.right);
        return ans;
    }
}