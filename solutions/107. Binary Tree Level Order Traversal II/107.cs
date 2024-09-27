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
    public IList<IList<int>> LevelOrderBottom(TreeNode root)
    {
        if (root == null)
            return new List<IList<int>>();

        List<IList<int>> ans = new List<IList<int>>();
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            IList<int> currLevel = new List<int>();
            int sz = q.Count;
            for (int i = 0; i < sz; i++)
            {
                TreeNode node = q.Dequeue();
                currLevel.Add(node.val);
                if (node.left != null)
                    q.Enqueue(node.left);
                if (node.right != null)
                    q.Enqueue(node.right);
            }
            ans.Add(currLevel);
        }

        ans.Reverse();
        return ans;
    }
}