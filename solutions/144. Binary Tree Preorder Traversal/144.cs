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
    public IList<int> PreorderTraversal(TreeNode root)
    {
        List<int> result = new();
        //PreOrderRecursion(root, result);

        PreOrderIterative(root, result);
        return result;
    }

    private void PreOrderRecursion(TreeNode root, IList<int> result)
    {
        if (root == null)
            return;

        result.Add(root.val);
        PreOrderRecursion(root.left, result);
        PreOrderRecursion(root.right, result);
    }

    private void PreOrderIterative(TreeNode root, IList<int> result)
    {
        if (root == null)
            return;

        Stack<TreeNode> st = new Stack<TreeNode>();
        st.Push(root);

        while (st.Count > 0)
        {
            TreeNode node = st.Pop();
            result.Add(node.val);

            if (node.right != null)
                st.Push(node.right);

            if (node.left != null)
                st.Push(node.left);
        }
    }
}