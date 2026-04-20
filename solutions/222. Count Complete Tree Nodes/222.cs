// Approach: Exploit the complete binary tree property to count faster than O(n).
// Compute left-height (leftmost path) hl and right-height (rightmost path) hr.
// If hl == hr, the left subtree is a perfect binary tree with 2^hl - 1 nodes; recurse only on the right.
// If hl != hr, the right subtree is perfect with 2^hr - 1 nodes; recurse only on the left.
// Each recursive call eliminates exactly half the tree, giving O(log n) levels of recursion.
// Each level computes two heights in O(log n) time, so the total is O(log^2 n).
// Time: O(log^2 n) Space: O(log n) for the recursion stack.

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