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
    public int[] FindFrequentTreeSum(TreeNode root)
    {
        List<int> ans = new List<int>();
        Dictionary<int, int> count = new Dictionary<int, int>();
        int maxCount = 0;

        SumDownFrom(root, count);

        foreach (var freq in count.Values)
            maxCount = Math.Max(maxCount, freq);

        foreach (var sum in count.Keys)
        {
            if (count[sum] == maxCount)
                ans.Add(sum);
        }

        return ans.ToArray();
    }

    private int SumDownFrom(TreeNode root, Dictionary<int, int> count)
    {
        if (root == null)
            return 0;

        int sum = root.val + SumDownFrom(root.left, count) + SumDownFrom(root.right, count);

        if (count.ContainsKey(sum))
            count[sum]++;
        else
            count[sum] = 1;

        return sum;
    }
}