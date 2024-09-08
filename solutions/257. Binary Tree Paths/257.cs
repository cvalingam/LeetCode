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