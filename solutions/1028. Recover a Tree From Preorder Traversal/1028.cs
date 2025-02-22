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
    private int i = 0;

    public TreeNode RecoverFromPreorder(string traversal)
    {
        return RecoverFromPreorder(traversal, 0);
    }

    private TreeNode RecoverFromPreorder(string traversal, int depth)
    {
        int nDashes = 0;
        while (i + nDashes < traversal.Length && traversal[i + nDashes] == '-')
            nDashes++;

        if (nDashes != depth)
            return null;

        i += depth;
        int start = i;
        while (i < traversal.Length && char.IsDigit(traversal[i]))
            i++;

        return new TreeNode(int.Parse(traversal.Substring(start, i - start)),
                            RecoverFromPreorder(traversal, depth + 1),
                            RecoverFromPreorder(traversal, depth + 1));
    }
}