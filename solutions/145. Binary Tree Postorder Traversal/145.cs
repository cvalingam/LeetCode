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
    public IList<int> PostorderTraversal(TreeNode root)
    {
        List<int> result = new();
        //PostorderRecursion(root, result);
        //PostorderIterativeUsing2Stack(root, result);
        PostorderIterativeUsing1Stack(root, result);
        return result;
    }

    private void PostorderRecursion(TreeNode root, IList<int> result)
    {
        if (root == null)
            return;

        PostorderRecursion(root.left, result);
        PostorderRecursion(root.right, result);
        result.Add(root.val);
    }

    private void PostorderIterativeUsing2Stack(TreeNode root, IList<int> result)
    {
        if (root == null)
            return;

        Stack<TreeNode> st1 = new Stack<TreeNode>();
        Stack<TreeNode> st2 = new Stack<TreeNode>();
        st1.Push(root);
        while (st1.Count > 0)
        {
            TreeNode node = st1.Pop();
            if (node != null)
                st2.Push(node);

            if (node.left != null)
                st1.Push(node.left);

            if (node.right != null)
                st1.Push(node.right);
        }

        while (st2.Count > 0)
        {
            TreeNode node = st2.Pop();
            result.Add(node.val);
        }
    }

    private void PostorderIterativeUsing1Stack(TreeNode root, IList<int> result)
    {
        if (root == null)
            return;

        Stack<TreeNode> st = new Stack<TreeNode>();
        TreeNode cur = root;

        while (st.Count > 0 || cur != null)
        {
            if (cur != null)
            {
                st.Push(cur);
                cur = cur.left;
            }
            else
            {
                TreeNode temp = st.Peek().right;
                if (temp == null)
                {
                    temp = st.Pop();
                    result.Add(temp.val);
                    while (st.Count > 0 && temp == st.Peek().right)
                    {
                        temp = st.Pop();
                        result.Add(temp.val);
                    }
                }
                else
                    cur = temp;
            }
        }
    }
}