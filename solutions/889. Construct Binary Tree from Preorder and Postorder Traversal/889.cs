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
    public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
    {
        Dictionary<int, int> postToIndex = new Dictionary<int, int>();

        for (int i = 0; i < postorder.Length; ++i)
            postToIndex[postorder[i]] = i;

        return Build(preorder, 0, preorder.Length - 1, postorder, 0, postorder.Length - 1, postToIndex);
    }

    private TreeNode Build(int[] pre, int preStart, int preEnd, int[] post, int postStart,
                           int postEnd, Dictionary<int, int> postToIndex)
    {
        if (preStart > preEnd)
            return null;
        if (preStart == preEnd)
            return new TreeNode(pre[preStart]);

        int rootVal = pre[preStart];
        int leftRootVal = pre[preStart + 1];
        int leftRootPostIndex = postToIndex[leftRootVal];
        int leftSize = leftRootPostIndex - postStart + 1;

        TreeNode root = new TreeNode(rootVal);
        root.left = Build(pre, preStart + 1, preStart + leftSize, post, postStart, leftRootPostIndex,
                          postToIndex);
        root.right = Build(pre, preStart + leftSize + 1, preEnd, post, leftRootPostIndex + 1,
                           postEnd - 1, postToIndex);
        return root;
    }
}