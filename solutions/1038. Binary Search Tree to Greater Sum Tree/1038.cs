// Approach: Reverse in-order traversal (right → node → left); accumulate a running prefix sum and assign it to each node.
// Time: O(n) Space: O(n)

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