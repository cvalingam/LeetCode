// Approach: DFS to recover tree values (root=0, left=2*v+1, right=2*v+2) into a HashSet; Find() is O(1) lookup.
// Time: O(n) build, O(1) find Space: O(n)

public class TreeNode
{
    private HashSet<int> vals = new HashSet<int>();

    public FindElements(TreeNode root)
    {
        Dfs(root, 0);
    }

    public bool Find(int target)
    {
        return vals.Contains(target);
    }

    private void Dfs(TreeNode root, int val)
    {
        if (root == null)
            return;

        root.val = val;
        vals.Add(val);
        Dfs(root.left, val * 2 + 1);
        Dfs(root.right, val * 2 + 2);
    }
}