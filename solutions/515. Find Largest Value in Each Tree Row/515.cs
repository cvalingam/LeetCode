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
    public IList<int> LargestValues(TreeNode root)
    {
        if (root == null)
            return new List<int>();

        List<int> ans = new List<int>();
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            int mx = int.MinValue;
            int sz = q.Count;
            for (int i = 0; i < sz; i++)
            {
                TreeNode node = q.Dequeue();
                mx = Math.Max(mx, node.val);
                if (node.left != null)
                    q.Enqueue(node.left);
                if (node.right != null)
                    q.Enqueue(node.right);
            }
            ans.Add(mx);
        }

        return ans;
    }
}