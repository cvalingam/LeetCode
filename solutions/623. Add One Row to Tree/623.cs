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
    public TreeNode AddOneRow(TreeNode root, int val, int depth)
    {
        if (depth == 1)
        {
            TreeNode newNode = new TreeNode(val);
            newNode.left = root;
            return newNode;
        }

        int d = 0;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            d++;
            int cnt = q.Count;
            for (int i = 0; i < cnt; i++)
            {
                TreeNode node = q.Dequeue();
                if (node.left != null)
                    q.Enqueue(node.left);

                if (node.right != null)
                    q.Enqueue(node.right);

                if (d == depth - 1)
                {
                    TreeNode cachedLeft = node.left;
                    TreeNode cachedRight = node.right;
                    node.left = new TreeNode(val);
                    node.right = new TreeNode(val);
                    node.left.left = cachedLeft;
                    node.right.right = cachedRight;
                }
            }

            if (d == depth - 1)
                break;
        }

        return root;
    }
}