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
    public TreeNode CreateBinaryTree(int[][] descriptions)
    {
        var childToParent = new Dictionary<TreeNode, TreeNode>();
        var valToNode = new Dictionary<int, TreeNode>();

        foreach (int[] d in descriptions)
        {
            int p = d[0];
            int c = d[1];
            int isLeft = d[2];
            TreeNode parent = valToNode.GetValueOrDefault(p, new TreeNode(p));
            TreeNode child = valToNode.GetValueOrDefault(c, new TreeNode(c));
            valToNode[p] = parent;
            valToNode[c] = child;

            childToParent[child] = parent;

            if (isLeft == 1)
                parent.left = child;
            else
                parent.right = child;
        }

        TreeNode root = childToParent.Keys.First();
        while (childToParent.ContainsKey(root))
            root = childToParent[root];

        return root;
    }
}