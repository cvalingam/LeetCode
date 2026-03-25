// Approach: DFS; return false if any node's value differs from its parent or if any child subtree is not univalued.
// Time: O(n) Space: O(n)

public class TreeNode(TreeNode root)
    {
        if (root == null)
            return true;
        if (root.left != null && root.left.val != root.val)
            return false;
        if (root.right != null && root.right.val != root.val)
            return false;
        return IsUnivalTree(root.left) && IsUnivalTree(root.right);
    }
}