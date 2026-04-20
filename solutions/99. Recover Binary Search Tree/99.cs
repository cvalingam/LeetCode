// Approach: In a valid BST, inorder traversal produces a strictly increasing sequence.
// Exactly two nodes are swapped, causing at most two inversions (positions where prev > current).
// Track the 'previous' node visited during inorder traversal.
// At the first inversion: record previous as 'first' (misplaced larger node) and current as 'second'.
// At the second inversion (if it exists): update 'second' to the current node.
// After the full traversal, swap the values of 'first' and 'second' to fix the BST.
// Time: O(n) Space: O(h) for the recursion stack.

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
    private TreeNode first;
    private TreeNode prev;
    private TreeNode middle;
    private TreeNode last;
    public void RecoverTree(TreeNode root)
    {
        first = middle = last = null;
        prev = new TreeNode(Int32.MinValue);
        IOTRecoverTree(root);

        if (first != null && last != null)
        {
            int t = first.val;
            first.val = last.val;
            last.val = t;
        }
        else if (first != null && middle != null)
        {
            int t = first.val;
            first.val = middle.val;
            middle.val = t;
        }
    }

    private void IOTRecoverTree(TreeNode root)
    {
        if (root == null)
            return;

        IOTRecoverTree(root.left);

        if (prev != null && root.val < prev.val)
        {
            if (first == null)
            {
                first = prev;
                middle = root;
            }
            else
                last = root;
        }

        prev = root;
        IOTRecoverTree(root.right);
    }
}