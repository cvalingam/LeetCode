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
    public int[] TreeQueries(TreeNode root, int[] queries)
    {
        int[] ans = new int[queries.Length];

        Dfs(root, 0, 0);

        for (int i = 0; i < queries.Length; ++i)
            ans[i] = valToMaxHeight[queries[i]];

        return ans;
    }

    // valToMaxHeight[val] := the maximum height without the node with `val`
    private Dictionary<int, int> valToMaxHeight = new Dictionary<int, int>();
    // valToHeight[val] := the height of the node with `val`
    private Dictionary<int, int> valToHeight = new Dictionary<int, int>();

    private int Height(TreeNode root)
    {
        if (root == null)
            return 0;
        if (valToHeight.ContainsKey(root.val))
            return valToHeight[root.val];
        int h = 1 + Math.Max(Height(root.left), Height(root.right));
        valToHeight[root.val] = h;
        return h;
    }

    // maxHeight := the maximum height without the current node `root`
    private void Dfs(TreeNode root, int depth, int maxHeight)
    {
        if (root == null)
            return;
        valToMaxHeight[root.val] = maxHeight;
        Dfs(root.left, depth + 1, Math.Max(maxHeight, depth + Height(root.right)));
        Dfs(root.right, depth + 1, Math.Max(maxHeight, depth + Height(root.left)));
    }
}