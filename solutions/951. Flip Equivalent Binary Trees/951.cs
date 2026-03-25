// Approach: Recursive equivalence check; two trees are flip-equivalent if they match directly or after swapping children at any node.
// Time: O(n) Space: O(n)

public class TreeNode(TreeNode root1, TreeNode root2)
    {
        if (root1 == null)
            return root2 == null;
        if (root2 == null)
            return root1 == null;
        if (root1.val != root2.val)
            return false;
        return //
            FlipEquiv(root1.left, root2.left) && FlipEquiv(root1.right, root2.right) ||
            FlipEquiv(root1.left, root2.right) && FlipEquiv(root1.right, root2.left);
    }
}