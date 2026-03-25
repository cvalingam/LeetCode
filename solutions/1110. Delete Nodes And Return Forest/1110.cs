// Approach: Post-order DFS; when deleting a node add its non-null children as new roots; return null upward when a node is deleted.
// Time: O(n) Space: O(n)

public class TreeNode(TreeNode root, int[] to_delete)
    {
        var ans = new List<TreeNode>();
        var set = new HashSet<int>(to_delete);
        DFS(root, set, true, ans);
        return ans;
    }

    private TreeNode DFS(TreeNode root, HashSet<int> set, bool isRoot, List<TreeNode> ans)
    {
        if (root == null)
            return null;

        bool deleted = set.Contains(root.val);
        if (isRoot && !deleted)
            ans.Add(root);

        root.left = DFS(root.left, set, deleted, ans);
        root.right = DFS(root.right, set, deleted, ans);
        return deleted ? null : root;
    }
}