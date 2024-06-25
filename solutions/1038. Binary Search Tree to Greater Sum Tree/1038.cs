public class Solution
{
    int prefix = 0;
    public TreeNode BstToGst(TreeNode root)
    {
        if (root.right != null)
            BstToGst(root.right);

        prefix += root.val;
        root.val = prefix;

        if (root.left != null)
            BstToGst(root.left);

        return root;
    }
}