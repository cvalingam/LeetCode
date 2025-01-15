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
    public IList<IList<int>> LevelOrder(Node root)
    {
        if (root == null)
            return new List<IList<int>>();

        IList<IList<int>> ans = new List<IList<int>>();
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            IList<int> currLevel = new List<int>();
            int sz = q.Count;
            for (int i = 0; i < sz; i++)
            {
                Node node = q.Dequeue();
                currLevel.Add(node.val);
                foreach (Node child in node.children)
                    q.Enqueue(child);
            }
            ans.Add(currLevel);
        }

        return ans;
    }
}