// Approach: Post-order DFS returning (lca, depth); when both subtree depths are equal the current node is the LCA of the deepest leaves.
// Time: O(n) Space: O(n)

public class Solution
{
    public TreeNode SubtreeWithAllDeepest(TreeNode root)
    {
        return DFS(root).lca;
    }

    private T DFS(TreeNode root)
    {
        if (root == null)
            return new T(null, 0);

        T left = DFS(root.left);
        T right = DFS(root.right);
        if (left.depth > right.depth)
            return new T(left.lca, left.depth + 1);
        if (left.depth < right.depth)
            return new T(right.lca, right.depth + 1);
        return new T(root, left.depth + 1);
    }
}

public class T
{
    public TreeNode lca;
    public int depth;

    public T(TreeNode lca, int depth)
    {
        this.lca = lca;
        this.depth = depth;
    }
}