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
    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        Dictionary<int, int> inToIndex = new Dictionary<int, int>();

        for (int i = 0; i < inorder.Length; ++i)
            inToIndex[inorder[i]] = i;

        return Build(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1, inToIndex);
    }

    private TreeNode Build(int[] inorder, int inStart, int inEnd, int[] postorder, int postStart, int postEnd,
                           Dictionary<int, int> inToIndex)
    {
        if (inStart > inEnd)
            return null;

        int rootVal = postorder[postEnd];
        int rootInIndex = inToIndex[rootVal];
        int leftSize = rootInIndex - inStart;

        TreeNode root = new TreeNode(rootVal);
        root.left = Build(inorder, inStart, rootInIndex - 1, postorder, postStart,
                          postStart + leftSize - 1, inToIndex);
        root.right = Build(inorder, rootInIndex + 1, inEnd, postorder, postStart + leftSize,
                           postEnd - 1, inToIndex);
        return root;
    }
}
