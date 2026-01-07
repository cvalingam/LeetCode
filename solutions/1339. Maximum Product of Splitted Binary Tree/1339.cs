
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
    public int MaxProduct(TreeNode root)
    {
        const int MOD = 1000000007;
        long ans = 0;
        List<int> allSums = new List<int>();
        long totalSum = TreeSum(root, allSums);

        foreach (long sum in allSums)
            ans = Math.Max(ans, sum * (totalSum - sum));

        return (int)(ans % MOD);
    }

    private int TreeSum(TreeNode root, List<int> allSums)
    {
        if (root == null)
            return 0;

        int leftSum = TreeSum(root.left, allSums);
        int rightSum = TreeSum(root.right, allSums);
        int sum = root.val + leftSum + rightSum;

        allSums.Add(sum);
        return sum;
    }
}