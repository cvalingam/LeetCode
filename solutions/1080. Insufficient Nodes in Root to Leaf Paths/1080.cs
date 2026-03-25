// Approach: Post-order DFS; prune a child subtree if its max root-to-leaf sum is below limit; prune the root itself if both children are pruned at a leaf.
// Time: O(n) Space: O(n)

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
    public TreeNode SufficientSubset(TreeNode root, int limit)
    {
        if (root == null)
            return null;

        if (root.left == null && root.right == null)
            return root.val < limit ? null : root;

        root.left = SufficientSubset(root.left, limit - root.val);
        root.right = SufficientSubset(root.right, limit - root.val);

        return root.left == null && root.right == null ? null : root;
    }
}