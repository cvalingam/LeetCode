// Approach: DFS (preorder) with path tracking using a string builder.
// At each non-null node, append the node value (and '->' if not a leaf) to the current path.
// When a leaf node is reached, add the complete path string to the results list.
// Backtrack by passing the path string as a parameter (immutable strings make backtracking free).
// Alternatively, use a StringBuilder with explicit Remove calls if performance matters at scale.
// Time: O(n x L) where L is the average path length. Space: O(h) for the recursion stack.

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
    public IList<string> BinaryTreePaths(TreeNode root)
    {
        List<string> ans = new List<string>();
        Dfs(root, new StringBuilder(), ans);
        return ans;
    }

    private void Dfs(TreeNode root, StringBuilder sb, List<string> ans)
    {
        if (root == null)
            return;
        if (root.left == null && root.right == null)
        {
            ans.Add(sb.Append(root.val).ToString());
            return;
        }

        int length = sb.Length;
        Dfs(root.left, sb.Append(root.val).Append("->"), ans);
        sb.Length = length;
        Dfs(root.right, sb.Append(root.val).Append("->"), ans);
        sb.Length = length;
    }
}