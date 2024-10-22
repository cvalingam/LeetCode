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
    public long KthLargestLevelSum(TreeNode root, int k)
    {
        List<long> levelSums = new List<long>();
        Dfs(root, 0, levelSums);
        if (levelSums.Count < k)
            return -1;

        levelSums.Sort((a, b) => b.CompareTo(a));
        return levelSums[k - 1];
    }

    private void Dfs(TreeNode root, int level, List<long> levelSums)
    {
        if (root == null)
            return;
        if (levelSums.Count == level)
            levelSums.Add(0);
        levelSums[level] += root.val;
        Dfs(root.left, level + 1, levelSums);
        Dfs(root.right, level + 1, levelSums);
    }
}