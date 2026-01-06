//Definition for a binary tree node.
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
    public int MaxLevelSum(TreeNode root)
    {
        int ans = 0;
        int maxLevelSum = int.MinValue;
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        for (int level = 1; q.Count > 0; ++level)
        {
            int levelSum = 0;
            int sz = q.Count;
            for (int i = 0; i < sz; i++)
            {
                TreeNode node = q.Dequeue();
                levelSum += node.val;
                if (node.left != null)
                    q.Enqueue(node.left);
                if (node.right != null)
                    q.Enqueue(node.right);
            }
            if (levelSum > maxLevelSum)
            {
                maxLevelSum = levelSum;
                ans = level;
            }
        }

        return ans;
    }
}