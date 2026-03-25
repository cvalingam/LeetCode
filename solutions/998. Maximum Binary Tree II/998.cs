// Approach: If val is larger than root insert as new root with old root as left child; otherwise recurse right to find insertion point.
// Time: O(n) Space: O(n)

public class TreeNode(TreeNode root, int val)
    {
        if (root == null)
            return new TreeNode(val);
        if (root.val < val)
            return new TreeNode(val, root, null);
        root.right = InsertIntoMaxTree(root.right, val);
        return root;
    }
}