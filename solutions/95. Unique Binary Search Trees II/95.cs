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
    public IList<TreeNode> GenerateTrees(int n)
    {
        if (n == 0)
            return new List<TreeNode>();
        return GenerateTrees(1, n);
    }

    private IList<TreeNode> GenerateTrees(int mn, int mx)
    {
        if (mn > mx)
            return new List<TreeNode> { null };

        IList<TreeNode> ans = new List<TreeNode>();

        for (int i = mn; i <= mx; ++i)
            foreach (TreeNode left in GenerateTrees(mn, i - 1))
                foreach (TreeNode right in GenerateTrees(i + 1, mx))
                {
                    TreeNode node = new TreeNode(i);
                    node.left = left;
                    node.right = right;
                    ans.Add(node);
                }

        return ans;
    }
}