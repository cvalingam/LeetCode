
// Definition for a binary tree node.
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
    public TreeNode ReplaceValueInTree(TreeNode root)
    {
        var map = new Dictionary<int, int>();
        DFS(root, 0, map);
        DFS2(root, 0, 0, map);

        return root;
    }

    void DFS(TreeNode root, int level, Dictionary<int, int> map)
    {
        if (root == null)
            return;

        if (map.ContainsKey(level))
            map[level] += root.val;
        else
            map.Add(level, root.val);

        DFS(root.left, level + 1, map);
        DFS(root.right, level + 1, map);
    }

    void DFS2(TreeNode root, int sibling, int level, Dictionary<int, int> map)
    {
        if (root == null)
            return;

        root.val = map[level] - root.val - sibling;
        int lv = root.left != null ? root.left.val : 0;
        int rv = root.right != null ? root.right.val : 0;

        DFS2(root.left, rv, level + 1, map);
        DFS2(root.right, lv, level + 1, map);
    }
}