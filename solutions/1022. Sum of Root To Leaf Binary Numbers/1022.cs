// Approach: DFS accumulating the binary number from root to leaf; add the leaf value to the running sum.
// Time: O(n) Space: O(n)

public class TreeNode(TreeNode root)
    {
        DFS(root, 0);
        return ans;
    }

    private int ans = 0;

    private void DFS(TreeNode root, int val)
    {
        if (root == null)
            return;

        val = val * 2 + root.val;
        if (root.left == null && root.right == null)
            ans += val;

        DFS(root.left, val);
        DFS(root.right, val);
    }
}