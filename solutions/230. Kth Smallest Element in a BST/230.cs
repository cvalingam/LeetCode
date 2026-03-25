// Approach: Use the BST structure to count left-subtree nodes; decide whether
// the k-th smallest is in the left subtree, at the root, or in the right.
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
    public int KthSmallest(TreeNode root, int k)
    {
        int leftCount = CountNodes(root.left);

        if (leftCount == k - 1)
            return root.val;
        if (leftCount >= k)
            return KthSmallest(root.left, k);
        return KthSmallest(root.right, k - 1 - leftCount); // leftCount < k
    }

    private int CountNodes(TreeNode root)
    {
        if (root == null)
            return 0;
        return 1 + CountNodes(root.left) + CountNodes(root.right);
    }
}