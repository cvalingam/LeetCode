// Approach: Iterative pre-order traversal using an explicit stack.
// Push the right child first, then the left child, so the left is popped (visited) first.
// For each dequeued node, set node.right to the next item on the stack and node.left to null.
// This rewires all pointers in-place to form a right-only singly linked list in pre-order.
// Time: O(n) Space: O(n)

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
    public void Flatten(TreeNode root)
    {
        if (root == null)
            return;

        var st = new Stack<TreeNode>();
        st.Push(root);

        while (st.Count > 0)
        {
            root = st.Pop();

            if (root.right != null)
                st.Push(root.right);

            if (root.left != null)
                st.Push(root.left);

            if (st.Count > 0)
                root.right = st.Peek();
            root.left = null;
        }
    }
}