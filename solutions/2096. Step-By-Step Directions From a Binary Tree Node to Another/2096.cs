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
    private string pathToStart = "";
    private string pathToDest = "";
    public string GetDirections(TreeNode root, int startValue, int destValue)
    {
        TreeNode lcaNode = LCA(root, startValue, destValue);
        DFS(lcaNode, startValue, destValue, new StringBuilder());
        return new string('U', pathToStart.Length) + pathToDest;
    }

    private TreeNode LCA(TreeNode root, int p, int q)
    {
        if (root == null || root.val == p || root.val == q)
            return root;
        TreeNode left = LCA(root.left, p, q);
        TreeNode right = LCA(root.right, p, q);
        if (left != null && right != null)
            return root;
        return left == null ? right : left;
    }

    private void DFS(TreeNode root, int p, int q, StringBuilder path)
    {
        if (root == null)
            return;
        if (root.val == p)
            pathToStart = path.ToString();
        if (root.val == q)
            pathToDest = path.ToString();
        DFS(root.left, p, q, path.Append('L'));
        path.Remove(path.Length - 1, 1);
        DFS(root.right, p, q, path.Append('R'));
        path.Remove(path.Length - 1, 1);
    }
}