// Approach: Recursively compare both trees node by node. If both nodes are null
// the subtrees are identical at this point. If only one is null, or their values
// differ, return false. Otherwise check left and right subtrees recursively.
// Time: O(n) Space: O(h)

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
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p == null || q == null)
            return (p == q);

        return (p.val == q.val) && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}