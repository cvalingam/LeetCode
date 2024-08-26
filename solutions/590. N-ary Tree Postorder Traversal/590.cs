public class Node
{
    public int val;
    public IList<Node> children;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, IList<Node> _children)
    {
        val = _val;
        children = _children;
    }
}

public class Solution
{
    public IList<int> Postorder(Node root)
    {
        if (root == null)
            return new List<int>();

        List<int> ans = new List<int>();
        Stack<Node> stack = new Stack<Node>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            root = stack.Pop();
            ans.Add(root.val);
            foreach (Node child in root.children)
                stack.Push(child);
        }

        ans.Reverse();
        return ans;
    }
}