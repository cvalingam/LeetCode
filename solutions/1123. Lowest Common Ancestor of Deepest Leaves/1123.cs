// Approach: Post-order DFS returning (lca, depth); when left and right depths are equal the current node is the LCA of the deepest leaves.
// Time: O(n) Space: O(n)

public class TreeNode(TreeNode root)
    {
        return Dfs(root).Lca;
    }

    private record T(TreeNode Lca, int Depth);

    private T Dfs(TreeNode root)
    {
        if (root == null)
            return new T(null, 0);

        T left = Dfs(root.left);
        T right = Dfs(root.right);

        if (left.Depth > right.Depth)
            return new T(left.Lca, left.Depth + 1);

        if (left.Depth < right.Depth)
            return new T(right.Lca, right.Depth + 1);

        return new T(root, left.Depth + 1);
    }
}