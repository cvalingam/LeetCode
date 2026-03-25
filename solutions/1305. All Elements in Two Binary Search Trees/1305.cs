// Approach: In-order traversal of each BST produces sorted lists; merge the two sorted lists.
// Time: O(m+n) Space: O(m+n)

public class TreeNode
{
    private Stack<TreeNode> stack = new Stack<TreeNode>();

    public BSTIterator(TreeNode root)
    {
        PushLeftsUntilNull(root);
    }

    public int Peek()
    {
        return stack.Peek().val;
    }

    public void Next()
    {
        PushLeftsUntilNull(stack.Pop().right);
    }

    public bool HasNext()
    {
        return stack.Count > 0;
    }

    private void PushLeftsUntilNull(TreeNode node)
    {
        while (node != null)
        {
            stack.Push(node);
            node = node.left;
        }
    }
}

public class Solution
{
    public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
    {
        List<int> ans = new List<int>();
        BSTIterator bstIterator1 = new BSTIterator(root1);
        BSTIterator bstIterator2 = new BSTIterator(root2);

        while (bstIterator1.HasNext() && bstIterator2.HasNext())
        {
            if (bstIterator1.Peek() < bstIterator2.Peek())
            {
                ans.Add(bstIterator1.Peek());
                bstIterator1.Next();
            }
            else
            {
                ans.Add(bstIterator2.Peek());
                bstIterator2.Next();
            }
        }

        while (bstIterator1.HasNext())
        {
            ans.Add(bstIterator1.Peek());
            bstIterator1.Next();
        }

        while (bstIterator2.HasNext())
        {
            ans.Add(bstIterator2.Peek());
            bstIterator2.Next();
        }

        return ans;
    }
}